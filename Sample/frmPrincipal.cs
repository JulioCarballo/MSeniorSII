using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Settings()
        {
            // Abrimos el formulario de configuración
            frmConfiguracion frmSettings = new frmConfiguracion();
            frmSettings.MdiParent = this;
            frmSettings.Show();
        }

 

        private void CrearLoteEmitidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas emitidas a enviar al SII de la AEAT.
            frmLREmitidasBatch frmLREmitidas = new frmLREmitidasBatch();
            frmLREmitidas.MdiParent = this;
            frmLREmitidas.Show();
        }

        private void CrearLoteRecibidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas recibidas a enviar al SII de la AEAT.
            frmLRRecibidasBatch frmLRRecibidas = new frmLRRecibidasBatch();
            frmLRRecibidas.MdiParent = this;
            frmLRRecibidas.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolStripStatusLabel2.Text);
        }

        private void loteFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteEmitidas();
        }

        private void loteFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteRecibidas();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTraducir frmTraducirLote = new frmTraducir();
            frmTraducirLote.MdiParent = this;
            frmTraducirLote.Show();
        }

        private void loteFactIntracomTSMI_Click(object sender, EventArgs e)
        {
            //Todavía no hemos acabado las pruebas con el formulario correspondiente.
        }
    }
}
