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
        /// Отправить сообщение
        /// </summary>
        public async Task<string> SendTypingOnAsync(string recipientId)
        {
            return await SendMessage(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.typing_on).ToString());
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async Task<string> SendTypingOffAsync(string recipientId)
        {
            return await SendMessage(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.typing_off).ToString());
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async Task<string> SendMarkSeenAsync(string recipientId)
        {
            return await SendMessage(new FacebookPushSenderAction(recipientId, FacebookSenderActionType.mark_seen).ToString());
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async Task<string> SendMessageAsync(string recipientId, string messageText)
        {
            var reply = new FacebookPushMessageViaText(recipientId, messageText);
            reply.message.metadata = "test_metadata";
            reply.message.quick_replies = new FacebookMessageContentQuickReplyTextList
            {
                Items = new List<FacebookMessageContentQuickReplyText>
                    {
                        new FacebookMessageContentQuickReplyText
                        {
                            payload = "DEVELOPER_DEFINED_PAYLOAD_FOR_PICKING_RED",
                            title = "Red"
                        },
                        new FacebookMessageContentQuickReplyText
                        {
                            payload = "DEVELOPER_DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                            title = "Green"
                        }
                    }
            };

            return await SendMessage(reply.ToString());
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async Task<string> SendMessageLocationAsync(string recipientId)
        {
            var reply = new FacebookPushMessageViaText(recipientId, "Please share your location");
            reply.message.metadata = "some webhooking metadata";
            reply.message.quick_replies = new FacebookMessageContentQuickReplyLocationList
            {
                Items = new List<FacebookMessageContentQuickReplyLocation>
                {
                    new FacebookMessageContentQuickReplyLocation()
                }
            };

            return await SendMessage(reply.ToString());
        }

        private async Task<string> SendMessage(string messageContent)
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
