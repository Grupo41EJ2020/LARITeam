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
        //
        // GET: /Empleados/
        //Pagina principal de los empleados

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
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("Direccion", datosEmpleado.Direccion));

            BaseHelper.ejecutarSentencia("sp_Empleado_Insertar", CommandType.StoredProcedure, parametros);
            
            return RedirectToAction("Index");
        }

        public ActionResult ConsultarTodo()
        {
            //obtener todos los videos

            DataTable dtEmpleados = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> lstEmpleados = new List<Empleado>();

            //convertir el DataTable en List<Video>

            foreach (DataRow item in dtEmpleados.Rows)
            { 
                Empleado datosEmpleado = new Empleado();

                datosEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                datosEmpleado.Nombre = item["Nombre"].ToString();
                datosEmpleado.Direccion = item["Direccion"].ToString();

                lstEmpleados.Add(datosEmpleado); 

            }
            
            return View(lstEmpleados);
        }

    }
}
