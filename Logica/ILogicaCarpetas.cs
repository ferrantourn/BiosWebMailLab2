using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Logica
{
    public interface ILogicaCarpetas
    {
        void AgregarCarpeta(Carpeta c);
        List<Carpeta> ListarCarpetas(Alumno a);
        void EliminarCarpeta(int numeroCarpeta);
        Carpeta getInboxFolder(int ciAlumno);
        bool IsCarpetaSistema(Carpeta c);
        Carpeta GetCarpeta(int numCarpeta, int ci);
    }
}
