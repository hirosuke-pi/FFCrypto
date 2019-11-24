namespace FFCryptGUI.Forms
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.projectFile_textBox = new System.Windows.Forms.TextBox();
            this.projectSave_button = new System.Windows.Forms.Button();
            this.projectOpen_button = new System.Windows.Forms.Button();
            this.projectFile_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.projectFile_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.set_minimize_notify_checkBox = new System.Windows.Forms.CheckBox();
            this.saveMainFFCP_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.set_noSavePassword_radioButton = new System.Windows.Forms.RadioButton();
            this.set_savePasswordWithHash_radioButton = new System.Windows.Forms.RadioButton();
            this.set_savePassword_radioButton = new System.Windows.Forms.RadioButton();
            this.set_saveSettings_checkBox = new System.Windows.Forms.CheckBox();
            this.set_showNotifyIcon_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addContextMenu_button = new System.Windows.Forms.Button();
            this.set_remove_button = new System.Windows.Forms.Button();
            this.set_ffcpFile_button = new System.Windows.Forms.Button();
            this.set_ffcFile_button = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salt_textBox = new System.Windows.Forms.TextBox();
            this.hash_textBox = new System.Windows.Forms.TextBox();
            this.windowSet_groupBox = new System.Windows.Forms.GroupBox();
            this.set_showTop_checkBox = new System.Windows.Forms.CheckBox();
            this.set_opacity_trackBar = new System.Windows.Forms.TrackBar();
            this.initialize_button = new System.Windows.Forms.Button();
            this.help_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.windowSet_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.set_opacity_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.projectFile_textBox);
            this.groupBox1.Controls.Add(this.projectSave_button);
            this.groupBox1.Controls.Add(this.projectOpen_button);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "プロジェクトファイル";
            // 
            // projectFile_textBox
            // 
            this.projectFile_textBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.projectFile_textBox.ForeColor = System.Drawing.SystemColors.Control;
            this.projectFile_textBox.Location = new System.Drawing.Point(6, 23);
            this.projectFile_textBox.Name = "projectFile_textBox";
            this.projectFile_textBox.ReadOnly = true;
            this.projectFile_textBox.Size = new System.Drawing.Size(394, 23);
            this.projectFile_textBox.TabIndex = 5;
            // 
            // projectSave_button
            // 
            this.projectSave_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.projectSave_button.Image = global::FFCryptoGUI.Properties.Resources.save_icon;
            this.projectSave_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectSave_button.Location = new System.Drawing.Point(485, 23);
            this.projectSave_button.Name = "projectSave_button";
            this.projectSave_button.Size = new System.Drawing.Size(73, 23);
            this.projectSave_button.TabIndex = 3;
            this.projectSave_button.Text = "保存 ...";
            this.projectSave_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.projectSave_button.UseVisualStyleBackColor = true;
            this.projectSave_button.Click += new System.EventHandler(this.ProjectSave_button_Click);
            // 
            // projectOpen_button
            // 
            this.projectOpen_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.projectOpen_button.Image = global::FFCryptoGUI.Properties.Resources.data_icon;
            this.projectOpen_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectOpen_button.Location = new System.Drawing.Point(406, 23);
            this.projectOpen_button.Name = "projectOpen_button";
            this.projectOpen_button.Size = new System.Drawing.Size(73, 23);
            this.projectOpen_button.TabIndex = 2;
            this.projectOpen_button.Text = "開く ...";
            this.projectOpen_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.projectOpen_button.UseVisualStyleBackColor = true;
            this.projectOpen_button.Click += new System.EventHandler(this.ProjectOpen_button_Click);
            // 
            // projectFile_openFileDialog
            // 
            this.projectFile_openFileDialog.Filter = "プロジェクトファイル|*.ffcp";
            this.projectFile_openFileDialog.Title = "プロジェクトを開く";
            // 
            // projectFile_saveFileDialog
            // 
            this.projectFile_saveFileDialog.Filter = "プロジェクトファイル|*.ffcp";
            this.projectFile_saveFileDialog.Title = "プロジェクトを保存";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.set_minimize_notify_checkBox);
            this.groupBox2.Controls.Add(this.saveMainFFCP_checkBox);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.set_saveSettings_checkBox);
            this.groupBox2.Controls.Add(this.set_showNotifyIcon_checkBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 230);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "プロジェクト設定";
            // 
            // set_minimize_notify_checkBox
            // 
            this.set_minimize_notify_checkBox.AutoSize = true;
            this.set_minimize_notify_checkBox.Location = new System.Drawing.Point(12, 97);
            this.set_minimize_notify_checkBox.Name = "set_minimize_notify_checkBox";
            this.set_minimize_notify_checkBox.Size = new System.Drawing.Size(166, 19);
            this.set_minimize_notify_checkBox.TabIndex = 4;
            this.set_minimize_notify_checkBox.Text = "最小化で通知バーに格納する";
            this.help_toolTip.SetToolTip(this.set_minimize_notify_checkBox, "ウィンドウの最小化ボタンで通知バーに格納するかどうかです。");
            this.set_minimize_notify_checkBox.UseVisualStyleBackColor = true;
            this.set_minimize_notify_checkBox.CheckedChanged += new System.EventHandler(this.Set_minimize_notify_checkBox_CheckedChanged);
            // 
            // saveMainFFCP_checkBox
            // 
            this.saveMainFFCP_checkBox.AutoSize = true;
            this.saveMainFFCP_checkBox.Checked = true;
            this.saveMainFFCP_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveMainFFCP_checkBox.Location = new System.Drawing.Point(12, 72);
            this.saveMainFFCP_checkBox.Name = "saveMainFFCP_checkBox";
            this.saveMainFFCP_checkBox.Size = new System.Drawing.Size(170, 19);
            this.saveMainFFCP_checkBox.TabIndex = 3;
            this.saveMainFFCP_checkBox.Text = "main.ffcpにも上書き保存する";
            this.help_toolTip.SetToolTip(this.saveMainFFCP_checkBox, "デフォルトプロジェクトであるmain.ffcpにも状態を上書き保存するかどうかです。");
            this.saveMainFFCP_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.set_noSavePassword_radioButton);
            this.groupBox4.Controls.Add(this.set_savePasswordWithHash_radioButton);
            this.groupBox4.Controls.Add(this.set_savePassword_radioButton);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(6, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 102);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "パスワード設定";
            // 
            // set_noSavePassword_radioButton
            // 
            this.set_noSavePassword_radioButton.AutoSize = true;
            this.set_noSavePassword_radioButton.Location = new System.Drawing.Point(6, 72);
            this.set_noSavePassword_radioButton.Name = "set_noSavePassword_radioButton";
            this.set_noSavePassword_radioButton.Size = new System.Drawing.Size(130, 19);
            this.set_noSavePassword_radioButton.TabIndex = 2;
            this.set_noSavePassword_radioButton.Text = "パスワードを保持しない";
            this.help_toolTip.SetToolTip(this.set_noSavePassword_radioButton, "生のパスワード・ハッシュ化されたパスワードを保持しないかどうかです。");
            this.set_noSavePassword_radioButton.UseVisualStyleBackColor = true;
            // 
            // set_savePasswordWithHash_radioButton
            // 
            this.set_savePasswordWithHash_radioButton.AutoSize = true;
            this.set_savePasswordWithHash_radioButton.Checked = true;
            this.set_savePasswordWithHash_radioButton.Location = new System.Drawing.Point(6, 47);
            this.set_savePasswordWithHash_radioButton.Name = "set_savePasswordWithHash_radioButton";
            this.set_savePasswordWithHash_radioButton.Size = new System.Drawing.Size(185, 19);
            this.set_savePasswordWithHash_radioButton.TabIndex = 1;
            this.set_savePasswordWithHash_radioButton.TabStop = true;
            this.set_savePasswordWithHash_radioButton.Text = "パスワードをハッシュ化して保持する";
            this.help_toolTip.SetToolTip(this.set_savePasswordWithHash_radioButton, "パスワードをハッシュ化して保存するかどうかです。");
            this.set_savePasswordWithHash_radioButton.UseVisualStyleBackColor = true;
            this.set_savePasswordWithHash_radioButton.CheckedChanged += new System.EventHandler(this.Set_savePasswordWithHash_radioButton_CheckedChanged);
            // 
            // set_savePassword_radioButton
            // 
            this.set_savePassword_radioButton.AutoSize = true;
            this.set_savePassword_radioButton.Location = new System.Drawing.Point(6, 22);
            this.set_savePassword_radioButton.Name = "set_savePassword_radioButton";
            this.set_savePassword_radioButton.Size = new System.Drawing.Size(168, 19);
            this.set_savePassword_radioButton.TabIndex = 0;
            this.set_savePassword_radioButton.TabStop = true;
            this.set_savePassword_radioButton.Text = "パスワードを保持する (非推奨)";
            this.help_toolTip.SetToolTip(this.set_savePassword_radioButton, "プロジェクトファイルに生のパスワードを保存するかどうかです。(非推奨)");
            this.set_savePassword_radioButton.UseVisualStyleBackColor = true;
            // 
            // set_saveSettings_checkBox
            // 
            this.set_saveSettings_checkBox.AutoSize = true;
            this.set_saveSettings_checkBox.Checked = true;
            this.set_saveSettings_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_saveSettings_checkBox.Location = new System.Drawing.Point(12, 47);
            this.set_saveSettings_checkBox.Name = "set_saveSettings_checkBox";
            this.set_saveSettings_checkBox.Size = new System.Drawing.Size(147, 19);
            this.set_saveSettings_checkBox.TabIndex = 1;
            this.set_saveSettings_checkBox.Text = "終了時に状態を保存する";
            this.help_toolTip.SetToolTip(this.set_saveSettings_checkBox, "終了時に、今の状態を保存してから終了するかどうかです。");
            this.set_saveSettings_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_showNotifyIcon_checkBox
            // 
            this.set_showNotifyIcon_checkBox.AutoSize = true;
            this.set_showNotifyIcon_checkBox.Checked = true;
            this.set_showNotifyIcon_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_showNotifyIcon_checkBox.Location = new System.Drawing.Point(12, 22);
            this.set_showNotifyIcon_checkBox.Name = "set_showNotifyIcon_checkBox";
            this.set_showNotifyIcon_checkBox.Size = new System.Drawing.Size(164, 19);
            this.set_showNotifyIcon_checkBox.TabIndex = 0;
            this.set_showNotifyIcon_checkBox.Text = "通知バーにアイコンを表示する";
            this.help_toolTip.SetToolTip(this.set_showNotifyIcon_checkBox, "通知バーにアイコンを表示するかどうかです。");
            this.set_showNotifyIcon_checkBox.UseVisualStyleBackColor = true;
            this.set_showNotifyIcon_checkBox.CheckedChanged += new System.EventHandler(this.Set_showNotifyIcon_checkBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addContextMenu_button);
            this.groupBox3.Controls.Add(this.set_remove_button);
            this.groupBox3.Controls.Add(this.set_ffcpFile_button);
            this.groupBox3.Controls.Add(this.set_ffcFile_button);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(249, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 86);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ファイルを関連付ける (管理者権限)";
            // 
            // addContextMenu_button
            // 
            this.addContextMenu_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addContextMenu_button.Location = new System.Drawing.Point(174, 22);
            this.addContextMenu_button.Name = "addContextMenu_button";
            this.addContextMenu_button.Size = new System.Drawing.Size(75, 57);
            this.addContextMenu_button.TabIndex = 3;
            this.addContextMenu_button.Text = "コンテキストメニュー";
            this.addContextMenu_button.UseVisualStyleBackColor = true;
            this.addContextMenu_button.Click += new System.EventHandler(this.AddContextMenu_button_Click);
            // 
            // set_remove_button
            // 
            this.set_remove_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.set_remove_button.Location = new System.Drawing.Point(255, 22);
            this.set_remove_button.Name = "set_remove_button";
            this.set_remove_button.Size = new System.Drawing.Size(66, 57);
            this.set_remove_button.TabIndex = 2;
            this.set_remove_button.Text = "削除";
            this.set_remove_button.UseVisualStyleBackColor = true;
            this.set_remove_button.Click += new System.EventHandler(this.Set_remove_button_Click);
            // 
            // set_ffcpFile_button
            // 
            this.set_ffcpFile_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.set_ffcpFile_button.Location = new System.Drawing.Point(90, 22);
            this.set_ffcpFile_button.Name = "set_ffcpFile_button";
            this.set_ffcpFile_button.Size = new System.Drawing.Size(78, 57);
            this.set_ffcpFile_button.TabIndex = 1;
            this.set_ffcpFile_button.Text = ".ffcp";
            this.set_ffcpFile_button.UseVisualStyleBackColor = true;
            this.set_ffcpFile_button.Click += new System.EventHandler(this.Set_ffcpFile_button_Click);
            // 
            // set_ffcFile_button
            // 
            this.set_ffcFile_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.set_ffcFile_button.Location = new System.Drawing.Point(6, 22);
            this.set_ffcFile_button.Name = "set_ffcFile_button";
            this.set_ffcFile_button.Size = new System.Drawing.Size(78, 57);
            this.set_ffcFile_button.TabIndex = 0;
            this.set_ffcFile_button.Text = ".ffc";
            this.set_ffcFile_button.UseVisualStyleBackColor = true;
            this.set_ffcFile_button.Click += new System.EventHandler(this.Set_ffcFile_button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.salt_textBox);
            this.groupBox5.Controls.Add(this.hash_textBox);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(12, 312);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(564, 97);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "パスワードのHMACハッシュコード (SHA256)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "ソルト:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ハッシュ:";
            // 
            // salt_textBox
            // 
            this.salt_textBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.salt_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.salt_textBox.ForeColor = System.Drawing.SystemColors.Control;
            this.salt_textBox.Location = new System.Drawing.Point(60, 59);
            this.salt_textBox.Name = "salt_textBox";
            this.salt_textBox.ReadOnly = true;
            this.salt_textBox.Size = new System.Drawing.Size(489, 20);
            this.salt_textBox.TabIndex = 2;
            this.salt_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hash_textBox
            // 
            this.hash_textBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.hash_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hash_textBox.ForeColor = System.Drawing.SystemColors.Control;
            this.hash_textBox.Location = new System.Drawing.Point(60, 27);
            this.hash_textBox.Name = "hash_textBox";
            this.hash_textBox.ReadOnly = true;
            this.hash_textBox.Size = new System.Drawing.Size(489, 20);
            this.hash_textBox.TabIndex = 1;
            this.hash_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // windowSet_groupBox
            // 
            this.windowSet_groupBox.Controls.Add(this.set_showTop_checkBox);
            this.windowSet_groupBox.Controls.Add(this.set_opacity_trackBar);
            this.windowSet_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.windowSet_groupBox.Location = new System.Drawing.Point(249, 76);
            this.windowSet_groupBox.Name = "windowSet_groupBox";
            this.windowSet_groupBox.Size = new System.Drawing.Size(327, 75);
            this.windowSet_groupBox.TabIndex = 8;
            this.windowSet_groupBox.TabStop = false;
            this.windowSet_groupBox.Text = "ウィンドウ設定 (透明度: 100%)";
            // 
            // set_showTop_checkBox
            // 
            this.set_showTop_checkBox.AutoSize = true;
            this.set_showTop_checkBox.Location = new System.Drawing.Point(206, 36);
            this.set_showTop_checkBox.Name = "set_showTop_checkBox";
            this.set_showTop_checkBox.Size = new System.Drawing.Size(115, 19);
            this.set_showTop_checkBox.TabIndex = 4;
            this.set_showTop_checkBox.Text = "最前面で表示する";
            this.set_showTop_checkBox.UseVisualStyleBackColor = true;
            this.set_showTop_checkBox.CheckedChanged += new System.EventHandler(this.Set_showTop_checkBox_CheckedChanged);
            // 
            // set_opacity_trackBar
            // 
            this.set_opacity_trackBar.Location = new System.Drawing.Point(12, 25);
            this.set_opacity_trackBar.Maximum = 100;
            this.set_opacity_trackBar.Minimum = 20;
            this.set_opacity_trackBar.Name = "set_opacity_trackBar";
            this.set_opacity_trackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.set_opacity_trackBar.RightToLeftLayout = true;
            this.set_opacity_trackBar.Size = new System.Drawing.Size(188, 45);
            this.set_opacity_trackBar.TabIndex = 0;
            this.set_opacity_trackBar.Value = 100;
            this.set_opacity_trackBar.Scroll += new System.EventHandler(this.Set_opacity_trackBar_Scroll);
            // 
            // initialize_button
            // 
            this.initialize_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.initialize_button.Location = new System.Drawing.Point(249, 251);
            this.initialize_button.Name = "initialize_button";
            this.initialize_button.Size = new System.Drawing.Size(327, 55);
            this.initialize_button.TabIndex = 9;
            this.initialize_button.Text = "初期化";
            this.initialize_button.UseVisualStyleBackColor = true;
            this.initialize_button.Click += new System.EventHandler(this.Initialize_button_Click);
            // 
            // help_toolTip
            // 
            this.help_toolTip.AutoPopDelay = 10000;
            this.help_toolTip.InitialDelay = 500;
            this.help_toolTip.ReshowDelay = 100;
            // 
            // SettingsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(588, 421);
            this.Controls.Add(this.initialize_button);
            this.Controls.Add(this.windowSet_groupBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SettingsForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SettingsForm_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.windowSet_groupBox.ResumeLayout(false);
            this.windowSet_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.set_opacity_trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button projectSave_button;
        private System.Windows.Forms.Button projectOpen_button;
        private System.Windows.Forms.OpenFileDialog projectFile_openFileDialog;
        private System.Windows.Forms.SaveFileDialog projectFile_saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox set_showNotifyIcon_checkBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton set_savePassword_radioButton;
        private System.Windows.Forms.RadioButton set_savePasswordWithHash_radioButton;
        private System.Windows.Forms.RadioButton set_noSavePassword_radioButton;
        private System.Windows.Forms.CheckBox saveMainFFCP_checkBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox salt_textBox;
        private System.Windows.Forms.TextBox hash_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox windowSet_groupBox;
        private System.Windows.Forms.TrackBar set_opacity_trackBar;
        private System.Windows.Forms.CheckBox set_showTop_checkBox;
        private System.Windows.Forms.Button initialize_button;
        private System.Windows.Forms.CheckBox set_minimize_notify_checkBox;
        private System.Windows.Forms.Button set_remove_button;
        private System.Windows.Forms.Button set_ffcpFile_button;
        private System.Windows.Forms.Button set_ffcFile_button;
        public System.Windows.Forms.CheckBox set_saveSettings_checkBox;
        public System.Windows.Forms.TextBox projectFile_textBox;
        private System.Windows.Forms.Button addContextMenu_button;
        private System.Windows.Forms.ToolTip help_toolTip;
    }
}