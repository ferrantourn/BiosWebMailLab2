using System;
using System.Windows.Forms;
using BiosWebMail.refServiceWebMail;

namespace BiosWebMailWindows
{
    public partial class ActivarCuenta : Form
    {
        public ActivarCuenta()
        {
            InitializeComponent();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //VAMOS A BUSCAR LA INFORMACION DEL USUARIO INGRESADO
                //---------------------------------------------------
                //ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                ServiceWebMail sm = new ServiceWebMail();
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    Alumno a = new Alumno {CI = ci};
                    a = sm.getAlumno(a);
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

       

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceWebMail sm = new ServiceWebMail();

                //ACTIVAMOS EL USUARIO
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    Alumno a = new Alumno {CI = ci};
                    sm.ActualizarStatusAlumno(a, true);
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
