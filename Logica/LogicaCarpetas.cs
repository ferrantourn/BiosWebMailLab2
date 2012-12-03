using System;
using System.Collections.Generic;
using Entidades;

namespace Logica
{
    internal class LogicaCarpetas : ILogicaCarpetas
    {
        //singleton
        private static LogicaCarpetas _instancia = null;
        private LogicaCarpetas() { }
        public static LogicaCarpetas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCarpetas();

            return _instancia;
        }


        public void AgregarCarpeta(Carpeta c)
        {

            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                if (c.NOMBRE_CARPETA.ToUpper() == "INBOX" ||
                    c.NOMBRE_CARPETA.ToUpper() == "PAPELERA" ||
                    c.NOMBRE_CARPETA.ToUpper() == "ENVIADOS")
                {
                    throw new Exception("Nombre de carpeta no valido");
                }

                //si el nombre de la carpeta no es ninguno por defecto del sistema la podemos ingreasr
                _objServicioC.NuevaCarpeta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Carpeta> ListarCarpetas(Alumno a)
        {
            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                return _objServicioC.ListarCarpetasAlumno(a);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public void EliminarCarpeta(int numeroCarpeta)
        public void EliminarCarpeta (Carpeta c)
        {
            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                _objServicioC.EliminarCarpeta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        //public Carpeta getInboxFolder(int ciAlumno)
        public Carpeta getInboxFolder(Alumno a)
        {
            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                Carpeta c = new Carpeta {USUARIO = a, NOMBRE_CARPETA = "Inbox"};
                return _objServicioC.BuscarCarpetaSistemaAlumno(c);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public Carpeta getSentFolder(int ciAlumno)
        public Carpeta getSentFolder(Alumno a)
        {
            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                Carpeta c = new Carpeta { USUARIO = a, NOMBRE_CARPETA = "Enviados" };
                return _objServicioC.BuscarCarpetaSistemaAlumno(c);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// DETERMINA SI UNA CARPETA ES UNA CARPETA PROPIA DEL SISTEMA O NO.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsCarpetaSistema(Carpeta c)
        {
            if (c.NOMBRE_CARPETA.ToUpper() == "INBOX" || c.NOMBRE_CARPETA.ToUpper() == "PAPELERA" || c.NOMBRE_CARPETA.ToUpper() == "ENVIADOS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public Carpeta GetCarpeta(int numCarpeta, int ci)
        public Carpeta GetCarpeta(Carpeta c)
        {
            try
            {
                ServicioRemoting.ServicioCarpeta _objServicioC = new ServicioRemoting.ServicioCarpeta();
                return _objServicioC.BuscarCarpetaAlumno(c);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
