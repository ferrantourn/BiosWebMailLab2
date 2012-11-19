using System.Collections.Generic;
using System.Web.Services;
using Entidades;
using Logica;


namespace WebMailWS
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://WebMailWS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceWebMail : WebService
    {
        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        #region WEB METHODS DE CARPETA
        [WebMethod]
        public void AgregarCarpeta(Carpeta c)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            lc.AgregarCarpeta(c);
        }

        [WebMethod]
        public List<Carpeta> ListarCarpetas(Alumno a)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            return lc.ListarCarpetas(a);
        }

        [WebMethod]
        public void EliminarCarpeta(Carpeta c)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            lc.EliminarCarpeta(c);
        }


        [WebMethod]
        public Carpeta getInboxFolder(Alumno a)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            return lc.getInboxFolder(a);
        }

        [WebMethod]
        public bool IsCarpetaSistema(Carpeta c)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            return lc.IsCarpetaSistema(c);
        }

        [WebMethod]
        public Carpeta GetCarpeta(Carpeta c)
        {
            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
            return lc.GetCarpeta(c);
        }

        #endregion


        #region WEB METHODS DE EMAILS
        [WebMethod]
        public void AgregarEmail(Email newEmail, Alumno remitente, Alumno destinatario)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            le.AgregarEmail(newEmail, remitente, destinatario);
        }

        [WebMethod]
        public List<Email> ListarEmail(Carpeta c)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            return le.ListarEmail(c);
        }

        [WebMethod]
        public Email GetEmail(Email e)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            return le.GetEmail(e);
        }

        [WebMethod]
        public void EliminarEmail(Email e, Carpeta carpeta)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            le.EliminarEmail(e, carpeta);
        }

        [WebMethod]
        public void MarcarEmailLeido(Email e, Carpeta c)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            le.MarcarEmailLeido(e, c);
        }

        [WebMethod]
        public void MoverEmail(Email e, Carpeta carpetaActual, Carpeta carpetaDestino)
        {
            ILogicaEmails le = FabricaLogica.getLogicaEmails();
            le.MoverEmail(e, carpetaActual, carpetaDestino);
        }

        #endregion


        #region WEB METHODS DE USUARIO
        [WebMethod]
        public Alumno getAlumno(Alumno a)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.getAlumno(a);
        }

        [WebMethod]
        public Alumno getAlumnoByCi(int ci)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.getAlumno(ci);
        }

        [WebMethod]
        public Docente getDocente(Docente d)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.getDocente(d);
        }

        [WebMethod]
        public void NuevoAlumno(Alumno a)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            le.NuevoAlumno(a);
        }

        [WebMethod]
        public void NuevoDocente(Docente d)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            le.NuevoDocente(d);
        }

        [WebMethod]
        public Usuario getLoginUsuario(string userName, string pass)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.getLoginUsuario(userName, pass);
        }

        [WebMethod]
        public List<Alumno> ListarAlumnosSinMovimientos(int NumeroDias)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.ListarAlumnosSinMovimientos(NumeroDias);
        }

        [WebMethod]
        public List<Docente> ListarDocentes()
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.ListarDocentes();
        }


        [WebMethod]
        public List<Alumno> ListarAlumnos()
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            return le.ListarAlumnos();
        }

        [WebMethod]
        public void ActualizarStatusAlumno(Alumno a, bool setActiveStatus)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            le.ActualizarStatusAlumno(a, setActiveStatus);
        }

        [WebMethod]
        public void ModificarAlumno(Alumno a)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            le.ModificarAlumno(a);
        }

        [WebMethod]
        public void ModificarDocente(Docente d)
        {
            ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
            le.ModificarDocente(d);
        }


        #endregion
    }
}