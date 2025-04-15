using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages
{
    public partial class MemberWelcome : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                lblWelcomeMessage.Text = $"Hi, {Session["User"]}!";
            }
            else
            {
                Response.Redirect("Default.aspx"); // Redirect if no user is logged in
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session and cookie
            Session["User"] = null;
            Session["UserRole"] = null;

            if (Request.Cookies["UserDetails"] != null)
            {
                HttpCookie userCookie = new HttpCookie("UserDetails");
                userCookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                Response.Cookies.Add(userCookie);
            }

            Response.Redirect("Default.aspx"); // Redirect to the default page after logout
        }
        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}