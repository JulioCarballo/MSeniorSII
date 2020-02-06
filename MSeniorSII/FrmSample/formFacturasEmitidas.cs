using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.IO;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class formFacturasEmitidas : Form
    {

        public formFacturasEmitidas()
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

            // Creamos un lote de facturas recibidas
            ARInvoicesBatch LoteDeFacturasEmitidas = new ARInvoicesBatch();

            // Creamos el titular del envío
            Party titular = new Party()
            {
                TaxIdentificationNumber =
                "B12959755",
                PartyName = "IRENE SOLUTIONS SL"
            };
                      
            LoteDeFacturasEmitidas.Titular = titular;           
            LoteDeFacturasEmitidas.CommunicationType = CommunicationType.A0; // alta facturas:
            // utilizando el tipo de comunicación podemos modificar datos de facturas envíadas
            // anteriormente. En lugar de alta de facturas, podemos elegir modificación.



            // Creo las facturas y las anexo al lote


            // Ejemplo de factura con cliente extranjero con NIF no español
            // en este caso el programa serializa Party en Contraparte.IDOtro
            // hay que establecer la propieda CountryCode ( si no lanza una excepción)
            // y por defecto asigna el tipo de documento otro '06' (se puede cambiar
            // mediante la propiedad IDOtroType de la factura.
            // Cuando el nif comienza por 'N', no residente o no es español, en lugar
            // de informarse el tipo DesgloseFactura se informara el tipo TipoDesglose.
            // En TipoDesglose si la propiedad IsService de la factura es true, se 
            // serializa el detalle como prestación de servicios, en caso contrario como
            // entrega de bienes

            //  Consideramos que el titular del envío también es el emisor de las facturas
            Party emisor = titular;

            ARInvoice facturaEnviadaPrimera = new ARInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha factura
                SellerParty = emisor, // El emisor de la factura


                CountryCode = "DK",


                BuyerParty = new Party() // El cliente
                {
                    TaxIdentificationNumber =
                "DK12345678",
                    PartyName = "CLIENTE EXTRANJERO LTD"
                },
                InvoiceNumber = "E00027", // El número de factura
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,
                GrossAmount = 231m, // Importe bruto
                InvoiceText = "Servicios consultoria" // Descripción
            }; // Primera factura (Ejemplo un poco raro: Sujeta con NIF extranjero)
            facturaEnviadaPrimera.AddTaxOtuput(21m, 100m, 21m); // Añadimos las líneas de IVA
            facturaEnviadaPrimera.AddTaxOtuput(10m, 100m, 10m);

            LoteDeFacturasEmitidas.ARInvoices.Add(facturaEnviadaPrimera); // Añadimos la primera factura al lote

            ARInvoice facturaEnviadaSegunda = new ARInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha factura
                SellerParty = emisor, // Emisor factura
                BuyerParty = new Party() // Cliente
                {
                    TaxIdentificationNumber =
                "B12756474",
                    PartyName = "MAC ORGANIZACION SL"
                },
                InvoiceNumber = "E00028", // Número de factura
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun, // Regimen común
                GrossAmount = 55m, // Importe bruto
                InvoiceText = "Licencia software" // Descripción
            }; // Segunda factura (factura exenta)

            // SI NO AÑADIMOS LÍNEAS DE IVA COGE EL IMPORTE BRUTO COMO BASE EXENTA

            LoteDeFacturasEmitidas.ARInvoices.Add(facturaEnviadaSegunda); // Añadimos la segunda factura al lote

            ARInvoice facturaEnviadaRectificativa = new ARInvoice
            {
                IssueDate = new DateTime(2017, 1, 15), // Fecha factura
                SellerParty = emisor, // Emisor factura
                BuyerParty = new Party() // Cliente
                {
                    TaxIdentificationNumber =
                "B12756474",
                    PartyName = "MAC ORGANIZACION SL"
                },
                InvoiceNumber = "E00029", // Número de factura
                InvoiceType = InvoiceType.R2, // Factura rectificativa
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun, // Regimen común
                GrossAmount = -231m, // Importe bruto
                InvoiceText = "Servicios consultoria" // Descripción
            }; // Tercera factura (factura rectificativa)

            // Para las rectificaciones
            facturaEnviadaRectificativa.InvoicesRectified[0].RectifiedInvoiceNumber = "00000000022";
            facturaEnviadaRectificativa.InvoicesRectified[0].RectifiedIssueDate = new DateTime(2017, 1, 5); // Fecha factura rectificada


            facturaEnviadaRectificativa.AddTaxOtuput(21m, -100m, -21m); // Añadimos las líneas de IVA
            facturaEnviadaRectificativa.AddTaxOtuput(10m, -100m, -10m);



            LoteDeFacturasEmitidas.ARInvoices.Add(facturaEnviadaRectificativa); // Añadimos la segunda factura al lote


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

            // Realizamos el envío del lote a la AEAT
            Wsd.SendFacturasEmitidas(LoteDeFacturasEmitidas);

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
