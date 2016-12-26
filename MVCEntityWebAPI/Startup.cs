using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCEntityWebAPI.Providers;
using MVCEntityWebAPI.ExceptionHandling;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

[assembly: OwinStartup(typeof(MVCEntityWebAPI.Startup))]

namespace MVCEntityWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app);
            config.Filters.Add(new CustomExceptionFilter());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Routes.MapHttpRoute(
               name: "DefaultExt",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );


            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            // Adding for   matter for Json   
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            // Adding formatter for XML   
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

            app.UseWebApi(config);

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, WebAPIOwinAuthentication.Migrations.Configuration>());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AuthorizeEndpointPath = new PathString("/api/Login/GetUser"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenFormat = new AccessTokenFormatter("")
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
