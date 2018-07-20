namespace NServiceBus.AzureEventGrid.StorageQueues.Tests
{
    using System;
    public class InitializeStaticsFixture : IDisposable
    {
        public InitializeStaticsFixture()
        {
            AzureStorageQueuesTransportExtensions.unwrapper = null;
        }
        public void Dispose()
        {
        }
    }
}