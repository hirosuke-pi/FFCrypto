using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace FFCryptGUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // プログラムの初期化
            initizalizeContorls();
            initializeSettingsData();
        }

        private FormsManager formsManager = null; // タブ(フォーム)をまとめるクラス
        private MenuManager menuManager = null; // ボタンをまとめるクラス
        private int selectedTab = 0; // 選択されたタブ
        private TextBox projectTextBox = null; // プロジェクトテキストボックス
        
        private Dictionary<string, string> settingsDict = new Dictionary<string, string>(); // 設定データ
        private Dictionary<string, string> settingsDictDefault = new Dictionary<string, string>(); // デフォルト設定データ
        private string tmpTitleProject = ""; // タイトル名の保存用変数
        private bool exitFlag = false; // 終了コード

        public string TmpTitle { get; private set; } = ""; // タイトル名の保存用変数
        // 設定データ保存パス
        public readonly string SettingsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\main.ffcp";

        /// <summary>
        /// 設定データ読み出し口
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get
            {
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                tmpDict["main_selected_tab"] = selectedTab.ToString();
                tmpDict["main_top_most"] = TopMost.ToString();
                tmpDict["main_opacity"] = Opacity.ToString();
                return tmpDict;
            }
            set
            {
                try
                {
                    Dictionary<string, string> tmpDict = value;
                    controlsActive(int.Parse(tmpDict["main_selected_tab"]));
                    ffc_notifyIcon.Visible = bool.Parse(tmpDict["project_show_notify_icon"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("メインフォームの状態を一部復元できませんでした:\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Main_Shown(object sender, EventArgs e)
        {
            try
            {
                TopMost = bool.Parse(settingsDict["main_top_most"]);
                Opacity = double.Parse(settingsDict["main_opacity"]);
                string d = Text;
            }
            catch { }
        }

        /// <summary>
        /// コントロールの初期化
        /// </summary>
        private void initizalizeContorls()
        {
            // 管理クラスの初期化
            int showIndex = 0;
            List<Button> buttonList = new List<Button>() { menu_ProjectButton, menu_CryptButton, menu_LogButton, menu_SettingsButton, menu_InfoButton };
            formsManager = new FormsManager(ProjectsPanel, showIndex);
            menuManager = new MenuManager(buttonList, showIndex);
            // メインフォーム関数呼び出し用として必要
            formsManager.cfObj.MainForm = this;
            formsManager.lfObj.MainForm = this;
            formsManager.sfObj.MainForm = this;
            projectTextBox = formsManager.sfObj.projectFile_textBox;
            Refresh();
            TmpTitle = Text;
        }

        /// <summary>
        /// 設定されたデータの初期化
        /// </summary>
        private void initializeSettingsData()
        {
            // 設定データの読み込み
            string[] args = Environment.GetCommandLineArgs();
            collectSettingsData();
            settingsDictDefault = new Dictionary<string, string>(settingsDict);
            loadSettingsFile(SettingsPath, true);

            // 引数による条件分岐
            if (args.Length > 1)
            {
                // 引数がプロジェクトファイルかどうか
                if (args.Length == 2 & Path.GetExtension(args[1]) == ".ffcp")
                {
                    LoadAndSetProjectFile(args[1]);
                }
                else
                {
                    // その他のファイルが指定された場合は、設定を初期化して、状態保存を無効にする
                    List<string> argsList = new List<string>(args);
                    argsList.RemoveAt(0);
                    InitializeSettings();
                    formsManager.sfObj.PermitSavingMainFFCP = false;
                    formsManager.pfObj.AddFileList(argsList.ToArray());
                    argsList = null;
                    formsManager.sfObj.HashCode = new string[] { "", "" };
                }
            }
            
        }

        /// <summary>
        /// プロジェクト・設定データの読み込み
        /// master: true ... 設定データ, master: false ... プロジェクトデータ
        /// </summary>
        /// <param name="projectPath">プロジェクトファイル又は設定ファイルのパス</param>
        /// <param name="master">設定データか、プロジェクトデータか</param>
        /// <returns>成功したかどうか</returns>
        private bool loadSettingsFile(string projectPath, bool master)
        {
            bool success = false;
            Forms.LoadingForm lf = new Forms.LoadingForm();
            lf.ExitFlag = false;
            lf.percentProgressBar.Maximum = 4;
            lf.percentProgressBar.Value = 1;
            lf.Path_label.Text = "プロジェクトを初期化しています...";
            lf.Show();
            Enabled = false;
            collectSettingsData();
            Application.DoEvents();
            lf.percentProgressBar.Value += 1;

            lf.Path_label.Text = "プロジェクトファイルを読み込んでいます...";
            success = readSettingsFile(projectPath, master);
            lf.percentProgressBar.Value += 1;
            if (success)
            {
                Application.DoEvents();
                lf.Path_label.Text = "プロジェクトファイルを適用しています...";
                applySettings();
                lf.percentProgressBar.Value += 1;
            }

            lf.ExitFlag = true;
            lf.Close();
            Enabled = true;
            TopMost = true;
            TopMost = false;
            return success;
        }

        /// <summary>
        /// プロジェクトファイルを読み込んで、適応する
        /// master: true ... 設定データ, master: false ... プロジェクトデータ
        /// </summary>
        /// <param name="filePath">プロジェクトファイル又は設定ファイルのパス</param>
        /// <returns>成功したかどうか</returns>
        public bool LoadAndSetProjectFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                if (loadSettingsFile(filePath, false))
                {
                    // プロジェクトファイルがファイルリストに存在するかどうか
                    Text = TmpTitle + " - " + Path.GetFileNameWithoutExtension(filePath);
                    projectName_ToolStripMenuItem.Text = Path.GetFileNameWithoutExtension(filePath);
                    projectTextBox.Text = filePath;
                    formsManager.sfObj.PermitSavingMainFFCP = false;
                    return true;
                }
                else
                {
                    projectTextBox.Text = "";
                    return false;
                }
            }
            else
            {
                projectTextBox.Text = "";
                return false;
            }
        }

        /// <summary>
        /// プロジェクト・設定データの読み込み
        /// master: true ... 設定データ, master: false ... プロジェクトデータ
        /// </summary>
        /// <param name="projectPath">プロジェクトファイル又は設定ファイルのパス</param>
        /// <param name="master">設定データか、プロジェクトデータか</param>
        /// <returns>成功したかどうか</returns>
        private bool readSettingsFile(string projectPath, bool master)
        {
            try
            {
                if (File.Exists(projectPath))
                {
                    using (StreamReader sr = new StreamReader(projectPath))
                    {
                        bool flag = true;
                        while (!sr.EndOfStream)
                        {
                            Application.DoEvents();
                            string[] line = sr.ReadLine().Split(';');
                            if (flag)
                            {
                                // チェックサム
                                if (line[0] != "FFCryptoGUI_flag")
                                    throw new IOException("FFCryptoGUIのプロジェクトファイルではありません。");
                                flag = false;
                            }
                            if (line.Length > 1)
                                settingsDict[line[0]] = line[1];
                        }
                    }
                    // 設定データか、プロジェクトデータか
                    if (!master)
                    {
                        settingsDict.Remove("project_files");
                        Main_Shown(null, EventArgs.Empty);
                    }
                    return true;
                }
                else
                    return false;
            } catch (Exception ex)
            {
                MessageBox.Show("プロジェクトファイル '"+ projectPath +"' の読み込みに失敗しました:\r\n"+ ex.Message, "読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// プロジェクト・設定データの書き込み
        /// master: true ... 設定データ, master: false ... プロジェクトデータ
        /// </summary>
        /// <param name="projectPath">プロジェクトファイル又は設定ファイルのパス</param>
        /// <param name="master">設定データか、プロジェクトデータか</param>
        /// <returns>成功したかどうか</returns>
        public bool WriteSettingsData(string projectPath, bool master)
        {
            try
            {
                // 情報収集
                collectSettingsData();
                if (!master)
                    settingsDict.Remove("project_files");
                // 読み込み専用なら強制的に外す
                if (File.Exists(projectPath))
                    new FileInfo(projectPath).IsReadOnly = false;
                // データ書き込み
                using (StreamWriter sw = new StreamWriter(projectPath, false))
                {
                    foreach (string key in settingsDict.Keys)
                        sw.WriteLine(key + ";" + settingsDict[key]);
                }
                Text = TmpTitle + " - " + Path.GetFileNameWithoutExtension(projectPath);
                projectName_ToolStripMenuItem.Text = Path.GetFileNameWithoutExtension(projectPath);
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show("プロジェクトファイル '"+ projectPath +"' の書き込みに失敗しました:\r\n"+ ex.Message, "書き込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// データの読み出し・収集
        /// </summary>
        private void collectSettingsData()
        {
            // データ初期化
            settingsDict = new Dictionary<string, string>();
            settingsDict["FFCryptoGUI_flag"] = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff");
            settingsDict = settingsDict.Concat(Settings).ToDictionary(x => x.Key, x => x.Value);
            settingsDict = settingsDict.Concat(formsManager.pfObj.Settings).ToDictionary(x => x.Key, x => x.Value);
            settingsDict = settingsDict.Concat(formsManager.cfObj.Settings).ToDictionary(x => x.Key, x => x.Value);
            settingsDict = settingsDict.Concat(formsManager.lfObj.Settings).ToDictionary(x => x.Key, x => x.Value);
            settingsDict = settingsDict.Concat(formsManager.sfObj.Settings).ToDictionary(x => x.Key, x => x.Value);

            // 生パスワード保存が無効なら、パスワードを削除する
            if (!bool.Parse(settingsDict["project_save_pass"]))
            {
                settingsDict["password1"] = "";
                settingsDict["password2"] = "";
            }
            // パスワードハッシュの保存が無効なら、ハッシュデータを削除する
            if (bool.Parse(settingsDict["project_no_save_pass"]))
            {
                settingsDict["pass_hash"] = "";
                settingsDict["pass_salt"] = "";
            }
                
        }

        /// <summary>
        /// 設定データ・プロジェクトを適応
        /// </summary>
        private void applySettings()
        {
            Settings = settingsDict;
            formsManager.pfObj.Settings = settingsDict;
            formsManager.cfObj.Settings = settingsDict;
            formsManager.lfObj.Settings = settingsDict;
            formsManager.sfObj.Settings = settingsDict;
        }

        /// <summary>
        /// 設定データを初期化
        /// </summary>
        public void InitializeSettings()
        {
            settingsDict = new Dictionary<string, string>(settingsDictDefault);
            applySettings();
        }

        /// <summary>
        /// タブのコントロール用関数
        /// </summary>
        /// <param name="index">タブ番号</param>
        private void controlsActive(int index)
        {
            formsManager.ShowWindow(index);
            menuManager.ActiveButton(index);
            selectedTab = index;
        }

        /// <summary>
        /// 暗号化・復号終了タスク
        /// </summary>
        public void ExitCryptoProgram(bool isEncryption)
        {
            if (isEncryption)
                MessageBox.Show("暗号化が終了しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("復号化が終了しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            exitTasks();
        }
        private delegate void doExitTasksDelegate();
        private void doExitTasks()
        {
            formsManager.lfObj.ArgvData = null;
            formsManager.lfObj.FileList = null;
            formsManager.lfObj.ExitTask = null;
            if (!exitFlag)
                formsManager.lfObj.DoExitTasks();

            projectName_ToolStripMenuItem.Enabled = true;
            project_ToolStripMenuItem.Enabled = true;
            cryptoSettings_ToolStripMenuItem.Enabled = true;
            files_ToolStripMenuItem.Enabled = true;

            try
            {
                File.Delete(formsManager.lfObj.FileListTmpPath);
            } catch { }

            controlsActive(2);
            Text = tmpTitleProject;
        }
        private void exitTasks(bool exit = false)
        {
            exitFlag = exit;
            if (InvokeRequired)
                Invoke(new doExitTasksDelegate(doExitTasks));
            else
                doExitTasks();
            GC.Collect();

        }


        /// <summary>
        /// 暗号化・復号化の実行のメイン関数
        /// </summary>
        public void StartCryptoProgram(bool isEncryption = true)
        {
            controlsActive(2);
            menuManager.DisableButton();
            projectName_ToolStripMenuItem.Enabled = false;
            project_ToolStripMenuItem.Enabled = false;
            cryptoSettings_ToolStripMenuItem.Enabled = false;
            files_ToolStripMenuItem.Enabled = false;

            // 暗号化・復号化に必要なデータの収集
            formsManager.lfObj.ArgvData = formsManager.cfObj.GetSettingsInfo();
            formsManager.lfObj.FileList = formsManager.pfObj.GetFilePathList();
            tmpTitleProject = Text;

            // パスワードハッシュを収集
            string nowPass = formsManager.lfObj.ArgvData["pass"].Split('"')[1];

            // ハッシュの上書き
            formsManager.sfObj.HashCode = GetHMAC(nowPass);

            // ファイル・フォルダがファイルリストに存在するかどうか
            if (formsManager.lfObj.FileList.Length < 1)
            {
                MessageBox.Show("暗号化・復号化したいファイル・フォルダが選択されていません。「ファイル・フォルダ」タブから追加してください。", "ファイルエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                exitTasks(true);
            }
            else
            {
                // 暗号化・復号化の実行
                if (isEncryption)
                {
                    Text = Text + " - 暗号化中...";
                    formsManager.lfObj.StartEncryption();
                }
                else
                {
                    Text = Text + " - 復号化中...";
                    formsManager.lfObj.StartDecryption();
                }
            }
        }

        /// <summary>
        /// 文字列のHMACハッシュコード取得
        /// </summary>
        /// <param name="password">パスワード</param>
        /// <returns>ハッシュデータとソルト</returns>
        public string[] GetHMAC(string password)
        {
            List<string> passData = new List<string>();
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, 32);
            HMACSHA256 hmac = new HMACSHA256(deriveBytes.GetBytes(256));

            // ハッシュデータの出力
            passData.Add(BitConverter.ToString(hmac.ComputeHash(deriveBytes.Salt)).Replace("-", ""));
            passData.Add(BitConverter.ToString(deriveBytes.Salt).Replace("-", ""));
            hmac.Dispose();
            deriveBytes.Dispose();
            return passData.ToArray();
        }

        /// <summary>
        /// ソルトによる、文字列のHMACハッシュコード取得
        /// </summary>
        /// <param name="password">パスワード</param>
        /// <param name="salt">ソルト</param>
        /// <returns>ハッシュデータとソルト</returns>
        public string[] GetHMAC(string password, string salt)
        {
            List<string> passData = new List<string>();
            byte[] saltBytes = StringToBytes(salt);
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1000);
            HMACSHA256 hmac = new HMACSHA256(deriveBytes.GetBytes(256));

            // ハッシュデータの出力
            passData.Add(BitConverter.ToString(hmac.ComputeHash(saltBytes)).Replace("-", ""));
            passData.Add(BitConverter.ToString(saltBytes).Replace("-", ""));

            hmac.Dispose();
            deriveBytes.Dispose();
            return passData.ToArray();
        }

        /// <summary>
        /// 16進数の文字列を、そのままバイト配列へ変換
        /// </summary>
        /// <param name="data">文字データ</param>
        /// <returns></returns>
        private byte[] StringToBytes(string data)
        {
            List<byte> byteData = new List<byte>();
            for (int i = 0; i < data.Length; i += 2)
                byteData.Add(Convert.ToByte(data.Substring(i, 2), 16));
            return byteData.ToArray();
        }


        // タブボタンが押された時のイベント
        private void Menu_ProjectButton_Click(object sender, EventArgs e)
        {
            controlsActive(0);
        }

        private void Menu_CryptButton_Click(object sender, EventArgs e)
        {
            controlsActive(1);
        }

        private void Menu_LogButton_Click(object sender, EventArgs e)
        {
            controlsActive(2);
        }

        private void Menu_SettingsButton_Click(object sender, EventArgs e)
        {
            controlsActive(3);
        }

        private void Menu_InfoButton_Click(object sender, EventArgs e)
        {
            controlsActive(4);
        }

        // 終了時に実行する事柄
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 暗号化・復号化のタスクが実行中なら、停止して終了する
            if (formsManager.lfObj.ExitTask != null)
            {
                DialogResult dr = MessageBox.Show("処理が実行中です。本当に終了しますか？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK & formsManager.lfObj.FFCProcess != null)
                {
                    Text = Text + " - 終了中...";
                    Cursor = Cursors.WaitCursor;
                    formsManager.lfObj.FFCProcess.Kill();
                    formsManager.lfObj.FFCProcess.Close();
                    formsManager.lfObj.FFCProcess = null;
                    exitTasks(true);
                    Thread.Sleep(3000);
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
           

            // プロジェクトデータと設定データの書き出し
            if (formsManager.sfObj.PermitWroteSettings & formsManager.sfObj.PermitSavingMainFFCP)
                WriteSettingsData(SettingsPath, true);

            if (projectTextBox.Text != "" & formsManager.sfObj.PermitWroteSettings)
                WriteSettingsData(projectTextBox.Text, false);

            ffc_notifyIcon.Visible = false;
        }

        private void Ffc_notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized & formsManager.sfObj.MinimizeNotifyIcon)
                ShowInTaskbar = false;
            else
                ShowInTaskbar = true;
        }

        private void ProjectName_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            controlsActive(3);
        }

        private void SaveProject_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsManager.sfObj.ProjectSave_button_Click(null, EventArgs.Empty);
        }

        private void OpenProject_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsManager.sfObj.ProjectOpen_button_Click(null, EventArgs.Empty);
        }

        private void CryptoSettings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            controlsActive(1);
        }

        private void OpenFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsManager.pfObj.AddFile_button_Click(null, EventArgs.Empty);
        }
        private void FolderOpenDirectoryOnly_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsManager.pfObj.addAllFile_checkBox.Checked = true;
            formsManager.pfObj.AddFolder_button_Click(null, EventArgs.Empty);
        }

        private void OpenFonderAllDirectory_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formsManager.pfObj.addAllFile_checkBox.Checked = false;
            formsManager.pfObj.AddFolder_button_Click(null, EventArgs.Empty);
        }

        private void ResetFileList_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formsManager.pfObj.RemoveAllObjects_button_Click(null, EventArgs.Empty);
        }
        private void CheckFileList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            controlsActive(0);
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
