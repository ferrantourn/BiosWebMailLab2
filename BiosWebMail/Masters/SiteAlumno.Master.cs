using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
using ExcepcionesPersonalizadas;

namespace BiosWebMail
{
    public partial class SiteAlumno : System.Web.UI.MasterPage
    {

        public Alumno USUARIO_LOGUEADO
        {
            get
            {
                if (Session["Usuario"] == null)
                    return null;
                return (Alumno)Session["Usuario"];
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
                    else
                    {

                        string pictureName = Convert.ToString(((Alumno)Session["Usuario"]).FOTO);
                        if (string.IsNullOrEmpty(pictureName))
                        {
                            imgUser.ImageUrl = ConfigurationManager.AppSettings["ImagesFolder"] + "userDefaultPicture.png";
                        }
                        else
                        {
                            imgUser.ImageUrl = ConfigurationManager.AppSettings["ImagesFolder"] + pictureName;

                        }

                        lblLogueadoComo.Text = ((Alumno) Session["Usuario"]).NOMBRE_USUARIO;
                    }
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