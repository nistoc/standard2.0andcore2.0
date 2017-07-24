using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hub.Contracts;
using Hub.FacebookMessenger.Models;
using Hub.FacebookMessenger.Providers;
using Hub.FacebookMessenger.Send;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hub.Web.Core.Controllers
{
    [Route("webhook")]
    public class SubController : ControllerBase
    {
        string recipientId = "1603826823023833";
        private string PathToCatalog => $@"{new HostingEnvironment().WebRootPath}files\";
        private readonly IFacebookMessengerProvider _facebookMessengerProvider;

        public SubController(IFacebookMessengerProvider facebookMessengerProvider)
        {
            _facebookMessengerProvider = facebookMessengerProvider;
        }


        //todo: реализовать проверку токена приходящего в "Запросы на подтверждение" (https://developers.facebook.com/docs/graph-api/webhooks#callback)
        /// <summary>
        /// Запросы на подтверждение
        /// 
        /// Чтобы подтвердить ваш эндпойнт во время настройки или обновления имеющейся подписки, мы отправим вам запрос GET. 
        /// Запрос будет включать ваш URL обратного вызова со следующими параметрами
        /// </summary>
        /// <param name="hub"></param>
        /// <returns> проверить, 
        /// - соответствует ли hub.verify_token значению, которое вы указали при настройке Webhook. Это позволяет авторизовать запрос и идентифицировать Webhook;
        /// - ответить значением hub.challenge.Так мы узнаем, что эндпойнт настроен правильно, а ответ является подлинным
        /// </returns>
        [HttpGet]
        [Route("subscription")]
        public int Validate(/*[FromUri]*/NewWebhookValidate hub)
        {
            //hub.verify_token =
            //03a5cde6-5717-4ec1-910e-ac5f15bbf068

            FilesService.CreateFile(PathToCatalog, "web_hook_validate", JsonConvert.SerializeObject(hub), "json");
            return hub.challenge;
        }

        //todo: реализовать проверку подписи SHA1 (https://developers.facebook.com/docs/graph-api/webhooks#callback)
        /// <summary>
        /// Уведомления об обновлениях.
        /// 
        /// Такой запрос содержит тип материалов application/json, а в его теле находятся полезные данные JSON
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("subscription")]
        public IActionResult Subscription([FromBody]NewWebhookSubscription subs)
        {
            FilesService.CreateFile(PathToCatalog, "web_hook_subscription", JsonConvert.SerializeObject(subs), "json");
            return Ok();
        }

        [HttpGet]
        [Route("send")]
        public async Task<IActionResult> Send()
        {
            await _facebookMessengerProvider.SendTextOnlyAsync(recipientId, "hello, world!", "callback: Send Text Only");

            return Ok();
        }

        [HttpGet]
        [Route("sendtyping")]
        public async Task<IActionResult> SendTyping()
        {
            await _facebookMessengerProvider.SendTypingOnAsync(recipientId);
            Thread.Sleep(3000);
            await _facebookMessengerProvider.SendTypingOffAsync(recipientId);
            Thread.Sleep(1500);
            await _facebookMessengerProvider.SendTextOnlyAsync(recipientId, "We have written a message", "Send Typing");

            return Ok();
        }

        [HttpGet]
        [Route("sendquickrepliestext")]
        public async Task<IActionResult> SendQuickRepliesText()
        {

            var quickReplies = new List<FacebookMessageContentQuickReplyText>
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
            };

            await _facebookMessengerProvider.SendQuickRepliesTextsAsync(recipientId, "Please, select the answer", "callback: Send Quick Replies as Texts", quickReplies);

            return Ok();
        }

        [HttpGet]
        [Route("sendquickreplieslocation")]
        public async Task<IActionResult> SendLocation()
        {
            await _facebookMessengerProvider.SendQuickRepliesLocationAsync(recipientId, "Please share your location", "callback: Send Quick Replies as Location");

            return Ok();
        }
    }
}
