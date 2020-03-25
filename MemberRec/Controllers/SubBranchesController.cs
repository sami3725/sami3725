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
    public class SubBranchesController : Controller
    {
        private Model1 db = new Model1();

        // GET: SubBranches
        public ActionResult Index()
        {
            return View(db.SubBranches.ToList());
        }

        // GET: SubBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubBranch subBranch = db.SubBranches.Find(id);
            if (subBranch == null)
            {
                return HttpNotFound();
            }
            return View(subBranch);
        }

        // GET: SubBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubBranchId,SubBranchName")] SubBranch subBranch)
        {
            if (ModelState.IsValid)
            {
                db.SubBranches.Add(subBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subBranch);
        }

        // GET: SubBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubBranch subBranch = db.SubBranches.Find(id);
            if (subBranch == null)
            {
                return HttpNotFound();
            }
            return View(subBranch);
        }

        // POST: SubBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubBranchId,SubBranchName")] SubBranch subBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subBranch);
        }

        // GET: SubBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubBranch subBranch = db.SubBranches.Find(id);
            if (subBranch == null)
            {
                return HttpNotFound();
            }
            return View(subBranch);
        }

        // POST: SubBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubBranch subBranch = db.SubBranches.Find(id);
            db.SubBranches.Remove(subBranch);
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
