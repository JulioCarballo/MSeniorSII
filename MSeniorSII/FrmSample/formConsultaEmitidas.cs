using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sample
{
    public partial class formConsultaEmitidas : Form
    {

        public formConsultaEmitidas()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Crea un lote de facturas emitidas para su envío al SII
        /// de la aeat.
        /// </summary>
        /// <returns></returns>
        private static ARInvoicesQuery CreaLoteDeEmitidasEnviadas()
        {

            // Informamos los datos necesarios para realizar la petición
            ARInvoicesQuery LoteFactEmitEnviadas = new ARInvoicesQuery();

            // Creamos el titular del envío
            Party titular = new Party()
            {
                TaxIdentificationNumber = "V57525560",
                PartyName = "IRENE SOLUTIONS SL"
            };
                      
            LoteFactEmitEnviadas.Titular = titular;           

            // Necesitamos indicar una fecha de factura, para que se pueda calcular el ejercicio y periodo
            // que son necesarios y obligatorios para realizar esta peticiones.
            ARInvoice facturaEnviadaPrimera = new ARInvoice();

            facturaEnviadaPrimera.IssueDate = new DateTime(2017, 1, 15); // Fecha factura

            //
            // Estos campos son opcionales, de manera que los informaremos si necesitamos buscar una factura
            // en concreto o aquellas cuya fecha de expedición coincida con la indicada en la petición
            //
            //facturaEnviadaPrimera.SellerParty = new Party() // El cliente
            //{
            //    TaxIdentificationNumber = "B12756474"
            //};
            //facturaEnviadaPrimera.InvoiceNumber = "E00027"; // El número de factura

            LoteFactEmitEnviadas.ARInvoice = facturaEnviadaPrimera;


            return LoteFactEmitEnviadas;
          


        }

        /// <summary>
        /// Ejemplo de envío de un lote de facturas emitidas
        /// </summary>
        public void EnviarConsultaFactEmit()
        {

            // Creamos un lote de factura recibidas
            ARInvoicesQuery LoteDeFacturasEmitidas =
                CreaLoteDeEmitidasEnviadas();

            // Realizamos el envío del lote a la AEAT
            Wsd.GetFacturasEmitidas(LoteDeFacturasEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                LoteDeFacturasEmitidas.GetReceivedFileName());                

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de lote de facturas emitidas
            EnviarConsultaFactEmit();           
        }



        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
