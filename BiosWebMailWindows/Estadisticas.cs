using System;
using System.Windows.Forms;
using BiosWebMail.refServiceWebMail;

namespace BiosWebMailWindows
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();


        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceWebMail sm = new ServiceWebMail();
                sm.get
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }
    }
}
