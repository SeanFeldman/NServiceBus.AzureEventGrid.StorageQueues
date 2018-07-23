namespace Microsoft.ContainerRegistry
{
    // TODO: fix when https://github.com/MicrosoftDocs/azure-docs/issues/12193 is addressed

    /// <summary>
    /// Raised when an image is pushed.
    /// </summary>
    /*public*/ class ImagePushed
    {
        /// <summary>
        /// The event ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The time at which the event occurred.
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// The action that encompasses the provided event.
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// The target of the event.
        /// </summary>
        public Target Target { get; set; }
        /// <summary>
        /// The request that generated the event.
        /// </summary>
        public Request Request { get; set; }
    }

    /// <summary></summary>
    /*public*/ class Target
    {
        /// <summary>
        /// The MIME type of the referenced object.
        /// </summary>
        public string MediaType { get; set; }
        /// <summary>
        /// The number of bytes of the content. Same as Length field.
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// The digest of the content, as defined by the Registry V2 HTTP API Specification.
        /// </summary>
        public string Digest { get; set; }
        /// <summary>
        /// The number of bytes of the content. Same as Size field.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// The repository name.
        /// </summary>
        public string Repository { get; set; }
        /// <summary>
        /// The direct URL to the content.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The tag name.
        /// </summary>
        public string Tag { get; set; }
    }

    /// <summary></summary>
    /*public*/ class Request
    {
        /// <summary>
        /// The event ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The IP or hostname and possibly port of the client connection that initiated the event. This value is the RemoteAddr from the standard http request.
        /// </summary>
        public string Attr { get; set; }
        /// <summary>
        /// The externally accessible hostname of the registry instance, as specified by the http host header on incoming requests.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// The request method that generated the event.
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// The user agent header of the request.
        /// </summary>
        public string Useragent { get; set; }
    }
}