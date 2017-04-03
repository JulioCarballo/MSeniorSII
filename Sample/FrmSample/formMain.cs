using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class btARInvoiceBatch : Form
    {
        public btARInvoiceBatch()
        {
            InitializeComponent();
        }

        private void Settings()
        {
            // Abrimos el formulario de configuración
            formSettings frmSettings = new formSettings();
            frmSettings.MdiParent = this;
            frmSettings.Show();
        }

 

        private void CrearLoteEmitidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas emitidas a enviar al SII de la AEAT.
            formLREmitidasBatch frmLREmitidas =
                new formLREmitidasBatch();
            frmLREmitidas.MdiParent = this;
            frmLREmitidas.Show();
        }

        private void CrearLoteRecibidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas recibidas a enviar al SII de la AEAT.
            formLRRecibidasBatch frmLRRecibidas =
                new formLRRecibidasBatch();
            frmLRRecibidas.MdiParent = this;
            frmLRRecibidas.Show();
        }

        private void CrearLoteOperIntracom()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de operaciones intracomunitarias a enviar al SII de la AEAT.
            formLROperIntracomBatch frmLROperIntracom = new formLROperIntracomBatch();
            frmLROperIntracom.MdiParent = this;
            frmLROperIntracom.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void btFacturasEmitidas_Click(object sender, EventArgs e)
        {
            CrearLoteEmitidas();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolStripStatusLabel2.Text);
        }

        private void btFacturasRecibidas_Click(object sender, EventArgs e)
        {
            CrearLoteRecibidas();
        }

        private void crearLoteOperIntracomTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteOperIntracom();
        }
    }
}
