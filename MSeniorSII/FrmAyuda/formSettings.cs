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
/*
 * Toda la información que hace referencia a los parámetros que se utilizan en la ejecución de este proceso,
 * se almacenan en el correspondiente XML en la siguiente carpeta: C:\ProgramData\EasySII.
 */
namespace MSeniorSII
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            txInbox.Text = Settings.Current.InboxPath;
            txOutbox.Text = Settings.Current.OutboxPath;
            txSerial.Text = Settings.Current.CertificateSerial;
            txVersion.Text = Settings.Current.IDVersionSii;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Current.InboxPath = txInbox.Text;
            Settings.Current.OutboxPath = txOutbox.Text;
            Settings.Current.CertificateSerial = txSerial.Text;
            Settings.Current.IDVersionSii= txVersion.Text;
            // Guardamos la configuración
            Settings.Save();
        }

        private void BtInbox_Click(object sender, EventArgs e)
        {
            fldBrw.ShowDialog();
            if (Directory.Exists(fldBrw.SelectedPath))
                txInbox.Text = fldBrw.SelectedPath + "\\";
        }

        private void BtOutbox_Click(object sender, EventArgs e)
        {
            fldBrw.ShowDialog();
            if (Directory.Exists(fldBrw.SelectedPath))
                txOutbox.Text = fldBrw.SelectedPath + "\\";
        }

        private void BtSerial_Click(object sender, EventArgs e)
        {
            FormSelectCertificate frmSelectCertificate = new FormSelectCertificate();
            frmSelectCertificate.ShowDialog();
            if (!string.IsNullOrEmpty(frmSelectCertificate.CertificateSerial))
                txSerial.Text = frmSelectCertificate.CertificateSerial;
        }
    }
}
