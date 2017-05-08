using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;
using System.IO;
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

            APInvoice facturaRecibidaPrimera = new APInvoice();

            facturaRecibidaPrimera.IssueDate = new DateTime(2017, 1, 15);// Fecha de emisión factura (Ejemplo raro, sujeta con nif extranjero)
            facturaRecibidaPrimera.PostingDate = new DateTime(2017, 1, 15); // Fecha de contabilización

            facturaRecibidaPrimera.CountryCode = "DK";

            facturaRecibidaPrimera.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "DK12345678",
                PartyName = "CLIENTE EXTRANJERO LTD"
            };


            facturaRecibidaPrimera.BuyerParty = comprador; // Comprador
            facturaRecibidaPrimera.InvoiceNumber = "R00016"; // Número de factura
            facturaRecibidaPrimera.InvoiceType = InvoiceType.F1; // Tipo factura
            facturaRecibidaPrimera.ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun;
            facturaRecibidaPrimera.GrossAmount = 231m; // Importe bruto
            facturaRecibidaPrimera.InvoiceText = "Servicios consultoria"; // Descripción
            facturaRecibidaPrimera.AddTaxOtuput(21m, 100m, 21m); // Añadimo líneas de IVA
            facturaRecibidaPrimera.AddTaxOtuput(10m, 100m, 10m);

            LoteFacturasRecibidas.APInvoices.Add(facturaRecibidaPrimera); // Añado la factura al lote

            APInvoice facturaRecibidaSegunda = new APInvoice(); // Segunda factura (Factura exenta)

            facturaRecibidaSegunda.IssueDate = new DateTime(2017, 1, 15); // Fecha de emisión factura
            facturaRecibidaSegunda.PostingDate = new DateTime(2017, 1, 15); // Fecha de contabilización
            facturaRecibidaSegunda.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaRecibidaSegunda.BuyerParty = comprador; // Comprador
            facturaRecibidaSegunda.InvoiceNumber = "R00017"; // Número de factura
            facturaRecibidaSegunda.InvoiceType = InvoiceType.F1; // Tipo de factura
            facturaRecibidaSegunda.ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun;
            facturaRecibidaSegunda.GrossAmount = 55m; // Importe bruto
            facturaRecibidaSegunda.InvoiceText = "Licencia software"; // Descripción         

            facturaRecibidaSegunda.AddTaxOtuput(0m, 55m, 0m); // Añadimo líneas de IVA

            LoteFacturasRecibidas.APInvoices.Add(facturaRecibidaSegunda); // Añadimos la segunda factura al lote


            APInvoice facturaRecibidaRectificativa = new APInvoice(); // Tercera factura (Ejemplo rectificativa)

            facturaRecibidaRectificativa.IssueDate = new DateTime(2017, 1, 15); // Fecha de emisión factura
            facturaRecibidaRectificativa.PostingDate = new DateTime(2017, 1, 15); // Fecha de contabilización
            facturaRecibidaRectificativa.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            facturaRecibidaRectificativa.BuyerParty = comprador; // Comprador
            facturaRecibidaRectificativa.InvoiceNumber = "R00018"; // Número de factura
            facturaRecibidaRectificativa.InvoiceType = InvoiceType.R2; // Tipo de factura
            facturaRecibidaRectificativa.ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun;
            facturaRecibidaRectificativa.GrossAmount = -231m; // Importe bruto
            facturaRecibidaRectificativa.InvoiceText = "Licencia software"; // Descripción

            // Para las rectificaciones
            facturaRecibidaRectificativa.InvoicesRectified[0].RectifiedInvoiceNumber = "00000000022";
            facturaRecibidaRectificativa.InvoicesRectified[0].RectifiedIssueDate = new DateTime(2017, 1, 5); // Fecha factura rectificada

            facturaRecibidaRectificativa.AddTaxOtuput(21m, -100m, -21m); // Añadimo líneas de IVA
            facturaRecibidaRectificativa.AddTaxOtuput(10m, -100m, -10m);
            
            LoteFacturasRecibidas.APInvoices.Add(facturaRecibidaRectificativa); // Añadimos la segunda factura al lote

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





            /*****************************************/

            //Envelope envelope = LoteFacturasRecibidas.GetEnvelope();

            //SuministroLRFacturasRecibidas slrFrasRecibidas =  envelope.Body.SuministroLRFacturasRecibidas;

            //FacturaRecibida fraRecibida = slrFrasRecibidas.RegistroLRFacturasRecibidas[0].FacturaRecibida;

            //fraRecibida.TipoRectificativa = "I";

            //fraRecibida.FacturasRectificadas = new List<IDFactura>();
            //fraRecibida.FacturasRectificadas.Add(new IDFactura());
            //fraRecibida.FacturasRectificadas[0].NumSerieFacturaEmisor = "000000000055";
            //fraRecibida.FacturasRectificadas[0].FechaExpedicionFacturaEmisor =
            //    "01-01-2015" ;
            //// En este caso pongo a null IDEmisorFactura para que no serialice una etiqueta vacía.
            //fraRecibida.FacturasRectificadas[0].IDEmisorFactura = null;

            ////fraRecibida.FacturasRectificadas = new EasySII.Xml.Sii.FacturasRectificadas();
            ////fraRecibida.FacturasRectificadas.IDFacturaRectificada = new IDFactura();
            ////fraRecibida.FacturasRectificadas.IDFacturaRectificada.NumSerieFacturaEmisor = "00000000022";
            ////fraRecibida.FacturasRectificadas.IDFacturaRectificada.FechaExpedicionFacturaEmisor = "01-01-2015";

            //string response = Wsd.Send(envelope);
            //string file = Settings.Current.InboxPath +
            // LoteFacturasRecibidas.GetReceivedFileName();

            //File.WriteAllText(file, response);

            //webBrw.Navigate(file);

            //return;

            /*****************************************/

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
