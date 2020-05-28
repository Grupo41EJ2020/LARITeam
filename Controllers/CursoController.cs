using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class CursoController : Controller
    {
        RepositorioCurso repoCurso = new RepositorioCurso();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DatosCurso()
        {
            return View(repoCurso.obtenerCursos());
        }

        public ActionResult CursoDetails(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }

        public ActionResult CursoDelete(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }

        [HttpPost]
        public ActionResult CursoDelete(int id,FormCollection frm)
        {
            repoCurso.eliminarCurso(id);
            return RedirectToAction("DatosCurso");
        }

        public ActionResult CursoEdit(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }

        [HttpPost]
        public ActionResult CursoEdit(int id, Curso datos)
        {
            datos.IdCurso = id;
            repoCurso.actualizarVideo(datos);
            return RedirectToAction("DatosCurso");
        }

        public ActionResult CursoCreate(Curso datos)
        {
            
            return RedirectToAction("DatosCurso");
        }
       
         [HttpPost]
        public ActionResult CursoCreate(int id, Curso datosCurso)
        {
            repoCurso.insertarCurso(datosCurso);
            return RedirectToAction("DatosCurso");
        }


       


        
        
        
   }
}

