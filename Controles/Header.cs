using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Header : WebControl, INamingContainer
    {
        private string _HeaderText;
        private string _imageUrl;
        private Label lblHeader;
        private Image _imagen;

        public string HEADER_TEXT
        {
            get { return _HeaderText; }
            set { _HeaderText = value; }
        }

        public string IMAGE_URL
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }


        protected override void CreateChildControls()
        {
            Panel upanel = new Panel();

            lblHeader = new Label { Text = HEADER_TEXT };
            _imagen = new Image { ImageUrl = IMAGE_URL };
            _imagen.Height = Unit.Pixel(64);
            _imagen.Width = Unit.Pixel(64);
            upanel.Controls.Add(_imagen);
            LiteralControl l = new LiteralControl("</br>");
            upanel.Controls.Add(l);
            lblHeader.Height = Unit.Pixel(15);
            lblHeader.Width = Unit.Percentage(100);
            upanel.Controls.Add(lblHeader);

            //agrego el panel de los controles
            Controls.Add(upanel);
        }

    }
}
