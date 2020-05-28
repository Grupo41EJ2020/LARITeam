using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Models;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositorioEmpleados repoEmpleado = new RepositorioEmpleados(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado datosEmpleado )
        {

            repoEmpleado.insertarEmpleado(datosEmpleado); 
            return RedirectToAction("ConsultarTodo");
            ////return RedirectToAction("Index");
        }

        public ActionResult ConsultarTodo()
        {
            
            return View(repoEmpleado.obtenerEmpleado());
        }

        public ActionResult ConsultarPorID(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        public ActionResult Delete(int id) 
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection frm)
        {
            repoEmpleado.eliminarEmpleado(id);
            return RedirectToAction("ConsultarTodo");
        }


        public ActionResult Edit(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Empleado datos)
        {
            datos.IdEmpleado = id; 
            repoEmpleado.actualizarEmpleado(datos); 
            return RedirectToAction("ConsultarTodo");

        }

    }
}
