using Newtonsoft.Json;
// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// модель быстрого ответа: получить текст
    /// </summary>
    public class FacebookMessageContentQuickReplyText: FacebookMessageContentQuickReplyBase
    {
        public FacebookMessageContentQuickReplyText(): base("text")
        {
        }

        /// <summary>
        /// Подпись для кнопки
        /// - Обязательно: Только если content_type имеет значение text
        /// - Лимит title составляет 20 символов. В случае превышения этого лимита заголовок будет обрезан.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Индивидуально настроенные данные, которые будут отправлены от Facebook обратно через Webhook
        /// - Обязательно: Только если content_type имеет значение text
        /// - Лимит не более 1 000 символов
        /// </summary>
        public string payload { get; set; }

        /// <summary>
        /// URL изображения для быстрых ответов text
        /// - Не обязательно.
        /// - Изображение должно быть размером не менее 24 x 24. Оно будет кадрировано, и его размер будет изменен
        /// </summary>
        public string image_url { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}