using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
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
