using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WoodvilleWater.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WoodvilleWater.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void connect(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=ROLAND-PC\\SQLEXPRESS;Initial Catalog=WoodvilleWater;User ID=WaterUser;Password=wateruser";
            //connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Response.Write("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Can not open connection ! ");
            }
        }


        protected void LogIn(object sender, EventArgs e)
        {

            CreateConnection();
            string SqlString = "SELECT * FROM tbladmin WHERE emailaddress='" + Email.Text + "' and encpwd='" + Password.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
            DataTable dt = new DataTable();
            //Response.Redirect("../MainMenu.aspx");
            try
            {
                Conn.Open();
                sda.Fill(dt);
                DataRow row = dt.Rows[0];
                if (row["rights"].ToString()=="1")
                {
                    Session["Admin"] = "Yes";
                }
                else
                {
                    Session["Admin"] = "No";
                }
                Response.Redirect("../MainMenu.aspx");
            }
            catch (SqlException se)
            {
                Response.Write(se);
                //DBErLog.DbServLog(se, se.ToString());
            }
            finally
            {
                Conn.Close();
            }

            //if (IsValid)
            //{
            //    // Validate the user password
            //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            //    // This doen't count login failures towards account lockout
            //    // To enable password failures to trigger lockout, change to shouldLockout: true
            //    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

            //    switch (result)
            //    {
            //        case SignInStatus.Success:
            //            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //            break;
            //        case SignInStatus.LockedOut:
            //            Response.Redirect("/Account/Lockout");
            //            break;
            //        case SignInStatus.RequiresVerification:
            //            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
            //                                            Request.QueryString["ReturnUrl"],
            //                                            RememberMe.Checked),
            //                              true);
            //            break;
            //        case SignInStatus.Failure:
            //        default:
            //            FailureText.Text = "Invalid login attempt";
            //            ErrorMessage.Visible = true;
            //            break;
            //    }
            //}
        }

        private SqlConnection Conn;
        private void CreateConnection()
        {
            string ConnStr =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
        }

    }
}
