using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class Specials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                lbl_top.Text = "Для доступу до списку замовлень потрібно авторизуватись";
            }
            else
            {
                DataTable dt = getter.getOrderList(getter.getUserID(Session["name"].ToString()));
                List<Control> lOrders = new List<Control>();
                if (dt.Rows.Count != 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Control o = LoadControl("~/Order.ascx");
                        o.ID = "" + i;
                        (o as Order).setInfo(dt.Rows[i]);
                        lOrders.Add(o);
                        phOrders.Controls.Add(o);
                    }
                }
                else { lbl_top.Text = "у вас немає замовлень"; }
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["name"] != null && this.MasterPageFile == "/Site.Master")
            {
                this.MasterPageFile = "/Logined.Master";
            }

            if (Session["name"] == null && this.MasterPageFile == "/Logined.Master")
            {
                this.MasterPageFile = "/Site.Master";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
            {
                e.Row.Cells[0].Controls.Clear(); // Comment this line if you do not want to hide Textbox from First Cell first Row
                LinkButton btn = new LinkButton();
                btn.ID = "ID";
                btn.Text = "Insert";
                e.Row.Cells[0].Controls.Add(btn);
            }
        }


    }
}