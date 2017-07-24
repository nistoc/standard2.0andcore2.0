using System.Threading.Tasks;

namespace Hub.FacebookMessenger.Providers
{
    /// <summary>
    /// Обеспечивает коммуникацию с Massenger Facebook
    /// </summary>
    public interface IFacebookMessengerProvider
    {
        /// <summary>
        /// Отправить сообщение
        /// </summary>
        Task<string> SendTypingOnAsync(string recipientId);

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        Task<string> SendTypingOffAsync(string recipientId);

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        Task<string> SendMarkSeenAsync(string recipientId);

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        Task<string> SendMessageAsync(string recipientId, string messageText);

        Task<string> SendMessageLocationAsync(string recipientId);
    }
}
