using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Internet_Shop
{
    public partial class Sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            String loginString = getter.loginValidation(Session, TextBox_nickname.Text, TextBox_password.Text);
            if (loginString.Length != 0)
            {
                lbl_top.Text = loginString;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["name"] != null && this.MasterPageFile == "/Site.Master")
            {
                this.MasterPageFile = "/Logined.Master";
                Response.Redirect("Default.aspx");
            }

            if (Session["name"] == null && this.MasterPageFile == "/Logined.Master")
            {
                this.MasterPageFile = "/Site.Master";
            }
        }
    }
}