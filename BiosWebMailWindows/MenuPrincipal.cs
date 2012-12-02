using System;
using System.Windows.Forms;

namespace BiosWebMailWindows
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

       

       

        private void btnRegistroDocente_Click(object sender, EventArgs e)
        {
           
        }

        private void listadoAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas formEstadisticas = new Estadisticas();
            formEstadisticas.Show();
        }

        private void registrarDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Registro regform = new Registro();
                regform.Show();
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        private void activarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarCuenta formActivarCuenta = new ActivarCuenta();
            formActivarCuenta.Show();
        }

        private void alumnosSinMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoAlumnSinMovs formAlumnosSinMovs = new ListadoAlumnSinMovs();
            formAlumnosSinMovs.Show();
        }

       

     

       
    }
}
