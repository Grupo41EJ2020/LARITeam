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
    public class TemaController : Controller
    {
        RepositorioTema repoTema = new RepositorioTema();

        public ActionResult Tema()
        {
            return View(repoTema.obtenerTemas());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TemaDetails(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        public ActionResult TemaDelete(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        [HttpPost]
        public ActionResult TemaDelete(int id, FormCollection frm)
        {
            repoTema.eliminarTema(id);
            return RedirectToAction("Tema");
        }

        public ActionResult TemaEdit(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        [HttpPost]
        public ActionResult TemaEdit(int id, Tema datos)
        {
            datos.IdTema = id;
            repoTema.actualizarTema(datos);
            return RedirectToAction("Tema");
        }

        public ActionResult TemaCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TemaCreate(Tema datosTema)
        {

            repoTema.insertarTema(datosTema);
            return RedirectToAction("Tema");
            ////return RedirectToAction("Index");
        }

    }
}
