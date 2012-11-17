using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface    IPersistenciaCarpetas
    {
        void NuevaCarpeta(Carpeta c);
        Carpeta BuscarCarpetaSistemaAlumno (int ciAlumno, string nombreCarpetaSistema);
        Carpeta BuscarCarpetaAlumno(int ciAlumno, int numCarpeta);
        List<Carpeta> ListarCarpetasAlumno(int ciAlumno);
        void EliminarCarpeta(int numeroCarpeta);
    }
}
