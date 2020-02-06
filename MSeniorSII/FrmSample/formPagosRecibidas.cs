using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class formPagosRecibidas : Form
    {

        public formPagosRecibidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea un lote de pagos de factura recibidas
        /// en regimen especial de caja.
        /// </summary>
        /// <returns>Lote de pagos de facturas recibidas.</returns>
        private static APInvoicesPaymentsBatch CrearLotePagosFacturasRecibidas()
        {

            // Creamos el titular del lote
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Creamos el lote de pagos de facturas recibidas y le asignamos el titular
            APInvoicesPaymentsBatch LotePagosFacturasRecibidas = new APInvoicesPaymentsBatch
            {
                Titular = titular
            };

            // El titular coincide con el comprador en las facturas recibidas
            Party comprador = titular;

            // Empezamos a crear las facturas
            APInvoice facturaRecibidaPagadaPrimera = new APInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha emisión
                PostingDate = new DateTime(2017, 1, 15), // Fecha contabilización
                SellerParty = new Party() // Acreedor (emisor factura)
                {
                    TaxIdentificationNumber =
                "B12756474",
                    PartyName = "MAC ORGANIZACION SL"
                },
                BuyerParty = comprador, // Comprador
                InvoiceNumber = "00001" // Número factura
            };

            // Añadimos el/los pago/s correspondientes a la factura
            facturaRecibidaPagadaPrimera.APInvoicePayments.Add(new APInvoicePayment()
            {
                PaymentDate = new DateTime(2017, 2, 17),
                PaymentTerm = PaymentTerms.Cheque,
                PaymentAmount = 231m,
                AccountOrTermsText = "Cheque A 90 días"
            });

            // Añadimos la factura con sus pagos al lote
            LotePagosFacturasRecibidas.APInvoices.Add(facturaRecibidaPagadaPrimera);

            // Creamos una segunda factura recibida pagada para añadir al lote
            APInvoice facturaRecibidaPagadaSegunda = new APInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha factura
                PostingDate = new DateTime(2017, 1, 15), // Fecha contabilización
                SellerParty = new Party() // acreedor (emisor factura)
                {
                    TaxIdentificationNumber =
                "B12756474",
                    PartyName = "MAC ORGANIZACION SL"
                },
                BuyerParty = comprador, // Comprador
                InvoiceNumber = "00002" // Número factura
            };

            // Añadimos el/los pago/s correspondientes a la factura
            facturaRecibidaPagadaSegunda.APInvoicePayments.Add(new APInvoicePayment()
            {
                PaymentDate = new DateTime(2017, 2, 17),
                PaymentTerm = PaymentTerms.Cheque,
                PaymentAmount = 50m,
                AccountOrTermsText = "Cheque A 90 días"
            });

            // Añadimos la factura recibida con sus pagos al lote
            LotePagosFacturasRecibidas.APInvoices.Add(facturaRecibidaPagadaSegunda);

            return LotePagosFacturasRecibidas;

        }


        // Envía una lote de cobros de facturas recibidas aL SII de la AEAT.
        public void EnviarLotePagosFacturasRecibidas()
        {

            // Creamos el lote de de pago de facturas recibidas en regimen especial
            // de caja al SII de la AEAT.
            APInvoicesPaymentsBatch LotePagosFacturasRecibidas = CrearLotePagosFacturasRecibidas();
            // Envía el lote de pagos de factura recibidas a la AEAT.
            Wsd.SendPagosFacturasRecibidas(LotePagosFacturasRecibidas);


            //Muestra el archivo xml recibido de la AEAT con la respuesta en el 
            // web browser.
            webBrw.Navigate(Settings.Current.InboxPath + 
                LotePagosFacturasRecibidas.GetReceivedFileName());


        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Envía una lote de pagos de facturas recibidas en regimen especial de caja
            // aL SII de la AEAT.
            EnviarLotePagosFacturasRecibidas();           
        }

   
        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guardo la configuración actual.
            Settings.Save();
        }
    }
}
