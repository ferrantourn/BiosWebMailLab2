using System;
using System.Windows.Forms;
using BiosWebMailWindows.refServiceWebMailWin;
namespace BiosWebMailWindows
{
    public partial class ActivarCuenta : Form
    {
        public ActivarCuenta()
        {
            InitializeComponent();
        }

        private void ActivarCuenta_Load(object sender, EventArgs e)
        {
            try
            {
                PanelUsuario.Visible = false;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                //VAMOS A BUSCAR LA INFORMACION DEL USUARIO INGRESADO
                //---------------------------------------------------
                //ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                ServiceWebMail sm = new ServiceWebMail();
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    //Alumno a = new Alumno {CI = ci};
                    Alumno a = sm.getAlumnoByCi(ci);
                    if (a != null)
                    {
                        PanelUsuario.Visible = true;
                        lblUserName.Text = a.NOMBRE_USUARIO;
                        lblStatus.Text = a.ACTIVO.ToString().Trim() == "True" ? "Activo" : "No Activo";
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
                lblInfo.Text = "";
                ServiceWebMail sm = new ServiceWebMail();

                //ACTIVAMOS EL USUARIO
                int ci;
                if (Int32.TryParse(txtDocumento.Text, out ci))
                {
                    Alumno a = new Alumno { CI = ci };
                    sm.ActualizarStatusAlumno(a, true);
                    lblStatus.Text = "Activo";
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
