namespace Sample
{
    partial class formXmlViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formXmlViewer));
            this.webBrw = new System.Windows.Forms.WebBrowser();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrw
            // 
            this.webBrw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrw.Location = new System.Drawing.Point(0, 29);
            this.webBrw.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrw.Name = "webBrw";
            this.webBrw.Size = new System.Drawing.Size(518, 257);
            this.webBrw.TabIndex = 0;
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Archivos xml|*.xml";
            this.dlgSave.Title = "GUARDAR XML";
            // 
            // mnMain
            // 
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSave});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(518, 29);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
            // 
            // mnSave
            // 
            this.mnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnSave.Image = global::Sample.Properties.Resources.Ribbon_Save_32x32;
            this.mnSave.Name = "mnSave";
            this.mnSave.Size = new System.Drawing.Size(95, 25);
            this.mnSave.Text = "Guardar";
            this.mnSave.Click += new System.EventHandler(this.mnSave_Click);
            // 
            // formXmlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 286);
            this.Controls.Add(this.webBrw);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.Name = "formXmlViewer";
            this.Text = ":: EJEMPLO SII: VISOR XML";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Shown += new System.EventHandler(this.formXmlViewer_Shown);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrw;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
    }
}

