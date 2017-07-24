using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LightInject;

namespace FacebookWebhookNet
{
    public static class Container
    {
        private static ServiceContainer Current;

        public static void Initialize()
        {
            Current = new ServiceContainer();
            Current.RegisterApiControllers();
            //register other services
            Current.EnablePerWebRequestScope();
            Current.EnableWebApi(GlobalConfiguration.Configuration);

            //Current.Register<,>();

        }
    }
}