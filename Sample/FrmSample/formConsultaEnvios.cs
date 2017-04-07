using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasySII.Business;

namespace Sample
{
    public partial class formConsultaEnvios : Form
    {
        public formConsultaEnvios()
        {
            InitializeComponent();
        }

        private void formConsultaEnvios_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(EasySII.Settings.Current.OutboxPath);


            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string key = fileName.Split('.')[0];

                if(Context.BatchFilePrefixes.Keys.Contains<string>(key))
                    trView.Nodes.Add(Context.BatchFilePrefixes[key]);

            }
        }
    }
}
