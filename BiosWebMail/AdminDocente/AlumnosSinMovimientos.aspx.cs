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
    public partial class AlumnosSinMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.ToString();
            }

        }

        protected void UsersListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper() == "DESACTIVAR")
                {
                    ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                    Alumno a = new Alumno();
                    a.CI = Convert.ToInt32(e.CommandArgument);
                    lu.ActualizarStatusAlumno(a, false);
                    lblInfo.Text = "Alumno desactivado";
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
                if (!string.IsNullOrEmpty(txtNumDias.Text))
                {
                    ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                    int numDias;
                    if (Int32.TryParse(txtNumDias.Text, out numDias))
                    {
                        UsersListRepeater.DataSource = lu.ListarAlumnosSinMovimientos(numDias);
                        UsersListRepeater.DataBind();
                    }
                    else
                    {
                        lblInfo.Text = "El numero de dias ingresado no es valido";
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