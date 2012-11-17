using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario
    {
        #region ATRIBUTOS Y PROPIEDADES

        private int _ci;
        public int CI
        {
            get { return _ci; }
            set { _ci = value; }
        }


        private string _nombreUsuario;
        public string NOMBRE_USUARIO
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        private string _nombre;
        public string NOMBRE
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;
        public string APELLIDO
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _pass;
        public string PASS
        {
            get { return _pass; }
            set { _pass = value; }
        }

       

        #endregion

        public Usuario()
        {
            
        }

        public Usuario(int ci, string NombreUsuario, string Nombre, string Apellido, string Pass)
        {
            CI = ci;
            NOMBRE_USUARIO = NombreUsuario;
            NOMBRE = Nombre;
            APELLIDO = Apellido;
            PASS = Pass;
        }
    }
}
