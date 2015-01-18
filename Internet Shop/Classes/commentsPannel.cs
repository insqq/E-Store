using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public class commentsPannel : HtmlGenericControl
    {
        private TextBox tb;
        private productInfo pInfo;
        private String userID;
        private Page page;

        public commentsPannel(productInfo _pInfo, String _userID, Page _page)
        {
            pInfo = _pInfo;
            userID = _userID;
            page = _page;
            this.TagName = "div";
            this.Attributes.Add("class", "center_content");

            HtmlGenericControl center_title_bar = new HtmlGenericControl("div");
            center_title_bar.Attributes.Add("class", "center_title_bar");
            center_title_bar.InnerText = "Залишити коментар";
            this.Controls.Add(center_title_bar);

            HtmlGenericControl prod_box_big = new HtmlGenericControl("div");
            prod_box_big.Attributes.Add("class", "prod_box_big");
            this.Controls.Add(prod_box_big);
            // top div
            HtmlGenericControl top_prod_box_big = new HtmlGenericControl("div");
            top_prod_box_big.Attributes.Add("class", "top_prod_box_big");
            prod_box_big.Controls.Add(top_prod_box_big);

            HtmlGenericControl center_prod_box_big = new HtmlGenericControl("div");
            center_prod_box_big.Attributes.Add("class", "center_prod_box_big");
            prod_box_big.Controls.Add(center_prod_box_big);
            // product_img_main

            // bottom div
            HtmlGenericControl bottom_prod_box_big = new HtmlGenericControl("div");
            bottom_prod_box_big.Attributes.Add("class", "bottom_prod_box_big");
            prod_box_big.Controls.Add(bottom_prod_box_big);
            // end product details div
        }


        public productInfo getpInfo()
        {
            return pInfo;
        }

        protected void leaveComment_Click(object sender, EventArgs e)
        {

            if (userID != null)
            {
                setter.addCommentToProduct(tb.Text, pInfo.ID, userID);
                page.Response.Redirect("Shopping.aspx");
            }
        }
    }
}