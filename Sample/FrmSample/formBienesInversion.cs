using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class formBienesInversion : Form
    {

        public formBienesInversion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea lote de bienes inversión.
        /// </summary>
        /// <returns>Lote de facturas recibidas de prueba.</returns>
        private static AssetsBatch CrearLoteBienesInversion()
        {

            // Creamos al titular del lote.
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };

            // Lote de factura recibidas a enviar la AEAT al SII
            AssetsBatch LoteBienesInversion = new AssetsBatch();
            LoteBienesInversion.Titular = titular;
            LoteBienesInversion.CommunicationType = CommunicationType.A0; // Alta de facturas:
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.


            Party comprador = titular; // El titular es el comprador en este caso

            Asset bienInversionPrimero = new Asset();

            bienInversionPrimero.IssueDate = new DateTime(2017, 1, 15);// Fecha de emisión factura
            bienInversionPrimero.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            bienInversionPrimero.BuyerParty = comprador; // Comprador

            bienInversionPrimero.PropertyId = "00001";
            bienInversionPrimero.InitialDate = new DateTime(2017, 1, 15); // Fecha inicio utilización
            bienInversionPrimero.ProrrataAnual = 22.22m; // Prorrata anual
           
            LoteBienesInversion.Assets.Add(bienInversionPrimero); // Añado la factura al lote

            Asset bienInversionSegundo = new Asset(); // Segundo bien inversión

            bienInversionSegundo.IssueDate = new DateTime(2017, 1, 15); // Fecha de emisión factura

            bienInversionSegundo.SellerParty = new Party() // Acreedor (Emisor factura)
            {
                TaxIdentificationNumber =
                "B12756474",
                PartyName = "MAC ORGANIZACION SL"
            };
            bienInversionSegundo.BuyerParty = comprador; // Comprador

            bienInversionPrimero.PropertyId = "00002";
            bienInversionPrimero.InitialDate = new DateTime(2017, 1, 15); // Fecha inicio utilización
            bienInversionPrimero.ProrrataAnual = 50m; // Prorrata anual

            LoteBienesInversion.Assets.Add(bienInversionSegundo); // Añadimos la segunda factura al lote

            return LoteBienesInversion;         


        }

        /// <summary>
        /// Ejemplo de envío de un lote de bienes inversión
        /// </summary>
        public void EnviarLoteBienesInversion()
        {

            // Creamos un lote de bienes inversión
            AssetsBatch LoteBienesInversion = CrearLoteBienesInversion();
            // Realizamos el envío del lote a la AEAT
            Wsd.SendBienesInversion(LoteBienesInversion);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            webBrw.Navigate(Settings.Current.InboxPath +
                LoteBienesInversion.GetReceivedFileName());
                  

        }

      

        private void formMain_Load(object sender, EventArgs e)
        {
            // Rutina de ejemplo de envío de lote de bienes inversión
            EnviarLoteBienesInversion();           
        }


        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }
    }
}
