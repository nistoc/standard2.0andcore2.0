using System.Collections;
// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{
    public abstract class FacebookMessageContentQuickReplyBaseList : IEnumerable
    {
        protected virtual IEnumerable Items { get; set; }
        public abstract IEnumerator GetEnumerator();
    }
}