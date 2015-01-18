using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Internet_Shop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        FileUpload FU;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_top.Text = "";
            if (Session["msg"] != null && Session["msg"].ToString() != "")
            {
                lbl_top.Text = Session["msg"].ToString();
                Session["msg"] = "";
            }

            FU = new FileUpload();
            ph_fu_1.Controls.Add(FU);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Account_type"]) == 0)
            {
                Response.Redirect("My_account.aspx");
            }

            if (Session["name"] != null && this.MasterPageFile == "/Site.Master")
            {
                this.MasterPageFile = "/Logined.Master";
            }

            if (Session["name"] == null && this.MasterPageFile == "/Logined.Master")
            {
                this.MasterPageFile = "/Site.Master";
                Response.Redirect("Enter.aspx");
            }
        }

        protected void btn_addgoods_Click(object sender, EventArgs e)
        {
            Guid ID = Guid.NewGuid();
            try
            {
                String rootPath = Server.MapPath("~");
                String dir = rootPath + "/images/loadedpic/" + ID;
                if (FU.FileName != "" && FU.FileName != null)
                {
                    dir += FU.FileName;
                    FU.SaveAs(dir);
                    dir = "/images/loadedpic/" + ID + FU.FileName;
                }
                else dir = "/images/loadedpic/__Page.png";

                setter.addProduct(tb_name.Text, dir, tb_priceless.Text, tb_price.Text, tb_info.Text,
                    tb_type.Text, DropDownList1.SelectedValue.ToString(),
                    tb_weight.Text, tb_insurance.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tb_manufacturer.Text);
                lbl_top.Text = "product added";
            }
            catch (Exception ex)
            {
                lbl_top.Text = ex.Message;
            }
        }


    }
}