using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public partial class Post_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Main_Page_Post> postsList = new List<Main_Page_Post>();
            getter.loadMainPagePosts(postsList, this, true);
            foreach (Main_Page_Post var in postsList)
            {
                PlaceHolder_post.Controls.Add(var);
            }
            String userID = null;
            if (Session["name"] != null)
            {
                userID = getter.getUserID(Session["name"].ToString());
            }
            String postID = Session["postID"].ToString();
            leaveComment tb = new leaveComment(postID, userID, this, false);
            PlaceHolder_leaveComment.Controls.Add(tb);
        }
    }
}