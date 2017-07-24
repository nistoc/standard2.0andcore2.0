using System.Collections;
using System.Collections.Generic;

namespace Hub.FacebookMessenger.Send
{
    public sealed class FacebookMessageContentQuickReplyLocationList : FacebookMessageContentQuickReplyBaseList
    {
        public new List<FacebookMessageContentQuickReplyLocation> Items { get; set; }

        public override IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}