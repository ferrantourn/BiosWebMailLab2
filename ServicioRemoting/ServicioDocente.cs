using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioDocente
    {
        //atributo que representa un objeto de la fachadalogicaremota. 
        private Persistencia.IPersistenciaDocentes unaPersistencia;

     //constructor del servicio
        public ServicioDocente()
        {
            Servicio.CreoServicio();
            unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaDocentes();
        }

        //operaciones
        public void Alta(Entidades.Docente unDocente)
        {
            unaPersistencia.NuevoDocente(unDocente);
        }

        public void Baja(Entidades.Docente unDocente)
        {
            unaPersistencia.EliminarDocente(unDocente);
        }

        public void Modificar(Entidades.Docente unDocente)
        {
            unaPersistencia.ModificarDocente(unDocente);
        }

        public Entidades.Docente Buscar(string userName)
        {
            return unaPersistencia.BuscarDocente(userName);
        }

        public List<Entidades.Docente> Listar()
        {
            return unaPersistencia.ListarDocentes();
        }

        public Entidades.Docente LoginDocente(string userName, string passWord)
        {
            return unaPersistencia.LoginDocente(userName,passWord);
        }

    }
}
