using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using DLLComponent;

namespace Pages
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                // Redirect to Staff.aspx if already logged in
                Response.Redirect("Staff.aspx");
            }

            // Ensure TA account exists
            EnsureDefaultAdminAccount();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            // string captchaInput = CaptchaControl.CaptchaInput; // Removed Captcha input

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password are required.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            // // Validate Captcha - Removed

            string xmlFilePath = Server.MapPath("~/App_Data/Staff.xml");

            // Load XML and authenticate user
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode userNode = xmlDoc.SelectSingleNode($"StaffMembers/Staff[Username='{username}']");

            if (userNode == null)
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            string storedEncryptedPassword = userNode["Password"].InnerText;

            // Decrypt the stored password
            string storedPassword = EncryptionUtility.Decrypt(storedEncryptedPassword);

            if (password == storedPassword)
            {
                // Credentials are valid
                Session["User"] = username;
                Session["UserRole"] = "Staff";
                // Set cookie with login time
                HttpCookie userCookie = new HttpCookie("UserDetails");
                userCookie["Username"] = username;
                userCookie["LoginTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                userCookie.Expires = DateTime.Now.AddHours(1); // Cookie expires in 1 hour
                Response.Cookies.Add(userCookie);

                Response.Redirect("Staff.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.CssClass = "text-danger";
            }
        }

        private void EnsureDefaultAdminAccount()
        {
            string xmlFilePath = Server.MapPath("~/App_Data/Staff.xml");
            XmlDocument xmlDoc = new XmlDocument();

            // Create Staff.xml if it doesn't exist
            if (!System.IO.File.Exists(xmlFilePath))
            {
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement root = xmlDoc.CreateElement("StaffMembers");
                xmlDoc.AppendChild(xmlDecl);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFilePath);
            }
            else
            {
                xmlDoc.Load(xmlFilePath);
            }

            XmlNode rootNode = xmlDoc.SelectSingleNode("StaffMembers");

            // Check if the default admin account already exists
            XmlNode defaultUserNode = rootNode.SelectSingleNode("Staff[Username='TA']");
            if (defaultUserNode == null)
            {
                // Add default admin account
                XmlElement staffElement = xmlDoc.CreateElement("Staff");

                XmlElement usernameElement = xmlDoc.CreateElement("Username");
                usernameElement.InnerText = "TA";
                staffElement.AppendChild(usernameElement);

                XmlElement passwordElement = xmlDoc.CreateElement("Password");
                passwordElement.InnerText = EncryptionUtility.Encrypt("Cse445!");
                staffElement.AppendChild(passwordElement);

                rootNode.AppendChild(staffElement);
                xmlDoc.Save(xmlFilePath);
            }
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); // Redirect to the default page
        }
    }
}
