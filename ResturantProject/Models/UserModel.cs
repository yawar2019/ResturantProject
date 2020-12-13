using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResturantProject.Models
{
    public class UserModel
    {

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleType { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public bool IsEnabled { get; set; }
        public int UID { get; set; }
    }

    public class UserContext
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Restaurent;Integrated Security=True");

        public List<UserModel> GetAllUserList()
        {
            List<UserModel> Userlist = new List<UserModel>();
            SqlCommand cmd = new SqlCommand("SP_GETUSERDEATILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                UserModel objuser = new UserModel();
                objuser.UID = Convert.ToInt32(rec[0]);
                objuser.FullName = Convert.ToString(rec[1]);
                objuser.UserName = Convert.ToString(rec[2]);
                objuser.Password = Convert.ToString(rec[3]);
                objuser.ConfirmPassword = Convert.ToString(rec[4]);
                objuser.RoleType = Convert.ToString(rec[5]);
                objuser.EmailId = Convert.ToString(rec[6]);
                objuser.ContactNo = Convert.ToString(rec[7]);
                objuser.IsEnabled = Convert.ToBoolean(rec[8]);

                Userlist.Add(objuser);
            }
            return Userlist;
        }
        public int InsertUser(UserModel obj)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTUSER", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FULLNAME", obj.FullName);
            cmd.Parameters.AddWithValue("@USERNAME", obj.UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
            cmd.Parameters.AddWithValue("@CONFIRMPASSWORD", obj.ConfirmPassword);
            cmd.Parameters.AddWithValue("@ROLETYPE", obj.RoleType);
            cmd.Parameters.AddWithValue("@EMAILID", obj.EmailId);
            cmd.Parameters.AddWithValue("@MOBILENO", obj.ContactNo);
            cmd.Parameters.AddWithValue("@ENABLED", obj.IsEnabled);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public UserModel GetUserDetailWithID(int? id)
        {
            UserModel obj = new Models.UserModel();
            SqlCommand cmd = new SqlCommand("SP_GETUSERDEATILSWITHID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@UID", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                obj.UID = Convert.ToInt32(rec[0]);
                obj.FullName = Convert.ToString(rec[1]);
                obj.UserName = Convert.ToString(rec[2]);
                obj.Password = Convert.ToString(rec[3]);
                obj.ConfirmPassword = Convert.ToString(rec[4]);
                obj.RoleType = Convert.ToString(rec[5]);
                obj.EmailId = Convert.ToString(rec[6]);
                obj.ContactNo = Convert.ToString(rec[7]);
                obj.IsEnabled = Convert.ToBoolean(rec[8]);
            }
            return obj;
        }
        public int UpdateUser(UserModel obj)
        {
            int i;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATEUSER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FULLNAME", obj.FullName);
                cmd.Parameters.AddWithValue("@USERNAME", obj.UserName);
                cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
                cmd.Parameters.AddWithValue("@CONFIRMPASSWORD", obj.ConfirmPassword);
                cmd.Parameters.AddWithValue("@ROLETYPE", obj.RoleType);
                cmd.Parameters.AddWithValue("@EMAILID", obj.EmailId);
                cmd.Parameters.AddWithValue("@MOBILENO", obj.ContactNo);
                cmd.Parameters.AddWithValue("@ENABLED", obj.IsEnabled);
                cmd.Parameters.AddWithValue("@UID", obj.UID);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int DeleteUser(int? id)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETEUSER", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                con.Close();
                return i;
            }
            else
            {
                return 0;
            }
        }

    }

    public class CategoryItem
    {
        public TBL_CATEGORY Category { get; set; }
        public TBL_ITEMLIST Item { get; set; }
        public List<TBL_CATEGORY> CategoryList { get; set; }
        public List<TBL_ITEMLIST> ItemList { get; set; }
    }

}