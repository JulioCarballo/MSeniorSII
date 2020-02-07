using EasySII;
using EasySII.Business;
using EasySII.Net;
using System;
using System.IO;
using System.Windows.Forms;

namespace MSeniorSII
{
    public partial class FormXmlViewer : Form
    {

        public string Path { get; set; }

        public FormXmlViewer()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
         
        }

        private void FormXmlViewer_Shown(object sender, EventArgs e)
        {
            // Muestro el xml en el web browser
            if(Path != null)
                webBrw.Navigate(Path);
        }

        private void MnSave_Click(object sender, EventArgs e)
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
