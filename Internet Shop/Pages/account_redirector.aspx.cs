using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class account_redirector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Account_type"]) == 0)
            {
                Response.Redirect("My_account.aspx");
            }
            else if (Convert.ToInt32(Session["Account_type"]) == 1)
            {
                Response.Redirect("My_account_admin.aspx");
            }
        }
    }
}