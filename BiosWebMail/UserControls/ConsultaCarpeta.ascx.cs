using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

namespace BiosWebMail.UserControls
{
    public partial class ConsultaCarpeta : System.Web.UI.UserControl
    {
        public Carpeta CARPETA
        {
            get
            {
                if (Session["Carpeta"] == null)
                {
                    Session.Add("Carpeta", new Carpeta());
                }

                return (Carpeta)Session["Carpeta"];
            }
            set
            {
                if (Session["Carpeta"] == null)
                {
                    Session.Add("Carpeta", value);
                }
                Session["Carpeta"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "";
        }


        protected void EmailListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                ILogicaEmails le = FabricaLogica.getLogicaEmails();
                if (e.CommandName.ToUpper() == "VER")
                {
                    //OBTENEMOS EL EMAIL
                    //------------------
                    if (Session["EmailId"] == null)
                    {
                        Session.Add("EmailId", e.CommandArgument);
                    }
                    else
                    {
                        Session["EmailId"] = e.CommandArgument;
                    }
                    //MARCAR EMAIL COMO LEIDO
                    //-----------------------
                    le.MarcarEmailLeido(Convert.ToInt32(e.CommandArgument), CARPETA.NUMERO_CARPETA);

                    Response.Redirect("~/AdminAlumno/Email.aspx", false);
                }
                else if (e.CommandName.ToUpper() == "ELIMINAR")
                {
                    le.EliminarEmail(Convert.ToInt32(e.CommandArgument), CARPETA.NUMERO_CARPETA, ((Alumno)Session["Usuario"]).CI);
                    lblInfo.Text = "Email eliminado";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                //CARGA EL TITULO DE LA CARPETA
                lblFolderName.Text = CARPETA.NOMBRE_CARPETA;


                //CARGA LOS EMAILS EN FUNCION DE LA PROPIEDAD CODIGO_CARPETA
                //----------------------------------------------------------
                ILogicaEmails le = FabricaLogica.getLogicaEmails();
                EmailListRepeater.DataSource = le.ListarEmail(CARPETA.NUMERO_CARPETA,((Alumno)Session["Usuario"]).CI);
                EmailListRepeater.DataBind();


            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void EmailListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    //-- Creo el objeto que tiene los datos de la ROW del Listview
                    //----------------------------------------------------------------
                    RepeaterItem dataItem = e.Item;
                    Entidades.Email data = (Entidades.Email)dataItem.DataItem;
                    //EMAIL --- REDUCIMOS EL CAMPO SI SUPERA UN NUMERO DADO DE CARACTERES
                    //-----------------------------------------------------------------------------
                    if (!String.IsNullOrEmpty(data.ASUNTO) && data.ASUNTO.Count() > 60)
                    {
                        //tiene mas de 60 caracteres
                        //--------------------------
                        ((Label)dataItem.FindControl("lblAsunto")).Text = data.ASUNTO.Substring(0, 60) + "...";
                    }

                    if (data.LEIDO)
                    {
                        ((Image)dataItem.FindControl("imageState")).ImageUrl = "~/Images/EmailLeido.png";
                    }
                    else
                    {
                        ((Image)dataItem.FindControl("imageState")).ImageUrl = "~/Images/EmailNoLeido.png";
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