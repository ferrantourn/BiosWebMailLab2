using System.Collections.Generic;
using Entidades;

namespace Persistencia
{
    public interface    IPersistenciaCarpetas
    {
        void NuevaCarpeta(Carpeta c);
        Carpeta BuscarCarpetaSistemaAlumno(Carpeta carpeta);
        Carpeta BuscarCarpetaAlumno(Carpeta c);
        List<Carpeta> ListarCarpetasAlumno(Alumno a);
        void EliminarCarpeta(Carpeta c);
    }
}
