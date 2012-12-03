using System;
using System.Collections.Generic;
using System.Xml;
using Entidades;

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



        //public Docente getDocente(string userName)
        public Docente getDocente(Docente d)
        {
            try
            {
                ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                return (_objServicioD.Buscar(d.NOMBRE_USUARIO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public Alumno getAlumno(string userName)
        public Alumno getAlumno(Alumno a)
        {
            try
            {
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                return (_objServicioA.Buscar(a));
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
                 ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                 return (_objServicioA.Buscar(ci));
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
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                _objServicioA.ModificarAlumno(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ModificarDocente(Docente d)
        {
            try
            {
                ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                _objServicioD.Modificar(d);
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
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                _objServicioA.AltaAlumno(a);
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
                ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                _objServicioD.Alta(d);
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
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                Entidades.Alumno a =_objServicioA.LoginAlumno(NombreUsuario, Pass);
                if (a != null)
                {
                    return a;
                }
                else
                {

                    ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                    Entidades.Docente d = _objServicioD.LoginDocente(NombreUsuario, Pass);

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
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                List<Entidades.Alumno> Lista = _objServicioA.ListarAlumnosSinMovimientos(NumeroDias);
                return Lista;
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
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                List<Entidades.Alumno> Lista = _objServicioA.Listar();
                return Lista;
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
                ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                return _objServicioD.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// ACTUALIZA EL STATUS DE ACTIVO/NOACTIVO DE UN ALUMNO 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="setActiveStatus"></param>
        public void ActualizarStatusAlumno(Alumno a, bool setActiveStatus)
        {
            try
            {
                ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                a.ACTIVO = setActiveStatus;
                _objServicioA.ActualizarStatusAlumno(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
