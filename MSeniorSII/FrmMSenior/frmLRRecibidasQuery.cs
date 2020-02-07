using EasySII;
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

namespace MSeniorSII
{
    public partial class frmLRRecibidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        APInvoicesDeleteBatch _LoteBajaFactRecibidas;
        APInvoicesQuery _PetFactRecEnviadas;
        Party _Titular;
        APInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public frmLRRecibidasQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _PetFactRecEnviadas = new APInvoicesQuery();
            _LoteBajaFactRecibidas = new APInvoicesDeleteBatch();

            _Titular = new Party();

            _PetFactRecEnviadas.Titular = _Titular;

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
            _FactParaBuscar = new APInvoice
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

            _PetFactRecEnviadas.Titular = _Titular;

        }

        /// <summary>
        /// Busqueda: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private bool BindModelBusqueda()
        {
            _FactParaBuscar = new APInvoice();

            // Revisamos que el formato de la fecha sea correcto.
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
                _FactParaBuscar.IsFiltroClavePag = false;
                if (cbPaginacion.Checked)
                    _FactParaBuscar.IsFiltroClavePag = true;

                _FactParaBuscar.SellerParty = new Party() // El cliente
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
                    _FactParaBuscar.SellerParty.TaxIdentificationNumber = txNifBusqueda.Text;
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


            bool desdeFechaOk = DateTime.TryParse(txDesdeFecha.Text, out DateTime desdeFecha);
            bool hastaFechaOk = DateTime.TryParse(txHastaFecha.Text, out DateTime hastaFecha);

            if (!string.IsNullOrEmpty(txDesdeFecha.Text) && !desdeFechaOk)
            {
                string _msg = "(Desde Fecha) - Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txDesdeFecha.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txHastaFecha.Text) && !hastaFechaOk)
            {
                string _msg = "(Hasta Fecha) - Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txHastaFecha.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txDesdeFecha.Text) && !string.IsNullOrEmpty(txHastaFecha.Text))
            {
                _FactParaBuscar.SinceDate = Convert.ToDateTime(desdeFecha);
                _FactParaBuscar.UntilDate = Convert.ToDateTime(hastaFecha);
            }

            _PetFactRecEnviadas.APInvoice = _FactParaBuscar;
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
            Wsd.GetFacturasRecibidas(_PetFactRecEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _PetFactRecEnviadas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            try
            {
                // Obtengo la respuesta de la consulta de facturas recibidas del archivo de respuesta de la AEAT.
                RespuestaConsultaLRFacturasRecibidas respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaLRFacturasRecibidas;

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

                if (respuesta.ResultadoConsulta == "SinDatos")
                {
                    MessageBox.Show("No se han encontrado registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (respuesta.ResultadoConsulta == "ConDatos")
                {
                    foreach (var invoice in respuesta.RegistroRCLRFacturasRecibidas)
                    {
                        System.Drawing.Icon _marcaFact = MSeniorSII.Properties.Resources.Tag_Ok;

                        if (invoice.EstadoFactura.EstadoRegistro == "Anulada")
                            _marcaFact = MSeniorSII.Properties.Resources.Tag_Delete;

                        decimal TotalTmp = Convert.ToDecimal(invoice.FacturaRecibida.ImporteTotal, DefaultNumberFormatInfo);

                        grdInvoices.Rows.Add(invoice.IDFactura.NumSerieFacturaEmisor, invoice.IDFactura.FechaExpedicionFacturaEmisor,
                        invoice.FacturaRecibida.Contraparte.NIF, invoice.FacturaRecibida.Contraparte.NombreRazon,
                        TotalTmp.ToString("#,##0.00"), invoice, _marcaFact, invoice.DatosPresentacion.TimestampPresentacion, invoice.EstadoFactura.TimestampUltimaModificacion);
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
            _LoteBajaFactRecibidas = new APInvoicesDeleteBatch();

            foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            {
                _LoteBajaFactRecibidas.Titular = _Titular;

                APInvoice _FactRecibidaBaja = new APInvoice();
                RegistroRCLRFacturasRecibidas _regWrk = new RegistroRCLRFacturasRecibidas();

                _regWrk = (RegistroRCLRFacturasRecibidas)row.Cells[5].Value;

                // Sólo daremos de baja aquellas facturas cuyo estado sean correctas, ya que tras realizar varias pruebas,
                // las anuladas también las devuelve y al seleccionarlas se puede producir un error.
                if (_regWrk.EstadoFactura.EstadoRegistro == "Correcta")
                {
                    _FactRecibidaBaja.SellerParty = new Party
                    {
                        PartyName = _regWrk.FacturaRecibida.Contraparte.NombreRazon,
                        TaxIdentificationNumber = _regWrk.FacturaRecibida.Contraparte.NIF
                    };

                    if (_regWrk.FacturaRecibida.Contraparte.IDOtro != null)
                        _FactRecibidaBaja.CountryCode = _regWrk.FacturaRecibida.Contraparte.IDOtro.CodigoPais;

                    _FactRecibidaBaja.IssueDate = Convert.ToDateTime(_regWrk.IDFactura.FechaExpedicionFacturaEmisor);
                    _FactRecibidaBaja.InvoiceNumber = _regWrk.IDFactura.NumSerieFacturaEmisor;

                    _LoteBajaFactRecibidas.APInvoices.Add(_FactRecibidaBaja);
                }
            }

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteBajaFactRecibidas.GetXml(tmpath);

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
                if (_LoteBajaFactRecibidas.Titular != null)
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
            Wsd.DeleteFacturasRecibidas(_LoteBajaFactRecibidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath + _LoteBajaFactRecibidas.GetReceivedFileName()
            };

            frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de la baja de facturas emitidas del archivo de respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRBajaFacturasRecibidas;

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
            }
            else
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
            // Si el campo correspondiente está informado, se obtendrá el certificado.
            if (!string.IsNullOrEmpty(this.txEmisorTaxIdentificationNumber.Text))
            {
                BindObtCertificado();
            }
        }
    }
}
