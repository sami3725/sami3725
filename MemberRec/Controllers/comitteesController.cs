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
    public class comitteesController : Controller
    {
        private Model1 db = new Model1();

        // GET: comittees
        public ActionResult Index()
        {
            return View(db.comittees.ToList());
        }

        // GET: comittees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comittee comittee = db.comittees.Find(id);
            if (comittee == null)
            {
                return HttpNotFound();
            }
            return View(comittee);
        }

        // GET: comittees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: comittees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComitteeId,ComitteeName")] comittee comittee)
        {
            if (ModelState.IsValid)
            {
                db.comittees.Add(comittee);
                db.SaveChanges();
                return RedirectToAction("Create","members");
            }

            return View(comittee);
        }

        // GET: comittees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comittee comittee = db.comittees.Find(id);
            if (comittee == null)
            {
                return HttpNotFound();
            }
            return View(comittee);
        }

        // POST: comittees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComitteeId,ComitteeName")] comittee comittee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comittee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comittee);
        }

        // GET: comittees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comittee comittee = db.comittees.Find(id);
            if (comittee == null)
            {
                return HttpNotFound();
            }
            return View(comittee);
        }

        // POST: comittees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comittee comittee = db.comittees.Find(id);
            db.comittees.Remove(comittee);
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
