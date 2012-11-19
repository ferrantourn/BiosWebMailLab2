using System;
using System.Configuration;

namespace BiosWebMail.UserControls
{
    public partial class UserControlPicture : System.Web.UI.UserControl
    {

        public string GetFileNameExtension
        {
            get
            {
                if (fu1.HasFile)
                {
                    string fileExtension = fu1.FileName.Substring(fu1.FileName.Length - 3, 3);

                    return fileExtension;
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CargarFotos(string foto)
        {
            try
            {
                imgUser.ImageUrl = ConfigurationManager.AppSettings["ImagesFolder"] + foto;
            }
            catch (Exception ex)
            {
                lblF1.Text = ex.ToString();
            }
        }


        public void GuardarFotos(string ci)
        {
            if (fu1.HasFile)
            {
                try
                {
                    string fileExtension = GetFileNameExtension;
                    fu1.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["ImagesFolder"]) + ci + "." + fileExtension);
                    imgUser.ImageUrl = ConfigurationManager.AppSettings["ImagesFolder"] + ci + "." + fileExtension;
                    lblF1.Text = "OK!";
                }
                catch (Exception ex)
                {
                    lblF1.Text = "No se pudo cargar el archivo, ocurrió el siguiente error:" + ex.Message;
                }
            }
        }

    }
}