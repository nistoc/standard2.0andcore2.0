using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
//using FacebookMessenger.Models;

namespace WebApplicationCore2.Controllers
{
    //[Route("webhook")]
    public class SubController : ControllerBase
    {
        public SubController()
        {
            var tt = new Class1();
        }

        ////todo: реализовать проверку токена приходящего в "Запросы на подтверждение" (https://developers.facebook.com/docs/graph-api/webhooks#callback)
        ///// <summary>
        ///// Запросы на подтверждение
        ///// 
        ///// Чтобы подтвердить ваш эндпойнт во время настройки или обновления имеющейся подписки, мы отправим вам запрос GET. 
        ///// Запрос будет включать ваш URL обратного вызова со следующими параметрами
        ///// </summary>
        ///// <param name="hub"></param>
        ///// <returns> проверить, 
        ///// - соответствует ли hub.verify_token значению, которое вы указали при настройке Webhook. Это позволяет авторизовать запрос и идентифицировать Webhook;
        ///// - ответить значением hub.challenge.Так мы узнаем, что эндпойнт настроен правильно, а ответ является подлинным
        ///// </returns>
        //[HttpGet]
        //[Route("subscription")]
        //public int Validate([FromUri]NewWebhookValidate hub)
        //{
        //    //hub.verify_token =
        //    //03a5cde6-5717-4ec1-910e-ac5f15bbf068

        //    FilesService.CreateFile("web_hook_validate", JsonConvert.SerializeObject(hub), "json");
        //    return hub.challenge;
        //}

        ////todo: реализовать проверку подписи SHA1 (https://developers.facebook.com/docs/graph-api/webhooks#callback)
        ///// <summary>
        ///// Уведомления об обновлениях.
        ///// 
        ///// Такой запрос содержит тип материалов application/json, а в его теле находятся полезные данные JSON
        ///// </summary>
        ///// <param name="subs"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("subscription")]
        //public IActionResult Subscription([FromBody]WebhookSubscription subs)
        //{
        //    FilesService.CreateFile("web_hook_subscription", JsonConvert.SerializeObject(subs), "json");
        //    return  Ok();
        //}
    }
}
