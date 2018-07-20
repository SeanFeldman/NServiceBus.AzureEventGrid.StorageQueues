namespace NServiceBus.AzureEventGrid.StorageQueues
{
    using System;
    using Newtonsoft.Json;

    class EventGridEvent
    {
        /// <summary>
        /// Gets or sets an unique identifier for the event.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource path of the event source.
        /// </summary>
        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        /// <summary>
        /// Gets or sets a resource path relative to the topic path.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets event data specific to the event type.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the type of the event that occurred.
        /// </summary>
        [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the time (in UTC) the event was generated.
        /// </summary>
        [JsonProperty(PropertyName = "eventTime")]
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets the schema version of the event metadata.
        /// </summary>
        [JsonProperty(PropertyName = "metadataVersion")]
        public string MetadataVersion { get; private set; }

        /// <summary>
        /// Gets or sets the schema version of the data object.
        /// </summary>
        [JsonProperty(PropertyName = "dataVersion")]
        public string DataVersion { get; set; }
    }
}