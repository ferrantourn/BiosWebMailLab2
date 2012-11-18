using System.Collections.Generic;
using Entidades;

namespace Persistencia
{
    public interface IPersistenciaEmails
    {
        void NuevoEmail (Email e);
        List<Email> ListarEmails(Carpeta carpeta);
        void EliminarEmail(Email e, Carpeta c);
        Email GetEmail(Email e);
        void MarcarEmailLeido(Email e, Carpeta c);
        void MoverEmail(Email e, Carpeta carpetaActual, Carpeta carpetaDestino);
        List<Email> ListarEmailsEnviados(Carpeta c);
        List<Email> ListarEmailsRecibidos(Carpeta c);
    }
}
