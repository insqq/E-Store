using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace Internet_Shop
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonClick(Object sender, EventArgs e)
        {
            String tryReg = setter.registration(TextBox_name.Text, TextBox_surename.Text, TextBox_nickname.Text, 
                TextBox_password.Text, TextBox_email.Text);
            if (tryReg.Length != 0)
            {
                Label_top.Text = tryReg;
            }
            else
            {
                getter.loginValidation(Session, TextBox_nickname.Text, TextBox_password.Text);
                Response.Redirect("account_redirector.aspx");
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["name"] != null && this.MasterPageFile == "/Site.Master")
            {
                this.MasterPageFile = "/Logined.Master";
                Response.Redirect("My_account.aspx");
            }

            if (Session["name"] == null && this.MasterPageFile == "/Logined.Master")
            {
                this.MasterPageFile = "/Site.Master";
                
            }
        }
    }
}