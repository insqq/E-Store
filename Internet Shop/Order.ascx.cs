using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Internet_Shop
{
    public partial class Order : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void setInfo(DataRow dr)
        {
            if (Convert.ToInt32(Session["Account_type"]) == 0)
            {
                btnChangeStatus.Visible = false;
            }
            lblDate.Text = dr[0].ToString();
            lbltotalPrice.Text = dr[1].ToString();
            lblStatus.Text = dr[2].ToString();
            btnChangeStatus.ID = dr[3].ToString();
            btnChangeStatus.Text = "Змінити статус";
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            updater.changeOrderStatus((sender as Button).ID);
            Page.Response.Redirect("~/Pages/Specials.aspx");
        }

        
    }
}