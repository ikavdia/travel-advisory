using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblActiveCounter.Text = "Active Sessions: " + Application["ActiveCounter"].ToString();
                lblTotalCounter.Text = "Total Sessions: " + Application["TotalCounter"].ToString();
            }
        }
    }
}