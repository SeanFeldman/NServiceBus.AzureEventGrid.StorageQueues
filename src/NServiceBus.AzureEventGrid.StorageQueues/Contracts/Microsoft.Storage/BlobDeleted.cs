namespace Microsoft.Storage
{
    using NServiceBus;

    public class BlobDeleted : IEvent
    {
        public string Api { get; set; }
        public string RequestId { get; set; }

        public string ContentType { get; set; }
        public string BlobType { get; set; }
        public string Url { get; set; }
        public string Sequencer { get; set; }
    }
}