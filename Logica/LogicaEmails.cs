using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Entidades;
using Persistencia;

namespace Logica
{
    internal class LogicaEmails : ILogicaEmails
    {
        //singleton
        private static LogicaEmails _instancia = null;
        private LogicaEmails() { }
        public static LogicaEmails GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEmails();

            return _instancia;
        }



        public void AgregarEmail(string asunto, string cuerpo, Alumno Remitente, string userNameDestinatario)
        {
            try
            {
                //PRIMERO VALIDAMOS QUE EL DESTINATARIO EXISTA
                //--------------------------------------------
                LogicaUsuario lusuario = LogicaUsuario.GetInstancia();
                Alumno destinatario = lusuario.getAlumno(userNameDestinatario);
                if (destinatario != null)
                {
                    //OBTENGO LA CARPETA INBOX POR DEFECTO DEL DESTINATARIO
                    //------------------------------------------------------
                    LogicaCarpetas lcarpeta = LogicaCarpetas.GetInstancia();
                    Carpeta InboxDest = lcarpeta.getInboxFolder(destinatario.CI);
                    Carpeta SentFolder = lcarpeta.getSentFolder(Remitente.CI);
                    Email e = new Email(null, asunto, false, cuerpo, SentFolder, InboxDest, DateTime.Now);
                    IPersistenciaEmails persEmails = FabricaPersistencia.getPersistenciaEmails();

                    //GUARDAMOS EL NUEVO EMAIL EN LA BASE DE DATOS
                    //--------------------------------------------
                    persEmails.NuevoEmail(e);
                }
                else
                    //CREAR EXCEPCION PERSONALIZADA AQUI!! ***********************************
                    throw new Exception("Usuario destinatario no valido. El usuario no existe en el sistema.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Email> ListarEmail(int numeroCarpeta, int ci)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();

                ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                Carpeta c = lc.GetCarpeta(numeroCarpeta, ci);
                List<Email> emails = new List<Email>();
                if (c != null)
                {
                    if (c.NOMBRE_CARPETA.ToUpper() == "ENVIADOS")
                    {
                        emails = pe.ListarEmailsEnviados(numeroCarpeta);
                    }
                    else if (c.NOMBRE_CARPETA.ToUpper() == "INBOX")
                    {
                        emails = pe.ListarEmailsRecibidos(numeroCarpeta);
                    }
                    else
                    {
                        emails = pe.ListarEmails(numeroCarpeta);
                    }

                    return emails;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ENVIA UN EMAIL A LA CARPETA DE PAPELERA
        /// ELIMINA UN EMAIL COMPLETAMENTE SI SE ENCUENTRA EN LA CARPETA PAPELERA
        /// </summary>
        /// <param name="numeroEmail"></param>
        /// <param name="NumeroCarpeta"></param>
        /// <param name="ciAlumno"></param>
        public void EliminarEmail(int numeroEmail, int NumeroCarpeta, int ciAlumno)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                Carpeta c = pc.BuscarCarpetaAlumno(ciAlumno, NumeroCarpeta);
                if (c != null && c.NOMBRE_CARPETA.ToUpper() != "PAPELERA")
                {
                    Carpeta papelera = pc.BuscarCarpetaSistemaAlumno(ciAlumno, "Papelera");
                    if (papelera != null)
                    {
                        pe.MoverEmail(numeroEmail, NumeroCarpeta, papelera.NUMERO_CARPETA);
                    }
                    else
                    {
                        throw new Exception("No se encontro la carpeta papelera del usuario");
                    }
                }
                else
                {
                    pe.EliminarEmail(numeroEmail, NumeroCarpeta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Email GetEmail(int numeroEmail)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                return pe.GetEmail(numeroEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MarcarEmailLeido(int NumeroEmail, int numeroCarpeta)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();

                pe.MarcarEmailLeido(NumeroEmail, numeroCarpeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MoverEmail(int numeroEmail, int NumeroCarpetaActual, int numeroCarpetaDestino)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                pe.MoverEmail(numeroEmail, NumeroCarpetaActual, numeroCarpetaDestino);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

