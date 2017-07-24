using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Hub.FacebookMessenger.Send;
using Newtonsoft.Json;

namespace Hub.FacebookMessenger.Providers
{
    /// <summary>
    /// Обеспечивает коммуникацию с Massenger Facebook
    /// </summary>
    public class FacebookMessengerProvider : IFacebookMessengerProvider
    {
        private readonly FacebookMessengerConfiguration _FBMessengerConfiguration;

        public FacebookMessengerProvider(FacebookMessengerConfiguration FBMessengerConfiguration)
        {
            _FBMessengerConfiguration = FBMessengerConfiguration;
        }

        /// <summary>
        /// Начали печатать
        /// </summary>
        public async Task<string> SendTypingOnAsync(string recipientId)
        {
            return await PerformTheSending(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.typing_on).ToString());
        }

        /// <summary>
        /// Закончили печатать
        /// </summary>
        public async Task<string> SendTypingOffAsync(string recipientId)
        {
            return await PerformTheSending(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.typing_off).ToString());
        }

        /// <summary>
        /// Посмотрели сообщение
        /// </summary>
        public async Task<string> SendMarkSeenAsync(string recipientId)
        {
            return await PerformTheSending(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.mark_seen).ToString());
        }

        /// <summary>
        /// Отправить обычное текстове сообщение
        /// </summary>
        public async Task<string> SendTextOnlyAsync(string recipientId, string messageText, string callBackMatadata)
        {
            var reply = new FacebookPushMessageViaText(recipientId, messageText);
            reply.message.metadata = callBackMatadata;
            return await PerformTheSending(reply.ToString());
        }

        /// <summary>
        /// Отправить текстовое сообщение с текстовыми вариантами ответа
        /// </summary>
        public async Task<string> SendQuickRepliesTextsAsync(string recipientId, string messageText, string callBackMatadata, List<FacebookMessageContentQuickReplyText> quickReplies)
        {
            var reply = new FacebookPushMessageViaText(recipientId, messageText);
            reply.message.metadata = callBackMatadata;
            reply.message.quick_replies = new FacebookMessageContentQuickReplyTextList
            {
                Items = quickReplies
            };

            return await PerformTheSending(reply.ToString());
        }

        /// <summary>
        /// Отправить текстовое сообщение с запросом локации
        /// </summary>
        public async Task<string> SendQuickRepliesLocationAsync(string recipientId, string messageText, string callBackMatadata)
        {
            var reply = new FacebookPushMessageViaText(recipientId, messageText);
            reply.message.metadata = callBackMatadata;
            reply.message.quick_replies = new FacebookMessageContentQuickReplyLocationList
            {
                Items = new List<FacebookMessageContentQuickReplyLocation>
                {
                    new FacebookMessageContentQuickReplyLocation()
                }
            };

            return await PerformTheSending(reply.ToString());
        }

        private async Task<string> PerformTheSending(string messageContent)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _FBMessengerConfiguration.BaseAddress;


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage;
                try
                {
                    responseMessage = await client
                        .PostAsync(
                            $"{_FBMessengerConfiguration.ApiUrl}?access_token={_FBMessengerConfiguration.AccessToken}",
                            new StringContent(messageContent, Encoding.UTF8, "application/json")
                        );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }


                return $"{JsonConvert.SerializeObject(responseMessage.StatusCode)}";
            }
        }

    }
}
