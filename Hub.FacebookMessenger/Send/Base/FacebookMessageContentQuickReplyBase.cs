// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// модель быстрого текстового ответа
    /// </summary>
    public abstract class FacebookMessageContentQuickReplyBase
    {
        protected FacebookMessageContentQuickReplyBase(string contentType)
        {
            content_type = contentType;
        }

        /// <summary>
        /// *text* или *location*
        /// </summary>
        public string content_type { get; }

        /// <summary>
        /// URL изображения для быстрых ответов text
        /// - Не обязательно.
        /// - Изображение должно быть размером не менее 24 x 24. Оно будет кадрировано, и его размер будет изменен
        /// </summary>
        public string image_url { get; set; }
    }
}