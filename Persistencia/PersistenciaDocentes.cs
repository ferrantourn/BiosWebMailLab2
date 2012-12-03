using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entidades;
using ExcepcionesPersonalizadas;

namespace Persistencia
{

    internal class PersistenciaDocentes : MarshalByRefObject, IPersistenciaDocentes
    {
        //singleton

        /// <summary>
        /// ESTE ATRIBUTO ES PRIVADO Y DE CLASE!!
        /// </summary>
        private static PersistenciaDocentes _instancia;

        private PersistenciaDocentes() { }

        /// <summary>
        ///ESTE METODO TIENE QUE SER DE CLASE Y PUBLICO!! 
        /// (TAMBIEN PODRIA SER UNA PROPIEDAD QUE SOLO CONTENGA UN GET)
        /// </summary>
        /// <returns></returns>
        public static PersistenciaDocentes GetInstancia()
        {
            return _instancia ?? (_instancia = new PersistenciaDocentes());
        }


        /// <summary>
        /// Ingresa un nuevo usuario en el sistema
        /// </summary>
        /// <param name="u"></param>
        public void NuevoDocente(Docente u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spAltaDocente", conexion, CommandType.StoredProcedure);

            SqlParameter _ci = new SqlParameter("@Ci", u.CI);
            SqlParameter _nombreusuario = new SqlParameter("@NombreUsuario", u.NOMBRE_USUARIO);
            SqlParameter _nombre = new SqlParameter("@Nombre", u.NOMBRE);
            SqlParameter _apellido = new SqlParameter("@Apellido", u.APELLIDO);
            SqlParameter _pass = new SqlParameter("@Pass", u.PASS);
            SqlParameter _materias = new SqlParameter("@Materias", u.MateriasToString());
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_nombreusuario);
            cmd.Parameters.Add(_nombre);
            cmd.Parameters.Add(_apellido);
            cmd.Parameters.Add(_pass);
            cmd.Parameters.Add(_materias);
            cmd.Parameters.Add(_retorno);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

                if (Convert.ToInt32(_retorno.Value) == -1)
                    throw new ErrorUsuarioYaExiste();

                if (Convert.ToInt32(_retorno.Value) == -2)
                    throw new ErrorBaseDeDatos();

                if (Convert.ToInt32(_retorno.Value) <= -3)
                    throw new ErrorBaseDeDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EliminarDocente(Docente u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spEliminarDocente", conexion, CommandType.StoredProcedure);
            SqlParameter _ci = new SqlParameter("@ci", u.CI);

            cmd.Parameters.Add(_ci);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

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

        public void ModificarDocente(Docente u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spModificarDocente", conexion, CommandType.StoredProcedure);

            SqlParameter _ci = new SqlParameter("@Ci", u.CI);
            SqlParameter _nombreusuario = new SqlParameter("@NombreUsuario", u.NOMBRE_USUARIO);
            SqlParameter _nombre = new SqlParameter("@Nombre", u.NOMBRE);
            SqlParameter _apellido = new SqlParameter("@Apellido", u.APELLIDO);
            SqlParameter _pass = new SqlParameter("@Pass", u.PASS);
            SqlParameter _materias = new SqlParameter("@Materias", u.MateriasToString());
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);

            _retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_nombreusuario);
            cmd.Parameters.Add(_nombre);
            cmd.Parameters.Add(_apellido);
            cmd.Parameters.Add(_pass);
            cmd.Parameters.Add(_materias);
            cmd.Parameters.Add(_retorno);


            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

                if (Convert.ToInt32(_retorno.Value) == -1)
                    throw new ErrorUsuarioNoExiste();

                if (Convert.ToInt32(_retorno.Value) == -2)
                    throw new ErrorBaseDeDatos();

                if (Convert.ToInt32(_retorno.Value) <= -3)
                    throw new ErrorBaseDeDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }


        }

        /// <summary>
        /// BUSCA UN USUARIO EN EL SISTEMA POR SU NOMBRE DE USUARIO
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Docente BuscarDocente(string userName)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spBuscarDocente", conexion, CommandType.StoredProcedure);
            SqlParameter _userName = new SqlParameter("@NombreUsuario", userName);
            cmd.Parameters.Add(_userName);

            SqlDataReader reader;
            Docente u = null;
            int _ci;
            string _nombreusuario, _nombre, _apellido, _password, _materias;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    _ci = (int)reader["Ci"];
                    _nombre = (string)reader["Nombre"];
                    _nombreusuario = (string)reader["NombreUsuario"];
                    _apellido = (string)reader["Apellido"];
                    _password = (string)reader["Pass"];
                    _materias = (string)reader["Materias"];
                    u = new Docente
                            {
                                CI = _ci,
                                NOMBRE_USUARIO = _nombreusuario,
                                NOMBRE = _nombre,
                                APELLIDO = _apellido,
                                PASS = _password,
                                MATERIAS = _materias.Split(',').ToList()
                            };
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

            return u;
        }

        public Docente LoginDocente(string NombreUsuario, string Pass)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spLoginDocente", conexion, CommandType.StoredProcedure);
            SqlParameter _userName = new SqlParameter("@NombreUsuario", NombreUsuario);
            cmd.Parameters.Add(_userName);
            SqlParameter _passWord = new SqlParameter("@Pass", Pass);
            cmd.Parameters.Add(_passWord);
            SqlDataReader reader;

            Docente u = null;
            int _ci;
            string _nombreusuario, _nombre, _apellido, _password, _materias;

            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    _ci = (int)reader["Ci"];
                    _nombre = (string)reader["Nombre"];
                    _nombreusuario = (string)reader["NombreUsuario"];
                    _apellido = (string)reader["Apellido"];
                    _password = (string)reader["Pass"];
                    _materias = (string)reader["Materias"];
                    u = new Docente
                    {
                        CI = _ci,
                        NOMBRE_USUARIO = _nombreusuario,
                        NOMBRE = _nombre,
                        APELLIDO = _apellido,
                        PASS = _password,
                        MATERIAS = _materias.Split(',').ToList()
                    };
                }
                reader.Close();
            }
            catch
            {
                throw new ErrorBaseDeDatos();
            }
            finally
            {
                conexion.Close();
            }

            return u;
        }

        public List<Docente> ListarDocentes()
        {
            List<Docente> _listaDocentes = new List<Docente>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarDocentes", conexion, CommandType.StoredProcedure);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                int _ci;
                string _nombreUsuario, _nombre, _apellido, _pass, _materias;

                while (_Reader.Read())
                {
                    _ci = (int)_Reader["Ci"];
                    _nombreUsuario = (string)_Reader["NombreUsuario"];
                    _nombre = (string)_Reader["Nombre"];
                    _apellido = (string)_Reader["Apellido"];
                    _pass = (string)_Reader["Pass"];
                    _materias = (string)_Reader["Materias"];

                    Docente a = new Docente
                                    {
                                        CI = _ci,
                                        NOMBRE_USUARIO = _nombreUsuario,
                                        PASS = _pass,
                                        NOMBRE = _nombre,
                                        APELLIDO = _apellido,
                                        MATERIAS = _materias.Split(',').ToList()

                                    };

                    _listaDocentes.Add(a);
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

            return _listaDocentes;
        }


    }
}
