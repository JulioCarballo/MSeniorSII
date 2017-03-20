using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formFacturasRecibidasConsulta : Form
    {

        public formFacturasRecibidasConsulta()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Crea una consulta de factura recibidas.
        /// </summary>
        /// <returns>Consulta de factura recibidas.</returns>
        private static APInvoicesQuery CrearConsultaFacturasRecibidas()
        {
            // Titular de la consulta
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Consulta de factura recibidas enviadas
            APInvoicesQuery consultaFacturasRecibidas = new APInvoicesQuery();
            consultaFacturasRecibidas.Titular = titular;
            // Fecha de contabilización
            consultaFacturasRecibidas.APInvoice.PostingDate = 
                new DateTime(2017, 1, 15);     

            return consultaFacturasRecibidas;          


        }
        public void ConsultarFacturasRecibidas()
        {
            // Creo un objeto consulta de facturas recibidas
            APInvoicesQuery consultaFacturasRecibidas = CrearConsultaFacturasRecibidas();
            // Envío la consulta
            Wsd.GetFacturasRecibidas(consultaFacturasRecibidas);


            // Muestro el archivo xml de respuesta
            webBrw.Navigate(Settings.Current.InboxPath + 
                consultaFacturasRecibidas.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Consulta factura recibidas enviadas
            ConsultarFacturasRecibidas();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda configuración actual.
            Settings.Save();
        }
    }
}
