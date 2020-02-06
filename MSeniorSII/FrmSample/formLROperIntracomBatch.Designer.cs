namespace MSeniorSII
{
    partial class formLROperIntracomBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLROperIntracomBatch));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContTop = new System.Windows.Forms.SplitContainer();
            this.pnParties = new System.Windows.Forms.Panel();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.txCountry = new System.Windows.Forms.TextBox();
            this.lblNifInf = new System.Windows.Forms.Label();
            this.lbClientePartyName = new System.Windows.Forms.Label();
            this.lbClienteTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txAcreedorPartyName = new System.Windows.Forms.TextBox();
            this.txAcreedorTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.lbEmisorPartyName = new System.Windows.Forms.Label();
            this.lbEmisorTaxIdentificationNumber = new System.Windows.Forms.Label();
            this.txBuyerPartyName = new System.Windows.Forms.TextBox();
            this.txBuyerTaxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.grpFactura = new System.Windows.Forms.GroupBox();
            this.txDescripcionBienes = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txClaveDeclarado = new System.Windows.Forms.TextBox();
            this.txTipoOperacion = new System.Windows.Forms.TextBox();
            this.lbClaveDeclarado = new System.Windows.Forms.Label();
            this.lbTipoOperacion = new System.Windows.Forms.Label();
            this.txEstadoUE = new System.Windows.Forms.TextBox();
            this.lbEstadoUE = new System.Windows.Forms.Label();
            this.lbIndexlInf = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.txIssueDate = new System.Windows.Forms.TextBox();
            this.btAddFactura = new System.Windows.Forms.Button();
            this.lbDireccionOper = new System.Windows.Forms.Label();
            this.txDirOperador = new System.Windows.Forms.TextBox();
            this.lbInvoiceNumber = new System.Windows.Forms.Label();
            this.txInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdInvoices = new System.Windows.Forms.DataGridView();
            this.NumFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechFra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnViewXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSendXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.cbEsEmisor = new System.Windows.Forms.CheckBox();
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
            this.grpCliente.Controls.Add(this.cbEsEmisor);
            this.grpCliente.Controls.Add(this.txCountry);
            this.grpCliente.Controls.Add(this.lblNifInf);
            this.grpCliente.Controls.Add(this.lbClientePartyName);
            this.grpCliente.Controls.Add(this.lbClienteTaxIdentificationNumber);
            this.grpCliente.Controls.Add(this.txAcreedorPartyName);
            this.grpCliente.Controls.Add(this.txAcreedorTaxIdentificationNumber);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.Location = new System.Drawing.Point(7, 101);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(314, 96);
            this.grpCliente.TabIndex = 2;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente / Acreedor";
            // 
            // txCountry
            // 
            this.txCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCountry.Location = new System.Drawing.Point(143, 41);
            this.txCountry.Name = "txCountry";
            this.txCountry.ReadOnly = true;
            this.txCountry.Size = new System.Drawing.Size(34, 20);
            this.txCountry.TabIndex = 13;
            this.txCountry.Visible = false;
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
            this.lbClientePartyName.Location = new System.Drawing.Point(11, 73);
            this.lbClientePartyName.Name = "lbClientePartyName";
            this.lbClientePartyName.Size = new System.Drawing.Size(44, 13);
            this.lbClientePartyName.TabIndex = 3;
            this.lbClientePartyName.Text = "Nombre";
            // 
            // lbClienteTaxIdentificationNumber
            // 
            this.lbClienteTaxIdentificationNumber.AutoSize = true;
            this.lbClienteTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClienteTaxIdentificationNumber.Location = new System.Drawing.Point(27, 48);
            this.lbClienteTaxIdentificationNumber.Name = "lbClienteTaxIdentificationNumber";
            this.lbClienteTaxIdentificationNumber.Size = new System.Drawing.Size(24, 13);
            this.lbClienteTaxIdentificationNumber.TabIndex = 2;
            this.lbClienteTaxIdentificationNumber.Text = "NIF";
            // 
            // txAcreedorPartyName
            // 
            this.txAcreedorPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAcreedorPartyName.Location = new System.Drawing.Point(60, 70);
            this.txAcreedorPartyName.Name = "txAcreedorPartyName";
            this.txAcreedorPartyName.Size = new System.Drawing.Size(240, 20);
            this.txAcreedorPartyName.TabIndex = 3;
            this.txAcreedorPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txAcreedorTaxIdentificationNumber
            // 
            this.txAcreedorTaxIdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAcreedorTaxIdentificationNumber.Location = new System.Drawing.Point(57, 41);
            this.txAcreedorTaxIdentificationNumber.Name = "txAcreedorTaxIdentificationNumber";
            this.txAcreedorTaxIdentificationNumber.Size = new System.Drawing.Size(80, 20);
            this.txAcreedorTaxIdentificationNumber.TabIndex = 2;
            this.txAcreedorTaxIdentificationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.txAcreedorTaxIdentificationNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txAcreedorTaxIdentificationNumber_Validating);
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
            this.grpEmisor.Size = new System.Drawing.Size(314, 88);
            this.grpEmisor.TabIndex = 1;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Titular Lote";
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
            this.grpFactura.Controls.Add(this.txDescripcionBienes);
            this.grpFactura.Controls.Add(this.lbDescripcion);
            this.grpFactura.Controls.Add(this.txClaveDeclarado);
            this.grpFactura.Controls.Add(this.txTipoOperacion);
            this.grpFactura.Controls.Add(this.lbClaveDeclarado);
            this.grpFactura.Controls.Add(this.lbTipoOperacion);
            this.grpFactura.Controls.Add(this.txEstadoUE);
            this.grpFactura.Controls.Add(this.lbEstadoUE);
            this.grpFactura.Controls.Add(this.lbIndexlInf);
            this.grpFactura.Controls.Add(this.lbIssueDate);
            this.grpFactura.Controls.Add(this.txIssueDate);
            this.grpFactura.Controls.Add(this.btAddFactura);
            this.grpFactura.Controls.Add(this.lbDireccionOper);
            this.grpFactura.Controls.Add(this.txDirOperador);
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
            // txDescripcionBienes
            // 
            this.txDescripcionBienes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDescripcionBienes.Location = new System.Drawing.Point(116, 84);
            this.txDescripcionBienes.Name = "txDescripcionBienes";
            this.txDescripcionBienes.Size = new System.Drawing.Size(320, 20);
            this.txDescripcionBienes.TabIndex = 9;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion.Location = new System.Drawing.Point(13, 87);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(98, 13);
            this.lbDescripcion.TabIndex = 18;
            this.lbDescripcion.Text = "Descripción Bienes";
            // 
            // txClaveDeclarado
            // 
            this.txClaveDeclarado.Location = new System.Drawing.Point(238, 52);
            this.txClaveDeclarado.Name = "txClaveDeclarado";
            this.txClaveDeclarado.Size = new System.Drawing.Size(37, 22);
            this.txClaveDeclarado.TabIndex = 7;
            this.txClaveDeclarado.Enter += new System.EventHandler(this.txClaveDeclarado_Enter);
            // 
            // txTipoOperacion
            // 
            this.txTipoOperacion.Location = new System.Drawing.Point(98, 52);
            this.txTipoOperacion.Name = "txTipoOperacion";
            this.txTipoOperacion.Size = new System.Drawing.Size(42, 22);
            this.txTipoOperacion.TabIndex = 6;
            this.txTipoOperacion.Enter += new System.EventHandler(this.txTipoOperacion_Enter);
            // 
            // lbClaveDeclarado
            // 
            this.lbClaveDeclarado.AutoSize = true;
            this.lbClaveDeclarado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbClaveDeclarado.Location = new System.Drawing.Point(146, 57);
            this.lbClaveDeclarado.Name = "lbClaveDeclarado";
            this.lbClaveDeclarado.Size = new System.Drawing.Size(86, 13);
            this.lbClaveDeclarado.TabIndex = 15;
            this.lbClaveDeclarado.Text = "Clave Declarado";
            // 
            // lbTipoOperacion
            // 
            this.lbTipoOperacion.AutoSize = true;
            this.lbTipoOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbTipoOperacion.Location = new System.Drawing.Point(12, 57);
            this.lbTipoOperacion.Name = "lbTipoOperacion";
            this.lbTipoOperacion.Size = new System.Drawing.Size(80, 13);
            this.lbTipoOperacion.TabIndex = 14;
            this.lbTipoOperacion.Text = "Tipo Operación";
            // 
            // txEstadoUE
            // 
            this.txEstadoUE.Location = new System.Drawing.Point(380, 52);
            this.txEstadoUE.Name = "txEstadoUE";
            this.txEstadoUE.Size = new System.Drawing.Size(42, 22);
            this.txEstadoUE.TabIndex = 8;
            this.txEstadoUE.Enter += new System.EventHandler(this.txEstadoUE_Enter);
            // 
            // lbEstadoUE
            // 
            this.lbEstadoUE.AutoSize = true;
            this.lbEstadoUE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoUE.Location = new System.Drawing.Point(291, 57);
            this.lbEstadoUE.Name = "lbEstadoUE";
            this.lbEstadoUE.Size = new System.Drawing.Size(83, 13);
            this.lbEstadoUE.TabIndex = 12;
            this.lbEstadoUE.Text = "Estado Miembro";
            // 
            // lbIndexlInf
            // 
            this.lbIndexlInf.AutoSize = true;
            this.lbIndexlInf.ForeColor = System.Drawing.Color.Maroon;
            this.lbIndexlInf.Location = new System.Drawing.Point(20, 156);
            this.lbIndexlInf.Name = "lbIndexlInf";
            this.lbIndexlInf.Size = new System.Drawing.Size(145, 16);
            this.lbIndexlInf.TabIndex = 11;
            this.lbIndexlInf.Text = "Editando nueva factura";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.Location = new System.Drawing.Point(212, 29);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(37, 13);
            this.lbIssueDate.TabIndex = 10;
            this.lbIssueDate.Text = "Fecha";
            // 
            // txIssueDate
            // 
            this.txIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txIssueDate.Location = new System.Drawing.Point(255, 26);
            this.txIssueDate.Name = "txIssueDate";
            this.txIssueDate.Size = new System.Drawing.Size(68, 20);
            this.txIssueDate.TabIndex = 5;
            this.txIssueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btAddFactura
            // 
            this.btAddFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btAddFactura.Image = global::MSeniorSII.Properties.Resources.Ribbon_Save_32x32;
            this.btAddFactura.Location = new System.Drawing.Point(449, 145);
            this.btAddFactura.Name = "btAddFactura";
            this.btAddFactura.Size = new System.Drawing.Size(29, 28);
            this.btAddFactura.TabIndex = 11;
            this.btAddFactura.UseVisualStyleBackColor = true;
            this.btAddFactura.Click += new System.EventHandler(this.btAddFactura_Click);
            // 
            // lbDireccionOper
            // 
            this.lbDireccionOper.AutoSize = true;
            this.lbDireccionOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDireccionOper.Location = new System.Drawing.Point(13, 113);
            this.lbDireccionOper.Name = "lbDireccionOper";
            this.lbDireccionOper.Size = new System.Drawing.Size(99, 13);
            this.lbDireccionOper.TabIndex = 5;
            this.lbDireccionOper.Text = "Dirección Operador";
            // 
            // txDirOperador
            // 
            this.txDirOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDirOperador.Location = new System.Drawing.Point(116, 110);
            this.txDirOperador.Name = "txDirOperador";
            this.txDirOperador.Size = new System.Drawing.Size(319, 20);
            this.txDirOperador.TabIndex = 10;
            this.txDirOperador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lbInvoiceNumber
            // 
            this.lbInvoiceNumber.AutoSize = true;
            this.lbInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvoiceNumber.Location = new System.Drawing.Point(12, 29);
            this.lbInvoiceNumber.Name = "lbInvoiceNumber";
            this.lbInvoiceNumber.Size = new System.Drawing.Size(44, 13);
            this.lbInvoiceNumber.TabIndex = 2;
            this.lbInvoiceNumber.Text = "Número";
            // 
            // txInvoiceNumber
            // 
            this.txInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInvoiceNumber.Location = new System.Drawing.Point(62, 26);
            this.txInvoiceNumber.Name = "txInvoiceNumber";
            this.txInvoiceNumber.Size = new System.Drawing.Size(135, 20);
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
            this.TipoOper,
            this.Estado,
            this.invoice,
            this.Img});
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
            this.grdInvoices.Size = new System.Drawing.Size(834, 203);
            this.grdInvoices.TabIndex = 0;
            this.grdInvoices.SelectionChanged += new System.EventHandler(this.grdFacturas_SelectionChanged);
            this.grdInvoices.DoubleClick += new System.EventHandler(this.grdFacturas_DoubleClick);
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
            // TipoOper
            // 
            this.TipoOper.HeaderText = "Oper";
            this.TipoOper.Name = "TipoOper";
            this.TipoOper.ReadOnly = true;
            // 
            // Estado
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Estado.DefaultCellStyle = dataGridViewCellStyle2;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
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
            this.mnViewXML.Image = global::MSeniorSII.Properties.Resources.Ribbon_New_32x32;
            this.mnViewXML.Name = "mnViewXML";
            this.mnViewXML.Size = new System.Drawing.Size(159, 25);
            this.mnViewXML.Text = "Ver mensaje XML";
            this.mnViewXML.Click += new System.EventHandler(this.mnViewXML_Click);
            // 
            // mnSendXML
            // 
            this.mnSendXML.Image = global::MSeniorSII.Properties.Resources.Mail_32x32;
            this.mnSendXML.Name = "mnSendXML";
            this.mnSendXML.Size = new System.Drawing.Size(155, 25);
            this.mnSendXML.Text = "Enviar Lote AEAT";
            this.mnSendXML.Click += new System.EventHandler(this.mnSendXML_Click);
            // 
            // mnLoad
            // 
            this.mnLoad.Image = global::MSeniorSII.Properties.Resources.Ribbon_Open_32x32;
            this.mnLoad.Name = "mnLoad";
            this.mnLoad.Size = new System.Drawing.Size(120, 25);
            this.mnLoad.Text = "Cargar XML";
            this.mnLoad.Click += new System.EventHandler(this.mnLoad_Click);
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
            // cbEsEmisor
            // 
            this.cbEsEmisor.AutoSize = true;
            this.cbEsEmisor.Location = new System.Drawing.Point(220, 9);
            this.cbEsEmisor.Name = "cbEsEmisor";
            this.cbEsEmisor.Size = new System.Drawing.Size(88, 20);
            this.cbEsEmisor.TabIndex = 4;
            this.cbEsEmisor.Text = "Es Emisor";
            this.cbEsEmisor.UseVisualStyleBackColor = true;
            // 
            // formLROperIntracomBatch
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
            this.Name = "formLROperIntracomBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: EJEMPLO SII: ENVÍO LOTE OPERACIONES INTRACOMUNITARIAS";
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
        private System.Windows.Forms.Label lbDireccionOper;
        private System.Windows.Forms.TextBox txDirOperador;
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
        private System.Windows.Forms.TextBox txAcreedorPartyName;
        private System.Windows.Forms.TextBox txAcreedorTaxIdentificationNumber;
        private System.Windows.Forms.GroupBox grpEmisor;
        private System.Windows.Forms.Label lbEmisorPartyName;
        private System.Windows.Forms.Label lbEmisorTaxIdentificationNumber;
        private System.Windows.Forms.TextBox txBuyerPartyName;
        private System.Windows.Forms.TextBox txBuyerTaxIdentificationNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnLoad;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label lbIndexlInf;
        private System.Windows.Forms.Label lblNifInf;
        private System.Windows.Forms.TextBox txCountry;
        private System.Windows.Forms.TextBox txDescripcionBienes;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txClaveDeclarado;
        private System.Windows.Forms.TextBox txTipoOperacion;
        private System.Windows.Forms.Label lbClaveDeclarado;
        private System.Windows.Forms.Label lbTipoOperacion;
        private System.Windows.Forms.TextBox txEstadoUE;
        private System.Windows.Forms.Label lbEstadoUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechFra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.CheckBox cbEsEmisor;
    }
}

