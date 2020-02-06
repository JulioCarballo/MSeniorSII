using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Windows.Forms;

namespace MSeniorSII
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
            formSettings frmSettings = new formSettings
            {
                MdiParent = this
            };
            frmSettings.Show();
        }

 

        private void CrearLoteEmitidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas emitidas a enviar al SII de la AEAT.
            formLREmitidasBatch frmLREmitidas =
                new formLREmitidasBatch
                {
                    MdiParent = this
                };
            frmLREmitidas.Show();
        }

        private void CrearLoteRecibidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas recibidas a enviar al SII de la AEAT.
            formLRRecibidasBatch frmLRRecibidas =
                new formLRRecibidasBatch
                {
                    MdiParent = this
                };
            frmLRRecibidas.Show();
        }

        private void CrearLoteOperIntracom()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de operaciones intracomunitarias a enviar al SII de la AEAT.
            formLROperIntracomBatch frmLROperIntracom = new formLROperIntracomBatch
            {
                MdiParent = this
            };
            frmLROperIntracom.Show();
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

        private void crearLoteOperIntracomTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteOperIntracom();
        }

        private void crearLoteFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteRecibidas();
        }

        private void crearLoteFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteEmitidas();
        }

        private void consultaFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la consulta de las facturas Emitidas enviadas a al AEAT.
            formLREmitidasQuery frmConsultaFactEmitidas = new formLREmitidasQuery
            {
                MdiParent = this
            };
            frmConsultaFactEmitidas.Show();
        }

        private void consultaFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la consulta de las facturas Emitidas enviadas a al AEAT.
            formLRRecibidasQuery frmConsultaFactRecibidas = new formLRRecibidasQuery
            {
                MdiParent = this
            };
            frmConsultaFactRecibidas.Show();

        }

        private void consultaOperIntracomTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la consulta de las facturas Emitidas enviadas a al AEAT.
            formLROperIntracomQuery frmConsultaOperIntracom = new formLROperIntracomQuery
            {
                MdiParent = this
            };
            frmConsultaOperIntracom.Show();
        }

        private void loteCobrosFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la generación del lote de cobros de facturas emitidas.
            formLRCobrosEmitidasBatch frmCobrosEmitidas = new formLRCobrosEmitidasBatch
            {
                MdiParent = this
            };
            frmCobrosEmitidas.Show();
        }

        private void consultaCobrosFactEmitTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la consulta de los cobros de facturas Emitidas enviados a al AEAT.
            formLRCobrosEmitidasQuery frmConsultaCobrosFactEmit = new formLRCobrosEmitidasQuery
            {
                MdiParent = this
            };
            frmConsultaCobrosFactEmit.Show();
        }

        private void lotePagosFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la generación del lote de pagos de facturas recibidas.
            formLRPagosRecibidasBatch frmPagosRecibidas = new formLRPagosRecibidasBatch
            {
                MdiParent = this
            };
            frmPagosRecibidas.Show();
        }

        private void consultaPagosFactRecTSMI_Click(object sender, EventArgs e)
        {
            // Lanzamos la consulta de los pagos de facturas recibidas enviados a al AEAT.
            formLRPagosRecibidasQuery frmConsultaPagosFactRec = new formLRPagosRecibidasQuery
            {
                MdiParent = this
            };
            frmConsultaPagosFactRec.Show();
        }
    }
}
