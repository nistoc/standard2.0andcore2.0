using Hub.FacebookMessenger.Send.Base;

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// Используется при отправке текстового сообщения, должен быть в формате UTF-8 и может содержать не более 640 символов
    /// </summary>
    public class FacebookMessageContentViaText: FacebookMessageContentBase
    {
        public FacebookMessageContentViaText(string messageText)
        {
            text = messageText;
        }
        /// <summary>
        /// Текст сообщения. Предварительный просмотр URL в этом поле недоступен. Вместо него используйте свойство attachment.
        /// - Обязательный
        /// </summary>
        public string text { get; }
    }
}