using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface IPersistenciaDocentes
    {
        void NuevoDocente(Docente u);
        void EliminarDocente(Docente u);
        Docente BuscarDocente(string userName);
        Docente LoginDocente(string NombreUsuario, string Pass);
        void ModificarDocente(Docente u);
        List<Docente> ListarDocentes();
    }
}
