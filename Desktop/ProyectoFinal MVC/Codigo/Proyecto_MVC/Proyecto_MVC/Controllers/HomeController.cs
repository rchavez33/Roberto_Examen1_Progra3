using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenido!";

            return View();
        }

        public ActionResult Usuarios()
        {
            ViewBag.Message = "Portal de Usuarios.";

            return View();
        }

        public ActionResult Estudiantes()
        {
            ViewBag.Message = "Portal de Estudiantes";

            return View();
        }
    }
}