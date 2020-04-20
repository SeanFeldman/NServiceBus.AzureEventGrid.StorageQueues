namespace NServiceBus.AzureEventGrid.StorageQueues.Tests
{
    using System.Collections.Generic;
    using System.Text;
    using Azure.Transports.WindowsAzureStorageQueues;
    using global::Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using Settings;
    using Xunit;

    public class When_processing_NServiceBus_message : InitializeStaticsFixture
    {
        [Fact]
        public void Should_not_fail()
        {
            var @event = new MessageWrapper
            {
                MessageIntent = MessageIntentEnum.Publish,
                Headers = new Dictionary<string, string>(),
                Id = "12345",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new SomeEvent { Data = "event"}))
            };
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(@event));

            var transportExtensions = new TransportExtensions<AzureStorageQueueTransport>(new SettingsHolder());
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);
            var wrapper = AzureStorageQueuesTransportExtensions.tesingUnwrapper(message);

            Assert.Equal(@event.Id, wrapper.Id);
            Assert.Equal(MessageIntentEnum.Publish, @event.MessageIntent);
            Assert.Empty(@event.Headers);
        }
    }

    public class SomeEvent : IEvent
    {
        public string Data { get; set; }
    }
}
