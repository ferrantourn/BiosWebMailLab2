using System.Collections.Generic;
using Entidades;

namespace Logica
{
    public interface ILogicaEmails
    {
        void AgregarEmail(Email newEmail,Alumno remitente, Alumno destinatario);
        List<Email> ListarEmail(Carpeta c);

        Email GetEmail(Email e);

        void EliminarEmail(Email e, Carpeta carpeta);

        void MarcarEmailLeido(Email e, Carpeta c);
        void MoverEmail(Email e, Carpeta carpetaActual, Carpeta carpetaDestino);
    }
}
