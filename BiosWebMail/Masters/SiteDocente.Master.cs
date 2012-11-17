using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
using ExcepcionesPersonalizadas;

namespace BiosWebMail
{
    public partial class SiteDocente : System.Web.UI.MasterPage
    {

        public Usuario USUARIO_LOGUEADO
        {
            get
            {
                if (Session["Usuario"] == null)
                    return null;
                return (Usuario)Session["Usuario"];
            }
            set
            {
                if (Session["Usuario"] == null)
                    Session.Add("Usuario", value);
                else
                    Session["Usuario"] = value;
            }
        }

        public void SessionEnded()
        {

            Session.Abandon();
            Response.Redirect("~/index.aspx");


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (!IsPostBack)
                {
                    if (Session["Usuario"] == null) //si no existe el session["Login"], 
                    {

                        SessionEnded();
                    }

                    lblLogueadoComo.Text = "Bienvenido " + USUARIO_LOGUEADO.NOMBRE_USUARIO + " - " +
                                               "Tipo de usuario: " +
                                               "Docente";
                }
            }

            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }


        }

    
        protected void btnLogout_Click(object sender, EventArgs e)
        {
           SessionEnded();
            Response.Redirect("~/index.aspx");
        }
    }
}