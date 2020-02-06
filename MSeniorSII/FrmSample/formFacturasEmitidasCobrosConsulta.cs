using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class formFacturasEmitidasCobrosConsulta : Form
    {

        public formFacturasEmitidasCobrosConsulta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea una consulta de cobros de factura emitidas envíadas al SII
        /// con anterioridad.
        /// </summary>
        /// <returns>Consula de cobros de facturas emitidas</returns>
        private static ARPaymentsQuery CrearConsultaCobrosFacturasEmitidas()
        {

            // Creamos el Titular
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            Party emisor = titular; // El emisor es el propio titular

            ARPaymentsQuery consultaCobrosFacturasEmitidas = new ARPaymentsQuery
            {
                Titular = titular
            };
            consultaCobrosFacturasEmitidas.ARInvoice.IssueDate = new DateTime(2017, 1, 15); // Fecha emisión
            consultaCobrosFacturasEmitidas.ARInvoice.InvoiceNumber = "00001";// Número factura
            consultaCobrosFacturasEmitidas.ARInvoice.SellerParty = emisor;

            return consultaCobrosFacturasEmitidas;         


        }

        // Consulta cobros facturas emitidas comunicados al SII
        public void ConsultarCobrosFacturasEmitidas()
        {

            // Creo un objeto consulta de cobros de factura emitidas
            ARPaymentsQuery consultaCobrosFacturasEmitidas = CrearConsultaCobrosFacturasEmitidas();
            // Obtengo la respuesta de la AEAT a la consulta.
            Wsd.GetFacturasEmitidasCobros(consultaCobrosFacturasEmitidas);


            // Muestro el archivo xml de respuesta en el web browser
            webBrw.Navigate(Settings.Current.InboxPath + 
                consultaCobrosFacturasEmitidas.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Consulta cobros de facturas emitidas enviados al SII.
            ConsultarCobrosFacturasEmitidas();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual.
            Settings.Save();
        }
    }
}
