namespace NServiceBus.AzureEventGrid.StorageQueues.Tests
{
    using Settings;
    using Xunit;

    public class When_registering_more_than_once : InitializeStaticsFixture
    {
        [Fact]
        public void Should_not_throw()
        {
            var transportExtensions = new TransportExtensions<AzureStorageQueueTransport>(new SettingsHolder());
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);
        }
    }
}