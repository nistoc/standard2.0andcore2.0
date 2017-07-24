using System.Collections.Generic;

namespace Hub.FacebookMessenger.Models
{
    /// <summary>
    /// Both mids and watermark fields are used to determine which messages were delivered. 
    /// 
    /// - watermark is always present and mids is sometimes present. 
    /// - mids provides delivery receipts on a per-message basis but may not be present (due to backward compatibility reasons with older Messenger clients). 
    /// 
    /// watermark is always present and is a timestamp indicating that all messages with a timestamp before watermark were delivered.
    /// </summary>
    public class WebhookMessagingDelivery
    {
        /// <summary>
        /// Array containing message IDs of messages that were delivered. Field may not be present.
        /// </summary>
        public List<string> mids { get; set; }

        /// <summary>
        /// All messages that were sent before this timestamp were delivered
        /// </summary>
        public double watermark { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        public int seq { get; set; }
    }
}