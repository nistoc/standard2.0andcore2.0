using System.Collections;
using System.Collections.Generic;

namespace Hub.FacebookMessenger.Send
{
    public sealed class FacebookMessageContentQuickReplyTextList : FacebookMessageContentQuickReplyBaseList
    {
        public new List<FacebookMessageContentQuickReplyText> Items { get; set; }

        public override IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }

    }
}