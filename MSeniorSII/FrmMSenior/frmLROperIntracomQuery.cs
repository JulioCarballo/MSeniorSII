﻿using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Tax;
using EasySII.Xml.SiiR;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace MSeniorSII
{
    public partial class frmLROperIntracomQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        ITInvoicesDeleteBatch _LoteBajaOperIntracom;
        ITInvoicesQuery _PetOperIntraEnviadas;
        Party _Titular;
        ITInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public frmLROperIntracomQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _PetOperIntraEnviadas = new ITInvoicesQuery();
            _LoteBajaOperIntracom = new ITInvoicesDeleteBatch();

            _Titular = new Party();

            _PetOperIntraEnviadas.Titular = _Titular;

            ResetFactura();

            // Inicializamos el campo para el país, en el caso de que sea un NIF extranjero.
            lbCountry.Text = "";

            lbNifCert.Text = "";
            lbNroSerie.Text = "";

            //BindModelBusqueda();

        }

        /// <summary>
        /// Reinicia los parámetros de búsqueda.
        /// </summary>
        private void ResetFactura()
        {
            _FactParaBuscar = new ITInvoice
            {
                SellerParty = new Party()
            };
        }

        /// <summary>
        /// Emisor: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private void BindModelTitular()
        {
            _Titular.TaxIdentificationNumber = txEmisorTaxIdentificationNumber.Text;
            _Titular.PartyName = txEmisorPartyName.Text;

            _PetOperIntraEnviadas.Titular = _Titular;

        }

        /// <summary>
        /// Busqueda: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private bool BindModelBusqueda()
        {
            _FactParaBuscar = new ITInvoice();

            // Chequear datos

            if (!DateTime.TryParse(txFechaBusqueda.Text, out DateTime issueDate))
            {
                string _msg = "Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txFechaBusqueda.Focus();
                return false;
            }

            // Necesitamos indicar una fecha de factura, para que se pueda calcular el ejercicio y periodo
            // que son necesarios y obligatorios para realizar esta peticiones.
            _FactParaBuscar.IssueDate = Convert.ToDateTime(issueDate);

            // Si informamos el nombre del Acreedor, el resto de campos son obligatorios y se tienen que informar
            if (!string.IsNullOrEmpty(txNomBusqueda.Text))
            {
                _FactParaBuscar.BuyerParty = new Party() // El cliente
                {
                    PartyName = txNomBusqueda.Text
                };

                if (string.IsNullOrEmpty(txNifBusqueda.Text))
                {
                    string _msg = "Si informa el nombre de un Acreedor, también tiene que indicar un NIF";
                    MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txNifBusqueda.Focus();
                    return false;
                }
                else
                {
                    _FactParaBuscar.BuyerParty.TaxIdentificationNumber = txNifBusqueda.Text;
                }

                if (lbCountry.Text != "")
                    _FactParaBuscar.CountryCode = lbCountry.Text;

                if (string.IsNullOrEmpty(txFactBusqueda.Text))
                {
                    string _msg = "Si informa el nombre de un Acreedor, también tiene que indicar la serie número de una factura";
                    MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txFactBusqueda.Focus();
                    return false;
                }
                else
                {
                    _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;
                }

            }

            _PetOperIntraEnviadas.ITInvoice = _FactParaBuscar;
            return true;
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


        private void BtBuscaFacts_Click(object sender, EventArgs e)
        {

            BindModelTitular();
            bool paramBusquedaOk = BindModelBusqueda();

            if (paramBusquedaOk == true)
                LanzarConsulta();
        }


        private void LanzarConsulta()
        {

            // Realizamos la consulta de las facturas en la AEAT
            Wsd.GetOperIntracom(_PetOperIntraEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _PetOperIntraEnviadas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            try
            {
                // Obtengo la respuesta de la consulta de facturas recibidas del archivo de respuesta de la AEAT.
                RespuestaConsultaLRDetOperIntracomunitarias respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaLRDetOperIntracomunitarias;

                if (respuesta == null)
                {
                    SoapFault msgError = new Envelope(frmXmlViewer.Path).Body.RespuestaError;
                    if (msgError != null)
                    {
                        MessageBox.Show(msgError.FaultDescription, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Tenemos que recorrernos la respuesta y rellenar el datagrid con los datos de cada factura.
                grdInvoices.Rows.Clear();

                if (respuesta.ResultadoConsulta == "ConDatos")
                {
                    foreach (var invoice in respuesta.RegistroRCLRDetOperIntracom)
                    {
                        System.Drawing.Icon _marcaFact = MSeniorSII.Properties.Resources.Tag_Ok;

                        if (invoice.EstadoFactura.EstadoRegistro == "Anulada")
                            _marcaFact = MSeniorSII.Properties.Resources.Tag_Delete;

                        grdInvoices.Rows.Add(invoice.IDFactura.NumSerieFacturaEmisor, invoice.IDFactura.FechaExpedicionFacturaEmisor,
                            invoice.OperacionIntracomunitaria.OperacionIntracom.TipoOperacion, invoice.OperacionIntracomunitaria.OperacionIntracom.ClaveDeclarado,
                            invoice.OperacionIntracomunitaria.OperacionIntracom.DescripcionBienes, invoice, _marcaFact, invoice.DatosPresentacion.TimestampPresentacion,
                            invoice.EstadoFactura.TimestampUltimaModificacion);
                    }
                }
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txFechaBusqueda.Focus();

        }

        private void MnViewXML_Click(object sender, EventArgs e)
        {

            // Generaremos el lote para poder dar de baja las facturas que se hayan seleccionado en el DataGrid.
            _LoteBajaOperIntracom = new ITInvoicesDeleteBatch();

            foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            {
                _LoteBajaOperIntracom.Titular = _Titular;

                ITInvoice _OperIntracomBaja = new ITInvoice();
                RegistroRCLRDetOperIntracom _RegWrk = new RegistroRCLRDetOperIntracom();

                _RegWrk = (RegistroRCLRDetOperIntracom)row.Cells[5].Value;

                // Sólo daremos de baja aquellas facturas cuyo estado sean correctas, que tras realizar varias pruebas,
                // las anuladas también las devuelve y al seleccionarlas se puede producir un error.
                if (_RegWrk.EstadoFactura.EstadoRegistro == "Correcta")
                {
                    _OperIntracomBaja.BuyerParty = new Party
                    {
                        PartyName = _RegWrk.IDFactura.IDEmisorFactura.NombreRazon,
                        TaxIdentificationNumber = _RegWrk.IDFactura.IDEmisorFactura.NIF
                    };

                    if (_RegWrk.IDFactura.IDEmisorFactura.IDOtro  != null)
                    {
                        _OperIntracomBaja.CountryCode = _RegWrk.IDFactura.IDEmisorFactura.IDOtro.CodigoPais;
                        _OperIntracomBaja.BuyerParty.TaxIdentificationNumber = _RegWrk.IDFactura.IDEmisorFactura.IDOtro.ID;
                    }

                    _OperIntracomBaja.IssueDate = Convert.ToDateTime(_RegWrk.IDFactura.FechaExpedicionFacturaEmisor);
                    _OperIntracomBaja.InvoiceNumber = _RegWrk.IDFactura.NumSerieFacturaEmisor;

                    _LoteBajaOperIntracom.ITInvoices.Add(_OperIntracomBaja);
                }
            }

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteBajaOperIntracom.GetXml(tmpath);

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
                if (_LoteBajaOperIntracom.Titular != null)
                {
                    EnviaLoteEnCurso();
                } else
                {
                    string _msg = "Antes debe proceder a generar el lote con las facturas a eliminar";
                    MessageBox.Show(_msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviaLoteEnCurso()
        {
            // Realizamos el envío del lote de facturas a borrar a la AEAT
            Wsd.DeleteOperIntracom(_LoteBajaOperIntracom);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath + _LoteBajaOperIntracom.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de la baja de facturas emitidas del archivo de respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRBajaDetOperacionesIntracomunitarias;

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

                // Si el estado del registro es correcto lo marco como factura eliminada
                foreach (RespuestaLinea respuestaFra in linqQryFra)
                    if (respuestaFra.EstadoRegistro == "Correcto")
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.Tag_Delete;
                    else
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.Tag_Ok;

            }

            string _msg = "";
            if (respuesta.EstadoEnvio == "Incorrecto")
            {
                _msg = "Envío Rechazado. Para saber el motivo revise el fichero: " + frmXmlViewer.Path;
            } else
            {
                _msg = ($"Estado del envío realizado a la AEAT: {respuesta.EstadoEnvio}.\nCódigo CVS: {respuesta.CSV}");
            }
            MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void GrpEmisor_Enter(object sender, EventArgs e)
        {

        }

        private void MnSettings_Click(object sender, EventArgs e)
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

        private void TxNifBusqueda_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txNifBusqueda.Text))
            {
                bool IsNotNifES = false;
                TaxIdEs taxIdEs = null;

                try
                {
                    taxIdEs = new TaxIdEs(txNifBusqueda.Text);
                }
                catch
                {
                    IsNotNifES = true;
                }

                if (taxIdEs != null)
                    IsNotNifES = !taxIdEs.IsDCOK;

                if (IsNotNifES)
                {
                    string country = General.GetCountry();
                    if (string.IsNullOrEmpty(country))
                    {
                        string _msg = "Introducción de NIF cancelada. Para NIF no españoles debe seleccionar un país.";
                        MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txNifBusqueda.Text = "";
                    }
                    else
                    {
                        lbCountry.Text = country;
                    }
                }
                else
                {
                    lbCountry.Text = "";
                }
            }
        }

        private void TxEmisorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txEmisorTaxIdentificationNumber.Text))
            {
                BindObtCertificado();
            }
        }
    }
}
