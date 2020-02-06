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
    public partial class frmLREmitidasBatch : Form
    {

        ARInvoicesBatchAV _LoteDeFacturasEmitidas;
        Party _Titular;
        Party _Emisor;
        ARInvoiceAV _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public frmLREmitidasBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDeFacturasEmitidas = new ARInvoicesBatchAV
            {
                CommunicationType = CommunicationType.A0 // alta facturas:
            };

            _Titular = new Party();
            _Emisor = _Titular;

            _LoteDeFacturasEmitidas.Titular = _Titular;

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
            _FacturaEnCurso = new ARInvoiceAV
            {
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,

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

            //(Marzo-2017 - Julio Carballo)
            // Procedemos a informar el Titular, ya que este, al añadir facturas directamente desde el formulario,
            // no se informaba correctamente en el lote.
            _Titular = _Emisor;
            _LoteDeFacturasEmitidas.Titular = _Titular;
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


            if (!string.IsNullOrEmpty(txCountry.Text))
            {
                _FacturaEnCurso.CountryCode = txCountry.Text;
            }

            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.GrossAmount = Convert.ToDecimal(txGrossAmount.Text);
            _FacturaEnCurso.InvoiceText = txInvoiceText.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(issueDate);

            decimal netAmount = 0;
            decimal taxAmount = 0;

            _FacturaEnCurso.TaxesOutputs.Clear();

            foreach (DataGridViewRow row in grdIva.Rows)
            {
                decimal curTax = ToAmount(row.Cells[2].Value);

                if (curTax != 0)
                {
                    decimal curTaxRate = ToAmount(row.Cells[0].Value);
                    decimal curTaxBase = ToAmount(row.Cells[1].Value);

                    netAmount += curTaxBase;
                    taxAmount += curTax;

                    _FacturaEnCurso.AddTaxOtuput(curTaxRate, curTaxBase, curTax);
                }

            }

            if (netAmount + taxAmount != _FacturaEnCurso.GrossAmount && _FacturaEnCurso.TaxesOutputs.Count > 0)
            {
                string _msg = "Descuadre en el IVA.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            grdIva.Rows.Clear();

            txInvoiceNumber.Text = _FacturaEnCurso.InvoiceNumber;
            txGrossAmount.Text = _FacturaEnCurso.GrossAmount.ToString("#,##0.00") ;
            txInvoiceText.Text = _FacturaEnCurso.InvoiceText;
            txIssueDate.Text = (_FacturaEnCurso.IssueDate==null) ? "" : 
                (_FacturaEnCurso.IssueDate??new DateTime( 1, 1, 1)).ToString("dd/MM/yyyy");

            foreach (KeyValuePair<decimal, decimal[]> kvp in _FacturaEnCurso.TaxesOutputs)
                grdIva.Rows.Add(kvp.Key, kvp.Value[0], kvp.Value[1]);

            // Cliente
            BindViewCliente();

        }

        private void BindViewInvoices()
        {

            grdInvoices.Rows.Clear();

            foreach (var invoice in _LoteDeFacturasEmitidas.ARInvoicesAV)
                grdInvoices.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate,
                    invoice.BuyerParty.TaxIdentificationNumber, invoice.BuyerParty.PartyName,
                    invoice.GrossAmount, invoice, MSeniorSII.Properties.Resources.Ribbon_New_32x32);

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

            //ObtCertificado fncCertificado = new ObtCertificado();
            //string _NIFEmpresa = "";
            //string _NomEmpresa = "";
            //fncCertificado.ObtCertificadoDigital(ref _NIFEmpresa, ref _NomEmpresa);
            //txEmisorPartyName.Text = _NomEmpresa;
            //txEmisorTaxIdentificationNumber.Text = _NIFEmpresa;

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
            // (Marzo-2017: Julio Carballo)
            // Al añadir la factura, si se generaba el XML (Ver Mensaje XML), no se informaba correctamente el titular del lote, de
            // manera que sustituimos la llamada 'BindViewEmisor' por 'BindModelEmisor'. En este último también hemos realizado un cambio
            // para que se informe el Titular correctamente.
            BindModelEmisor();
            BindModelFactura();

            if(_SeletedInvoiceIndex == -1) // La factura es nueva: la añado
                _LoteDeFacturasEmitidas.ARInvoicesAV.Add(_FacturaEnCurso);


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
                _LoteDeFacturasEmitidas.GetXml(tmpath);

                formXmlViewer frmXmlViewer = new formXmlViewer
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
            Wsd.SendFacturasEmitidasAV(_LoteDeFacturasEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _LoteDeFacturasEmitidas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de facturas recibidas del archivo de
            // respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRFacturasEmitidas;

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
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.circle_green;
                    else
                    {
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.circle_red;
                        row.Cells[7].Value = respuestaFra.DescripcionErrorRegistro;
                    }


            }

            if (respuesta.EstadoEnvio == "Correcto")
            {
                string _msg = ($"Estado del envío realizado a la AEAT: {respuesta.EstadoEnvio}.\nCódigo CSV: {respuesta.CSV}");
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

            try
            {
                dlgOpen.ShowDialog();

                if (string.IsNullOrEmpty(dlgOpen.FileName))
                    return;

                string FullPath = dlgOpen.FileName;

                Envelope envelope = new Envelope(FullPath);


                if (envelope.Body.SuministroLRFacturasEmitidas == null)
                {
                    string _msg = "No es un lote de facturas emitidas.";
                    MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _LoteDeFacturasEmitidas = new ARInvoicesBatchAV(envelope.Body.SuministroLRFacturasEmitidas);
                //string _msg2 = _LoteDeFacturasEmitidas.ARInvoices[0].InvoiceNumber + " # " + _LoteDeFacturasEmitidas.ARInvoices[0].Sujeta + " # " + 
                //    _LoteDeFacturasEmitidas.ARInvoices[0].GrossAmount + " # " + _LoteDeFacturasEmitidas.ARInvoices[0].CausaExencion;
                //MessageBox.Show(_msg2, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Emisor = _Titular = _LoteDeFacturasEmitidas.Titular;

                BindViewEmisor();
                BindViewFactura();
                BindViewInvoices();

                BindObtCertificado();
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFacturas_SelectionChanged(object sender, EventArgs e)
        {



        }

        private void grdFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (grdInvoices.SelectedRows.Count > 0)
            { 
                _FacturaEnCurso = (ARInvoiceAV)grdInvoices.SelectedRows[0].Cells[5].Value;
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewEmisor();
                BindViewCliente();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteDeFacturasEmitidas.ARInvoicesAV.Count - 1)
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

        private void txClienteTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txClienteTaxIdentificationNumber.Text))
            {
                // Bandera que indica si el NIF es o no es español

                bool IsNotNifES = false;

                TaxIdEs taxIdEs = null;


                try
                {
                    taxIdEs =
                                    new TaxIdEs(txClienteTaxIdentificationNumber.Text);
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

                        txClienteTaxIdentificationNumber.Text = "";
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

        private void txEmisorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BindObtCertificado();
        }
    }
}
