using System;
using System.Web;
using System.Web.UI;

namespace Pages
{
    public partial class TryItCookie : Page
    {
        protected void btnGetCookie_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserDetails"];

            if (userCookie != null && userCookie["Username"] != null)
            {
                string username = userCookie["Username"];
                lblCookieResult.Text = $"Cookie Retrieved: Username - {username}";
                lblCookieResult.CssClass = "alert alert-success";
            }
            else
            {
                lblCookieResult.Text = "No cookie found!";
                lblCookieResult.CssClass = "alert alert-warning";
            }
        }

        protected void btnClearCookie_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserDetails"];

            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                Response.Cookies.Add(userCookie);
                lblCookieResult.Text = "Cookie has been cleared.";
                lblCookieResult.CssClass = "alert alert-info";
            }
            else
            {
                lblCookieResult.Text = "No cookie to clear.";
                lblCookieResult.CssClass = "alert alert-warning";
            }
        }
    }
}
