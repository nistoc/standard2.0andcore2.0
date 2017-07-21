using System.Collections.Generic;

namespace FacebookMessenger.Models
{
    public class WebhookMessagingMessage
    {
        #region This callback will occur when a message has been sent by your page

        /// <summary>
        /// Indicates the message sent from the page itself
        /// </summary>
        public bool is_echo { get; set; }
        /// <summary>
        /// ID of the app from which the message was sent
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// Custom string passed to the Send API as the metadata field
        /// </summary>
        public string metadata { get; set; }

        #endregion This callback will occur when a message has been sent by your page

        /// <summary>
        /// Message ID
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// Text of message
        /// escaped в формате Unicode с шестнадцатеричными цифрами в нижнем регистр
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int seq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double sticker_id { get; set; }

        /// <summary>
        /// Array containing attachment data
        /// </summary>
        public List<WebhookMessagingAttachment> attachments { get; set; }

        /// <summary>
        /// Optional custom data provided by the sending app
        /// </summary>
        public WebhookMessagingQuickReply quick_reply { get; set; }
    }
    /// <summary>
    /// A quick_reply payload is only provided with a text message when the user tap on a Quick Replies (https://developers.facebook.com/docs/messenger-platform/send-api-reference/quick-replies) button
    /// </summary>
    public class WebhookMessagingQuickReply
    {
        /// <summary>
        /// Custom data provided by the app
        /// </summary>
        public string payload { get; set; }
    }

    public class WebhookMessagingAttachment
    {
        /// <summary>
        /// Title of the attachment
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// audio, fallback, file, image, location or video
        /// or
        /// fallback attachments, which are attachments in Messenger other than the ones mentioned above
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// URL to the attachment
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// multimedia or location payload
        /// </summary>
        public WebhookMessagingAttachmentPayload payload { get; set; }
    }

    public class WebhookMessagingAttachmentPayload
    {
        /// <summary>
        /// URL of the file
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double sticker_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WebhookMessagingAttachmentPayloadCoordinates coordinates { get; set; }

    }

    public class WebhookMessagingAttachmentPayloadCoordinates
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double @long { get; set; }


    }
}