namespace Sample
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loteFactEmitidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loteFactRecibidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.loteFactIntracomTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.loteCobrosFactEmitidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSDDBConsultas = new System.Windows.Forms.ToolStripDropDownButton();
            this.factEmitidasEnviadasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.factRecibidasEnviadasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.operIntracomEnviadasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cobrosFactEmitidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btSettings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lotePagosFactRecibidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosFactRecibidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.tSDDBConsultas,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 28);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loteFactEmitidasToolStripMenuItem,
            this.loteFactRecibidasTSMI,
            this.loteFactIntracomTSMI,
            this.loteCobrosFactEmitidasTSMI,
            this.lotePagosFactRecibidasTSMI});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(125, 25);
            this.toolStripDropDownButton1.Text = "Creación Lotes";
            // 
            // loteFactEmitidasToolStripMenuItem
            // 
            this.loteFactEmitidasToolStripMenuItem.Name = "loteFactEmitidasToolStripMenuItem";
            this.loteFactEmitidasToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.loteFactEmitidasToolStripMenuItem.Text = "Lote Fact. Emitidas";
            this.loteFactEmitidasToolStripMenuItem.Click += new System.EventHandler(this.loteFactEmitidasTSMI_Click);
            // 
            // loteFactRecibidasTSMI
            // 
            this.loteFactRecibidasTSMI.Name = "loteFactRecibidasTSMI";
            this.loteFactRecibidasTSMI.Size = new System.Drawing.Size(262, 26);
            this.loteFactRecibidasTSMI.Text = "Lote Fact. Recibidas";
            this.loteFactRecibidasTSMI.Click += new System.EventHandler(this.loteFactRecibidasTSMI_Click);
            // 
            // loteFactIntracomTSMI
            // 
            this.loteFactIntracomTSMI.Name = "loteFactIntracomTSMI";
            this.loteFactIntracomTSMI.Size = new System.Drawing.Size(262, 26);
            this.loteFactIntracomTSMI.Text = "Lote Fact. Intracom.";
            this.loteFactIntracomTSMI.Click += new System.EventHandler(this.loteFactIntracomTSMI_Click);
            // 
            // loteCobrosFactEmitidasTSMI
            // 
            this.loteCobrosFactEmitidasTSMI.Name = "loteCobrosFactEmitidasTSMI";
            this.loteCobrosFactEmitidasTSMI.Size = new System.Drawing.Size(262, 26);
            this.loteCobrosFactEmitidasTSMI.Text = "Lote Cobros Fact. Emitidas";
            this.loteCobrosFactEmitidasTSMI.Click += new System.EventHandler(this.loteCobrosFactEmitidasTSMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // tSDDBConsultas
            // 
            this.tSDDBConsultas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSDDBConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.factEmitidasEnviadasTSMI,
            this.factRecibidasEnviadasTSMI,
            this.operIntracomEnviadasTSMI,
            this.cobrosFactEmitidasTSMI,
            this.pagosFactRecibidasTSMI});
            this.tSDDBConsultas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tSDDBConsultas.Image = ((System.Drawing.Image)(resources.GetObject("tSDDBConsultas.Image")));
            this.tSDDBConsultas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSDDBConsultas.Name = "tSDDBConsultas";
            this.tSDDBConsultas.Size = new System.Drawing.Size(91, 25);
            this.tSDDBConsultas.Text = "Consultas";
            // 
            // factEmitidasEnviadasTSMI
            // 
            this.factEmitidasEnviadasTSMI.Name = "factEmitidasEnviadasTSMI";
            this.factEmitidasEnviadasTSMI.Size = new System.Drawing.Size(252, 26);
            this.factEmitidasEnviadasTSMI.Text = "Fact. Emitidas Enviadas";
            this.factEmitidasEnviadasTSMI.Click += new System.EventHandler(this.factEmitidasEnviadasTSMI_Click);
            // 
            // factRecibidasEnviadasTSMI
            // 
            this.factRecibidasEnviadasTSMI.Name = "factRecibidasEnviadasTSMI";
            this.factRecibidasEnviadasTSMI.Size = new System.Drawing.Size(252, 26);
            this.factRecibidasEnviadasTSMI.Text = "Fact. Recibidas Enviadas";
            this.factRecibidasEnviadasTSMI.Click += new System.EventHandler(this.factRecibidasEnviadasTSMI_Click);
            // 
            // operIntracomEnviadasTSMI
            // 
            this.operIntracomEnviadasTSMI.Name = "operIntracomEnviadasTSMI";
            this.operIntracomEnviadasTSMI.Size = new System.Drawing.Size(252, 26);
            this.operIntracomEnviadasTSMI.Text = "Oper. Intracom. Enviadas";
            this.operIntracomEnviadasTSMI.Click += new System.EventHandler(this.operIntracomEnviadasTSMI_Click);
            // 
            // cobrosFactEmitidasTSMI
            // 
            this.cobrosFactEmitidasTSMI.Name = "cobrosFactEmitidasTSMI";
            this.cobrosFactEmitidasTSMI.Size = new System.Drawing.Size(252, 26);
            this.cobrosFactEmitidasTSMI.Text = "Cobros Fact. Emitidas";
            this.cobrosFactEmitidasTSMI.Click += new System.EventHandler(this.cobrosFactEmitidasTSMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 25);
            this.toolStripButton1.Text = "Traducir MIS";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btSettings
            // 
            this.btSettings.AutoSize = false;
            this.btSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btSettings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(155, 25);
            this.btSettings.Text = "Configuración";
            this.btSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(196, 17);
            this.toolStripStatusLabel1.Text = "Mundosenior | Mundosocial | Novotours";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(143, 17);
            this.toolStripStatusLabel2.Text = "http://www.mundosenior.es";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dlgTraducir";
            // 
            // lotePagosFactRecibidasTSMI
            // 
            this.lotePagosFactRecibidasTSMI.Name = "lotePagosFactRecibidasTSMI";
            this.lotePagosFactRecibidasTSMI.Size = new System.Drawing.Size(262, 26);
            this.lotePagosFactRecibidasTSMI.Text = "Lote Pagos Fact. Recibidas";
            this.lotePagosFactRecibidasTSMI.Click += new System.EventHandler(this.lotePagosFactRecibidasTSMI_Click);
            // 
            // pagosFactRecibidasTSMI
            // 
            this.pagosFactRecibidasTSMI.Name = "pagosFactRecibidasTSMI";
            this.pagosFactRecibidasTSMI.Size = new System.Drawing.Size(252, 26);
            this.pagosFactRecibidasTSMI.Text = "Pagos Fact. Recibidas";
            this.pagosFactRecibidasTSMI.Click += new System.EventHandler(this.pagosFactRecibidasTSMI_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 347);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Principal - Envio SII (Mundosenior)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem loteFactEmitidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loteFactRecibidasTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem loteFactIntracomTSMI;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripDropDownButton tSDDBConsultas;
        private System.Windows.Forms.ToolStripMenuItem factEmitidasEnviadasTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem factRecibidasEnviadasTSMI;
        private System.Windows.Forms.ToolStripMenuItem operIntracomEnviadasTSMI;
        private System.Windows.Forms.ToolStripMenuItem loteCobrosFactEmitidasTSMI;
        private System.Windows.Forms.ToolStripMenuItem cobrosFactEmitidasTSMI;
        private System.Windows.Forms.ToolStripMenuItem lotePagosFactRecibidasTSMI;
        private System.Windows.Forms.ToolStripMenuItem pagosFactRecibidasTSMI;
    }
}