namespace FacebookMessenger.Models
{
    /// <summary>
    /// The watermark field is used to determine which messages were read. 
    /// It represents a timestamp indicating that all messages with a timestamp before watermark were read by the recipient
    /// </summary>
    public class WebhookMessagingRead
    {

        /// <summary>
        /// All messages that were sent before this timestamp were read
        /// </summary>
        public double watermark { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        public int seq { get; set; }
    }
}