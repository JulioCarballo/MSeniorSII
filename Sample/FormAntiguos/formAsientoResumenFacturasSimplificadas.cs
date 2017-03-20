using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formAsientoResumenFacturasSimplificadas : Form
    {

        public formAsientoResumenFacturasSimplificadas()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Crea un asiento resumen de facturas simplificadas para su envío al SII
        /// de la aeat.
        /// </summary>
        /// <returns></returns>
        private static ARInvoicesBatch CreaAsientoResumenFacturasSimplificadas()
        {

            // Creamos al titular del envío
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };
  

            ARInvoicesBatch asientoResumenFacturasSimplificadas = new ARInvoicesBatch();
            asientoResumenFacturasSimplificadas.Titular = titular;
            asientoResumenFacturasSimplificadas.CommunicationType = CommunicationType.A0; // alta facturas:
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.

            // El titular del envío también es el emisor de las facturas
            Party emisor = titular;

            // Creo la factura 'asiento resumen' y las anexo al lote            

            ARInvoice facturaAsientoResumentFacturasSimplificadas = new ARInvoice(); // Factura asiento resumen

            facturaAsientoResumentFacturasSimplificadas.IssueDate = new DateTime(2017, 1, 15); // Fecha factura
            facturaAsientoResumentFacturasSimplificadas.SellerParty = emisor; // El emisor de la factura
            facturaAsientoResumentFacturasSimplificadas.BuyerParty = new Party() // El cliente
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaAsientoResumentFacturasSimplificadas.InvoiceNumber = "D00100"; // El número de factura de la primera factura simplificada
            facturaAsientoResumentFacturasSimplificadas.InvoiceNumberLastItem = "D00199"; // El número de la última factura simplificada
            facturaAsientoResumentFacturasSimplificadas.InvoiceType = InvoiceType.F4; // Asiento resumen
            facturaAsientoResumentFacturasSimplificadas.ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun;
            facturaAsientoResumentFacturasSimplificadas.InvoiceText = "Factura"; // Descripción
            facturaAsientoResumentFacturasSimplificadas.AddTaxOtuput(21m, 100m, 21m); // Añadimos las líneas resumen de IVA

            asientoResumenFacturasSimplificadas.ARInvoices.Add(facturaAsientoResumentFacturasSimplificadas); // Añadimos la factura de asiento resumen
            // sólo se permite una factura de este tipo en un lote de facturas a enviar. 
            // si en el lote se incluyen más facturas saltará una excepción         

            return asientoResumenFacturasSimplificadas;          


        }

        /// <summary>
        /// Ejemplo de envío de un asiento resumen de facturas simplificadas
        /// </summary>
        public void EnviarAsientoResumenFacturasSimplificadas()
        {

            // Creamos un lote de factura recibidas
            ARInvoicesBatch asientoResumentFacturasSimplificadas =
                CreaAsientoResumenFacturasSimplificadas();
            // Realizamos el envío del lote a la AEAT
            Wsd.SendFacturasEmitidas(asientoResumentFacturasSimplificadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                asientoResumentFacturasSimplificadas.GetReceivedFileName());                

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de un asiento resumen de facturas simplificadas
            EnviarAsientoResumenFacturasSimplificadas();           
        }



        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
