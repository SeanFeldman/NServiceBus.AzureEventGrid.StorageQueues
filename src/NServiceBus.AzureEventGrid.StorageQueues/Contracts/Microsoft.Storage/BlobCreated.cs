namespace Microsoft.Storage
{
    using NServiceBus;

    /// <summary>
    /// Raised when a blob is created.
    /// </summary>
    public class BlobCreated : IEvent
    {
        /// <summary>
        /// The operation that triggered the event.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// A client-generated, opaque value with a 1-KB character limit. When you have enabled storage analytics logging, it is recorded in the analytics logs.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// The unique identifier for the request. Use it for troubleshooting the request.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// The value that you can use to perform operations conditionally.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The content type specified for the blob.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 	The size of the blob in bytes.
        /// </summary>
        public int ContentLength { get; set; }

        /// <summary>
        /// The type of blob. Valid values are either "BlockBlob" or "PageBlob".
        /// </summary>
        public string BlobType { get; set; }

        /// <summary>
        /// The path to the blob.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// A user-controlled value that you can use to track requests.
        /// </summary>
        public string Sequencer { get; set; }
    }
}