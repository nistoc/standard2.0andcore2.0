using Hub.FacebookMessenger.Send.Base;
using Newtonsoft.Json;

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    public class FacebookPushMessageViaText : FacebookPushBase
    {
        public FacebookPushMessageViaText(string recipientId, string messageText)
        {
            recipient.id = recipientId;
            message = new FacebookMessageContentViaText(messageText);
        }


        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public FacebookMessageContentViaText message { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
