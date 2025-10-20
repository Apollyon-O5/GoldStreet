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
    public class HistorialEstadoMesaController : Controller
    {
        private GoldStreetEntities db = new GoldStreetEntities();

        // GET: HistorialEstadoMesa
        public ActionResult Index()
        {
            var historialEstadoMesa = db.HistorialEstadoMesa.Include(h => h.ClienteMesa).Include(h => h.EstadoMesa);
            return View(historialEstadoMesa.ToList());
        }

        // GET: HistorialEstadoMesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialEstadoMesa historialEstadoMesa = db.HistorialEstadoMesa.Find(id);
            if (historialEstadoMesa == null)
            {
                return HttpNotFound();
            }
            return View(historialEstadoMesa);
        }

        // GET: HistorialEstadoMesa/Create
        public ActionResult Create()
        {
            ViewBag.ClienteMesaID = new SelectList(db.ClienteMesa, "ClienteMesaID", "ClienteMesaID");
            ViewBag.EstadoMesaID = new SelectList(db.EstadoMesa, "EstadoMesaID", "NombreEstado");
            return View();
        }

        // POST: HistorialEstadoMesa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistorialEstadoMesaID,ClienteMesaID,EstadoMesaID")] HistorialEstadoMesa historialEstadoMesa)
        {
            if (ModelState.IsValid)
            {
                db.HistorialEstadoMesa.Add(historialEstadoMesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteMesaID = new SelectList(db.ClienteMesa, "ClienteMesaID", "ClienteMesaID", historialEstadoMesa.ClienteMesaID);
            ViewBag.EstadoMesaID = new SelectList(db.EstadoMesa, "EstadoMesaID", "NombreEstado", historialEstadoMesa.EstadoMesaID);
            return View(historialEstadoMesa);
        }

        // GET: HistorialEstadoMesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialEstadoMesa historialEstadoMesa = db.HistorialEstadoMesa.Find(id);
            if (historialEstadoMesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteMesaID = new SelectList(db.ClienteMesa, "ClienteMesaID", "ClienteMesaID", historialEstadoMesa.ClienteMesaID);
            ViewBag.EstadoMesaID = new SelectList(db.EstadoMesa, "EstadoMesaID", "NombreEstado", historialEstadoMesa.EstadoMesaID);
            return View(historialEstadoMesa);
        }

        // POST: HistorialEstadoMesa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistorialEstadoMesaID,ClienteMesaID,EstadoMesaID")] HistorialEstadoMesa historialEstadoMesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialEstadoMesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteMesaID = new SelectList(db.ClienteMesa, "ClienteMesaID", "ClienteMesaID", historialEstadoMesa.ClienteMesaID);
            ViewBag.EstadoMesaID = new SelectList(db.EstadoMesa, "EstadoMesaID", "NombreEstado", historialEstadoMesa.EstadoMesaID);
            return View(historialEstadoMesa);
        }

        // GET: HistorialEstadoMesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialEstadoMesa historialEstadoMesa = db.HistorialEstadoMesa.Find(id);
            if (historialEstadoMesa == null)
            {
                return HttpNotFound();
            }
            return View(historialEstadoMesa);
        }

        // POST: HistorialEstadoMesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialEstadoMesa historialEstadoMesa = db.HistorialEstadoMesa.Find(id);
            db.HistorialEstadoMesa.Remove(historialEstadoMesa);
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
