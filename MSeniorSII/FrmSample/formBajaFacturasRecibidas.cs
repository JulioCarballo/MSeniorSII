using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class formBajaFacturasRecibidas : Form
    {

        public formBajaFacturasRecibidas()
        {
            InitializeComponent();
        }

        // Crea un lote de factura recibidas a eliminar
        private static APInvoicesDeleteBatch CrearLoteFacturaRecibidasEliminar()
        {

            // Titular del lote
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };


            APInvoicesDeleteBatch loteFacturasEmitidasEliminar = new APInvoicesDeleteBatch
            {
                Titular = titular
            };


            // Creamos la primera factura enviada a eliminar
            APInvoice primeraFacturaEliminar = new APInvoice
            {
                IssueDate = new DateTime(2017, 1, 15),
                PostingDate = new DateTime(2017, 1, 15), // Fecha de contabilización
                SellerParty = new Party() // Acreedor (Emisor factura)
                {
                    TaxIdentificationNumber =
                "B12756474",
                    PartyName = "MAC ORGANIZACION SL"
                },
                BuyerParty = titular, // Comprador
                InvoiceNumber = "00001" // Número de factura
            };


            // Añadimos la factura a eliminar al lote
            loteFacturasEmitidasEliminar.APInvoices.Add(primeraFacturaEliminar);

            return loteFacturasEmitidasEliminar;


        }

        // Ejemplo de eliminar una factura emitida comunicada anteriormente al SII
        public void EliminarFacturaRecibida()
        {
            
            // Crea un lote de facturas recibidas envíadas al SII con anterioridad a eliminar
            APInvoicesDeleteBatch loteFacturasRecibidasEliminar = CrearLoteFacturaRecibidasEliminar();
            // Envíamos lote con las peticiones de borrado
            Wsd.DeleteFacturasRecibidas(loteFacturasRecibidasEliminar);


            // Mostramos el xml de respuesta de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                loteFacturasRecibidasEliminar.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Elimina una factura emitida envíada al SII con anterioridad.
            EliminarFacturaRecibida();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
