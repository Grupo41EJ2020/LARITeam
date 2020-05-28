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
    public class Curso_TemaController : Controller
    {
        RepositorioCurso_Tema repoCurso_Tema = new RepositorioCurso_Tema();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso_Tema()
        {
            return View(repoCurso_Tema.obtenerCurso_Tema());
        }

        public ActionResult Curso_TemaDetails(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));
        }

        public ActionResult Curso_TemaDelete(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));
        }

        [HttpPost]
        public ActionResult Curso_TemaDelete(int id, FormCollection frm)
        {
            repoCurso_Tema.eliminarCurso_Tema(id);
            return RedirectToAction("DatosCurso");
        }

        public ActionResult Curso_TemaEdit(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));
        }

        [HttpPost]
        public ActionResult Curso_TemaEdit(int id, Curso_Tema datos)
        {
            datos.IdCT = id;
            repoCurso_Tema.actualizarCurso_Tema(datos);
            return RedirectToAction("DatosCurso_Tema");
        }

        public ActionResult Curso_TemaCreate(Curso_Tema datos)
        {

            return RedirectToAction("DatosCurso_Tema");
        }

        [HttpPost]
        public ActionResult Curso_TemaCreate(int id, Curso_Tema datosCurso_Tema)
        {
            repoCurso_Tema.insertarCurso_Tema(datosCurso_Tema);
            return RedirectToAction("DatosCurso_Tema");
        }








    }
}

