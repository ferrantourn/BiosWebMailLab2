using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using BiosWebMailWindows.refServiceWebMailWin;
using System.Linq;
namespace BiosWebMailWindows
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }


        private void Estadisticas_Load(object sender, EventArgs e)
        {

            try
            {
                ServiceWebMail sm = new ServiceWebMail();
                XmlNode nodos = sm.ListarAlumnosXml();
                XmlDocument myXmlDocumentObject = new XmlDocument();
                myXmlDocumentObject.AppendChild(myXmlDocumentObject.ImportNode(nodos, true));


                //obtengo objeto para realizar la consulta
                XPathNavigator _Navegador = myXmlDocumentObject.CreateNavigator();

                //ejecuto la consulta
                XPathNodeIterator _Resultado = _Navegador.Select("/raiz/EstadisticaMail");

                //si hay resultado lo muestro;
                //El iterador tiene una propiedad count que me va a determinar la cantidad de nodos que puedo navegar
                if (_Resultado.Count > 0)
                {
                    while (_Resultado.MoveNext())
                    {
                        string nombre = _Resultado.Current.SelectSingleNode("NombreUsuario").ToString();
                        string enviados = _Resultado.Current.SelectSingleNode("MailsEnviados").ToString();
                        string recibidos = _Resultado.Current.SelectSingleNode("MailsRecibidos").ToString();

                        object[] row0 = { nombre, enviados, recibidos };
                        gridEstadistica.Rows.Add(row0);
                    }
                }

                //XmlNode nodeaux = myXmlDocumentObject.SelectSingleNode("/raiz");
                //XmlNodeList estadisticasMail = nodeaux.SelectNodes("EstadisticaMail");
                //foreach (XmlNode n in estadisticasMail)
                //{
                //    while (n.h)
                //    {
                //        n.NextSibling
                //        string nombreUsuario = n.InnerText;
                //    }

                //}



                //          // Create the query
                //var alumnos = from a in XElement.ReadFrom(.Elements("Alumno")
                //            select a;

                //        foreach (XmlNode n in myXmlDocumentObject)
                //        {
                //            object[] row0 = {n.};
                //            UsersListRepeater.Rows.Add(row0);
                //        }



                //sm.get
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
