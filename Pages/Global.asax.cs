using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Pages
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["ActiveCounter"] = 0;
            Application["TotalCounter"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            lock (Application)
            {
                int count = (int)Application["ActiveCounter"];
                count++;
                Application["ActiveCounter"] = count;

                int totalCount = (int)Application["TotalCounter"];
                totalCount++;
                Application["TotalCounter"] = totalCount;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine("Unhandled exception: " + exception.Message);
            System.Diagnostics.Debug.WriteLine("Stack Trace: " + exception.StackTrace);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            lock (Application)
            {
                int count = (int)Application["ActiveCounter"];
                if (count > 0)
                {
                    count--;
                }
                Application["ActiveCounter"] = count;
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Response.Write("<hr /> The website was last visited on " + DateTime.Now.ToString());
        }
    }
}