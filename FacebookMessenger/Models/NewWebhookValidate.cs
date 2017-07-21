namespace FacebookMessenger.Models
{
    /// <summary>
    /// подтвердить наш собственный эндпойнт во время настройки или обновления имеющейся подписки
    /// </summary>
    public class NewWebhookValidate
    {
        /// <summary>
        /// subscribe
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// случайная строка
        /// </summary>
        public int challenge { get; set; }

        /// <summary>
        /// значение verify_token, которое вы указываете при настройке Webhook для своего приложения
        /// </summary>
        public string verify_token { get; set; }
    }
}