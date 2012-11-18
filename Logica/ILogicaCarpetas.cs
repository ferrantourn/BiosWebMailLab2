using System.Collections.Generic;
using Entidades;

namespace Logica
{
    public interface ILogicaCarpetas
    {
        void AgregarCarpeta(Carpeta c);
        List<Carpeta> ListarCarpetas(Alumno a);
        //void EliminarCarpeta(int numeroCarpeta);
        void EliminarCarpeta(Carpeta c);

        //Carpeta getInboxFolder(int ciAlumno);
        Carpeta getInboxFolder(Alumno a);

        bool IsCarpetaSistema(Carpeta c);
        //Carpeta GetCarpeta(int numCarpeta, int ci);
        Carpeta GetCarpeta(Carpeta c);

    }
}
