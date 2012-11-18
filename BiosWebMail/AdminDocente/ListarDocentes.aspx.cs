using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;


namespace BiosWebMail
{
    public partial class ListarDocentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //Control de acceso.
        {
            lblInfo.Text = "";
        }

        protected void Page_PreRender(object sender, EventArgs e) //Control de acceso.
        {
            try
            {
                ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                UsersListRepeater.DataSource = lu.ListarDocentes();
                UsersListRepeater.DataBind();
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }

        protected void UsersListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper() == "EDITAR")
                {
                    ILogicaUsuario lu = FabricaLogica.getLogicaUsuario();
                    Docente d = new Docente { NOMBRE_USUARIO = Convert.ToString(e.CommandArgument) };
                    d = lu.getDocente(d);
                    if (d != null)
                    {
                        if (Session["EditarUsuario"] == null)
                            Session.Add("EditarUsuario", null);

                        Session["EditarUsuario"] = d;

                        Response.Redirect("~/AdminDocente/Usuarios.aspx", false);
                    }
                    else
                    {
                        lblInfo.Text = "Docente no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.ToString();
            }
        }

        protected void UsersListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    //-- Creo el objeto que tiene los datos de la ROW del Listview
                    //----------------------------------------------------------------
                    RepeaterItem dataItem = e.Item;
                    Docente data = (Docente)dataItem.DataItem;
                    ((Label)dataItem.FindControl("lblMaterias")).Text = data.MateriasToString();

                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }



}
