using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Internet_Shop
{
    public class details_product : HtmlGenericControl
    {
        private productInfo pInfo;
        private String userID;
        private Page page;

        public details_product(productInfo _pInfo, String _userID, Page _page)
        {
            pInfo = _pInfo;
            userID = _userID;
            page = _page;
            this.TagName = "div";
            this.Attributes.Add("class", "center_content");

            HtmlGenericControl center_title_bar = new HtmlGenericControl("div");
            center_title_bar.Attributes.Add("class", "center_title_bar");
            center_title_bar.InnerText = pInfo.name;
            this.Controls.Add(center_title_bar);

            HtmlGenericControl prod_box_big = new HtmlGenericControl("div");
            prod_box_big.Attributes.Add("class", "prod_box_big");
            this.Controls.Add(prod_box_big);
            // top div
            HtmlGenericControl top_prod_box_big = new HtmlGenericControl("div");
            top_prod_box_big.Attributes.Add("class", "top_prod_box_big");
            prod_box_big.Controls.Add(top_prod_box_big);
            // middle div
            HtmlGenericControl center_prod_box_big = new HtmlGenericControl("div");
            center_prod_box_big.Attributes.Add("class", "center_prod_box_big");
            prod_box_big.Controls.Add(center_prod_box_big);
            // product_img_main
            HtmlGenericControl product_img_big = new HtmlGenericControl("div");
            product_img_big.Attributes.Add("class", "product_img_big");
            center_prod_box_big.Controls.Add(product_img_big);

            HtmlAnchor imgPopUpRef = new HtmlAnchor();
            imgPopUpRef.Attributes.Add("href", "javascript:popImage('" + pInfo.Main_big_pic + "','" + pInfo.name + "')");
            imgPopUpRef.Attributes.Add("title", "header=[Zoom] body=[&nbsp;] fade=[on]");
            HtmlGenericControl main_pic = new HtmlGenericControl("img");
            main_pic.Attributes.Add("src", pInfo.pic);
            main_pic.Attributes.Add("alt", "");
            main_pic.Attributes.Add("border", "0");
            imgPopUpRef.Controls.Add(main_pic);
            product_img_big.Controls.Add(imgPopUpRef);

            //details_big_box
            HtmlGenericControl details_big_box = new HtmlGenericControl("div");
            details_big_box.Attributes.Add("class", "details_big_box");
            center_prod_box_big.Controls.Add(details_big_box);
            HtmlGenericControl product_title_big = new HtmlGenericControl("div");
            product_title_big.Attributes.Add("class", "product_title_big");
            product_title_big.InnerText = pInfo.product_type + " / " + pInfo.name;
            details_big_box.Controls.Add(product_title_big);
            HtmlGenericControl specifications = new HtmlGenericControl("div");
            specifications.Attributes.Add("class", "specifications");
            details_big_box.Controls.Add(specifications);

            HtmlGenericControl inStocq = new HtmlGenericControl("div");
            inStocq.InnerText = "В наявності: ";
            HtmlGenericControl weightq = new HtmlGenericControl("div");
            weightq.InnerText = "Вага: ";
            HtmlGenericControl insuranceq = new HtmlGenericControl("div");
            insuranceq.InnerText = "Гарантія: ";


            HtmlGenericControl inStoc = new HtmlGenericControl("span");
            inStoc.Attributes.Add("class", "blue");
            inStoc.InnerText = pInfo.inStoc;
            HtmlGenericControl weight = new HtmlGenericControl("span");
            weight.Attributes.Add("class", "blue");
            weight.InnerText = pInfo.weight;
            HtmlGenericControl insurance = new HtmlGenericControl("span");
            insurance.Attributes.Add("class", "blue");
            insurance.InnerText = pInfo.insurance;

            specifications.Controls.Add(inStocq);
            inStocq.Controls.Add(inStoc);
            specifications.Controls.Add(weightq);
            weightq.Controls.Add(weight);
            specifications.Controls.Add(insuranceq);
            insuranceq.Controls.Add(insurance);

            HtmlGenericControl prod_price_big = new HtmlGenericControl("div");
            prod_price_big.Attributes.Add("class", "prod_price_big");
            HtmlGenericControl reduce = new HtmlGenericControl("span");
            reduce.Attributes.Add("class", "reduce");
            reduce.InnerText = pInfo.max_price + "$ ";
            prod_price_big.Controls.Add(reduce);
            HtmlGenericControl price = new HtmlGenericControl("span");
            price.Attributes.Add("class", "price");
            price.InnerText = pInfo.current_price + "$ ";
            prod_price_big.Controls.Add(price);
            details_big_box.Controls.Add(prod_price_big);

            HtmlAnchor addtocart = new HtmlAnchor();
            addtocart.InnerText = "В корзину";
            addtocart.Attributes.Add("class", "addtocart");
            addtocart.ServerClick += new EventHandler(addToCard_Click);
            details_big_box.Controls.Add(addtocart);
            


            if (userID != null && Convert.ToInt32(page.Session["Account_type"]) == 1)
            {
                HtmlAnchor delete = new HtmlAnchor();
                delete.InnerText = "Видалити";
                delete.Attributes.Add("class", "addtocart");
                delete.ServerClick += new EventHandler(delete_Click);
                details_big_box.Controls.Add(delete);
            }

            /*HtmlAnchor compare = new HtmlAnchor();
            compare.InnerText = "compare";
            compare.Attributes.Add("class", "compare");
            details_big_box.Controls.Add(compare);*/

            // bottom div
            HtmlGenericControl bottom_prod_box_big = new HtmlGenericControl("div");
            bottom_prod_box_big.Attributes.Add("class", "bottom_prod_box_big");
            prod_box_big.Controls.Add(bottom_prod_box_big);
            // end product details div

            HtmlGenericControl center_title_bar2 = new HtmlGenericControl("div");
            center_title_bar2.Attributes.Add("class", "center_title_bar");
            center_title_bar2.InnerText = "Похожа продукція";
            this.Controls.Add(center_title_bar2);
        }

        private HtmlAnchor createThumb(int n)
        {
            HtmlAnchor thumb = new HtmlAnchor();
            thumb.Attributes.Add("href", "javascript:popImage('" + pInfo.thumbs_pic[n, 1] + "','" + pInfo.name + "')");
            thumb.Attributes.Add("title", "header=[Zoom] body=[&nbsp;] fade=[on]");
            HtmlGenericControl small_thumb = new HtmlGenericControl("img");
            small_thumb.Attributes.Add("src", pInfo.thumbs_pic[n, 0]);
            small_thumb.Attributes.Add("style", "height:20px");
            small_thumb.Attributes.Add("alt", "");
            small_thumb.Attributes.Add("border", "0");
            thumb.Controls.Add(small_thumb);
            return thumb;
        }

        public productInfo getpInfo()
        {
            return pInfo;
        }

        protected void addToCard_Click(object sender, EventArgs e)
        {

            if (userID != null)
            {
                setter.addToCart(userID, pInfo.ID);
                page.Response.Redirect("Shopping.aspx");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            deleter.deleteProduct(pInfo.ID);
            page.Session["msg"] = "product deleted";
            page.Response.Redirect("My_account_admin.aspx");
        }
    }
}