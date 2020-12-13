using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResturantProject.Models;

namespace ResturantProject.Controllers
{
    public class TBL_ITEMLISTController : Controller
    {
        private ResturantProjectEntities db = new ResturantProjectEntities();

        // GET: TBL_ITEMLIST
        public ActionResult Index()
        {
            return View(db.TBL_ITEMLIST.ToList());
        }

        public ActionResult OrderFood()
        {
            
            return View(db.TBL_ITEMLIST.ToList());
        }

        // GET: TBL_ITEMLIST/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ITEMLIST tBL_ITEMLIST = db.TBL_ITEMLIST.Find(id);
            if (tBL_ITEMLIST == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ITEMLIST);
        }

        // GET: TBL_ITEMLIST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_ITEMLIST/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CATEID,ITEMNAME,DESCRIPTION,PRICE,TYPE,ENABLED,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ImagePath")] TBL_ITEMLIST tBL_ITEMLIST)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ITEMLIST.Add(tBL_ITEMLIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_ITEMLIST);
        }

        // GET: TBL_ITEMLIST/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ITEMLIST tBL_ITEMLIST = db.TBL_ITEMLIST.Find(id);
            if (tBL_ITEMLIST == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ITEMLIST);
        }

        // POST: TBL_ITEMLIST/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CATEID,ITEMNAME,DESCRIPTION,PRICE,TYPE,ENABLED,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ImagePath")] TBL_ITEMLIST tBL_ITEMLIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ITEMLIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_ITEMLIST);
        }

        // GET: TBL_ITEMLIST/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ITEMLIST tBL_ITEMLIST = db.TBL_ITEMLIST.Find(id);
            if (tBL_ITEMLIST == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ITEMLIST);
        }

        // POST: TBL_ITEMLIST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ITEMLIST tBL_ITEMLIST = db.TBL_ITEMLIST.Find(id);
            db.TBL_ITEMLIST.Remove(tBL_ITEMLIST);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
