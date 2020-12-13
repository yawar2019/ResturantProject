using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResturantProject.Models;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ResturantProject.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Restaurent;Integrated Security=True");
        CategoryContext catcontext = new CategoryContext();
        MenuContext menucontext = new MenuContext();
        //ResturantProjectEntities catcontext = new ResturantProjectEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        EmpContext econtext = new EmpContext();
        UserContext ucontext = new UserContext();

        public ActionResult ItemDataEntry()
        {
            List<string> categoryList = new List<string>();
            ResturantProjectEntities db = new ResturantProjectEntities();
            var result = db.spGetCategories();
            foreach (string item in result)
            {
                categoryList.Add(item);
            }
            Session["CategoryNames"] = categoryList;
            return View(categoryList);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserLogin(UserModel obj)
        {
            if (ModelState.IsValid)
            {

                string s = "Select UserName,Password,RoleType from TBL_LOGIN where UserName=@username and Password=@password";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", obj.UserName);
                cmd.Parameters.AddWithValue("@password", obj.Password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                    return Redirect("~/Admin/Index");
                }
                //if (obj.UserName == "Admin" && obj.Password == "Admin")
                //{
                //    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                // return Redirect("~/Admin/Index");
                // return RedirectToAction("Index", "Admin", new { UserId = "Admin" });

                // }
                else
                {
                    ViewBag.msg = "Invalid UserName and Password";

                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Admin/UserLogin");
        }
        [HttpGet]
        public ActionResult GetCatDetails()
        {
            return View(catcontext.GetCategoryList());
        }
        [HttpGet]
        public ActionResult Addnew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(CategoryModel obj)
        {
            int i = catcontext.InsertCategory(obj);
            if (i > 0)
            {
                ViewBag.msg = "Category Inserted Successfully";
            }
            else
            {
                ViewBag.msg = "Failed to Added Category";
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditCat(int? ID)
        {
            CategoryModel obj = catcontext.GetCategoryListwithId(ID);
            return View(obj);
        }
        [HttpPost]
        public ActionResult EditCat(CategoryModel obj)
        {
            int i = catcontext.UpdateCategory(obj);
            if (i > 0)
            {
                ViewBag.msg = "Updated Successfully";
                return RedirectToAction("GetCatDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Update Record";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteCat(int? ID)
        {
            CategoryModel obj = catcontext.GetCategoryListwithId(ID);
            return View(obj);
        }
        [HttpPost]
        [ActionName("DeleteCat")]
        public ActionResult DeleteConfirmed(int? ID)
        {
            int i = catcontext.DeleteCategory(ID);
            if (i > 0)
            {
                ViewBag.msg = "Deleted Successfully";
                return RedirectToAction("GetCatDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Delete Record";
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetItemDetails()
        {
            return View(GetAllMenuList());
        }
        public List<MenuModel> GetAllMenuList()
        {
            List<MenuModel> menulist = new List<MenuModel>();
            SqlCommand cmd = new SqlCommand("SP_GETITEMDEATILS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                MenuModel menuobj = new Models.MenuModel();
                menuobj.MID = Convert.ToInt32(rec[0]);
                menuobj.MenuName = Convert.ToString(rec[1]);
                menuobj.Description = Convert.ToString(rec[2]);
                menuobj.Price = Convert.ToDouble(rec[3]);
                menuobj.Enabled = Convert.ToBoolean(rec[4]);
                menuobj.CategoryName = Convert.ToString(rec[5]);
                menuobj.Imagepath = Convert.ToString(rec[6]);
                menuobj.MenuImage = (byte[])rec[7];
                //if(rec[5] == DBNull.Value)
                //{
                // menuobj.Enabled = Convert.ToBoolean(rec[5]);
                //}
                menulist.Add(menuobj);

            }
            return menulist;
        }

        [HttpGet]
        public ActionResult AddMenu()
        {

            //CategoryModel objcat = new Models.CategoryModel(); // categorymodel
            MenuModel objcat = new Models.MenuModel(); // menumodel
            DataSet ds = new DataSet();
            string s = "Select * from TBL_CATEGORY";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            // List<CategoryModel> catlist = new List<CategoryModel>(); // categorymodel
            List<CategoryModel> catlist = new List<CategoryModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CategoryModel cobj = new CategoryModel();

                cobj.CID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                cobj.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                catlist.Add(cobj);
            }
            objcat.Categories = catlist;
            con.Close();
            return View(objcat);


        }
        [HttpPost]
        public ActionResult AddMenu(HttpPostedFileBase postedFile, MenuModel menufile)
        {
            try
            {
                //CODE FOR IMAGE
                //HttpPostedFileBase postedFile,
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }


                SqlCommand cmd = new SqlCommand("Insert into TBL_ITEMLIST(ITEMNAME,DESCRIPTION,PRICE,ENABLED,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,MenuImage,ImagePath,CategoryName) values (@ITEMNAME,@DESCRIPTION,@PRICE,@ENABLED,@CreatedBy,@CreatedDate,@UpdatedBy,@UpdatedDate,@MenuImage,@ImagePath,@CategoryName)", con);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@CATEID",menufile.CID);
                cmd.Parameters.AddWithValue("@ITEMNAME", menufile.MenuName);
                cmd.Parameters.AddWithValue("@DESCRIPTION", menufile.Description);
                cmd.Parameters.AddWithValue("@PRICE", menufile.Price);
                cmd.Parameters.AddWithValue("@ENABLED", menufile.Enabled);
                cmd.Parameters.AddWithValue("@CreatedBy", 0);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@MenuImage", bytes);
                string fileName = Path.GetFileName(postedFile.FileName);
                string path = "Images/" + fileName;
                postedFile.SaveAs(Server.MapPath("~/Images/" + fileName));
                cmd.Parameters.AddWithValue("@ImagePath", path);
                cmd.Parameters.AddWithValue("@CategoryName", menufile.CategoryName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    con.Close();
                    ViewBag.msg = "Record Saved Successfully";
                }
                else
                {
                    con.Close();
                    ViewBag.msg = "Record Failed to Added";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("AddMenu");

        }
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
        [HttpGet]
        public ActionResult EditMenu(int? ID)
        {
            //MenuModel obj = menucontext.GetAllMenuListWithId(ID);  //1

            MenuModel objcat = new Models.MenuModel(); // menumodel // ADDD 2
            objcat = menucontext.GetAllMenuListWithId(ID);
            DataSet ds = new DataSet();
            string s = "Select * from TBL_CATEGORY";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            // List<CategoryModel> catlist = new List<CategoryModel>(); // categorymodel
            List<CategoryModel> catlist = new List<CategoryModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CategoryModel cobj = new CategoryModel();

                cobj.CID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                cobj.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                catlist.Add(cobj);
            }
            objcat.Categories = catlist;
            con.Close();
            return View(objcat);//2
            //return View(obj);  //1
        }

        [HttpPost]
        public ActionResult EditMenu(HttpPostedFileBase postedFile, MenuModel obj)
        {
            try
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }
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
                cmd.Parameters.AddWithValue("@MenuImage", bytes);
                string fileName = Path.GetFileName(postedFile.FileName);
                string path = "Images/" + fileName;
                postedFile.SaveAs(Server.MapPath("~/Images/" + fileName));
                cmd.Parameters.AddWithValue("@ImagePath", path);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    con.Close();
                    ViewBag.msg = "Record Updated Successfully";
                }
                else
                {
                    ViewBag.msg = "Record Failed to Updated";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("GetItemDetails");
        }

        [HttpGet]
        public ActionResult DeleteMenu(int? ID)
        {
            MenuModel obj = menucontext.GetAllMenuListWithId11(ID);
            return View(obj);
        }
        [HttpPost]
        [ActionName("DeleteMenu")]
        public ActionResult DeleteMenuConfirmed(int? ID)
        {
            int i = menucontext.DeleteItem(ID);
            if (i > 0)
            {
                ViewBag.msg = "Deleted Successfully";
                return RedirectToAction("GetItemDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Delete Record";
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetEmpDetails()
        {
            return View(econtext.GetAllEmpList());
        }
        [HttpGet]
        public ActionResult AddEmpNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmpNew(EmployeeModel obj)
        {
            int i = econtext.InsertEmployee(obj);
            if (i > 0)
            {
                ViewBag.msg = "Employee Inserted Successfully";
            }
            else
            {
                ViewBag.msg = "Failed to Added Employee";
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmp(int? ID)
        {
            EmployeeModel obj = econtext.GetEmployeeListwithId(ID);
            return View(obj);
        }
        [HttpPost]
        public ActionResult EditEmp(EmployeeModel obj)
        {
            int i = econtext.UpdateEmployee(obj);
            if (i > 0)
            {
                ViewBag.msg = "Updated Successfully";
                return RedirectToAction("GetEmpDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Added Employee";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteEmp(int? ID)
        {
            EmployeeModel obj = econtext.GetEmployeeListwithId(ID);
            return View(obj);
        }
        [HttpPost]
        [ActionName("DeleteEmp")]
        public ActionResult DeleteEmpConfirmed(int? ID)
        {
            int i = econtext.DeleteEmployee(ID);
            if (i > 0)
            {
                ViewBag.msg = "Deleted Successfully";
                return RedirectToAction("GetEmpDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Delete Record";
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetUserDetails()
        {
            
            return View(ucontext.GetAllUserList());

        }

        [HttpGet]
        public ActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewUser(UserModel obj)
        {
            int i = ucontext.InsertUser(obj);
            if (i > 0)
            {
                ViewBag.msg = "User Inserted Successfully";
            }
            else
            {
                ViewBag.msg = "Failed to Added User";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edituser(int? ID)
        {
            UserModel obj = ucontext.GetUserDetailWithID(ID);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edituser(UserModel obj)
        {
            int i = ucontext.UpdateUser(obj);
            if (i > 0)
            {
                ViewBag.msg = "Updated Successfully";
                return RedirectToAction("GetUserDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Added Employee";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteUser(int? ID)
        {
            UserModel obj = ucontext.GetUserDetailWithID(ID);
            return View(obj);
        }
        [HttpPost]
        [ActionName("DeleteUser")]
        public ActionResult DeleteUserConfirmed(int? ID)
        {
            int i = ucontext.DeleteUser(ID);
            if (i > 0)
            {
                ViewBag.msg = "Deleted Successfully";
                return RedirectToAction("GetUserDetails");
            }
            else
            {
                ViewBag.msg = "Failed to Delete Record";
            }
            return View();
        }

    }
}