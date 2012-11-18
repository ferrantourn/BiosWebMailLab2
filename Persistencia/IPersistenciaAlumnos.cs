using System.Collections.Generic;
using Entidades;

namespace Persistencia
{
    public interface IPersistenciaAlumnos
    {
        void NuevoAlumno(Alumno u);
        void EliminarAlumno(Alumno u);
        void ModificarAlumno(Alumno u);
        Alumno BuscarAlumno(string userName);
        Alumno BuscarAlumno(int Ci);
        Alumno LoginAlumno(string NombreUsuario, string Pass);
        void ActualizarStatusAlumno(Alumno a);
        List<Alumno> ListarAlumnosSinMovimientos(int NumeroDias);
        List<Alumno> ListarAlumno();
    }
}
