namespace MSeniorSII
{
    partial class frmTraducir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraducir));
            this.lblDirectorio = new System.Windows.Forms.Label();
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.dgwFicheros = new System.Windows.Forms.DataGridView();
            this.Fichero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelec = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwFicheros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDirectorio
            // 
            this.lblDirectorio.AutoSize = true;
            this.lblDirectorio.Location = new System.Drawing.Point(12, 9);
            this.lblDirectorio.Name = "lblDirectorio";
            this.lblDirectorio.Size = new System.Drawing.Size(89, 13);
            this.lblDirectorio.TabIndex = 0;
            this.lblDirectorio.Text = "Directorio Origen:";
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Location = new System.Drawing.Point(107, 6);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.ReadOnly = true;
            this.txtDirectorio.Size = new System.Drawing.Size(259, 20);
            this.txtDirectorio.TabIndex = 1;
            // 
            // dgwFicheros
            // 
            this.dgwFicheros.AllowDrop = true;
            this.dgwFicheros.AllowUserToOrderColumns = true;
            this.dgwFicheros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgwFicheros.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgwFicheros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwFicheros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fichero});
            this.dgwFicheros.Location = new System.Drawing.Point(15, 40);
            this.dgwFicheros.MultiSelect = false;
            this.dgwFicheros.Name = "dgwFicheros";
            this.dgwFicheros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgwFicheros.Size = new System.Drawing.Size(351, 144);
            this.dgwFicheros.TabIndex = 2;
            // 
            // Fichero
            // 
            this.Fichero.HeaderText = "Fichero";
            this.Fichero.Name = "Fichero";
            this.Fichero.ReadOnly = true;
            this.Fichero.Width = 67;
            // 
            // btnSelec
            // 
            this.btnSelec.Location = new System.Drawing.Point(209, 207);
            this.btnSelec.Name = "btnSelec";
            this.btnSelec.Size = new System.Drawing.Size(81, 23);
            this.btnSelec.TabIndex = 3;
            this.btnSelec.Text = "Seleccionado";
            this.btnSelec.UseVisualStyleBackColor = true;
            this.btnSelec.Click += new System.EventHandler(this.btnSelec_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(296, 207);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(69, 22);
            this.btnTodos.TabIndex = 4;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // frmTraducir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 243);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnSelec);
            this.Controls.Add(this.dgwFicheros);
            this.Controls.Add(this.txtDirectorio);
            this.Controls.Add(this.lblDirectorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTraducir";
            this.Text = ":: Traducción Ficheros DAT";
            this.Load += new System.EventHandler(this.frmTraducir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwFicheros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirectorio;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.DataGridView dgwFicheros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fichero;
        private System.Windows.Forms.Button btnSelec;
        private System.Windows.Forms.Button btnTodos;
    }
}