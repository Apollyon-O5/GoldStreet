using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Primer cambio 👻

namespace GoldStreet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Somos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
     
        }


        //parte sujeta a optimizaciones
        private GoldStreetEntities db = new GoldStreetEntities(); // tu contexto de base de datos

        // Acción para mostrar la carta
        public ActionResult Carta()
        {
            var menu = db.Menu.Include("Categorias").ToList(); // Obtiene todos los platillos de la tabla Menu, se puso .Include("Categorias")
            return View(menu);           // Envía la lista a la vista
        }


    }
}