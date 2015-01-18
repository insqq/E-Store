 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class details : System.Web.UI.Page
    {
        static private String productID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                productID = Session["productID"].ToString();
            }

            String userID = null;
            if (Session["name"] != null)
            {
                userID = getter.getUserID(Session["name"].ToString());
            }

            //List<productInfo> productsList = new List<productInfo>();
            //DB.loadSimilarProducts(productsList, DB.loadProduct(productID, userID).getpInfo());
            details_product pDetails = null;

            pDetails = new details_product(getter.loadProduct(productID, userID), userID, this);
            PlaceHolder1.Controls.Add(pDetails);

            /*foreach (productInfo var in productsList)
            {
                ProductBox pb = new ProductBox(var, userID, this);
                PlaceHolder1.Controls.Add(pb);
            }*/

            leaveComment tb = new leaveComment(productID, userID, this, true);
            PlaceHolder_leaveComment.Controls.Add(tb);


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


    }
}