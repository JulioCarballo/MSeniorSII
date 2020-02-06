using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System;
using System.Security;
using System.Windows.Forms;

namespace MSeniorSII
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
            FrmConfiguracion frmSettings = new FrmConfiguracion
            {
                MdiParent = this
            };
            frmSettings.Show();
        }

        private void CrearTraducir()
        {
            frmTraducir frmTraducirLote = new frmTraducir
            {
                MdiParent = this
            };
            frmTraducirLote.Show();
        }

        private void CrearLoteEmitidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas emitidas a enviar al SII de la AEAT.
            frmLREmitidasBatch frmLREmitidas = new frmLREmitidasBatch
            {
                MdiParent = this
            };
            frmLREmitidas.Show();
        }

        private void CrearLoteRecibidas()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de facturas recibidas a enviar al SII de la AEAT.
            frmLRRecibidasBatch frmLRRecibidas = new frmLRRecibidasBatch
            {
                MdiParent = this
            };
            frmLRRecibidas.Show();
        }

        private void CrearLoteOperIntracom()
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de lote de operciones intracomunitarias a enviar al SII de la AEAT.
            frmLROperIntracomBatch frmLROperIntracom = new frmLROperIntracomBatch
            {
                MdiParent = this
            };
            frmLROperIntracom.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
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

        private void BtSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolStripStatusLabel2.Text);
        }

        private void LoteFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteEmitidas();
        }

        private void LoteFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteRecibidas();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            // Creamos la clase para poder llamar a la rutina de traducción.
            GenerarFicheros _GenFicheros = new GenerarFicheros();

            // Mostramos el cuadro de diálogo para poder selccionar el/los fichero/s.
            DialogResult dialogResult = this.openFileDialog1.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
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

        private void LoteFactIntracomTSMI_Click(object sender, EventArgs e)
        {
            CrearLoteOperIntracom();
        }

        private void FactEmitidasEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // facturas emitidas enviadas al SII de la AEAT.
            frmLREmitidasQuery frmConsultaFactEmitidas = new frmLREmitidasQuery
            {
                MdiParent = this
            };
            frmConsultaFactEmitidas.Show();
        }

        private void FactRecibidasEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // facturas recibidas enviadas al SII de la AEAT.
            frmLRRecibidasQuery frmConsultaFactRecibidas = new frmLRRecibidasQuery
            {
                MdiParent = this
            };
            frmConsultaFactRecibidas.Show();
        }

        private void OperIntracomEnviadasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo para realizar la consulta y posterior baja de las
            // operaciones intracomunitarias enviadas al SII de la AEAT.
            frmLROperIntracomQuery frmConsultaOperIntracom = new frmLROperIntracomQuery
            {
                MdiParent = this
            };
            frmConsultaOperIntracom.Show();
        }

        private void LoteCobrosFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // del lote de cobros de facturas emitidas a enviar al SII de la AEAT.
            FrmLRCobrosEmitidasBatch frmLRCobrosEmitidas = new FrmLRCobrosEmitidasBatch
            {
                MdiParent = this
            };
            frmLRCobrosEmitidas.Show();
        }

        private void CobrosFactEmitidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de la consulta de cobros de facturas emitidas a enviar al SII de la AEAT.
            FrmLRCobrosEmitidasQuery frmConsultaCobrosEmitidas = new FrmLRCobrosEmitidasQuery
            {
                MdiParent = this
            };
            frmConsultaCobrosEmitidas.Show();
        }

        private void LotePagosFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // del lote de cobros de facturas emitidas a enviar al SII de la AEAT.
            FrmLRPagosRecibidasBatch frmLRPagosRecibidas = new FrmLRPagosRecibidasBatch
            {
                MdiParent = this
            };
            frmLRPagosRecibidas.Show();
        }

        private void PagosFactRecibidasTSMI_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario que contiene el ejemplo de envío
            // de la consulta de cobros de facturas emitidas a enviar al SII de la AEAT.
            FrmLRPagosRecibidasQuery frmConsultaPagosRecibidas = new FrmLRPagosRecibidasQuery
            {
                MdiParent = this
            };
            frmConsultaPagosRecibidas.Show();
        }
    }
}
