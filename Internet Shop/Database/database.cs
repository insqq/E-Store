using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace Internet_Shop
{
    public class database
    {
        static protected MySqlConnection con = new MySqlConnection(@"Data Source=localhost; DataBase=internet_store; User ID=root; Password=root");
        static protected MySqlCommand _cmd = new MySqlCommand("", con);
        


        static public void conOpen()
        {
            con.Open();
        }

        static public void conClose()
        {
            con.Close();
        }
    }
}