using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            

            // Home
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // /Cuisine/french
            routes.MapRoute(
               name: "Cuisine",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cuisine", action = "Search", id = UrlParameter.Optional }
           );

            // /Reviews
            routes.MapRoute(
               name: "reviews",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Review", action = "Index", id = UrlParameter.Optional }
           );
           
        }
    }
}