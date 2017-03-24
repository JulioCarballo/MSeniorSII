using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formFacturasRecibidas : Form
    {

        public formFacturasRecibidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea lote de facturas recibidas.
        /// </summary>
        /// <returns>Lote de facturas recibidas de prueba.</returns>
        private static APInvoicesBatch CrearLoteFacturasRecibidas()
        {

            // Creamos al titular del lote.
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Lote de factura recibidas a enviar la AEAT al SII
            APInvoicesBatch LoteFacturasRecibidas = new APInvoicesBatch();
            LoteFacturasRecibidas.Titular = titular;
            LoteFacturasRecibidas.CommunicationType = CommunicationType.A0; // Alta de facturas:
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.


            Party comprador = titular; // El titular es el comprador en este caso

            //APInvoice facturaRecibidaPrimera = new APInvoice();

            //facturaRecibidaPrimera.IssueDate = new DateTime(2017, 1, 15);// Fecha de emisión factura
            //facturaRecibidaPrimera.PostingDate = new DateTime(2017, 1, 15); // Fecha de contabilización

            //facturaRecibidaPrimera.CountryCode = "US";

            //facturaRecibidaPrimera.SellerParty = new Party() // Acreedor (Emisor factura)
            //{
            //    TaxIdentificationNumber =
            //    "NIF_EXTRANJ",
            //    PartyName = "CLIENTE EXTRANJERO LTD"
            //};


            //facturaRecibidaPrimera.BuyerParty = comprador; // Comprador
            //facturaRecibidaPrimera.InvoiceNumber = "R00001"; // Número de factura
            //facturaRecibidaPrimera.InvoiceType = InvoiceType.F1; // Tipo factura
            //facturaRecibidaPrimera.ClaveRegimenEspecialOTrascendencia = 
            //    ClaveRegimenEspecialOTrascendencia.RegimenComun; 
            //facturaRecibidaPrimera.GrossAmount = 231m; // Importe bruto
            //facturaRecibidaPrimera.InvoiceText = "Servicios consultoria"; // Descripción
            //facturaRecibidaPrimera.AddTaxOtuput(21m, 100m, 21m); // Añadimo líneas de IVA
            //facturaRecibidaPrimera.AddTaxOtuput(10m, 100m, 10m);

            //LoteFacturasRecibidas.APInvoices.Add(facturaRecibidaPrimera); // Añado la factura al lote

            APInvoice facturaRecibidaSegunda = new APInvoice(); // Segunda factura

            facturaRecibidaSegunda.IssueDate = new DateTime(2017, 1, 15); // Fecha de emisión factura
            facturaRecibidaSegunda.PostingDate = new DateTime(2017, 1, 15); // Fecha de contabilización
            facturaRecibidaSegunda.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaRecibidaSegunda.BuyerParty = comprador; // Comprador
            facturaRecibidaSegunda.InvoiceNumber = "R00002"; // Número de factura
            facturaRecibidaSegunda.InvoiceType = InvoiceType.F1; // Tipo de factura
            facturaRecibidaSegunda.ClaveRegimenEspecialOTrascendencia = 
                ClaveRegimenEspecialOTrascendencia.RegimenComun;
            facturaRecibidaSegunda.GrossAmount = 231m; // Importe bruto
            facturaRecibidaSegunda.InvoiceText = "Licencia software"; // Descripción

            facturaRecibidaSegunda.AddTaxOtuput(21m, 100m, 21m); // Añadimo líneas de IVA
            facturaRecibidaSegunda.AddTaxOtuput(10m, 100m, 10m);

            // SI NO AÑADIMOS LÍNEAS DE IVA COGE EL IMPORTE BRUTO COMO BASE EXENTA

            LoteFacturasRecibidas.APInvoices.Add(facturaRecibidaSegunda); // Añadimos la segunda factura al lote

            return LoteFacturasRecibidas;         


        }

        /// <summary>
        /// Ejemplo de envío de un lote de facturas recibidas
        /// </summary>
        public void EnviarLoteFacturasRecibidas()
        {

            // Creamos un lote de factura recibidas
            APInvoicesBatch LoteFacturasRecibidas = 
                CrearLoteFacturasRecibidas();
            // Realizamos el envío del lote a la AEAT
            Wsd.SendFacturasRecibidas(LoteFacturasRecibidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath + 
                LoteFacturasRecibidas.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de lote de facturas recibidas
            EnviarLoteFacturasRecibidas();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
