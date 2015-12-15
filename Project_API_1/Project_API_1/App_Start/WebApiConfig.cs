using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Project_API_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
          
            

            // Web API configuration and services
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", JsonMediaTypeFormatter.DefaultMediaType);
            
            // Web API routes
           config.MapHttpAttributeRoutes();

            //var cors = new EnableCorsAttribute(origins: "http://www.apiminh.somee.com", headers: "*", methods: "*");
            var cors = new EnableCorsAttribute(origins: "http://localhost", headers: "*", methods: "*");
          
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
