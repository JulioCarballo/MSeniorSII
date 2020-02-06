using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class formTipoOperIntracom : Form
    {

        public string SelectedTipoOperIntra { get; private set; }

        public formTipoOperIntracom()
        {
            InitializeComponent();
        }

        private void formTipoOperIntracom_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {

            grdPaises.Rows.Clear();

            foreach (KeyValuePair<string, string> kvp in General.TipoOperIntracom)
                if(string.IsNullOrEmpty(txPattern.Text))
                    grdPaises.Rows.Add(kvp.Key, kvp.Value);
                else
                    if(kvp.Value.ToUpper().Contains(txPattern.Text.ToUpper()) || kvp.Key.ToUpper().Contains(txPattern.Text.ToUpper()))
                        grdPaises.Rows.Add(kvp.Key, kvp.Value);

        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    int step =(e.KeyCode == Keys.Down) ? 1 : -1;
                    if (grdPaises.SelectedRows.Count > 0)
                    {
                        int next = grdPaises.SelectedRows[0].Index + step;

                        if (next == grdPaises.Rows.Count)
                            next = 1;

                        if (next == -1)
                            next = grdPaises.Rows.Count - 1;

                        grdPaises.SelectedRows[0].Selected = false;

                        grdPaises.Rows[next].Selected = true;

                        if(grdPaises.FirstDisplayedScrollingRowIndex > next || 
                            next > grdPaises.FirstDisplayedScrollingRowIndex + grdPaises.DisplayedRowCount(false))
                            grdPaises.FirstDisplayedScrollingRowIndex = next;

                    }
                    else
                    {
                        if (grdPaises.Rows.Count > 0)
                            grdPaises.Rows[0].Selected = true;
                    }

                    e.SuppressKeyPress = e.Handled = true;

                    break;
                case Keys.Enter:
                    SelectTipoOperIntracom();
                    break;
            }
        }

        private void SelectTipoOperIntracom()
        {
            if (grdPaises.SelectedRows.Count > 0)
            {
                SelectedTipoOperIntra = grdPaises.SelectedRows[0].Cells[0].Value.ToString();
                Close();
            }
        }

        private void txPattern_TextChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void grdPaises_DoubleClick(object sender, EventArgs e)
        {
            SelectTipoOperIntracom();
        }
    }
}
