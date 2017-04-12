namespace Sample
{
    partial class frmLRCobrosEmitidasBatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLRCobrosEmitidasBatch));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContTop = new System.Windows.Forms.SplitContainer();
            this.pnParties = new System.Windows.Forms.Panel();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblNifInf = new System.Windows.Forms.Label();
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
            this.lbIndexlInf = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.txIssueDate = new System.Windows.Forms.TextBox();
            this.btAddFactura = new System.Windows.Forms.Button();
            this.lbIVA = new System.Windows.Forms.Label();
            this.grdCobros = new System.Windows.Forms.DataGridView();
            this.FechaCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedioCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbInvoiceNumber = new System.Windows.Forms.Label();
            this.txInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdInvoices = new System.Windows.Forms.DataGridView();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnViewXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSendXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.NumFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdCobros)).BeginInit();
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
            this.splitContTop.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContTop.Panel1.Controls.Add(this.pnParties);
            // 
            // splitContTop.Panel2
            // 
            this.splitContTop.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContTop.Panel2.Controls.Add(this.grpFactura);
            this.splitContTop.Size = new System.Drawing.Size(858, 223);
            this.splitContTop.SplitterDistance = 343;
            this.splitContTop.TabIndex = 0;
            // 
            // pnParties
            // 
            this.pnParties.BackColor = System.Drawing.Color.Silver;
            this.pnParties.Controls.Add(this.grpCliente);
            this.pnParties.Controls.Add(this.grpEmisor);
            this.pnParties.Location = new System.Drawing.Point(3, 15);
            this.pnParties.Name = "pnParties";
            this.pnParties.Size = new System.Drawing.Size(335, 208);
            this.pnParties.TabIndex = 3;
            // 
            // grpCliente
            // 
            this.grpCliente.BackColor = System.Drawing.Color.Silver;
            this.grpCliente.Controls.Add(this.lblNifInf);
            this.grpCliente.Controls.Add(this.lbClientePartyName);
            this.grpCliente.Controls.Add(this.lbClienteTaxIdentificationNumber);
            this.grpCliente.Controls.Add(this.txClientePartyName);
            this.grpCliente.Controls.Add(this.txClienteTaxIdentificationNumber);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.Location = new System.Drawing.Point(7, 101);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(314, 96);
            this.grpCliente.TabIndex = 2;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // lblNifInf
            // 
            this.lblNifInf.AutoSize = true;
            this.lblNifInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNifInf.ForeColor = System.Drawing.Color.Maroon;
            this.lblNifInf.Location = new System.Drawing.Point(185, 33);
            this.lblNifInf.Name = "lblNifInf";
            this.lblNifInf.Size = new System.Drawing.Size(0, 13);
            this.lblNifInf.TabIndex = 12;
            // 
            // lbClientePartyName
            // 
            this.lbClientePartyName.AutoSize = true;
            this.lbClientePartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientePartyName.Location = new System.Drawing.Point(11, 64);
            this.lbClientePartyName.Name = "lbClientePartyName";
            this.lbClientePartyName.Size = new System.Drawing.Size(44, 13);
            this.lbClientePartyName.TabIndex = 3;
            this.lbClientePartyName.Text = "Nombre";
            // 
            // lbClienteTaxIdentificationNumber
            // 
            this.lbClienteTaxIdentificationNumber.AutoSize = true;
            this.lbClienteTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClienteTaxIdentificationNumber.Location = new System.Drawing.Point(27, 33);
            this.lbClienteTaxIdentificationNumber.Name = "lbClienteTaxIdentificationNumber";
            this.lbClienteTaxIdentificationNumber.Size = new System.Drawing.Size(24, 13);
            this.lbClienteTaxIdentificationNumber.TabIndex = 2;
            this.lbClienteTaxIdentificationNumber.Text = "NIF";
            // 
            // txClientePartyName
            // 
            this.txClientePartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txClientePartyName.Location = new System.Drawing.Point(60, 61);
            this.txClientePartyName.Name = "txClientePartyName";
            this.txClientePartyName.Size = new System.Drawing.Size(240, 20);
            this.txClientePartyName.TabIndex = 3;
            this.txClientePartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txClienteTaxIdentificationNumber
            // 
            this.txClienteTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txClienteTaxIdentificationNumber.Location = new System.Drawing.Point(59, 30);
            this.txClienteTaxIdentificationNumber.Name = "txClienteTaxIdentificationNumber";
            this.txClienteTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txClienteTaxIdentificationNumber.TabIndex = 2;
            this.txClienteTaxIdentificationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.txClienteTaxIdentificationNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txClienteTaxIdentificationNumber_Validating);
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
            this.grpEmisor.Size = new System.Drawing.Size(314, 88);
            this.grpEmisor.TabIndex = 1;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Emisor factura";
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
            // grpFactura
            // 
            this.grpFactura.BackColor = System.Drawing.Color.Silver;
            this.grpFactura.Controls.Add(this.lbIndexlInf);
            this.grpFactura.Controls.Add(this.lbIssueDate);
            this.grpFactura.Controls.Add(this.txIssueDate);
            this.grpFactura.Controls.Add(this.btAddFactura);
            this.grpFactura.Controls.Add(this.lbIVA);
            this.grpFactura.Controls.Add(this.grdCobros);
            this.grpFactura.Controls.Add(this.lbInvoiceNumber);
            this.grpFactura.Controls.Add(this.txInvoiceNumber);
            this.grpFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFactura.Location = new System.Drawing.Point(6, 19);
            this.grpFactura.Name = "grpFactura";
            this.grpFactura.Size = new System.Drawing.Size(491, 185);
            this.grpFactura.TabIndex = 2;
            this.grpFactura.TabStop = false;
            this.grpFactura.Text = "Factura";
            // 
            // lbIndexlInf
            // 
            this.lbIndexlInf.AutoSize = true;
            this.lbIndexlInf.ForeColor = System.Drawing.Color.Maroon;
            this.lbIndexlInf.Location = new System.Drawing.Point(333, 34);
            this.lbIndexlInf.Name = "lbIndexlInf";
            this.lbIndexlInf.Size = new System.Drawing.Size(145, 16);
            this.lbIndexlInf.TabIndex = 11;
            this.lbIndexlInf.Text = "Editando nueva factura";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.Location = new System.Drawing.Point(154, 36);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(76, 13);
            this.lbIssueDate.TabIndex = 10;
            this.lbIssueDate.Text = "Fecha Factura";
            // 
            // txIssueDate
            // 
            this.txIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txIssueDate.Location = new System.Drawing.Point(236, 33);
            this.txIssueDate.Name = "txIssueDate";
            this.txIssueDate.Size = new System.Drawing.Size(68, 20);
            this.txIssueDate.TabIndex = 7;
            this.txIssueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btAddFactura
            // 
            this.btAddFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btAddFactura.Image = global::Sample.Properties.Resources.Ribbon_Save_32x32;
            this.btAddFactura.Location = new System.Drawing.Point(444, 139);
            this.btAddFactura.Name = "btAddFactura";
            this.btAddFactura.Size = new System.Drawing.Size(34, 34);
            this.btAddFactura.TabIndex = 8;
            this.btAddFactura.UseVisualStyleBackColor = true;
            this.btAddFactura.Click += new System.EventHandler(this.btAddFactura_Click);
            // 
            // lbIVA
            // 
            this.lbIVA.AutoSize = true;
            this.lbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIVA.Location = new System.Drawing.Point(11, 61);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Size = new System.Drawing.Size(79, 13);
            this.lbIVA.TabIndex = 7;
            this.lbIVA.Text = "Cobros Factura";
            // 
            // grdCobros
            // 
            this.grdCobros.BackgroundColor = System.Drawing.Color.Silver;
            this.grdCobros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCobros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaCobro,
            this.ImporteCobro,
            this.MedioCobro});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCobros.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdCobros.Location = new System.Drawing.Point(14, 81);
            this.grdCobros.Name = "grdCobros";
            this.grdCobros.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCobros.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdCobros.Size = new System.Drawing.Size(349, 92);
            this.grdCobros.TabIndex = 8;
            // 
            // FechaCobro
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaCobro.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaCobro.HeaderText = "Fecha";
            this.FechaCobro.Name = "FechaCobro";
            this.FechaCobro.Width = 90;
            // 
            // ImporteCobro
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.ImporteCobro.DefaultCellStyle = dataGridViewCellStyle2;
            this.ImporteCobro.HeaderText = "Importe";
            this.ImporteCobro.Name = "ImporteCobro";
            // 
            // MedioCobro
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.MedioCobro.DefaultCellStyle = dataGridViewCellStyle3;
            this.MedioCobro.HeaderText = "Medio";
            this.MedioCobro.Name = "MedioCobro";
            this.MedioCobro.Width = 120;
            // 
            // lbInvoiceNumber
            // 
            this.lbInvoiceNumber.AutoSize = true;
            this.lbInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvoiceNumber.Location = new System.Drawing.Point(11, 36);
            this.lbInvoiceNumber.Name = "lbInvoiceNumber";
            this.lbInvoiceNumber.Size = new System.Drawing.Size(44, 13);
            this.lbInvoiceNumber.TabIndex = 2;
            this.lbInvoiceNumber.Text = "Número";
            // 
            // txInvoiceNumber
            // 
            this.txInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInvoiceNumber.Location = new System.Drawing.Point(59, 33);
            this.txInvoiceNumber.Name = "txInvoiceNumber";
            this.txInvoiceNumber.Size = new System.Drawing.Size(80, 20);
            this.txInvoiceNumber.TabIndex = 4;
            this.txInvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
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
            this.invoice,
            this.Img,
            this.Error});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoices.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdInvoices.GridColor = System.Drawing.SystemColors.Control;
            this.grdInvoices.Location = new System.Drawing.Point(12, 46);
            this.grdInvoices.Name = "grdInvoices";
            this.grdInvoices.ReadOnly = true;
            this.grdInvoices.RowHeadersVisible = false;
            this.grdInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoices.Size = new System.Drawing.Size(832, 203);
            this.grdInvoices.TabIndex = 0;
            this.grdInvoices.SelectionChanged += new System.EventHandler(this.grdFacturas_SelectionChanged);
            this.grdInvoices.DoubleClick += new System.EventHandler(this.grdFacturas_DoubleClick);
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnViewXML,
            this.mnSendXML,
            this.mnLoad});
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
            this.mnViewXML.Size = new System.Drawing.Size(159, 25);
            this.mnViewXML.Text = "Ver mensaje XML";
            this.mnViewXML.Click += new System.EventHandler(this.mnViewXML_Click);
            // 
            // mnSendXML
            // 
            this.mnSendXML.Image = global::Sample.Properties.Resources.Mail_32x32;
            this.mnSendXML.Name = "mnSendXML";
            this.mnSendXML.Size = new System.Drawing.Size(155, 25);
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
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Archivos xml|*.xml";
            this.dlgOpen.InitialDirectory = "C:\\";
            this.dlgOpen.Title = "CARGAR XML LOTE COBROS DE FACTURAS EMITIDAS";
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
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.FechFra.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.Img.Image = global::Sample.Properties.Resources.Ribbon_New_32x32;
            this.Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            this.Img.Width = 32;
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            // 
            // frmLRCobrosEmitidasBatch
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
            this.Name = "frmLRCobrosEmitidasBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Generación/Envío Cobros de Factuas Emitidas";
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
            ((System.ComponentModel.ISupportInitialize)(this.grdCobros)).EndInit();
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
        private System.Windows.Forms.DataGridView grdCobros;
        private System.Windows.Forms.Label lbIVA;
        private System.Windows.Forms.Button btAddFactura;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.TextBox txIssueDate;
        private System.Windows.Forms.DataGridView grdInvoices;
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
        private System.Windows.Forms.ToolStripMenuItem mnLoad;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label lbIndexlInf;
        private System.Windows.Forms.Label lblNifInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedioCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
    }
}

