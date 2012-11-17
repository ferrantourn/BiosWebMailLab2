using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Logica
{
    public interface ILogicaEmails
    {
        void AgregarEmail(string asunto, string cuerpo, Alumno Remitente, string userNameDestinatario);
        List<Email> ListarEmail(int numeroCarpeta, int ci);
        Email GetEmail(int numeroEmail);
        void EliminarEmail(int numeroEmail, int NumeroCarpeta, int ciAlumno);
        void MarcarEmailLeido(int NumeroEmail, int numeroCarpeta);
        void MoverEmail(int numeroEmail, int NumeroCarpetaActual, int numeroCarpetaDestino);
    }
}
