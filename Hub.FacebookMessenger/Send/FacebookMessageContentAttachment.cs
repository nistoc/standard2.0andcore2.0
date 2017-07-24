using System.Reflection;

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// используется для отправки сообщений с изображениями или структурированных сообщений
    /// </summary>
    public class FacebookMessageContentAttachment
    {
        /// <summary>
        /// Тип вложения, может иметь значения image, audio, video, file или template
        /// - Обязательный
        /// </summary>
        public string type { get; set; }


        //todo: реализовать класс для добавления вложений
        //todo: класс трубет доработки - добавить реализацию повторного использования Вложений
        /// <summary>
        /// Можно включить следующие элементы:
        /// - Мультимедийные сообщения, содержащие 
        ///     * изображения https://developers.facebook.com/docs/messenger-platform/send-api-reference/image-attachment
        ///     * аудиозаписи https://developers.facebook.com/docs/messenger-platform/send-api-reference/audio-attachment
        ///     * видео https://developers.facebook.com/docs/messenger-platform/send-api-reference/video-attachment
        ///     * файлы https://developers.facebook.com/docs/messenger-platform/send-api-reference/file-attachment
        /// - Шаблоны, в том числе 
        ///     * общий шаблон https://developers.facebook.com/docs/messenger-platform/send-api-reference/generic-template
        ///     * шаблон кнопки https://developers.facebook.com/docs/messenger-platform/send-api-reference/button-template
        ///     * шаблон квитанции https://developers.facebook.com/docs/messenger-platform/send-api-reference/receipt-template
        ///     * шаблон списка https://developers.facebook.com/docs/messenger-platform/send-api-reference/list-template
        /// 
        /// *!!* Добавить реализацию повторного использования Вложений https://developers.facebook.com/docs/messenger-platform/send-api-reference#attachment_reuse
        /// </summary>
        public string payload { get; set; }
    }

}