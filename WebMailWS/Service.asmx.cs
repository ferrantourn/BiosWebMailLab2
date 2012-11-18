using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class Service : WebService
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

        #endregion


        #region WEB METHODS DE USUARIO

        #endregion
    }
}