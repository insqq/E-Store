using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class contact_logined : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            setter.addQuestion(TextBox1.Text, TextBox2.Text, getter.getUserID(Session["name"].ToString()));
            lbl_top.Text = "Лист адміністратору відправленно.";

        }
    }
}