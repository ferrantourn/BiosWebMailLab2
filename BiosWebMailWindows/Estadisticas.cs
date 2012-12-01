using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            this.reportViewer1.RefreshReport();
        }
    }
}
