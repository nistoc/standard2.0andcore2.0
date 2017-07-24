using Hub.FacebookMessenger.Send.Base;
using Newtonsoft.Json;

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    public class FacebookPushMessageViaAttachment: FacebookPushBase
    {
        public FacebookPushMessageViaAttachment(string recipientId)
        {
            recipient.id = recipientId;
            message.attachment = new FacebookMessageContentAttachment();
        }

        
        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public FacebookMessageContentViaAttachment message { get; } = new FacebookMessageContentViaAttachment();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
