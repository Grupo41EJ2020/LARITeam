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
    public class RepositorioTema : ITema
    {
        public List<Tema> obtenerTemas()
        {
            //obtener todos los temas
            DataTable dtTemas = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarTodo", CommandType.StoredProcedure);

            List<Tema> lsttemas = new List<Tema>();

            //convertir el DataTable en List<Tema> 

            foreach (DataRow item in dtTemas.Rows)
            {
                Tema datosTema = new Tema();

                datosTema.IdTema = int.Parse(item["IdTema"].ToString());
                datosTema.Nombre = item["Nombre"].ToString();               
                
                lsttemas.Add(datosTema);

            }
            return lsttemas;
        }

        public Tema obtenerTema(int idTema)
        {
            //consultar los datos del Tema
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", idTema));

            DataTable dtTema = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Tema miTema = new Tema();

            if (dtTema.Rows.Count > 0)
            {
                miTema.IdTema = int.Parse(dtTema.Rows[0]["IdTema"].ToString());
                miTema.Nombre = dtTema.Rows[0]["Nombre"].ToString();
          
                return miTema;
            }
            else
            {  //no encontrado 
                return null;
            }
        }

        public void insertarTema(Tema datosTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));        

            BaseHelper.ejecutarSentencia("sp_Tema_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarTema(int idTema)
        {
            //obtener info del tema
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", idTema));

            BaseHelper.ejecutarConsulta("sp_Tema_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarTema(Tema datosTema)
        {
            //realizar el update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", datosTema.IdTema));
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));
    

            BaseHelper.ejecutarConsulta("sp_Tema_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}