using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Tax;
using EasySII.Xml.SiiR;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MSeniorSII
{
    public partial class formLRPagosRecibidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        APPaymentsQuery _PetPagoFactRecEnviadas;
        Party _Titular;
        Party _Buyer;
        APInvoice _FacturaParaBuscar;

        List<Control> _TextBoxes;

        public formLRPagosRecibidasQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _PetPagoFactRecEnviadas = new APPaymentsQuery();

            _Titular = new Party();
            _Buyer = _Titular;

            _PetPagoFactRecEnviadas.Titular = _Titular;

            ResetFactura();     

            BindModelBuyer();

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaParaBuscar = new APInvoice
            {
                BuyerParty = _Buyer, // El emisor de la factura
                SellerParty = new Party() // El cliente
            }; // factura

        }

        /// <summary>
        /// Buyer: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelBuyer()
        {
            _Buyer.TaxIdentificationNumber = txBuyerTaxIdentificationNumber.Text;
            _Buyer.PartyName = txBuyerPartyName.Text;

            _Titular = _Buyer;
            _PetPagoFactRecEnviadas.Titular = _Titular;
        }

        /// <summary>
        /// Acreedor: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelAcreedor()
        {
            _FacturaParaBuscar.SellerParty.TaxIdentificationNumber = txAcreedorTaxIdentificationNumber.Text;
            _FacturaParaBuscar.SellerParty.PartyName = txAcreedorPartyName.Text;
        }

        /// <summary>
        /// Factura: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelBusqueda()
        {

            // Chequear datos

            DateTime issueDate;

            if (!DateTime.TryParse(txIssueDate.Text, out issueDate))
            {
                MessageBox.Show("Debe introducir una fecha correcta");
                txIssueDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txAcreedorTaxIdentificationNumber.Text))
            {
                MessageBox.Show("Debe introducir un NIF de Acreedor");
                txAcreedorTaxIdentificationNumber.Focus();
                return;
            }


            if (!string.IsNullOrEmpty(txCountry.Text))
            {
                _FacturaParaBuscar.CountryCode = txCountry.Text;
            }

            _FacturaParaBuscar.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaParaBuscar.IssueDate = Convert.ToDateTime(issueDate);

            // Acreedor
            BindModelAcreedor();

            _PetPagoFactRecEnviadas.APInvoice = _FacturaParaBuscar;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            _TextBoxes = new List<Control>();
            GetTextBoxes(this, _TextBoxes);

            var cert = Wsd.GetCertificate();

            if (cert == null)
            {
                MessageBox.Show("Debe configurar un certificado digital para utilizar la aplicación.");
            }

            string cn = cert.Subject.Replace("CN=", "");

            string[] tokens = cn.Split('-');

            string nifCandidate = tokens[1].Replace("CIF", "").Replace("NIF", "").Trim();

            if (tokens.Length > 1 && nifCandidate.Length==9)
            { 
                txBuyerPartyName.Text = tokens[0].Trim();
                txBuyerTaxIdentificationNumber.Text = tokens[1].Replace("CIF","").Replace("NIF","").Trim();
            }

            Inizialize();

        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }

        private void BindModelBuyer_Validated(object sender, EventArgs e)
        {
            BindModelBuyer();
        }

        private void BindModelAcreedor_Validated(object sender, EventArgs e)
        {
            BindModelAcreedor();
        }

        private void btBuscaFact_Click(object sender, EventArgs e)
        {
            BindModelBuyer();
            BindModelBusqueda();

            Wsd.GetFacturasRecibidasPagos (_PetPagoFactRecEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _PetPagoFactRecEnviadas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaConsultaPagos respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaPagos;

            if (respuesta == null)
            {
                DialogResult resultMsg;
                string _msgError = "Se ha recibido una respuesta inesperada. Pulse 'Aceptar', si quiere revisarla";
                resultMsg = MessageBox.Show(_msgError, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (resultMsg == DialogResult.OK)
                    frmXmlViewer.ShowDialog();

                return;
            }

            // Tenemos que recorrernos la respuesta y rellenar el datagrid con los datos de cada factura.
            grdInvoices.Rows.Clear();

            if (respuesta.ResultadoConsulta == "ConDatos")
            {
                foreach (var invoice in respuesta.RegistroRespuestaConsultaPagos)
                {
                    System.Drawing.Icon _marcaFact = MSeniorSII.Properties.Resources.Tag_Ok;

                    decimal TotalTmp = Convert.ToDecimal(invoice.Pago.Importe, DefaultNumberFormatInfo);

                    grdInvoices.Rows.Add(invoice.Pago.Fecha, TotalTmp.ToString("#,##0.00"), invoice.Pago.Medio, invoice.Pago.Cuenta_O_Medio,
                    invoice, _marcaFact, invoice.DatosPresentacion.TimestampPresentacion);
                }
            }
        }

        private void mnSettings_Click(object sender, EventArgs e)
        {
            formSettings frmSettings = new formSettings();
            frmSettings.ShowDialog();
        }

        private void GetTextBoxes(Control parent, List<Control> controls)
        {
            foreach (Control ctl in parent.Controls)
                if (ctl.GetType() == typeof(TextBox))
                    controls.Add(ctl);
                else
                    if (ctl.GetType().GetProperty("Controls")!=null)
                        GetTextBoxes((Control)ctl, controls);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txb = sender as TextBox;
                foreach (var ctxb in _TextBoxes)
                { 
                    if (txb.TabIndex + 1 == ctxb.TabIndex)
                    { 
                        ctxb.Focus();
                        ((TextBox)ctxb).SelectAll();
                    }
                }

                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void txAcreedorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txAcreedorTaxIdentificationNumber.Text))
            {
                // Bandera que indica si el NIF es o no es español

                bool IsNotNifES = false;
                TaxIdEs taxIdEs = null;

                try
                {
                    taxIdEs = new TaxIdEs(txAcreedorTaxIdentificationNumber.Text);
                }
                catch 
                {
                    IsNotNifES = true;
                }

                if (taxIdEs != null)
                    IsNotNifES = !taxIdEs.IsDCOK;

                if (IsNotNifES)
                {
                    lblNifInf.Text = "Id. fiscal no español.";
                    string country = General.GetCountry();
                    if (string.IsNullOrEmpty(country))
                    {
                        MessageBox.Show("Introducción de NIF cancelada. Para NIF no españoles debe seleccionar un país.");
                        txAcreedorTaxIdentificationNumber.Text = "";
                        lblNifInf.Text = "";
                        txCountry.Visible = false;
                    }
                    else
                    {
                        txCountry.Visible = true;
                        txCountry.Text = country;
                    }
                }
                else
                {
                    txCountry.Visible = false;
                    txCountry.Text = "";
                }
            }
            else
            {
                lblNifInf.Text = "";
                txCountry.Visible = false;
            }
        }

    }
}
