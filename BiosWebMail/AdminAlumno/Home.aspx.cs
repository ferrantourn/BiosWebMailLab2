using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

namespace BiosWebMail
{
    public partial class _Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblInfo.Text = "";
                Session["EmailId"] = null;

                if (!IsPostBack)
                {
                    //CARGAMOS NOMBRE DE USUARIO LOGUEADO
                    //-----------------------------------

                    //CARGAMOS CARPETAS DE USUARIO LOGUEADO
                    //-------------------------------------
                    RefreshFolders();

                    //CARGAMOS CARPETA INBOX DEL USUARIO LOGUEADO POR DEFECTO
                    //-------------------------------------------------------
                    ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                    SiteAlumno master = (SiteAlumno)Master;
                    if (master != null && master.USUARIO_LOGUEADO != null)
                    {
                        //Carpeta inbox = lc.getInboxFolder(master.USUARIO_LOGUEADO.CI);
                        Carpeta inbox = lc.getInboxFolder(master.USUARIO_LOGUEADO);

                        if (inbox != null)
                            ConsultaCarpeta.CARPETA = inbox;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnNuevaCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNuevaCarpetaNombre.Text))
                {
                    ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                    Carpeta c = new Carpeta();
                    SiteAlumno master = (SiteAlumno)Master;
                    c.NOMBRE_CARPETA = txtNuevaCarpetaNombre.Text;
                    c.USUARIO = master.USUARIO_LOGUEADO;
                    lc.AgregarCarpeta(c);

                    RefreshFolders();
                    lblInfo.Text = "Carpeta creada";
                    txtNuevaCarpetaNombre.Text = "";
                }
                else
                {
                    lblInfo.Text = "Ingrese un nombre de carpeta";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            RefreshFolders();
        }


        public void RefreshFolders()
        {
            try
            {
                ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                SiteAlumno master = (SiteAlumno)Master;
                if (master != null)
                {
                    FolderListRepeater.DataSource = lc.ListarCarpetas((Alumno)master.USUARIO_LOGUEADO);
                    FolderListRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void FolderListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();

                if (e.CommandName.ToUpper() == "CONSULTAR")
                {
                    //TRAEMOS TODOS LOS EMAILS DE ESA CARPETA
                    //---------------------------------------
                    //Carpeta currentFolder = lc.GetCarpeta(Convert.ToInt32(e.CommandArgument),((Alumno) Session["Usuario"]).CI);
                    Carpeta c = new Carpeta
                                    {
                                        NUMERO_CARPETA = Convert.ToInt32(e.CommandArgument),
                                        USUARIO = ((Alumno) Session["Usuario"])
                                    };
                    Carpeta currentFolder = lc.GetCarpeta(c);

                    ConsultaCarpeta.CARPETA = currentFolder;
                }
                else if (e.CommandName.ToUpper() == "ELIMINAR")
                {

                    //ELIMINAMOS LA CARPETA SELECCIONADA
                    //----------------------------------
                    Carpeta c = new Carpeta();
                    c.NUMERO_CARPETA = Convert.ToInt32(e.CommandArgument);
                    //lc.EliminarCarpeta(Convert.ToInt32(e.CommandArgument));
                    lc.EliminarCarpeta(c);

                    lblInfo.Text = "Carpeta Eliminada";
                    RefreshFolders();
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void FolderListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    //-- Creo el objeto que tiene los datos de la ROW del Listview
                    //----------------------------------------------------------------
                    RepeaterItem dataItem = e.Item;
                    Carpeta folder = (Carpeta)dataItem.DataItem;
                    ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                    if (lc.IsCarpetaSistema(folder))
                    {
                        dataItem.FindControl("lnkEliminar").Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }


    }
}