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
    public class MenuController : Controller
    {
        private GoldStreetEntities db = new GoldStreetEntities();

        // GET: Menu
        public ActionResult Index()
        {
            var menu = db.Menu.Include(m => m.Categorias);
            return View(menu.ToList());
        }

        // GET: Menu/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria");
            return View();
        }

        // POST: Menu/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,CategoriaID,Nombre,Precio,Descripcion")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", menu.CategoriaID);
            return View(menu);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", menu.CategoriaID);
            return View(menu);
        }

        // POST: Menu/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,CategoriaID,Nombre,Precio,Descripcion")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NombreCategoria", menu.CategoriaID);
            return View(menu);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Menu menu = db.Menu.Find(id);
            db.Menu.Remove(menu);
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
