using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class Shopping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                lbl_top.Text = "Для доступу до корзини потрібно авторизуватись";
                Lbl_Address.Visible = false;
                tbAddress.Visible = false;
            }
            else
            {
                getter.getCartItems(GridView1, getter.getUserID(Session["name"].ToString()));
                if (GridView1.Rows.Count == 1)
                {
                    lbl_top.Text = "Корзина пуста";
                    GridView1.Visible = false;
                    Lbl_Address.Visible = false;
                    tbAddress.Visible = false;
                    return;
                }
                GridView1.Visible = true;
                buttonsInit();
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
                Response.Redirect("Enter.aspx");
            }
            
        }

        protected void Button_clear_Click(object sender, EventArgs e)
        {
            deleter.clearCart(getter.getUserID(Session["name"].ToString()));
            Response.Redirect("Shopping.aspx");
        }

        protected void Button_makeOrder_Click(object sender, EventArgs e)
        {
            setter.createOrder(getter.getUserID(Session["name"].ToString()), tbAddress.Text);
            deleter.clearCart(getter.getUserID(Session["name"].ToString()));
            Response.Redirect("Shopping.aspx");
        }

        private void buttonsInit()
        {
            HtmlGenericControl buttonsdiv = new HtmlGenericControl("div");
            HtmlGenericControl button_clear = new HtmlGenericControl("div");
            button_clear.Attributes.Add("style", "margin: 20px 25% 0 25%; width: 50%;");
            HtmlGenericControl button_makeOrder = new HtmlGenericControl("div");
            button_makeOrder.Attributes.Add("style", "margin: 20px 25% 0 25%; width: 50%;");

            HtmlAnchor a_clear = new HtmlAnchor();
            a_clear.Attributes.Add("runat", "server");
            a_clear.Attributes.Add("class", "contact");
            a_clear.InnerHtml = "Очистити";
            a_clear.ServerClick += new EventHandler(Button_clear_Click);
            button_clear.Controls.Add(a_clear);

            HtmlAnchor a_makeOrder = new HtmlAnchor();
            a_makeOrder.Attributes.Add("runat", "server");
            a_makeOrder.Attributes.Add("class", "contact");
            a_makeOrder.InnerHtml = "Замовити";
            a_makeOrder.ServerClick += new EventHandler(Button_makeOrder_Click);
            button_makeOrder.Controls.Add(a_makeOrder);

            buttonsdiv.Controls.Add(button_clear);
            buttonsdiv.Controls.Add(button_makeOrder);

            PlaceHolder_buttons.Controls.Add(buttonsdiv);
        }
    }
}