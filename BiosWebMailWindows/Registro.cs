using System;
using System.Linq;
using System.Windows.Forms;
using BiosWebMailWindows.refServiceWebMailWin;

namespace BiosWebMailWindows
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        public Docente DOCENTE { get; set; }

        private void Registro_Load(object sender, EventArgs e)
        {
            if (DOCENTE != null)
            {
                lblHeader.Text = "Editar Docente";
                btnRegistrar.Text = "Actualizar";

                txtUserName.Text = DOCENTE.NOMBRE_USUARIO;
                txtNombre.Text = DOCENTE.NOMBRE;
                txtApellido.Text = DOCENTE.APELLIDO;
                txtDocumento.Text = Convert.ToString(DOCENTE.CI);
                passwordControl.PASSWORD = DOCENTE.PASS;
                txtDocumento.Enabled = false;

                controlMaterias.MATERIAS = DOCENTE.MATERIAS;
                //foreach (string s in DOCENTE.MATERIAS)
                //{
                //    txtMateriasDesc.Text = txtMateriasDesc.Text + ", " + s;
                //}
            }
        }

        private void ClearForm()
        {
            txtUserName.Text = "";
            txtNombre.Text = "";
            controlMaterias.MATERIAS = null;
            txtDocumento.Text = "";
            txtApellido.Text = "";
            passwordControl.ClearPasswords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";

                if (DOCENTE != null)
                {
                    DOCENTE.APELLIDO = txtApellido.Text;
                    DOCENTE.NOMBRE = txtNombre.Text;
                    DOCENTE.NOMBRE_USUARIO = txtUserName.Text;
                    DOCENTE.MATERIAS = controlMaterias.MATERIAS;
                    DOCENTE.PASS = passwordControl.PASSWORD;

                    ServiceWebMail sm = new ServiceWebMail();
                    sm.ModificarDocente(DOCENTE);

                    lblInfo.Text = "Informacion actualizada";
                }
                else
                {


                    lblInfo.Text = "";
                    Docente d = new Docente
                                    {
                                        APELLIDO = txtApellido.Text,
                                        CI = Convert.ToInt32(txtDocumento.Text),
                                        NOMBRE_USUARIO = txtUserName.Text,
                                        MATERIAS = controlMaterias.MATERIAS,
                                        NOMBRE = txtNombre.Text,
                                        PASS = passwordControl.PASSWORD
                                    };

                    ServiceWebMail sm = new ServiceWebMail();

                    sm.NuevoDocente(d);

                    lblInfo.Text = "Impeca!!, fuiste registrado.";
                    ClearForm();
                }

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void btnRegistrar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                errorProviderRegistro.SetError(txtNombre, "Debe ingresar un nombre.");
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                errorProviderRegistro.SetError(txtApellido, "Debe ingresar un apellido.");
            }

            if (String.IsNullOrEmpty(txtDocumento.Text))
            {
                errorProviderRegistro.SetError(txtApellido, "Debe ingresar un apellido.");
            }
        }





    }
}
