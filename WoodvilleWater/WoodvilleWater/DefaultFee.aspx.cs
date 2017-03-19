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
                fillList();
                BtnSave.Text = "Add/Save";
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

        private void fillList()
        {
            string mdata = "select ID, DefaultKey from Defaults order by DefaultKey";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            DDLFees.DataSource = dt;
            DDLFees.DataTextField = "DefaultKey";
            DDLFees.DataValueField = "ID";
            DDLFees.DataBind();

            DDLFees.Items.Insert(0, new ListItem("<Select Name>", "0"));
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
            string mdata = "";
            ClassFile cf = new ClassFile();

            mdata = "SELECT MAX(id) AS maxID FROM Defaults";
            DataTable dt = cf.GetData(mdata);
            DataRow dr = dt.Rows[0];

            int newID = int.Parse(dr["maxID"].ToString()) + 1;

            if (BtnSave.Text == "Add/Save")
            {
                mdata = "INSERT into defaults(id, DefaultKey, DefaultValue, SharePrice) values(" + newID + "," + txtName.Text + "," + double.Parse(txtFee.Text) + "," + float.Parse(txtSharePrice.Text) + ")";
                cf.Modify_Data(mdata);
            }
            else
            {
                string SqlString = "update defaults set DefaultFee='" + txtFee.Text + ",Defaultkey='" + txtName.Text + "',SharePrice=" + txtSharePrice.Text;
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
            }
            
        }

        private void clearData()
        {
            txtName.Text = "";
            txtFee.Text = "";
            txtSharePrice.Text = "";
        }

        protected void DDLFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLFees.SelectedIndex.ToString() == "0")
            {
                clearData();
                BtnSave.Text = "Add/Save";
            }
            else
            {
                BtnSave.Text = "Edit/Update";
            }
        }
    }
}