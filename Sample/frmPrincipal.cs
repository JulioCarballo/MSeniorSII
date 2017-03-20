using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmSettings = new frmConfiguracion();
            frmSettings.Show();
        }

        private void ficherosDATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraducir frmTraduccion = new frmTraducir();
            frmTraduccion.Show();
        }
        /*
private void btEnvioEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío de lote
  // de facturas emitidas al SII de la AEAT.
  formFacturasEmitidas frmFacturasEmitidas = new formFacturasEmitidas();
  frmFacturasEmitidas.Show();
}

private void btEnvioRecibidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío de lote
  // de facturas recibidas al SII de la AEAT.
  formFacturasRecibidas frmFacturasRecibidas = new formFacturasRecibidas();
  frmFacturasRecibidas.Show();
}

private void brCobrosEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío de lote
  // de cobros de factura emitidas al SII de la AEAT.
  formCobrosEmitidas frmCobrosEmitidas = new formCobrosEmitidas();
  frmCobrosEmitidas.Show();
}

private void brPagosRecibidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío de lote
  // de cobros de factura recibidas al SII de la AEAT.
  formPagosRecibidas frmPagosRecibidas = new formPagosRecibidas();
  frmPagosRecibidas.Show();
}

private void btConsultaEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de cosulta de documentos
  // de facturas emitidas envíadas al SII de la AEAT.
  formFacturasEmitidasConsulta frmFacturasEmitidasConsulta = new formFacturasEmitidasConsulta();
  frmFacturasEmitidasConsulta.Show();
}

private void btConsultaRecibidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de cosulta de documentos
  // de facturas recibidas envíadas al SII de la AEAT.
  formFacturasRecibidasConsulta frmFacturasRecibidasConsulta = new formFacturasRecibidasConsulta();
  frmFacturasRecibidasConsulta.Show();
}

private void btConsultaCobrosEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de cosulta de documentos
  // de cobros de facturas emitidas envíados al SII de la AEAT.
  formFacturasEmitidasCobrosConsulta frmFacturasEmitidasCobrosConsulta = new formFacturasEmitidasCobrosConsulta();
  frmFacturasEmitidasCobrosConsulta.Show();
}

private void btDeleteEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de borrado de documentos
  // de facturas emitidas envíadas al SII de la AEAT.
  formBajaFacturasEmitidas frmBajaFacturasEmitidas = new formBajaFacturasEmitidas();
  frmBajaFacturasEmitidas.Show();
}

private void btDeleteRecibidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de borrado de documentos
  // de facturas recibidas envíadas al SII de la AEAT.
  formBajaFacturasRecibidas frmBajaFacturasRecibidas = new formBajaFacturasRecibidas();
  frmBajaFacturasRecibidas.Show();
}

private void btResumenFacturasSimplificadas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de asiento resumen de
  // de facturas simplificadas a enviar al SII de la AEAT.
  formAsientoResumenFacturasSimplificadas frmAsientoResumenFacturasSimplificadas = 
      new formAsientoResumenFacturasSimplificadas();
  frmAsientoResumenFacturasSimplificadas.Show();
}

private void btBienesInversion_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío
  // de lote bienes inversión a enviar al SII de la AEAT.
  formBienesInversion frmBienesInversion =
      new formBienesInversion();
  frmBienesInversion.Show();
}

private void btCrearLoteEmitidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío
  // de lote bienes inversión a enviar al SII de la AEAT.
  formLREmitidas frmLREmitidas =
      new formLREmitidas();
  frmLREmitidas.Show();
}

private void btCrearLoteRecibidas_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío
  // de lote bienes inversión a enviar al SII de la AEAT.
  formLRRecibidas frmLRRecibidas =
      new formLRRecibidas();
  frmLRRecibidas.Show();
}

private void btEnvioEmitidasNifOtro_Click(object sender, EventArgs e)
{
  // Abrimos el formulario que contiene el ejemplo de envío
  // lote de facturas con NIF otro.
  formFacturasEmitidasNifOtro frmFacturasEmitidasNifOtro =
      new formFacturasEmitidasNifOtro();
  frmFacturasEmitidasNifOtro.Show();
}
*/

    }
}
