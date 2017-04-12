using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Security;
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

        private void CrearTraducir()
        {
            frmTraducir frmTraducirLote = new frmTraducir();
            frmTraducirLote.MdiParent = this;
            frmTraducirLote.Show();
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

        private void CrearLoteOperIntracom()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de operciones intracomunitarias a enviar al SII de la AEAT.
            frmLROperIntracomBatch frmLROperIntracom = new frmLROperIntracomBatch();
            frmLROperIntracom.MdiParent = this;
            frmLROperIntracom.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Establecemos los ficheros que se pueden seleccionar para poder traducir
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Filter =
                "Ficheros CSV (SII*.DAT)|SII*.DAT|" +
                "All files (*.*)|*.*";

            // Indicamos que se puede tratar de una multiselección.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Ficheros a traducir para envío SII";

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
            // Creamos la clase para poder llamar a la rutina de traducción.
            GenerarFicheros _GenFicheros = new GenerarFicheros();

            // Mostramos el cuadro de diálogo para poder selccionar el/los fichero/s.
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Procedemos a leer los ficheros que hayamos elegido
                foreach (String file in openFileDialog1.FileNames)
                {
                    // Procedemos a traducir los ficheros que vamos leyendo
                    try
                    {
                        _GenFicheros.GeneraFicheros(file);
                    }
                    catch (SecurityException ex)
                    {
                        string _msgError = "Error de seguridad. Contacta con el Administrador para los detalles.\n\n" +
                            "Mensaje error: " + ex.Message + "\n\n" + "Detalles (enviar a soporte):\n\n" + ex.StackTrace;
                        MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        string _msgError = "Error con el fichero: " + file.Substring(file.LastIndexOf('\\'))
                            + ". Puede que no tengas permisos de lectura o esté corrupto\n\nError a enviar: " + ex.Message;
                        MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loteFactIntracomTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteOperIntracom();
        }

        private void factEmitidasEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // facturas emitidas enviadas al SII de la AEAT.
            frmLREmitidasQuery frmConsultaFactEmitidas = new frmLREmitidasQuery();
            frmConsultaFactEmitidas.MdiParent = this;
            frmConsultaFactEmitidas.Show();
        }

        private void factRecibidasEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // facturas recibidas enviadas al SII de la AEAT.
            frmLRRecibidasQuery frmConsultaFactRecibidas = new frmLRRecibidasQuery();
            frmConsultaFactRecibidas.MdiParent = this;
            frmConsultaFactRecibidas.Show();
        }

        private void operIntracomEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // operaciones intracomunitarias enviadas al SII de la AEAT.
            frmLROperIntracomQuery frmConsultaOperIntracom = new frmLROperIntracomQuery();
            frmConsultaOperIntracom.MdiParent = this;
            frmConsultaOperIntracom.Show();
        }

        private void loteCobrosFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // del lote de cobros de facturas emitidas a enviar al SII de la AEAT.
            frmLRCobrosEmitidasBatch frmLRCobrosEmitidas = new frmLRCobrosEmitidasBatch();
            frmLRCobrosEmitidas.MdiParent = this;
            frmLRCobrosEmitidas.Show();
        }

        private void cobrosFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de la consulta de cobros de facturas emitidas a enviar al SII de la AEAT.
            frmLRCobrosEmitidasQuery frmConsultaCobrosEmitidas = new frmLRCobrosEmitidasQuery();
            frmConsultaCobrosEmitidas.MdiParent = this;
            frmConsultaCobrosEmitidas.Show();
        }

        private void lotePagosFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // del lote de cobros de facturas emitidas a enviar al SII de la AEAT.
            frmLRPagosRecibidasBatch frmLRPagosRecibidas = new frmLRPagosRecibidasBatch();
            frmLRPagosRecibidas.MdiParent = this;
            frmLRPagosRecibidas.Show();
        }

        private void pagosFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de la consulta de cobros de facturas emitidas a enviar al SII de la AEAT.
            frmLRPagosRecibidasQuery frmConsultaPagosRecibidas = new frmLRPagosRecibidasQuery();
            frmConsultaPagosRecibidas.MdiParent = this;
            frmConsultaPagosRecibidas.Show();
        }
    }
}
