namespace ConfigManage
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ConfigManagerView = new System.Windows.Forms.TreeView();
            this.contextMenu_ConfigManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_hostgroup_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_host_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_filegroup_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_configfile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.変数編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.接続ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切断ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再読込ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルを比較するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.上書き保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.印刷PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.印刷プレビューVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.エンコードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sJISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eUCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.元に戻すUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.やり直しRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.切り取りTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼り付けPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.すべて選択AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.カスタマイズCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.オプションOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内容CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.インデックスIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検索SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.バージョン情報AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConsoleText = new System.Windows.Forms.TextBox();
            this.RemoteFilemanagerView = new System.Windows.Forms.TreeView();
            this.contextMenu_RemoteFilemanager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ホスト追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ホスト削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接続ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.切断ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LocalFileView = new System.Windows.Forms.TreeView();
            this.TemplateView = new System.Windows.Forms.TreeView();
            this.ContextMenu_Template = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.テンプレートグループToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.テンプレートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.FileDetail = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileneame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_address = new System.Windows.Forms.ToolStripTextBox();
            this.overlay_imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu_ConfigManager.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenu_RemoteFilemanager.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ContextMenu_Template.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.FileDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Output.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigManagerView
            // 
            this.ConfigManagerView.AllowDrop = true;
            this.ConfigManagerView.ContextMenuStrip = this.contextMenu_ConfigManager;
            this.ConfigManagerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigManagerView.Font = new System.Drawing.Font("游ゴシック", 11F);
            this.ConfigManagerView.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ConfigManagerView.ImageIndex = 0;
            this.ConfigManagerView.ImageList = this.imageList1;
            this.ConfigManagerView.LabelEdit = true;
            this.ConfigManagerView.Location = new System.Drawing.Point(0, 0);
            this.ConfigManagerView.Name = "ConfigManagerView";
            this.ConfigManagerView.SelectedImageIndex = 0;
            this.ConfigManagerView.Size = new System.Drawing.Size(360, 391);
            this.ConfigManagerView.TabIndex = 0;
            this.ConfigManagerView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ConfigManageTree_BeforeLabelEdit);
            this.ConfigManagerView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ConfigManageTree_AfterLabelEdit);
            this.ConfigManagerView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ConfigManageTree_ItemDrag);
            this.ConfigManagerView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ConfigManagerView_NodeMouseDoubleClick);
            this.ConfigManagerView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ConfigManageTree_DragDrop);
            this.ConfigManagerView.DragOver += new System.Windows.Forms.DragEventHandler(this.ConfigManageTree_DragOver);
            this.ConfigManagerView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConfigManageTree_KeyUp);
            // 
            // contextMenu_ConfigManager
            // 
            this.contextMenu_ConfigManager.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu_ConfigManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.削除ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.変数編集ToolStripMenuItem,
            this.toolStripSeparator9,
            this.接続ToolStripMenuItem,
            this.切断ToolStripMenuItem,
            this.再読込ToolStripMenuItem,
            this.更新ToolStripMenuItem});
            this.contextMenu_ConfigManager.Name = "contextMenuStrip1";
            this.contextMenu_ConfigManager.Size = new System.Drawing.Size(170, 226);
            this.contextMenu_ConfigManager.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_hostgroup_ToolStripMenuItem,
            this.add_host_ToolStripMenuItem,
            this.add_filegroup_ToolStripMenuItem,
            this.add_configfile_ToolStripMenuItem});
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.追加ToolStripMenuItem.Text = "追加";
            // 
            // add_hostgroup_ToolStripMenuItem
            // 
            this.add_hostgroup_ToolStripMenuItem.Name = "add_hostgroup_ToolStripMenuItem";
            this.add_hostgroup_ToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.add_hostgroup_ToolStripMenuItem.Text = "ホストグループ";
            this.add_hostgroup_ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // add_host_ToolStripMenuItem
            // 
            this.add_host_ToolStripMenuItem.Name = "add_host_ToolStripMenuItem";
            this.add_host_ToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.add_host_ToolStripMenuItem.Text = "ホスト";
            this.add_host_ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // add_filegroup_ToolStripMenuItem
            // 
            this.add_filegroup_ToolStripMenuItem.Name = "add_filegroup_ToolStripMenuItem";
            this.add_filegroup_ToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.add_filegroup_ToolStripMenuItem.Text = "ファイルグループ";
            this.add_filegroup_ToolStripMenuItem.Click += new System.EventHandler(this.add_filegroup_ToolStripMenuItem_Click);
            // 
            // add_configfile_ToolStripMenuItem
            // 
            this.add_configfile_ToolStripMenuItem.Name = "add_configfile_ToolStripMenuItem";
            this.add_configfile_ToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.add_configfile_ToolStripMenuItem.Text = "管理ファイル";
            this.add_configfile_ToolStripMenuItem.Click += new System.EventHandler(this.add_configfile_ToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem1
            // 
            this.削除ToolStripMenuItem1.Name = "削除ToolStripMenuItem1";
            this.削除ToolStripMenuItem1.Size = new System.Drawing.Size(169, 30);
            this.削除ToolStripMenuItem1.Text = "削除";
            this.削除ToolStripMenuItem1.Click += new System.EventHandler(this.削除ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // 変数編集ToolStripMenuItem
            // 
            this.変数編集ToolStripMenuItem.Name = "変数編集ToolStripMenuItem";
            this.変数編集ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.変数編集ToolStripMenuItem.Text = "変数編集";
            this.変数編集ToolStripMenuItem.Click += new System.EventHandler(this.変数編集ToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(166, 6);
            // 
            // 接続ToolStripMenuItem
            // 
            this.接続ToolStripMenuItem.Name = "接続ToolStripMenuItem";
            this.接続ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.接続ToolStripMenuItem.Text = "接続";
            // 
            // 切断ToolStripMenuItem
            // 
            this.切断ToolStripMenuItem.Name = "切断ToolStripMenuItem";
            this.切断ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.切断ToolStripMenuItem.Text = "切断";
            // 
            // 再読込ToolStripMenuItem
            // 
            this.再読込ToolStripMenuItem.Name = "再読込ToolStripMenuItem";
            this.再読込ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.再読込ToolStripMenuItem.Text = "再読込";
            this.再読込ToolStripMenuItem.Click += new System.EventHandler(this.再読込ToolStripMenuItem_Click);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(169, 30);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "48px-Crystal_Clear_filesystem_folder_desktop.png");
            this.imageList1.Images.SetKeyName(1, "48px-Crystal_Clear_app_harddrive.png");
            this.imageList1.Images.SetKeyName(2, "48px-Crystal_Clear_device_cdrom_unmount.png");
            this.imageList1.Images.SetKeyName(3, "48px-Crystal_Clear_filesystem_folder_yellow.png");
            this.imageList1.Images.SetKeyName(4, "48px-Crystal_Clear_filesystem_folder.png");
            this.imageList1.Images.SetKeyName(5, "48px-Crystal_Clear_mimetype_misc.png");
            this.imageList1.Images.SetKeyName(6, "48px-Crystal_Clear_mimetype_metafont.png");
            this.imageList1.Images.SetKeyName(7, "DataConnection-Connected_1061.png");
            this.imageList1.Images.SetKeyName(8, "OK.png");
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.表示VToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.ツールTToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1211, 33);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成NToolStripMenuItem,
            this.開くOToolStripMenuItem,
            this.ファイルを比較するToolStripMenuItem,
            this.toolStripSeparator,
            this.上書き保存SToolStripMenuItem,
            this.名前を付けて保存AToolStripMenuItem,
            this.toolStripSeparator2,
            this.印刷PToolStripMenuItem,
            this.印刷プレビューVToolStripMenuItem,
            this.toolStripSeparator3,
            this.終了XToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 新規作成NToolStripMenuItem
            // 
            this.新規作成NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新規作成NToolStripMenuItem.Image")));
            this.新規作成NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新規作成NToolStripMenuItem.Name = "新規作成NToolStripMenuItem";
            this.新規作成NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新規作成NToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.新規作成NToolStripMenuItem.Text = "新規作成(&N)";
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("開くOToolStripMenuItem.Image")));
            this.開くOToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.開くOToolStripMenuItem.Text = "開く(&O)";
            // 
            // ファイルを比較するToolStripMenuItem
            // 
            this.ファイルを比較するToolStripMenuItem.Name = "ファイルを比較するToolStripMenuItem";
            this.ファイルを比較するToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.ファイルを比較するToolStripMenuItem.Text = "ファイルを比較する";
            this.ファイルを比較するToolStripMenuItem.Click += new System.EventHandler(this.ファイルを比較するToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(253, 6);
            // 
            // 上書き保存SToolStripMenuItem
            // 
            this.上書き保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("上書き保存SToolStripMenuItem.Image")));
            this.上書き保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.上書き保存SToolStripMenuItem.Name = "上書き保存SToolStripMenuItem";
            this.上書き保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.上書き保存SToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.上書き保存SToolStripMenuItem.Text = "設定保存(&S)";
            this.上書き保存SToolStripMenuItem.Click += new System.EventHandler(this.上書き保存SToolStripMenuItem_Click);
            // 
            // 名前を付けて保存AToolStripMenuItem
            // 
            this.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem";
            this.名前を付けて保存AToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(&A)";
            this.名前を付けて保存AToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存AToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(253, 6);
            // 
            // 印刷PToolStripMenuItem
            // 
            this.印刷PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("印刷PToolStripMenuItem.Image")));
            this.印刷PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.印刷PToolStripMenuItem.Name = "印刷PToolStripMenuItem";
            this.印刷PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.印刷PToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.印刷PToolStripMenuItem.Text = "印刷(&P)";
            // 
            // 印刷プレビューVToolStripMenuItem
            // 
            this.印刷プレビューVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("印刷プレビューVToolStripMenuItem.Image")));
            this.印刷プレビューVToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.印刷プレビューVToolStripMenuItem.Name = "印刷プレビューVToolStripMenuItem";
            this.印刷プレビューVToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.印刷プレビューVToolStripMenuItem.Text = "印刷プレビュー(&V)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(253, 6);
            // 
            // 終了XToolStripMenuItem
            // 
            this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
            this.終了XToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.終了XToolStripMenuItem.Text = "終了(&X)";
            // 
            // 表示VToolStripMenuItem
            // 
            this.表示VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.エンコードToolStripMenuItem});
            this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
            this.表示VToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.表示VToolStripMenuItem.Text = "表示(&V)";
            // 
            // エンコードToolStripMenuItem
            // 
            this.エンコードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sJISToolStripMenuItem,
            this.eUCToolStripMenuItem,
            this.toolStripSeparator8,
            this.cRLFToolStripMenuItem,
            this.cRToolStripMenuItem,
            this.lFToolStripMenuItem});
            this.エンコードToolStripMenuItem.Name = "エンコードToolStripMenuItem";
            this.エンコードToolStripMenuItem.Size = new System.Drawing.Size(162, 30);
            this.エンコードToolStripMenuItem.Text = "エンコード";
            // 
            // sJISToolStripMenuItem
            // 
            this.sJISToolStripMenuItem.Name = "sJISToolStripMenuItem";
            this.sJISToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.sJISToolStripMenuItem.Text = "SJIS";
            this.sJISToolStripMenuItem.Click += new System.EventHandler(this.sJISToolStripMenuItem_Click);
            // 
            // eUCToolStripMenuItem
            // 
            this.eUCToolStripMenuItem.Name = "eUCToolStripMenuItem";
            this.eUCToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.eUCToolStripMenuItem.Text = "EUC";
            this.eUCToolStripMenuItem.Click += new System.EventHandler(this.sJISToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(145, 6);
            // 
            // cRLFToolStripMenuItem
            // 
            this.cRLFToolStripMenuItem.Name = "cRLFToolStripMenuItem";
            this.cRLFToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.cRLFToolStripMenuItem.Text = "CR+LF";
            // 
            // cRToolStripMenuItem
            // 
            this.cRToolStripMenuItem.Name = "cRToolStripMenuItem";
            this.cRToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.cRToolStripMenuItem.Text = "CR";
            // 
            // lFToolStripMenuItem
            // 
            this.lFToolStripMenuItem.Name = "lFToolStripMenuItem";
            this.lFToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.lFToolStripMenuItem.Text = "LF";
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.元に戻すUToolStripMenuItem,
            this.やり直しRToolStripMenuItem,
            this.toolStripSeparator4,
            this.切り取りTToolStripMenuItem,
            this.コピーCToolStripMenuItem,
            this.貼り付けPToolStripMenuItem,
            this.toolStripSeparator5,
            this.すべて選択AToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItem,
            this.削除ToolStripMenuItem,
            this.変更ToolStripMenuItem});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // 元に戻すUToolStripMenuItem
            // 
            this.元に戻すUToolStripMenuItem.Name = "元に戻すUToolStripMenuItem";
            this.元に戻すUToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.元に戻すUToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.元に戻すUToolStripMenuItem.Text = "元に戻す(&U)";
            // 
            // やり直しRToolStripMenuItem
            // 
            this.やり直しRToolStripMenuItem.Name = "やり直しRToolStripMenuItem";
            this.やり直しRToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.やり直しRToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.やり直しRToolStripMenuItem.Text = "やり直し(&R)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // 切り取りTToolStripMenuItem
            // 
            this.切り取りTToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("切り取りTToolStripMenuItem.Image")));
            this.切り取りTToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.切り取りTToolStripMenuItem.Name = "切り取りTToolStripMenuItem";
            this.切り取りTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.切り取りTToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.切り取りTToolStripMenuItem.Text = "切り取り(&T)";
            // 
            // コピーCToolStripMenuItem
            // 
            this.コピーCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("コピーCToolStripMenuItem.Image")));
            this.コピーCToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.コピーCToolStripMenuItem.Name = "コピーCToolStripMenuItem";
            this.コピーCToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.コピーCToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.コピーCToolStripMenuItem.Text = "コピー(&C)";
            // 
            // 貼り付けPToolStripMenuItem
            // 
            this.貼り付けPToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("貼り付けPToolStripMenuItem.Image")));
            this.貼り付けPToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.貼り付けPToolStripMenuItem.Name = "貼り付けPToolStripMenuItem";
            this.貼り付けPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.貼り付けPToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.貼り付けPToolStripMenuItem.Text = "貼り付け(&P)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // すべて選択AToolStripMenuItem
            // 
            this.すべて選択AToolStripMenuItem.Name = "すべて選択AToolStripMenuItem";
            this.すべて選択AToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.すべて選択AToolStripMenuItem.Text = "すべて選択(&A)";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.toolStripMenuItem.Text = "追加";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(254, 30);
            this.toolStripMenuItem2.Text = "ホスト";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(254, 30);
            this.toolStripMenuItem3.Text = "ホストグループ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(254, 30);
            this.toolStripMenuItem4.Text = "アプリケーショングループ";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(254, 30);
            this.toolStripMenuItem5.Text = "アプリケーション定義";
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.削除ToolStripMenuItem.Text = "削除";
            // 
            // 変更ToolStripMenuItem
            // 
            this.変更ToolStripMenuItem.Name = "変更ToolStripMenuItem";
            this.変更ToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.変更ToolStripMenuItem.Text = "変更";
            // 
            // ツールTToolStripMenuItem
            // 
            this.ツールTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.カスタマイズCToolStripMenuItem,
            this.オプションOToolStripMenuItem});
            this.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem";
            this.ツールTToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.ツールTToolStripMenuItem.Text = "ツール(&T)";
            // 
            // カスタマイズCToolStripMenuItem
            // 
            this.カスタマイズCToolStripMenuItem.Name = "カスタマイズCToolStripMenuItem";
            this.カスタマイズCToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.カスタマイズCToolStripMenuItem.Text = "カスタマイズ(&C)";
            // 
            // オプションOToolStripMenuItem
            // 
            this.オプションOToolStripMenuItem.Name = "オプションOToolStripMenuItem";
            this.オプションOToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.オプションOToolStripMenuItem.Text = "オプション(&O)";
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.内容CToolStripMenuItem,
            this.インデックスIToolStripMenuItem,
            this.検索SToolStripMenuItem,
            this.toolStripSeparator6,
            this.バージョン情報AToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // 内容CToolStripMenuItem
            // 
            this.内容CToolStripMenuItem.Name = "内容CToolStripMenuItem";
            this.内容CToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.内容CToolStripMenuItem.Text = "内容(&C)";
            // 
            // インデックスIToolStripMenuItem
            // 
            this.インデックスIToolStripMenuItem.Name = "インデックスIToolStripMenuItem";
            this.インデックスIToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.インデックスIToolStripMenuItem.Text = "インデックス(&I)";
            // 
            // 検索SToolStripMenuItem
            // 
            this.検索SToolStripMenuItem.Name = "検索SToolStripMenuItem";
            this.検索SToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.検索SToolStripMenuItem.Text = "検索(&S)";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(230, 6);
            // 
            // バージョン情報AToolStripMenuItem
            // 
            this.バージョン情報AToolStripMenuItem.Name = "バージョン情報AToolStripMenuItem";
            this.バージョン情報AToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.バージョン情報AToolStripMenuItem.Text = "バージョン情報(&A)...";
            this.バージョン情報AToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報AToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 848);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1211, 30);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(181, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ConsoleText
            // 
            this.ConsoleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleText.Font = new System.Drawing.Font("游ゴシック", 11F);
            this.ConsoleText.Location = new System.Drawing.Point(3, 3);
            this.ConsoleText.Multiline = true;
            this.ConsoleText.Name = "ConsoleText";
            this.ConsoleText.Size = new System.Drawing.Size(831, 341);
            this.ConsoleText.TabIndex = 6;
            this.ConsoleText.TextChanged += new System.EventHandler(this.ConsoleText_TextChanged);
            // 
            // RemoteFilemanagerView
            // 
            this.RemoteFilemanagerView.AllowDrop = true;
            this.RemoteFilemanagerView.ContextMenuStrip = this.contextMenu_RemoteFilemanager;
            this.RemoteFilemanagerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoteFilemanagerView.Font = new System.Drawing.Font("游ゴシック", 11F);
            this.RemoteFilemanagerView.ImageIndex = 0;
            this.RemoteFilemanagerView.ImageList = this.imageList1;
            this.RemoteFilemanagerView.LabelEdit = true;
            this.RemoteFilemanagerView.Location = new System.Drawing.Point(3, 3);
            this.RemoteFilemanagerView.Name = "RemoteFilemanagerView";
            this.RemoteFilemanagerView.SelectedImageIndex = 0;
            this.RemoteFilemanagerView.Size = new System.Drawing.Size(348, 341);
            this.RemoteFilemanagerView.TabIndex = 8;
            this.RemoteFilemanagerView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.RemoteFilemanagerView_BeforeExpand);
            this.RemoteFilemanagerView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.RemoteFilemanagerView_ItemDrag);
            this.RemoteFilemanagerView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RemoteFilemanagerView_AfterSelect);
            this.RemoteFilemanagerView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RemoteFilemanagerView_NodeMouseDoubleClick);
            this.RemoteFilemanagerView.DragOver += new System.Windows.Forms.DragEventHandler(this.RemoteFilemanagerView_DragOver);
            this.RemoteFilemanagerView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RemoteFilemanagerView_MouseDoubleClick);
            this.RemoteFilemanagerView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RemoteFilemanagerView_MouseMove);
            this.RemoteFilemanagerView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoteFilemanagerView_MouseUp);
            // 
            // contextMenu_RemoteFilemanager
            // 
            this.contextMenu_RemoteFilemanager.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu_RemoteFilemanager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ホスト追加ToolStripMenuItem,
            this.ホスト削除ToolStripMenuItem,
            this.接続ToolStripMenuItem1,
            this.切断ToolStripMenuItem1});
            this.contextMenu_RemoteFilemanager.Name = "contextMenuStrip2";
            this.contextMenu_RemoteFilemanager.Size = new System.Drawing.Size(175, 124);
            // 
            // ホスト追加ToolStripMenuItem
            // 
            this.ホスト追加ToolStripMenuItem.Name = "ホスト追加ToolStripMenuItem";
            this.ホスト追加ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.ホスト追加ToolStripMenuItem.Text = "ホスト追加";
            this.ホスト追加ToolStripMenuItem.Click += new System.EventHandler(this.ホスト追加ToolStripMenuItem_Click);
            // 
            // ホスト削除ToolStripMenuItem
            // 
            this.ホスト削除ToolStripMenuItem.Name = "ホスト削除ToolStripMenuItem";
            this.ホスト削除ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.ホスト削除ToolStripMenuItem.Text = "ホスト削除";
            this.ホスト削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem1_Click);
            // 
            // 接続ToolStripMenuItem1
            // 
            this.接続ToolStripMenuItem1.Name = "接続ToolStripMenuItem1";
            this.接続ToolStripMenuItem1.Size = new System.Drawing.Size(174, 30);
            this.接続ToolStripMenuItem1.Text = "接続";
            this.接続ToolStripMenuItem1.Click += new System.EventHandler(this.接続ToolStripMenuItem1_Click);
            // 
            // 切断ToolStripMenuItem1
            // 
            this.切断ToolStripMenuItem1.Name = "切断ToolStripMenuItem1";
            this.切断ToolStripMenuItem1.Size = new System.Drawing.Size(174, 30);
            this.切断ToolStripMenuItem1.Text = "切断";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.ContextMenuStrip = this.contextMenu_ConfigManager;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(362, 379);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RemoteFilemanagerView);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(354, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RemoteFile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LocalFileView);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(354, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LocalFile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LocalFileView
            // 
            this.LocalFileView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LocalFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalFileView.ImageIndex = 0;
            this.LocalFileView.ImageList = this.imageList1;
            this.LocalFileView.Location = new System.Drawing.Point(3, 3);
            this.LocalFileView.Name = "LocalFileView";
            this.LocalFileView.SelectedImageIndex = 0;
            this.LocalFileView.Size = new System.Drawing.Size(348, 341);
            this.LocalFileView.TabIndex = 12;
            this.LocalFileView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.LocalFileView_BeforeExpand);
            this.LocalFileView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LocalFileView_NodeMouseDoubleClick);
            this.LocalFileView.DoubleClick += new System.EventHandler(this.LocalFileView_DoubleClick);
            // 
            // TemplateView
            // 
            this.TemplateView.AllowDrop = true;
            this.TemplateView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TemplateView.ContextMenuStrip = this.ContextMenu_Template;
            this.TemplateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateView.ImageIndex = 0;
            this.TemplateView.ImageList = this.imageList1;
            this.TemplateView.LabelEdit = true;
            this.TemplateView.Location = new System.Drawing.Point(0, 0);
            this.TemplateView.Name = "TemplateView";
            this.TemplateView.SelectedImageIndex = 0;
            this.TemplateView.Size = new System.Drawing.Size(277, 341);
            this.TemplateView.TabIndex = 0;
            this.TemplateView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TemplateView_DrawNode);
            this.TemplateView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TemplateView_ItemDrag);
            this.TemplateView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TemplateView_AfterSelect);
            this.TemplateView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TemplateView_DragDrop);
            this.TemplateView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TemplateView_DragEnter);
            this.TemplateView.DragOver += new System.Windows.Forms.DragEventHandler(this.TemplateView_DragOver);
            this.TemplateView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigManageTree_KeyUp);
            this.TemplateView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConfigManageTree_KeyUp);
            // 
            // ContextMenu_Template
            // 
            this.ContextMenu_Template.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ContextMenu_Template.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem1,
            this.削除ToolStripMenuItem2});
            this.ContextMenu_Template.Name = "ContextMenu_Template";
            this.ContextMenu_Template.Size = new System.Drawing.Size(134, 64);
            // 
            // 追加ToolStripMenuItem1
            // 
            this.追加ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.テンプレートグループToolStripMenuItem,
            this.テンプレートToolStripMenuItem});
            this.追加ToolStripMenuItem1.Name = "追加ToolStripMenuItem1";
            this.追加ToolStripMenuItem1.Size = new System.Drawing.Size(133, 30);
            this.追加ToolStripMenuItem1.Text = "追加";
            // 
            // テンプレートグループToolStripMenuItem
            // 
            this.テンプレートグループToolStripMenuItem.Name = "テンプレートグループToolStripMenuItem";
            this.テンプレートグループToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.テンプレートグループToolStripMenuItem.Text = "テンプレートグループ";
            this.テンプレートグループToolStripMenuItem.Click += new System.EventHandler(this.テンプレートグループToolStripMenuItem_Click);
            // 
            // テンプレートToolStripMenuItem
            // 
            this.テンプレートToolStripMenuItem.Name = "テンプレートToolStripMenuItem";
            this.テンプレートToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.テンプレートToolStripMenuItem.Text = "テンプレート";
            // 
            // 削除ToolStripMenuItem2
            // 
            this.削除ToolStripMenuItem2.Name = "削除ToolStripMenuItem2";
            this.削除ToolStripMenuItem2.Size = new System.Drawing.Size(133, 30);
            this.削除ToolStripMenuItem2.Text = "削除";
            this.削除ToolStripMenuItem2.Click += new System.EventHandler(this.削除ToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1211, 774);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ConfigManagerView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer2.Size = new System.Drawing.Size(1211, 391);
            this.splitContainer2.SplitterDistance = 360;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(0, 0);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(847, 391);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl2_Selected);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer3.Size = new System.Drawing.Size(1211, 379);
            this.splitContainer3.SplitterDistance = 362;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl3
            // 
            this.tabControl3.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl3.Controls.Add(this.FileDetail);
            this.tabControl3.Controls.Add(this.Output);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(845, 379);
            this.tabControl3.TabIndex = 0;
            // 
            // FileDetail
            // 
            this.FileDetail.Controls.Add(this.splitContainer4);
            this.FileDetail.Location = new System.Drawing.Point(4, 4);
            this.FileDetail.Name = "FileDetail";
            this.FileDetail.Padding = new System.Windows.Forms.Padding(3);
            this.FileDetail.Size = new System.Drawing.Size(837, 347);
            this.FileDetail.TabIndex = 1;
            this.FileDetail.Text = "FileDetail";
            this.FileDetail.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.TemplateView);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer4.Size = new System.Drawing.Size(831, 341);
            this.splitContainer4.SplitterDistance = 277;
            this.splitContainer4.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.fileneame,
            this.PATH});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(550, 341);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // fileneame
            // 
            this.fileneame.HeaderText = "ファイル名";
            this.fileneame.Name = "fileneame";
            this.fileneame.Width = 150;
            // 
            // PATH
            // 
            this.PATH.HeaderText = "パス";
            this.PATH.Name = "PATH";
            this.PATH.Width = 400;
            // 
            // Output
            // 
            this.Output.Controls.Add(this.ConsoleText);
            this.Output.Location = new System.Drawing.Point(4, 4);
            this.Output.Name = "Output";
            this.Output.Padding = new System.Windows.Forms.Padding(3);
            this.Output.Size = new System.Drawing.Size(837, 347);
            this.Output.TabIndex = 0;
            this.Output.Text = "Output";
            this.Output.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStrip_address});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1211, 31);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 28);
            this.toolStripLabel1.Text = "パス：";
            // 
            // toolStrip_address
            // 
            this.toolStrip_address.Name = "toolStrip_address";
            this.toolStrip_address.Size = new System.Drawing.Size(1000, 31);
            // 
            // overlay_imageList
            // 
            this.overlay_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("overlay_imageList.ImageStream")));
            this.overlay_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.overlay_imageList.Images.SetKeyName(0, "109_AllAnnotations_Default_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(1, "109_AllAnnotations_Complete_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(2, "109_AllAnnotations_Error_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(3, "109_AllAnnotations_Help_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(4, "109_AllAnnotations_Info_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(5, "109_AllAnnotations_Warning_16x16_72.png");
            this.overlay_imageList.Images.SetKeyName(6, "pending_request_16x16_72.png");
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1211, 878);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "構成管理ツール";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.contextMenu_ConfigManager.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu_RemoteFilemanager.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ContextMenu_Template.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.FileDetail.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Output.ResumeLayout(false);
            this.Output.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox ConsoleText;
        private System.Windows.Forms.TreeView RemoteFilemanagerView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenu_ConfigManager;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_host_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 上書き保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 印刷PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 印刷プレビューVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 元に戻すUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem やり直しRToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 切り取りTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コピーCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼り付けPToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem すべて選択AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem カスタマイズCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem オプションOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内容CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem インデックスIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 検索SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報AToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem1;
        private System.Windows.Forms.TreeView LocalFileView;
        private System.Windows.Forms.ToolStripMenuItem add_hostgroup_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_configfile_ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem add_filegroup_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 変数編集ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TreeView TemplateView;
        private System.Windows.Forms.ContextMenuStrip contextMenu_RemoteFilemanager;
        private System.Windows.Forms.ToolStripMenuItem ホスト追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ホスト削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_address;
        private System.Windows.Forms.ToolStripMenuItem 表示VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem エンコードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sJISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eUCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cRLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lFToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage Output;
        private System.Windows.Forms.TabPage FileDetail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileneame;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATH;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView ConfigManagerView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 接続ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切断ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再読込ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenu_Template;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem テンプレートグループToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem テンプレートToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイルを比較するToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接続ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 切断ToolStripMenuItem1;
        private System.Windows.Forms.ImageList overlay_imageList;
    }
}

