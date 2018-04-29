using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDDontomate;

namespace BDDontomate.Controllers
{
    public class PERFILESController : Controller
    {
        private BdAppDonTomateEntities db = new BdAppDonTomateEntities();

        // GET: PERFILES
        public ActionResult Index()
        {
            return View(db.PERFILES.ToList());
        }

        // GET: PERFILES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILES perfiles = db.PERFILES.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // GET: PERFILES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERFILES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPERFIL,NOMBRE,DESCRIPCION")] PERFILES perfiles)
        {
            if (ModelState.IsValid)
            {
                db.PERFILES.Add(perfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfiles);
        }

        // GET: PERFILES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILES perfiles = db.PERFILES.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: PERFILES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPERFIL,NOMBRE,DESCRIPCION")] PERFILES perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfiles);
        }

        // GET: PERFILES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILES perfiles = db.PERFILES.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: PERFILES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERFILES perfiles = db.PERFILES.Find(id);
            db.PERFILES.Remove(perfiles);
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
