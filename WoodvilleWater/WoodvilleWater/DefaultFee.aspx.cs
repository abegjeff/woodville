using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WoodvilleWater
{
    public partial class DefaultFee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldata();
            }
        }

        private void filldata()
        {
            string SqlString = "SELECT * FROM Defaults";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
            DataTable dt = new DataTable();
            //Response.Redirect("../MainMenu.aspx");
            try
            {
                Conn.Open();
                sda.Fill(dt);
                DataRow row = dt.Rows[0];
                txtFee.Text = row["DefaultFee"].ToString();
                txtName.Text = row["DefaultKey"].ToString();
                txtSharePrice.Text = row["SharePrice"].ToString();
            }
            catch { }
        }

        private SqlConnection Conn;
        private void CreateConnection()
        {
            string ConnStr =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string SqlString = "update defaults set DefaultFee='"+txtFee.Text +",Defaultkey='"+txtName.Text+"',SharePrice="+txtSharePrice.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
        }
    }
}