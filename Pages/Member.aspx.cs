using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using DLLComponent;

namespace Pages
{
    public partial class Member : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect if logged in as Staff
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "Staff")
            {
                Response.Redirect("Default.aspx");
            }

            // Prevent access to registration if already logged in as Member
            if (Session["User"] != null && Session["UserRole"] == "Member")
            {
                // Redirect to MemberWelcome.aspx if already logged in as Member
                Response.Redirect("MemberWelcome.aspx");
            }

            if (!IsPostBack)
            {
                // Hide logout button if no user is logged in
                btnLogout.Visible = Session["User"] != null;
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblSignupMessage.Text = "All fields are required.";
                lblSignupMessage.CssClass = "text-danger";
                return;
            }

            if (password != confirmPassword)
            {
                lblSignupMessage.Text = "Passwords do not match.";
                lblSignupMessage.CssClass = "text-danger";
                return;
            }

            // Validate Captcha
            string captchaInput = CaptchaControl.CaptchaInput;
            if (!CaptchaControl.ValidateCaptcha(captchaInput))
            {
                lblSignupMessage.Text = "Invalid captcha.";
                lblSignupMessage.CssClass = "text-danger";
                return;
            }

            // Define the path to Member.xml
            string xmlFilePath = Server.MapPath("~/App_Data/Member.xml");

            XmlDocument xmlDoc = new XmlDocument();

            // Create the XML file if it does not exist
            if (!System.IO.File.Exists(xmlFilePath))
            {
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement root = xmlDoc.CreateElement("Members");
                xmlDoc.AppendChild(xmlDecl);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFilePath);
            }

            // Load the XML file
            xmlDoc.Load(xmlFilePath);

            XmlNode rootNode = xmlDoc.SelectSingleNode("Members");

            // Check if username already exists
            XmlNode existingUser = rootNode.SelectSingleNode($"Member[Username='{username}']");
            if (existingUser != null)
            {
                lblSignupMessage.Text = "Username already exists. Please choose a different username.";
                lblSignupMessage.CssClass = "text-danger";
                return;
            }

            // Encrypt the password
            string encryptedPassword = EncryptionUtility.Encrypt(password);

            // Add a new Member element
            XmlElement memberElement = xmlDoc.CreateElement("Member");

            XmlElement usernameElement = xmlDoc.CreateElement("Username");
            usernameElement.InnerText = username;
            memberElement.AppendChild(usernameElement);

            XmlElement passwordElement = xmlDoc.CreateElement("Password");
            passwordElement.InnerText = encryptedPassword;
            memberElement.AppendChild(passwordElement);

            rootNode.AppendChild(memberElement);
            xmlDoc.Save(xmlFilePath);

            lblSignupMessage.CssClass = "text-success";
            lblSignupMessage.Text = "Signup successful! You can now log in.";

            // Clear input fields
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
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

            Response.Redirect("Login.aspx");
        }

        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
