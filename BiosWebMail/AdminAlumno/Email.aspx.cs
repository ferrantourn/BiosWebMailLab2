﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ExcepcionesPersonalizadas;
using Logica;

namespace BiosWebMail
{
    public partial class Email : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int emailId;
                    if (Int32.TryParse(Convert.ToString(Session["EmailId"]), out emailId))
                    {
                        txtFrom.Visible = true;
                        lblFrom.Visible = true;

                        //CARGAMOS LA INFORMACION DEL EMAIL PARA SER VISUALIZADA.
                        //-------------------------------------------------------
                        btnAceptar.Visible = false;
                        ILogicaEmails le = FabricaLogica.getLogicaEmails();

                        Entidades.Email email = le.GetEmail(emailId);
                        if (email != null)
                        {
                            Header.HEADER_TEXT = "Email enviado " + email.FECHA.ToShortDateString() + " a las " +
                                                 email.FECHA.ToShortTimeString();

                            txtFrom.Text = email.CARPETA_REMITENTE.USUARIO.NOMBRE + " " +
                                           email.CARPETA_REMITENTE.USUARIO.APELLIDO;
                            txtPara.Text = email.CARPETA_DESTINATARIO.USUARIO.NOMBRE + " " +
                                           email.CARPETA_DESTINATARIO.USUARIO.APELLIDO;
                            txtAsunto.Text = email.ASUNTO;
                            txtContenido.Text = email.CUERPO;

                            //bindeamos las posibles carpetas de destino
                            // a mover
                            ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                            ddlFolders.DataSource = lc.ListarCarpetas((Alumno) Session["Usuario"]);
                            ddlFolders.DataBind();
                            lblMover.Visible = true;
                            ddlFolders.Visible = true;
                        }
                        else
                        {
                            lblInfo.Text = "No se encontro la informacion del email";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.ToString();
            }

        }

        /// <summary>
        /// ENVIA UN EMAIL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ILogicaEmails le = FabricaLogica.getLogicaEmails();
                SiteAlumno m = (SiteAlumno)Master;
                if (m != null && m.USUARIO_LOGUEADO != null)
                {
                    Alumno a = (Alumno)m.USUARIO_LOGUEADO;

                    le.AgregarEmail(txtAsunto.Text, txtContenido.Text, a, txtPara.Text);
                    Response.Redirect("~/AdminAlumno/home.aspx");
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void ddlFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILogicaEmails le = FabricaLogica.getLogicaEmails();
                Carpeta current = (Carpeta)Session["Carpeta"];
                if (current != null)
                {
                    le.MoverEmail(Convert.ToInt32(Session["EmailId"]), current.NUMERO_CARPETA, Convert.ToInt32(ddlFolders.SelectedValue));
                    lblInfo.Text = "El email se movio a la carpeta " + ddlFolders.SelectedItem.Text;
                }

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}