using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Charades.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    null,
            //    "Dictionary{DictionaryId}/Page{page}",
            //    new { controller = "Home", action = "Index" }, new { page = @"\d+" });
            routes.MapRoute(null,
                "",
                new { controller = "Home", action = "Index", navType = "", id = 0, page = 1 });

            routes.MapRoute(null,
                "Download{level}",
                new {controller = "Home", action = "GetFile"});
            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Home", action = "Index", id = 0 },
                new { page = @"\d+" });
            routes.MapRoute(null,
                "Dictionary{id}",
                new { controller = "Home", action = "Index", navType = "Dict", page = 1 });
            routes.MapRoute(null,
                "Level{id}",
                new {controller = "Home", action = "Index", navType = "Level", page = 1});
            routes.MapRoute(
                null,
                "Level{levelId}/Page{page}",
                new {controller = "Home", action = "Index"}, new{page = @"\d+"});
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}