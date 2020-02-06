namespace MSeniorSII
{
    partial class formLRPagosRecibidasQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLRPagosRecibidasQuery));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContTop = new System.Windows.Forms.SplitContainer();
            this.pnParties = new System.Windows.Forms.Panel();
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.lbEmisorPartyName = new System.Windows.Forms.Label();
            this.lbEmisorTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txBuyerPartyName = new System.Windows.Forms.TextBox();
            this.txBuyerTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.grpFactura = new System.Windows.Forms.GroupBox();
            this.txCountry = new System.Windows.Forms.TextBox();
            this.txAcreedorPartyName = new System.Windows.Forms.TextBox();
            this.lbClientePartyName = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.txIssueDate = new System.Windows.Forms.TextBox();
            this.btBuscaFact = new System.Windows.Forms.Button();
            this.lbClienteTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txAcreedorTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.lbInvoiceNumber = new System.Windows.Forms.Label();
            this.txInvoiceNumber = new System.Windows.Forms.TextBox();
            this.grdInvoices = new System.Windows.Forms.DataGridView();
            this.FechFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaMedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblNifInf = new System.Windows.Forms.Label();
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
            this.grpFactura.SuspendLayout();
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
            this.splitContMain.Panel2.Controls.Add(this.grdInvoices);
            this.splitContMain.Panel2.Controls.Add(this.label1);
            this.splitContMain.Size = new System.Drawing.Size(858, 506);
            this.splitContMain.SplitterDistance = 152;
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
            this.splitContTop.Panel2.Controls.Add(this.grpFactura);
            this.splitContTop.Size = new System.Drawing.Size(858, 152);
            this.splitContTop.SplitterDistance = 343;
            this.splitContTop.TabIndex = 0;
            // 
            // pnParties
            // 
            this.pnParties.BackColor = System.Drawing.Color.Silver;
            this.pnParties.Controls.Add(this.grpEmisor);
            this.pnParties.Location = new System.Drawing.Point(3, 15);
            this.pnParties.Name = "pnParties";
            this.pnParties.Size = new System.Drawing.Size(335, 134);
            this.pnParties.TabIndex = 3;
            // 
            // grpEmisor
            // 
            this.grpEmisor.BackColor = System.Drawing.Color.Silver;
            this.grpEmisor.Controls.Add(this.lbEmisorPartyName);
            this.grpEmisor.Controls.Add(this.lbEmisorTaxIdentificationNumber);
            this.grpEmisor.Controls.Add(this.txBuyerPartyName);
            this.grpEmisor.Controls.Add(this.txBuyerTaxIdentificationNumber);
            this.grpEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmisor.Location = new System.Drawing.Point(7, 4);
            this.grpEmisor.Name = "grpEmisor";
            this.grpEmisor.Size = new System.Drawing.Size(314, 120);
            this.grpEmisor.TabIndex = 1;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Receptor factura";
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
            // txBuyerPartyName
            // 
            this.txBuyerPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBuyerPartyName.Location = new System.Drawing.Point(60, 54);
            this.txBuyerPartyName.Name = "txBuyerPartyName";
            this.txBuyerPartyName.Size = new System.Drawing.Size(240, 20);
            this.txBuyerPartyName.TabIndex = 1;
            this.txBuyerPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txBuyerTaxIdentificationNumber
            // 
            this.txBuyerTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBuyerTaxIdentificationNumber.Location = new System.Drawing.Point(59, 26);
            this.txBuyerTaxIdentificationNumber.Name = "txBuyerTaxIdentificationNumber";
            this.txBuyerTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txBuyerTaxIdentificationNumber.TabIndex = 0;
            this.txBuyerTaxIdentificationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // grpFactura
            // 
            this.grpFactura.BackColor = System.Drawing.Color.Silver;
            this.grpFactura.Controls.Add(this.lblNifInf);
            this.grpFactura.Controls.Add(this.txCountry);
            this.grpFactura.Controls.Add(this.txAcreedorPartyName);
            this.grpFactura.Controls.Add(this.lbClientePartyName);
            this.grpFactura.Controls.Add(this.lbIssueDate);
            this.grpFactura.Controls.Add(this.txIssueDate);
            this.grpFactura.Controls.Add(this.btBuscaFact);
            this.grpFactura.Controls.Add(this.lbClienteTaxIdentificationNumber);
            this.grpFactura.Controls.Add(this.txAcreedorTaxIdentificationNumber);
            this.grpFactura.Controls.Add(this.lbInvoiceNumber);
            this.grpFactura.Controls.Add(this.txInvoiceNumber);
            this.grpFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFactura.Location = new System.Drawing.Point(6, 15);
            this.grpFactura.Name = "grpFactura";
            this.grpFactura.Size = new System.Drawing.Size(491, 124);
            this.grpFactura.TabIndex = 2;
            this.grpFactura.TabStop = false;
            this.grpFactura.Text = "Parámetros Búsqueda";
            // 
            // txCountry
            // 
            this.txCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCountry.Location = new System.Drawing.Point(187, 30);
            this.txCountry.Name = "txCountry";
            this.txCountry.ReadOnly = true;
            this.txCountry.Size = new System.Drawing.Size(34, 20);
            this.txCountry.TabIndex = 13;
            this.txCountry.Visible = false;
            // 
            // txAcreedorPartyName
            // 
            this.txAcreedorPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAcreedorPartyName.Location = new System.Drawing.Point(92, 58);
            this.txAcreedorPartyName.Name = "txAcreedorPartyName";
            this.txAcreedorPartyName.Size = new System.Drawing.Size(240, 20);
            this.txAcreedorPartyName.TabIndex = 3;
            this.txAcreedorPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lbClientePartyName
            // 
            this.lbClientePartyName.AutoSize = true;
            this.lbClientePartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientePartyName.Location = new System.Drawing.Point(16, 61);
            this.lbClientePartyName.Name = "lbClientePartyName";
            this.lbClientePartyName.Size = new System.Drawing.Size(75, 13);
            this.lbClientePartyName.TabIndex = 3;
            this.lbClientePartyName.Text = "Nom Acreedor";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.Location = new System.Drawing.Point(164, 92);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(76, 13);
            this.lbIssueDate.TabIndex = 10;
            this.lbIssueDate.Text = "Fecha Factura";
            // 
            // txIssueDate
            // 
            this.txIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txIssueDate.Location = new System.Drawing.Point(246, 89);
            this.txIssueDate.Name = "txIssueDate";
            this.txIssueDate.Size = new System.Drawing.Size(68, 20);
            this.txIssueDate.TabIndex = 7;
            this.txIssueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btBuscaFact
            // 
            this.btBuscaFact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscaFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscaFact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btBuscaFact.Image = global::MSeniorSII.Properties.Resources.Ribbon_Search_32x32;
            this.btBuscaFact.Location = new System.Drawing.Point(424, 79);
            this.btBuscaFact.Name = "btBuscaFact";
            this.btBuscaFact.Size = new System.Drawing.Size(34, 34);
            this.btBuscaFact.TabIndex = 8;
            this.btBuscaFact.UseVisualStyleBackColor = true;
            this.btBuscaFact.Click += new System.EventHandler(this.btBuscaFact_Click);
            // 
            // lbClienteTaxIdentificationNumber
            // 
            this.lbClienteTaxIdentificationNumber.AutoSize = true;
            this.lbClienteTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClienteTaxIdentificationNumber.Location = new System.Drawing.Point(16, 33);
            this.lbClienteTaxIdentificationNumber.Name = "lbClienteTaxIdentificationNumber";
            this.lbClienteTaxIdentificationNumber.Size = new System.Drawing.Size(70, 13);
            this.lbClienteTaxIdentificationNumber.TabIndex = 2;
            this.lbClienteTaxIdentificationNumber.Text = "NIF Acreedor";
            // 
            // txAcreedorTaxIdentificationNumber
            // 
            this.txAcreedorTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAcreedorTaxIdentificationNumber.Location = new System.Drawing.Point(92, 30);
            this.txAcreedorTaxIdentificationNumber.Name = "txAcreedorTaxIdentificationNumber";
            this.txAcreedorTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txAcreedorTaxIdentificationNumber.TabIndex = 2;
            this.txAcreedorTaxIdentificationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.txAcreedorTaxIdentificationNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txAcreedorTaxIdentificationNumber_Validating);
            // 
            // lbInvoiceNumber
            // 
            this.lbInvoiceNumber.AutoSize = true;
            this.lbInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvoiceNumber.Location = new System.Drawing.Point(16, 92);
            this.lbInvoiceNumber.Name = "lbInvoiceNumber";
            this.lbInvoiceNumber.Size = new System.Drawing.Size(44, 13);
            this.lbInvoiceNumber.TabIndex = 2;
            this.lbInvoiceNumber.Text = "Número";
            // 
            // txInvoiceNumber
            // 
            this.txInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInvoiceNumber.Location = new System.Drawing.Point(66, 89);
            this.txInvoiceNumber.Name = "txInvoiceNumber";
            this.txInvoiceNumber.Size = new System.Drawing.Size(80, 20);
            this.txInvoiceNumber.TabIndex = 4;
            this.txInvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // grdInvoices
            // 
            this.grdInvoices.AllowUserToAddRows = false;
            this.grdInvoices.AllowUserToDeleteRows = false;
            this.grdInvoices.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.grdInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechFra,
            this.Importe,
            this.Medio,
            this.CuentaMedio,
            this.invoice,
            this.Img,
            this.FechaReg});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdInvoices.GridColor = System.Drawing.SystemColors.Control;
            this.grdInvoices.Location = new System.Drawing.Point(152, 43);
            this.grdInvoices.Name = "grdInvoices";
            this.grdInvoices.ReadOnly = true;
            this.grdInvoices.RowHeadersVisible = false;
            this.grdInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoices.Size = new System.Drawing.Size(561, 203);
            this.grdInvoices.TabIndex = 2;
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
            // Medio
            // 
            this.Medio.HeaderText = "Medio";
            this.Medio.Name = "Medio";
            this.Medio.ReadOnly = true;
            this.Medio.Width = 120;
            // 
            // CuentaMedio
            // 
            this.CuentaMedio.HeaderText = "Cuenta/Medio";
            this.CuentaMedio.Name = "CuentaMedio";
            this.CuentaMedio.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pagos de la Factura Recibida enviada a la A.E.A.T.";
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSettings});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(858, 29);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
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
            this.dlgOpen.InitialDirectory = "C:\\";
            this.dlgOpen.Title = "CARGAR XML LOTE PAGOS FACTURAS RECIBIDAS";
            // 
            // lblNifInf
            // 
            this.lblNifInf.AutoSize = true;
            this.lblNifInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNifInf.ForeColor = System.Drawing.Color.Red;
            this.lblNifInf.Location = new System.Drawing.Point(240, 32);
            this.lblNifInf.Name = "lblNifInf";
            this.lblNifInf.Size = new System.Drawing.Size(0, 13);
            this.lblNifInf.TabIndex = 14;
            // 
            // formLRPagosRecibidasQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(858, 535);
            this.Controls.Add(this.splitContMain);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLRPagosRecibidasQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: EJEMPLO SII: CONSULTA PAGOS DE FACTURAS RECIBIDAS EN AEAT";
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
            this.grpFactura.ResumeLayout(false);
            this.grpFactura.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpFactura;
        private System.Windows.Forms.Label lbInvoiceNumber;
        private System.Windows.Forms.TextBox txInvoiceNumber;
        private System.Windows.Forms.Button btBuscaFact;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.TextBox txIssueDate;
        private System.Windows.Forms.Panel pnParties;
        private System.Windows.Forms.Label lbClientePartyName;
        private System.Windows.Forms.Label lbClienteTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txAcreedorPartyName;
        private System.Windows.Forms.TextBox txAcreedorTaxIdentificationNumber;
        private System.Windows.Forms.GroupBox grpEmisor;
        private System.Windows.Forms.Label lbEmisorPartyName;
        private System.Windows.Forms.Label lbEmisorTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txBuyerPartyName;
        private System.Windows.Forms.TextBox txBuyerTaxIdentificationNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.TextBox txCountry;
        private System.Windows.Forms.DataGridView grdInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaMedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaReg;
        private System.Windows.Forms.Label lblNifInf;
    }
}

