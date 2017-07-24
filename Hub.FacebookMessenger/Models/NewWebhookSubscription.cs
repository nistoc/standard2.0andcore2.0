using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hub.FacebookMessenger.Models
{
    /// <summary>
    /// информация об обновлении в полях, на которые мы подписались
    /// </summary>
    public class NewWebhookSubscription
    {
        /// <summary>
        /// Указывает тип объекта
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public NewWebhookSubsctiptionType @object { get; set; }

        /// <summary>
        /// Список изменений. Изменения, внесенные в разные объекты одного типа, объединяются
        /// </summary>
        public List<WebhookEntry> entry { get; set; }
    }
}