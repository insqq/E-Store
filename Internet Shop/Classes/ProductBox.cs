using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.SessionState;

namespace Internet_Shop
{
    public class ProductBox : HtmlGenericControl
    {

        private String userID;
        private Page page;
        private String productID;

        public ProductBox(productInfo pInfo, String _userID, Page _page)
        {
            userID = _userID;
            page = _page;
            productID = pInfo.ID;

            this.TagName = "div";
            this.ID = "" + pInfo.ID;
            this.Attributes.Add("class", "prod_box");

            HtmlGenericControl boxTop = new HtmlGenericControl("div");
            HtmlGenericControl boxCenter = new HtmlGenericControl("div");
            HtmlGenericControl boxBottom = new HtmlGenericControl("div");
            HtmlGenericControl prTitle = new HtmlGenericControl("div");
            HtmlGenericControl prImg = new HtmlGenericControl("div");
            HtmlGenericControl prPrice = new HtmlGenericControl("div");
            HtmlAnchor titleRef = new HtmlAnchor();
            HtmlAnchor imgRef = new HtmlAnchor();
            HtmlGenericControl img = new HtmlGenericControl("img");
            HtmlGenericControl priceOne = new HtmlGenericControl("span");
            HtmlGenericControl priceTwo = new HtmlGenericControl("span");
            //details 
            HtmlGenericControl details = new HtmlGenericControl("div");
            HtmlAnchor detailsRef1 = new HtmlAnchor();
            HtmlAnchor detailsRef2 = new HtmlAnchor();
            HtmlAnchor detailsRef3 = new HtmlAnchor();
            HtmlAnchor detailsRef4 = new HtmlAnchor();
            HtmlGenericControl prDetailsImg1 = new HtmlGenericControl("img");
            HtmlGenericControl prDetailsImg2 = new HtmlGenericControl("img");
            HtmlGenericControl prDetailsImg3 = new HtmlGenericControl("img");

            //top box
            boxTop.Attributes.Add("class", "top_prod_box");

            //center box
            boxCenter.Attributes.Add("class", "center_prod_box");

            prTitle.Attributes.Add("class", "product_title");
            if (pInfo.name.Length > 25)
            {
                titleRef.InnerText = pInfo.name.Remove(22, pInfo.name.Length - 22) + "...";
                
            }
            else titleRef.InnerText = pInfo.name;
            titleRef.ServerClick += new EventHandler(details_click);
            prTitle.Controls.Add(titleRef);

            prImg.Attributes.Add("class", "product_img");
            prImg.Controls.Add(imgRef);
            img.Attributes.Add("src", pInfo.pic);
            img.Attributes.Add("style", "height:90px");
            imgRef.ServerClick += new EventHandler(details_click);
            imgRef.Controls.Add(img);

            prPrice.Attributes.Add("class", "prod_price");
            priceOne.Attributes.Add("class", "reduce");
            priceTwo.Attributes.Add("class", "price");
            priceOne.InnerText = pInfo.max_price + "$ ";
            priceTwo.InnerText = pInfo.current_price + "$";
            prPrice.Controls.Add(priceOne);
            prPrice.Controls.Add(priceTwo);

            boxCenter.Controls.Add(prTitle);
            boxCenter.Controls.Add(prImg);
            boxCenter.Controls.Add(prPrice);

            //box bottom
            boxBottom.Attributes.Add("class", "bottom_prod_box");

            //box details
            details.Attributes.Add("class", "prod_details_tab");
            detailsRef1.Attributes.Add("title", "header=[Add to cart] body=[&nbsp;] fade=[on]");
            detailsRef1.Attributes.Add("runat", "server");
            detailsRef1.ServerClick += new EventHandler(addToCard_Click);
            detailsRef2.Attributes.Add("title", "header=[Specials] body=[&nbsp;] fade=[on]");
            detailsRef3.Attributes.Add("title", "header=[Gifts] body=[&nbsp;] fade=[on]");
            detailsRef4.Attributes.Add("class", "prod_details");
            detailsRef4.ServerClick += new EventHandler(details_click);
            detailsRef4.InnerText = "details";

            prDetailsImg1.Attributes.Add("src", "/images/cart.gif");
            prDetailsImg2.Attributes.Add("src", "/images/favs.gif");
            prDetailsImg3.Attributes.Add("src", "/images/favorites.gif");
            prDetailsImg1.Attributes.Add("class", "left_bt");
            prDetailsImg2.Attributes.Add("class", "left_bt");
            prDetailsImg3.Attributes.Add("class", "left_bt");

            detailsRef1.Controls.Add(prDetailsImg1);
            detailsRef2.Controls.Add(prDetailsImg2);
            detailsRef3.Controls.Add(prDetailsImg3);

            details.Controls.Add(detailsRef1);
            details.Controls.Add(detailsRef2);
            details.Controls.Add(detailsRef3);
            details.Controls.Add(detailsRef4);

            //add all controls
            this.Controls.Add(boxTop);
            this.Controls.Add(boxCenter);
            this.Controls.Add(boxBottom);
            this.Controls.Add(details);
        }

        protected void addToCard_Click(object sender, EventArgs e)
        {
            if (userID != null)
            {
                setter.addToCart(userID, productID);
            }
            page.Response.Redirect("Shopping.aspx");
        }

        protected void details_click(object sender, EventArgs e)
        {
            page.Session["productID"] = productID;
            page.Response.Redirect("details.aspx");
        }
        
    }
}

/*
string script = "alert('abc');";
            item.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
*/