using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioEmails
    {
        //atributo que representa un objeto de la fachadalogicaremota. 
        private Persistencia.IPersistenciaEmails unaPersistencia;

        //constructor del servicio
        public ServicioEmails()
        {
            //se crea el servicio para uso del remoting
            Servicio.CreoServicio();

            //creo mi objeto fachada para trabajar en todas las operaciones que brinda el servicio
            unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaEmails();
        }

        //operaciones
        public NuevoEmail(Entidades.Email e)
        {
            unaPersistencia.NuevoEmail(e);
        }

        public MoverEmail(Entidades.Email e, Entidades.Carpeta carpetaActual, Entidades.Carpeta carpetaDestino)
        {
            unaPersistencia.MoverEmail(e,carpetaActual,carpetaDestino);
        }
        public MarcarEmailLeido(Entidades.Email e, Entidades.Carpeta carpeta)
        {
            unaPersistencia.MarcarEmailLeido(e,carpeta);
        }
        public List<Entidades.Email> ListarEmails(Entidades.Carpeta carpeta)
        {
            return unaPersistencia.ListarEmails(carpeta);
        }
        public List<Entidades.Email> ListarEmailsEnviados(Entidades.Carpeta carpeta)
        {
            return unaPersistencia.ListarEmailsEnviados(carpeta);
        }
        public List<Entidades.Email> ListarEmailsRecibidos(Entidades.Carpeta carpeta)
        {
            return unaPersistencia.ListarEmailsRecibidos(carpeta);
        }
        public Entidades.Email GetEmail(Entidades.Email e)
        {
            return unaPersistencia.GetEmail(e);
        }
        public void EliminarMail(Entidades.Email e, Entidades.Carpeta carpeta)
        {
            unaPersistencia.EliminarEmail(e, carpeta);
        }


        
        





    }
}
