using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class frmPrincipal_Old : Form
    {
        public frmPrincipal_Old()
        {
            InitializeComponent();
        }

        private void configuraciónTSMI_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmSettings = new frmConfiguracion();
            frmSettings.Show();
        }

        private void ficherosDATTSMI_Click(object sender, EventArgs e)
        {
            frmTraducir frmTraduccion = new frmTraducir();
            frmTraduccion.Show();
        }

        private void loteFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            frmLREmitidasBatch frmLREmitidas = new frmLREmitidasBatch();
            frmLREmitidas.Show();
        }

        private void loteFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            frmLRRecibidasBatch frmLRRecibidas = new frmLRRecibidasBatch();
            frmLRRecibidas.Show();
        }

    }
}
