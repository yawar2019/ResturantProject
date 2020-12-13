using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ResturantProject.Models
{

    public partial class MenuModel
    {
        [Key]
        public int MID { get; set; }
        public string CategoryName { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<CategoryModel> Categories { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
        public string Imagepath { get; set; }

        public byte[] MenuImage { get; set; }

        //public Nullable <int>  CID { get; set; }



        public List<System.Web.Mvc.SelectListItem> distList { get; set; }

        public bool Enabled { get; set; }
        public virtual CategoryModel CategoryModel { get; set; }

        //public virtual CatModel CatModel { get; set; }

        //public List<Category_List> CateList { get; set; }



    }
    public class Category_List
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryViewModel
    {
        ///public MenuModel meunu { get; set; }
        public string CategoryName { get; set; }
        public List<Category_List> CateList { get; set; }
    }
    public class MenuContext
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Restaurent;Integrated Security=True");
        public List<Category_List> GetCategoryList()
        {
            string s = "Select ID,CategoryName from TBL_CATEGORY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader idr = cmd.ExecuteReader();

            List<Category_List> CategoryList = new List<Category_List>();
            if (idr.HasRows)
            {
                while (idr.Read())
                {
                    CategoryList.Add(new Category_List
                    {
                        ID = Convert.ToInt32(idr["ID"]),
                        CategoryName = Convert.ToString(idr["CategoryName"]),
                    });
                }
            }
            con.Close();
            return CategoryList;
        }
        public MenuModel GetAllMenuListWithId(int? ID)

        {
            MenuModel obj = new Models.MenuModel();
            SqlCommand cmd = new SqlCommand("SP_GETITEMDETAILSWITHID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {



                obj.MenuName = Convert.ToString(rec["ITEMNAME"]);
                obj.Description = Convert.ToString(rec["DESCRIPTION"]);
                obj.Price = Convert.ToDouble(rec["PRICE"]);
                obj.Enabled = Convert.ToBoolean(rec["ENABLED"]);
                //obj.CategoryName = Convert.ToString(rec["CategoryName"]);
                obj.Imagepath = Convert.ToString(rec["ImagePath"]);
                obj.MID = Convert.ToInt32(rec["ID"]);
                obj.MenuImage = (byte[])rec["MenuImage"];


                // ID,ITEMNAME,DESCRIPTION,PRICE,ENABLED,CategoryName,ImagePath,MenuImage
            }
            return obj;

        }
        public MenuModel GetAllMenuListWithId11(int? ID)
        {
            MenuModel obj = new Models.MenuModel();
            SqlCommand cmd = new SqlCommand("SP_GETMENUDETAILWITHID1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                obj.MenuName = Convert.ToString(rec["ITEMNAME"]);
                obj.Description = Convert.ToString(rec["DESCRIPTION"]);
                obj.Price = Convert.ToDouble(rec["PRICE"]);
                obj.Enabled = Convert.ToBoolean(rec["ENABLED"]);
                obj.CategoryName = Convert.ToString(rec["CategoryName"]);
                obj.Imagepath = Convert.ToString(rec["ImagePath"]);
                obj.MID = Convert.ToInt32(rec["ID"]);
                obj.MenuImage = (byte[])rec["MenuImage"];
                // ID,ITEMNAME,DESCRIPTION,PRICE,ENABLED,CategoryName,ImagePath,MenuImage
            }
            return obj;
        }
        public int UpdateItem(MenuModel obj)
        {
            int i;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATEITEM", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ITEMNAME", obj.MenuName);
                cmd.Parameters.AddWithValue("@DESCRIPTION", obj.Description);
                cmd.Parameters.AddWithValue("@PRICE", obj.Price);
                cmd.Parameters.AddWithValue("@ENABLED", obj.Enabled);
                cmd.Parameters.AddWithValue("@CreatedBy", 0);
                cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                cmd.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                cmd.Parameters.AddWithValue("@ID", obj.MID);


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
        public int DeleteItem(int? ID)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETEITEM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}