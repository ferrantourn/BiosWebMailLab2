using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

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
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                if (c.NOMBRE_CARPETA.ToUpper() == "INBOX" ||
                    c.NOMBRE_CARPETA.ToUpper() == "PAPELERA" ||
                    c.NOMBRE_CARPETA.ToUpper() == "ENVIADOS")
                {
                    throw new Exception("Nombre de carpeta no valido");
                }

                //si el nombre de la carpeta no es ninguno por defecto del sistema la podemos ingreasr
                pc.NuevaCarpeta(c);
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
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                return pc.ListarCarpetasAlumno(a.CI);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void EliminarCarpeta(int numeroCarpeta)
        {
            try
            {
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                pc.EliminarCarpeta(numeroCarpeta);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public Carpeta getInboxFolder(int ciAlumno)
        {
            try
            {
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                return pc.BuscarCarpetaSistemaAlumno(ciAlumno, "Inbox");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Carpeta getSentFolder(int ciAlumno)
        {
            try
            {
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                return pc.BuscarCarpetaSistemaAlumno(ciAlumno, "Enviados");
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


        public Carpeta GetCarpeta(int numCarpeta, int ci)
        {
            try
            {
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                return pc.BuscarCarpetaAlumno(ci, numCarpeta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
