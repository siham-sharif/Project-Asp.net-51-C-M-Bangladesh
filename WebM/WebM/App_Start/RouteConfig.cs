using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "CenterLogin",
               url: "Center/{action}/{id}",
               defaults: new
                   {
                       controller = "Center",
                       action = "CenterLogin",
                       id = UrlParameter.Optional
                   }
             );


            routes.MapRoute(
               name: "Treatment",
               url: "Treatment/{action}/{id}",
               defaults: new
               {
                   controller = "Treatment",
                   action = "Create",
                   id = UrlParameter.Optional
               }
             );

            
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
