using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberRec.Models;

namespace MemberRec.Controllers
{
    public class FeeDatasController : Controller
    {
        private Model1 db = new Model1();

        // GET: FeeDatas
        public ActionResult Index()
        {
            return View(db.FeeDatas.ToList());
        }

        // GET: FeeDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeData feeData = db.FeeDatas.Find(id);
            if (feeData == null)
            {
                return HttpNotFound();
            }
            return View(feeData);
        }

        // GET: FeeDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeeDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeeDataId,Particular,Amount")] FeeData feeData)
        {
            if (ModelState.IsValid)
            {
                db.FeeDatas.Add(feeData);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(feeData);
        }

        // GET: FeeDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeData feeData = db.FeeDatas.Find(id);
            if (feeData == null)
            {
                return HttpNotFound();
            }
            return View(feeData);
        }

        // POST: FeeDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeeDataId,Particular,Amount")] FeeData feeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feeData);
        }

        // GET: FeeDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeData feeData = db.FeeDatas.Find(id);
            if (feeData == null)
            {
                return HttpNotFound();
            }
            return View(feeData);
        }

        // POST: FeeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeeData feeData = db.FeeDatas.Find(id);
            db.FeeDatas.Remove(feeData);
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
