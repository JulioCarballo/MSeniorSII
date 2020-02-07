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
    public partial class formLREmitidas : Form
    {

        ARInvoicesBatch _LoteDeFacturasEmitidas;
        Party _Titular;
        Party _Cliente;
        Party _Emisor;
        ARInvoice _FacturaEnCurso;

        public formLREmitidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia entorno.
        /// </summary>
        private void Inizialize()
        {
            _LoteDeFacturasEmitidas = new ARInvoicesBatch
            {
                CommunicationType = CommunicationType.A0 // alta facturas:
            };

            _Titular = new Party();
            _Emisor = _Titular;

            _Cliente = new Party();

            _LoteDeFacturasEmitidas.Titular = _Titular;

            ResetFactura();

     

            BindModelEmisor();
            BindModelCliente();

        }

    

        private void ResetFactura()
        {
            _FacturaEnCurso = new ARInvoice
            {
                InvoiceType = InvoiceType.F1, // Factura normal
                ClaveRegimenEspecialOTrascendencia =
                ClaveRegimenEspecialOTrascendencia.RegimenComun,

                SellerParty = _Emisor, // El emisor de la factura
                BuyerParty = _Cliente // El cliente
            }; // factura

        }

        private void BindModelEmisor()
        {
            _Emisor.TaxIdentificationNumber = txEmisorTaxIdentificationNumber.Text;
            _Emisor.PartyName = txEmisorPartyName.Text;
        }

        private void BindViewEmisor()
        {
            txEmisorTaxIdentificationNumber.Text = _Emisor.TaxIdentificationNumber;
            txEmisorPartyName.Text = _Emisor.PartyName;
        }

        private void BindModelCliente()
        {
            _Cliente.TaxIdentificationNumber = txClienteTaxIdentificationNumber.Text;
            _Cliente.PartyName = txClientePartyName.Text;
        }

        private void BindViewCliente()
        {
            txClienteTaxIdentificationNumber.Text = _Cliente.TaxIdentificationNumber;
            txClientePartyName.Text = _Cliente.PartyName;
        }

        private void BindModelFactura()
        {
            _FacturaEnCurso.InvoiceNumber = txInvoiceNumber.Text;
            _FacturaEnCurso.GrossAmount = Convert.ToDecimal(txGrossAmount.Text);
            _FacturaEnCurso.InvoiceText = txInvoiceText.Text;
            _FacturaEnCurso.IssueDate = Convert.ToDateTime(txIssueDate.Text);

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
                txEmisorPartyName.Text = tokens[0].Trim();
                txEmisorTaxIdentificationNumber.Text = tokens[1].Replace("CIF","").Replace("NIF","").Trim();
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
            BindModelCliente();
            BindViewEmisor();
            BindModelFactura();
            BindViewCliente();

            _LoteDeFacturasEmitidas.ARInvoices.Add(_FacturaEnCurso);

            _Cliente = new Party(); // Reset cliente
            BindModelCliente();


            ResetFactura();


            BindViewInvoices();

        }

        private void BindViewInvoices()
        {

            grdFacturas.Rows.Clear();

            foreach (var invoice in _LoteDeFacturasEmitidas.ARInvoices)
                grdFacturas.Rows.Add(invoice.InvoiceNumber, invoice.IssueDate, 
                    invoice.BuyerParty.TaxIdentificationNumber, invoice.BuyerParty.PartyName, 
                    invoice.GrossAmount);
           
        }

        private void mnViewXML_Click(object sender, EventArgs e)
        {
            string tmpath = Path.GetTempFileName();

            // Genera el archivo xml y lo guarda en la ruta facilitada comno parámetro
            _LoteDeFacturasEmitidas.GetXml(tmpath);

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
            Wsd.SendFacturasEmitidas(_LoteDeFacturasEmitidas);

            // Muestro el xml de respuesta recibido de la AEAT en el web browser

            FormXmlViewer frmXmlViewer = new FormXmlViewer
            {
                Path = Settings.Current.InboxPath +
                _LoteDeFacturasEmitidas.GetReceivedFileName()
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
  

            if (envelope.Body.SuministroLRFacturasEmitidas == null)
            {
                MessageBox.Show("No es un lote de facturas emitidas.");
                return;
            }
            
            _LoteDeFacturasEmitidas = new ARInvoicesBatch(envelope.Body.SuministroLRFacturasEmitidas);

            _Emisor = _Titular = _LoteDeFacturasEmitidas.Titular;
            if (_LoteDeFacturasEmitidas.ARInvoices.Count > 0)
                _Cliente = _LoteDeFacturasEmitidas.ARInvoices[0].BuyerParty;

            BindViewEmisor();
            BindViewCliente();
            BindViewInvoices();

        }
    }
}
