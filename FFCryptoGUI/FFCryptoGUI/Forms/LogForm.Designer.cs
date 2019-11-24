namespace FFCryptGUI.Forms
{
    partial class LogForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logs_richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stopProgram_button = new System.Windows.Forms.Button();
            this.searchLogs_groupBox = new System.Windows.Forms.GroupBox();
            this.changeBackColor_button = new System.Windows.Forms.Button();
            this.changeForeColor_button = new System.Windows.Forms.Button();
            this.claerLogs_button = new System.Windows.Forms.Button();
            this.saveLogs_button = new System.Windows.Forms.Button();
            this.changeFonts_button = new System.Windows.Forms.Button();
            this.errorWarning_groupBox = new System.Windows.Forms.GroupBox();
            this.errorWarning_comboBox = new System.Windows.Forms.ComboBox();
            this.logs_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.logs_fontDialog = new System.Windows.Forms.FontDialog();
            this.fore_colorDialog = new System.Windows.Forms.ColorDialog();
            this.back_colorDialog = new System.Windows.Forms.ColorDialog();
            this.ffc_percentProgressBar = new PercentProgressBar();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.searchLogs_groupBox.SuspendLayout();
            this.errorWarning_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Controls.Add(this.logs_richTextBox);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 332);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ログ";
            // 
            // logs_richTextBox
            // 
            this.logs_richTextBox.BackColor = System.Drawing.Color.Black;
            this.logs_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logs_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs_richTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logs_richTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.logs_richTextBox.HideSelection = false;
            this.logs_richTextBox.Location = new System.Drawing.Point(3, 46);
            this.logs_richTextBox.Name = "logs_richTextBox";
            this.logs_richTextBox.ReadOnly = true;
            this.logs_richTextBox.Size = new System.Drawing.Size(558, 283);
            this.logs_richTextBox.TabIndex = 2;
            this.logs_richTextBox.Text = "";
            this.logs_richTextBox.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ffc_percentProgressBar);
            this.panel1.Controls.Add(this.stopProgram_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 27);
            this.panel1.TabIndex = 4;
            // 
            // stopProgram_button
            // 
            this.stopProgram_button.BackColor = System.Drawing.Color.IndianRed;
            this.stopProgram_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.stopProgram_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopProgram_button.Image = global::FFCryptoGUI.Properties.Resources.delete_icon;
            this.stopProgram_button.Location = new System.Drawing.Point(520, 0);
            this.stopProgram_button.Name = "stopProgram_button";
            this.stopProgram_button.Size = new System.Drawing.Size(38, 27);
            this.stopProgram_button.TabIndex = 3;
            this.stopProgram_button.UseVisualStyleBackColor = false;
            this.stopProgram_button.Click += new System.EventHandler(this.StopProgram_button_Click);
            // 
            // searchLogs_groupBox
            // 
            this.searchLogs_groupBox.Controls.Add(this.changeBackColor_button);
            this.searchLogs_groupBox.Controls.Add(this.changeForeColor_button);
            this.searchLogs_groupBox.Controls.Add(this.claerLogs_button);
            this.searchLogs_groupBox.Controls.Add(this.saveLogs_button);
            this.searchLogs_groupBox.Controls.Add(this.changeFonts_button);
            this.searchLogs_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.searchLogs_groupBox.Location = new System.Drawing.Point(12, 350);
            this.searchLogs_groupBox.Name = "searchLogs_groupBox";
            this.searchLogs_groupBox.Size = new System.Drawing.Size(417, 59);
            this.searchLogs_groupBox.TabIndex = 1;
            this.searchLogs_groupBox.TabStop = false;
            this.searchLogs_groupBox.Text = "ログの操作";
            // 
            // changeBackColor_button
            // 
            this.changeBackColor_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeBackColor_button.Image = global::FFCryptoGUI.Properties.Resources.image_icon;
            this.changeBackColor_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeBackColor_button.Location = new System.Drawing.Point(285, 23);
            this.changeBackColor_button.Name = "changeBackColor_button";
            this.changeBackColor_button.Size = new System.Drawing.Size(67, 23);
            this.changeBackColor_button.TabIndex = 5;
            this.changeBackColor_button.Text = "背景...";
            this.changeBackColor_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.changeBackColor_button.UseVisualStyleBackColor = true;
            this.changeBackColor_button.Click += new System.EventHandler(this.ChangeBackColor_button_Click);
            // 
            // changeForeColor_button
            // 
            this.changeForeColor_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeForeColor_button.Image = global::FFCryptoGUI.Properties.Resources.rgba_icon;
            this.changeForeColor_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeForeColor_button.Location = new System.Drawing.Point(212, 23);
            this.changeForeColor_button.Name = "changeForeColor_button";
            this.changeForeColor_button.Size = new System.Drawing.Size(67, 23);
            this.changeForeColor_button.TabIndex = 4;
            this.changeForeColor_button.Text = "文字...";
            this.changeForeColor_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.changeForeColor_button.UseVisualStyleBackColor = true;
            this.changeForeColor_button.Click += new System.EventHandler(this.ChangeForeColor_button_Click);
            // 
            // claerLogs_button
            // 
            this.claerLogs_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.claerLogs_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.claerLogs_button.Location = new System.Drawing.Point(358, 23);
            this.claerLogs_button.Name = "claerLogs_button";
            this.claerLogs_button.Size = new System.Drawing.Size(53, 23);
            this.claerLogs_button.TabIndex = 3;
            this.claerLogs_button.Text = "クリア";
            this.claerLogs_button.UseVisualStyleBackColor = true;
            this.claerLogs_button.Click += new System.EventHandler(this.ClaerLogs_button_Click);
            // 
            // saveLogs_button
            // 
            this.saveLogs_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveLogs_button.Image = global::FFCryptoGUI.Properties.Resources.save_icon;
            this.saveLogs_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveLogs_button.Location = new System.Drawing.Point(6, 23);
            this.saveLogs_button.Name = "saveLogs_button";
            this.saveLogs_button.Size = new System.Drawing.Size(97, 23);
            this.saveLogs_button.TabIndex = 2;
            this.saveLogs_button.Text = "ログを保存...";
            this.saveLogs_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveLogs_button.UseVisualStyleBackColor = true;
            this.saveLogs_button.Click += new System.EventHandler(this.SaveLogs_button_Click);
            // 
            // changeFonts_button
            // 
            this.changeFonts_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeFonts_button.Image = global::FFCryptoGUI.Properties.Resources.font_icon;
            this.changeFonts_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeFonts_button.Location = new System.Drawing.Point(109, 23);
            this.changeFonts_button.Name = "changeFonts_button";
            this.changeFonts_button.Size = new System.Drawing.Size(97, 23);
            this.changeFonts_button.TabIndex = 1;
            this.changeFonts_button.Text = "フォント変更...";
            this.changeFonts_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.changeFonts_button.UseVisualStyleBackColor = true;
            this.changeFonts_button.Click += new System.EventHandler(this.ChangeFonts_button_Click);
            // 
            // errorWarning_groupBox
            // 
            this.errorWarning_groupBox.Controls.Add(this.errorWarning_comboBox);
            this.errorWarning_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.errorWarning_groupBox.Location = new System.Drawing.Point(435, 350);
            this.errorWarning_groupBox.Name = "errorWarning_groupBox";
            this.errorWarning_groupBox.Size = new System.Drawing.Size(141, 59);
            this.errorWarning_groupBox.TabIndex = 2;
            this.errorWarning_groupBox.TabStop = false;
            this.errorWarning_groupBox.Text = "エラー: 0, 警告: 0";
            // 
            // errorWarning_comboBox
            // 
            this.errorWarning_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorWarning_comboBox.FormattingEnabled = true;
            this.errorWarning_comboBox.Location = new System.Drawing.Point(6, 23);
            this.errorWarning_comboBox.Name = "errorWarning_comboBox";
            this.errorWarning_comboBox.Size = new System.Drawing.Size(129, 23);
            this.errorWarning_comboBox.TabIndex = 0;
            this.errorWarning_comboBox.SelectedIndexChanged += new System.EventHandler(this.ErrorWarning_comboBox_SelectedIndexChanged);
            // 
            // logs_saveFileDialog
            // 
            this.logs_saveFileDialog.Filter = "ログファイル|*.log|テキストファイル|*.txt;*.log";
            this.logs_saveFileDialog.Title = "ログファイルを保存";
            // 
            // logs_fontDialog
            // 
            this.logs_fontDialog.Color = System.Drawing.SystemColors.Control;
            this.logs_fontDialog.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // fore_colorDialog
            // 
            this.fore_colorDialog.AnyColor = true;
            this.fore_colorDialog.Color = System.Drawing.SystemColors.Control;
            this.fore_colorDialog.FullOpen = true;
            // 
            // back_colorDialog
            // 
            this.back_colorDialog.AnyColor = true;
            this.back_colorDialog.FullOpen = true;
            // 
            // ffc_percentProgressBar
            // 
            this.ffc_percentProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ffc_percentProgressBar.Location = new System.Drawing.Point(0, 0);
            this.ffc_percentProgressBar.Name = "ffc_percentProgressBar";
            this.ffc_percentProgressBar.Size = new System.Drawing.Size(520, 27);
            this.ffc_percentProgressBar.TabIndex = 1;
            // 
            // LogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(588, 421);
            this.Controls.Add(this.errorWarning_groupBox);
            this.Controls.Add(this.searchLogs_groupBox);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogForm_FormClosed);
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.searchLogs_groupBox.ResumeLayout(false);
            this.errorWarning_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private PercentProgressBar ffc_percentProgressBar;
        private System.Windows.Forms.Button changeFonts_button;
        private System.Windows.Forms.ComboBox errorWarning_comboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button stopProgram_button;
        private System.Windows.Forms.RichTextBox logs_richTextBox;
        private System.Windows.Forms.GroupBox searchLogs_groupBox;
        private System.Windows.Forms.GroupBox errorWarning_groupBox;
        private System.Windows.Forms.Button saveLogs_button;
        private System.Windows.Forms.Button claerLogs_button;
        private System.Windows.Forms.SaveFileDialog logs_saveFileDialog;
        private System.Windows.Forms.FontDialog logs_fontDialog;
        private System.Windows.Forms.Button changeBackColor_button;
        private System.Windows.Forms.Button changeForeColor_button;
        private System.Windows.Forms.ColorDialog fore_colorDialog;
        private System.Windows.Forms.ColorDialog back_colorDialog;
    }
}