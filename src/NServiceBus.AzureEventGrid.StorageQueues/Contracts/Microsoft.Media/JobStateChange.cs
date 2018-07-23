namespace NServiceBus.AzureEventGrid.StorageQueues.Microsoft.Media
{
    /// <summary>
    /// Raised when a state of the Job changes.
    /// </summary>
    public class JobStateChange
    {
        /// <summary>
        /// The state of the job before the event.
        /// </summary>
        public string PreviousState { get; set; }
        /// <summary>
        /// The new state of the job being notified in this event. For example, "Queued: The Job is awaiting resources" or “Scheduled: The job is ready to start".
        /// </summary>
        public string State { get; set; }
    }
}