using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //to use in case of direct url access without controller.
            //if not provide this then we have to provide COntroller name in Attribute Routing..
            //this removes controller names.
            routes.MapMvcAttributeRoutes();




          //  routes.MapRoute(
          //     name: "Home1",
          //     url: "Student/{action}/{id}/{name}",
          //     defaults: new { controller = "Student", action = "Staff"}
          // );


          //  //even this will work
          //  routes.MapRoute(
          //    name: "Home2",
          //    url: "abc",
          //    defaults: new { controller = "Student", action = "Image" }
          //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{id1}",
                defaults: new { controller = "Thread", action = "AsyncBar", id = UrlParameter.Optional, id1= UrlParameter.Optional } // diff controllers should have same action if called only the controller without specifying the action...
            );


        }
    }
}
