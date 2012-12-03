using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using ExcepcionesPersonalizadas;

namespace Persistencia
{

    internal class PersistenciaCarpetas : MarshalByRefObject, IPersistenciaCarpetas
    {
        //singleton

        //ESTE ATRIBUTO ES PRIVADO Y DE CLASE!!
        private static PersistenciaCarpetas _instancia = null;

        private PersistenciaCarpetas() { }

        //ESTE METODO TIENE QUE SER DE CLASE Y PUBLICO!! (TAMBIEN PODRIA SER UNA PROPIEDAD QUE SOLO CONTENGA UN GET)
        public static PersistenciaCarpetas GetInstancia()
        {
            return _instancia ?? (_instancia = new PersistenciaCarpetas());
        }


        /// <summary>
        /// DA DE ALTA UNA NUEVA CARPETA
        /// </summary>
        /// <param name="c"></param>
        public void NuevaCarpeta(Carpeta c)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spAltaCarpeta", conexion, CommandType.StoredProcedure);

            SqlParameter _ci = new SqlParameter("@ci", c.USUARIO.CI);
            SqlParameter _nombreCarpeta = new SqlParameter("@NombreCarpeta", c.NOMBRE_CARPETA);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_nombreCarpeta);
            cmd.Parameters.Add(_Retorno);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

                if (Convert.ToInt32(_Retorno.Value) == -1)
                    throw new ErrorCarpetaYaExiste();

                if (Convert.ToInt32(_Retorno.Value) == -2)
                    throw new ErrorUsuarioNoExiste();

                if (Convert.ToInt32(_Retorno.Value) == -3)
                    throw new ErrorGeneral();

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
        /// ELIMINA UNA CARPETA DEL SISTEMA
        /// </summary>
        /// <param name="numeroCarpeta"></param>
        public void EliminarCarpeta(Carpeta c)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spEliminarCarpeta", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroCarpeta = new SqlParameter("@NumeroCarpeta", c.NUMERO_CARPETA);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_numeroCarpeta);
            cmd.Parameters.Add(_Retorno);

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




        
        //public Carpeta BuscarCarpetaSistemaAlumno(int ciAlumno, string nombreCarpetaSistema)
        /// <summary>
        /// DADO EL USUARIO OBTIENE LA CARPETA DEL sistema pedida
        /// </summary>
        /// <param name="carpeta"></param>
        /// <returns></returns>
        public Carpeta BuscarCarpetaSistemaAlumno(Carpeta carpeta)

        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spBuscarCarpetaSistema", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@Ci", carpeta.USUARIO.CI);
            SqlParameter _carpetaSistema = new SqlParameter("@nombreCarpetaSistema", carpeta.NOMBRE_CARPETA);
            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_carpetaSistema);

            SqlDataReader reader;
            Carpeta c = null;
            int _numCarpeta;
            //Usuario _usuario;
            Alumno _usuario;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _numCarpeta = (int)reader["NumeroCarpeta"];
                    //_usuario = new Usuario(ciAlumno, "", "", "", "");
                    _usuario = new Alumno { CI = carpeta.USUARIO.CI};

                    c = new Carpeta(_usuario, _numCarpeta, carpeta.NOMBRE_CARPETA);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return c;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciAlumno"></param>
        /// <param name="numCarpeta"></param>
        /// <returns></returns>
        public Carpeta BuscarCarpetaAlumno(Carpeta carpeta)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spBuscarCarpeta", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@Ci", carpeta.USUARIO.CI);
            SqlParameter _numCarpeta = new SqlParameter("@numCarpeta", carpeta.NUMERO_CARPETA);
            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_numCarpeta);

            SqlDataReader reader;
            Carpeta c = null;
            //Usuario _usuario;
            Alumno _usuario;
            string _nomCarpeta;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nomCarpeta = (string)reader["NombreCarpeta"];
                    //_usuario = new Usuario(ciAlumno, "", "", "", "");
                    _usuario = new Alumno { CI = carpeta.USUARIO.CI };
                    c = new Carpeta(_usuario, carpeta.NUMERO_CARPETA, _nomCarpeta);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return c;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="a"></param>
       /// <returns></returns>
        public List<Carpeta> ListarCarpetasAlumno(Alumno a)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarCarpetasUsuario", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@Ci", a.CI);


            cmd.Parameters.Add(_ci);

            SqlDataReader reader;
            List<Carpeta> carpetas = new List<Carpeta>();
            //Usuario _usuario;
            Alumno _usuario;
            string _nomCarpeta;
            int _numCarpeta;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Carpeta c = new Carpeta();

                    _numCarpeta = (int)reader["NumeroCarpeta"];
                    _nomCarpeta = (string)reader["NombreCarpeta"];
                    //_usuario = new Usuario(ciAlumno, "", "", "", "");
                    _usuario = new Alumno {CI = a.CI};
                    c.NUMERO_CARPETA = _numCarpeta;
                    c.NOMBRE_CARPETA = _nomCarpeta;
                    int _totalEmails = ContarMailsCarpeta(c);
                    int _totalEmalsUnRead = ContarMailsCarpetaSinLeer(c);
                    c.USUARIO = _usuario;
                    c.TOTAL_EMAILS = _totalEmails;
                    c.TOTAL_EMAILS_NOLEIDOS = _totalEmalsUnRead;
                    carpetas.Add(c);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos: ListarCarpetasAlumno" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return carpetas;
        }


        /// <summary>
        /// CUENTA LA CANTIDAD DE EMAILS QUE CONTIENE UNA CARPETA
        /// </summary>
        /// <param name="numCarpeta"></param>
        /// <returns></returns>
        internal int ContarMailsCarpeta(Carpeta c)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spContarMailsCarpeta", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@numCarpeta", c.NUMERO_CARPETA);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_retorno);

            int cantEmailsCarpeta = 0;
            SqlDataReader reader;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cantEmailsCarpeta = (int)reader["Total"];
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

            return cantEmailsCarpeta;
        }

        /// <summary>
        /// CUENTA EL TOTAL DE EMAILS DE UNA CARPETA SIN LEER
        /// </summary>
        /// <param name="numCarpeta"></param>
        /// <returns></returns>
        internal int ContarMailsCarpetaSinLeer(Carpeta c)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spContarMailsSinLeer", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@numCarpeta", c.NUMERO_CARPETA);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_retorno);


            int cantSinLeer = 0;
            SqlDataReader reader;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cantSinLeer = (int)reader["Total"];
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

            return cantSinLeer;
        }



    }
}
