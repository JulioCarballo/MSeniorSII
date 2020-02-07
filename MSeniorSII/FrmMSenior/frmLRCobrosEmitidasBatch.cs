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

namespace MSeniorSII
{
    public partial class FrmLRCobrosEmitidasBatch : Form
    {

        ARInvoicesPaymentsBatch _LoteDeCobrosEmitidas;
        Party _Titular;
        Party _Emisor;
        ARInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public FrmLRCobrosEmitidasBatch()
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

            lbNifCert.Text = "";
            lbNroSerie.Text = "";
        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new ARInvoice
            {
                SellerParty = _Emisor, // El emisor de la factura
                BuyerParty = new Party() // El cliente
            }; // factura

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

            if (!DateTime.TryParse(txIssueDate.Text, out DateTime issueDate))
            {
                string _msg = "Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txIssueDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txClienteTaxIdentificationNumber.Text))
            {
                string _msg = "Debe introducir un NIF de cliente";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    if (!Enum.TryParse<PaymentTerms>(row.Cells[2].Value.ToString(), out PaymentTerms tipoCobro))
                    {
                        string _msg = ($"El tipo de cobro {row.Cells[2].Value} es deconocido.");
                        MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


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
                    invoice, MSeniorSII.Properties.Resources.Ribbon_New_32x32);

            if (_SeletedInvoiceIndex != -1)
                grdInvoices.Rows[_SeletedInvoiceIndex].Selected = true;


        }

        private void BindObtCertificado()
        {
            string _NIFEmpresa = txEmisorTaxIdentificationNumber.Text;
            string _NomEmpresa = "";
            string _NroSerie = "";

            ObtCertificado fncCertificado = new ObtCertificado();
            fncCertificado.BuscaCertificadoDigital(ref _NIFEmpresa, ref _NomEmpresa, ref _NroSerie);

            txEmisorPartyName.Text = _NomEmpresa;
            lbNifCert.Text = _NIFEmpresa;
            lbNroSerie.Text = _NroSerie;
        }

        /// <summary>
        /// Convierte una cadena en un valor decimal.
        /// En caso de nulo o error devuelve cero.
        /// </summary>
        /// <param name="nstr">Cadena a convertir.</param>
        /// <returns>Valor decimal represantedo por la cadena.</returns>
        private decimal ToAmount(object numstr)
        {
            decimal.TryParse((numstr ?? "0").ToString(), out decimal valordec);
            return valordec;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _TextBoxes = new List<Control>();
            GetTextBoxes(this, _TextBoxes);

            //ObtCertificado fncCertificado = new ObtCertificado();
            //string _NIFEmpresa = "";
            //string _NomEmpresa = "";
            //fncCertificado.ObtCertificadoDigital(ref _NIFEmpresa, ref _NomEmpresa);
            //txEmisorPartyName.Text = _NomEmpresa;
            //txEmisorTaxIdentificationNumber.Text = _NIFEmpresa;

            Inizialize();

        }


        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Guarda la configuración actual
            Settings.Save();
        }

        private void TxTaxIdentificationNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxPartyName_TextChanged(object sender, EventArgs e)
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

        private void BtAddFactura_Click(object sender, EventArgs e)
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

        private void MnViewXML_Click(object sender, EventArgs e)
        {

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteDeCobrosEmitidas.GetXml(tmpath);

                FormXmlViewer frmXmlViewer = new FormXmlViewer
                {
                    Path = tmpath
                };

                frmXmlViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void MnSendXML_Click(object sender, EventArgs e)
        {
            try
            {
                EnviaLoteEnCurso();
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviaLoteEnCurso()
        {
            // Realizamos el envío del lote a la AEAT
            Wsd.SendCobrosFacturasEmitidas(_LoteDeCobrosEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _LoteDeCobrosEmitidas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRCobrosEmitidas;

            if (respuesta == null)
            {
                SoapFault msgError = new Envelope(frmXmlViewer.Path).Body.RespuestaError;
                if (msgError != null)
                {
                    MessageBox.Show(msgError.FaultDescription, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                        row.Cells[5].Value = MSeniorSII.Properties.Resources.circle_green;
                    else
                    {
                        row.Cells[5].Value = MSeniorSII.Properties.Resources.circle_red;
                        row.Cells[6].Value = respuestaFra.DescripcionErrorRegistro;
                    }
            }

            if (respuesta.EstadoEnvio == "Correcto")
            {
                string _msg = ($"Estado del envío realizado a la AEAT: {respuesta.EstadoEnvio}.\nCódigo CSV: {respuesta.CSV}");
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void GrpEmisor_Enter(object sender, EventArgs e)
        {

        }

        private void MnSettings_Click(object sender, EventArgs e)
        {
            formSettings frmSettings = new formSettings();
            frmSettings.ShowDialog();
        }

        private void MnLoad_Click(object sender, EventArgs e)
        {

            dlgOpen.ShowDialog();

            if (string.IsNullOrEmpty(dlgOpen.FileName))
                return;

            string FullPath = dlgOpen.FileName;

            Envelope envelope = new Envelope(FullPath);


            if (envelope.Body.SuministroLRCobrosEmitidas == null)
            {
                string _msg = "No es un lote de cobros de facturas emitidas.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            _LoteDeCobrosEmitidas = new ARInvoicesPaymentsBatch(envelope.Body.SuministroLRCobrosEmitidas);

            _Emisor = _Titular = _LoteDeCobrosEmitidas.Titular;

            BindViewEmisor();
            BindViewFactura();
            BindViewInvoices();

            BindObtCertificado();

        }

        private void GrdFacturas_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void GrdFacturas_DoubleClick(object sender, EventArgs e)
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
                string _msg = ($"No existe la factura nº {index}");
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void TxClienteTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void TxEmisorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txEmisorTaxIdentificationNumber.Text))
            {
                BindObtCertificado();
            }
        }
    }
}
