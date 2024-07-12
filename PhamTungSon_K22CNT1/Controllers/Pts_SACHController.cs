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
    public class Pts_SACHController : Controller
    {
        private PhamTungSonEntities1 db = new PhamTungSonEntities1();

        // GET: Pts_SACH
        public ActionResult PtsIndex()
        {
            var pts_SACH = db.Pts_SACH.Include(p => p.Pts_TACGIA);
            return View(pts_SACH.ToList());
        }

        // GET: Pts_SACH/Details/5
        public ActionResult PtsDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_SACH pts_SACH = db.Pts_SACH.Find(id);
            if (pts_SACH == null)
            {
                return HttpNotFound();
            }
            return View(pts_SACH);
        }

        // GET: Pts_SACH/Create
        public ActionResult PtsCreate()
        {
            ViewBag.Pts_MaTG = new SelectList(db.Pts_TACGIA, "Pts_MaTG", "Pts_TenTacGia");
            return View();
        }

        // POST: Pts_SACH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PtsCreate([Bind(Include = "Pts_MaSach,Pts_TenSach,Pts_SoTrang,Pts_NamXB,Pts_MaTG,Pts_TrangThai")] Pts_SACH pts_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Pts_SACH.Add(pts_SACH);
                db.SaveChanges();
                return RedirectToAction("PtsIndex");
            }

            ViewBag.Pts_MaTG = new SelectList(db.Pts_TACGIA, "Pts_MaTG", "Pts_TenTacGia", pts_SACH.Pts_MaTG);
            return View(pts_SACH);
        }

        // GET: Pts_SACH/Edit/5
        public ActionResult PtsEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_SACH pts_SACH = db.Pts_SACH.Find(id);
            if (pts_SACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pts_MaTG = new SelectList(db.Pts_TACGIA, "Pts_MaTG", "Pts_TenTacGia", pts_SACH.Pts_MaTG);
            return View(pts_SACH);
        }

        // POST: Pts_SACH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PtsEdit([Bind(Include = "Pts_MaSach,Pts_TenSach,Pts_SoTrang,Pts_NamXB,Pts_MaTG,Pts_TrangThai")] Pts_SACH pts_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pts_SACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PtsIndex");
            }
            ViewBag.Pts_MaTG = new SelectList(db.Pts_TACGIA, "Pts_MaTG", "Pts_TenTacGia", pts_SACH.Pts_MaTG);
            return View(pts_SACH);
        }

        // GET: Pts_SACH/Delete/5
        public ActionResult PtsDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pts_SACH pts_SACH = db.Pts_SACH.Find(id);
            if (pts_SACH == null)
            {
                return HttpNotFound();
            }
            return View(pts_SACH);
        }

        // POST: Pts_SACH/Delete/5
        [HttpPost, ActionName("PtsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PtsDeleteConfirmed(string id)
        {
            Pts_SACH pts_SACH = db.Pts_SACH.Find(id);
            db.Pts_SACH.Remove(pts_SACH);
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
