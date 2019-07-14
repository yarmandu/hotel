using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Proyecto_Hoteleria.Mapas;

namespace Proyecto_Hoteleria
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperInitial.Init();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
