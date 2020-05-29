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
    public class VideoController : Controller
    {
        RepositorioVideo repoVideo = new RepositorioVideo(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        { 
            return View(repoVideo.obtenerVideos()); 
        }

        public ActionResult Details(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        public ActionResult Delete(int id)
        {
            return View (repoVideo.obtenerVideo(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection frm)
        { 
            repoVideo.eliminarVideo(id); 
            return RedirectToAction("Lista");
        }

        public ActionResult Edit(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

    [HttpPost]
        public ActionResult Edit(int id, Video datos) 
        {
            datos.IdVideo = id; 
            repoVideo.actualizarVideo(datos);
            return RedirectToAction("Lista");
        }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Video datosVideo)
    {
        repoVideo.insertarVideo(datosVideo);
        return RedirectToAction("Lista");
    }



        }
}
