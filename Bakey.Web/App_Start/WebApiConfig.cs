﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bakey.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ForAnotherGet",
                routeTemplate: "api/{controller}/{action}/{id}"                
            );



            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
