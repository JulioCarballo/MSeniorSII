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
    public partial class formSelectCertificate : Form
    {

        public string CertificateSerial;

        public formSelectCertificate()
        {
            InitializeComponent();
        }

        private void formSelectCertificate_Load(object sender, EventArgs e)
        {
            X509Store store = new X509Store();
            store.Open(OpenFlags.ReadOnly);
            foreach (var certificate in store.Certificates)
                grdCertificates.Rows.Add(certificate.Subject, certificate.SerialNumber);
               
        }

        private void grdCertificates_DoubleClick(object sender, EventArgs e)
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

        private void grdCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectCertificate();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
