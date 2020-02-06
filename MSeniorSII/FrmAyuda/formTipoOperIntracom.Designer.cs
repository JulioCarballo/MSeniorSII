namespace MSeniorSII
{
    partial class formTipoOperIntracom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTipoOperIntracom));
            this.txPattern = new System.Windows.Forms.TextBox();
            this.grdPaises = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescTipoOperIntra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaises)).BeginInit();
            this.SuspendLayout();
            // 
            // txPattern
            // 
            this.txPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.txPattern.Location = new System.Drawing.Point(0, 0);
            this.txPattern.Name = "txPattern";
            this.txPattern.Size = new System.Drawing.Size(399, 20);
            this.txPattern.TabIndex = 1;
            this.txPattern.TextChanged += new System.EventHandler(this.txPattern_TextChanged);
            this.txPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // grdPaises
            // 
            this.grdPaises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaises.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.DescTipoOperIntra});
            this.grdPaises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaises.Location = new System.Drawing.Point(0, 20);
            this.grdPaises.MultiSelect = false;
            this.grdPaises.Name = "grdPaises";
            this.grdPaises.RowHeadersVisible = false;
            this.grdPaises.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaises.Size = new System.Drawing.Size(399, 368);
            this.grdPaises.TabIndex = 2;
            this.grdPaises.DoubleClick += new System.EventHandler(this.grdPaises_DoubleClick);
            this.grdPaises.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // Code
            // 
            this.Code.HeaderText = "Cod.";
            this.Code.Name = "Code";
            this.Code.Width = 40;
            // 
            // DescTipoOperIntra
            // 
            this.DescTipoOperIntra.HeaderText = "Descripción";
            this.DescTipoOperIntra.Name = "DescTipoOperIntra";
            this.DescTipoOperIntra.Width = 300;
            // 
            // formTipoOperIntracom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 388);
            this.Controls.Add(this.grdPaises);
            this.Controls.Add(this.txPattern);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formTipoOperIntracom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR TIPO OPER. INTRACOMUNITARIA";
            this.Load += new System.EventHandler(this.formTipoOperIntracom_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaises)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txPattern;
        private System.Windows.Forms.DataGridView grdPaises;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescTipoOperIntra;
    }
}