using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formBajaFacturasEmitidas : Form
    {

        public formBajaFacturasEmitidas()
        {
            InitializeComponent();
        }

        // Crea un lote de factura emitidas a eliminar
        private static ARInvoicesDeleteBatch CrearLoteFacturasEnviadasEliminar()
        {

            // Titular del lote
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };


            ARInvoicesDeleteBatch loteFacturasEmitidasEliminar = new ARInvoicesDeleteBatch();
            loteFacturasEmitidasEliminar.Titular = titular;

            Party emisor = titular;

            // Creamos la primera factura enviada a eliminar
            ARInvoice primeraFacturaEliminar = new ARInvoice();
            primeraFacturaEliminar.IssueDate = new DateTime(2017, 1, 15);
            primeraFacturaEliminar.InvoiceNumber = "00001";
            primeraFacturaEliminar.SellerParty = emisor;

            // Añadimos la factura a eliminar al lote
            loteFacturasEmitidasEliminar.ARInvoices.Add(primeraFacturaEliminar);

            return loteFacturasEmitidasEliminar;


        }

        // Ejemplo de eliminar una factura emitida comunicada anteriormente al SII
        public void EliminarFacturaEmitida()
        {
            
            // Crea un lote de facturas enviada al SII con anterioridad a eliminar
            ARInvoicesDeleteBatch loteFacturasEnviadasEliminar = CrearLoteFacturasEnviadasEliminar();
            // Envíamos lote con las peticiones de borrado
            Wsd.DeleteFacturasEmitidas(loteFacturasEnviadasEliminar);


            // Mostramos el xml de respuesta de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath + 
                loteFacturasEnviadasEliminar.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Elimina una factura emitida envíada al SII con anterioridad.
            EliminarFacturaEmitida();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
