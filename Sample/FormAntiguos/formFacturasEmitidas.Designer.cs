namespace Sample
{
    partial class formFacturasEmitidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFacturasEmitidas));
            this.webBrw = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrw
            // 
            this.webBrw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrw.Location = new System.Drawing.Point(0, 0);
            this.webBrw.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrw.Name = "webBrw";
            this.webBrw.Size = new System.Drawing.Size(518, 286);
            this.webBrw.TabIndex = 0;
            // 
            // formFacturasEmitidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 286);
            this.Controls.Add(this.webBrw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formFacturasEmitidas";
            this.Text = ":: EJEMPLO SII: ENVÍO LOTE FACTURAS EMITIDAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrw;
    }
}

