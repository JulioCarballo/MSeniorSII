namespace Sample
{
    partial class formConsultaEnvios
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
            this.trView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trView
            // 
            this.trView.Location = new System.Drawing.Point(12, 12);
            this.trView.Name = "trView";
            this.trView.Size = new System.Drawing.Size(214, 419);
            this.trView.TabIndex = 0;
            // 
            // formConsultaEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 476);
            this.Controls.Add(this.trView);
            this.Name = "formConsultaEnvios";
            this.Text = ":: CONSULTA DE ENVÍOS REALIZADOS";
            this.Load += new System.EventHandler(this.formConsultaEnvios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trView;
    }
}