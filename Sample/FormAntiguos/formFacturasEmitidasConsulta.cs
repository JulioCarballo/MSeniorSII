using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formFacturasEmitidasConsulta : Form
    {

        public formFacturasEmitidasConsulta()
        {
            InitializeComponent();
        }

        // Crea una consulta de facturas emitidas
        private static ARInvoicesQuery CrearConsultaFacturasEmitidas()
        {

            // Titular que realizó el envío de las facturas a consultar
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Creamos una consulta de facturas emitidas
            ARInvoicesQuery consultaFacturasEmitidas = new ARInvoicesQuery();
            consultaFacturasEmitidas.Titular = titular;

            // La consulta de facturas emitidas contine un objeto factura emitida
            // que utilizaremos para pasarle los datos de filtro.
            ARInvoice facturaConDatosFiltro = consultaFacturasEmitidas.ARInvoice;
            // Filtramos por fecha de emisión.
            facturaConDatosFiltro.IssueDate = new DateTime(2017, 1, 15);     

            return consultaFacturasEmitidas;         


        }

        /// <summary>
        /// Consultar facturas emitidas.
        /// </summary>
        public void ConsultarFacturasEmitidas()
        {

            // Creo la consulta de facturas emitidas
            ARInvoicesQuery consultaFacturasEmitidas = CrearConsultaFacturasEmitidas();
            // Petición de factura emitidas envíada a la AEAT mediante el SII.
            Wsd.GetFacturasEmitidas(consultaFacturasEmitidas);


            // Mostramos el xml de respuesta de la AEAT en el web browser.
            webBrw.Navigate(Settings.Current.InboxPath + 
                consultaFacturasEmitidas.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de una consulta de 
            // facturas emitidas envíada anteriormente.
            ConsultarFacturasEmitidas();           
        }

  
        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Save();
        }
    }
}
