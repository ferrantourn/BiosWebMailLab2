using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class controlMaterias : TextBox
    {
        public controlMaterias()
        {
            InitializeComponent();
        }

        public controlMaterias(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string[] MATERIAS
        {
            get
            {
                return this.Text.Split(',').ToArray();
            }


            set
            {

                string texto = "";
                foreach (string materia in value)
                {
                    if (!String.IsNullOrEmpty(materia))
                        texto = texto + materia + ", ";
                }
                if (!String.IsNullOrEmpty(texto))
                {
                    //quitamos el , final.
                    int lastindex = texto.LastIndexOf(",");
                    texto = texto.Remove(lastindex, 2);
                }
                this.Text = texto;

            }
        }
    }
}
