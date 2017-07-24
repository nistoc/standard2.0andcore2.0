using Newtonsoft.Json;
// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// модель быстрого ответа: получить местоположение
    /// </summary>
    public class FacebookMessageContentQuickReplyLocation : FacebookMessageContentQuickReplyBase
    {
        public FacebookMessageContentQuickReplyLocation(): base("location")
        {
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}