using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ExcepcionesPersonalizadas;
using Logica;

namespace BiosWebMail.UserControls
{
    public partial class Usuario : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                if (!IsPostBack)
                {
                    if (Session["EditarUsuario"] != null)
                    {
                        lblRegistrarme.Visible = false;
                        ddlRegistroComo.Visible = false;
                        btnUpdate.Visible = true;
                        btnRegistrar.Visible = false;

                        if (Session["EditarUsuario"] is Alumno)
                        {
                            //cargamos la informacion para alumno
                            Alumno a = (Alumno) Session["EditarUsuario"];
                            txtUserName.Text = a.NOMBRE_USUARIO;
                            txtNombre.Text = a.NOMBRE;
                            txtMateriasDesc.Visible = false;
                            lblMaterias.Visible = false;
                            txtDocumento.Text = Convert.ToString(a.CI);
                            txtContraseña.Text = Convert.ToString(a.PASS);
                            txtApellido.Text = a.APELLIDO;
                            UCPicture.Visible = true;
                            UCPicture.CargarFotos(Convert.ToString(a.FOTO));
                            ddlRegistroComo.SelectedValue = "Alumno";
                        }
                        else if (Session["EditarUsuario"] is Docente)
                        {
                            //cargamos la info para docente
                            Docente d = (Docente) Session["EditarUsuario"];
                            txtUserName.Text = d.NOMBRE_USUARIO;
                            txtNombre.Text = d.NOMBRE;
                            txtMateriasDesc.Visible = true;
                            lblMaterias.Visible = true;
                            txtDocumento.Text = Convert.ToString(d.CI);
                            txtContraseña.Text = Convert.ToString(d.PASS);
                            txtApellido.Text = d.APELLIDO;
                            UCPicture.Visible = false;
                            ddlRegistroComo.SelectedValue = "Docente";
                            lblUserPicture.Visible = false;
                            txtMateriasDesc.Text = d.MateriasToString();
                        }
                        else
                        {
                            lblInfo.Text = "No se reconoce el usuario";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }


        private string Validaciones()
        {
            StringBuilder validacion = new StringBuilder();
            if (txtContraseña.Text.Length < 6 || txtContraseña.Text.Length > 10)
            {
                validacion.Append("La contraseña debe tener entre 6 y 10 caracteres, proba de nuevo.</br>");
            }

            int documento;
            if (!Int32.TryParse(txtDocumento.Text, out documento))
            {
                validacion.Append("El documento contiene caracteres no validos</br>");
            }

            return validacion.ToString();
        }

        /// <summary>
        /// INSERTA O ACTUALIZA UN NUEVO USUARIO DEL SISTEMA
        /// </summary>
        /// <param name="update"></param>
        private void Registrar(bool update)
        {
            try
            {
                string result = Validaciones();
                if (String.IsNullOrEmpty(result))
                {
                    ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                    if (ddlRegistroComo.SelectedValue.ToUpper() == "DOCENTE")
                    {
                        Docente d;
                        if (update)
                            d = (Docente)Session["EditarUsuario"];
                        else
                            d = new Docente();

                        d.APELLIDO = txtApellido.Text;
                        d.CI = Convert.ToInt32(txtDocumento.Text);
                        d.NOMBRE_USUARIO = txtUserName.Text;
                        d.MATERIAS = txtMateriasDesc.Text.Split(',').ToList();
                        d.NOMBRE = txtNombre.Text;
                        d.PASS = txtContraseña.Text;

                        if (update)
                        {
                            lu.ModificarDocente(d);

                            lblInfo.Text =
                                "Informacion actualizada";
                            Response.Redirect("~/AdminDocente/ListarDocentes.aspx", false);

                        }
                        else
                        {
                            lu.NuevoDocente(d);

                            lblInfo.Text =
                                "Impeca!!, fuiste registrado. Valida tu usuario y password para ingresar al sistema";
                            ClearForm();
                        }
                    }
                    else if (ddlRegistroComo.SelectedValue.ToUpper() == "ALUMNO")
                    {
                        Alumno a;
                        if (update)
                            a = (Alumno)Session["EditarUsuario"];
                        else
                            a = new Alumno();

                        a.APELLIDO = txtApellido.Text;
                        a.CI = Convert.ToInt32(txtDocumento.Text);
                        a.NOMBRE_USUARIO = txtUserName.Text;
                        a.NOMBRE = txtNombre.Text;
                        a.FOTO = Convert.ToString(a.CI) + "." + UCPicture.GetFileNameExtension;
                        a.PASS = txtContraseña.Text;
                        a.ACTIVO = true;

                        //GUARDO LA FOTO EN UNA CARPETA
                        //-----------------------------
                        UCPicture.GuardarFotos(Convert.ToString(a.CI));

                        if (update)
                        {
                            lu.ModificarAlumno(a);
                            lblInfo.Text = "Informacion actualizada";
                            Response.Redirect("~/AdminDocente/ListarAlumnos.aspx",false);
                        }
                        else
                        {
                            lu.NuevoAlumno(a);

                            lblInfo.Text =
                                "Sabelo!!, fuiste registrado. Valida tu usuario y password para ingresar al sistema";
                            ClearForm();
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Tipo de usuario a registrar/actualizar no valido";
                    }
                }
                else
                {
                    lblInfo.Text = result;
                }
            }
            catch (ErrorUsuarioYaExiste)
            {
                lblInfo.Text = "Error: El usuario con documento " + txtDocumento.Text + " o nombre de usuario " + txtUserName.Text + " ya se encuentra registrado.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar(false);
        }

        protected void ddlRegistroComo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaterias.Visible = ddlRegistroComo.SelectedValue.ToUpper() == "DOCENTE";
            txtMateriasDesc.Visible = ddlRegistroComo.SelectedValue.ToUpper() == "DOCENTE";
            RequiredFieldValidatorMaterias.Visible = ddlRegistroComo.SelectedValue.ToUpper() == "DOCENTE";
            UCPicture.Visible = ddlRegistroComo.SelectedValue.ToUpper() != "DOCENTE";
            lblUserPicture.Visible = ddlRegistroComo.SelectedValue.ToUpper() != "DOCENTE";

        }


        private void ClearForm()
        {
            txtUserName.Text = "";
            txtNombre.Text = "";
            txtMateriasDesc.Text = "";
            txtDocumento.Text = "";
            txtContraseña.Text = "";
            txtApellido.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Registrar(true);
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

    }
}