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
    public partial class formOperIntracomunitarias : Form
    {

        public formOperIntracomunitarias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea lote de facturas recibidas.
        /// </summary>
        /// <returns>Lote de facturas recibidas de prueba.</returns>
        private static IOInvoicesBatch CrearLoteOperIntracom()
        {

            // Creamos al titular del lote.
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Lote de factura recibidas a enviar la AEAT al SII
            IOInvoicesBatch LoteOperIntracom = new IOInvoicesBatch();
            LoteOperIntracom.Titular = titular;
            LoteOperIntracom.CommunicationType = CommunicationType.A0; // Alta de facturas:
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.


            Party comprador = titular; // El titular es el comprador en este caso

            IOInvoice operIntracomPrimera = new IOInvoice();

            operIntracomPrimera.IssueDate = new DateTime(2017, 1, 15);// Fecha de emisión factura (Ejemplo raro, sujeta con nif extranjero)

            operIntracomPrimera.CountryCode = "DK";

            operIntracomPrimera.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "DK12345678",
                PartyName = "CLIENTE EXTRANJERO LTD"
            };

            //
            // Según pruebas realizadas, parece ser que el 'BuyerParty' tiene que ser el mismo que el titular del libro, ya que sino indica un
            // error de que hay que indicar que se trata de un NIF-IVA (02).
            //
            operIntracomPrimera.BuyerParty = titular; // Comprador

            operIntracomPrimera.InvoiceNumber = "OI00016"; // Número de factura

            operIntracomPrimera.OperationType = OperationType.A.ToString();
            operIntracomPrimera.ClaveDeclarado = ClaveDeclarado.D.ToString();

            operIntracomPrimera.EstadoMiembro = "DK";

            operIntracomPrimera.DescripcionBienes = "Descripción de los bienes ...";
            operIntracomPrimera.DireccionOperador = "Dirección del operador ...";

            LoteOperIntracom.IOInvoices.Add(operIntracomPrimera); // Añado la factura al lote
            
            return LoteOperIntracom;


        }

        /// <summary>
        /// Ejemplo de envío de un lote de facturas recibidas
        /// </summary>
        public void EnviarLoteOperIntracom()
        {

            // Creamos un lote de factura recibidas
            IOInvoicesBatch LoteOperIntracom = 
                CrearLoteOperIntracom();

            // Realizamos el envío del lote a la AEAT
            Wsd.SendOperIntracom(LoteOperIntracom);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                LoteOperIntracom.GetReceivedFileName());

        }

        public void MostrarLoteOperIntracom()
        {

            // Creamos un lote de factura recibidas
            IOInvoicesBatch LoteOperIntracom =
                CrearLoteOperIntracom();

            string tmpath = Path.GetTempFileName();

            // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
            LoteOperIntracom.GetXml(tmpath);

            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = tmpath;

            frmXmlViewer.ShowDialog();

        }

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de lote de facturas recibidas
            //EnviarLoteOperIntracom();

            // Rutina para mostrar el lote antes de ser enviado.
            MostrarLoteOperIntracom();           
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
