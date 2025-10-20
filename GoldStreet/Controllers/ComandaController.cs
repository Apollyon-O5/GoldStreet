using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldStreet;

namespace GoldStreet.Controllers
{
    public class ComandaController : Controller
    {
        private GoldStreetEntities db = new GoldStreetEntities();

        // GET: Comanda
        public ActionResult Index()
        {
            var comanda = db.Comanda.Include(c => c.Cuentas).Include(c => c.Empleados).Include(c => c.Menu);
            return View(comanda.ToList());
        }

        // GET: Comanda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // GET: Comanda/Create
        public ActionResult Create()
        {
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID");
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "Nombre");
            ViewBag.MenuID = new SelectList(db.Menu, "MenuID", "Nombre");
            return View();
        }

        // POST: Comanda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComandaID,CuentaID,MenuID,EmpleadoID,Cantidad")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Comanda.Add(comanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", comanda.CuentaID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "Nombre", comanda.EmpleadoID);
            ViewBag.MenuID = new SelectList(db.Menu, "MenuID", "Nombre", comanda.MenuID);
            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", comanda.CuentaID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "Nombre", comanda.EmpleadoID);
            ViewBag.MenuID = new SelectList(db.Menu, "MenuID", "Nombre", comanda.MenuID);
            return View(comanda);
        }

        // POST: Comanda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComandaID,CuentaID,MenuID,EmpleadoID,Cantidad")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", comanda.CuentaID);
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "Nombre", comanda.EmpleadoID);
            ViewBag.MenuID = new SelectList(db.Menu, "MenuID", "Nombre", comanda.MenuID);
            return View(comanda);
        }

        // GET: Comanda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comanda comanda = db.Comanda.Find(id);
            db.Comanda.Remove(comanda);
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
