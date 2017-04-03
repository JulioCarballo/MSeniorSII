namespace Sample
{
    partial class formLREmitidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLREmitidas));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContTop = new System.Windows.Forms.SplitContainer();
            this.pnParties = new System.Windows.Forms.Panel();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lbClientePartyName = new System.Windows.Forms.Label();
            this.lbClienteTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txClientePartyName = new System.Windows.Forms.TextBox();
            this.txClienteTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.lbEmisorPartyName = new System.Windows.Forms.Label();
            this.lbEmisorTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txEmisorPartyName = new System.Windows.Forms.TextBox();
            this.txEmisorTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.grpFactura = new System.Windows.Forms.GroupBox();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.txIssueDate = new System.Windows.Forms.TextBox();
            this.btAddFactura = new System.Windows.Forms.Button();
            this.lbIVA = new System.Windows.Forms.Label();
            this.grdIva = new System.Windows.Forms.DataGridView();
            this.TaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxableBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbInvoiceText = new System.Windows.Forms.Label();
            this.txInvoiceText = new System.Windows.Forms.TextBox();
            this.lbGrossAmount = new System.Windows.Forms.Label();
            this.lbInvoiceNumber = new System.Windows.Forms.Label();
            this.txGrossAmount = new System.Windows.Forms.TextBox();
            this.txInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdFacturas = new System.Windows.Forms.DataGridView();
            this.NumFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnViewXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSendXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContTop)).BeginInit();
            this.splitContTop.Panel1.SuspendLayout();
            this.splitContTop.Panel2.SuspendLayout();
            this.splitContTop.SuspendLayout();
            this.pnParties.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpEmisor.SuspendLayout();
            this.grpFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturas)).BeginInit();
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
            this.splitContMain.Panel2.BackColor = System.Drawing.Color.Tan;
            this.splitContMain.Panel2.Controls.Add(this.label1);
            this.splitContMain.Panel2.Controls.Add(this.grdFacturas);
            this.splitContMain.Size = new System.Drawing.Size(858, 506);
            this.splitContMain.SplitterDistance = 223;
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
            this.splitContTop.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContTop.Panel1.Controls.Add(this.pnParties);
            // 
            // splitContTop.Panel2
            // 
            this.splitContTop.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContTop.Panel2.Controls.Add(this.grpFactura);
            this.splitContTop.Size = new System.Drawing.Size(858, 223);
            this.splitContTop.SplitterDistance = 343;
            this.splitContTop.TabIndex = 0;
            // 
            // pnParties
            // 
            this.pnParties.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnParties.Controls.Add(this.grpCliente);
            this.pnParties.Controls.Add(this.grpEmisor);
            this.pnParties.Location = new System.Drawing.Point(3, 15);
            this.pnParties.Name = "pnParties";
            this.pnParties.Size = new System.Drawing.Size(335, 208);
            this.pnParties.TabIndex = 3;
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lbClientePartyName);
            this.grpCliente.Controls.Add(this.lbClienteTaxIdentificationNumber);
            this.grpCliente.Controls.Add(this.txClientePartyName);
            this.grpCliente.Controls.Add(this.txClienteTaxIdentificationNumber);
            this.grpCliente.Location = new System.Drawing.Point(7, 93);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(314, 96);
            this.grpCliente.TabIndex = 2;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // lbClientePartyName
            // 
            this.lbClientePartyName.AutoSize = true;
            this.lbClientePartyName.Location = new System.Drawing.Point(11, 55);
            this.lbClientePartyName.Name = "lbClientePartyName";
            this.lbClientePartyName.Size = new System.Drawing.Size(44, 13);
            this.lbClientePartyName.TabIndex = 3;
            this.lbClientePartyName.Text = "Nombre";
            // 
            // lbClienteTaxIdentificationNumber
            // 
            this.lbClienteTaxIdentificationNumber.AutoSize = true;
            this.lbClienteTaxIdentificationNumber.Location = new System.Drawing.Point(27, 24);
            this.lbClienteTaxIdentificationNumber.Name = "lbClienteTaxIdentificationNumber";
            this.lbClienteTaxIdentificationNumber.Size = new System.Drawing.Size(24, 13);
            this.lbClienteTaxIdentificationNumber.TabIndex = 2;
            this.lbClienteTaxIdentificationNumber.Text = "NIF";
            // 
            // txClientePartyName
            // 
            this.txClientePartyName.Location = new System.Drawing.Point(60, 52);
            this.txClientePartyName.Name = "txClientePartyName";
            this.txClientePartyName.Size = new System.Drawing.Size(240, 20);
            this.txClientePartyName.TabIndex = 1;
            this.txClientePartyName.Text = "CLIENTE EMPRESA EJEMPLO SL";
            // 
            // txClienteTaxIdentificationNumber
            // 
            this.txClienteTaxIdentificationNumber.Location = new System.Drawing.Point(59, 21);
            this.txClienteTaxIdentificationNumber.Name = "txClienteTaxIdentificationNumber";
            this.txClienteTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txClienteTaxIdentificationNumber.TabIndex = 0;
            this.txClienteTaxIdentificationNumber.Text = "B44332211";
            // 
            // grpEmisor
            // 
            this.grpEmisor.Controls.Add(this.lbEmisorPartyName);
            this.grpEmisor.Controls.Add(this.lbEmisorTaxIdentificationNumber);
            this.grpEmisor.Controls.Add(this.txEmisorPartyName);
            this.grpEmisor.Controls.Add(this.txEmisorTaxIdentificationNumber);
            this.grpEmisor.Location = new System.Drawing.Point(7, 4);
            this.grpEmisor.Name = "grpEmisor";
            this.grpEmisor.Size = new System.Drawing.Size(314, 88);
            this.grpEmisor.TabIndex = 1;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Emisor factura";
            this.grpEmisor.Enter += new System.EventHandler(this.grpEmisor_Enter);
            // 
            // lbEmisorPartyName
            // 
            this.lbEmisorPartyName.AutoSize = true;
            this.lbEmisorPartyName.Location = new System.Drawing.Point(11, 53);
            this.lbEmisorPartyName.Name = "lbEmisorPartyName";
            this.lbEmisorPartyName.Size = new System.Drawing.Size(44, 13);
            this.lbEmisorPartyName.TabIndex = 3;
            this.lbEmisorPartyName.Text = "Nombre";
            // 
            // lbEmisorTaxIdentificationNumber
            // 
            this.lbEmisorTaxIdentificationNumber.AutoSize = true;
            this.lbEmisorTaxIdentificationNumber.Location = new System.Drawing.Point(27, 22);
            this.lbEmisorTaxIdentificationNumber.Name = "lbEmisorTaxIdentificationNumber";
            this.lbEmisorTaxIdentificationNumber.Size = new System.Drawing.Size(24, 13);
            this.lbEmisorTaxIdentificationNumber.TabIndex = 2;
            this.lbEmisorTaxIdentificationNumber.Text = "NIF";
            // 
            // txEmisorPartyName
            // 
            this.txEmisorPartyName.Location = new System.Drawing.Point(60, 50);
            this.txEmisorPartyName.Name = "txEmisorPartyName";
            this.txEmisorPartyName.Size = new System.Drawing.Size(240, 20);
            this.txEmisorPartyName.TabIndex = 1;
            this.txEmisorPartyName.Text = "TITULAR/EMISOR EMPRESA EJEMPLO SL";
            // 
            // txEmisorTaxIdentificationNumber
            // 
            this.txEmisorTaxIdentificationNumber.Location = new System.Drawing.Point(59, 19);
            this.txEmisorTaxIdentificationNumber.Name = "txEmisorTaxIdentificationNumber";
            this.txEmisorTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txEmisorTaxIdentificationNumber.TabIndex = 0;
            this.txEmisorTaxIdentificationNumber.Text = "B11223344";
            // 
            // grpFactura
            // 
            this.grpFactura.Controls.Add(this.lbIssueDate);
            this.grpFactura.Controls.Add(this.txIssueDate);
            this.grpFactura.Controls.Add(this.btAddFactura);
            this.grpFactura.Controls.Add(this.lbIVA);
            this.grpFactura.Controls.Add(this.grdIva);
            this.grpFactura.Controls.Add(this.lbInvoiceText);
            this.grpFactura.Controls.Add(this.txInvoiceText);
            this.grpFactura.Controls.Add(this.lbGrossAmount);
            this.grpFactura.Controls.Add(this.lbInvoiceNumber);
            this.grpFactura.Controls.Add(this.txGrossAmount);
            this.grpFactura.Controls.Add(this.txInvoiceNumber);
            this.grpFactura.Location = new System.Drawing.Point(6, 19);
            this.grpFactura.Name = "grpFactura";
            this.grpFactura.Size = new System.Drawing.Size(491, 185);
            this.grpFactura.TabIndex = 2;
            this.grpFactura.TabStop = false;
            this.grpFactura.Text = "Factura";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Location = new System.Drawing.Point(11, 102);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(37, 13);
            this.lbIssueDate.TabIndex = 10;
            this.lbIssueDate.Text = "Fecha";
            // 
            // txIssueDate
            // 
            this.txIssueDate.Location = new System.Drawing.Point(60, 99);
            this.txIssueDate.Name = "txIssueDate";
            this.txIssueDate.Size = new System.Drawing.Size(68, 20);
            this.txIssueDate.TabIndex = 9;
            this.txIssueDate.Text = "24/02/2017";
            // 
            // btAddFactura
            // 
            this.btAddFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btAddFactura.Location = new System.Drawing.Point(444, 139);
            this.btAddFactura.Name = "btAddFactura";
            this.btAddFactura.Size = new System.Drawing.Size(34, 34);
            this.btAddFactura.TabIndex = 8;
            this.btAddFactura.Text = "+";
            this.btAddFactura.UseVisualStyleBackColor = true;
            this.btAddFactura.Click += new System.EventHandler(this.btAddFactura_Click);
            // 
            // lbIVA
            // 
            this.lbIVA.AutoSize = true;
            this.lbIVA.Location = new System.Drawing.Point(203, 61);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Size = new System.Drawing.Size(60, 13);
            this.lbIVA.TabIndex = 7;
            this.lbIVA.Text = "Líneas IVA";
            // 
            // grdIva
            // 
            this.grdIva.AllowUserToAddRows = false;
            this.grdIva.AllowUserToDeleteRows = false;
            this.grdIva.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdIva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaxRate,
            this.TaxableBase,
            this.TaxAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdIva.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdIva.Location = new System.Drawing.Point(206, 79);
            this.grdIva.Name = "grdIva";
            this.grdIva.RowHeadersVisible = false;
            this.grdIva.Size = new System.Drawing.Size(209, 92);
            this.grdIva.TabIndex = 6;
            // 
            // TaxRate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.TaxRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.TaxRate.HeaderText = "Tipo";
            this.TaxRate.Name = "TaxRate";
            this.TaxRate.ReadOnly = true;
            this.TaxRate.Width = 40;
            // 
            // TaxableBase
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.TaxableBase.DefaultCellStyle = dataGridViewCellStyle2;
            this.TaxableBase.HeaderText = "Base";
            this.TaxableBase.Name = "TaxableBase";
            this.TaxableBase.Width = 90;
            // 
            // TaxAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TaxAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.TaxAmount.HeaderText = "Cuota";
            this.TaxAmount.Name = "TaxAmount";
            this.TaxAmount.Width = 70;
            // 
            // lbInvoiceText
            // 
            this.lbInvoiceText.AutoSize = true;
            this.lbInvoiceText.Location = new System.Drawing.Point(145, 36);
            this.lbInvoiceText.Name = "lbInvoiceText";
            this.lbInvoiceText.Size = new System.Drawing.Size(53, 13);
            this.lbInvoiceText.TabIndex = 5;
            this.lbInvoiceText.Text = "Concepto";
            // 
            // txInvoiceText
            // 
            this.txInvoiceText.Location = new System.Drawing.Point(199, 33);
            this.txInvoiceText.Name = "txInvoiceText";
            this.txInvoiceText.Size = new System.Drawing.Size(216, 20);
            this.txInvoiceText.TabIndex = 4;
            this.txInvoiceText.Text = "Servicios consultoria";
            // 
            // lbGrossAmount
            // 
            this.lbGrossAmount.AutoSize = true;
            this.lbGrossAmount.Location = new System.Drawing.Point(11, 67);
            this.lbGrossAmount.Name = "lbGrossAmount";
            this.lbGrossAmount.Size = new System.Drawing.Size(42, 13);
            this.lbGrossAmount.TabIndex = 3;
            this.lbGrossAmount.Text = "Importe";
            // 
            // lbInvoiceNumber
            // 
            this.lbInvoiceNumber.AutoSize = true;
            this.lbInvoiceNumber.Location = new System.Drawing.Point(11, 36);
            this.lbInvoiceNumber.Name = "lbInvoiceNumber";
            this.lbInvoiceNumber.Size = new System.Drawing.Size(44, 13);
            this.lbInvoiceNumber.TabIndex = 2;
            this.lbInvoiceNumber.Text = "Número";
            // 
            // txGrossAmount
            // 
            this.txGrossAmount.Location = new System.Drawing.Point(60, 64);
            this.txGrossAmount.Name = "txGrossAmount";
            this.txGrossAmount.Size = new System.Drawing.Size(93, 20);
            this.txGrossAmount.TabIndex = 1;
            this.txGrossAmount.Text = "231";
            this.txGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txInvoiceNumber
            // 
            this.txInvoiceNumber.Location = new System.Drawing.Point(59, 33);
            this.txInvoiceNumber.Name = "txInvoiceNumber";
            this.txInvoiceNumber.Size = new System.Drawing.Size(80, 20);
            this.txInvoiceNumber.TabIndex = 0;
            this.txInvoiceNumber.Text = "FR00001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturas incluidas en el lote";
            // 
            // grdFacturas
            // 
            this.grdFacturas.AllowUserToAddRows = false;
            this.grdFacturas.AllowUserToDeleteRows = false;
            this.grdFacturas.BackgroundColor = System.Drawing.Color.Tan;
            this.grdFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumFra,
            this.FechFra,
            this.NIF,
            this.Cliente,
            this.Importe});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFacturas.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdFacturas.GridColor = System.Drawing.SystemColors.Control;
            this.grdFacturas.Location = new System.Drawing.Point(40, 39);
            this.grdFacturas.Name = "grdFacturas";
            this.grdFacturas.ReadOnly = true;
            this.grdFacturas.RowHeadersVisible = false;
            this.grdFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFacturas.Size = new System.Drawing.Size(749, 203);
            this.grdFacturas.TabIndex = 0;
            // 
            // NumFra
            // 
            this.NumFra.HeaderText = "Núm. Fra.";
            this.NumFra.Name = "NumFra";
            this.NumFra.ReadOnly = true;
            this.NumFra.Width = 85;
            // 
            // FechFra
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.FechFra.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle6;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnViewXML,
            this.mnSendXML,
            this.mnLoad,
            this.mnSettings});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(858, 29);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
            // 
            // mnViewXML
            // 
            this.mnViewXML.Image = global::Sample.Properties.Resources.Ribbon_New_32x32;
            this.mnViewXML.Name = "mnViewXML";
            this.mnViewXML.Size = new System.Drawing.Size(158, 25);
            this.mnViewXML.Text = "Ver mensaje XML";
            this.mnViewXML.Click += new System.EventHandler(this.mnViewXML_Click);
            // 
            // mnSendXML
            // 
            this.mnSendXML.Image = global::Sample.Properties.Resources.Mail_32x32;
            this.mnSendXML.Name = "mnSendXML";
            this.mnSendXML.Size = new System.Drawing.Size(154, 25);
            this.mnSendXML.Text = "Enviar Lote AEAT";
            this.mnSendXML.Click += new System.EventHandler(this.mnSendXML_Click);
            // 
            // mnLoad
            // 
            this.mnLoad.Image = global::Sample.Properties.Resources.Ribbon_Open_32x32;
            this.mnLoad.Name = "mnLoad";
            this.mnLoad.Size = new System.Drawing.Size(120, 25);
            this.mnLoad.Text = "Cargar XML";
            this.mnLoad.Click += new System.EventHandler(this.mnLoad_Click);
            // 
            // mnSettings
            // 
            this.mnSettings.Image = global::Sample.Properties.Resources.tuerca;
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
            // formLREmitidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 535);
            this.Controls.Add(this.splitContMain);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLREmitidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: EJEMPLO SII: ENVÍO LOTE FACTURAS EMITIDAS";
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
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpEmisor.ResumeLayout(false);
            this.grpEmisor.PerformLayout();
            this.grpFactura.ResumeLayout(false);
            this.grpFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturas)).EndInit();
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
        private System.Windows.Forms.Label lbGrossAmount;
        private System.Windows.Forms.Label lbInvoiceNumber;
        private System.Windows.Forms.TextBox txGrossAmount;
        private System.Windows.Forms.TextBox txInvoiceNumber;
        private System.Windows.Forms.Label lbInvoiceText;
        private System.Windows.Forms.TextBox txInvoiceText;
        private System.Windows.Forms.DataGridView grdIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxableBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxAmount;
        private System.Windows.Forms.Label lbIVA;
        private System.Windows.Forms.Button btAddFactura;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.TextBox txIssueDate;
        private System.Windows.Forms.DataGridView grdFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.ToolStripMenuItem mnViewXML;
        private System.Windows.Forms.ToolStripMenuItem mnSendXML;
        private System.Windows.Forms.Panel pnParties;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lbClientePartyName;
        private System.Windows.Forms.Label lbClienteTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txClientePartyName;
        private System.Windows.Forms.TextBox txClienteTaxIdentificationNumber;
        private System.Windows.Forms.GroupBox grpEmisor;
        private System.Windows.Forms.Label lbEmisorPartyName;
        private System.Windows.Forms.Label lbEmisorTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txEmisorPartyName;
        private System.Windows.Forms.TextBox txEmisorTaxIdentificationNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.ToolStripMenuItem mnLoad;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

