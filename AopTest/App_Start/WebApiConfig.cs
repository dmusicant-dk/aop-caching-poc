using Interception.Interception;
using System;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace AopTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Setup interception and dependency injection
            InterceptionConfiguration.Configure(config, typeof(WebApiConfig));
        }
    }
}
