using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoodvilleWater
{
    public partial class Shares : System.Web.UI.Page
    {
        

        protected void BtnEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entry.aspx");
        }

        protected void BtnTransfer_Click(object sender, EventArgs e)
        {

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}