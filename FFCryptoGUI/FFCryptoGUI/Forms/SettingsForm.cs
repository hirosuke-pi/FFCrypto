using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace FFCryptGUI.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        public Main MainForm = null; // メインフォームのコントロール

        public bool PermitWroteSettings { get { return set_saveSettings_checkBox.Checked; } set { set_saveSettings_checkBox.Checked = value; } } // 設定データの書き出しが許可されているかどうか
        public bool PermitSavingMainFFCP { get { return saveMainFFCP_checkBox.Checked; } set { saveMainFFCP_checkBox.Checked = value; } } // 起動時の設定データの読み出しが許可されているかどうか
        public bool MinimizeNotifyIcon = false; // 最小化時は通知領域にアイコンを表示するかどうか
        public bool IsCheckingPassHash = true; // パスワードハッシュ照合するかどうか

        /// <summary>
        /// HMACハッシュコード(SHA256)とソルト
        /// </summary>
        public string[] HashCode
        {
            get
            {
                return new string[] { hash_textBox.Text, salt_textBox.Text };
            }
            set
            {
                hash_textBox.Text = value[0];
                salt_textBox.Text = value[1];
            }
        }

        /// <summary>
        /// 設定データ読み出し口
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get
            {
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();

                // チェックボックスの設定
                tmpDict["project_show_notify_icon"] = set_showNotifyIcon_checkBox.Checked.ToString();
                tmpDict["project_save_settings"] = set_saveSettings_checkBox.Checked.ToString();
                tmpDict["project_minimize_notify_icon"] = set_minimize_notify_checkBox.Checked.ToString();
                tmpDict["project_save_pass"] = set_savePassword_radioButton.Checked.ToString();
                tmpDict["project_save_pass_hash"] = set_savePasswordWithHash_radioButton.Checked.ToString();
                tmpDict["project_no_save_pass"] = set_noSavePassword_radioButton.Checked.ToString();
                tmpDict["pass_hash"] = hash_textBox.Text;
                tmpDict["pass_salt"] = salt_textBox.Text;
                

                return tmpDict;
            }
            set
            {
                try
                {
                    Dictionary<string, string> tmpDict = value;
                    hash_textBox.Text = tmpDict["pass_hash"];
                    salt_textBox.Text = tmpDict["pass_salt"];

                    // チェックボックスの設定
                    set_showNotifyIcon_checkBox.Checked = bool.Parse(tmpDict["project_show_notify_icon"]);
                    set_saveSettings_checkBox.Checked = bool.Parse(tmpDict["project_save_settings"]);
                    set_minimize_notify_checkBox.Checked = bool.Parse(tmpDict["project_minimize_notify_icon"]);
                    MinimizeNotifyIcon = set_minimize_notify_checkBox.Checked;
                    set_savePassword_radioButton.Checked = bool.Parse(tmpDict["project_save_pass"]);
                    set_noSavePassword_radioButton.Checked = bool.Parse(tmpDict["project_no_save_pass"]);
                    set_savePasswordWithHash_radioButton.Checked = bool.Parse(tmpDict["project_save_pass_hash"]);
                    IsCheckingPassHash = set_savePasswordWithHash_radioButton.Checked;

                    set_showTop_checkBox.Checked = bool.Parse(tmpDict["main_top_most"]);
                    set_opacity_trackBar.Value = (int)(double.Parse(tmpDict["main_opacity"]) * 100);
                    windowSet_groupBox.Text = "ウィンドウ設定 (透明度: " + set_opacity_trackBar.Value.ToString() + "%)";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("タブ:'プロジェクト設定' の状態を一部復元できませんでした:\r\n"+ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// プロジェクトを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProjectOpen_button_Click(object sender, EventArgs e)
        {
            string filePath = "";

            DialogResult po = projectFile_openFileDialog.ShowDialog();
            if (po == DialogResult.OK)
                filePath = projectFile_openFileDialog.FileName;
            else
                return;

            // プロジェクトの読み出し
            if (MainForm.LoadAndSetProjectFile(filePath))
            {
                MessageBox.Show("プロジェクトファイル: " + filePath + " を適用しました。", Path.GetFileNameWithoutExtension(filePath), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// プロジェクトを保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProjectSave_button_Click(object sender, EventArgs e)
        {
            string filePath = "";

            projectFile_saveFileDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff") + ".ffcp";
            DialogResult dr = projectFile_saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
                filePath = projectFile_saveFileDialog.FileName;
            else
                return;

            // プロジェクトデータの書き出し
            bool success = MainForm.WriteSettingsData(filePath, false);
            if (success)
            {
                projectFile_textBox.Text = filePath;
                MessageBox.Show("プロジェクトファイル: " + filePath + " を保存しました。", Path.GetFileNameWithoutExtension(filePath), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            saveMainFFCP_checkBox.Checked = false;
        }


        /// <summary>
        /// すべての設定を初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initialize_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("設定されたすべての情報を初期化し、デフォルト状態に戻します。よろしいですか？", "初期化", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                MainForm.InitializeSettings();
        }


        // チェックボックスのイベント
        private void Set_opacity_trackBar_Scroll(object sender, EventArgs e)
        {
            MainForm.Opacity = ((double)set_opacity_trackBar.Value * 0.01);
            windowSet_groupBox.Text = "ウィンドウ設定 (透明度: "+ set_opacity_trackBar.Value.ToString() +"%)";
        }

        private void Set_showTop_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.TopMost = set_showTop_checkBox.Checked;
        }

        private void Set_showNotifyIcon_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.ffc_notifyIcon.Visible = set_showNotifyIcon_checkBox.Checked;
        }

        private void Set_minimize_notify_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            MinimizeNotifyIcon = set_minimize_notify_checkBox.Checked;
        }

        private void Set_savePasswordWithHash_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsCheckingPassHash = set_savePasswordWithHash_radioButton.Checked;
        }

        private void Set_ffcFile_button_Click(object sender, EventArgs e)
        {
            setExtensionAssociate(".ffc", "FFCrypto暗号化ファイル");
        }

        private void Set_ffcpFile_button_Click(object sender, EventArgs e)
        {
            setExtensionAssociate(".ffcp", "FFCryptoプロジェクトファイル");
        }

        /// <summary>
        /// コンテキストメニューに追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContextMenu_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdministrator())
                {
                    
                    string iconPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string commandLine = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\" \"%1\"";
                    RegistryKey rootkey = Registry.ClassesRoot;

                    // エクスプローラのコンテキストメニューに追加 (フォルダ)
                    RegistryKey cmdKeyDirectoryExplorer = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\FFCryptoGUI\\command");
                    cmdKeyDirectoryExplorer.SetValue("", commandLine);
                    cmdKeyDirectoryExplorer.Close();

                    RegistryKey verbkeyDirec = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\FFCryptoGUI");
                    verbkeyDirec.SetValue("", "FFCryptoGUIで開く (&F)");
                    verbkeyDirec.Close();

                    RegistryKey iconkeyDirec = rootkey.CreateSubKey("Directory\\shell\\FFCryptoGUI");
                    iconkeyDirec.SetValue("Icon", iconPath);
                    iconkeyDirec.Close();

                    // エクスプローラのコンテキストメニュー (ファイル)
                    RegistryKey cmdKeyFileExplorer = Registry.ClassesRoot.CreateSubKey("*\\shell\\FFCryptoGUI\\command");
                    cmdKeyFileExplorer.SetValue("", commandLine);
                    cmdKeyFileExplorer.Close();

                    RegistryKey verbkeyFile = Registry.ClassesRoot.CreateSubKey("*\\shell\\FFCryptoGUI");
                    verbkeyFile.SetValue("", "FFCryptoGUIで開く (&F)");
                    verbkeyFile.Close();

                    RegistryKey iconkeyFile = rootkey.CreateSubKey("*\\shell\\FFCryptoGUI");
                    iconkeyFile.SetValue("Icon", iconPath);
                    iconkeyFile.Close();
                    MessageBox.Show("コンテキストメニューの追加に成功しました。", "ファイル関連付け", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("ファイル関連付けには管理者権限が必要です。管理者に昇格してから実行してください。", "コンテキストメニューに追加", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("コンテキストメニューの追加に失敗しました:\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ファイル拡張子を関連付ける (管理者権限)
        /// </summary>
        /// <param name="extension">拡張子</param>
        /// <param name="description">説明</param>
        private void setExtensionAssociate(string extension, string description)
        {
            try
            {
                if (isAdministrator())
                {
                    
                    string commandLine = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\" \"%1\"";
                    string fileType = Application.ProductName + extension;
                    string verb = "open";
                    string verbDescription = "FFCryptoGUIで開く";
                    string iconPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    int iconIndex = 0;

                    // ファイル拡張子関連付け
                    RegistryKey rootkey = Registry.ClassesRoot;
                    RegistryKey regkey = rootkey.CreateSubKey(extension);
                    regkey.SetValue("", fileType);
                    regkey.Close();

                    RegistryKey typekey = rootkey.CreateSubKey(fileType);
                    typekey.SetValue("", description);
                    typekey.Close();

                    RegistryKey verblkey = rootkey.CreateSubKey(fileType + "\\shell\\" + verb);
                    verblkey.SetValue("", verbDescription);
                    verblkey.Close();

                    RegistryKey cmdkey = rootkey.CreateSubKey(fileType + "\\shell\\" + verb + "\\command");
                    cmdkey.SetValue("", commandLine);
                    cmdkey.Close();

                    RegistryKey iconkey = rootkey.CreateSubKey(fileType + "\\DefaultIcon");
                    iconkey.SetValue("", iconPath + "," + iconIndex.ToString());
                    iconkey.Close();

                    MessageBox.Show("ファイル関連付けが完了しました。", "ファイル関連付け", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("ファイル関連付けには管理者権限が必要です。管理者に昇格してから実行してください。", "ファイル関連付け", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ファイル関連付けに失敗しました:\r\n"+ ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 管理者権限かどうかのチェック
        /// </summary>
        /// <returns></returns>
        private bool isAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// ファイル関連付けの解除(管理者権限)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_remove_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdministrator())
                {
                    // 該当するレジストリキーを削除
                    Registry.ClassesRoot.DeleteSubKeyTree(".ffc");
                    Registry.ClassesRoot.DeleteSubKeyTree(Application.ProductName + ".ffc");
                    Registry.ClassesRoot.DeleteSubKeyTree(".ffcp");
                    Registry.ClassesRoot.DeleteSubKeyTree(Application.ProductName + ".ffcp");
                    Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shell\\FFCryptoGUI");
                    Registry.ClassesRoot.DeleteSubKeyTree("*\\shell\\FFCryptoGUI");
                    MessageBox.Show("ファイル関連付けの削除に成功しました。", "ファイル関連付け", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("ファイル関連付けには管理者権限が必要です。管理者に昇格してから実行してください。", "ファイル関連付けの削除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ファイル関連付けの削除に失敗しました:\r\n"+ ex.Message, "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// プロジェクトファイルのドラッグアンドドロップイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (MainForm.LoadAndSetProjectFile(filePath))
            {
                MessageBox.Show("プロジェクトファイル: " + filePath + " を適用しました。", Path.GetFileNameWithoutExtension(filePath), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SettingsForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

    }
}
