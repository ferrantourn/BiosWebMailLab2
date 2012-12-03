using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioCarpeta
    {
        //atributo que representa un objeto de la fachadalogicaremota. 
        private Persistencia.IPersistenciaCarpetas unaPersistencia;
        
         //constructor del servicio
        public ServicioCarpeta()
        {
            //se crea el servicio para uso del remoting
            Servicio.CreoServicio();

            //creo mi objeto fachada para trabajar en todas las operaciones que brinda el servicio
            unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaCarpetas();
        }

        //operaciones
        public Entidades.Carpeta BuscarCarpetaAlumno(Entidades.Carpeta carpeta)
        {
            return unaPersistencia.BuscarCarpetaAlumno(carpeta);
        }

        public Entidades.Carpeta BuscarCarpetaSistemaAlumno(Entidades.Carpeta carpeta)
        {
            return unaPersistencia.BuscarCarpetaSistemaAlumno(carpeta);
        }
        public void EliminarCarpeta(Entidades.Carpeta carpeta)
        {
            unaPersistencia.EliminarCarpeta(carpeta);
        }

        public List<Entidades.Carpeta> ListarCarpetasAlumno(Entidades.Alumno alumno)
        {
            return unaPersistencia.ListarCarpetasAlumno(alumno);
        }
        
        public void NuevaCarpeta(Entidades.Carpeta carpeta)
        {
            unaPersistencia.NuevaCarpeta(carpeta);
        }

    }
}
