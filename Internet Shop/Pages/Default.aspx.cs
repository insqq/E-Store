using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Main_Page_Post> postsList = new List<Main_Page_Post>();
            getter.loadMainPagePosts(postsList, this);


            foreach (Main_Page_Post var in postsList)
            {
                PlaceHolder1.Controls.Add(var);
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
            }
        }  
    }
}