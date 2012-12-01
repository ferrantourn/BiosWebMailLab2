using System.Collections.Generic;
using System;

namespace Entidades
{
    [Serializable]
    public class Alumno : Usuario
    {
        private List<Carpeta> _listaCarpetas;
        public List<Carpeta> LISTA_CARPETAS
        {
            get { return _listaCarpetas; }
            set { _listaCarpetas = value; }
        }

        private string _foto;
        public string FOTO
        {
            get { return _foto; }
            set { _foto = value; }
        }

        private bool _activo;
        public bool ACTIVO
        {
            get { return _activo; }
            set { _activo = value; }
        }
        private int _cantidadEnviados;
        public int CANTIDADENVIADOS
        {
            get { return _cantidadEnviados; }
            set { _cantidadEnviados = value; }
        }
        private int _cantidadRecividos;
        public int CANTIDADRECIBIDOS
        {
            get { return _cantidadRecividos; }
            set { _cantidadRecividos = value; }
        }

        public Alumno()
        {

        }

        public Alumno(List<Carpeta> listaCarpetas, string foto, bool activo, int cantidadEnviados, int cantidadRecibidos, int ci, string nombreUsuario, string nombre,
            string apellido, string pass)
            : base(ci, nombreUsuario, nombre, apellido, pass)
        {
            LISTA_CARPETAS = listaCarpetas;
            FOTO = foto;
            ACTIVO = activo;
            CI = ci;
            NOMBRE_USUARIO = nombreUsuario;
            NOMBRE = nombre;
            APELLIDO = apellido;
            PASS = pass;
            CANTIDADENVIADOS = cantidadEnviados;
            CANTIDADRECIBIDOS = cantidadRecibidos;
        }
    }
}
