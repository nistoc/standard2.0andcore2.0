using Hub.FacebookMessenger.Send.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hub.FacebookMessenger.Send
{

    public class FacebookPushSenderAction: FacebookPushBase
    {
        public FacebookPushSenderAction(string recipientId, FacebookSenderActionType senderActionType)
        {
            recipient.id = recipientId;
            sender_action = senderActionType;
        }

        /// <summary>
        /// Состояние сообщения: typing_on, typing_off, mark_seen
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FacebookSenderActionType sender_action {get;set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
