namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// 
    /// </summary>
    public enum FacebookSendNotificationType
    {
        /// <summary>
        /// звук или вибрация и уведомление на телефоне
        /// </summary>
        REGULAR,

        /// <summary>
        /// только уведомление на телефоне
        /// </summary>
        SILENT_PUSH,

        /// <summary>
        /// без уведомлений
        /// </summary>
        NO_PUSH
    }
}