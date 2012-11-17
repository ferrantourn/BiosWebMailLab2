using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface IPersistenciaEmails
    {
        void NuevoEmail (Email e);
        List<Email> ListarEmails(int numeroCarpeta);
        void EliminarEmail(int NumeroEmail, int numCarpeta);
        Email GetEmail(int numeroEmail);
        void MarcarEmailLeido(int NumeroEmail, int numeroCarpeta);
        void MoverEmail(int NumeroEmail, int numCarpetaActual, int numCarpetaDestino);
        List<Email> ListarEmailsEnviados(int numeroCarpeta);
        List<Email> ListarEmailsRecibidos(int numeroCarpeta);
    }
}
