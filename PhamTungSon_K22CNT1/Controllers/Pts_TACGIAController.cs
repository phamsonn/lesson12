using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhamTungSon_K22CNT1.Models;

namespace PhamTungSon_K22CNT1.Controllers
{
    public class Pts_TACGIAController : Controller
    {
        private PhamTungSonEntities1 db = new PhamTungSonEntities1();

        // GET: Pts_TACGIA
        public ActionResult PtsIndex()
        {
            return View(db.Pts_TACGIA.ToList());
        }

        // GET: Pts_TACGIA/Details/5
        public ActionResult PtsDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_TACGIA pts_TACGIA = db.Pts_TACGIA.Find(id);
            if (pts_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(pts_TACGIA);
        }

        // GET: Pts_TACGIA/Create
        public ActionResult PtsCreate()
        {
            return View();
        }

        // POST: Pts_TACGIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PtsCreate([Bind(Include = "Pts_MaTG,Pts_TenTacGia")] Pts_TACGIA pts_TACGIA)
        {
            if (ModelState.IsValid)
            {
                db.Pts_TACGIA.Add(pts_TACGIA);
                db.SaveChanges();
                return RedirectToAction("PtsIndex");
            }

            return View(pts_TACGIA);
        }

        // GET: Pts_TACGIA/Edit/5
        public ActionResult PtsEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_TACGIA pts_TACGIA = db.Pts_TACGIA.Find(id);
            if (pts_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(pts_TACGIA);
        }

        // POST: Pts_TACGIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PtsEdit([Bind(Include = "Pts_MaTG,Pts_TenTacGia")] Pts_TACGIA pts_TACGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pts_TACGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PtsIndex");
            }
            return View(pts_TACGIA);
        }

        // GET: Pts_TACGIA/Delete/5
        public ActionResult PtsDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_TACGIA pts_TACGIA = db.Pts_TACGIA.Find(id);
            if (pts_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(pts_TACGIA);
        }

        // POST: Pts_TACGIA/Delete/5
        [HttpPost, ActionName("PtsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PtsDeleteConfirmed(string id)
        {
            Pts_TACGIA pts_TACGIA = db.Pts_TACGIA.Find(id);
            db.Pts_TACGIA.Remove(pts_TACGIA);
            db.SaveChanges();
            return RedirectToAction("PtsIndex");
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
