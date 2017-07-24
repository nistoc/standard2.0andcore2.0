using System;
using Hub.FacebookMessenger;
using Hub.FacebookMessenger.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hub.Web.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(new FacebookMessengerConfiguration
            {
                AccessToken = "EAAVnt40gYbUBAAaqlY2JjlyakLMDanlPWJ0ZCXYi8UbbXEo55rB2iCQSiTpRA71Kiknw3ZBFk2gS3CvyZBwaqFZBFMd7ZBf0PV8EKo15mdCLVZBsmYoBZAZCGMa31yWzFWqURUexOpk0kpzjGnX6QnFkAtjsTItDwVLsxt0IZCgg26HHyp9s7UZCgg",
                BaseAddress = new Uri("https://graph.facebook.com"),
                ApiUrl = @"v2.6/me/messages"

            });
            services.AddSingleton<IFacebookMessengerProvider,FacebookMessengerProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
