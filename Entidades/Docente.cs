using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Docente : Usuario
    {
        private List<string> _materias;
        public List<string> MATERIAS
        {
            get { return _materias; }
            set
            {
                _materias = value;
            }
        }

        public Docente()
        { }

        public Docente(List<string> materias)
        {
            MATERIAS = materias;
        }

        public Docente(List<string> materias, int ci, string nombreUsuario, string nombre,
            string apellido, string pass)
            : base(ci, nombreUsuario, nombre, apellido, pass)
        {
            MATERIAS = materias;
            CI = ci;
            NOMBRE_USUARIO = nombreUsuario;
            NOMBRE = nombre;
            APELLIDO = apellido;
            PASS = pass;
        }

        public string MateriasToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in MATERIAS)
            {
                sb.AppendFormat("{0},", s);
            }

            return sb.ToString();
        }

    }
}
