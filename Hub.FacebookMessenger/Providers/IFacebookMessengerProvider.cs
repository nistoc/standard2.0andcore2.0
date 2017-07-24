using System.Collections.Generic;
using System.Threading.Tasks;
using Hub.FacebookMessenger.Send;

namespace Hub.FacebookMessenger.Providers
{
    /// <summary>
    /// Обеспечивает коммуникацию с Massenger Facebook
    /// </summary>
    public interface IFacebookMessengerProvider
    {
        /// <summary>
        /// Начали печатать
        /// </summary>
        Task<string> SendTypingOnAsync(string recipientId);

        /// <summary>
        /// Закончили печатать
        /// </summary>
        Task<string> SendTypingOffAsync(string recipientId);

        /// <summary>
        /// Посмотрели сообщение
        /// </summary>
        Task<string> SendMarkSeenAsync(string recipientId);

        /// <summary>
        /// Отправить обычное текстове сообщение
        /// </summary>
        Task<string> SendTextOnlyAsync(string recipientId, string messageText, string callBackMatadata);

        /// <summary>
        /// Отправить текстовое сообщение с текстовыми вариантами ответа
        /// </summary>
        Task<string> SendQuickRepliesTextsAsync(string recipientId, string messageText, string callBackMatadata, List<FacebookMessageContentQuickReplyText> quickReplies);

        /// <summary>
        /// Отправить текстовое сообщение с запросом локации
        /// </summary>
        Task<string> SendQuickRepliesLocationAsync(string recipientId, string messageText, string callBackMatadata);
    }
}
