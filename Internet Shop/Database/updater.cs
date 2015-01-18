using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Internet_Shop
{
    public class updater : database
    {
        static public void changeOrderStatus(String idorder)
        {
            MySqlCommand cmd = new MySqlCommand("", con);
            cmd.CommandText = "select status from orders where idorders ='" + idorder + "';";
            String s = cmd.ExecuteScalar().ToString();
            if (s == "Виконується")
            {
                cmd.CommandText = "update orders set status = 'Виконано' where idorders ='" + idorder + "';";
            }
            else
            {
                cmd.CommandText = "update orders set status = 'Виконується' where idorders ='" + idorder + "';";
            }

            cmd.ExecuteNonQuery();
        }

    }
}