using EasySII;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            txInbox.Text = Settings.Current.InboxPath;
            txOutbox.Text = Settings.Current.OutboxPath;
            txSerial.Text = Settings.Current.CertificateSerial;
            txVersion.Text = Settings.Current.IDVersionSii;
            txSiiEndPointPrefix.Text = Settings.Current.SiiEndPointPrefix;
        }

        private void formSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Current.InboxPath = txInbox.Text;
            Settings.Current.OutboxPath = txOutbox.Text;
            Settings.Current.CertificateSerial = txSerial.Text;
            Settings.Current.IDVersionSii= txVersion.Text;
            Settings.Current.SiiEndPointPrefix = txSiiEndPointPrefix.Text;
            // Guardamos la configuración
            Settings.Save();
        }

        private void btInbox_Click(object sender, EventArgs e)
        {
            fldBrw.ShowDialog();
            if (Directory.Exists(fldBrw.SelectedPath))
                txInbox.Text = fldBrw.SelectedPath + "\\";
        }

        private void btOutbox_Click(object sender, EventArgs e)
        {
            fldBrw.ShowDialog();
            if (Directory.Exists(fldBrw.SelectedPath))
                txOutbox.Text = fldBrw.SelectedPath + "\\";
        }

        private void btSerial_Click(object sender, EventArgs e)
        {
            formSelectCertificate frmSelectCertificate = new formSelectCertificate();
            frmSelectCertificate.ShowDialog();
            if (!string.IsNullOrEmpty(frmSelectCertificate.CertificateSerial))
                txSerial.Text = frmSelectCertificate.CertificateSerial;
        }
    }
}
