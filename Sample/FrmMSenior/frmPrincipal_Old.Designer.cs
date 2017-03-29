namespace Sample
{
    partial class frmPrincipal_Old
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal_Old));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traducirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ficherosDATTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loteFactEmitidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loteFactRecibidasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.loteFactIntracomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.configuraciónTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traducirToolStripMenuItem,
            this.generarToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(87, 25);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // traducirToolStripMenuItem
            // 
            this.traducirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficherosDATTSMI});
            this.traducirToolStripMenuItem.Name = "traducirToolStripMenuItem";
            this.traducirToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.traducirToolStripMenuItem.Text = "Traducir";
            // 
            // ficherosDATTSMI
            // 
            this.ficherosDATTSMI.Name = "ficherosDATTSMI";
            this.ficherosDATTSMI.Size = new System.Drawing.Size(171, 26);
            this.ficherosDATTSMI.Text = "Ficheros DAT";
            this.ficherosDATTSMI.Click += new System.EventHandler(this.ficherosDATTSMI_Click);
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loteFactEmitidasToolStripMenuItem,
            this.loteFactRecibidasTSMI,
            this.loteFactIntracomToolStripMenuItem});
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.generarToolStripMenuItem.Text = "Generar";
            // 
            // loteFactEmitidasToolStripMenuItem
            // 
            this.loteFactEmitidasToolStripMenuItem.Name = "loteFactEmitidasToolStripMenuItem";
            this.loteFactEmitidasToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.loteFactEmitidasToolStripMenuItem.Text = "Lote Fact. Emitidas";
            this.loteFactEmitidasToolStripMenuItem.Click += new System.EventHandler(this.loteFactEmitidasTSMI_Click);
            // 
            // loteFactRecibidasTSMI
            // 
            this.loteFactRecibidasTSMI.Name = "loteFactRecibidasTSMI";
            this.loteFactRecibidasTSMI.Size = new System.Drawing.Size(215, 26);
            this.loteFactRecibidasTSMI.Text = "Lote Fact. Recibidas";
            this.loteFactRecibidasTSMI.Click += new System.EventHandler(this.loteFactRecibidasTSMI_Click);
            // 
            // loteFactIntracomToolStripMenuItem
            // 
            this.loteFactIntracomToolStripMenuItem.Name = "loteFactIntracomToolStripMenuItem";
            this.loteFactIntracomToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.loteFactIntracomToolStripMenuItem.Text = "Lote Fact. Intracom.";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // configuraciónTSMI
            // 
            this.configuraciónTSMI.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.configuraciónTSMI.Name = "configuraciónTSMI";
            this.configuraciónTSMI.Size = new System.Drawing.Size(120, 25);
            this.configuraciónTSMI.Text = "Configuración";
            this.configuraciónTSMI.Click += new System.EventHandler(this.configuraciónTSMI_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(582, 236);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Principal - Envio SII";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traducirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ficherosDATTSMI;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loteFactEmitidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loteFactRecibidasTSMI;
        private System.Windows.Forms.ToolStripMenuItem loteFactIntracomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónTSMI;
    }
}