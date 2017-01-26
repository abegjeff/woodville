using System;

using System.Data.SqlClient;

using System.Web;

using System.Data;

using System.Collections;

using System.Configuration;

using System.Security.Cryptography;

using System.IO;

using System.Text;

using System.Text.RegularExpressions;


/// Summary description for DacWrappers.

/// </summary>

public class Wrappers

{

    private static Byte[] KEY_64 = { 13, 149, 11, 14, 14, 14, 21, 32, 21, 17, 46, 160, 64, 20, 15, 117, 112, 194, 241, 24, 29, 13, 84, 105 };

    private static Byte[] IV_64 = { 10, 113, 11, 176, 226, 95, 16, 126, 42, 65, 32, 1, 8, 7, 249, 21, 15, 23, 12, 19, 13, 10, 13, 24 };



    private static string _connectionString;



    /// <summary>

    /// Marked private because class doesn't require instantiation; all methods are static

    /// </summary>

    private Wrappers()

    {

        //

        // TODO: Add constructor logic here

        //



    }



    public static string ConnectionString

    {

        get

        {

            //only go get it if we don't have a value already

            if (_connectionString == null || _connectionString == string.Empty)

            {
                    _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            }



            string pwd = Decrypt(ConfigurationManager.AppSettings["PasswordEncrypted"]);

            _connectionString = Regex.Replace(_connectionString, "#pwd#", pwd);



            return _connectionString;

        }

    }

    public static string Encrypt(string value)

    {

        if (value.Length == 0)

            return value;

        TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();

        MemoryStream ms = new MemoryStream();

        CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);

        StreamWriter sw = new StreamWriter(cs);

        sw.Write(value);

        sw.Flush();

        cs.FlushFinalBlock();

        ms.Flush();

        // convert back to a string

        return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));

    }



    // returns DES decrypted string

    public static string Decrypt(string value)

    {

        try

        {

            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();

            Byte[] buffer = Convert.FromBase64String(value);

            MemoryStream ms = new MemoryStream(buffer);

            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cs);



            return sr.ReadToEnd();

        }

        catch (FormatException)

        {

            return value;

        }

        catch (CryptographicException)

        {

            return value;

        }

    }

    /// <summary>

    /// This function is a update function that can be used by all other classes in the Radio.BO

    /// This function is a wrapper function that wraps up the functionallity of conn.ModdifyData. It has

    /// the same variables that are passed in. This function is for modifying, inserting, and deleting 

    /// records from the database.

    /// </summary>

    /// <param name="strQuery">name the query name to be used.</param>

    /// <param name="list">a list of parameter that need to used. Can be zero or many.</param>

    /// <returns>string that is either a complete message or the error that occured.</returns>

    public static string Modify_Record(string strQuery, params SqlParameter[] list)

    {

            // try catch Activated by Roland 11/17/14

            try

            {

                // get the stored procedure

                //do the modify can be an insert or update, or a delete



                conn.ModifyData(strQuery, ConnectionString,

                    CommandType.StoredProcedure, list

                    );

                return "";//if it was succesfull return empty string.

            }

            catch (Exception exc)// If there was an error return it.

            {

                return exc.Message;

            }

    }



    public static string Modify_Record(string strQuery, string constring, params SqlParameter[] list)

    {

        using (clDac conn = new clDac())

        {

            //try

            //{

            // get the stored procedure

            //do the modify can be an insert or update, or a delete

            // try catch Activated by Roland 11/17/14

            try

            {

                conn.ModifyData(strQuery, constring,

                    CommandType.StoredProcedure, list

                    );

                return "";//if it was succesfull return empty string.

            }

            catch (Exception exc)

            {

                return exc.Message;

            }

            //}

            //catch(Exception exc)// If there was an error return it.

            //{

            //    return exc.Message;

            //}

        }

    }



    /// <summary>

    /// This function is a wrapper for the the function GetDataSet from the class clDac. It 

    /// basically is the same function, but allows the BO to access it within its own namespace

    /// wich prevents the multiple using of the same header files. This function is for retrieving records

    /// </summary>

    /// <param name="strQuery">name the query name to be used.</param>

    /// <param name="list">List of parameters, can be 0 or many</param>

    /// <returns>DataTable of the items that where found.</returns>

    public static DataRow GetDataRow(string strQuery, params SqlParameter[] list)

    {

        using (clDac conn = new clDac(ConnectionString, ConnectionTypes.SQL))

        {



            conn.ConnectionType = ConnectionTypes.SQL.ToString();

            return conn.GetDataRow(strQuery, ConnectionString, CommandType.StoredProcedure, list);

        }

    }

    public static DataRow GetDataRow(string strQuery)

    {

        using (clDac conn = new clDac(ConnectionString, ConnectionTypes.SQL))

        {

            conn.ConnectionType = ConnectionTypes.SQL.ToString();

            // call the dac function and execute the stored procedure information, and return the 

            //query in a dataset



            conn.ConnectionType = ConnectionTypes.SQL.ToString();

            return conn.GetDataRow(strQuery, ConnectionString);



        }

    }



    /// <summary>

    /// This function is a wrapper for the the function GetDataSet from the class clDac. It 

    /// basically is the same function, but allows the BO to access it within its own namespace

    /// wich prevents the multiple using of the same header files. This function is for retrieving records

    /// </summary>

    /// <param name="strQuery">name the query name to be used.</param>

    /// <param name="list">List of parameters, can be 0 or many</param>

    /// <returns>DataTable of the items that where found.</returns>

    public static DataTable GetDataTable(string strQuery, params SqlParameter[] list)

    {

        using (clDac conn = new clDac())

        {

            try

            {

                return conn.GetDataTable(strQuery, ConnectionString, CommandType.StoredProcedure, list);

            }

            catch

            {

                return new DataTable();

            }

        }

    }



    /// <summary>

    /// This function is a wrapper for the the function GetDataSet from the class clDac. It 

    /// basically is the same function, but allows the Radio.BO to access it within its own namespace

    /// wich prevents the multiple using of the same header files. This function is for retrieving records

    /// </summary>

    /// <param name="strQuery">name the query name to be used.</param>

    /// <param name="list">List of parameters, can be 0 or many</param>

    /// <returns>DataSet of the items that where found.</returns>

    public static DataSet GetDataSet(string strQuery, params SqlParameter[] list)

    {

        using (clDac conn = new clDac())

        {

            // call the dac function and execute the stored procedure information, and return the 

            //query in a dataset

            return conn.GetDataSet(strQuery, ConnectionString, CommandType.StoredProcedure, list);

        }

    }



    #region GetData Method Wrappers



    /// <summary>

    /// GetData is used to select a single item from the database.

    /// </summary>

    /// <param name="strCommandText">The stored procedure name or T-SQL command.</param>

    /// <example>Here is just one example of how to use this class.

    /// INEL.IT.Utility is required to use <see cref="INEL.IT.Utility.clSqlReader"/>

    /// <code>

    /// ...

    /// using INEL.IT.DAC;

    /// using INEL.IT.Utility

    /// ...

    /// void TestMethod()

    /// {

    ///          object objTest;

    ///   

    ///          //NOTE: clGloabals.ConnString is just the connection string

    ///          using(clDac conn = new clDac(clGlobals.ConnString))

    ///          using(clSqlReader sRead = new clSqlReader(clGlobals.XmlDocPath))

    ///          {

    ///                DataRow dr = dsTables.Tables["ReqRollDown"].Rows.Find(strID);

    ///                //NOTE: clGlobals.XmlNodePath is just string holding the node path

    ///                objTest = conn.GetData(sRead.GetSQL("Ins_ReqRollDown","Query",clGlobals.XmlNodePath + @"/Group1"));

    ///          }

    ///   }

    /// </code>

    /// </example>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string strCommandText)

    {

        using (clDac objDac = new clDac(ConnectionString))

        {

            return objDac.GetData(strCommandText);

        }

    }



    public static object GetData(string strQuery, params SqlParameter[] list)

    {

        using (clDac conn = new clDac())

        {

            //try

            //{

            //    //do the modify - can be an insert or update, or a delete

            return conn.GetData(strQuery, ConnectionString,

                    CommandType.StoredProcedure, list

                    );

            //}

            //catch(Exception exc)// If there was an error return it.

            //{

            //    //return exc.Message;

            //}

        }

    }

    /// <summary>

    /// GetData is used to select a single value from the database.

    /// </summary>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string[] strSqlandConn)

    {

        using (clDac objDac = new clDac())

        {

            return objDac.GetData(strSqlandConn);

        }

    }



    /// <summary>

    /// GetData is used to select a single value from the database.

    /// </summary>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string strCommandText, string strConnection)

    {

        using (clDac objDac = new clDac())

        {

            return objDac.GetData(strCommandText, strConnection);

        }

    }



    /// <summary>

    /// GetData is used to select a single value from the database.

    /// </summary>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string strQuery, CommandType commandType,

        params IDbDataParameter[] commandParameters)

    {

        using (clDac objDac = new clDac(ConnectionString))

        {

            return objDac.GetData(strQuery, commandType, commandParameters);

        }

    }



    /// <summary>

    /// GetData is used to select a single value from the database.

    /// </summary>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string[] strSqlandConn, CommandType commandType,

        params IDbDataParameter[] commandParameters)

    {

        using (clDac objDac = new clDac())

        {

            return objDac.GetData(strSqlandConn, commandType, commandParameters);

        }

    }



    /// <summary>

    /// GetData is used to select a single value from the database.

    /// </summary>

    /// <returns>object - user must cast as desired type (int, string, etc.)</returns>

    public static object GetData(string strCommandText, string strConnection,

        CommandType commandType, params IDbDataParameter[] commandParameters)

    {

        using (clDac objDac = new clDac())

        {

            return objDac.GetData(strCommandText, strConnection, commandType, commandParameters);

        }

    }



    #endregion GetData Method Wrappers





}
