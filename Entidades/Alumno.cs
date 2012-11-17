using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
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

        public Alumno()
        {
        }

        public Alumno(List<Carpeta> listaCarpetas, string foto, bool Activo)
        {
            LISTA_CARPETAS = listaCarpetas;
            FOTO = foto;
            ACTIVO = Activo;
        }
    }
}
