﻿using EasySII;
using EasySII.Business;
using EasySII.Business.Batches;
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
    public partial class frmLRRecibidasBatch : Form
    {
        Batch _LoteDeFacturasRecibidas = new Batch(BatchActionKeys.LR, BatchActionPrefixes.SuministroLR, BatchTypes.FacturasRecibidas);

        Party _Titular;
        Party _Buyer;
        APInvoice _FacturaEnCurso;

        int _SeletedInvoiceIndex = -1;

        List<Control> _TextBoxes;

        public frmLRRecibidasBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDeFacturasRecibidas = new Batch(BatchActionKeys.LR, BatchActionPrefixes.SuministroLR, BatchTypes.FacturasRecibidas)
            {
                CommunicationType = CommunicationType.A0 // alta facturas:
            };

            _Titular = new Party();
            _Buyer = _Titular;

            _LoteDeFacturasRecibidas.Titular = _Titular;

            ResetFactura();     

            BindModelBuyer();

            lbNifCert.Text = "";
            lbNroSerie.Text = "";

        }

    
        /// <summary>
        /// Reinicia la factura en curso.
        /// </summary>
        private void ResetFactura()
        {
            _FacturaEnCurso = new APInvoice
            {
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,

                BuyerParty = _Buyer, // El emisor de la factura
                SellerParty = new Party() // El cliente
            }; // factura

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

            //(Marzo-2017 - Julio Carballo)
            // Procedemos a informar el Titular, ya que este, al añadir facturas directamente desde el formulario,
            // no se informaba correctamente en el lote.
            _Titular = _Buyer;
            _LoteDeFacturasRecibidas.Titular = _Titular;
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


            if (!DateTime.TryParse(txIssueDate.Text, out DateTime issueDate))
            {
                string _msg = "Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txIssueDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txAcreedorTaxIdentificationNumber.Text))
            {
                string _msg = "Debe introducir un NIF de cliente";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txAcreedorTaxIdentificationNumber.Focus();
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
            _FacturaEnCurso.PostingDate = Convert.ToDateTime(issueDate);

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

                    _FacturaEnCurso.IsInversionSujetoPasivo = false;
                    _FacturaEnCurso.AddTaxOtuput(curTaxRate, curTaxBase, curTax);
                }

            }

            if (netAmount + taxAmount != _FacturaEnCurso.GrossAmount && _FacturaEnCurso.TaxesOutputs.Count > 0)
            {
                string _msg = "Descuadre en el IVA.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            grdIva.Rows.Clear();

            txInvoiceNumber.Text = _FacturaEnCurso.InvoiceNumber;
            txGrossAmount.Text = _FacturaEnCurso.GrossAmount.ToString("#,##0.00") ;
            txInvoiceText.Text = _FacturaEnCurso.InvoiceText;
            txIssueDate.Text = (_FacturaEnCurso.IssueDate==null) ? "" : 
                (_FacturaEnCurso.IssueDate??new DateTime( 1, 1, 1)).ToString("dd/MM/yyyy");

            foreach (KeyValuePair<decimal, decimal[]> kvp in _FacturaEnCurso.TaxesOutputs)
                grdIva.Rows.Add(kvp.Key, kvp.Value[0], kvp.Value[1]);

            // Acreedor
            BindViewAcreedor();

        }

        private void BindViewInvoices()
        {

            grdInvoices.Rows.Clear();

            // Manera antigua de hacerlo.
            //foreach (var invoice in _LoteDeFacturasRecibidas.APInvoices)
            //    grdInvoices.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate,
            //        invoice.SellerParty.TaxIdentificationNumber, invoice.SellerParty.PartyName,
            //        invoice.GrossAmount, invoice, MSeniorSII.Properties.Resources.Ribbon_New_32x32);

            foreach (IBatchItem item in _LoteDeFacturasRecibidas.BatchItems)
            {
                APInvoice facturaTmp = (APInvoice)item;

                grdInvoices.Rows.Add(facturaTmp.InvoiceNumber, facturaTmp.IssueDate,
                    facturaTmp.BuyerParty.TaxIdentificationNumber, facturaTmp.BuyerParty.PartyName,
                    facturaTmp.GrossAmount, facturaTmp, MSeniorSII.Properties.Resources.Ribbon_New_32x32);
            }

            if (_SeletedInvoiceIndex != -1 && _SeletedInvoiceIndex < grdInvoices.Rows.Count)
                grdInvoices.Rows[_SeletedInvoiceIndex].Selected = true;


        }

        private void BindObtCertificado()
        {
            string _NIFEmpresa = txBuyerTaxIdentificationNumber.Text;
            string _NomEmpresa = "";
            string _NroSerie = "";

            ObtCertificado fncCertificado = new ObtCertificado();
            fncCertificado.BuscaCertificadoDigital(ref _NIFEmpresa, ref _NomEmpresa, ref _NroSerie);

            txBuyerPartyName.Text = _NomEmpresa;
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
            //txBuyerPartyName.Text = _NomEmpresa;
            //txBuyerTaxIdentificationNumber.Text = _NIFEmpresa;

            Inizialize();

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
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

        private void BtAddFactura_Click(object sender, EventArgs e)
        {
            // (Marzo-2017: Julio Carballo)
            // Al añadir la factura, si se generaba el XML (Ver Mensaje XML), no se informaba correctamente el titular del lote, de
            // manera que sustituimos la llamada 'BindViewBuyer' por 'BindModelBuyer'. En este último también hemos realizado un cambio
            // para que se informe el Titular correctamente.
            BindModelBuyer();
            BindModelFactura();

            if(_SeletedInvoiceIndex == -1) // La factura es nueva: la añado
                _LoteDeFacturasRecibidas.BatchItems.Add(_FacturaEnCurso);


            ResetFactura();

            BindViewFactura();


            BindViewInvoices();


            txAcreedorTaxIdentificationNumber.Focus();

        }

 

        private void MnViewXML_Click(object sender, EventArgs e)
        {

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteDeFacturasRecibidas.GetXml(tmpath);

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
            string response = BatchDispatcher.SendSiiLote(_LoteDeFacturasRecibidas);

            string responsePath = Settings.Current.InboxPath + _LoteDeFacturasRecibidas.GetReceivedFileName();
            File.WriteAllText(responsePath, response);

            Envelope envelopeRespuesta = new Envelope(responsePath);

            var respuesta = envelopeRespuesta.Body.GetRespuestaLRF();

            if (respuesta == null && envelopeRespuesta.Body.RespuestaError != null)
            {
                MessageBox.Show(envelopeRespuesta.Body.RespuestaError.FaultDescription, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                dlgOpen.ShowDialog();

                if (string.IsNullOrEmpty(dlgOpen.FileName))
                    return;

                string FullPath = dlgOpen.FileName;

                Envelope envelope = new Envelope(FullPath);


                if (envelope.Body.SuministroLRFacturasRecibidas == null)
                {
                    string _msg = "No es un lote de facturas recibidas.";
                    MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ResetFactura();

                // Aunque el primer método está en deshuso, lo hacemos así momentaneamente para poder cargar
                // el XML seleccionado sin tener ningún tipo de problema.
                APInvoicesBatch cargaXml = new APInvoicesBatch(envelope.Body.SuministroLRFacturasRecibidas);

                _LoteDeFacturasRecibidas = new Batch(BatchActionKeys.LR, BatchActionPrefixes.SuministroLR, BatchTypes.FacturasEmitidas);

                foreach (APInvoice cargaFact in cargaXml.APInvoices)
                {
                    _LoteDeFacturasRecibidas.BatchItems.Add(cargaFact);
                }

                _Buyer = _Titular = _LoteDeFacturasRecibidas.Titular = cargaXml.Titular;

                BindViewBuyer();
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

        private void GrdFacturas_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void GrdFacturas_DoubleClick(object sender, EventArgs e)
        {
            if (grdInvoices.SelectedRows.Count > 0)
            { 
                _FacturaEnCurso = (APInvoice)grdInvoices.SelectedRows[0].Cells[5].Value;
                ChangeCurrentInvoiceIndex(grdInvoices.SelectedRows[0].Index);
                BindViewFactura();
                BindViewBuyer();
                BindViewAcreedor();
            }
        }

        private void ChangeCurrentInvoiceIndex(int index)
        {
            if (index < -1 || index > _LoteDeFacturasRecibidas.BatchItems.Count - 1)
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

        private void TxAcreedorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void TxBuyerTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txBuyerTaxIdentificationNumber.Text))
            {
                BindObtCertificado();
            }
        }
    }
}
