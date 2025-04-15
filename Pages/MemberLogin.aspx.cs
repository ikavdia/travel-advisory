using DLLComponent;
using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Pages
{
    public partial class MemberLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if logged in as staff
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "Staff")
            {
                Response.Redirect("Default.aspx");
            }
            // Check if logged in as member
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "Member")
            {
                Response.Redirect("MemberWelcome.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password are required.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            string xmlFilePath = Server.MapPath("~/App_Data/Member.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode memberNode = xmlDoc.SelectSingleNode($"Members/Member[Username='{username}']");
            if (memberNode == null)
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            string storedEncryptedPassword = memberNode["Password"].InnerText;
            string storedPassword = EncryptionUtility.Decrypt(storedEncryptedPassword);

            if (password == storedPassword)
            {
                // Credentials are valid
                Session["User"] = username;
                Session["UserRole"] = "Member";
                Response.Redirect("MemberWelcome.aspx"); 
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.CssClass = "text-danger";
            }
        }
        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}