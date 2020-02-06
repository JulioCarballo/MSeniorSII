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

namespace MSeniorSII
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

            Dictionary<string, List<string>> Operaciones = new Dictionary<string, List<string>>();


            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string key = fileName.Split('.')[0];

                if (!Operaciones.ContainsKey(key))
                    Operaciones.Add(key, new List<string>());


                Operaciones[key].Add(fileName);                    

            }

            foreach(KeyValuePair<string, List<string>> kvp in Operaciones)
            {
                if (Context.BatchFilePrefixes.ContainsKey(kvp.Key))
                { 
                    TreeNode tNode = trView.Nodes.Add($"{Context.BatchFilePrefixes[kvp.Key]}({kvp.Value.Count})");
                    foreach (var lote in kvp.Value)
                        tNode.Nodes.Add(DecodeFileName(lote));
                }
            }

        }

        private string DecodeFileName(string fileName)
        {
           

            string[] values = fileName.Split('.');

            string taxId = values[2];

            string docIni = Encoding.UTF8.GetString(ToByte(values[3]));

            string docFin = Encoding.UTF8.GetString(ToByte(values[4]));

            return $"NIF titular {taxId}: Del doc. nº  {docIni} al doc. nº {docFin}";
        }
        /// <summary>
        /// Convierte un string que representa un conjunto de bytes en hexadecimal en una matriz de bytes.
        /// </summary>
        /// <param name="hexString">String con la representación hexadecimal de una matriz de bytes.</param>
        /// <returns></returns>
        private  byte[] ToByte(string hexString)
        {
            try
            {
                int numberChars = hexString.Length;
                byte[] bytesReturn = new byte[numberChars / 2];
                for (int i = 0; i < numberChars; i += 2)
                    bytesReturn[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
                return bytesReturn;
            }
            catch (Exception ex)
            {
               MessageBox.Show(":: ERROR: (byte[] ToByte(string hexString)) => " +
                    ex.ToString());
                return null;
            }

        }
    }
}
