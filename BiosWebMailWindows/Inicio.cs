using System;
using System.Windows.Forms;
using BiosWebMailWindows.refServiceWebMailWin;

namespace BiosWebMailWindows
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnLoguearse_Click(object sender, EventArgs e)
        {
            try
            {
                //ILogicaUsuario LogicaUsuario = FabricaLogica.getLogicaUsuario();
                ServiceWebMail sm = new ServiceWebMail();
                //Usuario NuevoUsuario = LogicaUsuario.getLoginUsuario(txtUsuario.Text, txtPass.Text);
                Usuario NuevoUsuario = sm.getLoginUsuario(txtNombreUsuario.Text, txtPassword.Text);

                //USUARIO_LOGUEADO = NuevoUsuario;
                if (NuevoUsuario != null)
                {
                    //if (NuevoUsuario is Alumno)
                    //    Response.Redirect("~/AdminAlumno/home.aspx");
                    if (NuevoUsuario is Docente)
                    {
                        this.Hide();
                        MenuPrincipal menuForm = new MenuPrincipal();
                        menuForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    lblInfo.Text = "El usuario o contraseña ingresados no son validos. Media pila! ...";
                }
            }
            //catch (ErrorAlumnoBloqueado ex)
            //{
            //    lblError.Text =  ex.Message;
            //}
            //catch (ErrorUsuarioContraseñaIncorrecto ex)
            //{
            //    lblError.Text = ex.ToString();
            //}
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}
