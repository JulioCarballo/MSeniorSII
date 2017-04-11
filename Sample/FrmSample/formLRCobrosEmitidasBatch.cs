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
    public partial class formLRCobrosEmitidasBatch : Form
    {

        ARInvoicesPaymentsBatch _LoteDeCobrosEmitidas;
        Party _Titular;
        Party _Emisor;
        ARInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public formLRCobrosEmitidasBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDeCobrosEmitidas = new ARInvoicesPaymentsBatch();

            _Titular = new Party();
            _Emisor = _Titular;

            _LoteDeCobrosEmitidas.Titular = _Titular;

            ResetFactura();     

            BindModelEmisor();

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new ARInvoice(); // factura

            _FacturaEnCurso.SellerParty = _Emisor; // El emisor de la factura
            _FacturaEnCurso.BuyerParty = new Party(); // El cliente

            ChangeCurrentInvoiceIndex(-1);

        }

        /// <summary>
        /// Emisor: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelEmisor()
        {
            _Emisor.TaxIdentificationNumber = txEmisorTaxIdentificationNumber.Text;
            _Emisor.PartyName = txEmisorPartyName.Text;

            _Titular = _Emisor;
            _LoteDeCobrosEmitidas.Titular = _Titular;

        }

        /// <summary>
        /// Emisor: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewEmisor()
        {
            txEmisorTaxIdentificationNumber.Text = _Emisor.TaxIdentificationNumber;
            txEmisorPartyName.Text = _Emisor.PartyName;
        }

        /// <summary>
        /// Cliente: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelCliente()
        {
            _FacturaEnCurso.BuyerParty.TaxIdentificationNumber = txClienteTaxIdentificationNumber.Text;
            _FacturaEnCurso.BuyerParty.PartyName = txClientePartyName.Text;
        }

        /// <summary>
        /// Cliente: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewCliente()
        {
            txClienteTaxIdentificationNumber.Text = _FacturaEnCurso.BuyerParty.TaxIdentificationNumber;
            txClientePartyName.Text = _FacturaEnCurso.BuyerParty.PartyName;
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

            if (string.IsNullOrEmpty(txClienteTaxIdentificationNumber.Text))
            {
                MessageBox.Show("Debe introducir un NIF de cliente");
                txClienteTaxIdentificationNumber.Focus();
                return;
            }

            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(issueDate);

            _FacturaEnCurso.ARInvoicePayments.Clear();

            foreach (DataGridViewRow row in grdCobros.Rows)
            {
                ARInvoicePayment CobroFact = new ARInvoicePayment();

                if (row.Cells[0].Value != null)
                {
                    CobroFact.PaymentDate = Convert.ToDateTime(row.Cells[0].Value);
                    CobroFact.PaymentAmount = Convert.ToDecimal(row.Cells[1].Value);

                    PaymentTerms tipoCobro;
                    if (!Enum.TryParse<PaymentTerms>(row.Cells[2].Value.ToString(), out tipoCobro))
                        MessageBox.Show($"El tipo de cobro {row.Cells[2].Value} es deconocido.");

                    CobroFact.PaymentTerm = tipoCobro;

                    _FacturaEnCurso.ARInvoicePayments.Add(CobroFact);
                }
            }

            // Cliente
            BindModelCliente();
        }

        /// <summary>
        /// Factura: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewFactura()
        {

            grdCobros.Rows.Clear();

            txInvoiceNumber.Text = _FacturaEnCurso.InvoiceNumber;
            txIssueDate.Text = (_FacturaEnCurso.IssueDate==null) ? "" : 
                (_FacturaEnCurso.IssueDate??new DateTime( 1, 1, 1)).ToString("dd/MM/yyyy");

            foreach (ARInvoicePayment cobro in _FacturaEnCurso.ARInvoicePayments)
                grdCobros.Rows.Add(cobro.PaymentDate, cobro.PaymentAmount, cobro.PaymentTerm);

            // Cliente
            BindViewCliente();

        }

        private void BindViewInvoices()
        {

            grdInvoices.Rows.Clear();

            foreach (var invoice in _LoteDeCobrosEmitidas.ARInvoices)
                grdInvoices.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate,
                    invoice.BuyerParty.TaxIdentificationNumber, invoice.BuyerParty.PartyName,
                    invoice, Sample.Properties.Resources.Ribbon_New_32x32);

            if (_SeletedInvoiceIndex != -1)
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
                txEmisorPartyName.Text = tokens[0].Trim();
                txEmisorTaxIdentificationNumber.Text = tokens[1].Replace("CIF","").Replace("NIF","").Trim();
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

        private void BindModelEmisor_Validated(object sender, EventArgs e)
        {
            BindModelEmisor();
        }

        private void BindModelCliente_Validated(object sender, EventArgs e)
        {
            BindModelCliente();
        }

        private void btAddFactura_Click(object sender, EventArgs e)
        {
            BindModelEmisor();
            BindModelFactura();

            if(_SeletedInvoiceIndex == -1) // La factura es nueva: la añado
                _LoteDeCobrosEmitidas.ARInvoices.Add(_FacturaEnCurso);

            ResetFactura();

            BindViewFactura();

            BindViewInvoices();

            txClienteTaxIdentificationNumber.Focus();

        }

 

        private void mnViewXML_Click(object sender, EventArgs e)
        {

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteDeCobrosEmitidas.GetXml(tmpath);

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
            Wsd.SendCobrosFacturasEmitidas(_LoteDeCobrosEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath +
                _LoteDeCobrosEmitidas.GetReceivedFileName();

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRCobrosEmitidas;

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


            if (envelope.Body.SuministroLRCobrosEmitidas == null)
            {
                MessageBox.Show("No es un lote de cobros de facturas emitidas.");
                return;
            }

            _LoteDeCobrosEmitidas = new ARInvoicesPaymentsBatch(envelope.Body.SuministroLRCobrosEmitidas);

            _Emisor = _Titular = _LoteDeCobrosEmitidas.Titular;

            BindViewEmisor();
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
                _FacturaEnCurso = (ARInvoice)grdInvoices.SelectedRows[0].Cells[4].Value;
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewEmisor();
                BindViewCliente();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteDeCobrosEmitidas.ARInvoices.Count - 1)
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

        private void txClienteTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
