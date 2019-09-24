using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kibiriukas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    "GetSubcategoryDetails",
            //    url: "{controller}/{id}/{action}",
            //    defaults: new {controller = "Category", action ="GetSubcategoryDetails", id = UrlParameter.Optional}
            //    );


            //routes.MapRoute(
            //    "GetSubcategories",
            //    url: "{controller}/{id}",
            //    defaults: new {controller = "Category", action = "GetSubcategory", id = UrlParameter.Optional}
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
