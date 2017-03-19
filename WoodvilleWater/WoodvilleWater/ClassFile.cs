using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WoodvilleWater.Models;

namespace WoodvilleWater
{
    public class ClassFile
    {
        //private string connectionString;
        //public static string ConnectionString
        //{
        //    get { return connectionString; }
        //    set { connectionString = value; }
        //}
        //public static DbConnection OpenConnection()
        //{
        //    OracleConnection con = new OracleConnection(ConnectionString);
        //    con.Open();
        //    return con;
        //}
        //private void connect(object sender, EventArgs e)
        //{
        //    string connetionString = null;
        //    SqlConnection cnn;
        //    connetionString = "Data Source=ROLAND-PC\\SQLEXPRESS;Initial Catalog=WoodvilleWater;User ID=WaterUser;Password=wateruser";
        //    //connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //    cnn = new SqlConnection(connetionString);
        //    try
        //    {
        //        cnn.Open();
        //        //Response.Write("Connection Open ! ");
        //        cnn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //       // Response.Write("Can not open connection ! ");
        //    }
        //}
        public  SqlConnection Conn;
        public  SqlConnection CreateConnection()
        {
            string ConnStr =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
            //Conn.Open();
            return Conn;
        }

        public void Modify_Data(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CreateConnection();
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public DataTable GetData(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, CreateConnection());
            DataTable dt = new DataTable();
            //Response.Redirect("../MainMenu.aspx");
            try
            {
                Conn.Open();
                sda.Fill(dt);
            }
            catch
            { }
            return dt;
        }

    }
}
