using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Bienvenidos al sector de emplados";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
