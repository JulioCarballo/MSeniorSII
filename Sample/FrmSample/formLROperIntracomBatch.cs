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
    public partial class formLROperIntracomBatch : Form
    {

        ITInvoicesBatch _LoteOperIntracom;
        Party _Titular;
        Party _Buyer;
        ITInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public formLROperIntracomBatch()
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
            _Buyer = _Titular;

            _LoteOperIntracom.Titular = _Titular;

            ResetFactura();     

            BindModelBuyer();

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new ITInvoice(); // factura

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
            _LoteOperIntracom.Titular = _Titular;
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
                MessageBox.Show("Debe introducir un NIF de Proveedor/Acreedor");
                txAcreedorTaxIdentificationNumber.Focus();
                return;
            }


            if (!string.IsNullOrEmpty(txCountry.Text))
            {
                _FacturaEnCurso.CountryCode = txCountry.Text;
            }

            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(issueDate);

            _FacturaEnCurso.OperationType = txTipoOperacion.Text;
            _FacturaEnCurso.ClaveDeclarado = txClaveDeclarado.Text;
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

            txTipoOperacion.Text = _FacturaEnCurso.OperationType;
            txClaveDeclarado.Text = _FacturaEnCurso.ClaveDeclarado;
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
                _LoteOperIntracom.ITInvoices.Add(_FacturaEnCurso);

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
                _LoteOperIntracom.GetXml(tmpath);

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
  

            if (envelope.Body.SuministroLRDetOperacionIntracomunitaria == null)
            {
                MessageBox.Show("No es un lote de Operaciones Intracomunitarias.");
                return;
            }

            ResetFactura();
            
            _LoteOperIntracom = new ITInvoicesBatch(envelope.Body.SuministroLRDetOperacionIntracomunitaria);

            _Buyer = _Titular = _LoteOperIntracom.Titular;

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
                _FacturaEnCurso = (ITInvoice)grdInvoices.SelectedRows[0].Cells[6].Value;
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewBuyer();
                BindViewAcreedor();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteOperIntracom.ITInvoices.Count - 1)
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

        private void txTipoOperacion_Enter(object sender, EventArgs e)
        {
            string TipoOperWrk = General.GetTipoOperIntracom();
            if (string.IsNullOrEmpty(TipoOperWrk))
            {
                MessageBox.Show("Introducción del tipo de operación intracomunitaria cancelada.");
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
                MessageBox.Show("Introducción de la Clave Declarado cancelada.");
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
                MessageBox.Show("Introducción del Estado de la U.E. cancelada.");
                txEstadoUE.Text = "";
            }
            else
            {
                txEstadoUE.Text = EstadoUEWrk;
            }

        }
    }
}
