using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web_ApI_Application
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            // Web API routes
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
