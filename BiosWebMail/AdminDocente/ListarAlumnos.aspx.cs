using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;


namespace BiosWebMail
{
    public partial class ListarAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //Control de acceso.
        {
            lblInfo.Text = "";
        }

        protected void Page_PreRender(object sender, EventArgs e) //Control de acceso.
        {
            try
            {
                ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                UsersListRepeater.DataSource = lu.ListarAlumnos();
                UsersListRepeater.DataBind();
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }


        protected void UsersListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper() == "EDITAR")
                {
                    ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                    Alumno a = lu.getAlumno(Convert.ToInt32(e.CommandArgument));
                    if (a != null)
                    {
                        if (Session["EditarUsuario"] == null)
                            Session.Add("EditarUsuario", null);

                        Session["EditarUsuario"] = a;

                        Response.Redirect("~/AdminDocente/Usuarios.aspx", false);
                    }
                    else
                    {
                        lblInfo.Text = "Alumno no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.ToString();
            }
        }



    }
}