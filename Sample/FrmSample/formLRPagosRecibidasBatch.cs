using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Tax;
using EasySII.Xml.SiiR;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Sample
{
    public partial class formLRPagosRecibidasBatch : Form
    {

        APInvoicesPaymentsBatch _LoteDePagosRecibidas;
        Party _Titular;
        Party _Buyer;
        APInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public formLRPagosRecibidasBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDePagosRecibidas = new APInvoicesPaymentsBatch();

            _Titular = new Party();
            _Buyer = _Titular;

            _LoteDePagosRecibidas.Titular = _Titular;

            ResetFactura();     

            BindModelBuyer();

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new APInvoice(); // factura

            _FacturaEnCurso.BuyerParty = _Buyer; // El emisor de la factura
            _FacturaEnCurso.SellerParty = new Party(); // El cliente

            ChangeCurrentInvoiceIndex(-1);

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
            _LoteDePagosRecibidas.Titular = _Titular;
        }

        /// <summary>
        /// Buyer: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewBuyer()
        {
            txBuyerTaxIdentificationNumber.Text = _Buyer.TaxIdentificationNumber;
            txBuyerPartyName.Text = _Buyer.PartyName;
        }

        /// <summary>
        /// Acreedor: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelAcreedor()
        {
            _FacturaEnCurso.SellerParty.TaxIdentificationNumber = txAcreedorTaxIdentificationNumber.Text;
            _FacturaEnCurso.SellerParty.PartyName = txAcreedorPartyName.Text;
        }

        /// <summary>
        /// Acreedor: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewAcreedor()
        {
            txAcreedorTaxIdentificationNumber.Text = _FacturaEnCurso.SellerParty.TaxIdentificationNumber;
            txAcreedorPartyName.Text = _FacturaEnCurso.SellerParty.PartyName;
        }

        /// <summary>
        /// Factura: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelFactura()
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
                _FacturaEnCurso.CountryCode = txCountry.Text;
            }

            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(issueDate);

            _FacturaEnCurso.APInvoicePayments.Clear();

            foreach (DataGridViewRow row in grdPagos.Rows)
            {
                APInvoicePayment PagoFact = new APInvoicePayment();

                if (row.Cells[0].Value != null)
                {
                    PagoFact.PaymentDate = Convert.ToDateTime(row.Cells[0].Value);
                    PagoFact.PaymentAmount = ToAmount(row.Cells[1].Value);

                    PaymentTerms tipoCobro;
                    if (!Enum.TryParse<PaymentTerms>(row.Cells[2].Value.ToString(), out tipoCobro))
                        MessageBox.Show($"El tipo de cobro {row.Cells[2].Value} es deconocido.");

                    PagoFact.PaymentTerm = tipoCobro;

                    _FacturaEnCurso.APInvoicePayments.Add(PagoFact);
                }
            }

            // Acreedor
            BindModelAcreedor();
        }

        /// <summary>
        /// Factura: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewFactura()
        {

            grdPagos.Rows.Clear();

            txInvoiceNumber.Text = _FacturaEnCurso.InvoiceNumber;
            txIssueDate.Text = (_FacturaEnCurso.IssueDate==null) ? "" : 
                (_FacturaEnCurso.IssueDate??new DateTime( 1, 1, 1)).ToString("dd/MM/yyyy");

            foreach (APInvoicePayment cobro in _FacturaEnCurso.APInvoicePayments)
                grdPagos.Rows.Add(cobro.PaymentDate, cobro.PaymentAmount, cobro.PaymentTerm);

            // Acreedor
            BindViewAcreedor();

        }

        private void BindViewInvoices()
        {

            grdInvoices.Rows.Clear();

            foreach (var invoice in _LoteDePagosRecibidas.APInvoices)
                grdInvoices.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate,
                    invoice.SellerParty.TaxIdentificationNumber, invoice.SellerParty.PartyName,
                    invoice, Sample.Properties.Resources.Ribbon_New_32x32);

            if (_SeletedInvoiceIndex != -1 && _SeletedInvoiceIndex < grdInvoices.Rows.Count)
                grdInvoices.Rows[_SeletedInvoiceIndex].Selected = true;


        }

        /// <summary>
        /// Convierte una cadena en un valor decimal.
        /// En caso de nulo o error devuelve cero.
        /// </summary>
        /// <param name="nstr">Cadena a convertir.</param>
        /// <returns>Valor decimal represantedo por la cadena.</returns>
        private decimal ToAmount(object nstr)
        {
            decimal r = 0;
            decimal.TryParse((nstr??"0").ToString(), out r);
            return r;
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

        private void txTaxIdentificationNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txPartyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BindModelBuyer_Validated(object sender, EventArgs e)
        {
            BindModelBuyer();
        }

        private void BindModelAcreedor_Validated(object sender, EventArgs e)
        {
            BindModelAcreedor();
        }

        private void btAddFactura_Click(object sender, EventArgs e)
        {
            BindModelBuyer();
            BindModelFactura();

            if(_SeletedInvoiceIndex == -1) // La factura es nueva: la añado
                _LoteDePagosRecibidas.APInvoices.Add(_FacturaEnCurso);

            ResetFactura();

            BindViewFactura();

            BindViewInvoices();

            txAcreedorTaxIdentificationNumber.Focus();

        }

        private void mnViewXML_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteDePagosRecibidas.GetXml(tmpath);

                formXmlViewer frmXmlViewer = new formXmlViewer();
                frmXmlViewer.Path = tmpath;

                frmXmlViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnSendXML_Click(object sender, EventArgs e)
        {
            try
            {
                EnviaLoteEnCurso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnviaLoteEnCurso()
        {
            // Realizamos el envío del lote a la AEAT
            Wsd.SendPagosFacturasRecibidas (_LoteDePagosRecibidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath +
                _LoteDePagosRecibidas.GetReceivedFileName();

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRPagosRecibidas;

            if (respuesta == null)
            {
                DialogResult resultMsg;
                string _msgError = "Se ha recibido una respuesta inesperada. Pulse 'Aceptar', si quiere revisarla";
                resultMsg = MessageBox.Show(_msgError, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (resultMsg == DialogResult.OK)
                    frmXmlViewer.ShowDialog();

                return;
            }

            foreach (DataGridViewRow row in grdInvoices.Rows) // Recorro las facturas enviadas
            {
                string numFra = row.Cells[0].Value.ToString();

                // Busco en las líneas de la respuesta el número de factura
                var linqQryFra = from respuestaFra in respuesta.RespuestaLinea
                                 where respuestaFra.IDFactura.NumSerieFacturaEmisor == numFra
                                 select respuestaFra;

                // Si el estado del registro es correcto lo marco como ok
                foreach (RespuestaLinea respuestaFra in linqQryFra)
                    if (respuestaFra.EstadoRegistro == "Correcto")
                        row.Cells[5].Value = Sample.Properties.Resources.circle_green;
                    else
                        row.Cells[5].Value = Sample.Properties.Resources.circle_red;
            }

            MessageBox.Show($"Estado del envío realizado a la AEAT: {respuesta.EstadoEnvio}.\nCódigo CVS: {respuesta.CSV}");

        }

        private void grpEmisor_Enter(object sender, EventArgs e)
        {

        }

        private void mnSettings_Click(object sender, EventArgs e)
        {
            formSettings frmSettings = new formSettings();
            frmSettings.ShowDialog();
        }

        private void mnLoad_Click(object sender, EventArgs e)
        {

            dlgOpen.ShowDialog();

            if (string.IsNullOrEmpty(dlgOpen.FileName))
                return;

            string FullPath = dlgOpen.FileName;

            Envelope envelope = new Envelope(FullPath);
  

            if (envelope.Body.SuministroLRPagosRecibidas == null)
            {
                MessageBox.Show("No es un lote de pagos de facturas recibidas.");
                return;
            }

            ResetFactura();
            
            _LoteDePagosRecibidas = new APInvoicesPaymentsBatch(envelope.Body.SuministroLRPagosRecibidas);

            _Buyer = _Titular = _LoteDePagosRecibidas.Titular;

            BindViewBuyer();
            BindViewFactura();
            BindViewInvoices();

        }

        private void grdFacturas_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void grdFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (grdInvoices.SelectedRows.Count > 0)
            { 
                _FacturaEnCurso = (APInvoice)grdInvoices.SelectedRows[0].Cells[4].Value;
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewBuyer();
                BindViewAcreedor();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteDePagosRecibidas.APInvoices.Count - 1)
            {
                MessageBox.Show($"No existe la factura nº {index}");
            }
            lbIndexlInf.Text =(index==-1) ? "Editando nueva factura" : $"Editando factura nº {index+1}";
            _SeletedInvoiceIndex = index;
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
