using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using Newtonsoft.Json;

namespace FacebookWebhookNet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new LogginHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }


    public class LogginHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var fileName = FilesService.getFullFilePath("request", "request");
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {

                Byte[] address = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(request.RequestUri));
                await fs.WriteAsync(address, 0, address.Length, cancellationToken);

                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);
                fs.Write(newline, 0, newline.Length);

                foreach (var httpRequestHeader in request.Headers)
                {
                    Byte[] headers = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(httpRequestHeader));
                    await fs.WriteAsync(headers, 0, headers.Length, cancellationToken);
                    fs.Write(newline, 0, newline.Length);
                }

                fs.Write(newline, 0, newline.Length);
                fs.Write(newline, 0, newline.Length);

                Byte[] content = await request.Content.ReadAsByteArrayAsync();
                await fs.WriteAsync(content, 0, content.Length, cancellationToken);
            }

            return await base.SendAsync(request, cancellationToken);

        }
    }
}
