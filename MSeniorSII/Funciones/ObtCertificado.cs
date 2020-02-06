using EasySII;
using EasySII.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSeniorSII
{
    class ObtCertificado
    {
        public void ObtCertificadoDigital(ref string NIFEmpresa, ref string NomEmpresa)
        {
            var cert = Wsd.GetCertificate();

            if (cert == null)
            {
                string _msg = "Debe configurar un certificado digital para utilizar la aplicación.";
                MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cert.Subject.StartsWith("CN="))
            {
                string cn = cert.Subject.Replace("CN=", "");

                string[] tokens = cn.Split('-');

                string nifCandidate = tokens[1].Replace("CIF", "").Replace("NIF", "").Trim();

                if (tokens.Length > 1 && nifCandidate.Length == 9)
                {
                    NomEmpresa = tokens[0].Trim();
                    NIFEmpresa = tokens[1].Replace("CIF", "").Replace("NIF", "").Trim();
                }
            }
            else
            {

                string[] tokens = cert.Subject.Split(',');
                string nifCandidate = tokens[2].Replace("OID.2.5.4.97=VATES-", "").Trim();

                if (tokens.Length > 1 && nifCandidate.Length == 9)
                {
                    NomEmpresa = tokens[1].Replace("O=", "").Trim();
                    NIFEmpresa = nifCandidate;
                }
            }
        }

        public void BuscaCertificadoDigital(ref string NIFEmpresa, ref string NomEmpresa, ref string NroSerie)
        {

            string NomEmpresaWrk;
            string nifCandidate;

            X509Store store = new X509Store();
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 cert in store.Certificates)
            {
                if (cert.Subject.StartsWith("CN="))
                {
                    string cn = cert.Subject.Replace("CN=", "");
                    string[] tokens = cn.Split('-');
                    nifCandidate = tokens[1].Replace("CIF", "").Replace("NIF", "").Trim();
                    NomEmpresaWrk = tokens[0].Trim();
                }
                else
                {
                    string[] tokens = cert.Subject.Split(',');
                    nifCandidate = tokens[2].Replace("OID.2.5.4.97=VATES-", "").Trim();
                    NomEmpresaWrk = tokens[1].Replace("O=", "").Trim();
                }

                if (NIFEmpresa == nifCandidate)
                {
                    NomEmpresa = NomEmpresaWrk;
                    NroSerie = cert.SerialNumber;
                    // Cada vez que cambiemos de empresa, se guardará su certificado correspondiente, de manera que 
                    // se realizarán todas las operaciones con el certificado que se haya cargado en ese momento.
                    Settings.Current.CertificateSerial = cert.SerialNumber;
                    Settings.Save();
                    break;
                }
            }

            if (string.IsNullOrEmpty(NroSerie))
            {
                string _msg = "No existe el certificado para la empresa indicada";
                MessageBox.Show(_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
