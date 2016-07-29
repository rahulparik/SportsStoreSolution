using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStoreMVCWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //http://localhost:xxxx/Page1
            routes.MapRoute(null, "Page{page}", new { controller = "Product", action = "List", category = (string) null }, new { page = @"\d+" });
            
            //Only with Category
            //http://localhost:xxx/chess, basketball
            routes.MapRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });

            //Category is Optional with the pages
            //http://localhost:xxx/chess/page1 
            routes.MapRoute(null, "{category}/Page{page}", new { controller = "Product", action = "List" });

            #region With Named args
            //routes.MapRoute(name: null, url:"Page{page}", defaults: new { controller = "Product", action = "List" }, constraints: new { page = @"\d+" }); 
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );

            #region Default
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //); 
            #endregion
        }
    }
}
