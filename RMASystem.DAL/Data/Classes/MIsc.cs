//using System.Data.SqlClient;
//using System;
//using Newtonsoft.Json;
//using System.Net.Mail;

//namespace RMASystem.DAL;

//public class Misc
//{
//    const string logSource = "RMA.Common.Classes.Misc.cs";
//    private static DateTime GetDBDate()
//    {
//        DateTime datetime = DateTime.Now;
//        try
//        {
//            SqlConnection con = new SqlConnection();         
//            ConnectionDAL.OpenConnection(ref con);
//            SqlCommand com = con.CreateCommand();
//            com.CommandText = "SELECT GETDATE()";

//            SqlDataReader rd = com.ExecuteReader();
//            rd.Read();
//            if (rd.HasRows)
//            {
//                datetime = rd.IsDBNull(0) ? DateTime.Now : rd.GetDateTime(0);
//            }
//            rd.Close();
//            rd.Dispose();
//            com.Dispose();
//            ConnectionDAL.CloseConnection(ref con);
//        }
//        catch
//        {

//        }
//        return datetime;
//    }


//    public static DateTime Now
//    {
//        get
//        {
//            return GetDBDate();
//        }
//    }

//    public static bool IsMailAddressValid(string email)
//    {
//        try
//        {
//            MailAddress m = new MailAddress(email);

//            return true;
//        }
//        catch (FormatException)
//        {
//            return false;
//        }
//    }
//}
