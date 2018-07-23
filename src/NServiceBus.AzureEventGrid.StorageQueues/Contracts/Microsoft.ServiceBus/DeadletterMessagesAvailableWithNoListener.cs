namespace Microsoft.ServiceBus
{
    /// <summary>
    /// Raised when there are active messages in a Dead Letter Queue and no active listeners.
    /// </summary>
    public class DeadletterMessagesAvailableWithNoListener
    {
        /// <summary>
        /// The Service Bus namespace the resource exists in.
        /// </summary>
        public string NamespaceName { get; set; }
        /// <summary>
        /// The URI to the specific queue or subscription emitting the event.
        /// </summary>
        public string Uri { get; set; }
        /// <summary>
        /// The type of Service Bus entity emitting events (queue or subscription).
        /// </summary>
        public string EntityType { get; set; }
        /// <summary>
        /// The queue with active messages if subscribing to a queue. Value null if using topics / subscriptions.
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// The topic the Service Bus subscription with active messages belongs to. Value null if using a queue.
        /// </summary>
        public string TopicName { get; set; }
        /// <summary>
        /// The Service Bus subscription with active messages. Value null if using a queue.
        /// </summary>
        public string SubscriptionName { get; set; }
    }
}