namespace Microsoft.Resources
{
    /// <summary>
    /// Raised when a resource create or update operation fails.
    /// </summary>
    public class ResourceWriteFailure
    {
        /// <summary>
        /// The resource provider performing the operation.
        /// </summary>
        public string ResourceProvider { get; set; }
        /// <summary>
        /// The URI of the resource in the operation.
        /// </summary>
        public string ResourceUri { get; set; }
        /// <summary>
        /// The operation that was performed.
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// The status of the operation.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The subscription ID of the resource.
        /// </summary>
        public string SubscriptionId { get; set; }
        /// <summary>
        /// The tenant ID of the resource.
        /// </summary>
        public string TenantId { get; set; }
    }
}