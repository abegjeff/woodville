using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WoodvilleWater
{
    public partial class Entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillList();
                txtFname.Focus();
            }
        }

        private void FillList()
        {
            string mdata = "select *, CONVERT(varchar(10), ID) + '      ' + FIRSTNAME + '      ' + LASTNAME AS FLNAME from accounts order by ID";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            DDLIDNAME.DataSource = dt;
            DDLIDNAME.DataTextField = "FLNAME";
            DDLIDNAME.DataValueField = "ID";
            DDLIDNAME.DataBind();

            DDLIDNAME.Items.Insert(0, new ListItem("<Select ID To Edit>", "0"));
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string mdata = "";
            ClassFile cf = new ClassFile();
            DataTable dt;

            if (BtnAdd.Text == "Add Entry")
            {
                mdata = "select MAX(id) as MMID from Accounts";
                
                dt = cf.GetData(mdata);
                DataRow dr = dt.Rows[0];
 
                int idNum = int.Parse(dr["MMID"].ToString()) + 1;

                mdata = "insert into Accounts (ID,FirstName,LastName,AddressLine1,AddressLine2,AddressLine3,Phone,Notes,Email) values(" + idNum +  ",'" + txtFname.Text + "','" + txtLname.Text + "','" + txtAddress1.Text + "','";
                mdata = mdata + txtAddress2.Text + "','" + txtAddress3.Text + "','" + txtPhone.Text + "','" + txtEmail.Text + "','" + txtNotes.Text + "')";

                lblMessage.Text = txtFname.Text + " " + txtLname.Text + " has been added.";
            }
            else
            {
                mdata = "update Accounts SET FirstName='" + txtFname.Text + "', LastName='" + txtLname.Text + "', AddressLine1='" + txtAddress1.Text + "', AddressLine2='"
                    + txtAddress2.Text + "', AddressLine3='" + txtAddress3.Text + "', Phone='" + txtPhone.Text + "', Notes='" + txtNotes.Text + "', Email='" + txtEmail.Text + "'"
                    + "WHERE ID=" + DDLIDNAME.SelectedValue.ToString();

                lblMessage.Text = txtFname.Text + " " + txtLname.Text + "\'s record has been updated.";
            }

            ClassFile c = new ClassFile();
            c.Modify_Data(mdata);

            pnlMain.Visible = false;
            pnlMessage.Visible = true;


        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void DDLIDNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLIDNAME.SelectedIndex.ToString() == "0")
            {
                clearData();
            }
            else
            {
                string mdata = "select * from accounts where ID=" + DDLIDNAME.SelectedValue.ToString();
                ClassFile cf = new ClassFile();
                DataTable dt = cf.GetData(mdata);
                DataRow dr = dt.Rows[0];

                lblAccount.Text = dr["ID"].ToString();
                txtFname.Text = dr["FIRSTNAME"].ToString();
                txtLname.Text = dr["LASTNAME"].ToString();
                txtAddress1.Text = dr["ADDRESSLINE1"].ToString();
                txtAddress2.Text = dr["ADDRESSLINE2"].ToString();
                txtAddress3.Text = dr["ADDRESSLINE3"].ToString();
                txtPhone.Text = dr["PHONE"].ToString();
                txtEmail.Text = dr["EMAIL"].ToString();
                txtNotes.Text = dr["NOTES"].ToString();

                BtnAdd.Text = "Edit/Save";
            }
        }

        protected void clearData()
        {
            lblAccount.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtNotes.Text = "";
            BtnAdd.Text = "Add Entry";
        }

        protected void btnCloseUpdate_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlMessage.Visible = false;
            FillList();
            clearData();
            txtFname.Focus();
        }
    }
}