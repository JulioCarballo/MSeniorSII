using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sample
{
    public partial class formXmlViewer : Form
    {

        public string Path { get; set; }

        public formXmlViewer()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
         
        }

        private void formXmlViewer_Shown(object sender, EventArgs e)
        {
            // Muestro el xml en el web browser
            if(Path != null)
                webBrw.Navigate(Path);
        }

        private void mnSave_Click(object sender, EventArgs e)
        {
            dlgSave.ShowDialog();
            if (!string.IsNullOrEmpty(dlgSave.FileName))
            {
                if (File.Exists(dlgSave.FileName))
                    File.Delete(dlgSave.FileName);

                File.Copy(Path, dlgSave.FileName);
            }
        }
    }
}
