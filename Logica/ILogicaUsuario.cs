using System.Collections.Generic;
using Entidades;

namespace Logica
{
    public interface ILogicaUsuario
    {
        Alumno getAlumno(Alumno a);
        Alumno getAlumno(int ci);
        Docente getDocente(Docente d);
        void NuevoAlumno(Alumno a);
        void NuevoDocente(Docente d);
        Usuario getLoginUsuario(string userName, string pass);
        List<Alumno> ListarAlumnosSinMovimientos(int NumeroDias);
        List<Docente> ListarDocentes();
        List<Alumno> ListarAlumnos();
        /// <summary>
        /// ACTUALIZA EL STATUS DE ACTIVO/NOACTIVO DE UN ALUMNO
        /// </summary>
        /// <param name="a"></param>
        /// <param name="SetActiveStatus"></param>
        void ActualizarStatusAlumno(Alumno a, bool setActiveStatus);


        /// <summary>
        /// ACTUALIZA LA INFORMACION DE UN ALUMNO
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        void ModificarAlumno(Alumno a);

        /// <summary>
        /// ACTUALIZA LA INFORMACION DE UN DOCENTE
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        void ModificarDocente(Docente d);
    }

}
