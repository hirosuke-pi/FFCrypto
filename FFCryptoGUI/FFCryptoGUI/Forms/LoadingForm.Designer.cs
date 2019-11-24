namespace FFCryptGUI.Forms
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.percentProgressBar = new PercentProgressBar();
            this.Path_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // percentProgressBar
            // 
            this.percentProgressBar.Location = new System.Drawing.Point(12, 69);
            this.percentProgressBar.Name = "percentProgressBar";
            this.percentProgressBar.Size = new System.Drawing.Size(329, 39);
            this.percentProgressBar.TabIndex = 2;
            this.percentProgressBar.Tag = "%";
            // 
            // Path_label
            // 
            this.Path_label.Location = new System.Drawing.Point(12, 19);
            this.Path_label.Name = "Path_label";
            this.Path_label.Size = new System.Drawing.Size(329, 47);
            this.Path_label.TabIndex = 3;
            this.Path_label.Text = "filepath";
            // 
            // LoadingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(353, 120);
            this.Controls.Add(this.Path_label);
            this.Controls.Add(this.percentProgressBar);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingForm";
            this.ShowInTaskbar = false;
            this.Text = "プロジェクトファイルを読み込み中...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingForm_FormClosing);
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public PercentProgressBar percentProgressBar;
        public System.Windows.Forms.Label Path_label;
    }
}