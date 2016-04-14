﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace plejmo_wants_you
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}