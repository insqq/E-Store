using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Internet_Shop
{
    public class getter : database
    {
        static public String loginValidation(System.Web.SessionState.HttpSessionState Session, String nickname, String pw)
        {
            _cmd.CommandText = "select internet_store.login_validation('" + nickname +"', '"+ pw +"');";
            object result = _cmd.ExecuteScalar();
            if (result.ToString() != "2")
            {
                Session["name"] = nickname;
                Session["account_type"] = Convert.ToInt32(result);
                return "";
            }
            else return "Ви ввели некоректні дані.";
        }

        static public String getUserID(String nickname)
        {
            MySqlCommand cmdDataBase = new MySqlCommand("Select idUsers from users where NickName = '" + nickname + "';  ", con);
            String userID = cmdDataBase.ExecuteScalar().ToString().Replace(" ", "");

            return userID;
        }

        static public void getCartItems(GridView gv, String userID)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "Select product_name, count, current_price from cart c inner join products p where idcart = '" +
                userID + "' and c.products_idproducts = p.idproducts;", con);
            adapter.Fill(dt);

            dt.Columns.Add("total price", typeof(String));
            double total = 0;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[3] = Convert.ToDouble(dr[1]) * Convert.ToDouble(dr[2]);
                    total += Convert.ToDouble(dr[3]);
                }
            }
            catch (Exception) { }

            dt.Rows.Add();
            dt.Columns.Add("edit", typeof(ButtonField));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == "" || dr[0] == null)
                {
                    dr[0] = "total: ";
                    dr[3] = total;
                }
                else
                {
                    Button btn = new Button();
                }
            }
            gv.DataSource = dt;
            gv.DataBind();
        }

        static public void loadProducts(List<productInfo> l)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from products", con);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new productInfo(dr));
            }
        }

        static public void loadProducts(List<productInfo> l, String category)
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from products where product_type = '" + category + 
                "' or manufacturer = '" + category + "';", con);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new productInfo(dr));
            }
        }

        static public productInfo loadProduct(String pID, String userID)
        {
            productInfo pInfo = null;

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from products where idproducts='" + pID + "'; ", con);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                pInfo = new productInfo(dr);
            }

            return pInfo;
        }

        static public String getTotalItems(String userID)
        {
            MySqlCommand cmdDataBase = new MySqlCommand(
                "select SUM(count) from cart where idcart = '" + userID + "';", con);

            String count = cmdDataBase.ExecuteScalar().ToString().Replace(" ", "");

            return count;
        }

        static public void loadMainPagePosts(List<Main_Page_Post> l, Page page, bool detail = false)
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select title, date, titlePicWay, content, NickName, idPost " +
                "from main_page_posts p inner join users u on p.users_idUsers=u.idUsers;", con);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new Main_Page_Post(dr, page, detail));
            }
        }

        static public void loadSimilarProducts(List<productInfo> l, productInfo pInfo)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from products p inner join thumbs_pic t on p.idproducts=t.IDproduct where product_type = ''", con);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new productInfo(dr));
            }
        }

        static public void loadNewProduct(ref productInfo product)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from products p order by add_date desc limit 6", con);
            adapter.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(0, dt.Rows.Count);

                product = new productInfo(dt.Rows[randomNumber]);
            }
        }

        static public Double getTotalPrice(String userID)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "Select count, current_price from cart as ci inner join products p where idcart = '" +
                userID + "' and ci.products_idproducts = p.idproducts;", con);
            adapter.Fill(dt);

            Double total = 0;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    total += Convert.ToDouble(dr[0]) * Convert.ToDouble(dr[1]);
                }
            }
            catch (Exception) { }

            return total;
        }

        static public DataTable getOrderList(String userID)
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select date, totalPrice, status, idorders from orders where users_idUsers = '" + userID + "';", con);
            adapter.Fill(dt);

            /*gv.DataSource = dt;
            gv.DataBind();*/
            return dt;
        }

        static public DataTable getCategorys()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select product_type from products group by product_type;", con);
            adapter.Fill(dt);


            return dt;
        }

        static public DataTable loadProductComments(String itemID)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select Name, text, date from comments c join users u on c.users_idUsers = u.idUsers where products_idproducts = '" + itemID + "' order by date desc", con);
            adapter.Fill(dt);

            return dt;
        }

        static public DataTable loadPostsComments(String itemID)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select Name, text, date from comments c join users u on c.users_idUsers = u.idUsers where main_page_posts_idPost = '" + itemID + "' order by date desc", con);
            adapter.Fill(dt);

            return dt;
        }

        static public DataTable getManufacturers()
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select manufacturer from products group by manufacturer;", con);
            adapter.Fill(dt);


            return dt;
        }
    }
}