using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TusAutos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Autos()
        {
            ViewBag.Message = "Listado de Autos";

            return View();
        }

        public ActionResult Auto()
        {
            ViewBag.Message = "Vista de Auto";

            return View();
        }

        public ActionResult Promotores()
        {
            ViewBag.Message = "Promotores de nuestro Sitio.";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}