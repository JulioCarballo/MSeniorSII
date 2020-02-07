using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml.Soap;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MSeniorSII
{
    public partial class formLRRecibidas : Form
    {

        APInvoicesBatch _LoteDeFacturasRecibidas;
        Party _Titular;
        Party _Acreedor;
        Party _Emisor;
        APInvoice _FacturaEnCurso;

        public formLRRecibidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDeFacturasRecibidas = new APInvoicesBatch
            {
                CommunicationType = CommunicationType.A0 // alta facturas:
            };

            _Titular = new Party();          

            _Acreedor = new Party();
            _Emisor = _Acreedor;

            _LoteDeFacturasRecibidas.Titular = _Titular;

            ResetFactura();     

            BindModelTitular();
            BindModelAcreedor();

        }

    

        private void ResetFactura()
        {
            _FacturaEnCurso = new APInvoice
            {
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,

                SellerParty = _Acreedor, // El acreedor
                BuyerParty = _Emisor // El emisor de la factura
            }; // factura

        }

        private void BindModelTitular()
        {
            _Titular.TaxIdentificationNumber = txTitularTaxIdentificationNumber.Text;
            _Titular.PartyName = txTitularPartyName.Text;
        }

        private void BindViewTitular()
        {
            txTitularTaxIdentificationNumber.Text = _Titular.TaxIdentificationNumber;
            txTitularPartyName.Text = _Titular.PartyName;
        }

        private void BindModelAcreedor()
        {
            _Acreedor.TaxIdentificationNumber = txAcreedorTaxIdentificationNumber.Text;
            _Acreedor.PartyName = txAcreedorPartyName.Text;
        }

        private void BindViewAcreedor()
        {
            txAcreedorTaxIdentificationNumber.Text = _Acreedor.TaxIdentificationNumber;
            txAcreedorPartyName.Text = _Acreedor.PartyName;
        }

        private void BindModelFactura()
        {
            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.GrossAmount = Convert.ToDecimal(txGrossAmount.Text);
            _FacturaEnCurso.InvoiceText = txInvoiceText.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(txIssueDate.Text);
            _FacturaEnCurso.PostingDate = Convert.ToDateTime(txIssueDate.Text);

            decimal netAmount = ToAmount(grdIva.Rows[0].Cells[1].Value) +
                ToAmount(grdIva.Rows[1].Cells[1].Value) +
                ToAmount(grdIva.Rows[2].Cells[1].Value);

            decimal taxAmount = ToAmount(grdIva.Rows[0].Cells[2].Value) +
             ToAmount(grdIva.Rows[1].Cells[2].Value) +
             ToAmount(grdIva.Rows[2].Cells[2].Value);

            if (netAmount + taxAmount != _FacturaEnCurso.GrossAmount)
                MessageBox.Show("Descuadre en el IVA.");

            foreach (DataGridViewRow row in grdIva.Rows)
            {
                decimal curTax = ToAmount(row.Cells[2].Value);

                if (curTax != 0)
                {
                    decimal curTaxRate = ToAmount(row.Cells[0].Value);
                    decimal curTaxBase = ToAmount(row.Cells[1].Value);
                    _FacturaEnCurso.AddTaxOtuput(curTaxRate, curTaxBase, curTax);
                }

            }           


        }

        private decimal ToAmount(object nstr)
        {
            decimal r = 0;
            decimal.TryParse((nstr??"0").ToString(), out r);
            return r;
        }
        

      

        private void formMain_Load(object sender, EventArgs e)
        {

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
                txTitularPartyName.Text = tokens[0].Trim();
                txTitularTaxIdentificationNumber.Text = tokens[1].Replace("CIF","").Replace("NIF","").Trim();
            }

            Inizialize();

            grdIva.Rows.Add(4, null, null);
            grdIva.Rows.Add(10, 100, 10);
            grdIva.Rows.Add(21, 100, 21);



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

        private void BindModelTitular_Validated(object sender, EventArgs e)
        {
            BindModelTitular();
        }

        private void BindModelAcreedor_Validated(object sender, EventArgs e)
        {
            BindModelAcreedor();
        }

        private void btAddFactura_Click(object sender, EventArgs e)
        {
            BindModelAcreedor();
            BindModelFactura();

            _LoteDeFacturasRecibidas.APInvoices.Add(_FacturaEnCurso);

            _Acreedor = new Party(); // Reset cliente
            BindModelAcreedor();


            ResetFactura();


            BindViewInvoices();

        }

        private void BindViewInvoices()
        {

            grdFacturas.Rows.Clear();

            foreach (var invoice in _LoteDeFacturasRecibidas.APInvoices)
                grdFacturas.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate, 
                    invoice.SellerParty.TaxIdentificationNumber, invoice.SellerParty.PartyName, 
                    invoice.GrossAmount);
           
        }

        private void mnViewXML_Click(object sender, EventArgs e)
        {
            BindModelTitular();

            string tmpath = Path.GetTempFileName();
            _LoteDeFacturasRecibidas.GetXml(tmpath);

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = tmpath
            };

            frmXmlViewer.ShowDialog();

        }

        private void mnSendXML_Click(object sender, EventArgs e)
        {
            try
            {
                BindModelTitular();
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
            Wsd.SendFacturasRecibidas(_LoteDeFacturasRecibidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _LoteDeFacturasRecibidas.GetReceivedFileName()
            };

            frmXmlViewer.ShowDialog();
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
  

            if (envelope.Body.SuministroLRFacturasRecibidas == null)
            {
                MessageBox.Show("No es un lote de facturas recibidas.");
                return;
            }

            _LoteDeFacturasRecibidas = new APInvoicesBatch(envelope.Body.SuministroLRFacturasRecibidas);

            _Titular = _LoteDeFacturasRecibidas.Titular;
            if (_LoteDeFacturasRecibidas.APInvoices.Count > 0)
                _Emisor =  _Acreedor = _LoteDeFacturasRecibidas.APInvoices[0].SellerParty;

            BindViewTitular();
            BindViewAcreedor();
            BindViewInvoices();

        }
    }
}
