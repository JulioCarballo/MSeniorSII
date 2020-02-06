namespace MSeniorSII
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.txInbox = new System.Windows.Forms.TextBox();
            this.btInbox = new System.Windows.Forms.Button();
            this.lbInbox = new System.Windows.Forms.Label();
            this.lbOutbox = new System.Windows.Forms.Label();
            this.btOutbox = new System.Windows.Forms.Button();
            this.txOutbox = new System.Windows.Forms.TextBox();
            this.lbSerial = new System.Windows.Forms.Label();
            this.btSerial = new System.Windows.Forms.Button();
            this.txSerial = new System.Windows.Forms.TextBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.txVersion = new System.Windows.Forms.TextBox();
            this.fldBrw = new System.Windows.Forms.FolderBrowserDialog();
            this.lbSiiEndPointPrefix = new System.Windows.Forms.Label();
            this.txSiiEndPointPrefix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txInbox
            // 
            this.txInbox.Location = new System.Drawing.Point(12, 30);
            this.txInbox.Name = "txInbox";
            this.txInbox.Size = new System.Drawing.Size(365, 20);
            this.txInbox.TabIndex = 0;
            // 
            // btInbox
            // 
            this.btInbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInbox.Location = new System.Drawing.Point(383, 31);
            this.btInbox.Name = "btInbox";
            this.btInbox.Size = new System.Drawing.Size(30, 19);
            this.btInbox.TabIndex = 1;
            this.btInbox.Text = "...";
            this.btInbox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btInbox.UseVisualStyleBackColor = true;
            this.btInbox.Click += new System.EventHandler(this.btInbox_Click);
            // 
            // lbInbox
            // 
            this.lbInbox.AutoSize = true;
            this.lbInbox.Location = new System.Drawing.Point(12, 9);
            this.lbInbox.Name = "lbInbox";
            this.lbInbox.Size = new System.Drawing.Size(175, 13);
            this.lbInbox.TabIndex = 2;
            this.lbInbox.Text = "Carpeta Ficheros Respuesta AEAT:";
            // 
            // lbOutbox
            // 
            this.lbOutbox.AutoSize = true;
            this.lbOutbox.Location = new System.Drawing.Point(12, 61);
            this.lbOutbox.Name = "lbOutbox";
            this.lbOutbox.Size = new System.Drawing.Size(153, 13);
            this.lbOutbox.TabIndex = 5;
            this.lbOutbox.Text = "Carpeta Ficheros Envío AEAT:";
            // 
            // btOutbox
            // 
            this.btOutbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOutbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOutbox.Location = new System.Drawing.Point(383, 81);
            this.btOutbox.Name = "btOutbox";
            this.btOutbox.Size = new System.Drawing.Size(30, 19);
            this.btOutbox.TabIndex = 4;
            this.btOutbox.Text = "...";
            this.btOutbox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btOutbox.UseVisualStyleBackColor = true;
            this.btOutbox.Click += new System.EventHandler(this.btOutbox_Click);
            // 
            // txOutbox
            // 
            this.txOutbox.Location = new System.Drawing.Point(12, 82);
            this.txOutbox.Name = "txOutbox";
            this.txOutbox.Size = new System.Drawing.Size(365, 20);
            this.txOutbox.TabIndex = 3;
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Location = new System.Drawing.Point(9, 116);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(102, 13);
            this.lbSerial.TabIndex = 8;
            this.lbSerial.Text = "Nº Serie Certificado:";
            // 
            // btSerial
            // 
            this.btSerial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSerial.Location = new System.Drawing.Point(383, 116);
            this.btSerial.Name = "btSerial";
            this.btSerial.Size = new System.Drawing.Size(30, 19);
            this.btSerial.TabIndex = 7;
            this.btSerial.Text = "...";
            this.btSerial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSerial.UseVisualStyleBackColor = true;
            this.btSerial.Click += new System.EventHandler(this.btSerial_Click);
            // 
            // txSerial
            // 
            this.txSerial.Location = new System.Drawing.Point(112, 115);
            this.txSerial.Name = "txSerial";
            this.txSerial.Size = new System.Drawing.Size(265, 20);
            this.txSerial.TabIndex = 6;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(12, 151);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(64, 13);
            this.lbVersion.TabIndex = 10;
            this.lbVersion.Text = "Versión SII: ";
            // 
            // txVersion
            // 
            this.txVersion.Location = new System.Drawing.Point(15, 172);
            this.txVersion.Name = "txVersion";
            this.txVersion.Size = new System.Drawing.Size(58, 20);
            this.txVersion.TabIndex = 9;
            // 
            // lbSiiEndPointPrefix
            // 
            this.lbSiiEndPointPrefix.AutoSize = true;
            this.lbSiiEndPointPrefix.Location = new System.Drawing.Point(109, 151);
            this.lbSiiEndPointPrefix.Name = "lbSiiEndPointPrefix";
            this.lbSiiEndPointPrefix.Size = new System.Drawing.Size(82, 13);
            this.lbSiiEndPointPrefix.TabIndex = 14;
            this.lbSiiEndPointPrefix.Text = "Prefijo EndPoint";
            // 
            // txSiiEndPointPrefix
            // 
            this.txSiiEndPointPrefix.Location = new System.Drawing.Point(109, 172);
            this.txSiiEndPointPrefix.Name = "txSiiEndPointPrefix";
            this.txSiiEndPointPrefix.Size = new System.Drawing.Size(281, 20);
            this.txSiiEndPointPrefix.TabIndex = 13;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 232);
            this.Controls.Add(this.lbSiiEndPointPrefix);
            this.Controls.Add(this.txSiiEndPointPrefix);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.txVersion);
            this.Controls.Add(this.lbSerial);
            this.Controls.Add(this.btSerial);
            this.Controls.Add(this.txSerial);
            this.Controls.Add(this.lbOutbox);
            this.Controls.Add(this.btOutbox);
            this.Controls.Add(this.txOutbox);
            this.Controls.Add(this.lbInbox);
            this.Controls.Add(this.btInbox);
            this.Controls.Add(this.txInbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Configurar Aplicación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSettings_FormClosing);
            this.Load += new System.EventHandler(this.formSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txInbox;
        private System.Windows.Forms.Button btInbox;
        private System.Windows.Forms.Label lbInbox;
        private System.Windows.Forms.Label lbOutbox;
        private System.Windows.Forms.Button btOutbox;
        private System.Windows.Forms.TextBox txOutbox;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.Button btSerial;
        private System.Windows.Forms.TextBox txSerial;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.TextBox txVersion;
        private System.Windows.Forms.FolderBrowserDialog fldBrw;
        private System.Windows.Forms.Label lbSiiEndPointPrefix;
        private System.Windows.Forms.TextBox txSiiEndPointPrefix;
    }
}