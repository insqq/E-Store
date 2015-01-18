using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class My_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Account_type"]) == 1)
            {
                Response.Redirect("My_account_admin.aspx");
            }

            if (Session["name"] != null && this.MasterPageFile == "/Site.Master")
            {
                this.MasterPageFile = "/Logined.Master";
            }

            if (Session["name"] == null && this.MasterPageFile == "/Logined.Master")
            {
                this.MasterPageFile = "/Site.Master";
                Response.Redirect("Enter.aspx");
            }
        }
    }
}