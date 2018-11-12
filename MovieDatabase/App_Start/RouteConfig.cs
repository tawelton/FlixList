using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieDatabase
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Movies", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MovieDetails",
                url: "{controller}/{action}/{movieID}",
                defaults: new { controller = "Home", action = "MovieDetails", id = UrlParameter.Optional }
            );
        }
    }
}
