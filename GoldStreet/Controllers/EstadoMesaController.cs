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
    public class EstadoMesaController : Controller
    {
        private GoldStreetEntities db = new GoldStreetEntities();

        // GET: EstadoMesa
        public ActionResult Index()
        {
            return View(db.EstadoMesa.ToList());
        }

        // GET: EstadoMesa/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMesa estadoMesa = db.EstadoMesa.Find(id);
            if (estadoMesa == null)
            {
                return HttpNotFound();
            }
            return View(estadoMesa);
        }

        // GET: EstadoMesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoMesa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoMesaID,NombreEstado")] EstadoMesa estadoMesa)
        {
            if (ModelState.IsValid)
            {
                db.EstadoMesa.Add(estadoMesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoMesa);
        }

        // GET: EstadoMesa/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMesa estadoMesa = db.EstadoMesa.Find(id);
            if (estadoMesa == null)
            {
                return HttpNotFound();
            }
            return View(estadoMesa);
        }

        // POST: EstadoMesa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoMesaID,NombreEstado")] EstadoMesa estadoMesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoMesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoMesa);
        }

        // GET: EstadoMesa/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMesa estadoMesa = db.EstadoMesa.Find(id);
            if (estadoMesa == null)
            {
                return HttpNotFound();
            }
            return View(estadoMesa);
        }

        // POST: EstadoMesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            EstadoMesa estadoMesa = db.EstadoMesa.Find(id);
            db.EstadoMesa.Remove(estadoMesa);
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
