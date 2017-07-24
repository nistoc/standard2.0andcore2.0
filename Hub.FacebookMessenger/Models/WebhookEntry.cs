using System;
using System.Collections.Generic;

namespace Hub.FacebookMessenger.Models
{
    /// <summary>
    /// Список изменений. Изменения, внесенные в разные объекты одного типа, объединяются
    /// </summary>
    public class WebhookEntry
    {
        /// <summary>
        /// ID объекта
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Когда отправлено обновление (не при внесении изменения, которое активировало это обновление).
        /// </summary>
        public double time { get; set; }

        /// <summary>
        /// Когда отправлено обновление (не при внесении изменения, которое активировало это обновление).
        /// </summary>
        public DateTime DateTimeFrom1970
        {
            get
            {
                var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                try
                {
                    dtDateTime = dtDateTime.AddMilliseconds(time);
                }
                catch
                {
                    //
                }
                return dtDateTime;
            }
        }

        /// <summary>
        /// Массив обновленных полей
        /// </summary>
        public string[] changed_fields { get; set; }

        /// <summary>
        /// Массив с только что обновленными значениями. Возвращается только для подписок на *page*.
        /// </summary>
        public object[] changes { get; set; }


        /// <summary>
        /// Message Received Callback
        /// </summary>
        public List<WebhookMessaging> messaging { get; set; }

    }
}