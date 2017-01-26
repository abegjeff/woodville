using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WoodvilleWater
{
    public partial class Accounting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillData();
                
            }
        }
        private void FillData()
        {
            string mdata = "select * from accounts order by LastName";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            DataRow dr = dt.Rows[0];
            lblAccount.Text = dr["ID"].ToString();
            txtFname.Text = dr["FirstName"].ToString();
            txtLname.Text = dr["LastName"].ToString();
            txtAddress1.Text = dr["AddressLine1"].ToString();
            txtAddress2.Text = dr["AddressLine2"].ToString();
            txtAddress3.Text = dr["AddressLine3"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtNotes.Text = dr["Notes"].ToString();

            mdata = "select * from Certificates where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            GVCert.DataSource = dt;
            GVCert.DataBind();

            mdata = "select * from LedgerEntries where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            GVAssess.DataSource = dt;
            GVAssess.DataBind();

            mdata = "select * from Payments where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            GVPayments.DataSource = dt;
            GVPayments.DataBind();

            mdata = "select * from Penalties where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            GVPen.DataSource = dt;
            GVPen.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string mdata = "insert into Accounts (FirstName,LastName,AddressLine1,AddressLine2,AddressLine3,Phone,Email,Notes) values('" + txtFname.Text + ",'" + txtLname.Text + "','" + txtAddress1.Text + "','";
            mdata=mdata+txtAddress2.Text + "','"+txtAddress3.Text + "','"  + txtPhone.Text + "','" + txtEmail.Text + "','" + txtNotes.Text + "'";

            ClassFile c = new ClassFile();
            c.Modify_Data(mdata);

            mdata = "select * from accounts";
            ClassFile cf = new ClassFile();
            DataTable dt= cf.GetData(mdata);
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}