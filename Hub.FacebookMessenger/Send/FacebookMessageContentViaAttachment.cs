using Hub.FacebookMessenger.Send.Base;

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// используется для отправки сообщений с изображениями или структурированных сообщений
    /// </summary>
    public class FacebookMessageContentViaAttachment: FacebookMessageContentBase
    {
        /// <summary>
        /// Объект attachment. Обеспечивает предварительный просмотр URL.
        /// - Обязательный
        /// </summary>
        public FacebookMessageContentAttachment attachment { get; set; }
    }
}
