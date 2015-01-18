using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;

namespace Internet_Shop
{
    public class productInfo
    {
        public String ID;
        public String name;
        public String pic;
        public String current_price;
        public String max_price;
        public String info;
        public String product_type;
        public String Main_big_pic;
        public String[,] thumbs_pic;
        public String inStoc;
        public String weight;
        public String insurance;
        public String add_date;
        public String manufacturer;

        public productInfo(DataRow dr)
        {
            ID = dr[0].ToString();
            name = dr[1].ToString();
            pic = dr[2].ToString();
            current_price = dr[3].ToString();
            max_price = dr[4].ToString();
            /*MemoryStream stream = new MemoryStream((byte[])dr[5]);
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            info = reader.ReadToEnd();*/
            info = dr[5].ToString();
            product_type = dr[6].ToString();
            inStoc = dr[7].ToString();
            weight = dr[8].ToString();
            insurance = dr[9].ToString();
            add_date = dr[10].ToString();
            manufacturer = dr[11].ToString();
        }

    }
}