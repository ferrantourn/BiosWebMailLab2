using System;
using BiosWebMail.refServiceWebMail;
//using Logica;


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
                        //ILogicaEmails le = FabricaLogica.getLogicaEmails();
                        
                        //Entidades.Email email = le.GetEmail(emailId);
                        ServiceWebMail sm = new ServiceWebMail();
                        refServiceWebMail.Email email = new refServiceWebMail.Email {NUMERO_EMAIL = emailId};
                        //email = le.GetEmail(email);
                        email = sm.GetEmail(email);

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
                            //ILogicaCarpetas lc = FabricaLogica.getLogicaCarpetas();
                            //ddlFolders.DataSource = lc.ListarCarpetas((Alumno)Session["Usuario"]);

                            ddlFolders.DataSource = sm.ListarCarpetas((Alumno) Session["Usuario"]);
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
                //ILogicaEmails le = FabricaLogica.getLogicaEmails();
                ServiceWebMail sm = new ServiceWebMail();
                
                SiteAlumno m = Master;
                if (m != null && m.USUARIO_LOGUEADO != null)
                {
                    Alumno a = (Alumno)m.USUARIO_LOGUEADO;

                    refServiceWebMail.Email newEmail = new refServiceWebMail.Email
                                                   {
                                                       CUERPO = txtContenido.Text,
                                                       FECHA = DateTime.Now,
                                                       ASUNTO = txtAsunto.Text
                                                   };
                    Alumno destinatario = new Alumno {NOMBRE_USUARIO = txtPara.Text};

                    //le.AgregarEmail(txtAsunto.Text, txtContenido.Text, a, txtPara.Text);
                    //le.AgregarEmail(newEmail, a, destinatario);
                    sm.AgregarEmail(newEmail, a, destinatario);
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
                //ILogicaEmails le = FabricaLogica.getLogicaEmails();
                ServiceWebMail sm = new ServiceWebMail();

                Carpeta current = (Carpeta)Session["Carpeta"];
                if (current != null)
                {
                    //le.MoverEmail(Convert.ToInt32(Session["EmailId"]), current.NUMERO_CARPETA, Convert.ToInt32(ddlFolders.SelectedValue));

                    refServiceWebMail.Email email = new refServiceWebMail.Email();
                    email.NUMERO_EMAIL = Convert.ToInt32(Session["EmailId"]);
                    Carpeta cdestino = new Carpeta {NUMERO_CARPETA = Convert.ToInt32(ddlFolders.SelectedValue)};
                    //le.MoverEmail(email, current, cdestino);
                    sm.MoverEmail(email, current, cdestino);
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