﻿using System;
using System.Windows.Forms;

namespace BiosWebMailWindows
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivarCuenta formActivarCuenta = new ActivarCuenta();
            formActivarCuenta.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Estadisticas formEstadisticas = new Estadisticas();
            formEstadisticas.Show();
        }
    }
}
