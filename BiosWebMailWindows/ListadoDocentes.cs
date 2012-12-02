using System;
using System.Windows.Forms;
using BiosWebMailWindows.refServiceWebMailWin;

namespace BiosWebMailWindows
{
    public partial class ListadoDocentes : Form
    {
        public ListadoDocentes()
        {
            InitializeComponent();
        }

        private void ListadoDocentes_Load(object sender, EventArgs e)
        {
            //TRAEMOMS TODOS LOS DOCENTES DEL SISTEMA
            //---------------------------------------
            try
            {
                ServiceWebMail sm = new ServiceWebMail();
                Docente[] docentes = sm.ListarDocentes();

                //foreach (Docente d in docentes)
                //{
                //    object[] row0 = { "Editar",d.NOMBRE_USUARIO, d.CI, d.NOMBRE, d.APELLIDO };
                //    gridDocentes.Rows.Add(row0);
                //}

                bindingSource1.DataSource = docentes;
                gridDocentes.DataSource = bindingSource1;
                bindingNavigator1.BindingSource= bindingSource1;

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void btnNuevoDocente_Click(object sender, EventArgs e)
        {
            Registro formRegistro = new Registro();
            formRegistro.Show();
        }

        private void gridDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    string username = Convert.ToString(gridDocentes.Rows[e.RowIndex].Cells[1].Value);
                    //if (Int32.TryParse(Convert.ToString(gridDocentes.Rows[e.RowIndex].Cells[1].Value), out ci))
                    if (!String.IsNullOrEmpty(username))
                    {
                        //LLAMAMOS A EDITAR DOCENTE
                        //------------------------
                        Registro formRegistro = new Registro();
                        //TRAEMOS LA INFORMACION DEL DOCENTE DEL WEB SERVICE
                        ServiceWebMail sm = new ServiceWebMail();
                        Docente d = new Docente();
                        d.NOMBRE_USUARIO = username;
                        d = sm.getDocente(d);

                        if (d != null)
                        {
                            formRegistro.DOCENTE = d;
                            formRegistro.Show();
                        }
                        else
                        {
                            lblInfo.Text = "No se encontro la informacion del docente";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Registro formRegistro = new Registro();
            formRegistro.Show();
        }

       
    }
}
