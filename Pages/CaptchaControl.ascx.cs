using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace Pages
{
    public partial class CaptchaControl : UserControl
    {
        private string captchaText;

        public string CaptchaInput
        {
            get { return txtCaptcha.Text; } // Exposes the text in txtCaptcha
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        public void GenerateCaptcha()
        {
            // Generate random captcha text
            Random rand = new Random();
            captchaText = rand.Next(1000, 9999).ToString(); // Simple 4-digit captcha

            // Save the captcha text to session for validation later
            Session["CaptchaText"] = captchaText;

            // Generate captcha image
            using (Bitmap bmp = new Bitmap(200, 50))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(240, 240, 240)); // Light gray background
                    Font font = new Font("Arial", 24, FontStyle.Bold | FontStyle.Italic);
                    Brush brush = Brushes.Black;

                    // Add some noise lines for better security
                    Pen noisePen = new Pen(Color.Gray, 1);
                    for (int i = 0; i < 10; i++)
                    {
                        int x1 = rand.Next(bmp.Width);
                        int y1 = rand.Next(bmp.Height);
                        int x2 = rand.Next(bmp.Width);
                        int y2 = rand.Next(bmp.Height);
                        g.DrawLine(noisePen, x1, y1, x2, y2);
                    }

                    // Draw the captcha text
                    g.DrawString(captchaText, font, brush, new PointF(40, 10));

                    // Save the image to a memory stream
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Jpeg);
                        captchaImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public bool ValidateCaptcha(string input)
        {
            // Get the captcha text stored in the session
            string storedCaptcha = Session["CaptchaText"] as string;

            // Check if the user input matches the stored captcha text
            return input == storedCaptcha;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh the captcha image
            GenerateCaptcha();
            lblMessage.Text = string.Empty; // Clear any previous messages
        }
    }
}
