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
    public partial class ActivarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //Control de acceso.
        {
            try
            {

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.ToString();
            }

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //VAMOS A BUSCAR LA INFORMACION DEL USUARIO INGRESADO
                //---------------------------------------------------
                ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    Alumno a = lu.getAlumno(ci);
                    if (a != null)
                    {
                        PanelUsuario.Visible = true;
                        lblUserName.Text = a.NOMBRE_USUARIO;
                        lblStatus.Text = a.ACTIVO.ToString().Trim() == "True" ? "Si" : "No";
                        lblDocumento.Text = Convert.ToString(a.CI);
                        lblNombreAlumno.Text = a.NOMBRE + " " + a.NOMBRE_USUARIO;
                        btnActivar.Visible = !a.ACTIVO;
                    }
                    else
                    {
                        PanelUsuario.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }


        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //ACTIVAMOS EL USUARIO
                ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    Alumno a = new Alumno();
                    a.CI = ci;
                    lu.ActualizarStatusAlumno(a, true);
                    lblInfo.Text = "Alumno activado!";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}