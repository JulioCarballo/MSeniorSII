namespace Sample
{
    partial class btARInvoiceBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btARInvoiceBatch));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btFacturasEmitidas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFacturasRecibidas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btSettings = new System.Windows.Forms.ToolStripButton();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSDDBNuevas = new System.Windows.Forms.ToolStripDropDownButton();
            this.crearLoteOperIntracomTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFacturasEmitidas,
            this.toolStripSeparator1,
            this.btFacturasRecibidas,
            this.toolStripSeparator2,
            this.btSettings,
            this.toolStripSeparator3,
            this.tSDDBNuevas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 28);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btFacturasEmitidas
            // 
            this.btFacturasEmitidas.AutoSize = false;
            this.btFacturasEmitidas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFacturasEmitidas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btFacturasEmitidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFacturasEmitidas.Name = "btFacturasEmitidas";
            this.btFacturasEmitidas.Size = new System.Drawing.Size(155, 25);
            this.btFacturasEmitidas.Text = "Crear lote facturas emitidas";
            this.btFacturasEmitidas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btFacturasEmitidas.Click += new System.EventHandler(this.btFacturasEmitidas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btFacturasRecibidas
            // 
            this.btFacturasRecibidas.AutoSize = false;
            this.btFacturasRecibidas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFacturasRecibidas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btFacturasRecibidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFacturasRecibidas.Name = "btFacturasRecibidas";
            this.btFacturasRecibidas.Size = new System.Drawing.Size(155, 25);
            this.btFacturasRecibidas.Text = "Crear lote facturas recibidas";
            this.btFacturasRecibidas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btFacturasRecibidas.Click += new System.EventHandler(this.btFacturasRecibidas_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btSettings
            // 
            this.btSettings.AutoSize = false;
            this.btSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(155, 25);
            this.btSettings.Text = "Opciones de configuración";
            this.btSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // rchText
            // 
            this.rchText.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchText.Dock = System.Windows.Forms.DockStyle.Top;
            this.rchText.Enabled = false;
            this.rchText.Location = new System.Drawing.Point(0, 28);
            this.rchText.Multiline = false;
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(684, 23);
            this.rchText.TabIndex = 16;
            this.rchText.Text = resources.GetString("rchText.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel1.Text = "Irene Solutions SL";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(192, 17);
            this.toolStripStatusLabel2.Text = "http://www.easysii.irenesolutions.com";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // tSDDBNuevas
            // 
            this.tSDDBNuevas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSDDBNuevas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearLoteOperIntracomTSMI});
            this.tSDDBNuevas.Image = ((System.Drawing.Image)(resources.GetObject("tSDDBNuevas.Image")));
            this.tSDDBNuevas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSDDBNuevas.Name = "tSDDBNuevas";
            this.tSDDBNuevas.Size = new System.Drawing.Size(102, 25);
            this.tSDDBNuevas.Text = "Opciones nuevas";
            this.tSDDBNuevas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // crearLoteOperIntracomTSMI
            // 
            this.crearLoteOperIntracomTSMI.Name = "crearLoteOperIntracomTSMI";
            this.crearLoteOperIntracomTSMI.Size = new System.Drawing.Size(206, 22);
            this.crearLoteOperIntracomTSMI.Text = "Crear Lote Oper. Intracom.";
            this.crearLoteOperIntracomTSMI.Click += new System.EventHandler(this.crearLoteOperIntracomTSMI_Click);
            // 
            // btARInvoiceBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 347);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rchText);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "btARInvoiceBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: CATALOGO DE EJEMPLOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.ToolStripButton btSettings;
        private System.Windows.Forms.ToolStripButton btFacturasEmitidas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripButton btFacturasRecibidas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tSDDBNuevas;
        private System.Windows.Forms.ToolStripMenuItem crearLoteOperIntracomTSMI;
    }
}