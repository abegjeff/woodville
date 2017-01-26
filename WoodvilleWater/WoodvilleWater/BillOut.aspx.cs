using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoodvilleWater
{
    public partial class BillOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {

        }
        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainmenu.aspx");
        }
    }
}