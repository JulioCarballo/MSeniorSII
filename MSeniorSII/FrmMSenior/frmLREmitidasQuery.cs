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
    public partial class frmLREmitidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        ARInvoicesDeleteBatch _LoteBajaFactEmitidas;
        ARInvoicesQuery _PetFactEmitEnviadas;
        Party _Titular;
        ARInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public frmLREmitidasQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _PetFactEmitEnviadas = new ARInvoicesQuery();
            _LoteBajaFactEmitidas = new ARInvoicesDeleteBatch();

            _Titular = new Party();

            _PetFactEmitEnviadas.Titular = _Titular;

            ResetFactura();

            lbNifCert.Text = "";
            lbNroSerie.Text = "";

            //BindModelBusqueda();

        }

    
        /// <summary>
        /// Reinicia los parámetros de búsqueda.
        /// </summary>
        private void ResetFactura()
        {
            _FactParaBuscar = new ARInvoice
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

            _PetFactEmitEnviadas.Titular = _Titular;

        }

        /// <summary>
        /// Busqueda: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private bool BindModelBusqueda()
        {
            _FactParaBuscar = new ARInvoice();

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

            if (!string.IsNullOrEmpty(txNifBusqueda.Text))
            {
                _FactParaBuscar.BuyerParty = new Party() // El cliente
                {
                    TaxIdentificationNumber = txNifBusqueda.Text,
                    PartyName = txNomCliente.Text
                };
            }

            if (!string.IsNullOrEmpty(txFactBusqueda.Text))
                _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;

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


            _PetFactEmitEnviadas.ARInvoice = _FactParaBuscar;
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
            Wsd.GetFacturasEmitidas(_PetFactEmitEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            formXmlViewer frmXmlViewer = new formXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _PetFactEmitEnviadas.GetReceivedFileName()
            };

            //frmXmlViewer.ShowDialog();

            try
            {
                // Obtengo la respuesta de la consulta de facturas recibidas del archivo de respuesta de la AEAT.
                RespuestaConsultaLRFacturasEmitidas respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaLRFacturasEmitidas;

                if (respuesta == null)
                {
                    SoapFault msgError = new Envelope(frmXmlViewer.Path).Body.RespuestaError;
                    if (msgError != null)
                    {
                        MessageBox.Show(msgError.FaultDescription, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                grdInvoices.Rows.Clear();

                if (respuesta.ResultadoConsulta == "SinDatos")
                {
                    MessageBox.Show("No se han encontrado registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tenemos que recorrernos la respuesta y rellenar el datagrid con los datos de cada factura.
                if (respuesta.ResultadoConsulta == "ConDatos")
                {
                    foreach (var invoice in respuesta.RegistroRCLRFacturasEmitidas)
                    {
                        System.Drawing.Icon _marcaFact = MSeniorSII.Properties.Resources.Tag_Ok;

                        if (invoice.EstadoFactura.EstadoRegistro == "Anulada")
                            _marcaFact = MSeniorSII.Properties.Resources.Tag_Delete;

                        decimal TotalTmp = Convert.ToDecimal(invoice.DatosFacturaEmitida.ImporteTotal, DefaultNumberFormatInfo);

                        string NifTmp = "";
                        string NombreRazonTmp = "";

                        if (invoice.DatosFacturaEmitida.Contraparte != null) {
                            NifTmp = invoice.DatosFacturaEmitida.Contraparte.NIF;
                            NombreRazonTmp = invoice.DatosFacturaEmitida.Contraparte.NombreRazon;
                        }

                        grdInvoices.Rows.Add(invoice.IDFactura.NumSerieFacturaEmisor, invoice.IDFactura.FechaExpedicionFacturaEmisor,
                        NifTmp, NombreRazonTmp,
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
            _LoteBajaFactEmitidas = new ARInvoicesDeleteBatch();

            foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            {
                _LoteBajaFactEmitidas.Titular = _Titular;

                ARInvoice _FactEmitidaBaja = new ARInvoice();
                RegistroRCLRFacturasEmitidas _RegWrk = new RegistroRCLRFacturasEmitidas();

                _RegWrk = (RegistroRCLRFacturasEmitidas)row.Cells[5].Value;

                // Sólo daremos de baja aquellas facturas cuyo estado sean correctas, que tras realizar varias pruebas,
                // las anuladas también las devuelve y al seleccionarlas se puede producir un error.
                if (_RegWrk.EstadoFactura.EstadoRegistro == "Correcta")
                {
                    _FactEmitidaBaja.SellerParty = new Party
                    {
                        TaxIdentificationNumber = _RegWrk.IDFactura.IDEmisorFactura.NIF
                    };
                    _FactEmitidaBaja.IssueDate = Convert.ToDateTime(_RegWrk.IDFactura.FechaExpedicionFacturaEmisor);
                    _FactEmitidaBaja.InvoiceNumber = _RegWrk.IDFactura.NumSerieFacturaEmisor;

                    _LoteBajaFactEmitidas.ARInvoices.Add(_FactEmitidaBaja);
                }
            }

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteBajaFactEmitidas.GetXml(tmpath);

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

        private void MnSendXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LoteBajaFactEmitidas.Titular != null)
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
            Wsd.DeleteFacturasEmitidas(_LoteBajaFactEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer
            {
                Path = Settings.Current.InboxPath + _LoteBajaFactEmitidas.GetReceivedFileName()
            };

            frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de la baja de facturas emitidas del archivo de respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRBajaFacturasEmitidas;

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

        private void TxEmisorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txEmisorTaxIdentificationNumber.Text))
            {
                BindObtCertificado();
            }
        }
    }
}
