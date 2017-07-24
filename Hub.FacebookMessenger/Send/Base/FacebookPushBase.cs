using Hub.FacebookMessenger.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hub.FacebookMessenger.Send.Base
{
    public abstract class FacebookPushBase
    {
        /// <summary>
        /// Получатель
        /// </summary>
        public FacebookMessagingPartner recipient { get; } = new FacebookMessagingPartner();

        /// <summary>
        /// не является обязательным; 
        /// по умолчанию для сообщений будет выбран тип push-уведомлений REGULAR
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookSendNotificationType notification_type { get; set; } = FacebookSendNotificationType.REGULAR;
    }
}
