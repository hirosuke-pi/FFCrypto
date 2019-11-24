using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace FFCryptGUI.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<string, string> ArgvData = null; // FFCryptoコマンド引数リスト
        public string[] FileList = null; // 暗号化・復号化ファイルリスト
        public string SettingDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // ファイルリストを書き込む用のフォルダパス
        public Main MainForm = null; // メインフォームのコントロール
        public Task ExitTask = null; // 終了タスク
        public Process FFCProcess = null; // FFCryptoプロセスの管理
        public string FileListTmpPath = ""; // 一時ファイルリストのファイルパス

        // マルチタスクする上で、フォーム・コントロールにアクセスできるようにするための設定
        private delegate void outPutDataEventHandler(object sender, DataReceivedEventArgs e);
        private event outPutDataEventHandler outPutDataEvent = null;

        // 失敗・警告の文字列検索用
        private string searchWordWarning = " - Warning:";
        private string searchWordError = " - Failed:";

        // リッチテキストボックスに高速に描画できるようにするための設定
        const int WM_GETTEXTLENGTH = 0x000E;
        const int EM_SETSEL = 0x00B1;
        const int EM_REPLACESEL = 0x00C2;

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        
        /// <summary>
        /// 設定データの読み出し
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get
            {
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                tmpDict["logs_font_name"] = logs_richTextBox.Font.FontFamily.Name;
                tmpDict["logs_font_em"] = logs_richTextBox.Font.Size.ToString();
                tmpDict["logs_font_style"] = logs_richTextBox.Font.Style.ToString();
                tmpDict["logs_back_color"] = logs_richTextBox.BackColor.ToArgb().ToString();
                tmpDict["logs_fore_color"] = logs_richTextBox.ForeColor.ToArgb().ToString();
                return tmpDict;
            }
            set
            {
                try
                {
                    Dictionary<string, string> tmpDict = value;
                    logs_richTextBox.BackColor = Color.FromArgb(int.Parse(tmpDict["logs_back_color"]));
                    logs_richTextBox.ForeColor = Color.FromArgb(int.Parse(tmpDict["logs_fore_color"]));
                    FontStyle fn = (FontStyle)Enum.Parse(typeof(FontStyle), tmpDict["logs_font_style"], true);
                    logs_richTextBox.Font = new Font(tmpDict["logs_font_name"], float.Parse(tmpDict["logs_font_em"]), fn);
                } catch (Exception ex)
                {
                    MessageBox.Show("タブ:'ログ' の状態を一部復元できませんでした:\r\n" + ex.ToString(), "読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 暗号化の実行
        /// </summary>
        public void StartEncryption()
        {
            startFFCProgram("--enc", true);
        }

        /// <summary>
        /// 復号化の実行
        /// </summary>
        public void StartDecryption()
        {
            startFFCProgram("--dec", false);
        }

        /// <summary>
        /// ファイルリストの一時ファイルの作成
        /// </summary>
        /// <param name="folderPath">作成するフォルダリスト</param>
        /// <returns></returns>
        private bool makeFilePathList(string folderPath)
        {
            // ファイル名をランダム文字列に設定
            FileListTmpPath = folderPath + "\\filelist_" + Guid.NewGuid().ToString("N").Substring(0, 10);

            try
            {
                // ファイルリスト書き出し
                using (StreamWriter sw = new StreamWriter(FileListTmpPath, false))
                {
                    foreach (string path in FileList)
                        sw.WriteLine(path);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ファイルリスト作成中にエラーが発生しました:\r\n"+ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// FFCryptoプロセスの実行
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="isEncryption">暗号化か、復号化か</param>
        private void startFFCProgram(string mode, bool isEncryption)
        {
            searchLogs_groupBox.Enabled = false;
            errorWarning_groupBox.Enabled = false;

            string folderPath = SettingDirectoryPath;
            string ffcPath = folderPath + "\\ffc.exe";
            bool madeTmpFileList = makeFilePathList(folderPath);
            // ファイルリスト作成に失敗したときは中止
            if (!madeTmpFileList)
            {
                MainForm.ExitCryptoProgram(isEncryption);
                return;
            }

            // ffc.exeがフォルダ内に存在するかどうか
            while (true)
            {
                if (!File.Exists(ffcPath))
                {
                    DialogResult dr = MessageBox.Show("ffc.exeが、'"+ folderPath +"'のフォルダ内に存在しません。ffc.exeをこのフォルダ内に入れてから実行してください。", "ffc.exe", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Cancel)
                    {
                        MainForm.ExitCryptoProgram(isEncryption);
                        return;
                    }
                }
                else
                    break;
            }

            // FFCryptoのプロセス設定
            string argv = "-pathlist \""+ FileListTmpPath + "\" "+ mode + " " + string.Join(" ", ArgvData.Values.ToArray());
            logs_richTextBox.Clear();
            errorWarning_comboBox.Items.Clear();
            errorWarning_groupBox.Text = "エラー:0, 警告: 0";

            outPutDataEvent = new outPutDataEventHandler(event_DataReceived);
            FFCProcess = new Process();
            FFCProcess.StartInfo.UseShellExecute = false;
            FFCProcess.StartInfo.RedirectStandardOutput = true;
            FFCProcess.StartInfo.RedirectStandardError = true;
            FFCProcess.OutputDataReceived += ffcOutputDataReceived;
            FFCProcess.StartInfo.FileName = ffcPath;
            FFCProcess.StartInfo.RedirectStandardInput = false;
            FFCProcess.StartInfo.CreateNoWindow = true;
            FFCProcess.StartInfo.Arguments = argv;

            // プロセスの実行
            FFCProcess.Start();
            FFCProcess.BeginOutputReadLine();

            // 終了タスク実行
            ExitTask = Task.Factory.StartNew(() =>
            {
                // FFCryptoプロセスが終了するまで待機
                FFCProcess.WaitForExit();
                if (FFCProcess != null)
                {
                    FFCProcess.Dispose();
                    FFCProcess = null;
                    // 終了タスク
                    MainForm.ExitCryptoProgram(isEncryption);
                }
            });
        }

        /// <summary>
        /// コンソールに出力されたデータをログに出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_DataReceived(object sender, DataReceivedEventArgs e)
        {
            SendMessage(logs_richTextBox.Handle, EM_REPLACESEL, 1, e.Data +"\r\n");

            if (e.Data != null)
            {
                if (e.Data.Contains("+ Enc(") | e.Data.Contains(" + Dec("))
                {
                    try
                    {
                        string[] files = e.Data.Split('(')[1].Split(')')[0].Split('/');
                        ffc_percentProgressBar.Value = int.Parse(files[0]);
                        int max = int.Parse(files[1]);
                        if (ffc_percentProgressBar.Maximum != max)
                            ffc_percentProgressBar.Maximum = max;
                    }
                    catch { }
                }
            }
        }

        private void ffcOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke(outPutDataEvent, new object[2] { sender, e });
        }

        /// <summary>
        /// フォームが閉じられるときはプロセスを停止する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                FFCProcess.Kill();
                FFCProcess.Close();
                FFCProcess.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// FFCryptoプロセスを停止させる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopProgram_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (FFCProcess != null)
                {
                    DialogResult dr = MessageBox.Show("処理を中断しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        stopProgram_button.Enabled = false;
                        FFCProcess.Kill();
                        stopProgram_button.Enabled = true;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 終了タスクの実行
        /// </summary>
        public void DoExitTasks()
        {
            searchLogs_groupBox.Enabled = true;
            errorWarning_groupBox.Enabled = true;

            int error_pos = 0;
            int warning_pos = 0;

            logs_richTextBox.SelectionLength = 0;
            int error_count = 0;
            int warning_count = 0;

            // エラーログを抽出・カラーマーキングする
            while (true)
            {
                error_pos = logs_richTextBox.Find(searchWordError, error_pos, RichTextBoxFinds.None);
                if (error_pos >= 0)
                {
                    logs_richTextBox.SelectionBackColor = Color.IndianRed;
                    errorWarning_comboBox.Items.Add("Error - "+ error_pos.ToString());
                    error_count++;
                }
                else
                    break;
                error_pos++;
            }
            
            // 警告ログを抽出・カラーマーキングする
            logs_richTextBox.SelectionLength = 0;
            while (true)
            {
                warning_pos = logs_richTextBox.Find(searchWordWarning, warning_pos, RichTextBoxFinds.None);
                if (warning_pos >= 0)
                {
                    logs_richTextBox.SelectionBackColor = Color.Peru;
                    errorWarning_comboBox.Items.Add("Warning - " + warning_pos.ToString());
                    warning_count++;
                }
                else
                    break;
                warning_pos++;
            }

            // グループボックスに総数を表示
            logs_richTextBox.ScrollToCaret();
            errorWarning_groupBox.Text = "エラー: "+ error_count.ToString() +", 警告: "+ warning_count.ToString();
            logs_richTextBox.SelectionLength = 0;
        }

        /// <summary>
        /// エラー・警告ログの検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorWarning_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int pos = int.Parse(errorWarning_comboBox.Text.Split('-')[1].Replace(" ", ""));
                logs_richTextBox.Select(pos, 3);
            } catch { }
        }

        /// <summary>
        /// ログをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaerLogs_button_Click(object sender, EventArgs e)
        {
            logs_richTextBox.Clear();
            errorWarning_groupBox.Text = "エラー: 0, 警告: 0";
            errorWarning_comboBox.Items.Clear();
        }

        /// <summary>
        /// ログを保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveLogs_button_Click(object sender, EventArgs e)
        {
            if (logs_richTextBox.Text != "")
            {
                logs_saveFileDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff") +".log";
                DialogResult dr = logs_saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(logs_saveFileDialog.FileName))
                        {
                            sw.WriteLine(logs_richTextBox.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("'" + logs_saveFileDialog.FileName + "' へのログファイルの保存に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// ログのフォントを変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeFonts_button_Click(object sender, EventArgs e)
        {
            logs_fontDialog.Font = logs_richTextBox.Font;
            DialogResult dr = logs_fontDialog.ShowDialog();
            if (dr == DialogResult.OK)
                logs_richTextBox.Font = logs_fontDialog.Font;
        }

        /// <summary>
        /// ログの文字色を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForeColor_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = fore_colorDialog.ShowDialog();
            if (dr == DialogResult.OK)
                logs_richTextBox.ForeColor = fore_colorDialog.Color;
        }

        /// <summary>
        /// ログの背景色を変える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeBackColor_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = back_colorDialog.ShowDialog();
            if (dr == DialogResult.OK)
                logs_richTextBox.BackColor = back_colorDialog.Color;
        }
    }
}
