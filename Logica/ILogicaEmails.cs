using System.Collections.Generic;
using Entidades;

namespace Logica
{
    public interface ILogicaEmails
    {
        //void AgregarEmail(string asunto, string cuerpo, Alumno Remitente, string userNameDestinatario);
        void AgregarEmail(Email newEmail,Alumno remitente, Alumno destinatario);

       // List<Email> ListarEmail(int numeroCarpeta, int ci);
        List<Email> ListarEmail(Carpeta c);

        //Email GetEmail(int numeroEmail);
        Email GetEmail(Email e);

        //void EliminarEmail(int numeroEmail, int NumeroCarpeta, int ciAlumno);
        void EliminarEmail(Email e, Carpeta carpeta);

        void MarcarEmailLeido(Email e, Carpeta c);
        void MoverEmail(Email e, Carpeta carpetaActual, Carpeta carpetaDestino);
    }
}
