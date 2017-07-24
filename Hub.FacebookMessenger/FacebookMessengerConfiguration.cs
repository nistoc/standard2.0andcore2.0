using System;

namespace Hub.FacebookMessenger
{
    public class FacebookMessengerConfiguration
    {
        /// <summary>
        /// Адрес API
        /// </summary>
        public Uri BaseAddress { get; set; }

        /// <summary>
        /// Токен для подулючения к API страницы
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Адрес используемого API
        /// </summary>
        public string ApiUrl { get; set; }
    }
}
