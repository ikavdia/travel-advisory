using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using DLLComponent;

namespace Pages
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["UserRole"] != null && Session["UserRole"].ToString() == "Member")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                lblStaffMessage.Text = $"Welcome, {Session["User"]}!";
                lblStaffMessage.CssClass = "text-success";
            }
        }

        protected void btnAddStaff_Click(object sender, EventArgs e)
        {
            string username = txtStaffUsername.Text.Trim();
            string password = txtStaffPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblStaffErrorMessage.Text = "Username and Password are required.";
                lblStaffErrorMessage.CssClass = "text-danger";
                return;
            }

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

            // Load the XML file
            xmlDoc.Load(xmlFilePath);
            XmlNode rootNode = xmlDoc.SelectSingleNode("StaffMembers");

            // Check if the username already exists
            XmlNode existingNode = rootNode.SelectSingleNode($"Staff[Username='{username}']");
            if (existingNode != null)
            {
                lblStaffErrorMessage.Text = "Username already exists.";
                lblStaffErrorMessage.CssClass = "text-danger";
                return;
            }

            // Encrypt the password
            string encryptedPassword = EncryptionUtility.Encrypt(password);

            // Add new staff member
            XmlElement staffElement = xmlDoc.CreateElement("Staff");

            XmlElement usernameElement = xmlDoc.CreateElement("Username");
            usernameElement.InnerText = username;
            staffElement.AppendChild(usernameElement);

            XmlElement passwordElement = xmlDoc.CreateElement("Password");
            passwordElement.InnerText = encryptedPassword;
            staffElement.AppendChild(passwordElement);

            rootNode.AppendChild(staffElement);
            xmlDoc.Save(xmlFilePath);

            lblStaffErrorMessage.Text = "Staff member added successfully!";
            lblStaffErrorMessage.CssClass = "text-success";

            txtStaffUsername.Text = "";
            txtStaffPassword.Text = "";
        }
        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); // Redirect to the default page
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["UserRole"] = null;

            if (Request.Cookies["UserDetails"] != null)
            {
                HttpCookie userCookie = new HttpCookie("UserDetails");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }

            Response.Redirect("Default.aspx"); 
        }
    }
}
