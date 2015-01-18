using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class Logined : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl count = new HtmlGenericControl();
            count.InnerHtml = getter.getTotalItems(getter.getUserID(Session["name"].ToString())) + " items";
            HtmlGenericControl price = new HtmlGenericControl();
            price.InnerHtml = getter.getTotalPrice(getter.getUserID(Session["name"].ToString())).ToString();
            PlaceHolder_countItems.Controls.Add(count);
            PlaceHolder_totalPrice.Controls.Add(price);

            titleInit();
            leftMenuInit();
            rightMenuInit();
            
        }

        private HtmlGenericControl createButton(int n, String productType)
        {
            HtmlGenericControl item = null;
            if (n == 0)
            {
                item = new HtmlGenericControl("li");
                item.Attributes.Add("class", "even");
                HtmlAnchor refA = new HtmlAnchor();
                refA.ID = productType;
                refA.InnerHtml = productType;
                refA.ServerClick += new EventHandler(menuItem_Click);
                item.Controls.Add(refA);

            }
            else
            {
                item = new HtmlGenericControl("li");
                item.Attributes.Add("class", "odd");
                HtmlAnchor refA = new HtmlAnchor();
                refA.ID = productType;
                refA.InnerHtml = productType;
                refA.ServerClick += new EventHandler(menuItem_Click);
                item.Controls.Add(refA);
            }

            return item;
        }

        protected void menuItem_Click(object sender, EventArgs e)
        {

            String productType = ((HtmlControl)sender).ID;


            Session["productType"] = productType;
            Response.Redirect("ProductByCategory.aspx");
        }

        private void rightMenuInit()
        {
            HtmlGenericControl rightMenu = new HtmlGenericControl("ul");
            rightMenu.Attributes.Add("class", "left_menu");

            DataTable dt = getter.getManufacturers();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    rightMenu.Controls.Add(createButton(1, dt.Rows[i][0].ToString()));
                }
                else rightMenu.Controls.Add(createButton(0, dt.Rows[i][0].ToString()));
            }

            PlaceHolder_rightMenu.Controls.Add(rightMenu);
        }

        private void titleInit()
        {
            productInfo product = null;
            getter.loadNewProduct(ref product);
            if (product != null)
            {
                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes.Add("src", product.pic);
                img.Attributes.Add("class", "oferta_img");
                img.Attributes.Add("style", "width:94 height:92 border: 0");
                HtmlGenericControl title = new HtmlGenericControl("div");
                title.InnerHtml = product.name;
                title.Attributes.Add("class", "oferta_title");
                HtmlGenericControl text = new HtmlGenericControl("div");
                if (product.info.Length > 200)
                {
                    String inf = product.info;
                    inf = inf.Remove(200);
                    inf += "...";
                    text.InnerHtml = inf;
                }
                else text.InnerHtml = product.info;
                text.Attributes.Add("class", "oferta_text");

                PlaceHolder_img.Controls.Add(img);
                PlaceHolder_title.Controls.Add(title);
                PlaceHolder_text.Controls.Add(text);
                Session["productID"] = product.ID;
            }
        }

        private void leftMenuInit()
        {
            HtmlGenericControl leftMenu = new HtmlGenericControl("ul");
            leftMenu.Attributes.Add("class", "left_menu");

            DataTable dt = getter.getCategorys();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    leftMenu.Controls.Add(createButton(1, dt.Rows[i][0].ToString()));
                }
                else leftMenu.Controls.Add(createButton(0, dt.Rows[i][0].ToString()));
            }

            PlaceHolder_leftMenu.Controls.Add(leftMenu);
        }
    }
}