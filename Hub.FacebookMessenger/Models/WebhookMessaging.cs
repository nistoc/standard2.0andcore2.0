using System;

namespace Hub.FacebookMessenger.Models
{
    /// <summary>
    /// Message Received Callback
    /// </summary>
    public class WebhookMessaging
    {
        /// <summary>
        /// "id":"USER_ID"
        /// </summary>
        public WebhookMessagingSender sender { get; set; }

        /// <summary>
        /// "id":"PAGE_ID"
        /// </summary>
        public WebhookMessagingSender recipient { get; set; }

        /// <summary>
        ///  огда отправлено обновление (не при внесении изменени€, которое активировало это обновление).
        /// </summary>
        public double timestamp { get; set; }

        /// <summary>
        ///  огда отправлено обновление (не при внесении изменени€, которое активировало это обновление).
        /// </summary>
        public DateTime DateTimeFrom1970
        {
            get
            {
                var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                try
                {
                    dtDateTime = dtDateTime.AddMilliseconds(timestamp);
                }
                catch
                {
                    //
                }
                return dtDateTime;
            }
        }

        /// <summary>
        /// This callback will occur when a message has been sent to your page. 
        /// You may receive text messages or messages with attachments (image, audio, video, file, or location). You may also receive fallback
        /// </summary>
        public WebhookMessagingMessage message { get; set; }

        /// <summary>
        /// This callback will occur when a message a page has sent has been delivered. 
        /// You can subscribe to this callback by selecting the message_deliveries field when setting up your webhook
        /// </summary>
        public WebhookMessagingDelivery delivery { get; set; }

        /// <summary>
        /// This callback will occur when a message a page has sent has been read by the user.
        /// You can subscribe to this callback by selecting the message_reads field when setting up your webhook
        /// </summary>
        public WebhookMessagingRead read { get; set; }
    }
}