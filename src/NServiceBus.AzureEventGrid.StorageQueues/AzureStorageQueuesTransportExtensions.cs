namespace NServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using Azure.Transports.WindowsAzureStorageQueues;
    using AzureEventGrid.StorageQueues;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary></summary>
    public static class AzureStorageQueuesTransportExtensions
    {
        internal  static Func<CloudQueueMessage, MessageWrapper> tesingUnwrapper { get; private set; }

        /// <summary>
        /// Allow processing of EventGrid events
        /// </summary>
        public static void EnableSupportForEventGridEvents(this TransportExtensions<AzureStorageQueueTransport> transportExtensions)
        {
            var jsonSerializer = new Newtonsoft.Json.JsonSerializer();

            Func<CloudQueueMessage, MessageWrapper> unwrapper = cloudQueueMessage =>
            {
                using (var stream = new MemoryStream(cloudQueueMessage.AsBytes))
                using (var streamReader = new StreamReader(stream))
                using (var textReader = new JsonTextReader(streamReader))
                {
                    var jObject = JObject.Load(textReader);

                    using (var jsonReader = jObject.CreateReader())
                    {
                        //try deserialize to a NServiceBus envelope first
                        var wrapper = jsonSerializer.Deserialize<MessageWrapper>(jsonReader);

                        if (wrapper.MessageIntent != default)
                        {
                            //this was a envelope message
                            return wrapper;
                        }
                    }

                    //this was an EventGrid event
                    using (var jsonReader = jObject.CreateReader())
                    {
                        var @event = jsonSerializer.Deserialize<EventGridEvent>(jsonReader);

                        var wrapper = new MessageWrapper
                        {
                            Id = @event.Id,
                            Headers = new Dictionary<string, string>
                            {
                                {Headers.EnclosedMessageTypes, @event.EventType},
                                {"EventGrid.topic", @event.Topic},
                                {"EventGrid.subject", @event.Subject},
                                {"EventGrid.eventTime", @event.EventTime.ToUniversalTime().ToString(format, CultureInfo.InvariantCulture)},
                                {"EventGrid.dataVersion", @event.DataVersion},
                                {"EventGrid.metadataVersion", @event.MetadataVersion},
                            },
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event.Data)),
                            MessageIntent = MessageIntentEnum.Publish
                        };
                        return wrapper;
                    }
                }
            };

            transportExtensions.UnwrapMessagesWith(unwrapper);

            tesingUnwrapper = unwrapper;
        }

        const string format = "yyyy-MM-dd HH:mm:ss:ffffff Z";
    }
}
