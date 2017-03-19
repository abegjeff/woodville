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
                Session["RowNo"] = "";
                pickID.Text = "No";
                FillData();
                FillList();
            }
        }

        private void FillList()
        {
            string mdata = "select ID from accounts order by ID";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            DDLID.DataSource = dt;
            DDLID.DataTextField = "ID";
            DDLID.DataValueField = "ID";
            DDLID.DataBind();

            DDLID.Items.Insert(0, new ListItem("<Select ID>", "0"));
        }

        private void FillData()
        {
            string mdata = "select * from accounts order by LastName";

            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    btnNext.Visible = true;

                    btnPrevious.Visible = true;
                }

                else
                {
                    btnNext.Visible = false;

                    btnPrevious.Visible = false;
                }

                if (Session["RowNo"].ToString() == "" || int.Parse(Session["RowNo"].ToString()) > dt.Rows.Count)
                {
                    Session["RowNo"] = "0";
                }

                if (dt.Rows.Count == int.Parse(Session["RowNo"].ToString()))
                {

                    Session["RowNo"] = "0";

                }

                if (Session["RowNo"].ToString() == "-1")
                {

                    Session["RowNo"] = (dt.Rows.Count - 1).ToString();

                }
            }


            DataRow dr = dt.Rows[int.Parse(Session["RowNo"].ToString())];

            
            if (pickID.Text == "Yes")
            {
                mdata = "select * from accounts WHERE ID="+DDLID.SelectedValue+" order by LastName";
            }
            
            if (pickID.Text == "Active")
            {
                mdata = "SELECT Certificates.IsActive, Accounts.*";
                mdata += " FROM Certificates INNER JOIN Accounts ON Certificates.id = Accounts.id WHERE Certificates.IsActive=1";
            }

            else if (pickID.Text == "Inactive")
            {
                mdata = "SELECT Certificates.IsActive, Accounts.*";
                mdata += " FROM Certificates INNER JOIN Accounts ON Certificates.id = Accounts.id WHERE Certificates.IsActive=0";
            }

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

            mdata = "select *, CONVERT(VARCHAR(10), DUEDATE, 101) AS DDATE, CONVERT(VARCHAR(10), DATEOFASSESSMENT, 101) AS DASSESSMENT from LedgerEntries where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            GVAssess.DataSource = dt;
            GVAssess.DataBind();

            mdata = "select *, CONVERT(VARCHAR(10), DATEPAID, 101) AS DPAID from Payments where AccountID=" + lblAccount.Text;
            dt = cf.GetData(mdata);
            GVPayments.DataSource = dt;
            GVPayments.DataBind();

            mdata = "select *, CONVERT(VARCHAR(10), PENALTYDATE, 101) AS PDATE from Penalties where AccountID=" + lblAccount.Text;
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

        protected void DDLID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLID.SelectedValue == "0")
            {
                pickID.Text = "No";
            }
            else
            {
                pickID.Text = "Yes";
            }
            FillData(); 
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            if (btnActive.Text == "All Accounts")
            {
                pickID.Text = "Active";
                btnActive.Text = "Active Only";
            }
            else if (btnActive.Text == "Active Only")
            {
                btnActive.Text = "Inactive Only";
                pickID.Text = "Inactive";
            }
            else
            {
                btnActive.Text = "All Accounts";
                pickID.Text = "All";
            }
            FillData();
            FillList();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Session["RowNo"] = (int.Parse(Session["RowNo"].ToString()) + 1).ToString();
            FillData();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Session["RowNo"] = (int.Parse(Session["RowNo"].ToString()) - 1).ToString();
            }

            catch
            {
                Session["RowNo"] = "0";
            }
            FillData();
        }
    }
}