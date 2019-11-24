namespace FFCryptGUI.Forms
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fileList_listView = new System.Windows.Forms.ListView();
            this.fileName_Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTime_Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize_Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath_Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileFolder_imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.addAllFile_checkBox = new System.Windows.Forms.CheckBox();
            this.removeAllObjects_button = new System.Windows.Forms.Button();
            this.removeObject_button = new System.Windows.Forms.Button();
            this.addFolder_button = new System.Windows.Forms.Button();
            this.addFile_button = new System.Windows.Forms.Button();
            this.addFile_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addFolder_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 397);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "暗号化・復号化したいファイル・フォルダ一覧";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fileList_listView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 330);
            this.panel2.TabIndex = 1;
            // 
            // fileList_listView
            // 
            this.fileList_listView.AllowDrop = true;
            this.fileList_listView.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.fileList_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileList_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName_Header,
            this.dateTime_Header,
            this.fileSize_Header,
            this.filePath_Header});
            this.fileList_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList_listView.ForeColor = System.Drawing.SystemColors.Control;
            this.fileList_listView.HideSelection = false;
            this.fileList_listView.Location = new System.Drawing.Point(0, 0);
            this.fileList_listView.Name = "fileList_listView";
            this.fileList_listView.Size = new System.Drawing.Size(558, 330);
            this.fileList_listView.SmallImageList = this.fileFolder_imageList;
            this.fileList_listView.TabIndex = 0;
            this.fileList_listView.UseCompatibleStateImageBehavior = false;
            this.fileList_listView.View = System.Windows.Forms.View.Details;
            this.fileList_listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FileList_listView_ColumnClick);
            this.fileList_listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileList_listView_DragDrop);
            this.fileList_listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileList_listView_DragEnter);
            // 
            // fileName_Header
            // 
            this.fileName_Header.Text = "ファイル・フォルダ名";
            this.fileName_Header.Width = 200;
            // 
            // dateTime_Header
            // 
            this.dateTime_Header.Text = "更新日時";
            this.dateTime_Header.Width = 150;
            // 
            // fileSize_Header
            // 
            this.fileSize_Header.Text = "ファイルサイズ (KB)";
            this.fileSize_Header.Width = 110;
            // 
            // filePath_Header
            // 
            this.filePath_Header.Text = "絶対パス";
            this.filePath_Header.Width = 550;
            // 
            // fileFolder_imageList
            // 
            this.fileFolder_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileFolder_imageList.ImageStream")));
            this.fileFolder_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileFolder_imageList.Images.SetKeyName(0, "file_icon.png");
            this.fileFolder_imageList.Images.SetKeyName(1, "folder_icon.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addAllFile_checkBox);
            this.panel1.Controls.Add(this.removeAllObjects_button);
            this.panel1.Controls.Add(this.removeObject_button);
            this.panel1.Controls.Add(this.addFolder_button);
            this.panel1.Controls.Add(this.addFile_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 45);
            this.panel1.TabIndex = 0;
            // 
            // addAllFile_checkBox
            // 
            this.addAllFile_checkBox.AutoSize = true;
            this.addAllFile_checkBox.Checked = true;
            this.addAllFile_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addAllFile_checkBox.Location = new System.Drawing.Point(217, 13);
            this.addAllFile_checkBox.Name = "addAllFile_checkBox";
            this.addAllFile_checkBox.Size = new System.Drawing.Size(176, 19);
            this.addAllFile_checkBox.TabIndex = 7;
            this.addAllFile_checkBox.Text = "サブフォルダのファイルも追加する";
            this.addAllFile_checkBox.UseVisualStyleBackColor = true;
            // 
            // removeAllObjects_button
            // 
            this.removeAllObjects_button.BackColor = System.Drawing.Color.IndianRed;
            this.removeAllObjects_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeAllObjects_button.ForeColor = System.Drawing.SystemColors.Control;
            this.removeAllObjects_button.Image = global::FFCryptoGUI.Properties.Resources.trash_icon;
            this.removeAllObjects_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeAllObjects_button.Location = new System.Drawing.Point(472, 4);
            this.removeAllObjects_button.Name = "removeAllObjects_button";
            this.removeAllObjects_button.Size = new System.Drawing.Size(83, 35);
            this.removeAllObjects_button.TabIndex = 6;
            this.removeAllObjects_button.Text = "すべて削除";
            this.removeAllObjects_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeAllObjects_button.UseVisualStyleBackColor = false;
            this.removeAllObjects_button.Click += new System.EventHandler(this.RemoveAllObjects_button_Click);
            // 
            // removeObject_button
            // 
            this.removeObject_button.BackColor = System.Drawing.Color.IndianRed;
            this.removeObject_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeObject_button.Image = global::FFCryptoGUI.Properties.Resources.delete_icon;
            this.removeObject_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeObject_button.Location = new System.Drawing.Point(408, 4);
            this.removeObject_button.Name = "removeObject_button";
            this.removeObject_button.Size = new System.Drawing.Size(58, 35);
            this.removeObject_button.TabIndex = 5;
            this.removeObject_button.Text = "削除";
            this.removeObject_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeObject_button.UseVisualStyleBackColor = false;
            this.removeObject_button.Click += new System.EventHandler(this.RemoveObject_button_Click);
            // 
            // addFolder_button
            // 
            this.addFolder_button.BackColor = System.Drawing.Color.Peru;
            this.addFolder_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFolder_button.Image = global::FFCryptoGUI.Properties.Resources.folder_icon;
            this.addFolder_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFolder_button.Location = new System.Drawing.Point(110, 4);
            this.addFolder_button.Name = "addFolder_button";
            this.addFolder_button.Size = new System.Drawing.Size(101, 35);
            this.addFolder_button.TabIndex = 4;
            this.addFolder_button.Text = "フォルダを追加";
            this.addFolder_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addFolder_button.UseVisualStyleBackColor = false;
            this.addFolder_button.Click += new System.EventHandler(this.AddFolder_button_Click);
            // 
            // addFile_button
            // 
            this.addFile_button.BackColor = System.Drawing.Color.Peru;
            this.addFile_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFile_button.Image = global::FFCryptoGUI.Properties.Resources.file_icon;
            this.addFile_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFile_button.Location = new System.Drawing.Point(3, 4);
            this.addFile_button.Name = "addFile_button";
            this.addFile_button.Size = new System.Drawing.Size(101, 35);
            this.addFile_button.TabIndex = 3;
            this.addFile_button.Text = "ファイルを追加";
            this.addFile_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addFile_button.UseVisualStyleBackColor = false;
            this.addFile_button.Click += new System.EventHandler(this.AddFile_button_Click);
            // 
            // addFile_openFileDialog
            // 
            this.addFile_openFileDialog.Filter = resources.GetString("addFile_openFileDialog.Filter");
            this.addFile_openFileDialog.Multiselect = true;
            this.addFile_openFileDialog.SupportMultiDottedExtensions = true;
            this.addFile_openFileDialog.Title = "プロジェクトを開く";
            // 
            // addFolder_folderBrowserDialog
            // 
            this.addFolder_folderBrowserDialog.Description = "フォルダ内のファイル追加";
            // 
            // ProjectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(588, 421);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView fileList_listView;
        private System.Windows.Forms.ColumnHeader filePath_Header;
        private System.Windows.Forms.ColumnHeader fileSize_Header;
        private System.Windows.Forms.Button addFolder_button;
        private System.Windows.Forms.Button addFile_button;
        private System.Windows.Forms.Button removeAllObjects_button;
        private System.Windows.Forms.Button removeObject_button;
        private System.Windows.Forms.ColumnHeader fileName_Header;
        private System.Windows.Forms.OpenFileDialog addFile_openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog addFolder_folderBrowserDialog;
        private System.Windows.Forms.ColumnHeader dateTime_Header;
        public System.Windows.Forms.CheckBox addAllFile_checkBox;
        private System.Windows.Forms.ImageList fileFolder_imageList;
    }
}