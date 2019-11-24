namespace FFCryptGUI
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.menu_InfoButton = new System.Windows.Forms.Button();
            this.menu_SettingsButton = new System.Windows.Forms.Button();
            this.menu_LogButton = new System.Windows.Forms.Button();
            this.menu_CryptButton = new System.Windows.Forms.Button();
            this.menu_ProjectButton = new System.Windows.Forms.Button();
            this.ProjectsPanel = new System.Windows.Forms.Panel();
            this.ffc_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ffc_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.projectName_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.project_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProject_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProject_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cryptoSettings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.files_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolder_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderOpenDirectoryOnly_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFonderAllDirectory_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.checkFileList_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetFileList_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPanel.SuspendLayout();
            this.ffc_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.menu_InfoButton);
            this.MenuPanel.Controls.Add(this.menu_SettingsButton);
            this.MenuPanel.Controls.Add(this.menu_LogButton);
            this.MenuPanel.Controls.Add(this.menu_CryptButton);
            this.MenuPanel.Controls.Add(this.menu_ProjectButton);
            resources.ApplyResources(this.MenuPanel, "MenuPanel");
            this.MenuPanel.Name = "MenuPanel";
            // 
            // menu_InfoButton
            // 
            resources.ApplyResources(this.menu_InfoButton, "menu_InfoButton");
            this.menu_InfoButton.Image = global::FFCryptoGUI.Properties.Resources.information_icon_big;
            this.menu_InfoButton.Name = "menu_InfoButton";
            this.menu_InfoButton.UseVisualStyleBackColor = true;
            this.menu_InfoButton.Click += new System.EventHandler(this.Menu_InfoButton_Click);
            // 
            // menu_SettingsButton
            // 
            resources.ApplyResources(this.menu_SettingsButton, "menu_SettingsButton");
            this.menu_SettingsButton.Image = global::FFCryptoGUI.Properties.Resources.settings_icon_big;
            this.menu_SettingsButton.Name = "menu_SettingsButton";
            this.menu_SettingsButton.UseVisualStyleBackColor = true;
            this.menu_SettingsButton.Click += new System.EventHandler(this.Menu_SettingsButton_Click);
            // 
            // menu_LogButton
            // 
            resources.ApplyResources(this.menu_LogButton, "menu_LogButton");
            this.menu_LogButton.Image = global::FFCryptoGUI.Properties.Resources.log_icon_big;
            this.menu_LogButton.Name = "menu_LogButton";
            this.menu_LogButton.UseVisualStyleBackColor = true;
            this.menu_LogButton.Click += new System.EventHandler(this.Menu_LogButton_Click);
            // 
            // menu_CryptButton
            // 
            resources.ApplyResources(this.menu_CryptButton, "menu_CryptButton");
            this.menu_CryptButton.Image = global::FFCryptoGUI.Properties.Resources.encryption_icon;
            this.menu_CryptButton.Name = "menu_CryptButton";
            this.menu_CryptButton.UseVisualStyleBackColor = true;
            this.menu_CryptButton.Click += new System.EventHandler(this.Menu_CryptButton_Click);
            // 
            // menu_ProjectButton
            // 
            this.menu_ProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.menu_ProjectButton, "menu_ProjectButton");
            this.menu_ProjectButton.Image = global::FFCryptoGUI.Properties.Resources.project_icon_big;
            this.menu_ProjectButton.Name = "menu_ProjectButton";
            this.menu_ProjectButton.UseVisualStyleBackColor = false;
            this.menu_ProjectButton.Click += new System.EventHandler(this.Menu_ProjectButton_Click);
            // 
            // ProjectsPanel
            // 
            resources.ApplyResources(this.ProjectsPanel, "ProjectsPanel");
            this.ProjectsPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ProjectsPanel.Name = "ProjectsPanel";
            // 
            // ffc_notifyIcon
            // 
            this.ffc_notifyIcon.ContextMenuStrip = this.ffc_contextMenuStrip;
            resources.ApplyResources(this.ffc_notifyIcon, "ffc_notifyIcon");
            this.ffc_notifyIcon.DoubleClick += new System.EventHandler(this.Ffc_notifyIcon_DoubleClick);
            // 
            // ffc_contextMenuStrip
            // 
            this.ffc_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectName_ToolStripMenuItem,
            this.project_ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cryptoSettings_ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.files_ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exit_ToolStripMenuItem});
            this.ffc_contextMenuStrip.Name = "ffc_contextMenuStrip";
            resources.ApplyResources(this.ffc_contextMenuStrip, "ffc_contextMenuStrip");
            // 
            // projectName_ToolStripMenuItem
            // 
            this.projectName_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.window_icon;
            this.projectName_ToolStripMenuItem.Name = "projectName_ToolStripMenuItem";
            resources.ApplyResources(this.projectName_ToolStripMenuItem, "projectName_ToolStripMenuItem");
            this.projectName_ToolStripMenuItem.Click += new System.EventHandler(this.ProjectName_ToolStripMenuItem_Click);
            // 
            // project_ToolStripMenuItem
            // 
            this.project_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProject_ToolStripMenuItem,
            this.openProject_ToolStripMenuItem});
            this.project_ToolStripMenuItem.Name = "project_ToolStripMenuItem";
            resources.ApplyResources(this.project_ToolStripMenuItem, "project_ToolStripMenuItem");
            // 
            // saveProject_ToolStripMenuItem
            // 
            this.saveProject_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.save_icon;
            this.saveProject_ToolStripMenuItem.Name = "saveProject_ToolStripMenuItem";
            resources.ApplyResources(this.saveProject_ToolStripMenuItem, "saveProject_ToolStripMenuItem");
            this.saveProject_ToolStripMenuItem.Click += new System.EventHandler(this.SaveProject_ToolStripMenuItem_Click);
            // 
            // openProject_ToolStripMenuItem
            // 
            this.openProject_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.file_icon;
            this.openProject_ToolStripMenuItem.Name = "openProject_ToolStripMenuItem";
            resources.ApplyResources(this.openProject_ToolStripMenuItem, "openProject_ToolStripMenuItem");
            this.openProject_ToolStripMenuItem.Click += new System.EventHandler(this.OpenProject_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // cryptoSettings_ToolStripMenuItem
            // 
            this.cryptoSettings_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.encryption_icon_min;
            this.cryptoSettings_ToolStripMenuItem.Name = "cryptoSettings_ToolStripMenuItem";
            resources.ApplyResources(this.cryptoSettings_ToolStripMenuItem, "cryptoSettings_ToolStripMenuItem");
            this.cryptoSettings_ToolStripMenuItem.Click += new System.EventHandler(this.CryptoSettings_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // files_ToolStripMenuItem
            // 
            this.files_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile_ToolStripMenuItem,
            this.openFolder_ToolStripMenuItem,
            this.toolStripMenuItem5,
            this.checkFileList_ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.resetFileList_ToolStripMenuItem1});
            this.files_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.folder_icon;
            this.files_ToolStripMenuItem.Name = "files_ToolStripMenuItem";
            resources.ApplyResources(this.files_ToolStripMenuItem, "files_ToolStripMenuItem");
            // 
            // openFile_ToolStripMenuItem
            // 
            this.openFile_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.file_icon;
            this.openFile_ToolStripMenuItem.Name = "openFile_ToolStripMenuItem";
            resources.ApplyResources(this.openFile_ToolStripMenuItem, "openFile_ToolStripMenuItem");
            this.openFile_ToolStripMenuItem.Click += new System.EventHandler(this.OpenFile_ToolStripMenuItem_Click);
            // 
            // openFolder_ToolStripMenuItem
            // 
            this.openFolder_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderOpenDirectoryOnly_ToolStripMenuItem,
            this.openFonderAllDirectory_ToolStripMenuItem});
            this.openFolder_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.folder_icon;
            this.openFolder_ToolStripMenuItem.Name = "openFolder_ToolStripMenuItem";
            resources.ApplyResources(this.openFolder_ToolStripMenuItem, "openFolder_ToolStripMenuItem");
            // 
            // folderOpenDirectoryOnly_ToolStripMenuItem
            // 
            this.folderOpenDirectoryOnly_ToolStripMenuItem.Name = "folderOpenDirectoryOnly_ToolStripMenuItem";
            resources.ApplyResources(this.folderOpenDirectoryOnly_ToolStripMenuItem, "folderOpenDirectoryOnly_ToolStripMenuItem");
            this.folderOpenDirectoryOnly_ToolStripMenuItem.Click += new System.EventHandler(this.FolderOpenDirectoryOnly_ToolStripMenuItem_Click);
            // 
            // openFonderAllDirectory_ToolStripMenuItem
            // 
            this.openFonderAllDirectory_ToolStripMenuItem.Name = "openFonderAllDirectory_ToolStripMenuItem";
            resources.ApplyResources(this.openFonderAllDirectory_ToolStripMenuItem, "openFonderAllDirectory_ToolStripMenuItem");
            this.openFonderAllDirectory_ToolStripMenuItem.Click += new System.EventHandler(this.OpenFonderAllDirectory_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // checkFileList_ToolStripMenuItem
            // 
            this.checkFileList_ToolStripMenuItem.Name = "checkFileList_ToolStripMenuItem";
            resources.ApplyResources(this.checkFileList_ToolStripMenuItem, "checkFileList_ToolStripMenuItem");
            this.checkFileList_ToolStripMenuItem.Click += new System.EventHandler(this.CheckFileList_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // resetFileList_ToolStripMenuItem1
            // 
            this.resetFileList_ToolStripMenuItem1.Image = global::FFCryptoGUI.Properties.Resources.trash_icon;
            this.resetFileList_ToolStripMenuItem1.Name = "resetFileList_ToolStripMenuItem1";
            resources.ApplyResources(this.resetFileList_ToolStripMenuItem1, "resetFileList_ToolStripMenuItem1");
            this.resetFileList_ToolStripMenuItem1.Click += new System.EventHandler(this.ResetFileList_ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Image = global::FFCryptoGUI.Properties.Resources.delete_icon;
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            resources.ApplyResources(this.exit_ToolStripMenuItem, "exit_ToolStripMenuItem");
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ProjectsPanel);
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.MenuPanel.ResumeLayout(false);
            this.ffc_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button menu_SettingsButton;
        private System.Windows.Forms.Button menu_LogButton;
        private System.Windows.Forms.Button menu_CryptButton;
        private System.Windows.Forms.Button menu_ProjectButton;
        private System.Windows.Forms.Button menu_InfoButton;
        private System.Windows.Forms.Panel ProjectsPanel;
        private System.Windows.Forms.ContextMenuStrip ffc_contextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon ffc_notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem project_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProject_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProject_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem files_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFile_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolder_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem resetFileList_ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cryptoSettings_ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem projectName_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkFileList_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem folderOpenDirectoryOnly_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFonderAllDirectory_ToolStripMenuItem;
    }
}

