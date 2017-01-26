using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoodvilleWater
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblAdmin.Text = Session["Admin"].ToString();
                if(lblAdmin.Text=="Yes")
                {
                    PnlAdmin.Visible = true;
                }
            }
        }

        protected void BtnBilling_Click(object sender, EventArgs e)
        {
            Response.Redirect("Billing.aspx");
        }

        protected void BtnPayments_Click(object sender, EventArgs e)
        {

        }

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPaid_Click(object sender, EventArgs e)
        {

        }

        protected void BtnNotPaid_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entry.aspx");
        }

        protected void BtnShare_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shares.aspx");
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnBillOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("BillOut.aspx");
        }

        protected void BtnDefaultFee_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultFee.aspx");
        }
    }
}