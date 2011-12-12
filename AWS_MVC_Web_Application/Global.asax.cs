using System.Web.Mvc;
using System.Web.Routing;
using AWS_MVC_Web_Application.Data;
using AWS_MVC_Web_Application.Jobs;
using AWS_MVC_Web_Application.Models;

namespace AWS_MVC_Web_Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RepositorySession.DefaultContainerType = typeof(PilesOfDataEntities);

            SinglyScheduler.FireOffSchedules();
        }
    }
}