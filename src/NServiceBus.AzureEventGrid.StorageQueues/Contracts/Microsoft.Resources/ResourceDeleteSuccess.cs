namespace Microsoft.Resources
{
    using System.Collections.Generic;
    using NServiceBus;

    /// <summary>
    /// Raised when a resource delete operation succeeds.
    /// </summary>
    public class ResourceDeleteSuccess : IEvent
    {
        /// <summary>
        /// 	The requested authorization for the operation.
        /// </summary>
        public Authorization Authorization { get; set; }
        /// <summary>
        /// The properties of the claims. For more information, see JWT specification (http://self-issued.info/docs/draft-ietf-oauth-json-web-token.html).
        /// </summary>
        public Dictionary<string, string> Claims { get; set; }
        /// <summary>
        /// An operation ID for troubleshooting.
        /// </summary>
        public string CorrelationId { get; set; }
        /// <summary>
        /// The details of the operation.
        /// </summary>
        public HttpRequest HttpRequest { get; set; }
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