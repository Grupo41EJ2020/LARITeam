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
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DatosCurso()
        {
            DataTable dtCursos = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarTodo", CommandType.StoredProcedure);


            List<Curso> lstCursos = new List<Curso>();

            foreach (DataRow item in dtCursos.Rows)
	        {
                Curso datosCurso = new Curso();

                datosCurso.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCurso.Descripcion = item["Descripcion"].ToString();
                datosCurso.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());

                lstCursos.Add(datosCurso);
		 
	        }


            return View(lstCursos);
        }

        public ActionResult CursoDetails(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                return View(miCurso);
            }
            else 
            {
                return View("Error");
            }

        }

        public ActionResult CursoDelete(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                return View(miCurso);
            }
            else
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult CursoDelete(int id,FormCollection frm)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            BaseHelper.ejecutarConsulta("sp_Curso_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("DatosCurso");
        }

        public ActionResult CursoEdit(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso miCurso = new Curso();

            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                return View(miCurso);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult CursoEdit(int id, Curso datos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));
            parametros.Add(new SqlParameter("@Descripcion", datos.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datos.IdEmpleado));

            BaseHelper.ejecutarConsulta("sp_Curso_Actualizar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("DatosCurso");

        }

        }
    }

