using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MVCLaboratorio.Models;
using System.Data;
using System.Data.SqlClient;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Models
{
    public class RepositorioEmpleados: IEmpleado 
    {
        public List<Empleado> obtenerEmpleado()
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

            return lstEmpleados;
        }

        public Empleado obtenerEmpleado(int idEmpleado)
        {
            //Consultar los datos del video

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", idEmpleado));

            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarPorID", CommandType.StoredProcedure, parametros);
            Empleado elEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0)
            {
                elEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                elEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                elEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();
                return elEmpleado; 

            }
            else  //no encontrado
            {
                return null;
            } 
        }

        public void insertarEmpleado(Empleado datosEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("Direccion", datosEmpleado.Direccion));

            BaseHelper.ejecutarSentencia("sp_Empleado_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarEmpleado(int idEmpleado)
        {
            //obtener inf del video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", idEmpleado));

            BaseHelper.ejecutarConsulta("sp_Empleado_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarEmpleado(Empleado datosEmpleado)
        {
            //actualizar empleado
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", datosEmpleado.IdEmpleado));
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));

            BaseHelper.ejecutarConsulta("sp_Empleado_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}