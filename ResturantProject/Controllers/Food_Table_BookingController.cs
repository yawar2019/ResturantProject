using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResturantProject.Models;
using System.Data;

namespace ResturantProject.Controllers
{
    public class Food_Table_BookingController : Controller
    {
        private ResturantProjectEntities db = new ResturantProjectEntities();
        List<TBL_ITEMLIST> itemList = new List<TBL_ITEMLIST>();
        List<string> chairIdList = new List<string>();
        List<TBL_ITEMLIST> itemDetailsList = new List<TBL_ITEMLIST>();


        // GET: Food_Table_Booking
        public ActionResult Food_Table_Booking()
        {
            Session["TotalItemList"] = db.TBL_ITEMLIST.ToList();
            //return View(db.TBL_ITEMLIST.ToList());
            return RedirectToAction("GetStarters");
        }

        public ActionResult GetStarters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CATEID", typeof(int));
            dt.Columns.Add("ITEMNAME", typeof(string));
            dt.Columns.Add("DESCRIPTION", typeof(string));
            dt.Columns.Add("PRICE", typeof(double));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("ENABLED", typeof(bool));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            dt.Columns.Add("UpdatedBy", typeof(int));
            dt.Columns.Add("UpdatedDate", typeof(DateTime));
            dt.Columns.Add("ImagePath", typeof(string));

            var result = db.spGetStarters();

            foreach (TBL_ITEMLIST item in result)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.ID;
                dr["CATEID"] = item.CATEID;
                dr["ITEMNAME"] = item.ITEMNAME;
                dr["DESCRIPTION"] = item.DESCRIPTION;
                dr["PRICE"] = item.PRICE;
                dr["TYPE"] = item.TYPE;
                dr["ENABLED"] = item.ENABLED;
                dr["CreatedBy"] = item.CreatedBy;
                dr["CreatedDate"] = item.CreatedDate;
                dr["UpdatedBy"] = item.UpdatedBy;
                dr["UpdatedDate"] = item.UpdatedDate;
                dr["ImagePath"] = item.ImagePath;
                dt.Rows.Add(dr);
                //string imagePath = item.ImagePath;
            }

            foreach (DataRow dr in dt.Rows)
            {
                TBL_ITEMLIST item = new TBL_ITEMLIST();
                item.ID = Convert.ToInt32(dr[0]);
                item.CATEID = Convert.ToInt32(dr[1]);
                item.ITEMNAME = Convert.ToString(dr[2]);
                item.DESCRIPTION = Convert.ToString(dr[3]);
                item.PRICE = Convert.ToDouble(dr[4]);
                item.TYPE = Convert.ToString(dr[5]);
                item.ENABLED = Convert.ToBoolean(dr[6]);
                item.CreatedBy = Convert.ToInt32(dr[7]);
                item.CreatedDate = Convert.ToDateTime(dr[8]);
                item.UpdatedBy = Convert.ToInt32(dr[9]);
                item.UpdatedDate = Convert.ToDateTime(dr[10]);
                item.ImagePath = Convert.ToString(dr[11]);
                itemList.Add(item);

            }
            Session["itemList"] = itemList;
            return View("Food_Table_Booking", itemList);
        }

        public ActionResult GetMainCourse()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CATEID", typeof(int));
            dt.Columns.Add("ITEMNAME", typeof(string));
            dt.Columns.Add("DESCRIPTION", typeof(string));
            dt.Columns.Add("PRICE", typeof(double));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("ENABLED", typeof(bool));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            dt.Columns.Add("UpdatedBy", typeof(int));
            dt.Columns.Add("UpdatedDate", typeof(DateTime));
            dt.Columns.Add("ImagePath", typeof(string));

            var result = db.spGetMainCourse();

            foreach (TBL_ITEMLIST item in result)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.ID;
                dr["CATEID"] = item.CATEID;
                dr["ITEMNAME"] = item.ITEMNAME;
                dr["DESCRIPTION"] = item.DESCRIPTION;
                dr["PRICE"] = item.PRICE;
                dr["TYPE"] = item.TYPE;
                dr["ENABLED"] = item.ENABLED;
                dr["CreatedBy"] = item.CreatedBy;
                dr["CreatedDate"] = item.CreatedDate;
                dr["UpdatedBy"] = item.UpdatedBy;
                dr["UpdatedDate"] = item.UpdatedDate;
                dr["ImagePath"] = item.ImagePath;
                dt.Rows.Add(dr);
                //string imagePath = item.ImagePath;
            }

            foreach (DataRow dr in dt.Rows)
            {
                TBL_ITEMLIST item = new TBL_ITEMLIST();
                item.ID = Convert.ToInt32(dr[0]);
                item.CATEID = Convert.ToInt32(dr[1]);
                item.ITEMNAME = Convert.ToString(dr[2]);
                item.DESCRIPTION = Convert.ToString(dr[3]);
                item.PRICE = Convert.ToDouble(dr[4]);
                item.TYPE = Convert.ToString(dr[5]);
                item.ENABLED = Convert.ToBoolean(dr[6]);
                item.CreatedBy = Convert.ToInt32(dr[7]);
                item.CreatedDate = Convert.ToDateTime(dr[8]);
                item.UpdatedBy = Convert.ToInt32(dr[9]);
                item.UpdatedDate = Convert.ToDateTime(dr[10]);
                item.ImagePath = Convert.ToString(dr[11]);
                itemList.Add(item);

            }
            Session["itemList"] = itemList;
            return View("Food_Table_Booking", itemList);
            
        }

        public ActionResult GetDesserts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CATEID", typeof(int));
            dt.Columns.Add("ITEMNAME", typeof(string));
            dt.Columns.Add("DESCRIPTION", typeof(string));
            dt.Columns.Add("PRICE", typeof(double));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("ENABLED", typeof(bool));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            dt.Columns.Add("UpdatedBy", typeof(int));
            dt.Columns.Add("UpdatedDate", typeof(DateTime));
            dt.Columns.Add("ImagePath", typeof(string));

            var result = db.spGetDesserts();

            foreach (TBL_ITEMLIST item in result)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.ID;
                dr["CATEID"] = item.CATEID;
                dr["ITEMNAME"] = item.ITEMNAME;
                dr["DESCRIPTION"] = item.DESCRIPTION;
                dr["PRICE"] = item.PRICE;
                dr["TYPE"] = item.TYPE;
                dr["ENABLED"] = item.ENABLED;
                dr["CreatedBy"] = item.CreatedBy;
                dr["CreatedDate"] = item.CreatedDate;
                dr["UpdatedBy"] = item.UpdatedBy;
                dr["UpdatedDate"] = item.UpdatedDate;
                dr["ImagePath"] = item.ImagePath;
                dt.Rows.Add(dr);
                //string imagePath = item.ImagePath;
            }

            foreach (DataRow dr in dt.Rows)
            {
                TBL_ITEMLIST item = new TBL_ITEMLIST();
                item.ID = Convert.ToInt32(dr[0]);
                item.CATEID = Convert.ToInt32(dr[1]);
                item.ITEMNAME = Convert.ToString(dr[2]);
                item.DESCRIPTION = Convert.ToString(dr[3]);
                item.PRICE = Convert.ToDouble(dr[4]);
                item.TYPE = Convert.ToString(dr[5]);
                item.ENABLED = Convert.ToBoolean(dr[6]);
                item.CreatedBy = Convert.ToInt32(dr[7]);
                item.CreatedDate = Convert.ToDateTime(dr[8]);
                item.UpdatedBy = Convert.ToInt32(dr[9]);
                item.UpdatedDate = Convert.ToDateTime(dr[10]);
                item.ImagePath = Convert.ToString(dr[11]);
                itemList.Add(item);

            }
            Session["itemList"] = itemList;
            return View("Food_Table_Booking", itemList);
            
        }

        public ActionResult AddItem(string itemName, double? price, string act, int? qty)
        {
            double? totalPrice = 0;
            int count = 0;
            if (Session["totalPrice"] != null)
            {
                totalPrice = (double)Session["totalPrice"];
            }

            if (Session["itemDetailsList"] != null)
            {
                foreach (var item in (List<TBL_ITEMLIST>)Session["itemDetailsList"])
                {
                    itemDetailsList.Add(item);
                }
            }

            if(itemDetailsList.Count > 0)
            {
                foreach (var item in itemDetailsList.ToList())
                {
                   if(item.ITEMNAME == itemName)
                    {
                        count = 1;
                        if (act == "Add")
                        {
                            item.PRICE = item.PRICE + price;
                            totalPrice = totalPrice + price;

                        }
                        else if(act == "Remove")
                        {
                           
                            if(qty == 1)
                            {
                                itemDetailsList.Remove(item);
                                totalPrice = totalPrice - price;
                            }
                            else
                            {
                                item.PRICE = item.PRICE - price;
                                totalPrice = totalPrice - price;
                            }

                        }
                        //else if(act == "Remove Item")
                        //{
                        //    itemDetailsList.Remove(item);
                        //    totalPrice = totalPrice - price;
                        //}
                        else
                        {
                            
                        }
                    }
                }
            }
            if (count == 0)
            {
                TBL_ITEMLIST itemObj = new TBL_ITEMLIST();
                itemObj.ITEMNAME = itemName;
                itemObj.PRICE = price;
                itemDetailsList.Add(itemObj);
                totalPrice = totalPrice + price;
            }

            Session["totalPrice"] = totalPrice;
            if (itemDetailsList.Count == 0)
            {
                Session["itemDetailsList"] = null;
            }
            else {
                Session["itemDetailsList"] = itemDetailsList;
            }

            itemList = (List<TBL_ITEMLIST>)Session["itemList"];
            return View("Food_Table_Booking", itemList);

        }

        public ActionResult AddChair(string id, string act)
        {
            if (act == "Remove")
            {
                Session["chairIdList"] = null;
            }
            else
            {
                int i = 0;
                if (Session["chairIdList"] != null)
                {
                    foreach (var item in (List<string>)Session["chairIdList"])
                    {
                        chairIdList.Add(item);
                    }

                }
                if (chairIdList.Count > 0)
                {
                    foreach (var item in chairIdList)
                    {
                        if (id == item)
                        {
                            ViewBag.message = string.Format("You have already selected {0} chair", id);
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }

                }
                if (i == chairIdList.Count)
                {
                    chairIdList.Add(id);
                }
                Session["chairIdList"] = chairIdList;
            }

            itemList = (List<TBL_ITEMLIST>)Session["itemList"];
            return View("Food_Table_Booking", itemList);
        }

    }
}
