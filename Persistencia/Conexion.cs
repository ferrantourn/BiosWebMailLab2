using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Persistencia.Properties;

namespace Persistencia
{
    public class Conexion
    {
        private static string _cnn = Settings.Default.PersistenciaConnString;

        public static string Cnn
        {
            get { return _cnn; }
        }

        /// <summary>
        /// Obtiene el comando de conexion ya configurado con las variables
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static SqlCommand GetCommand(string commandText,SqlConnection conexion, CommandType commandType)
        {
            SqlCommand cmd = new SqlCommand(commandText, conexion);
            cmd.CommandType = commandType;
            return cmd;
        }
    }
}
