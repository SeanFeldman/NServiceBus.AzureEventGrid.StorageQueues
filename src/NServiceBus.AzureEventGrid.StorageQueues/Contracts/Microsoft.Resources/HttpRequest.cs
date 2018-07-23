namespace Microsoft.Resources
{
    /// <summary>
    /// The details of the operation.
    /// </summary>
    public class HttpRequest
    {
        /// <summary></summary>
        public string ClientRequestId { get; set; }
        /// <summary></summary>
        public string ClientIpAddress { get; set; }
        /// <summary></summary>
        public string Method { get; set; }
        /// <summary></summary>
        public string Url { get; set; }
    }
}