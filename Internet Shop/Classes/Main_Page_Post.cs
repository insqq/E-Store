using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Internet_Shop
{
    public class Main_Page_Post : HtmlGenericControl
    {
        String title;
        String date;
        String titlePicWay;
        String postetBy;
        String content;
        String idpost;
        Page page;

        public Main_Page_Post(DataRow dr, Page _page, bool detail)
        {
            title = dr[0].ToString();
            date = dr[1].ToString();
            titlePicWay = dr[2].ToString();
            content = Encoding.UTF8.GetString((byte[])dr[3]);
            postetBy = dr[4].ToString();
            idpost = dr[5].ToString();
            page = _page;

            this.TagName = "div";
            this.Attributes.Add("class", "center_content");

            

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

            HtmlGenericControl titleDiv = new HtmlGenericControl("div");
            HtmlGenericControl contentDiv = new HtmlGenericControl("div");
            HtmlGenericControl img = null;
            HtmlGenericControl bottomDiv = new HtmlGenericControl("div");

            HtmlAnchor titleRef = new HtmlAnchor();
            titleDiv.Attributes.Add("class", "product_title");
            titleRef.Attributes.Add("runat", "server");
            titleRef.Attributes.Add("style", "font-size: 20px");
            titleRef.InnerText = title;
            titleRef.ServerClick += new EventHandler(titleRef_click);
            titleDiv.Controls.Add(titleRef);
            center_prod_box_big.Controls.Add(titleDiv);

            contentDiv.Attributes.Add("class", "content_div");

            if (content.Length > 200 && !detail)
            {
                contentDiv.InnerText = content.Remove(200, content.Length - 200) + "...";
            }
            else contentDiv.InnerText = content;
            center_prod_box_big.Controls.Add(contentDiv);

            if (titlePicWay != null)
            {
                img = new HtmlGenericControl("img");
                img.Attributes.Add("src", titlePicWay);

                HtmlAnchor imgRef = new HtmlAnchor();
                imgRef.Attributes.Add("runat", "server");
                imgRef.Controls.Add(img);

                center_prod_box_big.Controls.Add(imgRef);
            }

            bottomDiv.InnerText = date + " " + postetBy;
            bottomDiv.Attributes.Add("class", "bottom_div");
            center_prod_box_big.Controls.Add(bottomDiv);

            HtmlGenericControl bottom_prod_box_big = new HtmlGenericControl("div");
            bottom_prod_box_big.Attributes.Add("class", "bottom_prod_box_big");
            prod_box_big.Controls.Add(bottom_prod_box_big);

        }

        protected void titleRef_click(object sender, EventArgs e)
        {
            page.Session["postID"] = idpost;
            page.Response.Redirect("Post_details.aspx");
        }
    }
}