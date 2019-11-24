using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFCryptGUI.Forms
{
    public partial class CryptoForm : Form
    {
        public CryptoForm()
        {
            InitializeComponent();
        }

        private void CryptForm_Load(object sender, EventArgs e)
        {
            showedDetailsSetting = cryptoSettings_panel.Visible;
            if (aesMode_comboBox.SelectedIndex == -1)
                aesMode_comboBox.SelectedIndex = 0;
            if (aesKeySize_comboBox.SelectedIndex == -1)
                aesKeySize_comboBox.SelectedIndex = 2;
            if (aesBlockSize_comboBox.SelectedIndex == -1)
                aesBlockSize_comboBox.SelectedIndex = 0;
            if (aesPadding_comboBox.SelectedIndex == -1)
                aesPadding_comboBox.SelectedIndex = 0;
        }

        public Main MainForm = null; // メインフォームのコントロール

        private bool showedDetailsSetting = false; // 高度な設定を表示するかどうか

        /// <summary>
        /// 暗号化するのに必要なコマンド引数の書き出し
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetSettingsInfo()
        {
            Dictionary<string, string> tmpDict = new Dictionary<string, string>()
            {
                { "no-del-file", "" },
                { "fill-zero-del", ""},
                { "rand-name", "" },
                { "no-original", "" },
                { "all-file-select", ""},
                { "no-restore-file-info", "" },
                { "restore-path", "" },
                { "forece-write", "" }
            };

            if (aesMode_comboBox.SelectedIndex == 1)
                tmpDict["aes_mode"] = "--cfb";
            else if (aesMode_comboBox.SelectedIndex == 2)
                tmpDict["aes_mode"] = "--cts";
            else if (aesMode_comboBox.SelectedIndex == 3)
                tmpDict["aes_mode"] = "--ofb";
            else if (aesMode_comboBox.SelectedIndex == 4)
                tmpDict["aes_mode"] = "--ecb";
            else
                tmpDict["aes_mode"] = "--cbc";

            if (aesKeySize_comboBox.SelectedIndex == 0)
                tmpDict["aes_key"] = "--k128";
            else if (aesKeySize_comboBox.SelectedIndex == 1)
                tmpDict["aes_key"] = "--k192";
            else
                tmpDict["aes_key"] = "--k256";

            if (aesBlockSize_comboBox.SelectedIndex == 0)
                tmpDict["aes_block"] = "--b128";
            else if (aesBlockSize_comboBox.SelectedIndex == 1)
                tmpDict["aes_block"] = "--b192";
            else
                tmpDict["aes_block"] = "--b256";

            if (aesPadding_comboBox.SelectedIndex == 1)
                tmpDict["aes_padding"] = "--ansix923";
            else if (aesPadding_comboBox.SelectedIndex == 2)
                tmpDict["aes_padding"] = "--iso10126";
            else
                tmpDict["aes_padding"] = "--pkcs7";

            tmpDict["pass"] = "-pass \""+ password1_textBox.Text+"\"";
            if (output_textBox.Text == "")
                tmpDict["outpath"] = "";
            else
                tmpDict["outpath"] = "-out \""+ output_textBox.Text +"\"";

            tmpDict["complress-level"] = "-cl " + compressLevel_trackBar.Value.ToString();

            if (!set_removeFiles_checkBox.Checked)
                tmpDict["no-del-file"] = "--ndf";
            if (set_removeFolderFillZero_checkBox.Checked)
                tmpDict["fill-zero-del"] = "--fzd";
            if (set_enc_randomName_checkBox.Checked)
                tmpDict["rand-name"] = "--rn";
            if (!set_enc_saveFileInfo_checkBox.Checked)
                tmpDict["no-original"] = "--no";
            if (set_allFiles_checkBox.Checked)
                tmpDict["all-file-select"] = "--afs";
            if (!set_dec_restoreInfo_checkBox.Checked)
                tmpDict["no-restore-info"] = "--nri";
            if (set_dec_restoreFilePath_checkBox.Checked)
                tmpDict["restore-path"] = "--rp";
            if (set_forceWrite_checkBox.Checked)
                tmpDict["force-write"] = "--fw";
            if (set_collectFolder_checkBox.Checked)
                tmpDict["compress-folder"] = "--cf";

            return tmpDict;
        }

        /// <summary>
        /// 設定データ読み出し
        /// </summary>
        public Dictionary<string,string> Settings
        {
            get
            {
                checkAesCombobox();
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                tmpDict["show_details_set"] = showedDetailsSetting.ToString();
                tmpDict["password1"] = password1_textBox.Text;
                tmpDict["password2"] = password2_textBox.Text;
                tmpDict["out_path"] = output_textBox.Text;
                tmpDict["aes_mode"] = aesMode_comboBox.SelectedIndex.ToString();
                tmpDict["aes_padding"] = aesPadding_comboBox.SelectedIndex.ToString();
                tmpDict["aes_block_size"] = aesBlockSize_comboBox.SelectedIndex.ToString();
                tmpDict["aes_key_size"] = aesKeySize_comboBox.SelectedIndex.ToString();
                tmpDict["compress_level"] = compressLevel_trackBar.Value.ToString();

                tmpDict["set_remove_files"] = set_removeFiles_checkBox.Checked.ToString();
                tmpDict["set_folder_fill_zero"] = set_removeFolderFillZero_checkBox.Checked.ToString();
                tmpDict["set_force_write"] = set_forceWrite_checkBox.Checked.ToString();
                tmpDict["set_all_files"] = set_allFiles_checkBox.Checked.ToString();
                tmpDict["set_enc_save_file_info"] = set_enc_saveFileInfo_checkBox.Checked.ToString();
                tmpDict["set_enc_random_name"] = set_enc_randomName_checkBox.Checked.ToString();
                tmpDict["set_enc_compress_folder"] = set_collectFolder_checkBox.Checked.ToString();
                tmpDict["set_dec_restore_info"] = set_dec_restoreInfo_checkBox.Checked.ToString();
                tmpDict["set_dec_restore_file_path"] = set_dec_restoreFilePath_checkBox.Checked.ToString();

                return tmpDict;
            }
            set
            {
                Dictionary<string, string> tmpDict = value;

                try
                {
                    password1_textBox.Text = tmpDict["password1"];
                    password2_textBox.Text = tmpDict["password2"];
                    output_textBox.Text = tmpDict["out_path"];
                    aesMode_comboBox.SelectedIndex = int.Parse(tmpDict["aes_mode"]);
                    aesKeySize_comboBox.SelectedIndex = int.Parse(tmpDict["aes_key_size"]);
                    aesBlockSize_comboBox.SelectedIndex = int.Parse(tmpDict["aes_block_size"]);
                    aesPadding_comboBox.SelectedIndex = int.Parse(tmpDict["aes_padding"]);
                    compressLevel_trackBar.Value = int.Parse(tmpDict["compress_level"]);

                    set_removeFiles_checkBox.Checked = bool.Parse(tmpDict["set_remove_files"]);
                    set_removeFolderFillZero_checkBox.Checked = bool.Parse(tmpDict["set_folder_fill_zero"]);
                    set_forceWrite_checkBox.Checked = bool.Parse(tmpDict["set_force_write"]);
                    set_allFiles_checkBox.Checked = bool.Parse(tmpDict["set_all_files"]);
                    set_enc_saveFileInfo_checkBox.Checked = bool.Parse(tmpDict["set_enc_save_file_info"]);
                    set_enc_randomName_checkBox.Checked = bool.Parse(tmpDict["set_enc_random_name"]);
                    set_collectFolder_checkBox.Checked = bool.Parse(tmpDict["set_enc_compress_folder"]);
                    set_dec_restoreInfo_checkBox.Checked = bool.Parse(tmpDict["set_dec_restore_info"]);
                    set_dec_restoreFilePath_checkBox.Checked = bool.Parse(tmpDict["set_dec_restore_file_path"]);
                    cryptoSettings_panel.Visible = bool.Parse(tmpDict["show_details_set"]);
                    showedDetailsSetting = cryptoSettings_panel.Visible;
                    checkAesCombobox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("タブ:'暗号化設定' の状態を一部復元できませんでした:\r\n"+ ex.ToString(), "読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 高度な設定の表示ボタンのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HightLevelSettings_button_Click(object sender, EventArgs e)
        {
            cryptoSettings_panel.Visible = true;
            showedDetailsSetting = true;
        }

        /// <summary>
        /// AES設定コンボボックスの値チェック
        /// </summary>
        private void checkAesCombobox()
        {
            if (aesMode_comboBox.SelectedIndex < 0)
                aesMode_comboBox.SelectedIndex = 0;
            if (aesKeySize_comboBox.SelectedIndex < 0)
                aesKeySize_comboBox.SelectedIndex = 2;
            if (aesBlockSize_comboBox.SelectedIndex < 0)
                aesBlockSize_comboBox.SelectedIndex = 0;
            if (aesPadding_comboBox.SelectedIndex < 0)
                aesPadding_comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 暗号化実行ボタンのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encryption_button_Click(object sender, EventArgs e)
        {
            if (password1_textBox.Text != "" & password2_textBox.Text != "")
            {
                if (password1_textBox.Text == password2_textBox.Text)
                {
                    // パスワードが入力されている且つ完全に一致しているときのみ実行
                    MainForm.StartCryptoProgram(true);
                }
                else
                {
                    MessageBox.Show("パスワードが一致しません。", "暗号化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("パスワードを入力してください。", "暗号化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 復号化実行ボタンのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decryption_button_Click(object sender, EventArgs e)
        {
            if (password1_textBox.Text != "")
            {
                MainForm.StartCryptoProgram(false);
            }
            else
            {
                MessageBox.Show("パスワードを入力してください。", "復号化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ファイル圧縮レベルの選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompressLevel_trackBar_Scroll(object sender, EventArgs e)
        {
            compressLevel_groupBox.Text = "圧縮レベル: " + compressLevel_trackBar.Value.ToString();
        }

        /// <summary>
        /// 暗号化・復号化されたファイルの出力先フォルダの指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_outFilder_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = output_folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
                output_textBox.Text = output_folderBrowserDialog.SelectedPath;
        }

        // 出力先フォルダパスをクリア
        private void ClearOutPath_button_Click(object sender, EventArgs e)
        {
            output_textBox.Text = "";
        }

        // パスワードを表示するかどうか
        private void Password1_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            password1_textBox.UseSystemPasswordChar = !password1_checkBox.Checked;
        }

        private void Password2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            password2_textBox.UseSystemPasswordChar = !password2_checkBox.Checked;
        }

        /// <summary>
        /// 高度な設定を隠す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_button_Click(object sender, EventArgs e)
        {
            cryptoSettings_panel.Visible = false;
            showedDetailsSetting = false;
        }

        /// <summary>
        /// 暗号化・復号化設定を初期化する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestoreSettings_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("暗号化・復号化設定を初期化しますか？", "初期化", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (dr == DialogResult.No)
                return;

            output_textBox.Text = "";
            

            set_removeFiles_checkBox.Checked = true;
            set_removeFolderFillZero_checkBox.Checked = false;
            set_forceWrite_checkBox.Checked = false;
            set_allFiles_checkBox.Checked = false;
            set_enc_saveFileInfo_checkBox.Checked = true;
            set_enc_randomName_checkBox.Checked = false;
            set_dec_restoreInfo_checkBox.Checked = true;
            set_dec_restoreFilePath_checkBox.Checked = false;
        }
    }
}
