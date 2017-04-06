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
    public partial class frmLROperIntracomBatch : Form
    {

        ITInvoicesBatch _LoteOperIntracom;
        Party _Titular, _Buyer, _Seller;
        ITInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public frmLROperIntracomBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteOperIntracom = new ITInvoicesBatch();
            _LoteOperIntracom.CommunicationType = CommunicationType.A0; // alta facturas:

            _Titular = new Party();
            _Buyer = new Party();
            _Seller = new Party();
            //_Buyer = _Titular;

            _LoteOperIntracom.Titular = _Titular;

            ResetFactura();     

            BindModelTitular();

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new ITInvoice(); // factura

            //_FacturaEnCurso.BuyerParty = _Buyer; // El emisor de la factura
            _FacturaEnCurso.BuyerParty = new Party();
            _FacturaEnCurso.SellerParty = new Party(); // El cliente

            ChangeCurrentInvoiceIndex(-1);

        }

        /// <summary>
        /// Buyer: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelTitular()
        {
            _Titular.TaxIdentificationNumber = txBuyerTaxIdentificationNumber.Text;
            _Titular.PartyName = txBuyerPartyName.Text;

            _LoteOperIntracom.Titular = _Titular;
        }

        /// <summary>
        /// Buyer: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewTitular()
        {
            txBuyerTaxIdentificationNumber.Text = _Titular.TaxIdentificationNumber;
            txBuyerPartyName.Text = _Titular.PartyName;
        }

        /// <summary>
        /// Acreedor: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelAcreedor()
        {
            // Si el checkBox está marcado, quiere decir que se trata del emisor de la factura, de manera que procederemos
            // a informar el Buyer con los datos correspondientes.
            if (!cbEsEmisor.Checked)
            {
                _FacturaEnCurso.BuyerParty = _Titular;

                _FacturaEnCurso.SellerParty.TaxIdentificationNumber = txAcreedorTaxIdentificationNumber.Text;
                _FacturaEnCurso.SellerParty.PartyName = txAcreedorPartyName.Text;
            }
            else
            {
                _FacturaEnCurso.SellerParty = _Titular;

                _FacturaEnCurso.BuyerParty.TaxIdentificationNumber = txAcreedorTaxIdentificationNumber.Text;
                _FacturaEnCurso.BuyerParty.PartyName = txAcreedorPartyName.Text;
            }
        }

        /// <summary>
        /// Acreedor: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewAcreedor()
        {
            if (_FacturaEnCurso.BuyerParty.TaxIdentificationNumber == _Titular.TaxIdentificationNumber)
            {
                txAcreedorTaxIdentificationNumber.Text = _FacturaEnCurso.SellerParty.TaxIdentificationNumber;
                txAcreedorPartyName.Text = _FacturaEnCurso.SellerParty.PartyName;
                cbEsEmisor.Checked = false;
            }
            else
            {
                txAcreedorTaxIdentificationNumber.Text = _FacturaEnCurso.BuyerParty.TaxIdentificationNumber;
                txAcreedorPartyName.Text = _FacturaEnCurso.BuyerParty.PartyName;
                cbEsEmisor.Checked = true;
            }
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
                string _msg = "Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txIssueDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txAcreedorTaxIdentificationNumber.Text))
            {
                string _msg = "Debe introducir un NIF de Proveedor/Acreedor";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txAcreedorTaxIdentificationNumber.Focus();
                return;
            }


            if (!string.IsNullOrEmpty(txCountry.Text))
            {
                _FacturaEnCurso.CountryCode = txCountry.Text;
            }

            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(issueDate);

            OperationType operationType;

            if (!Enum.TryParse<OperationType>(txTipoOperacion.Text, out operationType))
            {
                string _msg = ($"El tipo de operación { txTipoOperacion.Text} es deconocido.");
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _FacturaEnCurso.OperationType = operationType;

            ClaveDeclarado claveDeclarado;

            if (!Enum.TryParse<ClaveDeclarado>(txClaveDeclarado.Text, out claveDeclarado))
            {
                string _msg = ($"La clave declarado {txClaveDeclarado.Text} es desconocido");
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _FacturaEnCurso.ClaveDeclarado = claveDeclarado;

            _FacturaEnCurso.EstadoMiembro = txEstadoUE.Text;
            _FacturaEnCurso.DescripcionBienes = txDescripcionBienes.Text;
            _FacturaEnCurso.DireccionOperador = txDirOperador.Text;

            // Acreedor
            BindModelAcreedor();

        }

        /// <summary>
        /// Factura: Actualiza los datos de la vista 
        /// con los datos actuales del modelo.
        /// </summary>
        private void BindViewFactura()
        {

            txInvoiceNumber.Text = _FacturaEnCurso.InvoiceNumber;
            txIssueDate.Text = (_FacturaEnCurso.IssueDate == null) ? "" :
                (_FacturaEnCurso.IssueDate ?? new DateTime(1, 1, 1)).ToString("dd/MM/yyyy");

            txTipoOperacion.Text = _FacturaEnCurso.OperationType.ToString();
            txClaveDeclarado.Text = _FacturaEnCurso.ClaveDeclarado.ToString();
            txEstadoUE.Text = _FacturaEnCurso.EstadoMiembro;
            txDescripcionBienes.Text = _FacturaEnCurso.DescripcionBienes;
            txDirOperador.Text = _FacturaEnCurso.DireccionOperador;

            // Acreedor
            BindViewAcreedor();

        }

        private void BindViewInvoices()
        {

            grdInvoices.Rows.Clear();

            foreach (var invoice in _LoteOperIntracom.ITInvoices)
                //invoice.BuyerParty.TaxIdentificationNumber ya no está informado aquí
                grdInvoices.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate,
                    invoice.SellerParty.TaxIdentificationNumber, invoice.SellerParty.PartyName,
                    invoice.OperationType, invoice.EstadoMiembro, invoice, Sample.Properties.Resources.Ribbon_New_32x32);

            
            if (_SeletedInvoiceIndex != -1 && _SeletedInvoiceIndex < grdInvoices.Rows.Count)
                grdInvoices.Rows[_SeletedInvoiceIndex].Selected = true;


        }


        private void formMain_Load(object sender, EventArgs e)
        {
            _TextBoxes = new List<Control>();
            GetTextBoxes(this, _TextBoxes);

            var cert = Wsd.GetCertificate();

            if (cert == null)
            {
                string _msg = "Debe configurar un certificado digital para utilizar la aplicación.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BindModelTitular();
        }

        private void BindModelAcreedor_Validated(object sender, EventArgs e)
        {
            BindModelAcreedor();
        }

        private void btAddFactura_Click(object sender, EventArgs e)
        {

            BindModelTitular();
            BindModelFactura();

            if(_SeletedInvoiceIndex == -1) // La factura es nueva: la añado
                _LoteOperIntracom.ITInvoices.Add(_FacturaEnCurso);

            ResetFactura();

            BindViewFactura();

            BindViewInvoices();

            cbEsEmisor.Checked = false;
            txAcreedorTaxIdentificationNumber.Focus();

        }

 
        private void mnViewXML_Click(object sender, EventArgs e)
        {

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteOperIntracom.GetXml(tmpath);

                formXmlViewer frmXmlViewer = new formXmlViewer();
                frmXmlViewer.Path = tmpath;

                frmXmlViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviaLoteEnCurso()
        {
            // Realizamos el envío del lote a la AEAT
            Wsd.SendOperIntracom(_LoteOperIntracom);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath +
                _LoteOperIntracom.GetReceivedFileName();

            frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRDetOperacionesIntracomunitarias;

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
                        row.Cells[7].Value = Sample.Properties.Resources.circle_green;
                    else
                        row.Cells[7].Value = Sample.Properties.Resources.circle_red;


            }


            string _msg = ($"Estado del envío realizado a la AEAT: {respuesta.EstadoEnvio}.\nCódigo CVS: {respuesta.CSV}");
            MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
  

            if (envelope.Body.SuministroLRDetOperacionIntracomunitaria == null)
            {
                string _msg = "No es un lote de Operaciones Intracomunitarias.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ResetFactura();
            
            _LoteOperIntracom = new ITInvoicesBatch(envelope.Body.SuministroLRDetOperacionIntracomunitaria);

            _Titular = _LoteOperIntracom.Titular;

            BindViewTitular();
            BindViewFactura();
            BindViewInvoices();

            cbEsEmisor.Checked = false;

        }

        private void grdFacturas_SelectionChanged(object sender, EventArgs e)
        {



        }

        private void grdFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (grdInvoices.SelectedRows.Count > 0)
            { 
                _FacturaEnCurso = (ITInvoice)grdInvoices.SelectedRows[0].Cells[6].Value;
                //_FacturaEnCurso.BuyerParty.TaxIdentificationNumber no contiene ningún valor
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewTitular();
                BindViewAcreedor();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteOperIntracom.ITInvoices.Count - 1)
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

        private void txAcreedorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txAcreedorTaxIdentificationNumber.Text))
            {
                // Bandera que indica si el NIF es o no es español

                bool IsNotNifES = false;

                TaxIdEs taxIdEs = null;


                try
                {
                    taxIdEs =
                                    new TaxIdEs(txAcreedorTaxIdentificationNumber.Text);
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
                        string _msg = "Introducción de NIF cancelada. Para NIF no españoles debe seleccionar un país.";
                        MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txTipoOperacion_Enter(object sender, EventArgs e)
        {
            string TipoOperWrk = General.GetTipoOperIntracom();
            if (string.IsNullOrEmpty(TipoOperWrk))
            {
                string _msg = "Introducción del tipo de operación intracomunitaria cancelada.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txTipoOperacion.Text = "";
            }
            else
            {
                txTipoOperacion.Text = TipoOperWrk;
            }

        }

        private void txClaveDeclarado_Enter(object sender, EventArgs e)
        {
            string ClaveDeclWrk = General.GetClaveDeclarado();
            if (string.IsNullOrEmpty(ClaveDeclWrk))
            {
                string _msg = "Introducción de la Clave Declarado cancelada.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txClaveDeclarado.Text = "";
            }
            else
            {
                txClaveDeclarado.Text = ClaveDeclWrk;
            }

        }

        private void txEstadoUE_Enter(object sender, EventArgs e)
        {
            string EstadoUEWrk = General.GetEstado();
            if (string.IsNullOrEmpty(EstadoUEWrk))
            {
                string _msg = "Introducción del Estado de la U.E. cancelada.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txEstadoUE.Text = "";
            }
            else
            {
                txEstadoUE.Text = EstadoUEWrk;
            }

        }
    }
}
