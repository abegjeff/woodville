using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WoodvilleWater
{
    public partial class Shares : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillFromIDList();
                fillFromName();
                fillToName();
            }
        }

        protected void fillData()
        {
            string mdata;
            ClassFile cf = new ClassFile();
            DataTable dt;

            if (DDLFromName.SelectedValue != "0" && DDLFromID.SelectedValue != "0")
            {
                mdata = "select * from Certificates where AccountID=" + DDLFromID.SelectedValue + " AND IsActive=0";
                dt = cf.GetData(mdata);
                GVCert.DataSource = dt;
                GVCert.DataBind();
            }
            
        }

        protected void BtnEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entry.aspx");
        }

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (DDLToName.SelectedValue.ToString() == "0")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "To Shareholder Name Not Selected";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (lblCertSelected.Text == "" || lblNumShares.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "A Certificate Was Not Selected";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (txtNumTransfer.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "Number of Shares to Transfer Was Not Entered";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (txtNewCert.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "New Certificate Number Was Not Entered";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (txtRemainCert.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "Remaining Certificate Number Was Not Entered";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (txtNumTransfer.Text != "")
            {
                if (lblNumShares.Text != "")
                {
                    if (double.Parse(txtNumTransfer.Text) > double.Parse(lblNumShares.Text))
                    {
                        if (errorMessage != "")
                        {
                            errorMessage += ", ";
                        }
                        errorMessage += "The Number Of Shares To Transfer Is Greater Than The Number Of Shares Available";
                        lblError.Visible = true;
                        lblError.Text = errorMessage;
                    }
                }
            }

            if (txtNewCertNote.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "A New Certificate Note Was Not Entered";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }
            if (txtRemCertNote.Text == "")
            {
                if (errorMessage != "")
                {
                    errorMessage += ", ";
                }
                errorMessage += "A Remainder Certificate Note Was Not Entered";
                lblError.Visible = true;
                lblError.Text = errorMessage;
            }

            else
            {
                string mdata = "";
                ClassFile cf = new ClassFile();

                /********
                Remember to update the id in certificates to auto-increment 
                *********/
                mdata = "SELECT MAX(id) AS maxID FROM Certificates";
                DataTable dt = cf.GetData(mdata);
                DataRow dr = dt.Rows[0];

                int newID = int.Parse(dr["maxID"].ToString()) + 1;
                int remID = newID++;

                string updatedNewCertNote = txtNewCertNote.Text;
                updatedNewCertNote = updatedNewCertNote.Replace("'", "''");

                string updatedRemCertNote = txtRemCertNote.Text;
                updatedRemCertNote = updatedRemCertNote.Replace("'", "''");

                //New Certificate
                mdata = "INSERT INTO Certificates (id, CertificateNumber, AccountId, NumberOfShares, IsActive, DateOfActivation, DateOfTransfer, TransfereeAccountId, Note) values(" + newID + "," + txtNewCert.Text + "," + DDLToName.SelectedValue.ToString() + ",";
                mdata += txtNumTransfer.Text + ", 0, " + "CONVERT(VARCHAR(10), GETDATE(), 101), CONVERT(VARCHAR(10), GETDATE(), 101)," + DDLToName.SelectedValue.ToString() + ",'" + updatedNewCertNote + "')";
                cf.Modify_Data(mdata);

                if ((double.Parse(lblNumShares.Text) - double.Parse(txtNumTransfer.Text)) != 0)
                {
                    //Remaining Certificate
                    mdata = "INSERT INTO Certificates (id, CertificateNumber, AccountId, NumberOfShares, IsActive, DateOfActivation, DateOfTransfer, TransfereeAccountId, Note) values(" + remID + "," + txtRemainCert.Text + "," + DDLFromID.SelectedValue.ToString() + ",";
                    mdata += (double.Parse(lblNumShares.Text) - double.Parse(txtNumTransfer.Text)).ToString() + ", 0, " + "CONVERT(VARCHAR(10), GETDATE(), 101), CONVERT(VARCHAR(10), GETDATE(), 101)," + DDLFromID.SelectedValue.ToString() + ",'" + txtRemCertNote.Text + "')";
                    cf.Modify_Data(mdata);
                }

                //Update the Old Transfered Certificate
                mdata = "UPDATE Certificates SET NumberOfShares=0, IsActive=1, Note='This certificate is now Inactive. " + txtNumTransfer.Text + " shares were transferred to " +  DDLToName.SelectedItem.ToString() + ", ID: " + DDLToName.SelectedValue.ToString() + "' WHERE CertificateNumber=" + lblCertSelected.Text;
                cf.Modify_Data(mdata);                 

                lblError.Visible = true;
                lblError.Text = "Shares Transferred";
                clearData();
            }

        }

        protected void clearData()
        {
            string mdata = "Select * from Certificates WHERE id < 0";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            GVCert.DataSource = dt;
            GVCert.DataBind();

            lblCertSelected.Text = "";
            lblNumShares.Text = "";
            txtNewCert.Text = "";
            txtNewCertNote.Text = "";
            txtNumTransfer.Text = "";
            txtRemainCert.Text = "";
            txtRemCertNote.Text = "";

            fillFromIDList();
            fillFromName();
            fillToName();

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void DDLFromID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLFromName.SelectedValue = DDLFromID.SelectedValue;
            fillData();
        }

        protected void DDLFromName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLFromID.SelectedValue = DDLFromName.SelectedValue;
            fillData();
        }


        protected void fillFromIDList()
        {
            string mdata = "SELECT distinct Accounts.id, Accounts.FirstName, Accounts.LastName "
                          + "FROM Accounts INNER JOIN "
                         + "Certificates ON Accounts.id = Certificates.AccountId "
                         + "WHERE IsActive=0 order by ID";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            DDLFromID.DataSource = dt;
            DDLFromID.DataValueField = "ID";
            DDLFromID.DataTextField = "ID";
            DDLFromID.DataBind();

            DDLFromID.Items.Insert(0, new ListItem("<Select ID>", "0"));
        }

        protected void fillFromName()
        {
            string mdata = "SELECT distinct accounts.ID,FIRSTNAME + CHAR(32) + LASTNAME AS FLNAME "
                         + "FROM Accounts INNER JOIN "
                         + "Certificates ON Accounts.id = Certificates.AccountId "
                         + "WHERE IsActive=0 order by ID";

            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            DDLFromName.DataSource = dt;
            DDLFromName.DataTextField = "FLNAME";
            DDLFromName.DataValueField = "ID";
            DDLFromName.DataBind();

            DDLFromName.Items.Insert(0, new ListItem("<Select Name>", "0"));
        }

        protected void fillToName()
        {
            string mdata = "select *, FIRSTNAME + CHAR(32) + LASTNAME AS FLNAME from accounts order by ID";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            string x = dt.Rows.Count.ToString();
            DDLToName.DataSource = dt;
            DDLToName.DataTextField = "FLNAME";
            DDLToName.DataValueField = "ID";
            DDLToName.DataBind();

            DDLToName.Items.Insert(0, new ListItem("<Select Name>", "0"));
        }


        protected void GVCert_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GVCert.SelectedDataKey.Value.ToString();

            lblCertSelected.Text = GVCert.SelectedRow.Cells[0].Text.ToString();
            lblNumShares.Text = GVCert.SelectedRow.Cells[1].Text.ToString();

            string mdata = "SELECT MAX(CertificateNumber) AS maxCert FROM Certificates";
            ClassFile cf = new ClassFile();
            DataTable dt = cf.GetData(mdata);
            DataRow dr = dt.Rows[0];

            txtNewCert.Text = (int.Parse(dr["maxCert"].ToString()) + 1).ToString();
            txtRemainCert.Text = (int.Parse(txtNewCert.Text) + 1).ToString();
        }
    }
}