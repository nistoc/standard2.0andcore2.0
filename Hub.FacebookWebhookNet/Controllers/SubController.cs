using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using FacebookMessenger.Models;

namespace FacebookWebhookNet.Controllers
{
    [System.Web.Http.RoutePrefix("webhook")]
    public class SubController : ApiController
    {

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
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("subscription")]
        public int Validate([FromUri]NewWebhookValidate hub)
        {
            //hub.verify_token =
            //03a5cde6-5717-4ec1-910e-ac5f15bbf068

            FilesService.CreateFile("web_hook_validate", JsonConvert.SerializeObject(hub), "json");
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
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("subscription")]
        public IHttpActionResult Subscription([FromBody]WebhookSubscription subs)
        {
            FilesService.CreateFile("web_hook_subscription", JsonConvert.SerializeObject(subs), "json");
            return Ok();
        }
    }
}
