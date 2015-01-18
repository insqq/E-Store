using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Internet_Shop
{
    public class deleter : database
    {
        static public void clearCart(String userID)
        {
            try
            {
                MySqlCommand cmdDataBase = new MySqlCommand(
                    "Delete from cart where idcart ='" + userID + "';", con);
                cmdDataBase.ExecuteScalar();
            }
            catch (MySqlException)
            {

            }
        }

        static public void deleteProduct(String productID)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("delete from products where idproducts = '" + productID + "';", con);
                cmd.ExecuteScalar();
            }
            catch (MySqlException)
            {
            }

        }
    }
}