using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Internet_Shop
{
    public class setter : database
    {
        static public String registration(String name, String sureName, String nickName, String password, String email)
        {
            string checkUser = "select count(*) from users where NickName='" + nickName + "'";
            MySqlCommand com = new MySqlCommand(checkUser, con);
            int tmp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (tmp == 1)
            {
                return "user with same nickname allready register";
            }

            com = new MySqlCommand("insert into users (Name, Surename, NickName, Password, Email" +
                ") values('" + name + "', '" + sureName + "', '" + nickName + "', '" + 
                password + "', '" + email + "');", con);
            com.ExecuteNonQuery();

           
            return "";
        }

        static public void addToCart(String userID, String productID)
        {
            MySqlCommand cmdDataBase = new MySqlCommand("select COUNT(*) from cart where products_idproducts ='" +
                productID + "' AND idcart ='" + userID + "' ", con);
            String tmp = cmdDataBase.ExecuteScalar().ToString();

            if (tmp == "0")
            {
                cmdDataBase = new MySqlCommand("insert into cart (idcart, products_idproducts) values('" +
                    userID + "', '" + productID + "') ", con);
                cmdDataBase.ExecuteScalar();
                return;
            }
            else
            {
                cmdDataBase = new MySqlCommand("UPDATE cart SET count= '" + (Convert.ToInt32(tmp) + 1) + 
                    "' where products_idproducts ='" + productID + "' AND idcart ='" + userID + "';", con);
                cmdDataBase.ExecuteScalar();
                return;
            }
        }

        static public void addProduct(String name, String PicPath, String CurrentPrice, String MaxPrice, String Info, String productType,
          String inStoc, String weight, String insurance, String add_date, String manufacturer)
        {
            if (CurrentPrice == "") CurrentPrice = "0";
            if (MaxPrice == "") MaxPrice = "0";
            if (PicPath != null)
            {
                String s = PicPath.Remove(0, PicPath.Length - 4);
                if (s != ".png")
                {
                    PicPath += ".png";
                }
            }


            MySqlCommand cmdDataBase = new MySqlCommand(
                "insert into products (product_name, product_pic, current_price, max_price,info,product_type," +
            " inStoc, weight, insurance, add_date, manufacturer) values('" + name + "', '" + PicPath + "', '" + CurrentPrice + "', '" +
            MaxPrice + "', '" + Info + "', '" + productType + "'   , '" + inStoc + "'  , '" + weight +
            "' , '" + insurance + "' , '" + add_date + "', '" + manufacturer + "' );", con);
            cmdDataBase.ExecuteNonQuery();

        }

        static public void createOrder(String userID, String address)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "Select count, current_price from cart ci inner join products p "+
                "where idcart = '" + userID + "' and ci.products_idproducts = p.idproducts;", con);
            adapter.Fill(dt);

            Double total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDouble(dr[0]) * Convert.ToDouble(dr[1]);
            }

            MySqlCommand cmdDataBase = new MySqlCommand("insert into orders (users_idUsers, date, totalPrice, address) "+
                "values ('" + userID + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + total.ToString() +"', '"+ 
                address +"' );", con);
            cmdDataBase.ExecuteScalar();

            cmdDataBase.CommandText = "select last_insert_id() from cart;";
            string idorder = cmdDataBase.ExecuteScalar().ToString();

            cmdDataBase = new MySqlCommand("Insert into orderitems (productId, orders_idorders, count) "+
                "select products_idproducts as productId, '" + idorder + "' as orders_idorders, count from cart "+
                "where idcart =  '" + userID + "';", con);

            cmdDataBase.ExecuteScalar();
        }

        static public void addCommentToProduct(String text, String itemID, String idUser)
        {
            MySqlCommand com = new MySqlCommand("insert into comments (text, date, products_idproducts, users_idUsers) values('" + 
                text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                itemID + "', '" + idUser + "'); ", con);
            com.ExecuteScalar();
        }

        static public void addCommentToPost(String text, String itemID, String idUser)
        {
            MySqlCommand com = new MySqlCommand("insert into comments (text, date, main_page_posts_idPost, users_idUsers) values('" +
                text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                itemID + "', '" + idUser + "'); ", con);
            com.ExecuteScalar();
        }

        static public void addQuestion(String name, String email, String phone, String topic, String text)
        {
            Guid qID = Guid.NewGuid();


            MySqlCommand cmd = new MySqlCommand("insert into user_questions (iduser_questions, name, email, phone, topic, text, date) values('" +
                 qID.ToString() + "', '" + name + "', '" + email + "', '" + phone + "', '" + topic + "', '" + text + "', '" +
                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'); ", con);
            cmd.ExecuteScalar();

        }

        static public void addQuestion(String topic, String text, String userID)
        {
            Guid qID = Guid.NewGuid();


            MySqlCommand cmd = new MySqlCommand("insert into user_questions (iduser_questions, topic, text, iduser, date) values('" +
                 qID.ToString() + "', '" + topic + "', '" + text + "', '" + userID + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'); ", con);
            cmd.ExecuteScalar();

        }

    }
}