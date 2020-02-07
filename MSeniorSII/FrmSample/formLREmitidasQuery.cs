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
    public partial class formLREmitidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        ARInvoicesDeleteBatch _LoteBajaFactEmitidas;
        ARInvoicesQuery _PetFactEmitEnviadas;
        Party _Titular;
        ARInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public formLREmitidasQuery()
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
        private void BindModelBusqueda()
        {
            _FactParaBuscar = new ARInvoice();

            // Chequear datos
            DateTime issueDate;

            if (!DateTime.TryParse(txFechaBusqueda.Text, out issueDate))
            {
                MessageBox.Show("Debe introducir una fecha correcta");
                txFechaBusqueda.Focus();
                return;
            }

            // Necesitamos indicar una fecha de factura, para que se pueda calcular el ejercicio y periodo
            // que son necesarios y obligatorios para realizar esta peticiones.
            _FactParaBuscar.IssueDate = Convert.ToDateTime(issueDate);

            if (!string.IsNullOrEmpty(txNifBusqueda.Text))
            {
                _FactParaBuscar.SellerParty = new Party() // El cliente
                {
                    TaxIdentificationNumber = txNifBusqueda.Text
                };
            }

            if (!string.IsNullOrEmpty(txFactBusqueda.Text))
                _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;

            _PetFactEmitEnviadas.ARInvoice = _FactParaBuscar;
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


        private void btBuscaFacts_Click(object sender, EventArgs e)
        {

            BindModelTitular();
            BindModelBusqueda();

            // Realizamos la consulta de las facturas en la AEAT
            Wsd.GetFacturasEmitidas(_PetFactEmitEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            FormXmlViewer frmXmlViewer = new FormXmlViewer
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
                    DialogResult resultMsg;
                    string _msg = "Se ha recibido una respuesta inesperada. Pulse 'Aceptar', si quiere revisarla";
                    resultMsg = MessageBox.Show(_msg, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    if (resultMsg == DialogResult.OK)
                        frmXmlViewer.ShowDialog();

                    return;
                }

                // Tenemos que recorrernos la respuesta y rellenar el datagrid con los datos de cada factura.
                grdInvoices.Rows.Clear();

                if (respuesta.ResultadoConsulta == "ConDatos")
                {
                    foreach (var invoice in respuesta.RegistroRCLRFacturasEmitidas)
                    {
                        System.Drawing.Icon _marcaFact = MSeniorSII.Properties.Resources.Tag_Ok;

                        if (invoice.EstadoFactura.EstadoRegistro == "Anulada")
                            _marcaFact = MSeniorSII.Properties.Resources.Tag_Delete;

                        decimal TotalTmp = Convert.ToDecimal(invoice.DatosFacturaEmitida.ImporteTotal, DefaultNumberFormatInfo);

                        grdInvoices.Rows.Add(invoice.IDFactura.NumSerieFacturaEmisor, invoice.IDFactura.FechaExpedicionFacturaEmisor,
                        invoice.DatosFacturaEmitida.Contraparte.NIF, invoice.DatosFacturaEmitida.Contraparte.NombreRazon,
                        TotalTmp.ToString("#,##0.00"), invoice, _marcaFact, invoice.DatosPresentacion.TimestampPresentacion, invoice.EstadoFactura.TimestampUltimaModificacion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txFechaBusqueda.Focus();

        }

        private void mnViewXML_Click(object sender, EventArgs e)
        {

            // Generaremos el lote para poder dar de baja las facturas que se hayan seleccionado en el DataGrid.
            _LoteBajaFactEmitidas = new ARInvoicesDeleteBatch();

            foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            {
                _LoteBajaFactEmitidas.Titular = _Titular;

                ARInvoice _FactEmitidaBaja = new ARInvoice();
                RegistroRCLRFacturasEmitidas _regWrk = new RegistroRCLRFacturasEmitidas();

                _regWrk = (RegistroRCLRFacturasEmitidas)row.Cells[5].Value;

                // Sólo daremos de baja aquellas facturas cuyo estado sean correctas, que tras realizar varias pruebas,
                // las anuladas también las devuelve y al seleccionarlas se puede producir un error.
                if (_regWrk.EstadoFactura.EstadoRegistro == "Correcta")
                {
                    _FactEmitidaBaja.BuyerParty = new Party
                    {
                        TaxIdentificationNumber = _regWrk.IDFactura.IDEmisorFactura.NIF
                    };
                    _FactEmitidaBaja.IssueDate = Convert.ToDateTime(_regWrk.IDFactura.FechaExpedicionFacturaEmisor);
                    _FactEmitidaBaja.InvoiceNumber = _regWrk.IDFactura.NumSerieFacturaEmisor;

                    _LoteBajaFactEmitidas.ARInvoices.Add(_FactEmitidaBaja);
                }
            }

            try
            {
                string tmpath = Path.GetTempFileName();

                // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
                _LoteBajaFactEmitidas.GetXml(tmpath);

                FormXmlViewer frmXmlViewer = new FormXmlViewer
                {
                    Path = tmpath
                };

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
                if (_LoteBajaFactEmitidas.Titular != null)
                {
                    EnviaLoteEnCurso();
                } else
                {
                    MessageBox.Show("Atención!!!. Antes debe proceder a generar el lote con las facturas a eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnviaLoteEnCurso()
        {
            // Realizamos el envío del lote de facturas a borrar a la AEAT
            Wsd.DeleteFacturasEmitidas(_LoteBajaFactEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath + _LoteBajaFactEmitidas.GetReceivedFileName()
            };

            frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de la baja de facturas emitidas del archivo de respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRBajaFacturasEmitidas;

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

                // Si el estado del registro es correcto lo marco como factura eliminada
                foreach (RespuestaLinea respuestaFra in linqQryFra)
                    if (respuestaFra.EstadoRegistro == "Correcto")
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.Tag_Delete;
                    else
                        row.Cells[6].Value = MSeniorSII.Properties.Resources.Tag_Ok;

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

    }
}
