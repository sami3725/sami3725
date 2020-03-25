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
    public class FeeDetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: FeeDetails
        public ActionResult Index()
        {
            var feeDetails = db.FeeDetails.Include(f => f.member);
            return View(feeDetails.ToList());
        }

        // GET: FeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeDetail feeDetail = db.FeeDetails.Find(id);
            if (feeDetail == null)
            {
                return HttpNotFound();
            }
            return View(feeDetail);
        }

        // GET: FeeDetails/Create
        public ActionResult Create(int? id)
        {
            var FeeDetails = db.FeeDetails.Where(x => x.MemberId == id);
        
            ViewBag.MemberId = new SelectList(db.members, "MemberId", "MemberNo");
            ViewBag.FeeDataId = new SelectList(db.FeeDatas, "FeeDataId", "Particular");
            return View();
        }

        // POST: FeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeeDetailId,Date,Particular,Amount,MemberId")] FeeDetail feeDetail)
        {
            if (ModelState.IsValid)
            {
                db.FeeDetails.Add(feeDetail);
                db.SaveChanges();
                return RedirectToAction("Create","members");
            }

            ViewBag.MemberId = new SelectList(db.members, "MemberId", "MemberNo", feeDetail.MemberId);
      
            return View(feeDetail);
        }

        // GET: FeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeDetail feeDetail = db.FeeDetails.Find(id);
            if (feeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.members, "MemberId", "MemberNo", feeDetail.MemberId);
            return View(feeDetail);
        }

        // POST: FeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeeDetailId,Date,Particular,Amount,MemberId")] FeeDetail feeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.members, "MemberId", "MemberNo", feeDetail.MemberId);
            return View(feeDetail);
        }

        // GET: FeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeDetail feeDetail = db.FeeDetails.Find(id);
            if (feeDetail == null)
            {
                return HttpNotFound();
            }
            return View(feeDetail);
        }

        // POST: FeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeeDetail feeDetail = db.FeeDetails.Find(id);
            db.FeeDetails.Remove(feeDetail);
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
