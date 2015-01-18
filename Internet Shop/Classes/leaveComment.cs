using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public class leaveComment : HtmlGenericControl
    {
        private TextBox tb;
        private String itemID;
        private String userID;
        private Page page;

        public leaveComment(String _itemID, String _userID, Page _page, Boolean whatItem)
        {
            itemID = _itemID;
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

            if (whatItem)
            {
                foreach (DataRow dr in getter.loadProductComments(itemID).Rows)
                {
                    center_prod_box_big.Controls.Add(post(dr));
                }
            }
            else
            {
                foreach (DataRow dr in getter.loadPostsComments(itemID).Rows)
                {
                    center_prod_box_big.Controls.Add(post(dr));
                }
            }

            if (page.Session["name"] != null)
            {
                tb = new TextBox();
                tb.Attributes.Add("style", "resize: none");
                tb.Width = 500;
                tb.Height = 125;
                tb.TextMode = TextBoxMode.MultiLine;
                center_prod_box_big.Controls.Add(tb);

                HtmlGenericControl leaveCommentDiv = new HtmlGenericControl("div");
                leaveCommentDiv.Attributes.Add("class", "form_row");

                HtmlAnchor leaveComment = new HtmlAnchor();
                leaveComment.InnerText = "Відправити";
                leaveComment.Attributes.Add("class", "contact");
                leaveComment.ServerClick += new EventHandler(leaveComment_Click);
                leaveCommentDiv.Controls.Add(leaveComment);
                center_prod_box_big.Controls.Add(leaveCommentDiv);
            }

            else
            {
                Label lbl = new Label();
                lbl.Text = "Авторизуйтесь щоб залишити коментар";
                center_prod_box_big.Controls.Add(lbl);
            }

            // bottom div
            HtmlGenericControl bottom_prod_box_big = new HtmlGenericControl("div");
            bottom_prod_box_big.Attributes.Add("class", "bottom_prod_box_big");
            prod_box_big.Controls.Add(bottom_prod_box_big);
            // end product details div
            
        }

        private HtmlGenericControl post(DataRow dr)
        {
            HtmlGenericControl p = new HtmlGenericControl("div");
            p.Attributes.Add("style", "Margin: 15px 23px 23px 23px; text-align: left;");

            HtmlGenericControl name = new HtmlGenericControl("div");
            name.Attributes.Add("style", "Margin: 3px 10px 3px 3px");
            Label lbl = new Label();
            lbl.Text = "name: " + dr[0].ToString() + "<br>" + "date:" + dr[2].ToString();
            name.Controls.Add(lbl);

            HtmlGenericControl text = new HtmlGenericControl("div");
            text.Attributes.Add("style", "Margin: 5px 0 3px 3px");

            MemoryStream stream = new MemoryStream((byte[])dr[1]);
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String info = reader.ReadToEnd();
            text.InnerHtml = info;

            p.Controls.Add(name);
            p.Controls.Add(text);
            return p;
        }

        protected void leaveComment_Click(object sender, EventArgs e)
        {
            if (page.Session["name"] != null)
            {
                setter.addCommentToProduct(tb.Text, itemID, userID);
                page.Response.Redirect("details.aspx");
            }
        }
    }
}