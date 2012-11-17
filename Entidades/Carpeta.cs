using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Carpeta
    {
        #region ATRIBUTOS Y PROPIEDADES

        /// <summary>
        /// usuario dueño de la carpeta
        /// </summary>
        private Usuario _usuario;
        public Usuario USUARIO
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private int _numeroCarpeta;
        public int NUMERO_CARPETA
        {
            get { return _numeroCarpeta; }
            set { _numeroCarpeta = value; }
        }

        private string _nombreCarpeta;
        public string NOMBRE_CARPETA
        {
            get { return _nombreCarpeta; }
            set { _nombreCarpeta = value; }
        }

        private int _totalEmails;
        public int TOTAL_EMAILS
        {
            get { return _totalEmails; }
            set { _totalEmails = value; }
        }

        private int _totalEmailsNoLeidos;
        public int TOTAL_EMAILS_NOLEIDOS
        {
            get { return _totalEmailsNoLeidos; }
            set { _totalEmailsNoLeidos = value; }
        }


        private List<Email> _listaEmail;
        /// <summary>
        /// LISTA LOS EMAILS CONTENIDOS EN ESTA CARPETA*////////////////////*
        /// </summary>
        public List<Email> LISTA_EMAIL
        {
            get { return _listaEmail; }
            set { _listaEmail = value; }
        }

        #endregion

        public Carpeta()
        {

        }

        public Carpeta(Usuario usuario, int numeroCarpeta, string nombreCarpeta, List<Email> listaEmail)
        {
            USUARIO = usuario;
            NUMERO_CARPETA = numeroCarpeta;
            NOMBRE_CARPETA = nombreCarpeta;
            LISTA_EMAIL = listaEmail;
        }

        public Carpeta(Usuario usuario, int numeroCarpeta, string nombreCarpeta)
        {
            USUARIO = usuario;
            NUMERO_CARPETA = numeroCarpeta;
            NOMBRE_CARPETA = nombreCarpeta;
        }

        public Carpeta(Usuario usuario, int numeroCarpeta, string nombreCarpeta, int totalEmails, int totalNoLeidos)
        {
            USUARIO = usuario;
            NUMERO_CARPETA = numeroCarpeta;
            NOMBRE_CARPETA = nombreCarpeta;
            TOTAL_EMAILS = totalEmails;
            TOTAL_EMAILS_NOLEIDOS = totalNoLeidos;
        }
    }
}
