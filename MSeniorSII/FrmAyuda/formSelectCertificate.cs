using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class FormSelectCertificate : Form
    {

        public string CertificateSerial;

        public FormSelectCertificate()
        {
            InitializeComponent();
        }

        private void FormSelectCertificate_Load(object sender, EventArgs e)
        {
            X509Store store = new X509Store();
            store.Open(OpenFlags.ReadOnly);
            foreach (var certificate in store.Certificates)
                grdCertificates.Rows.Add(certificate.Subject, certificate.SerialNumber);
               
        }

        private void GrdCertificates_DoubleClick(object sender, EventArgs e)
        {

            SelectCertificate();

        }

        private void SelectCertificate()
        {
            if (grdCertificates.SelectedRows.Count > 0)
            {
                CertificateSerial = grdCertificates.SelectedRows[0].Cells[1].Value.ToString();
                Close();
            }
        }

        private void GrdCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectCertificate();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
