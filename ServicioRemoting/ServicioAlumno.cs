using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioAlumno
    {
        //atributo que representa un objeto de la fachadalogicaremota. 
        private Persistencia.IPersistenciaAlumnos unaPersistencia;
        
         //constructor del servicio
        public ServicioAlumno()
        {
            //se crea el servicio para uso del remoting
            Servicio.CreoServicio();

            //creo mi objeto fachada para trabajar en todas las operaciones que brinda el servicio
            unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaAlumnos();
        }

        //operaciones
        public Entidades.Alumno Buscar(int pCi)
        {
            return unaPersistencia.BuscarAlumno(pCi);
        }

        public Entidades.Alumno Buscar(Entidades.Alumno a)
        {
            return unaPersistencia.BuscarAlumno(a.NOMBRE_USUARIO);
        }

        public List<Entidades.Alumno> Listar()
        {
            return unaPersistencia.ListarAlumno();
        }

        public void AltaAlumno(Entidades.Alumno a)
        {
            unaPersistencia.NuevoAlumno(a);
        }

        public void ModificarAlumno(Entidades.Alumno a)
        {
            unaPersistencia.ModificarAlumno(a);
        }
        public void EliminarAlumno(Entidades.Alumno a)
        {
            unaPersistencia.EliminarAlumno(a);
        }
        public void ActualizarStatusAlumno(Entidades.Alumno a)
        {
            unaPersistencia.ActualizarStatusAlumno(a);
        }
        public List<Entidades.Alumno> ListarAlumnosSinMovimientos(int d)
        {
            return unaPersistencia.ListarAlumnosSinMovimientos(d);
        }
        public Entidades.Alumno LoginAlumno(string user, string pass)
        {
            return unaPersistencia.LoginAlumno(user, pass);
        }
         


    }
}
