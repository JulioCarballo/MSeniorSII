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
    public partial class frmLRCobrosEmitidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        ARPaymentsQuery _PetCobroFactEmitEnviadas;
        Party _Titular;
        ARInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public frmLRCobrosEmitidasQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _PetCobroFactEmitEnviadas = new ARPaymentsQuery();

            _Titular = new Party();

            _PetCobroFactEmitEnviadas.Titular = _Titular;

            ResetFactura();

            //BindModelBusqueda();

            lbNifCert.Text = "";
            lbNroSerie.Text = "";
        }

    
        /// <summary>
        /// Reinicia los parámetros de búsqueda.
        /// </summary>
        private void ResetFactura()
        {
            _FactParaBuscar = new ARInvoice();
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

            _PetCobroFactEmitEnviadas.Titular = _Titular;

        }

        /// <summary>
        /// Busqueda: Actualiza los datos del modelo 
        /// con los datos actuales de la vista.
        /// </summary>
        private bool BindModelBusqueda()
        {
            _FactParaBuscar = new ARInvoice();

            // Chequear datos
            DateTime issueDate;

            if (!DateTime.TryParse(txFechaBusqueda.Text, out issueDate))
            {
                string _msg = "Debe introducir una fecha correcta";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txFechaBusqueda.Focus();
                return false;
            }

            _FactParaBuscar.IssueDate = Convert.ToDateTime(issueDate);

            // En este caso, necesitamos indicar el SellerParty para evitar errores. Informaremos el titular.
            _FactParaBuscar.SellerParty = _Titular;

            if (!string.IsNullOrEmpty(txFactBusqueda.Text))
                _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;

            _PetCobroFactEmitEnviadas.ARInvoice = _FactParaBuscar;
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


        private void btBuscaFacts_Click(object sender, EventArgs e)
        {

            BindModelTitular();
            bool paramBusquedaOk = BindModelBusqueda();

            if (paramBusquedaOk == true)
                LanzarConsulta();
        }


        private void LanzarConsulta()
        {

            // Realizamos la consulta de las facturas en la AEAT
            Wsd.GetFacturasEmitidasCobros(_PetCobroFactEmitEnviadas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser
            formXmlViewer frmXmlViewer = new formXmlViewer();
            frmXmlViewer.Path = Settings.Current.InboxPath +
                _PetCobroFactEmitEnviadas.GetReceivedFileName();

            //frmXmlViewer.ShowDialog();

            try
            {
                // Obtengo la respuesta de la consulta de facturas recibidas del archivo de respuesta de la AEAT.
                RespuestaConsultaCobros respuesta = new Envelope(frmXmlViewer.Path).Body.RespuestaConsultaCobros;

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
                    foreach (var invoice in respuesta.RegistroRespuestaConsultaCobros)
                    {
                        System.Drawing.Icon _marcaFact = Sample.Properties.Resources.Tag_Ok;

                        decimal TotalTmp = Convert.ToDecimal(invoice.Cobro.Importe, DefaultNumberFormatInfo);

                        grdInvoices.Rows.Add(invoice.Cobro.Fecha, TotalTmp.ToString("#,##0.00"), invoice.Cobro.Medio, invoice.Cobro.Cuenta_O_Medio,
                        invoice, _marcaFact, invoice.DatosPresentacion.TimestampPresentacion);
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

        private void txEmisorTaxIdentificationNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BindObtCertificado();
        }
    }
}
