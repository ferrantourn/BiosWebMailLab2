using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using ExcepcionesPersonalizadas;

namespace Persistencia
{

    internal class PersistenciaAlumnos : IPersistenciaAlumnos
    {
        //singleton

        /// <summary>
        /// ESTE ATRIBUTO ES PRIVADO Y DE CLASE!!
        /// </summary>
        private static PersistenciaAlumnos _instancia;

        private PersistenciaAlumnos() { }

        /// <summary>
        ///ESTE METODO TIENE QUE SER DE CLASE Y PUBLICO!! 
        /// (TAMBIEN PODRIA SER UNA PROPIEDAD QUE SOLO CONTENGA UN GET)
        /// </summary>
        /// <returns></returns>
        public static PersistenciaAlumnos GetInstancia()
        {
            return _instancia ?? (_instancia = new PersistenciaAlumnos());
        }


        /// <summary>
        /// Ingresa un nuevo usuario en el sistema
        /// </summary>
        /// <param name="u"></param>
        public void NuevoAlumno(Alumno u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spAltaAlumno", conexion, CommandType.StoredProcedure);

       SqlParameter _ci = new SqlParameter("@Ci", u.CI);
            SqlParameter _nombreusuario = new SqlParameter("@NombreUsuario", u.NOMBRE_USUARIO);
            SqlParameter _nombre = new SqlParameter("@Nombre", u.NOMBRE);
            SqlParameter _apellido = new SqlParameter("@Apellido", u.APELLIDO);
            SqlParameter _pass = new SqlParameter("@Pass", u.PASS);
            SqlParameter _foto = new SqlParameter("@Foto", u.FOTO);
            SqlParameter _activo = new SqlParameter("@Activo", u.ACTIVO);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_nombreusuario);
            cmd.Parameters.Add(_nombre);
            cmd.Parameters.Add(_apellido);
            cmd.Parameters.Add(_pass);
            cmd.Parameters.Add(_foto);
            cmd.Parameters.Add(_activo);
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

        public void EliminarAlumno(Alumno u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spEliminarAlumno", conexion, CommandType.StoredProcedure);
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

        public void ModificarAlumno(Alumno u)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spModificarAlumno", conexion, CommandType.StoredProcedure);

            SqlParameter _ci = new SqlParameter("@Ci", u.CI);
            SqlParameter _nombreusuario = new SqlParameter("@NombreUsuario", u.NOMBRE_USUARIO);
            SqlParameter _nombre = new SqlParameter("@Nombre", u.NOMBRE);
            SqlParameter _apellido = new SqlParameter("@Apellido", u.APELLIDO);
            SqlParameter _pass = new SqlParameter("@Pass", u.PASS);
            SqlParameter _foto = new SqlParameter("@Foto", u.FOTO);
            SqlParameter _activo = new SqlParameter("@Activo", u.ACTIVO);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_nombreusuario);
            cmd.Parameters.Add(_nombre);
            cmd.Parameters.Add(_apellido);
            cmd.Parameters.Add(_pass);
            cmd.Parameters.Add(_foto);
            cmd.Parameters.Add(_activo);
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
        /// BUSCA UN ALUMNO EN EL SISTEMA POR SU NOMBRE DE USUARIO
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Alumno BuscarAlumno(string userName)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spBuscarAlumno", conexion, CommandType.StoredProcedure);
            SqlParameter _userName = new SqlParameter("@NombreUsuario", userName);
            cmd.Parameters.Add(_userName);

            SqlDataReader reader;
            Alumno u = null;
            int _ci;
            string _nombreusuario, _nombre, _apellido, _password, _foto;
            bool _activo;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ci = (int)reader["Ci"];
                    _nombre = (string)reader["Nombre"];
                    _nombreusuario = (string)reader["NombreUsuario"];
                    _apellido = (string)reader["Apellido"];
                    _password = (string)reader["Pass"];
                    _foto = (string)reader["foto"];
                    _activo = (bool)reader["Activo"];
                    u = new Alumno
                            {
                                CI = _ci,
                                NOMBRE_USUARIO = _nombreusuario,
                                NOMBRE = _nombre,
                                APELLIDO = _apellido,
                                PASS = _password,
                                ACTIVO = _activo,
                                FOTO = _foto
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

        public Alumno BuscarAlumno(int Ci)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spBuscarAlumnoPorCi", conexion, CommandType.StoredProcedure);
            SqlParameter _Ci = new SqlParameter("@Ci", Ci);
            cmd.Parameters.Add(_Ci);

            SqlDataReader reader;
            Alumno u = null;
            int _ci;
            string _nombreusuario, _nombre, _apellido, _password, _foto;
            bool _activo;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ci = (int)reader["Ci"];
                    _nombre = (string)reader["Nombre"];
                    _nombreusuario = (string)reader["NombreUsuario"];
                    _apellido = (string)reader["Apellido"];
                    _password = (string)reader["Pass"];
                    _foto = (string)reader["foto"];
                    _activo = (bool)reader["Activo"];
                    u = new Alumno
                    {
                        CI = _ci,
                        NOMBRE_USUARIO = _nombreusuario,
                        NOMBRE = _nombre,
                        APELLIDO = _apellido,
                        PASS = _password,
                        ACTIVO = _activo,
                        FOTO = _foto
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


        public Alumno LoginAlumno(string NombreUsuario, string Pass)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spLoginAlumno", conexion, CommandType.StoredProcedure);
            SqlParameter _userName = new SqlParameter("@NombreUsuario", NombreUsuario);
            cmd.Parameters.Add(_userName);
            SqlParameter _passWord = new SqlParameter("@Pass", Pass);
            cmd.Parameters.Add(_passWord);
            SqlDataReader reader;
            Alumno u = null;
            int _ci;
            string _nombreusuario, _nombre, _apellido, _password, _foto;
            bool _activo;

            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ci = (int)reader["Ci"];
                    _nombre = (string)reader["Nombre"];
                    _nombreusuario = (string)reader["NombreUsuario"];
                    _apellido = (string)reader["Apellido"];
                    _password = (string)reader["Pass"];
                    _foto = (string)reader["foto"];
                    _activo = (bool)reader["Activo"];
                    u = new Alumno
                    {
                        CI = _ci,
                        NOMBRE_USUARIO = _nombreusuario,
                        NOMBRE = _nombre,
                        APELLIDO = _apellido,
                        PASS = _password,
                        ACTIVO = _activo,
                        FOTO = _foto
                    };
                }
                reader.Close();

                if (u != null && !u.ACTIVO)
                {
                    throw new ErrorAlumnoBloqueado();
                   
                }
            }
            catch (ErrorAlumnoBloqueado ex)
            {
                throw ex;
            }
            catch (ErrorUsuarioContraseñaIncorrecto ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return u;
        }

        
        /// <summary>
        /// LISTA LOS ALUMNOS DEL SISTEMA SIN ENVIOS DE EMAILS POR UN NUMERO DE DIAS DADO.
        /// </summary>
        /// <param name="NumeroDias"></param>
        /// <returns></returns>
        public List<Alumno> ListarAlumnosSinMovimientos(int NumeroDias)
        {
            List<Alumno> _listaAlumnos = new List<Alumno>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarAlumnosSinMovimientos", conexion, CommandType.StoredProcedure);

            SqlParameter _numeroDias = new SqlParameter("@NumeroDias", NumeroDias);
            cmd.Parameters.Add(_numeroDias);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                int _ci;
                string _nombreUsuario, _nombre, _apellido, _pass, _foto;
                bool _activo;

                while (_Reader.Read())
                {
                    _ci = (int)_Reader["Ci"];
                    _nombreUsuario = (string)_Reader["NombreUsuario"];
                    _nombre = (string)_Reader["Nombre"];
                    _apellido = (string)_Reader["Apellido"];
                    _pass = (string)_Reader["Pass"];
                    _foto = (string)_Reader["Foto"];
                    _activo = (bool)_Reader["Activo"];

                    Alumno a = new Alumno
                                   {
                                       CI = _ci,
                                       NOMBRE_USUARIO = _nombreUsuario,
                                       PASS = _pass,
                                       NOMBRE = _nombre,
                                       FOTO = _foto,
                                       APELLIDO = _apellido,
                                       ACTIVO = _activo

                                   };

                    _listaAlumnos.Add(a);
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

            return _listaAlumnos;
        }


        public List<Alumno> ListarAlumno()
        {
            List<Alumno> _listaAlumnos = new List<Alumno>();

            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spListarAlumnos", conexion, CommandType.StoredProcedure);

            SqlDataReader _Reader;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                _Reader = cmd.ExecuteReader();
                int _ci, _cantidadEnviados, _cantidadRecibidos;
                string _nombreUsuario, _nombre, _apellido, _pass, _foto;
                bool _activo;

                while (_Reader.Read())
                {
                    _ci = (int)_Reader["Ci"];
                    _nombreUsuario = (string)_Reader["NombreUsuario"];
                    _nombre = (string)_Reader["Nombre"];
                    _apellido = (string)_Reader["Apellido"];
                    _pass = (string)_Reader["Pass"];
                    _foto = (string)_Reader["Foto"];
                    _activo = (bool)_Reader["Activo"];
                    _cantidadEnviados = (int)_Reader["cantEnviados"];
                    _cantidadRecibidos = (int)_Reader["cantRecibidos"];

                    Alumno a = new Alumno
                    {
                        CI = _ci,
                        NOMBRE_USUARIO = _nombreUsuario,
                        PASS = _pass,
                        NOMBRE = _nombre,
                        FOTO = _foto,
                        APELLIDO = _apellido,
                        ACTIVO = _activo,
                        CANTIDADRECIBIDOS = _cantidadRecibidos,
                        CANTIDADENVIADOS = _cantidadEnviados,

                    };

                    _listaAlumnos.Add(a);
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

            return _listaAlumnos;
        }

       /// <summary>
        /// ACTUALIZA EL STATUS DE ACTIVO DE UN ALUMNO 
       /// </summary>
       /// <param name="a"></param>
        public void ActualizarStatusAlumno(Alumno a)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = Conexion.GetCommand("spActualiarStatusAlumno", conexion, CommandType.StoredProcedure);

            SqlParameter _ci = new SqlParameter("@ci", a.CI);
            SqlParameter _statusAlumno = new SqlParameter("@SetStatus", a.ACTIVO);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(_ci);
            cmd.Parameters.Add(_statusAlumno);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

                if (Convert.ToInt32(_retorno.Value) == -1)
                {
                    throw new ErrorAlumnoNoExiste();
                }
            }
            catch (ErrorAlumnoNoExiste ex)
            {
                throw ex;
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
