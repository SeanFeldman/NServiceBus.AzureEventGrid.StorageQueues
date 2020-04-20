namespace NServiceBus.AzureEventGrid.StorageQueues.Tests
{
    using System.IO;
    using global::Microsoft.Storage;
    using global::Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using Settings;
    using Xunit;

    public class When_processing_EventGrid_Storage_event : InitializeStaticsFixture
    {
        const string @event = @"{
  ""topic"": ""/subscriptions/<guid>/resourceGroups/<rg>/providers/Microsoft.Storage/storageAccounts/<storage-account>"",
  ""subject"": ""/blobServices/default/containers/uploads/blobs/file.json"",
  ""eventType"": ""Microsoft.Storage.BlobCreated"",
  ""eventTime"": ""2018-07-19T04:05:16.3666265Z"",
  ""id"": ""65216123-501e-002f-0517-1abc1d06b007"",
  ""data"": {
    ""api"": ""PutBlob"",
    ""clientRequestId"": ""f15c08e0-b6a9-11e8-b16a-1d5a6655a317"",
    ""requestId"": ""45216011-501e-2f32-4915-1faa1d000000"",
    ""eTag"": ""0x8D5ED2CD5C5F045"",
    ""contentType"": ""application/xml"",
    ""contentLength"": 1308,
    ""blobType"": ""BlockBlob"",
    ""url"": ""https://eventgridtest.blob.core.windows.net/eventgrid-post/file.txt"",
    ""sequencer"": ""000000000000000000000000000000BF000000000042e65c"",
    ""storageDiagnostics"": {
      ""batchId"": ""a303a38a-b4d7-41f0-928c-50e54f55e7df""
    }
  },
  ""dataVersion"": """",
  ""metadataVersion"": ""1""
}";

        [Fact]
        public void Should_copy_over_EventGrid_metadata()
        {
            var message = new CloudQueueMessage(@event);
            var transportExtensions = new TransportExtensions<AzureStorageQueueTransport>(new SettingsHolder());
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);
            var wrapper = AzureStorageQueuesTransportExtensions.tesingUnwrapper(message);

            Assert.Equal("/subscriptions/<guid>/resourceGroups/<rg>/providers/Microsoft.Storage/storageAccounts/<storage-account>", wrapper.Headers["EventGrid.topic"]);
            Assert.Equal("/blobServices/default/containers/uploads/blobs/file.json", wrapper.Headers["EventGrid.subject"]);
            Assert.Equal("2018-07-19 04:05:16:366626 Z", wrapper.Headers["EventGrid.eventTime"]);
            Assert.Equal("", wrapper.Headers["EventGrid.dataVersion"]);
            Assert.Equal("1", wrapper.Headers["EventGrid.metadataVersion"]);
            Assert.Equal("Microsoft.Storage.BlobCreated", wrapper.Headers[Headers.EnclosedMessageTypes]);
            Assert.Equal("65216123-501e-002f-0517-1abc1d06b007", wrapper.Id);
        }

        [Fact]
        public void Should_store_data_as_serialized_body()
        {
            var message = new CloudQueueMessage(@event);
            var transportExtensions = new TransportExtensions<AzureStorageQueueTransport>(new SettingsHolder());
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);
            var wrapper = AzureStorageQueuesTransportExtensions.tesingUnwrapper(message);

            using (var stream = new MemoryStream(wrapper.Body))
            using (var streamReader = new StreamReader(stream))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var jsonSerializer = new JsonSerializer();
                var body = jsonSerializer.Deserialize<BlobCreated>(textReader);

                Assert.Equal("PutBlob", body.Api);
                Assert.Equal("BlockBlob", body.BlobType);
                Assert.Equal("f15c08e0-b6a9-11e8-b16a-1d5a6655a317", body.ClientRequestId);
                Assert.Equal("application/xml", body.ContentType);
                Assert.Equal(1308, body.ContentLength);
                Assert.Equal("https://eventgridtest.blob.core.windows.net/eventgrid-post/file.txt", body.Url);
                Assert.Equal("0x8D5ED2CD5C5F045", body.ETag);
                Assert.Equal("45216011-501e-2f32-4915-1faa1d000000", body.RequestId);
                Assert.Equal("f15c08e0-b6a9-11e8-b16a-1d5a6655a317", body.ClientRequestId);
                Assert.Equal("000000000000000000000000000000BF000000000042e65c", body.Sequencer);
            }
        }
    }
}
