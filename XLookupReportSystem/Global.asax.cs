﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace XLookupReportSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            if (exception is HttpRequestValidationException)
            {
                // Handle the exception as needed
                Response.Redirect("~/Admin/NoInternetConnection.aspx");
            }
            else if (exception is NullReferenceException)
            {
                // Handle the exception as needed
                Response.Redirect("~/Admin/Error.aspx");
            }
            else if (exception is Exception)
            {
                // Handle the exception as needed
                Response.Redirect("~/Admin/Error.aspx");
            }
            // Handle other exceptions or let them propagate
        }

    }
}