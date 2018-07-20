namespace NServiceBus.AzureEventGrid.StorageQueues.Tests
{
    using System;
    using Settings;
    using Xunit;

    public class When_registering_more_than_once : InitializeStaticsFixture
    {
        [Fact]
        public void Should_throw()
        {
            var transportExtensions = new TransportExtensions<AzureStorageQueueTransport>(new SettingsHolder());
            AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions);

            Assert.Throws<InvalidOperationException>(() => AzureStorageQueuesTransportExtensions.EnableSupportForEventGridEvents(transportExtensions));
        }
    }
}