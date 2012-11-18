using System;

namespace Entidades
{
    [Serializable]
    public class Email
    {
        #region ATRIBUTOS Y PROPIEDADES

        private int _numeroEmail;
        public int NUMERO_EMAIL
        {
            get { return _numeroEmail; }
            set { _numeroEmail = value; }
        }

        private Carpeta _carpetaRemitente;
        public Carpeta CARPETA_REMITENTE
        {
            get { return _carpetaRemitente; }
            set { _carpetaRemitente = value; }
        }

        private Carpeta _carpetaDestinatario;
        public Carpeta CARPETA_DESTINATARIO
        {
            get { return _carpetaDestinatario; }
            set { _carpetaDestinatario = value; }
        }


        private string _cuerpo;
        public string CUERPO
        {
            get { return _cuerpo; }
            set { _cuerpo = value; }
        }

       
        private string _asunto;
        public string ASUNTO
        {
            get { return _asunto; }
            set { _asunto = value; }
        }


        private bool _leido;
        public bool LEIDO
        {
            get { return _leido; }
            set { _leido = value; }
        }

        private DateTime _fecha;
        public DateTime FECHA
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

     

        #endregion

        #region CONSTRUCTORES
        public Email()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroEmail"></param>
        /// <param name="asunto"></param>
        /// <param name="leido"></param>
        /// <param name="cuerpo"></param>
        /// <param name="_carpetaRemitente"></param>
        /// <param name="_carpetaDestinatario"></param>
        public Email(int? numeroEmail, string asunto, bool leido, string cuerpo, Carpeta _carpetaRemitente, Carpeta _carpetaDestinatario, DateTime fechaEmail)
        {
            if (numeroEmail != null)
                NUMERO_EMAIL = Convert.ToInt32(numeroEmail);
            CARPETA_REMITENTE = _carpetaRemitente;
            CARPETA_DESTINATARIO = _carpetaDestinatario;
            ASUNTO = asunto;
            LEIDO = leido;
            CUERPO = cuerpo;
            FECHA = fechaEmail;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="asunto"></param>
       /// <param name="leido"></param>
       /// <param name="cuerpo"></param>
       /// <param name="fechaEmail"></param>
        public Email(string asunto, bool leido, string cuerpo, DateTime fechaEmail)
        {
            ASUNTO = asunto;
            LEIDO = leido;
            CUERPO = cuerpo;
            FECHA = fechaEmail;

        }
        #endregion

    }
}
