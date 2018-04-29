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
    public class PRODUCTOSController : Controller
    {
        private BdAppDonTomateEntities db = new BdAppDonTomateEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            var listaProductos = db.PRODUCTOS.ToList();
            return View(listaProductos); 
           
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS listaProductos = db.PRODUCTOS.Find(id);
            
            if (listaProductos == null)
            {
                return HttpNotFound();
            }
            return View(listaProductos);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            var listaProductos = db.PRODUCTOS.Select(p=> p.IDPRODUCTO).ToList().Max();
            String ultimoId = listaProductos.ToString().Substring(4);
            int x = int.Parse(ultimoId);
            x += 1;
            if(x.ToString().Length == 1)
            {
                listaProductos = "PROD" + x.ToString().PadLeft(3,'0');
            }else if (x.ToString().Length == 2)
            {
                listaProductos = "PROD" + x.ToString().PadLeft(3,'0').PadLeft(3,'0');
            }
            else
            {
                listaProductos = "PROD" + x.ToString();
            }
            ViewBag.ultimoID = listaProductos;
            return View();
        }

        // POST: PRODUCTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPRODUCTO,NOMBRE,DESCRIPCION")] PRODUCTOS producto)
        {

            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS producto = db.PRODUCTOS.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: PRODUCTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPRODUCTO,NOMBRE,DESCRIPCION")] PRODUCTOS producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS producto = db.PRODUCTOS.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCTOS producto = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(producto);
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
