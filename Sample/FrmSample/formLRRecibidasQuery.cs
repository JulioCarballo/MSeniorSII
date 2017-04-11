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

namespace Sample
{
    public partial class formLRRecibidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        APInvoicesDeleteBatch _LoteBajaFactRecibidas;
        APInvoicesQuery _PetFactRecEnviadas;
        Party _Titular;
        APInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public formLRRecibidasQuery()
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

            //BindModelBusqueda();

        }

        /// <summary>
        /// Reinicia los parámetros de búsqueda.
        /// </summary>
        private void ResetFactura()
        {
            _FactParaBuscar = new APInvoice();
            _FactParaBuscar.SellerParty = new Party();
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
        private void BindModelBusqueda()
        {
            _FactParaBuscar = new APInvoice();

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

            // Si informamos el nombre del Acreedor, el resto de campos son obligatorios y se tienen que informar
            if (!string.IsNullOrEmpty(txNomBusqueda.Text))
            {
                _FactParaBuscar.SellerParty = new Party() // El cliente
                {
                    PartyName = txNomBusqueda.Text
                };

                if (string.IsNullOrEmpty(txNifBusqueda.Text))
                {
                    MessageBox.Show("Si informa el nombre de un Acreedor, también tiene que indicar un NIF");
                    txNifBusqueda.Focus();
                    return;
                }
                else
                {
                    _FactParaBuscar.SellerParty.TaxIdentificationNumber = txNifBusqueda.Text;
                }

                if (lbCountry.Text != "")
                    _FactParaBuscar.CountryCode = lbCountry.Text;

                if (string.IsNullOrEmpty(txFactBusqueda.Text))
                {
                    MessageBox.Show("Si informa el nombre de un Acreedor, también tiene que indicar la serie número de una factura");
                    txFactBusqueda.Focus();
                    return;
                }
                else
                {
                    _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;
                }

            }


            _PetFactRecEnviadas.APInvoice = _FactParaBuscar;
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
            Wsd.GetFacturasRecibidas(_PetFactRecEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath +
                _PetFactRecEnviadas.GetReceivedFileName();

            //frmXmlViewer.ShowDialog();

            try
            {
                // Obtengo la respuesta de la consulta de facturas recibidas del archivo de respuesta de la AEAT.
                RespuestaConsultaLRFacturasRecibidas respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaLRFacturasRecibidas;

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
                    foreach (var invoice in respuesta.RegistroRCLRFacturasRecibidas)
                    {
                        System.Drawing.Icon _marcaFact = Sample.Properties.Resources.Tag_Ok;

                        if (invoice.EstadoFactura.EstadoRegistro == "Anulada")
                            _marcaFact = Sample.Properties.Resources.Tag_Delete;

                        decimal TotalTmp = Convert.ToDecimal(invoice.FacturaRecibida.ImporteTotal, DefaultNumberFormatInfo);

                        grdInvoices.Rows.Add(invoice.IDFactura.NumSerieFacturaEmisor, invoice.IDFactura.FechaExpedicionFacturaEmisor,
                        invoice.FacturaRecibida.Contraparte.NIF, invoice.FacturaRecibida.Contraparte.NombreRazon,
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
            _LoteBajaFactRecibidas = new APInvoicesDeleteBatch();

            foreach (DataGridViewRow row in grdInvoices.SelectedRows)
            {
                _LoteBajaFactRecibidas.Titular = _Titular;

                APInvoice _FactRecibidaBaja = new APInvoice();
                RegistroRCLRFacturasRecibidas _regWrk = new RegistroRCLRFacturasRecibidas();

                _regWrk = (RegistroRCLRFacturasRecibidas)row.Cells[5].Value;

                // Sólo daremos de baja aquellas facturas cuyo estado sean correctas, que tras realizar varias pruebas,
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
                if (_LoteBajaFactRecibidas.Titular != null)
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
            Wsd.DeleteFacturasRecibidas(_LoteBajaFactRecibidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath + _LoteBajaFactRecibidas.GetReceivedFileName();

            frmXmlViewer.ShowDialog();

            // Obtengo la respuesta de la baja de facturas emitidas del archivo de respuesta de la AEAT.
            RespuestaLRF respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaLRBajaFacturasRecibidas;

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
                        row.Cells[6].Value = Sample.Properties.Resources.Tag_Delete;
                    else
                        row.Cells[6].Value = Sample.Properties.Resources.Tag_Ok;

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

        private void txNifBusqueda_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
                        MessageBox.Show("Introducción de NIF cancelada. Para NIF no españoles debe seleccionar un país.");
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

    }
}
