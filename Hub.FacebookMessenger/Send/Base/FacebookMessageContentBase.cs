using System;
using System.Collections;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{

    public abstract class FacebookMessageContentBase
    {
        /// <summary>
        /// быстрые ответы
        /// - Не обязательный
        /// - Не более 11
        /// </summary>
        public FacebookMessageContentQuickReplyBaseList quick_replies { get; set; }

        /// <summary>
        /// Пользовательская строка, которая доставляется как отзеркаленное сообщение.
        /// - Не обязательный
        /// - Не более 1 000 символов
        /// https://developers.facebook.com/docs/messenger-platform/webhook-reference/message-echo
        /// </summary>
        public string metadata { get; set; }
    }
}