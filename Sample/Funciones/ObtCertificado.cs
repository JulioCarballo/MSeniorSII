using EasySII.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
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
    }
}
