
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario : ILogicaUsuario
    {
        //singleton
        private static LogicaUsuario _instancia = null;
        private LogicaUsuario() { }
        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();

            return _instancia;
        }



        public Docente getDocente(string userName)
        {
            try
            {
                IPersistenciaDocentes persDocente = FabricaPersistencia.getPersistenciaDocentes();
                return persDocente.BuscarDocente(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Alumno getAlumno(string userName)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                return persAlumnos.BuscarAlumno(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alumno getAlumno(int ci)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                return persAlumnos.BuscarAlumno(Convert.ToInt32(ci));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ACTUALIZA LA INFORMACION DE UN ALUMNO
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public void ModificarAlumno(Alumno a)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                persAlumnos.ModificarAlumno(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ModificarDocente (Docente d)
        {
            try
            {
                IPersistenciaDocentes persAlumnos = FabricaPersistencia.getPersistenciaDocentes();
                persAlumnos.ModificarDocente(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NuevoAlumno(Alumno a)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                persAlumnos.NuevoAlumno(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NuevoDocente(Docente d)
        {
            try
            {
                IPersistenciaDocentes persDocentes = FabricaPersistencia.getPersistenciaDocentes();
                persDocentes.NuevoDocente(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario getLoginUsuario(string NombreUsuario, string Pass)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                Alumno a = persAlumnos.LoginAlumno(NombreUsuario, Pass);
                if (a != null)
                {
                    return a;
                }
                else
                {

                    IPersistenciaDocentes persDocentes = FabricaPersistencia.getPersistenciaDocentes();
                    Docente d = persDocentes.LoginDocente(NombreUsuario, Pass);
                    return d;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Alumno> ListarAlumnosSinMovimientos(int NumeroDias)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                return persAlumnos.ListarAlumnosSinMovimientos(NumeroDias);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Alumno> ListarAlumnos()
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                return persAlumnos.ListarAlumno();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Docente> ListarDocentes()
        {
            try
            {
                IPersistenciaDocentes persDocentes = FabricaPersistencia.getPersistenciaDocentes();
                return persDocentes.ListarDocentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// ACTUALIZA EL STATUS DE ACTIVO/NOACTIVO DE UN ALUMNO 
        /// </summary>
        /// <param name="ci">Esta de cedula del alumno</param>
        /// <param name="SetActiveStatus"></param>
        public void ActualizarStatusAlumno(int ci, bool SetActiveStatus)
        {
            try
            {
                IPersistenciaAlumnos persAlumnos = FabricaPersistencia.getPersistenciaAlumnos();
                persAlumnos.ActualizarStatusAlumno(ci,SetActiveStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
