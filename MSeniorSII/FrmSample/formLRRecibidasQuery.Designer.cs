﻿namespace MSeniorSII
{
    partial class formLRRecibidasQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLRRecibidasQuery));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContTop = new System.Windows.Forms.SplitContainer();
            this.pnParties = new System.Windows.Forms.Panel();
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.lbEmisorPartyName = new System.Windows.Forms.Label();
            this.lbEmisorTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txEmisorPartyName = new System.Windows.Forms.TextBox();
            this.txEmisorTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCountry = new System.Windows.Forms.Label();
            this.txNifBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txFechaBusqueda = new System.Windows.Forms.TextBox();
            this.btBuscaFacts = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txFactBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdInvoices = new System.Windows.Forms.DataGridView();
            this.NumFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltModif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnViewXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSendXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.txNomBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContTop)).BeginInit();
            this.splitContTop.Panel1.SuspendLayout();
            this.splitContTop.Panel2.SuspendLayout();
            this.splitContTop.SuspendLayout();
            this.pnParties.SuspendLayout();
            this.grpEmisor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).BeginInit();
            this.mnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContMain
            // 
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.Location = new System.Drawing.Point(0, 29);
            this.splitContMain.Name = "splitContMain";
            this.splitContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContMain.Panel1
            // 
            this.splitContMain.Panel1.Controls.Add(this.splitContTop);
            // 
            // splitContMain.Panel2
            // 
            this.splitContMain.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContMain.Panel2.Controls.Add(this.label1);
            this.splitContMain.Panel2.Controls.Add(this.grdInvoices);
            this.splitContMain.Size = new System.Drawing.Size(944, 437);
            this.splitContMain.SplitterDistance = 113;
            this.splitContMain.TabIndex = 0;
            // 
            // splitContTop
            // 
            this.splitContTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContTop.Location = new System.Drawing.Point(0, 0);
            this.splitContTop.Name = "splitContTop";
            // 
            // splitContTop.Panel1
            // 
            this.splitContTop.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContTop.Panel1.Controls.Add(this.pnParties);
            // 
            // splitContTop.Panel2
            // 
            this.splitContTop.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContTop.Panel2.Controls.Add(this.groupBox1);
            this.splitContTop.Size = new System.Drawing.Size(944, 113);
            this.splitContTop.SplitterDistance = 430;
            this.splitContTop.TabIndex = 0;
            // 
            // pnParties
            // 
            this.pnParties.BackColor = System.Drawing.Color.Silver;
            this.pnParties.Controls.Add(this.grpEmisor);
            this.pnParties.Location = new System.Drawing.Point(3, 4);
            this.pnParties.Name = "pnParties";
            this.pnParties.Size = new System.Drawing.Size(424, 113);
            this.pnParties.TabIndex = 3;
            // 
            // grpEmisor
            // 
            this.grpEmisor.BackColor = System.Drawing.Color.Silver;
            this.grpEmisor.Controls.Add(this.lbEmisorPartyName);
            this.grpEmisor.Controls.Add(this.lbEmisorTaxIdentificationNumber);
            this.grpEmisor.Controls.Add(this.txEmisorPartyName);
            this.grpEmisor.Controls.Add(this.txEmisorTaxIdentificationNumber);
            this.grpEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmisor.Location = new System.Drawing.Point(7, 4);
            this.grpEmisor.Name = "grpEmisor";
            this.grpEmisor.Size = new System.Drawing.Size(414, 102);
            this.grpEmisor.TabIndex = 1;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Titular";
            this.grpEmisor.Enter += new System.EventHandler(this.grpEmisor_Enter);
            // 
            // lbEmisorPartyName
            // 
            this.lbEmisorPartyName.AutoSize = true;
            this.lbEmisorPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmisorPartyName.Location = new System.Drawing.Point(11, 57);
            this.lbEmisorPartyName.Name = "lbEmisorPartyName";
            this.lbEmisorPartyName.Size = new System.Drawing.Size(44, 13);
            this.lbEmisorPartyName.TabIndex = 3;
            this.lbEmisorPartyName.Text = "Nombre";
            // 
            // lbEmisorTaxIdentificationNumber
            // 
            this.lbEmisorTaxIdentificationNumber.AutoSize = true;
            this.lbEmisorTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmisorTaxIdentificationNumber.Location = new System.Drawing.Point(27, 29);
            this.lbEmisorTaxIdentificationNumber.Name = "lbEmisorTaxIdentificationNumber";
            this.lbEmisorTaxIdentificationNumber.Size = new System.Drawing.Size(24, 13);
            this.lbEmisorTaxIdentificationNumber.TabIndex = 2;
            this.lbEmisorTaxIdentificationNumber.Text = "NIF";
            // 
            // txEmisorPartyName
            // 
            this.txEmisorPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txEmisorPartyName.Location = new System.Drawing.Point(60, 54);
            this.txEmisorPartyName.Name = "txEmisorPartyName";
            this.txEmisorPartyName.Size = new System.Drawing.Size(240, 20);
            this.txEmisorPartyName.TabIndex = 1;
            this.txEmisorPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txEmisorTaxIdentificationNumber
            // 
            this.txEmisorTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txEmisorTaxIdentificationNumber.Location = new System.Drawing.Point(59, 26);
            this.txEmisorTaxIdentificationNumber.Name = "txEmisorTaxIdentificationNumber";
            this.txEmisorTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txEmisorTaxIdentificationNumber.TabIndex = 0;
            this.txEmisorTaxIdentificationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.txNomBusqueda);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbCountry);
            this.groupBox1.Controls.Add(this.txNifBusqueda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txFechaBusqueda);
            this.groupBox1.Controls.Add(this.btBuscaFacts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txFactBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros Búsqueda";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbCountry.Location = new System.Drawing.Point(174, 60);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(0, 13);
            this.lbCountry.TabIndex = 11;
            // 
            // txNifBusqueda
            // 
            this.txNifBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNifBusqueda.Location = new System.Drawing.Point(88, 58);
            this.txNifBusqueda.Name = "txNifBusqueda";
            this.txNifBusqueda.Size = new System.Drawing.Size(80, 20);
            this.txNifBusqueda.TabIndex = 4;
            this.txNifBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.txNifBusqueda.Validating += new System.ComponentModel.CancelEventHandler(this.txNifBusqueda_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "NIF Acreedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha Factura";
            // 
            // txFechaBusqueda
            // 
            this.txFechaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFechaBusqueda.Location = new System.Drawing.Point(88, 26);
            this.txFechaBusqueda.Name = "txFechaBusqueda";
            this.txFechaBusqueda.Size = new System.Drawing.Size(68, 20);
            this.txFechaBusqueda.TabIndex = 2;
            // 
            // btBuscaFacts
            // 
            this.btBuscaFacts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscaFacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscaFacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btBuscaFacts.Image = global::MSeniorSII.Properties.Resources.Ribbon_Search_32x32;
            this.btBuscaFacts.Location = new System.Drawing.Point(450, 60);
            this.btBuscaFacts.Name = "btBuscaFacts";
            this.btBuscaFacts.Size = new System.Drawing.Size(34, 34);
            this.btBuscaFacts.TabIndex = 8;
            this.btBuscaFacts.UseVisualStyleBackColor = true;
            this.btBuscaFacts.Click += new System.EventHandler(this.btBuscaFacts_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nº Factura";
            // 
            // txFactBusqueda
            // 
            this.txFactBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFactBusqueda.Location = new System.Drawing.Point(290, 57);
            this.txFactBusqueda.Name = "txFactBusqueda";
            this.txFactBusqueda.Size = new System.Drawing.Size(80, 20);
            this.txFactBusqueda.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturas enviadas a la A.E.A.T.";
            // 
            // grdInvoices
            // 
            this.grdInvoices.AllowUserToAddRows = false;
            this.grdInvoices.AllowUserToDeleteRows = false;
            this.grdInvoices.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.grdInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumFra,
            this.FechFra,
            this.NIF,
            this.Cliente,
            this.Importe,
            this.invoice,
            this.Img,
            this.FechaReg,
            this.UltModif});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdInvoices.GridColor = System.Drawing.SystemColors.Control;
            this.grdInvoices.Location = new System.Drawing.Point(10, 39);
            this.grdInvoices.Name = "grdInvoices";
            this.grdInvoices.ReadOnly = true;
            this.grdInvoices.RowHeadersVisible = false;
            this.grdInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoices.Size = new System.Drawing.Size(892, 203);
            this.grdInvoices.TabIndex = 0;
            // 
            // NumFra
            // 
            this.NumFra.HeaderText = "Núm. Fra.";
            this.NumFra.Name = "NumFra";
            this.NumFra.ReadOnly = true;
            this.NumFra.Width = 120;
            // 
            // FechFra
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechFra.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechFra.HeaderText = "Fecha";
            this.FechFra.Name = "FechFra";
            this.FechFra.ReadOnly = true;
            this.FechFra.Width = 85;
            // 
            // NIF
            // 
            this.NIF.HeaderText = "NIF";
            this.NIF.Name = "NIF";
            this.NIF.ReadOnly = true;
            this.NIF.Width = 90;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Nombre";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 250;
            // 
            // Importe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // invoice
            // 
            this.invoice.HeaderText = "invoice";
            this.invoice.Name = "invoice";
            this.invoice.ReadOnly = true;
            this.invoice.Visible = false;
            // 
            // Img
            // 
            this.Img.HeaderText = "";
            this.Img.Image = global::MSeniorSII.Properties.Resources.Ribbon_New_32x32;
            this.Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            this.Img.Width = 32;
            // 
            // FechaReg
            // 
            this.FechaReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaReg.HeaderText = "Fecha Reg.";
            this.FechaReg.Name = "FechaReg";
            this.FechaReg.ReadOnly = true;
            this.FechaReg.Width = 88;
            // 
            // UltModif
            // 
            this.UltModif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UltModif.HeaderText = "Ult. Modif.";
            this.UltModif.Name = "UltModif";
            this.UltModif.ReadOnly = true;
            this.UltModif.Width = 80;
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnViewXML,
            this.mnSendXML,
            this.mnSettings});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(944, 29);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
            // 
            // mnViewXML
            // 
            this.mnViewXML.Image = global::MSeniorSII.Properties.Resources.Ribbon_New_32x32;
            this.mnViewXML.Name = "mnViewXML";
            this.mnViewXML.Size = new System.Drawing.Size(162, 25);
            this.mnViewXML.Text = "Generar XML Baja";
            this.mnViewXML.Click += new System.EventHandler(this.mnViewXML_Click);
            // 
            // mnSendXML
            // 
            this.mnSendXML.Image = global::MSeniorSII.Properties.Resources.Mail_32x32;
            this.mnSendXML.Name = "mnSendXML";
            this.mnSendXML.Size = new System.Drawing.Size(188, 25);
            this.mnSendXML.Text = "Enviar Lote Baja AEAT";
            this.mnSendXML.Click += new System.EventHandler(this.mnSendXML_Click);
            // 
            // mnSettings
            // 
            this.mnSettings.Image = global::MSeniorSII.Properties.Resources.tuerca;
            this.mnSettings.Name = "mnSettings";
            this.mnSettings.Size = new System.Drawing.Size(136, 25);
            this.mnSettings.Text = "Configuración";
            this.mnSettings.Click += new System.EventHandler(this.mnSettings_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Archivos xml|*.xml";
            this.dlgOpen.Title = "CARGAR XML LOTE FACTURAS EMITIDAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(174, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre Acreedor";
            // 
            // txNomBusqueda
            // 
            this.txNomBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txNomBusqueda.Location = new System.Drawing.Point(270, 24);
            this.txNomBusqueda.Name = "txNomBusqueda";
            this.txNomBusqueda.Size = new System.Drawing.Size(225, 20);
            this.txNomBusqueda.TabIndex = 3;
            // 
            // formLRRecibidasQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(944, 466);
            this.Controls.Add(this.splitContMain);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLRRecibidasQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: EJEMPLO SII: CONSULTA FACTURAS RECIBIDAS EN AEAT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel2.ResumeLayout(false);
            this.splitContMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.splitContTop.Panel1.ResumeLayout(false);
            this.splitContTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContTop)).EndInit();
            this.splitContTop.ResumeLayout(false);
            this.pnParties.ResumeLayout(false);
            this.grpEmisor.ResumeLayout(false);
            this.grpEmisor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).EndInit();
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContMain;
        private System.Windows.Forms.SplitContainer splitContTop;
        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.DataGridView grdInvoices;
        private System.Windows.Forms.ToolStripMenuItem mnViewXML;
        private System.Windows.Forms.ToolStripMenuItem mnSendXML;
        private System.Windows.Forms.GroupBox grpEmisor;
        private System.Windows.Forms.Label lbEmisorPartyName;
        private System.Windows.Forms.Label lbEmisorTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txEmisorPartyName;
        private System.Windows.Forms.TextBox txEmisorTaxIdentificationNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Panel pnParties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txNifBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txFechaBusqueda;
        private System.Windows.Forms.Button btBuscaFacts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txFactBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltModif;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txNomBusqueda;
    }
}

