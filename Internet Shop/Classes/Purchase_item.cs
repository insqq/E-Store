using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace Internet_Shop
{
    public class Purchase_item : HtmlGenericControl
    {
        public Purchase_item(int n)
        {
            this.TagName = "div";
            this.ID = "box" + n;
            this.Attributes.Add("class", "purchase_item_box");
        }

        
    }
}