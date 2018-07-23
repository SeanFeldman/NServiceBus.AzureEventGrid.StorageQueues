namespace Microsoft.EventHub
{
    /// <summary>
    /// Event when a capture file is created.
    /// </summary>
    public class CaptureFileCreated
    {
        /// <summary>
        /// The path to the capture file.
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// The file type of the capture file.
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// The shard ID.
        /// </summary>
        public string PartitionId { get; set; }
        /// <summary>
        /// The file size.
        /// </summary>
        public int SizeInBytes { get; set; }
        /// <summary>
        /// The number of events in the file.
        /// </summary>
        public int EventCount { get; set; }
        /// <summary>
        /// The smallest sequence number from the queue.
        /// </summary>
        public int FirstSequenceNumber { get; set; }
        /// <summary>
        /// The last sequence number from the queue.
        /// </summary>
        public int LastSequenceNumber { get; set; }
        /// <summary>
        /// The first time from the queue.
        /// </summary>
        public string FirstEnqueueTime { get; set; }
        /// <summary>
        /// The last time from the queue.
        /// </summary>
        public string LastEnqueueTime { get; set; }
    }
}