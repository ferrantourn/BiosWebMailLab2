using System;
using System.Windows.Forms;
using System.Xml;
using BiosWebMailWindows.refServiceWebMailWin;
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
                XmlNode nodo = sm.ListarAlumnosXml();
                //sm.get
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }
    }
}
