using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemberRec.Models;
using System.IO;

namespace MemberRec.Controllers
{
    public class membersController : Controller
    {
        private Model1 db = new Model1();

        // GET: members
        public ActionResult Index()
        {
            var members = db.members.Include(m => m.BusinessType).Include(m => m.Comittee).Include(m => m.Post).Include(m=>m.SubBranch);          
            return View(members.ToList());
        }


        // GET: members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: members/Create
        public ActionResult Create( int? id)
        {
            ViewBag.BusinessTypeId = new SelectList(db.BusinessTypes, "BusinessTypeId", "BusinessTypeName");
            ViewBag.ComitteeId = new SelectList(db.comittees, "ComitteeId", "ComitteeName");
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName");
            ViewBag.SubBranchId = new SelectList(db.SubBranches, "SubBranchId", "SubBranchName");

           
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,MemberNo,Name,Address,PhoneNo,PanNo,RegistrationDate,ComitteeId,PostId,BusinessTypeId,SubBranchId")] member member,HttpPostedFileBase Image)
        {
            

            ViewBag.BusinessTypeId = new SelectList(db.BusinessTypes, "BusinessTypeId", "BusinessTypeName", member.BusinessTypeId);
            ViewBag.ComitteeId = new SelectList(db.comittees, "ComitteeId", "ComitteeName", member.ComitteeId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", member.PostId);
            ViewBag.SubBranchId = new SelectList(db.SubBranches, "SubBranchId", "SubBranchName", member.SubBranchId);

            if (ModelState.IsValid)
            {
                var tempimg = Image;
                var file = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("/Images"), file);
                tempimg.SaveAs(path);
                member.image = "/Images/" + file;
                db.members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

           

            return View(member);
        }

        // GET: members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessTypeId = new SelectList(db.BusinessTypes, "BusinessTypeId", "BusinessTypeName", member.BusinessTypeId);
            ViewBag.ComitteeId = new SelectList(db.comittees, "ComitteeId", "ComitteeName", member.ComitteeId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", member.PostId);
            ViewBag.SubBranchId = new SelectList(db.SubBranches, "SubBranchId", "SubBranchName", member.SubBranchId);
            return View(member);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,MemberNo,Name,Address,PhoneNo,PanNo,RegistrationDate,ComitteeId,PostId,BusinessTypeId,SubBranchId")] member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessTypeId = new SelectList(db.BusinessTypes, "BusinessTypeId", "BusinessTypeName", member.BusinessTypeId);
            ViewBag.ComitteeId = new SelectList(db.comittees, "ComitteeId", "ComitteeName", member.ComitteeId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostName", member.PostId);
            ViewBag.SubBranchId = new SelectList(db.SubBranches, "SubBranchtId", "SubBranchName", member.SubBranchId);
            return View(member);
        }

        // GET: members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member member = db.members.Find(id);
            db.members.Remove(member);
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

        public ActionResult Modal()
        {
            return View();
        }

        public ActionResult Index1(int? id)
        {
            var members = db.members.Where(x => x.ComitteeId == id).Include(m => m.BusinessType).Include(m => m.Comittee).Include(m => m.Post);
            return View(members.ToList());
        }

        public ActionResult fetchfeedata(int feedataid)
        {
            var feedata = db.FeeDatas.Find(feedataid);
            return Json(new
            {
                amount = feedata.Amount,
            }, behavior: JsonRequestBehavior.AllowGet);
        }

        public ActionResult checkbox(int? checkboxvalue)
        {
            string result = "sorry!!";

            if (ModelState.IsValid)
            {
                member meb = new member();
                meb = db.members.Find(checkboxvalue);
                meb.Suspend = true;
                db.Entry(meb).State = EntityState.Modified;
                db.SaveChanges();

                result = "Sucess!!";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
    }
}
