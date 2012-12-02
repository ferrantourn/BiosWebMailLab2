using System;
using System.Windows.Forms;
using BiosWebMailWindows.refServiceWebMailWin;

namespace BiosWebMailWindows
{
    public partial class ListadoAlumnSinMovs : Form
    {
        public ListadoAlumnSinMovs()
        {
            InitializeComponent();
        }

        private void Busqueda()
        {
            try
            {
                lblInfo.Text = "";

                //LIMPIO LAS FILAS SI TENIA ALGUNA DE ANTES
                //-----------------------------------------
                UsersListRepeater.Rows.Clear();
                if (!string.IsNullOrEmpty(txtNumDias.Text))
                {
                    ServiceWebMail sm = new ServiceWebMail();
                    int numDias;
                    if (Int32.TryParse(txtNumDias.Text, out numDias))
                    {
                        Alumno[] alumnos = sm.ListarAlumnosSinMovimientos(numDias);
                        foreach (Alumno a in alumnos)
                        {
                            object[] row0 = {a.CI, "Desactivar", a.NOMBRE, a.APELLIDO,
                                                    Convert.ToString(a.ACTIVO).Trim() == "True" ? "Activo" : "No Activo"
                                                };
                            UsersListRepeater.Rows.Add(row0);
                        }
                    }
                    else
                    {
                        lblInfo.Text = "El numero de dias ingresado no es valido";
                    }
                }
                else
                    lblInfo.Text = "Debe ingresar un numero de dias para realizar la consulta";

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.ToString();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
          Busqueda();
        }

        private void UsersListRepeater_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    int ci;
                    if (Int32.TryParse(Convert.ToString(UsersListRepeater.Rows[e.RowIndex].Cells[0].Value), out ci))
                    {
                        ServiceWebMail sm = new ServiceWebMail();
                        Alumno a = new Alumno { CI = ci };
                        sm.ActualizarStatusAlumno(a, false);
                        lblInfo.Text = "Alumno desactivado";

                        //VOLVEMOS A REALIZAR LA BUSQUEDA PARA QUE ACTUALICE LA INFORMACION
                        //-----------------------------------------------------------------
                        Busqueda();
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}
