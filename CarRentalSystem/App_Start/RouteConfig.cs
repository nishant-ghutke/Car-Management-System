
using System.Web.Mvc;
using System.Web.Routing;

namespace CarRentalSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
               name: "UpdateUser",
               url: "User/Update/{id}",
               defaults: new { controller = "User", action = "UpdateUser", id = UrlParameter.Optional },
               constraints: new { id = @"\d+" } // Constraint: id must be an integer
           );

           
            routes.MapRoute(
               name: "CarDetail",
               url: "Car/Detail/{id}",
               defaults: new { controller = "Car", action = "Detail" },
               constraints: new { id = @"\d+" } // Constraint: id must be an integer
           );

           

        }
    }
}
