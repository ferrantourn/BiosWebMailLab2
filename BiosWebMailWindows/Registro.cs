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

        private void ClearForm()
        {
            txtUserName.Text = "";
            txtNombre.Text = "";
            txtMateriasDesc.Text = "";
            txtDocumento.Text = "";
            txtContraseña.Text = "";
            txtApellido.Text = "";
            txtPassword2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                Docente d = new Docente
                                {
                                    APELLIDO = txtApellido.Text,
                                    CI = Convert.ToInt32(txtDocumento.Text),
                                    NOMBRE_USUARIO = txtUserName.Text,
                                    MATERIAS = txtMateriasDesc.Text.Split(',').ToArray(),
                                    NOMBRE = txtNombre.Text,
                                    PASS = txtContraseña.Text
                                };

                ServiceWebMail sm = new ServiceWebMail();
                //if (update)
                //{
                //    lu.ModificarDocente(d);

                //    lblInfo.Text =
                //        "Informacion actualizada";
                //    Response.Redirect("~/AdminDocente/ListarDocentes.aspx", false);

                //}
                //else
                //{
                    sm.NuevoDocente(d);

                    lblInfo.Text = "Impeca!!, fuiste registrado.";
                    ClearForm();
                //}
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}
