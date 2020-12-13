using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ResturantProject.Models
{
    public class EmployeeModel
    {
        public int EID { get; set; }
        public string Ename { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public DateTime DateofJoining { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        //public byte[] Image { get; set; }
        //public string Imagepath { get; set; }

    }
    public class EmpContext
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Restaurent;Integrated Security=True");
        public List<EmployeeModel> GetAllEmpList()
        {
            List<EmployeeModel> emplist = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {

                EmployeeModel empobj = new Models.EmployeeModel();
                empobj.EID = Convert.ToInt32(rec[0]);
                empobj.Ename = Convert.ToString(rec[1]);
                empobj.Designation = Convert.ToString(rec[2]);
                empobj.Salary = Convert.ToDouble(rec[3]);
                empobj.DateofJoining = Convert.ToDateTime(rec[4]);
                empobj.Address = Convert.ToString(rec[5]);
                empobj.ContactNo = Convert.ToString(rec[6]);
                emplist.Add(empobj);
            }
            return emplist;
        }
        public int InsertEmployee(EmployeeModel obj)
        {
            SqlCommand cmd = new SqlCommand("INSERTREC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ENAME", obj.Ename);
            cmd.Parameters.AddWithValue("@DESIGNATION", obj.Designation);
            cmd.Parameters.AddWithValue("@SALARY", obj.Salary);
            cmd.Parameters.AddWithValue("@DATEOFJOINING", obj.DateofJoining);
            cmd.Parameters.AddWithValue("@ADDRESS", obj.Address);
            cmd.Parameters.AddWithValue("@CONTACTNO", obj.ContactNo);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public EmployeeModel GetEmployeeListwithId(int? id)
        {
            EmployeeModel obj = new EmployeeModel();
            SqlCommand cmd = new SqlCommand("GetEmpDetailswithId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EID", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow rec in dt.Rows)
            {
                obj.EID = Convert.ToInt32(rec[0]);
                obj.Ename = Convert.ToString(rec[1]);
                obj.Designation = Convert.ToString(rec[2]);
                obj.Salary = Convert.ToDouble(rec[3]);
                obj.DateofJoining = Convert.ToDateTime(rec[4]);
                obj.Address = Convert.ToString(rec[5]);
                obj.ContactNo = Convert.ToString(rec[6]);
            }
            return obj;
        }
        public int UpdateEmployee(EmployeeModel obj)
        {
            int i;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateRec", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ENAME", obj.Ename);
                cmd.Parameters.AddWithValue("@DESIGNATION", obj.Designation);
                cmd.Parameters.AddWithValue("@SALARY", obj.Salary);
                cmd.Parameters.AddWithValue("@DATEOFJOINING", obj.DateofJoining);
                cmd.Parameters.AddWithValue("@ADDRESS", obj.Address);
                cmd.Parameters.AddWithValue("@CONTACTNO", obj.ContactNo);
                cmd.Parameters.AddWithValue("@ID", obj.EID);
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
        public int DeleteEmployee(int? id)
        {
            SqlCommand cmd = new SqlCommand("SP_Deleteemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
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
}