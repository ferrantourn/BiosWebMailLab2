using System;
using System.Collections.Generic;
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



        //public void AgregarEmail(string asunto, string cuerpo, Alumno Remitente, string userNameDestinatario)
        public void AgregarEmail(Email newEmail, Alumno remitente, Alumno destinatario)
        {
            try
            {
                //PRIMERO VALIDAMOS QUE EL DESTINATARIO EXISTA
                //--------------------------------------------
                LogicaUsuario lusuario = LogicaUsuario.GetInstancia();
                //OBTENERMOS EL USUARIO DESTINATARIO
                //destinatario = lusuario.getAlumno(destinatario.NOMBRE_USUARIO);
                destinatario = lusuario.getAlumno(destinatario);
                if (destinatario != null)
                {
                    //OBTENGO LA CARPETA INBOX POR DEFECTO DEL DESTINATARIO
                    //------------------------------------------------------
                    LogicaCarpetas lcarpeta = LogicaCarpetas.GetInstancia();
                    //Carpeta InboxDest = lcarpeta.getInboxFolder(destinatario.CI);
                    Carpeta InboxDest = lcarpeta.getInboxFolder(destinatario);

                    //Carpeta SentFolder = lcarpeta.getSentFolder(Remitente.CI);
                    Carpeta SentFolder = lcarpeta.getSentFolder(remitente);

                    //Email e = new Email(null, asunto, false, cuerpo, SentFolder, InboxDest, DateTime.Now);
                    newEmail.CARPETA_DESTINATARIO = InboxDest;
                    newEmail.CARPETA_REMITENTE = SentFolder;
                    IPersistenciaEmails persEmails = FabricaPersistencia.getPersistenciaEmails();

                    //GUARDAMOS EL NUEVO EMAIL EN LA BASE DE DATOS
                    //--------------------------------------------
                    persEmails.NuevoEmail(newEmail);
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

        //public List<Email> ListarEmail(int numeroCarpeta, int ci)
        public List<Email> ListarEmail(Carpeta carpeta)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();

                ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                //Carpeta c = lc.GetCarpeta(numeroCarpeta, ci);
                Carpeta c = lc.GetCarpeta(carpeta);

                List<Email> emails = new List<Email>();
                if (c != null)
                {
                    if (c.NOMBRE_CARPETA.ToUpper() == "ENVIADOS")
                    {
                        emails = pe.ListarEmailsEnviados(carpeta);
                    }
                    else if (c.NOMBRE_CARPETA.ToUpper() == "INBOX")
                    {
                        emails = pe.ListarEmailsRecibidos(carpeta);
                    }
                    else
                    {
                        emails = pe.ListarEmails(carpeta);
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

      
        //public void EliminarEmail(int numeroEmail, int NumeroCarpeta, int ciAlumno)
        /// <summary>
        /// ENVIA UN EMAIL A LA CARPETA DE PAPELERA
        /// ELIMINA UN EMAIL COMPLETAMENTE SI SE ENCUENTRA EN LA CARPETA PAPELERA
        /// </summary>
        /// <param name="e"></param>
        /// <param name="carpeta"></param>
        public void EliminarEmail(Email e, Carpeta carpeta)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                IPersistenciaCarpetas pc = FabricaPersistencia.getPersistenciaCarpetas();
                //Carpeta c = pc.BuscarCarpetaAlumno(ciAlumno, NumeroCarpeta);
                Carpeta c = pc.BuscarCarpetaAlumno(carpeta);
                if (c != null && c.NOMBRE_CARPETA.ToUpper() != "PAPELERA")
                {
                    //Carpeta papelera = pc.BuscarCarpetaSistemaAlumno(ciAlumno, "Papelera");
                    carpeta.NOMBRE_CARPETA = "Papelera";
                    Carpeta papelera = pc.BuscarCarpetaSistemaAlumno(carpeta);

                    if (papelera != null)
                    {
                        //pe.MoverEmail(numeroEmail, NumeroCarpeta, papelera.NUMERO_CARPETA);
                        pe.MoverEmail(e, carpeta, papelera);

                    }
                    else
                    {
                        throw new Exception("No se encontro la carpeta papelera del usuario");
                    }
                }
                else
                {
                    //pe.EliminarEmail(numeroEmail, NumeroCarpeta);
                    pe.EliminarEmail(e, carpeta);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public Email GetEmail(int numeroEmail)
        public Email GetEmail(Email e)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                return pe.GetEmail(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void MarcarEmailLeido(int NumeroEmail, int numeroCarpeta)
        public void MarcarEmailLeido(Email e, Carpeta c)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();

                pe.MarcarEmailLeido(e, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void MoverEmail(int numeroEmail, int NumeroCarpetaActual, int numeroCarpetaDestino)
        public void MoverEmail(Email e, Carpeta carpetaActual, Carpeta carpetaDestino)
        {
            try
            {
                IPersistenciaEmails pe = FabricaPersistencia.getPersistenciaEmails();
                pe.MoverEmail(e, carpetaActual, carpetaDestino);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

