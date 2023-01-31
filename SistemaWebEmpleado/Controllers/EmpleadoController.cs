using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly DBEmpleados context;

        public EmpleadoController(DBEmpleados context)
        {
            this.context = context;
        }

        //GET /Opera
        //GET /Opera/index
        [HttpGet]
        public IActionResult Index()
        {
            //lista de operas
            var empleados = context.Empleados.ToList();

            //Envia las operas a la vista
            return View(empleados);
        }

        //Get opera/create
        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);//Devuelve el hmlt(View) al cliente
        }

        //Post opera/create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        //Get opera/delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", empleado);//Devuelve el hmlt(View) al cliente
            }
        }

        //Post opera/delete/1
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Get opera/Details/4
        [HttpGet]
        public ActionResult Details(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {

                return View("Detalle", empleado);
            }
        }

        [HttpGet("{titulo}")]
        public ActionResult<Empleado> GetByTitulo(string titulo)
        {

            List<Empleado> empleados = (from e in context.Empleados
                                 where e.Título == titulo
                                 select e).ToList();
            return View("GetByTitulo", empleados);
        }

        private Empleado TraerUno(int id)
        {
            return context.Empleados.Find(id);
        }
    }

}
