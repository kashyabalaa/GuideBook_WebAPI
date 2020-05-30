using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartGuideWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            //,constraints: new { id = @"^[0-9]+$" }
        );


        //    config.Routes.MapHttpRoute(
        //    name: "guidePost",
        //    routeTemplate: "api/{controller}/{id}",
        //      defaults: new { action = "Get" },
        //    constraints: new { id = @"^[0-9]+$" }
        //);

            //config.Routes.MapHttpRoute(
            //    name: "guidePost",
            //    routeTemplate: "api/{controller}/{name}",
            //    defaults: null,
            //    constraints: new { name = @"^[a-z]+$" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "guidePost",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { action = "Get" }
            //);
            //config.Routes.MapHttpRoute(
            //name: "ApiByGuidePost",
            //routeTemplate: "{namespace}/{controller}/{action}/{id}",
            //defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            //);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

    }
}
