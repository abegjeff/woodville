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

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string mdata = "insert into Accounts (FirstName,LastName,AddressLine1,AddressLine2,AddressLine3,Phone,Notes,Email) values('" + txtFname.Text + ",'" + txtLname.Text + "','" + txtAddress1.Text + "','";
            mdata=mdata+txtAddress2.Text + "','"+txtAddress3.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtPhone.Text + "','" + txtEmail.Text + "','" + txtNotes.Text + "'";

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