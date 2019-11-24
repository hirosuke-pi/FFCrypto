using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace FFCryptGUI.Forms
{
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
            
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {

        }

        private bool isListViewDescending = false; // ファイル・フォルダリストの昇順降順フラグ

        /// <summary>
        /// ファイル・フォルダリストの書き出し
        /// </summary>
        /// <returns></returns>
        public string[] GetFilePathList()
        {
            List<string> filePathList = new List<string>();
            foreach (ListViewItem item in fileList_listView.Items)
            {
                string data = item.SubItems[3].Text;
                string dirname = Path.GetDirectoryName(data);
                string filename = Path.GetFileNameWithoutExtension(data);
                if (Directory.Exists(data))
                    filePathList.Add(data);
                else
                {
                    // .ffcファイルになっていれば、ファイルパスを変換する
                    if (File.Exists(data))
                        filePathList.Add(data);
                    else if (File.Exists(dirname + "\\" + filename + ".ffc"))
                        filePathList.Add(dirname + "\\" + filename + ".ffc");
                    else if (File.Exists(data + "\\" + ".ffc"))
                        filePathList.Add(data + "\\" + ".ffc");
                }
                    
            }
            return filePathList.ToArray();
        }

        private string[] collectFileList()
        {
            List<string> filePathList = new List<string>();
            foreach (ListViewItem item in fileList_listView.Items)
            {
                filePathList.Add(item.SubItems[3].Text);
            }
            return filePathList.ToArray();
        }

        /// <summary>
        /// 設定データの書き出し
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get
            {
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                tmpDict["files_add_folder"] = addAllFile_checkBox.Checked.ToString();
                tmpDict["files_paths"] = string.Join("|", collectFileList());
                tmpDict["files_name_width"] = fileName_Header.Width.ToString();
                tmpDict["files_date_width"] = dateTime_Header.Width.ToString();
                tmpDict["files_size_width"] = fileSize_Header.Width.ToString();
                tmpDict["files_path_width"] = filePath_Header.Width.ToString();
                return tmpDict;
            }
            set
            {
                try
                {
                    Dictionary<string, string> tmpDict = value;
                    addAllFile_checkBox.Checked = bool.Parse(tmpDict["files_add_folder"]);
                    fileList_listView.Items.Clear();
                    AddFileList(tmpDict["files_paths"].Split('|'));
                    fileName_Header.Width = int.Parse(tmpDict["files_name_width"]);
                    dateTime_Header.Width = int.Parse(tmpDict["files_date_width"]);
                    fileSize_Header.Width = int.Parse(tmpDict["files_size_width"]);
                    filePath_Header.Width = int.Parse(tmpDict["files_path_width"]);
                } catch (Exception ex)
                {
                    MessageBox.Show("タブ:'ファイル・フォルダ' の状態を一部復元できませんでした:\r\n" + ex.ToString(), "読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// バイトを文字型キロバイトに変換
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string calcBytesToKB(long bytes)
        {
            return String.Format("{0:#,0}", Convert.ToInt32(Math.Ceiling((double)bytes / 1024)));
        }

        /// <summary>
        /// ファイル・フォルダリストにファイル・フォルダを追加する
        /// </summary>
        /// <param name="fileListTmp">ファイルリスト</param>
        public void AddFileList(string[] fileListTmp)
        {
            // ファイルリストの重複を削除
            string[] fileList = new List<string>(fileListTmp).Distinct().ToArray();
            // 読み込み中ウィンドウフォームの作成・初期化
            LoadingForm lf  = new LoadingForm();
            lf.Path_label.Text = "";
            lf.Show();
            lf.percentProgressBar.Maximum = fileList.Length;
            lf.Text = "ファイル・フォルダを追加しています...";
            lf.percentProgressBar.Value = 0;

            // ファイルリストの更新を止める
            fileList_listView.BeginUpdate();
            foreach (string filePath in fileList)
            {
                Application.DoEvents();
                lf.percentProgressBar.Value += 1;
                lf.Path_label.Text = "[" +lf.percentProgressBar.Value.ToString() +"/"+ fileList.Length.ToString()+"]: " + filePath;
                // 読み込み中ウィンドウが閉じられれば、中断する
                if (!lf.Visible)
                    break;
                // ファイル・フォルダリストに重複があれば追加しない
                if (ContainFileList(filePath))
                    continue;
                try
                {
                    // ファイル処理
                    if (File.Exists(filePath))
                    {
                        FileInfo fi = new FileInfo(filePath);
                        string[] itemList = { fi.Name + " (.ffc)", fi.LastAccessTime.ToString(), calcBytesToKB(fi.Length) + " KB", filePath };
                        fileList_listView.Items.Add(new ListViewItem(itemList, 0));
                    }
                    // フォルダ処理
                    else if (Directory.Exists(filePath))
                    {
                        DirectoryInfo di = new DirectoryInfo(filePath);
                        string folderBytes = "0 KB (アクセスエラー)";
                        try
                        {
                            // アクセス権限で計算できないときもある
                            folderBytes = calcBytesToKB(di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length)) + " KB";
                        } catch {  }
                        string[] itemList = { di.Name, di.CreationTime.ToString(), folderBytes, filePath };
                        fileList_listView.Items.Add(new ListViewItem(itemList, 1));
                    }
                    else if (IsSafePath(filePath, false))
                    {
                        string[] itemList = { Path.GetFileName(filePath), DateTime.Now.ToString(), "0 KB", filePath };
                        fileList_listView.Items.Add(new ListViewItem(itemList));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("'"+ filePath+"' を追加できませんでした:\r\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // ファイルリストの更新を再開
            fileList_listView.EndUpdate();
            // 読み込みウィンドウを閉じる
            lf.Close();
            lf.Dispose();
            lf = null;
        }

        private static string renameFile(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string dirname = Path.GetDirectoryName(filePath);
            string extension = Path.GetExtension(filePath);
            string path = filePath;

            for (int i = 1; i < int.MaxValue; i++)
            {
                path = dirname + "\\" + filename + " (" + i.ToString() + ")" + extension;
                if (!File.Exists(path))
                    break;
            }
            return path;
        }

        /// <summary>
        /// パスが正しいかチェックする
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="isFileName">ファイル名の場合true, パスの場合false</param>
        /// <returns>True:正しいパス</returns>
        public static bool IsSafePath(string path, bool isFileName)
        {
            if (string.IsNullOrEmpty(path))
            {
                // null か、空文字列は不正とする
                return false;
            }

            // 使えない文字があるかチェック
            char[] invalidChars;
            if (isFileName)
            {
                invalidChars = Path.GetInvalidFileNameChars();
            }
            else
            {
                invalidChars = Path.GetInvalidPathChars();
            }
            if (path.IndexOfAny(invalidChars) >= 0)
            {
                // 使えない文字がある
                return false;
            }

            // 使えないファイル名を含んでいないかチェック
            if (System.Text.RegularExpressions.Regex.IsMatch(path
                                           , @"(^|\\|/)(CON|PRN|AUX|NUL|CLOCK\$|COM[0-9]|LPT[0-9])(\.|\\|/|$)"
                                           , System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                // 使えないファイル名がある
                return false;
            }
            return true;
        }

        /// <summary>
        /// ファイル・フォルダリストに存在するかどうか調べる
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        private bool ContainFileList(string filePath)
        {
            foreach (ListViewItem item in fileList_listView.Items)
            {
                if (item.SubItems[3].Text == filePath)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// ファイル追加ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddFile_button_Click(object sender, EventArgs e)
        {
            DialogResult ps = addFile_openFileDialog.ShowDialog();
            if (ps == DialogResult.OK)
            {
                AddFileList(addFile_openFileDialog.FileNames);
            }
        }

        /// <summary>
        /// フォルダー追加イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddFolder_button_Click(object sender, EventArgs e)
        {
            bool isAllFiles = addAllFile_checkBox.Checked;
            if (isAllFiles)
                addFolder_folderBrowserDialog.Description = "フォルダ内のファイルを開く (サブフォルダ内のファイルも含む)";
            else
                addFolder_folderBrowserDialog.Description = "フォルダ内のファイルのみを開く";

            DialogResult ps = addFolder_folderBrowserDialog.ShowDialog();
            if (ps == DialogResult.OK)
            {
                if (isAllFiles)
                    AddFileList(new string[] { addFolder_folderBrowserDialog.SelectedPath });
                else
                {
                    IEnumerable<string> subFolders = Directory.EnumerateFiles(addFolder_folderBrowserDialog.SelectedPath, "*", SearchOption.TopDirectoryOnly);
                    AddFileList(subFolders.ToArray());
                }
            }
        }

        /// <summary>
        /// ファイル・フォルダリストから、選択されている項目を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveObject_button_Click(object sender, EventArgs e)
        {
            if (fileList_listView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in fileList_listView.SelectedItems)
                    fileList_listView.Items.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// ファイル・フォルダリストからすべての項目を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RemoveAllObjects_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("表示されているファイル・フォルダリストをすべて削除します。よろしいですか？", "すべて削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                fileList_listView.Items.Clear();
        }

        /// <summary>
        /// ファイル・フォルダリストを、クリックされた項目順に並び替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileList_listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                fileList_listView.ListViewItemSorter = new ListViewItemComparer(e.Column, ListViewItemComparer.ComparerMode.String, isListViewDescending);
            else if (e.Column == 1)
                fileList_listView.ListViewItemSorter = new ListViewItemComparer(e.Column, ListViewItemComparer.ComparerMode.DateTime, isListViewDescending);
            else if (e.Column == 2)
                fileList_listView.ListViewItemSorter = new ListViewItemComparer(e.Column, ListViewItemComparer.ComparerMode.Integer, isListViewDescending);
            else
                fileList_listView.ListViewItemSorter = new ListViewItemComparer(e.Column, ListViewItemComparer.ComparerMode.String, isListViewDescending);
            isListViewDescending = !isListViewDescending;
        }


        /// <summary>
        /// ファイル・フォルダリストを並び替えるために必要なクラス
        /// </summary>
        class ListViewItemComparer : IComparer
        {
            public enum ComparerMode { String, Integer, DateTime };
            private int col;
            private ComparerMode selectedComparerMode;
            private bool isDescending = false;

            // 初期化
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
                selectedComparerMode = 0;
            }

            public ListViewItemComparer(int column, ComparerMode mode, bool descending = false)
            {
                col = column;
                selectedComparerMode = mode;
                isDescending = descending;
            }

            /// <summary>
            /// 項目ごとに並び替える
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                string xData = ((ListViewItem)x).SubItems[col].Text;
                string yData = ((ListViewItem)y).SubItems[col].Text;
                int result = 0;

                switch (selectedComparerMode)
                {
                    case ComparerMode.String:
                        result = String.Compare(xData, yData);
                        break;

                    case ComparerMode.Integer:
                        result = int.Parse(xData.Replace(",", "").Split(' ')[0]).CompareTo(int.Parse(yData.Replace(",", "").Split(' ')[0]));
                        break;

                    case ComparerMode.DateTime:
                        result = DateTime.Compare(DateTime.Parse(xData), DateTime.Parse(yData));
                        break;
                }
                if (isDescending)
                    return -1 * result;
                else
                    return result;
                
            }
        }

        /// <summary>
        /// ファイル・フォルダがドラッグアンドドロップされたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileList_listView_DragDrop(object sender, DragEventArgs e)
        {
            AddFileList((string[])e.Data.GetData(DataFormats.FileDrop, false));
        }

        private void FileList_listView_DragEnter(object sender, DragEventArgs e)
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
