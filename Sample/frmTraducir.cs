using EasySII;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sample
{
    public partial class frmTraducir : Form
    {
        public frmTraducir()
        {
            InitializeComponent();
        }

        private void frmTraducir_Load(object sender, EventArgs e)
        {
            // Indicamos la carpeta desde la que se tenderán que seleccionar los fichero a traducir.
            txtDirectorio.Text = Settings.Current.InboxPath;

            // Se recorre un directorio y genera los XML de todos los ficheros que encuentre y cumplan las condiciones
            // de búsqueda, en este caso 'SII*.DAT'.
            GenerarFicheros _GenFicheros = new GenerarFicheros();

            string[] listaFicheros = Directory.GetFiles(txtDirectorio.Text, "SII*.DAT");
            foreach (string _NomFichero in listaFicheros)
            {
                dgwFicheros.Rows.Add(_NomFichero);
            }

        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            GenerarFicheros _GenFicheros = new GenerarFicheros();

            // Con esta instrucción, procedemos a indicar el fichero seleccionado que queremos traducir
            string _NomFichero = dgwFicheros.CurrentCell.Value.ToString();

            _GenFicheros.GeneraFicheros(_NomFichero);

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            // Indicamos la carpeta desde la que se tenderán que seleccionar los fichero a traducir.
            txtDirectorio.Text = Settings.Current.InboxPath;

            // Se recorre un directorio y genera los XML de todos los ficheros que encuentre y cumplan las condiciones
            // de búsqueda, en este caso 'SII*.DAT'.
            GenerarFicheros _GenFicheros = new GenerarFicheros();

            string[] listaFicheros = Directory.GetFiles(txtDirectorio.Text, "SII*.DAT");
            foreach (string _NomFichero in listaFicheros)
            {
                _GenFicheros.GeneraFicheros(_NomFichero);
            }

        }
    }
}
