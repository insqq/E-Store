using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class ProductByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl title = new HtmlGenericControl("div");
            title.InnerHtml = Session["productType"].ToString();
            PlaceHolder_title.Controls.Add(title);

            List<productInfo> productsList = new List<productInfo>();
            getter.loadProducts(productsList, Session["productType"].ToString());

            String userID = null;
            if (Session["name"] != null)
            {
                userID = getter.getUserID(Session["name"].ToString());
            }

            foreach (productInfo var in productsList)
            {
                ProductBox pb = new ProductBox(var, userID, this);
                main_content.Controls.Add(pb);
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
    }
}