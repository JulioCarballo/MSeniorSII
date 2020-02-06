namespace MSeniorSII
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConsultaEnvios));
            this.trView = new System.Windows.Forms.TreeView();
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // trView
            // 
            this.trView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trView.ImageIndex = 0;
            this.trView.ImageList = this.imgList;
            this.trView.ItemHeight = 32;
            this.trView.Location = new System.Drawing.Point(0, 0);
            this.trView.Name = "trView";
            this.trView.SelectedImageKey = "lote_selected.png";
            this.trView.Size = new System.Drawing.Size(301, 476);
            this.trView.TabIndex = 0;
            // 
            // splitContMain
            // 
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContMain.Location = new System.Drawing.Point(0, 0);
            this.splitContMain.Name = "splitContMain";
            // 
            // splitContMain.Panel1
            // 
            this.splitContMain.Panel1.Controls.Add(this.trView);
            this.splitContMain.Size = new System.Drawing.Size(699, 476);
            this.splitContMain.SplitterDistance = 301;
            this.splitContMain.TabIndex = 1;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "lote.png");
            this.imgList.Images.SetKeyName(1, "lote_selected.png");
            // 
            // formConsultaEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 476);
            this.Controls.Add(this.splitContMain);
            this.Name = "formConsultaEnvios";
            this.Text = ":: CONSULTA DE ENVÍOS REALIZADOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formConsultaEnvios_Load);
            this.splitContMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trView;
        private System.Windows.Forms.SplitContainer splitContMain;
        private System.Windows.Forms.ImageList imgList;
    }
}