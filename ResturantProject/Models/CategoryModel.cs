using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ResturantProject.Models
{
    public class CategoryModel
    {
        public int CID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public List<CategoryModel> Categories { get; set; }

    }

    public class CategoryContext
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Restaurent;Integrated Security=True");
        public List<CategoryModel> GetCategoryList()
        {
            List<CategoryModel> catlist = new List<CategoryModel>();
            SqlCommand cmd = new SqlCommand("SP_GetAllCategoryDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                CategoryModel catobj = new CategoryModel();
                catobj.CID = Convert.ToInt32(rec[0]);
                catobj.CategoryName = Convert.ToString(rec[1]);
                catobj.Description = Convert.ToString(rec[2]);
                catobj.Enabled = Convert.ToBoolean(rec[3]);
                catlist.Add(catobj);
            }
            return catlist;
        }

        public int InsertCategory(CategoryModel objcat)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTCATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CATEGORYNAME", objcat.CategoryName);
            cmd.Parameters.AddWithValue("@DESCRIPTION", objcat.Description);
            cmd.Parameters.AddWithValue("@ENABLED", objcat.Enabled);
            cmd.Parameters.AddWithValue("@CreatedBy", 0);
            cmd.Parameters.AddWithValue("@UpdatedBy", 0);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public CategoryModel GetCategoryListwithId(int? id)
        {
            CategoryModel obj = new CategoryModel();
            SqlCommand cmd = new SqlCommand("SP_GETCATEGORYDEATILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CID", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                obj.CategoryName = Convert.ToString(rec["CategoryName"]);
                obj.Description = Convert.ToString(rec["DESCRIPTION"]);
                obj.Enabled = Convert.ToBoolean(rec["Enabled"]);
                obj.CID = Convert.ToInt32(rec["ID"]);
            }
            return obj;
        }
        public int UpdateCategory(CategoryModel obj)
        {
            int i;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATECATEGORY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CID", obj.CID);
                cmd.Parameters.AddWithValue("@CATEGORYNAME", obj.CategoryName);
                cmd.Parameters.AddWithValue("@DESCRIPTION", obj.Description);
                cmd.Parameters.AddWithValue("@ENABLED", obj.Enabled);
                cmd.Parameters.AddWithValue("@CreatedBy", 0);
                cmd.Parameters.AddWithValue("@UpdatedBy", 0);
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
        public int DeleteCategory(int? id)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETECATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
    }
}