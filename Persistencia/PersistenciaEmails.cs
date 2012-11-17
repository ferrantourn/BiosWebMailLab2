using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{

    internal class PersistenciaEmails : IPersistenciaEmails
    {
        //singleton

        //ESTE ATRIBUTO ES PRIVADO Y DE CLASE!!
        private static PersistenciaEmails _instancia = null;

        private PersistenciaEmails() { }

        //ESTE METODO TIENE QUE SER DE CLASE Y PUBLICO!! (TAMBIEN PODRIA SER UNA PROPIEDAD QUE SOLO CONTENGA UN GET)
        public static PersistenciaEmails GetInstancia()
        {
            return _instancia ?? (_instancia = new PersistenciaEmails());
        }


        /// <summary>
        /// Ingresa un nuevo email en el sistema
        /// </summary>
        /// <param name="e"></param>
        public void NuevoEmail(Email e)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spNuevoEmail", conexion, CommandType.StoredProcedure);

            SqlParameter _ciR = new SqlParameter("@ciR", e.CARPETA_REMITENTE.USUARIO.CI);
            SqlParameter _ciD = new SqlParameter("@ciD", e.CARPETA_DESTINATARIO.USUARIO.CI);
            SqlParameter _numCarpetaRem = new SqlParameter("@NumCarpetaR", e.CARPETA_REMITENTE.NUMERO_CARPETA);
            SqlParameter _numCarpetaDest = new SqlParameter("@NumCarpetaD", e.CARPETA_DESTINATARIO.NUMERO_CARPETA);
            SqlParameter _Asunto = new SqlParameter("@Asunto", e.ASUNTO);
            SqlParameter _Cuerpo = new SqlParameter("@Cuerpo", e.CUERPO);
            SqlParameter _Leido = new SqlParameter("@Leido", e.LEIDO);
            SqlParameter _Fecha = new SqlParameter("@Fecha", e.FECHA);


            cmd.Parameters.Add(_ciR);
            cmd.Parameters.Add(_ciD);
            cmd.Parameters.Add(_numCarpetaRem);
            cmd.Parameters.Add(_numCarpetaDest);
            cmd.Parameters.Add(_Asunto);
            cmd.Parameters.Add(_Cuerpo);
            cmd.Parameters.Add(_Leido);
            cmd.Parameters.Add(_Fecha);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


        /// <summary>
        /// Lista los emails del sistema
        /// </summary>
        /// <param name="numeroCarpeta"></param>a
        public List<Email> ListarEmails(int numeroCarpeta)
        {
            List<Email> _listaEmail = new List<Email>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarMails", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", numeroCarpeta);

            cmd.Parameters.Add(_numeroCarpeta);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                string _asunto, _cuerpo, _nombreDestinatario, _nombreRemitente, _apellidoRem,
                    _apellidoDest, _nombreUsuarioRem, _nombreUsuarioDest, _nombreCarpetaRem, _nombreCarpetaDest;
                bool _leido;
                int _numeroEmail;
                int _numCarpetaRem, _numCarpetaDest;
                Usuario _usuarioRemitente, _usuarioDestinatario;
                Carpeta _carpetaRemitente, _carpetaDestinatario;
                DateTime _fecha;

                while (_Reader.Read())
                {
                    _asunto = (string)_Reader["Asunto"];
                    _cuerpo = (string)_Reader["Cuerpo"];
                    _leido = (bool)_Reader["Leido"];
                    _numeroEmail = (int)_Reader["NumeroMail"];
                    _nombreRemitente = (string)_Reader["NombreRemitente"];
                    _nombreDestinatario = (string)_Reader["NombreDestinatario"];
                    _apellidoRem = (string)_Reader["ApellidoRemitente"];
                    _apellidoDest = (string)_Reader["ApellidoDestinatario"];
                    _nombreUsuarioRem = (string)_Reader["NombreUsuarioRemitente"];
                    _nombreUsuarioDest = (string)_Reader["NombreUsuarioDestinatario"];
                    _numCarpetaDest = (int)_Reader["NumeroCarpetaDest"];
                    _numCarpetaRem = (int)_Reader["NumeroCarpetaRem"];
                    _nombreCarpetaRem = (string)_Reader["NombreCarpetaRem"];
                    _nombreCarpetaDest = (string)_Reader["NombreCarpetaDest"];
                    _fecha = (DateTime)_Reader["Fecha"];

                    _usuarioRemitente = new Usuario(0, _nombreUsuarioRem, _nombreRemitente, _apellidoRem, "");
                    _carpetaRemitente = new Carpeta(_usuarioRemitente, _numCarpetaRem, _nombreCarpetaRem);
                    _usuarioDestinatario = new Usuario(0, _nombreUsuarioDest, _nombreDestinatario, _apellidoDest, "");
                    _carpetaDestinatario = new Carpeta(_usuarioDestinatario, _numCarpetaDest, _nombreCarpetaDest);

                    Email e = new Email(_numeroEmail, _asunto, _leido, _cuerpo, _carpetaRemitente, _carpetaDestinatario, _fecha);

                    _listaEmail.Add(e);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return _listaEmail;
        }

        /// <summary>
        /// Lista los emails del sistema
        /// </summary>
        /// <param name="numeroCarpeta"></param>a
        public List<Email> ListarEmailsEnviados(int numeroCarpeta)
        {
            List<Email> _listaEmail = new List<Email>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarMailsEnviados", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", numeroCarpeta);

            cmd.Parameters.Add(_numeroCarpeta);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                string _asunto, _cuerpo, _nombreDestinatario, _nombreRemitente, _apellidoRem,
                    _apellidoDest, _nombreUsuarioRem, _nombreUsuarioDest, _nombreCarpetaRem, _nombreCarpetaDest;
                bool _leido;
                int _numeroEmail;
                int _numCarpetaRem, _numCarpetaDest;
                Usuario _usuarioRemitente, _usuarioDestinatario;
                Carpeta _carpetaRemitente, _carpetaDestinatario;
                DateTime _fecha;

                while (_Reader.Read())
                {
                    _asunto = (string)_Reader["Asunto"];
                    _cuerpo = (string)_Reader["Cuerpo"];
                    _leido = (bool)_Reader["Leido"];
                    _numeroEmail = (int)_Reader["NumeroMail"];
                    _nombreRemitente = (string)_Reader["NombreRemitente"];
                    _nombreDestinatario = (string)_Reader["NombreDestinatario"];
                    _apellidoRem = (string)_Reader["ApellidoRemitente"];
                    _apellidoDest = (string)_Reader["ApellidoDestinatario"];
                    _nombreUsuarioRem = (string)_Reader["NombreUsuarioRemitente"];
                    _nombreUsuarioDest = (string)_Reader["NombreUsuarioDestinatario"];
                    _numCarpetaDest = (int)_Reader["NumeroCarpetaDest"];
                    _numCarpetaRem = (int)_Reader["NumeroCarpetaRem"];
                    _nombreCarpetaRem = (string)_Reader["NombreCarpetaRem"];
                    _nombreCarpetaDest = (string)_Reader["NombreCarpetaDest"];
                    _fecha = (DateTime)_Reader["Fecha"];

                    _usuarioRemitente = new Usuario(0, _nombreUsuarioRem, _nombreRemitente, _apellidoRem, "");
                    _carpetaRemitente = new Carpeta(_usuarioRemitente, _numCarpetaRem, _nombreCarpetaRem);
                    _usuarioDestinatario = new Usuario(0, _nombreUsuarioDest, _nombreDestinatario, _apellidoDest, "");
                    _carpetaDestinatario = new Carpeta(_usuarioDestinatario, _numCarpetaDest, _nombreCarpetaDest);

                    Email e = new Email(_numeroEmail, _asunto, _leido, _cuerpo, _carpetaRemitente, _carpetaDestinatario, _fecha);

                    _listaEmail.Add(e);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return _listaEmail;
        }

        /// <summary>
        /// Lista los emails del sistema
        /// </summary>
        /// <param name="numeroCarpeta"></param>a
        public List<Email> ListarEmailsRecibidos(int numeroCarpeta)
        {
            List<Email> _listaEmail = new List<Email>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarMailsRecibidos", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", numeroCarpeta);

            cmd.Parameters.Add(_numeroCarpeta);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                string _asunto, _cuerpo, _nombreDestinatario, _nombreRemitente, _apellidoRem,
                    _apellidoDest, _nombreUsuarioRem, _nombreUsuarioDest, _nombreCarpetaRem, _nombreCarpetaDest;
                bool _leido;
                int _numeroEmail;
                int _numCarpetaRem, _numCarpetaDest;
                Usuario _usuarioRemitente, _usuarioDestinatario;
                Carpeta _carpetaRemitente, _carpetaDestinatario;
                DateTime _fecha;

                while (_Reader.Read())
                {
                    _asunto = (string)_Reader["Asunto"];
                    _cuerpo = (string)_Reader["Cuerpo"];
                    _leido = (bool)_Reader["Leido"];
                    _numeroEmail = (int)_Reader["NumeroMail"];
                    _nombreRemitente = (string)_Reader["NombreRemitente"];
                    _nombreDestinatario = (string)_Reader["NombreDestinatario"];
                    _apellidoRem = (string)_Reader["ApellidoRemitente"];
                    _apellidoDest = (string)_Reader["ApellidoDestinatario"];
                    _nombreUsuarioRem = (string)_Reader["NombreUsuarioRemitente"];
                    _nombreUsuarioDest = (string)_Reader["NombreUsuarioDestinatario"];
                    _numCarpetaDest = (int)_Reader["NumeroCarpetaDest"];
                    _numCarpetaRem = (int)_Reader["NumeroCarpetaRem"];
                    _nombreCarpetaRem = (string)_Reader["NombreCarpetaRem"];
                    _nombreCarpetaDest = (string)_Reader["NombreCarpetaDest"];
                    _fecha = (DateTime)_Reader["Fecha"];

                    _usuarioRemitente = new Usuario(0, _nombreUsuarioRem, _nombreRemitente, _apellidoRem, "");
                    _carpetaRemitente = new Carpeta(_usuarioRemitente, _numCarpetaRem, _nombreCarpetaRem);
                    _usuarioDestinatario = new Usuario(0, _nombreUsuarioDest, _nombreDestinatario, _apellidoDest, "");
                    _carpetaDestinatario = new Carpeta(_usuarioDestinatario, _numCarpetaDest, _nombreCarpetaDest);

                    Email e = new Email(_numeroEmail, _asunto, _leido, _cuerpo, _carpetaRemitente, _carpetaDestinatario, _fecha);

                    _listaEmail.Add(e);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return _listaEmail;
        }

        /// <summary>
        /// ELIMINA UN EMAIL DE LA BASE DE DATOS
        /// </summary>
        /// <param name="NumeroEmail"></param>
        public void EliminarEmail(int NumeroEmail, int numCarpeta)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spEliminarEmail", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroEmail = new SqlParameter("@NumeroMail", NumeroEmail);
            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", numCarpeta);


            cmd.Parameters.Add(_numeroEmail);
            cmd.Parameters.Add(_numeroCarpeta);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


        /// <summary>
        /// MUEVE UN EMAIL DE CARPETA
        /// </summary>
        /// <param name="NumeroEmail"></param>
        public void MoverEmail(int NumeroEmail, int numCarpetaActual,int numCarpetaDestino)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spMoverEmail", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroEmail = new SqlParameter("@NumeroEmail", NumeroEmail);
            SqlParameter _numCarpetaActual = new SqlParameter("@NumeroCarpetaActual", numCarpetaActual);
            SqlParameter _numCarpetaDestino = new SqlParameter("@NumeroCarpetaDestino", numCarpetaDestino);

            cmd.Parameters.Add(_numeroEmail);
            cmd.Parameters.Add(_numCarpetaActual);
            cmd.Parameters.Add(_numCarpetaDestino);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// OBTIENE UN EMAIL DE LA BASE DE DATOS
        /// </summary>
        /// <param name="numeroEmail"></param>
        /// <returns></returns>
        public Email GetEmail(int numeroEmail)
        {
            Email EmailRetorno = new Email();
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spGetmail", conexion, CommandType.StoredProcedure);
            SqlParameter _numeroEmail = new SqlParameter("@NumeroMail", numeroEmail);

            cmd.Parameters.Add(_numeroEmail);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                _Reader = cmd.ExecuteReader();

                string _asunto, _cuerpo, _nombreDestinatario, _nombreRemitente, _apellidoRem,
                    _apellidoDest, _nombreUsuarioRem, _nombreUsuarioDest, _nombreCarpetaRem, _nombreCarpetaDest;
                bool _leido;
                int _numCarpetaRem, _numCarpetaDest;
                Usuario _usuarioRemitente, _usuarioDestinatario;
                Carpeta _carpetaRemitente, _carpetaDestinatario;
                DateTime _fecha;

                while (_Reader.Read())
                {
                    _asunto = (string)_Reader["Asunto"];
                    _cuerpo = (string)_Reader["Cuerpo"];
                    _leido = (bool)_Reader["Leido"];
                    _nombreRemitente = (string)_Reader["NombreRemitente"];
                    _nombreDestinatario = (string)_Reader["NombreDestinatario"];
                    _apellidoRem = (string)_Reader["ApellidoRemitente"];
                    _apellidoDest = (string)_Reader["ApellidoDestinatario"];
                    _nombreUsuarioRem = (string)_Reader["NombreUsuarioRemitente"];
                    _nombreUsuarioDest = (string)_Reader["NombreUsuarioDestinatario"];
                    _numCarpetaDest = (int)_Reader["NumeroCarpetaDest"];
                    _numCarpetaRem = (int)_Reader["NumeroCarpetaRem"];
                    _nombreCarpetaRem = (string)_Reader["NombreCarpetaRem"];
                    _nombreCarpetaDest = (string)_Reader["NombreCarpetaDest"];
                    _fecha = (DateTime)_Reader["Fecha"];

                    _usuarioRemitente = new Usuario(0, _nombreUsuarioRem, _nombreRemitente, _apellidoRem, "");
                    _carpetaRemitente = new Carpeta(_usuarioRemitente, _numCarpetaRem, _nombreCarpetaRem);
                    _usuarioDestinatario = new Usuario(0, _nombreUsuarioDest, _nombreDestinatario, _apellidoDest, "");
                    _carpetaDestinatario = new Carpeta(_usuarioDestinatario, _numCarpetaDest, _nombreCarpetaDest);

                    EmailRetorno = new Email(numeroEmail, _asunto, _leido, _cuerpo, _carpetaRemitente, _carpetaDestinatario,
                                        _fecha);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return EmailRetorno;
        }




        /// <summary>
        /// MARCA UN EMAIL COMO LEIDO
        /// </summary>
        /// <param name="NumeroEmail"></param>
        public void MarcarEmailLeido(int NumeroEmail, int numeroCarpeta)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spMarcarMailComoLeido", conexion, CommandType.StoredProcedure);
            SqlParameter _numeroEmail = new SqlParameter("@NumeroMail", NumeroEmail);
            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", numeroCarpeta);

            cmd.Parameters.Add(_numeroEmail);
            cmd.Parameters.Add(_numeroCarpeta);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
