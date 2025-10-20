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
    public class ClienteMesaController : Controller
    {
        private GoldStreetEntities db = new GoldStreetEntities();

        // GET: ClienteMesa
        public ActionResult Index()
        {
            var clienteMesa = db.ClienteMesa.Include(c => c.Cuentas).Include(c => c.Mesas).Include(c => c.Reservacion);
            return View(clienteMesa.ToList());
        }

        // GET: ClienteMesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMesa clienteMesa = db.ClienteMesa.Find(id);
            if (clienteMesa == null)
            {
                return HttpNotFound();
            }
            return View(clienteMesa);
        }

        // GET: ClienteMesa/Create
        public ActionResult Create()
        {
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID");
            ViewBag.MesaID = new SelectList(db.Mesas, "MesaID", "MesaID");
            ViewBag.ReservacionID = new SelectList(db.Reservacion, "ReservacionID", "ReservacionID");
            return View();
        }

        // POST: ClienteMesa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteMesaID,MesaID,CuentaID,ReservacionID")] ClienteMesa clienteMesa)
        {
            if (ModelState.IsValid)
            {
                db.ClienteMesa.Add(clienteMesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", clienteMesa.CuentaID);
            ViewBag.MesaID = new SelectList(db.Mesas, "MesaID", "MesaID", clienteMesa.MesaID);
            ViewBag.ReservacionID = new SelectList(db.Reservacion, "ReservacionID", "ReservacionID", clienteMesa.ReservacionID);
            return View(clienteMesa);
        }

        // GET: ClienteMesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMesa clienteMesa = db.ClienteMesa.Find(id);
            if (clienteMesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", clienteMesa.CuentaID);
            ViewBag.MesaID = new SelectList(db.Mesas, "MesaID", "MesaID", clienteMesa.MesaID);
            ViewBag.ReservacionID = new SelectList(db.Reservacion, "ReservacionID", "ReservacionID", clienteMesa.ReservacionID);
            return View(clienteMesa);
        }

        // POST: ClienteMesa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteMesaID,MesaID,CuentaID,ReservacionID")] ClienteMesa clienteMesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteMesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaID = new SelectList(db.Cuentas, "CuentaID", "CuentaID", clienteMesa.CuentaID);
            ViewBag.MesaID = new SelectList(db.Mesas, "MesaID", "MesaID", clienteMesa.MesaID);
            ViewBag.ReservacionID = new SelectList(db.Reservacion, "ReservacionID", "ReservacionID", clienteMesa.ReservacionID);
            return View(clienteMesa);
        }

        // GET: ClienteMesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMesa clienteMesa = db.ClienteMesa.Find(id);
            if (clienteMesa == null)
            {
                return HttpNotFound();
            }
            return View(clienteMesa);
        }

        // POST: ClienteMesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteMesa clienteMesa = db.ClienteMesa.Find(id);
            db.ClienteMesa.Remove(clienteMesa);
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
