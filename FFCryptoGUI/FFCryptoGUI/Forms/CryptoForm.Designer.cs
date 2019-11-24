namespace FFCryptGUI.Forms
{
    partial class CryptoForm
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
            this.aesMode_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.password2_checkBox = new System.Windows.Forms.CheckBox();
            this.password1_checkBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password2_textBox = new System.Windows.Forms.TextBox();
            this.password1_textBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.aesPadding_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.aesBlockSize_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.aesKeySize_comboBox = new System.Windows.Forms.ComboBox();
            this.encryption_button = new System.Windows.Forms.Button();
            this.decryption_button = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.set_collectFolder_checkBox = new System.Windows.Forms.CheckBox();
            this.set_enc_randomName_checkBox = new System.Windows.Forms.CheckBox();
            this.set_enc_saveFileInfo_checkBox = new System.Windows.Forms.CheckBox();
            this.set_removeFiles_checkBox = new System.Windows.Forms.CheckBox();
            this.set_removeFolderFillZero_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.set_allFiles_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.set_dec_restoreFilePath_checkBox = new System.Windows.Forms.CheckBox();
            this.set_dec_restoreInfo_checkBox = new System.Windows.Forms.CheckBox();
            this.set_forceWrite_checkBox = new System.Windows.Forms.CheckBox();
            this.cryptoSettings_panel = new System.Windows.Forms.Panel();
            this.compressLevel_groupBox = new System.Windows.Forms.GroupBox();
            this.compressLevel_trackBar = new System.Windows.Forms.TrackBar();
            this.restoreSettings_button = new System.Windows.Forms.Button();
            this.hide_button = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.clearOutPath_button = new System.Windows.Forms.Button();
            this.set_outFilder_button = new System.Windows.Forms.Button();
            this.output_textBox = new System.Windows.Forms.TextBox();
            this.hightLevelSettings_button = new System.Windows.Forms.Button();
            this.output_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.settings_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.cryptoSettings_panel.SuspendLayout();
            this.compressLevel_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressLevel_trackBar)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aesMode_comboBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(11, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AESモード";
            // 
            // aesMode_comboBox
            // 
            this.aesMode_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aesMode_comboBox.FormattingEnabled = true;
            this.aesMode_comboBox.Items.AddRange(new object[] {
            "CBC",
            "CFB",
            "CTS",
            "OFB",
            "ECB"});
            this.aesMode_comboBox.Location = new System.Drawing.Point(6, 25);
            this.aesMode_comboBox.Name = "aesMode_comboBox";
            this.aesMode_comboBox.Size = new System.Drawing.Size(150, 23);
            this.aesMode_comboBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.password2_checkBox);
            this.groupBox2.Controls.Add(this.password1_checkBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.password2_textBox);
            this.groupBox2.Controls.Add(this.password1_textBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "パスワード設定";
            // 
            // password2_checkBox
            // 
            this.password2_checkBox.AutoSize = true;
            this.password2_checkBox.Location = new System.Drawing.Point(329, 64);
            this.password2_checkBox.Name = "password2_checkBox";
            this.password2_checkBox.Size = new System.Drawing.Size(15, 14);
            this.password2_checkBox.TabIndex = 5;
            this.password2_checkBox.UseVisualStyleBackColor = true;
            this.password2_checkBox.CheckedChanged += new System.EventHandler(this.Password2_checkBox_CheckedChanged);
            // 
            // password1_checkBox
            // 
            this.password1_checkBox.AutoSize = true;
            this.password1_checkBox.Location = new System.Drawing.Point(329, 35);
            this.password1_checkBox.Name = "password1_checkBox";
            this.password1_checkBox.Size = new System.Drawing.Size(15, 14);
            this.password1_checkBox.TabIndex = 4;
            this.password1_checkBox.UseVisualStyleBackColor = true;
            this.password1_checkBox.CheckedChanged += new System.EventHandler(this.Password1_checkBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "再入力: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "入力: ";
            // 
            // password2_textBox
            // 
            this.password2_textBox.Location = new System.Drawing.Point(59, 60);
            this.password2_textBox.Name = "password2_textBox";
            this.password2_textBox.ShortcutsEnabled = false;
            this.password2_textBox.Size = new System.Drawing.Size(264, 23);
            this.password2_textBox.TabIndex = 1;
            this.password2_textBox.UseSystemPasswordChar = true;
            // 
            // password1_textBox
            // 
            this.password1_textBox.Location = new System.Drawing.Point(59, 31);
            this.password1_textBox.Name = "password1_textBox";
            this.password1_textBox.Size = new System.Drawing.Size(264, 23);
            this.password1_textBox.TabIndex = 0;
            this.password1_textBox.UseSystemPasswordChar = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(12, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 163);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AES設定";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.aesPadding_comboBox);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Location = new System.Drawing.Point(179, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(162, 60);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "パディング";
            // 
            // aesPadding_comboBox
            // 
            this.aesPadding_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aesPadding_comboBox.FormattingEnabled = true;
            this.aesPadding_comboBox.Items.AddRange(new object[] {
            "PKCS7",
            "ANSIX923",
            "ISO10126"});
            this.aesPadding_comboBox.Location = new System.Drawing.Point(6, 25);
            this.aesPadding_comboBox.Name = "aesPadding_comboBox";
            this.aesPadding_comboBox.Size = new System.Drawing.Size(150, 23);
            this.aesPadding_comboBox.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.aesBlockSize_comboBox);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(179, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 60);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ブロックサイズ";
            // 
            // aesBlockSize_comboBox
            // 
            this.aesBlockSize_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aesBlockSize_comboBox.FormattingEnabled = true;
            this.aesBlockSize_comboBox.Items.AddRange(new object[] {
            "128 Bit (AES)",
            "192 Bit",
            "256 Bit"});
            this.aesBlockSize_comboBox.Location = new System.Drawing.Point(9, 23);
            this.aesBlockSize_comboBox.Name = "aesBlockSize_comboBox";
            this.aesBlockSize_comboBox.Size = new System.Drawing.Size(147, 23);
            this.aesBlockSize_comboBox.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.aesKeySize_comboBox);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(11, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(162, 60);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "キーサイズ";
            // 
            // aesKeySize_comboBox
            // 
            this.aesKeySize_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aesKeySize_comboBox.FormattingEnabled = true;
            this.aesKeySize_comboBox.Items.AddRange(new object[] {
            "128 Bit",
            "192 Bit",
            "256 Bit"});
            this.aesKeySize_comboBox.Location = new System.Drawing.Point(6, 23);
            this.aesKeySize_comboBox.Name = "aesKeySize_comboBox";
            this.aesKeySize_comboBox.Size = new System.Drawing.Size(150, 23);
            this.aesKeySize_comboBox.TabIndex = 2;
            // 
            // encryption_button
            // 
            this.encryption_button.BackColor = System.Drawing.Color.SeaGreen;
            this.encryption_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encryption_button.Image = global::FFCryptoGUI.Properties.Resources.encryption_icon_big;
            this.encryption_button.Location = new System.Drawing.Point(376, 20);
            this.encryption_button.Name = "encryption_button";
            this.encryption_button.Size = new System.Drawing.Size(95, 92);
            this.encryption_button.TabIndex = 3;
            this.encryption_button.Text = "暗号化";
            this.encryption_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.encryption_button.UseVisualStyleBackColor = false;
            this.encryption_button.Click += new System.EventHandler(this.Encryption_button_Click);
            // 
            // decryption_button
            // 
            this.decryption_button.BackColor = System.Drawing.Color.IndianRed;
            this.decryption_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.decryption_button.Image = global::FFCryptoGUI.Properties.Resources.decryption_icon_big;
            this.decryption_button.Location = new System.Drawing.Point(484, 20);
            this.decryption_button.Name = "decryption_button";
            this.decryption_button.Size = new System.Drawing.Size(92, 92);
            this.decryption_button.TabIndex = 4;
            this.decryption_button.Text = "復号化";
            this.decryption_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.decryption_button.UseVisualStyleBackColor = false;
            this.decryption_button.Click += new System.EventHandler(this.Decryption_button_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.set_collectFolder_checkBox);
            this.groupBox7.Controls.Add(this.set_enc_randomName_checkBox);
            this.groupBox7.Controls.Add(this.set_enc_saveFileInfo_checkBox);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox7.Location = new System.Drawing.Point(6, 122);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(175, 102);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "暗号化設定";
            // 
            // set_collectFolder_checkBox
            // 
            this.set_collectFolder_checkBox.AutoSize = true;
            this.set_collectFolder_checkBox.Checked = true;
            this.set_collectFolder_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_collectFolder_checkBox.Location = new System.Drawing.Point(13, 72);
            this.set_collectFolder_checkBox.Name = "set_collectFolder_checkBox";
            this.set_collectFolder_checkBox.Size = new System.Drawing.Size(144, 19);
            this.set_collectFolder_checkBox.TabIndex = 11;
            this.set_collectFolder_checkBox.Text = "フォルダはまとめて暗号化";
            this.settings_toolTip.SetToolTip(this.set_collectFolder_checkBox, "フォルダを一旦Zipファイルにまとめてから暗号化するかどうかです。");
            this.set_collectFolder_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_enc_randomName_checkBox
            // 
            this.set_enc_randomName_checkBox.AutoSize = true;
            this.set_enc_randomName_checkBox.Location = new System.Drawing.Point(13, 47);
            this.set_enc_randomName_checkBox.Name = "set_enc_randomName_checkBox";
            this.set_enc_randomName_checkBox.Size = new System.Drawing.Size(144, 19);
            this.set_enc_randomName_checkBox.TabIndex = 6;
            this.set_enc_randomName_checkBox.Text = "ファイル名をランダムにする";
            this.settings_toolTip.SetToolTip(this.set_enc_randomName_checkBox, "暗号化したのち、ファイル名をランダムにするかどうかです。");
            this.set_enc_randomName_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_enc_saveFileInfo_checkBox
            // 
            this.set_enc_saveFileInfo_checkBox.AutoSize = true;
            this.set_enc_saveFileInfo_checkBox.Checked = true;
            this.set_enc_saveFileInfo_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_enc_saveFileInfo_checkBox.Location = new System.Drawing.Point(13, 22);
            this.set_enc_saveFileInfo_checkBox.Name = "set_enc_saveFileInfo_checkBox";
            this.set_enc_saveFileInfo_checkBox.Size = new System.Drawing.Size(136, 19);
            this.set_enc_saveFileInfo_checkBox.TabIndex = 5;
            this.set_enc_saveFileInfo_checkBox.Text = "ファイル情報を保持する";
            this.settings_toolTip.SetToolTip(this.set_enc_saveFileInfo_checkBox, "チェックを外すと、ファイル情報・暗号化設定の保存、パスワード照合・データ照合機能が無効になります。");
            this.set_enc_saveFileInfo_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_removeFiles_checkBox
            // 
            this.set_removeFiles_checkBox.AutoSize = true;
            this.set_removeFiles_checkBox.Checked = true;
            this.set_removeFiles_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_removeFiles_checkBox.Location = new System.Drawing.Point(12, 22);
            this.set_removeFiles_checkBox.Name = "set_removeFiles_checkBox";
            this.set_removeFiles_checkBox.Size = new System.Drawing.Size(134, 19);
            this.set_removeFiles_checkBox.TabIndex = 6;
            this.set_removeFiles_checkBox.Text = "元のファイルを削除する";
            this.settings_toolTip.SetToolTip(this.set_removeFiles_checkBox, "暗号化・復号化したのちに、元のファイルを削除するかどうかです。");
            this.set_removeFiles_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_removeFolderFillZero_checkBox
            // 
            this.set_removeFolderFillZero_checkBox.AutoSize = true;
            this.set_removeFolderFillZero_checkBox.Location = new System.Drawing.Point(12, 47);
            this.set_removeFolderFillZero_checkBox.Name = "set_removeFolderFillZero_checkBox";
            this.set_removeFolderFillZero_checkBox.Size = new System.Drawing.Size(148, 19);
            this.set_removeFolderFillZero_checkBox.TabIndex = 7;
            this.set_removeFolderFillZero_checkBox.Text = "元ファイルを完全削除する";
            this.settings_toolTip.SetToolTip(this.set_removeFolderFillZero_checkBox, "暗号化・復号化したのちに、ファイルを0x00で埋めるかどうかです。");
            this.set_removeFolderFillZero_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.set_allFiles_checkBox);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.set_forceWrite_checkBox);
            this.groupBox8.Controls.Add(this.set_removeFolderFillZero_checkBox);
            this.groupBox8.Controls.Add(this.groupBox7);
            this.groupBox8.Controls.Add(this.set_removeFiles_checkBox);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox8.Location = new System.Drawing.Point(376, 75);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(187, 315);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "コマンド設定";
            // 
            // set_allFiles_checkBox
            // 
            this.set_allFiles_checkBox.AutoSize = true;
            this.set_allFiles_checkBox.Location = new System.Drawing.Point(12, 97);
            this.set_allFiles_checkBox.Name = "set_allFiles_checkBox";
            this.set_allFiles_checkBox.Size = new System.Drawing.Size(160, 19);
            this.set_allFiles_checkBox.TabIndex = 10;
            this.set_allFiles_checkBox.Text = "すべてのファイルを対象とする";
            this.settings_toolTip.SetToolTip(this.set_allFiles_checkBox, ".ffcファイルを検索対象内に含めるかどうかです。多重暗号化を防ぎたい場合はチェックを外してください。");
            this.set_allFiles_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.set_dec_restoreFilePath_checkBox);
            this.groupBox9.Controls.Add(this.set_dec_restoreInfo_checkBox);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox9.Location = new System.Drawing.Point(6, 230);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(175, 73);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "復号化設定";
            // 
            // set_dec_restoreFilePath_checkBox
            // 
            this.set_dec_restoreFilePath_checkBox.AutoSize = true;
            this.set_dec_restoreFilePath_checkBox.Location = new System.Drawing.Point(13, 47);
            this.set_dec_restoreFilePath_checkBox.Name = "set_dec_restoreFilePath_checkBox";
            this.set_dec_restoreFilePath_checkBox.Size = new System.Drawing.Size(146, 19);
            this.set_dec_restoreFilePath_checkBox.TabIndex = 6;
            this.set_dec_restoreFilePath_checkBox.Text = "ファイルを元の場所に戻す";
            this.settings_toolTip.SetToolTip(this.set_dec_restoreFilePath_checkBox, "復号化するときに、元あったフォルダの場所に戻すかどうかです。フォルダが存在しない場合は作成されます。");
            this.set_dec_restoreFilePath_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_dec_restoreInfo_checkBox
            // 
            this.set_dec_restoreInfo_checkBox.AutoSize = true;
            this.set_dec_restoreInfo_checkBox.Checked = true;
            this.set_dec_restoreInfo_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.set_dec_restoreInfo_checkBox.Location = new System.Drawing.Point(13, 22);
            this.set_dec_restoreInfo_checkBox.Name = "set_dec_restoreInfo_checkBox";
            this.set_dec_restoreInfo_checkBox.Size = new System.Drawing.Size(136, 19);
            this.set_dec_restoreInfo_checkBox.TabIndex = 5;
            this.set_dec_restoreInfo_checkBox.Text = "ファイル情報を復元する";
            this.settings_toolTip.SetToolTip(this.set_dec_restoreInfo_checkBox, "ファイル名、ファイル属性などのファイル情報を復元するかどうかです。「ファイル情報を保持する」のチェックがされていないときにした暗号化ファイルには使用できません。");
            this.set_dec_restoreInfo_checkBox.UseVisualStyleBackColor = true;
            // 
            // set_forceWrite_checkBox
            // 
            this.set_forceWrite_checkBox.AutoSize = true;
            this.set_forceWrite_checkBox.Location = new System.Drawing.Point(12, 72);
            this.set_forceWrite_checkBox.Name = "set_forceWrite_checkBox";
            this.set_forceWrite_checkBox.Size = new System.Drawing.Size(114, 19);
            this.set_forceWrite_checkBox.TabIndex = 8;
            this.set_forceWrite_checkBox.Text = "強制的に書き込む";
            this.settings_toolTip.SetToolTip(this.set_forceWrite_checkBox, "暗号化・復号化したのち、ファイルが存在しても強制的に書き込むかどうかです。チェックされていない場合、[ファイル名](番号)(拡張子)で保存されます。");
            this.set_forceWrite_checkBox.UseVisualStyleBackColor = true;
            // 
            // cryptoSettings_panel
            // 
            this.cryptoSettings_panel.AutoScroll = true;
            this.cryptoSettings_panel.Controls.Add(this.compressLevel_groupBox);
            this.cryptoSettings_panel.Controls.Add(this.restoreSettings_button);
            this.cryptoSettings_panel.Controls.Add(this.hide_button);
            this.cryptoSettings_panel.Controls.Add(this.groupBox10);
            this.cryptoSettings_panel.Controls.Add(this.groupBox3);
            this.cryptoSettings_panel.Controls.Add(this.groupBox8);
            this.cryptoSettings_panel.Location = new System.Drawing.Point(0, 118);
            this.cryptoSettings_panel.Name = "cryptoSettings_panel";
            this.cryptoSettings_panel.Size = new System.Drawing.Size(587, 291);
            this.cryptoSettings_panel.TabIndex = 7;
            this.cryptoSettings_panel.Visible = false;
            // 
            // compressLevel_groupBox
            // 
            this.compressLevel_groupBox.Controls.Add(this.compressLevel_trackBar);
            this.compressLevel_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.compressLevel_groupBox.Location = new System.Drawing.Point(12, 244);
            this.compressLevel_groupBox.Name = "compressLevel_groupBox";
            this.compressLevel_groupBox.Size = new System.Drawing.Size(354, 77);
            this.compressLevel_groupBox.TabIndex = 10;
            this.compressLevel_groupBox.TabStop = false;
            this.compressLevel_groupBox.Text = "圧縮レベル: 7";
            // 
            // compressLevel_trackBar
            // 
            this.compressLevel_trackBar.Location = new System.Drawing.Point(11, 22);
            this.compressLevel_trackBar.Maximum = 9;
            this.compressLevel_trackBar.Name = "compressLevel_trackBar";
            this.compressLevel_trackBar.Size = new System.Drawing.Size(330, 45);
            this.compressLevel_trackBar.TabIndex = 0;
            this.compressLevel_trackBar.Value = 7;
            this.compressLevel_trackBar.Scroll += new System.EventHandler(this.CompressLevel_trackBar_Scroll);
            // 
            // restoreSettings_button
            // 
            this.restoreSettings_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.restoreSettings_button.Location = new System.Drawing.Point(191, 327);
            this.restoreSettings_button.Name = "restoreSettings_button";
            this.restoreSettings_button.Size = new System.Drawing.Size(175, 63);
            this.restoreSettings_button.TabIndex = 9;
            this.restoreSettings_button.Text = "設定の初期化";
            this.restoreSettings_button.UseVisualStyleBackColor = true;
            this.restoreSettings_button.Click += new System.EventHandler(this.RestoreSettings_button_Click);
            // 
            // hide_button
            // 
            this.hide_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hide_button.Location = new System.Drawing.Point(12, 327);
            this.hide_button.Name = "hide_button";
            this.hide_button.Size = new System.Drawing.Size(173, 63);
            this.hide_button.TabIndex = 8;
            this.hide_button.Text = "隠す";
            this.hide_button.UseVisualStyleBackColor = true;
            this.hide_button.Click += new System.EventHandler(this.Hide_button_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox10.Controls.Add(this.clearOutPath_button);
            this.groupBox10.Controls.Add(this.set_outFilder_button);
            this.groupBox10.Controls.Add(this.output_textBox);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox10.Location = new System.Drawing.Point(12, 7);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(551, 57);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "出力先フォルダパス";
            // 
            // clearOutPath_button
            // 
            this.clearOutPath_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearOutPath_button.Location = new System.Drawing.Point(484, 22);
            this.clearOutPath_button.Name = "clearOutPath_button";
            this.clearOutPath_button.Size = new System.Drawing.Size(61, 23);
            this.clearOutPath_button.TabIndex = 2;
            this.clearOutPath_button.Text = "クリア";
            this.clearOutPath_button.UseVisualStyleBackColor = true;
            this.clearOutPath_button.Click += new System.EventHandler(this.ClearOutPath_button_Click);
            // 
            // set_outFilder_button
            // 
            this.set_outFilder_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.set_outFilder_button.Image = global::FFCryptoGUI.Properties.Resources.folder_icon;
            this.set_outFilder_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.set_outFilder_button.Location = new System.Drawing.Point(364, 22);
            this.set_outFilder_button.Name = "set_outFilder_button";
            this.set_outFilder_button.Size = new System.Drawing.Size(114, 23);
            this.set_outFilder_button.TabIndex = 1;
            this.set_outFilder_button.Text = "フォルダを開く ...";
            this.set_outFilder_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settings_toolTip.SetToolTip(this.set_outFilder_button, "暗号化・復号化したファイルを出力するフォルダを指定できます。");
            this.set_outFilder_button.UseVisualStyleBackColor = true;
            this.set_outFilder_button.Click += new System.EventHandler(this.Set_outFilder_button_Click);
            // 
            // output_textBox
            // 
            this.output_textBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.output_textBox.ForeColor = System.Drawing.SystemColors.Control;
            this.output_textBox.Location = new System.Drawing.Point(11, 22);
            this.output_textBox.Name = "output_textBox";
            this.output_textBox.ReadOnly = true;
            this.output_textBox.Size = new System.Drawing.Size(343, 23);
            this.output_textBox.TabIndex = 0;
            // 
            // hightLevelSettings_button
            // 
            this.hightLevelSettings_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hightLevelSettings_button.Location = new System.Drawing.Point(195, 222);
            this.hightLevelSettings_button.Name = "hightLevelSettings_button";
            this.hightLevelSettings_button.Size = new System.Drawing.Size(186, 66);
            this.hightLevelSettings_button.TabIndex = 8;
            this.hightLevelSettings_button.Text = "高度な設定";
            this.hightLevelSettings_button.UseVisualStyleBackColor = true;
            this.hightLevelSettings_button.Click += new System.EventHandler(this.HightLevelSettings_button_Click);
            // 
            // output_folderBrowserDialog
            // 
            this.output_folderBrowserDialog.Description = "出力先フォルダの指定";
            // 
            // settings_toolTip
            // 
            this.settings_toolTip.AutoPopDelay = 10000;
            this.settings_toolTip.InitialDelay = 500;
            this.settings_toolTip.ReshowDelay = 100;
            // 
            // CryptoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(588, 421);
            this.Controls.Add(this.cryptoSettings_panel);
            this.Controls.Add(this.decryption_button);
            this.Controls.Add(this.encryption_button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hightLevelSettings_button);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CryptForm";
            this.Load += new System.EventHandler(this.CryptForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.cryptoSettings_panel.ResumeLayout(false);
            this.compressLevel_groupBox.ResumeLayout(false);
            this.compressLevel_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressLevel_trackBar)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button encryption_button;
        private System.Windows.Forms.Button decryption_button;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox password2_textBox;
        private System.Windows.Forms.TextBox password1_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox password2_checkBox;
        private System.Windows.Forms.CheckBox password1_checkBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox set_removeFolderFillZero_checkBox;
        private System.Windows.Forms.CheckBox set_removeFiles_checkBox;
        private System.Windows.Forms.CheckBox set_enc_saveFileInfo_checkBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox set_enc_randomName_checkBox;
        private System.Windows.Forms.CheckBox set_forceWrite_checkBox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox set_dec_restoreInfo_checkBox;
        private System.Windows.Forms.CheckBox set_allFiles_checkBox;
        private System.Windows.Forms.CheckBox set_dec_restoreFilePath_checkBox;
        private System.Windows.Forms.Panel cryptoSettings_panel;
        private System.Windows.Forms.Button hightLevelSettings_button;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox output_textBox;
        private System.Windows.Forms.Button set_outFilder_button;
        private System.Windows.Forms.FolderBrowserDialog output_folderBrowserDialog;
        private System.Windows.Forms.Button clearOutPath_button;
        private System.Windows.Forms.Button hide_button;
        private System.Windows.Forms.Button restoreSettings_button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox aesMode_comboBox;
        private System.Windows.Forms.ComboBox aesPadding_comboBox;
        private System.Windows.Forms.ComboBox aesBlockSize_comboBox;
        private System.Windows.Forms.ComboBox aesKeySize_comboBox;
        private System.Windows.Forms.GroupBox compressLevel_groupBox;
        private System.Windows.Forms.TrackBar compressLevel_trackBar;
        private System.Windows.Forms.ToolTip settings_toolTip;
        private System.Windows.Forms.CheckBox set_collectFolder_checkBox;
    }
}