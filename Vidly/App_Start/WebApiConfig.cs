using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var jsonSetting = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSetting.Formatting = Newtonsoft.Json.Formatting.Indented;
    

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
