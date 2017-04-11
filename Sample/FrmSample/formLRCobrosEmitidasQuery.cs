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
    public partial class formLRCobrosEmitidasQuery : Form
    {

        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();
        internal static string DefaultNumberDecimalSeparator = ".";

        ARPaymentsQuery _PetCobroFactEmitEnviadas;
        Party _Titular;
        ARInvoice _FactParaBuscar;

        List<Control> _TextBoxes;

        public formLRCobrosEmitidasQuery()
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

            _FactParaBuscar.IssueDate = Convert.ToDateTime(issueDate);

            // En este caso, necesitamos indicar el SellerParty para evitar errores. Informaremos el titular.
            _FactParaBuscar.SellerParty = _Titular;

            if (!string.IsNullOrEmpty(txFactBusqueda.Text))
                _FactParaBuscar.InvoiceNumber = txFactBusqueda.Text;

            _PetCobroFactEmitEnviadas.ARInvoice = _FactParaBuscar;
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
                MessageBox.Show(ex.Message);
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

    }
}
