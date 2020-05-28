using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    
        public interface ICurso_Tema_Video
        {
            List<Curso_Tema_Video> obtenerCurso_Tema_Video();
            Curso obtenerCurso_Tema_Video(int IdCurso_Tema_Video);
            void insertarCurso_Tema_Video(Curso datosCurso_Tema_Video);
            void eliminarCurso_Tema_Video(int IdCurso_Tema_Video);
            void actualizarCurso_Tema_Video(Curso datosCurso_Tema_Video);

        }
    
}