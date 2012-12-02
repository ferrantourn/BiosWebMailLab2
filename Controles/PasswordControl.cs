using System.ComponentModel;
using System.Windows.Forms;

namespace Controles
{
    public partial class PasswordControl : UserControl
    {
        public PasswordControl()
        {
            InitializeComponent();
        }

        public string PASSWORD
        {
            get
            {
                if (ValidarPassword())
                {
                    return txtContraseña.Text;
                }
                return null;
            }
            set
            {
                txtContraseña.Text = value;
                txtPassword2.Text = value;
            }
        }

        public void ClearPasswords()
        {
            txtContraseña.Text = "";
            txtPassword2.Text = "";
        }

        private bool ValidarPassword()
        {

            if (txtContraseña.Text != txtPassword2.Text)
            {
                errorProvider.SetError(txtPassword2, "Las contraseñas no coinciden.");
                return false;
            }
            else
            {
                if (txtContraseña.Text.Length >= 6 && txtPassword2.Text.Length <= 10)
                {
                    errorProvider.SetError(txtPassword2, "");
                    return true;
                }
                else
                {
                    errorProvider.SetError(txtPassword2, "La contraseña debe tener entre 6 y 10 caracteres");
                    return false;
                }
            }
        }

        private void txtPassword2_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidarPassword())
            {
                //e.Cancel = true;
            }
        }
    }
}
