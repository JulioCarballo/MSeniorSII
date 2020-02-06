using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml.Sii;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class formFacturasEmitidasNifOtro : Form
    {

        public formFacturasEmitidasNifOtro()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Crea un lote de facturas emitidas para su envío al SII
        /// de la aeat.
        /// </summary>
        /// <returns></returns>
        private static ARInvoicesBatch CreaLoteDeFacturasEmitidas()
        {

            // Creamos al titular del envío
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };


            ARInvoicesBatch LoteDeFacturasEmitidas = new ARInvoicesBatch
            {
                Titular = titular,
                CommunicationType = CommunicationType.A0 // alta facturas:
            };
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.

            // El titular del envío también es el emisor de las facturas
            Party emisor = titular;

            // Creo las facturas y las anexo al lote

            ARInvoice facturaEnviadaPrimera = new ARInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha factura
                SellerParty = emisor, // El emisor de la factura

                BuyerParty = new Party() // El cliente
                {
                    //TaxIdentificationNumber =
                    //"NIF_EXTRANJERO",
                    PartyName = "MAC ORGANIZACION SL"
                },


                InvoiceNumber = "E00001", // El número de factura
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,
                GrossAmount = 231m, // Importe bruto
                InvoiceText = "Servicios consultoria" // Descripción
            }; // Primera factura
            facturaEnviadaPrimera.AddTaxOtuput(21m, 100m, 21m); // Añadimos las líneas de IVA
            facturaEnviadaPrimera.AddTaxOtuput(10m, 100m, 10m);

            LoteDeFacturasEmitidas.ARInvoices.Add(facturaEnviadaPrimera); // Añadimos la primera factura al lote

       

            return LoteDeFacturasEmitidas;
          


        }

        /// <summary>
        /// Ejemplo de envío de un lote de facturas emitidas
        /// </summary>
        public void EnviarLoteFacturasEmitidas()
        {

            // Creamos un lote de factura recibidas
            ARInvoicesBatch LoteDeFacturasEmitidas =
                CreaLoteDeFacturasEmitidas();

            // Creo el sobre SOAP con el objeto XML a enviar a la AEAT
            Envelope envelope = LoteDeFacturasEmitidas.GetEnvelope();

            // Edito directamente el objeto XML
            FacturaExpedida facturaExpedida = envelope.Body.SuministroLRFacturasEmitidas.RegistroLRFacturasEmitidas[0].FacturaExpedida;
            facturaExpedida.Contraparte.IDOtro = new IDOtro
            {
                IDType = "06",
                CodigoPais = "US",
                ID = "NIF_EXTRANJERO"
            };


            // Realizamos el envío del SOBRE a la AEAT
            Wsd.Send(envelope);
           
         

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                LoteDeFacturasEmitidas.GetReceivedFileName());                

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de lote de facturas emitidas
            EnviarLoteFacturasEmitidas();           
        }



        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
