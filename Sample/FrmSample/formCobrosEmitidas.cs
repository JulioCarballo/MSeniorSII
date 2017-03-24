using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formCobrosEmitidas : Form
    {

        public formCobrosEmitidas()
        {
            InitializeComponent();
        }

        // Crea un lote de cobros de factura emitidas en regimen especial de caja.
        // Si las facturas emitidas no se han comunicado a la AEAT esta devolverá
        // un mensaje de error. Si las facturas si se han enviado pero no como 
        // facturas en regimen especial de caja, también devolverá un error.
        private static ARInvoicesPaymentsBatch CrearLoteCobrosFacturasEmitidas()
        {

            // Titular del lote a enviar
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Creo un Lote de cobros de facturas emitidas
            ARInvoicesPaymentsBatch LoteCobrosFacturasEmitidas = new ARInvoicesPaymentsBatch();
            LoteCobrosFacturasEmitidas.Titular = titular;

            Party emisor = titular;

            // Primero creamos la factura emitida a la que corresponde el cobro
            ARInvoice facturaEnviadaCobradaPrimera = new ARInvoice();

            facturaEnviadaCobradaPrimera.IssueDate = new DateTime(2017, 1, 15); // Informamos de la fecha de factura
            facturaEnviadaCobradaPrimera.SellerParty = emisor; // El emisor de la factura
            facturaEnviadaCobradaPrimera.BuyerParty = new Party() // El cliente
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaEnviadaCobradaPrimera.InvoiceNumber = "00001"; // El número de factura

            // Añadimos el/los cobro/s correspondientes a la factura
            facturaEnviadaCobradaPrimera.ARInvoicePayments.Add(new ARInvoicePayment() {
                PaymentDate = new DateTime(2017, 2, 17),
                PaymentTerm = PaymentTerms.Cheque,
                PaymentAmount = 231m,
                AccountOrTermsText = "Cheque A 90 días"
            });

            // Añadimos la factura con sus cobros al lote
            LoteCobrosFacturasEmitidas.ARInvoices.Add(facturaEnviadaCobradaPrimera);

            // Creamos la segunda factura a añadir
            ARInvoice facturaEnviadaCobradaSegunda = new ARInvoice();

            facturaEnviadaCobradaSegunda.IssueDate = new DateTime(2017, 1, 15); // Fecha factura
            facturaEnviadaCobradaSegunda.SellerParty = emisor; // Emisor factura
            facturaEnviadaCobradaSegunda.BuyerParty = new Party() // Cliente
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaEnviadaCobradaSegunda.InvoiceNumber = "00002"; // Número de factura

            // Añadimos el/los cobro/s correspondientes a la factura
            facturaEnviadaCobradaSegunda.ARInvoicePayments.Add(new ARInvoicePayment()
            {
                PaymentDate = new DateTime(2017, 2, 17),
                PaymentTerm = PaymentTerms.Transferencia,
                PaymentAmount = 50m,
                AccountOrTermsText = "Transferencia A 120 días"
            });

            // Añadimos la factura con sus cobros al lote
            LoteCobrosFacturasEmitidas.ARInvoices.Add(facturaEnviadaCobradaSegunda);

            return LoteCobrosFacturasEmitidas;  

        }


        /// <summary>
        /// Rutina de ejemplo de envío de lote de cobros al SII de la AEAT.
        /// </summary>
        public void EnviarLoteCobrosFacturasEmitidas()
        {

            // Creamos un lote de cobros de facturas emitidas en regimen especial de caja
            ARInvoicesPaymentsBatch LoteCobrosFacturasEmitidas = 
                CrearLoteCobrosFacturasEmitidas();
            // Realizamos el envío del lote a la AEAT
            Wsd.SendCobrosFacturasEmitidas(LoteCobrosFacturasEmitidas);


            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath + 
                LoteCobrosFacturasEmitidas.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Envía un lote de cobros de facturas emitidas en el 
            // regimen especial de caja.
            EnviarLoteCobrosFacturasEmitidas();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guardo la configuración actual
            Settings.Save();
        }
    }
}
