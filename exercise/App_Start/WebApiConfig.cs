using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace exercise
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Register has a parameter of HttpConfiguration type , 
        /// with properties that specified the dafault behavior of web api and can be override
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes(); // enable use route arrtibute in controller action


            // ** the order of adding route determines the order of match
            // if move this route to below DefaultApi, the request api/myschool will fail,
            // because it match DefaultApi routeTemplate but it cannot find MyschoolController **
            config.Routes.MapHttpRoute(
                name: "School",
                routeTemplate: "api/myschool/{id}",
                defaults: new { controller = "school", id = RouteParameter.Optional },
                constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region api/myschool will fail if School Route is below DefaultApi Route
            //config.Routes.MapHttpRoute(
            //    name: "School",
            //    routeTemplate: "api/myschool/{id}",
            //    defaults: new { controller = "school", id = RouteParameter.Optional },
            //    constraints: new { id = @"\d+" }
            //);
            #endregion


            #region define a route mapping then add to HttpRouteCollection

            //var defaultRoute = config.Routes.CreateRoute("api/school/{id}",
            //    new { Controllers = "school", id = RouteParameter.Optional },
            //    new { id = "/d+" });
            //config.Routes.Add("anotherRoute", defaultRoute);

            #endregion

            Console.WriteLine(config.Routes); // a route table in this HttpConfiguration

        }
    }
}
