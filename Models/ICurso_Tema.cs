using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    
        public interface ICurso_Tema
        {
            List<Curso_Tema> obtenerCurso_Tema();
            Curso obtenerCurso_Tema(int IdCurso_Tema);
            void insertarCurso_Tema(Curso datosCurso_Tema);
            void eliminarCurso_Tema(int IdCurso);
            void actualizarCurso_Tema(Curso datosCurso_Tema);

        }
    
}