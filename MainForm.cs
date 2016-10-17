using NodeTag;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinSCP;
using csdiff;
using Acha_ya.SampleApplication;

namespace ConfigManage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /////////////////////////////
            //ConfigManagerViewの初期化
            /////////////////////////////

            //ドラッグを受け入れる
            ConfigManagerView.AllowDrop = true;
            Xmlfile xf = new Xmlfile();
            ConfigManagerView.Nodes.Add("DataCenter");

            xf.DeserializeTreeView(ConfigManagerView, configmanagerxmlpath);

            //////////////////////////////
            //LocalFileManagerViewの初期化
            //////////////////////////////
            TreeNode tn = new TreeNode(System.Net.Dns.GetHostName()); //ホスト名を取得してノードを作成
            string[] dri = Environment.GetLogicalDrives();//ドライブ名を取得
            foreach (string d in dri)
            {
                TreeNode childnode = new TreeNode(d, 1, 1);
                childnode.Nodes.Add("..");//架空の枝を追加
                tn.Nodes.Add(childnode);//ノードライブアイコンを設定
            }
            LocalFileView.Nodes.Add(tn);//親ノードにドライブを設定

            ////////////////////////////////
            //RemoteFileManagerViewの初期化/
            ////////////////////////////////

            //ドラッグを受け入れる
            RemoteFilemanagerView.AllowDrop = true;
            Xmlfile remotehostxml = new Xmlfile();
            remotehostxml.DeserializeTreeView(RemoteFilemanagerView, remotehostxmlpath);

            /////////////////////////////
            //TemplateViewの初期化
            /////////////////////////////

            //ドラッグを受け入れる
            TemplateView.AllowDrop = true;
            Xmlfile tvxml = new Xmlfile();
            remotehostxml.DeserializeTreeView(TemplateView, templatexmlpath);
            //            TemplateView.Nodes.Add("Template", "Template",3,3);
            //            tvxml.DeserializeTreeView(TemplateView, templatexmlpath);

            /////////////////////////////
            //比較Viewの初期化
            /////////////////////////////
            /*            NativeMethods nativemeth = new NativeMethods();
                        nativemeth.ImageList_SetOverlayImage(imageList1.Handle, 2, 1);
                        */
            // imageList1.Image[1] のイメージをオーバーレイアイコンインデックス値1で登録
            NativeMethods.ImageList_SetOverlayImage(imageList1.Handle, 7, 1);
            NativeMethods.ImageList_SetOverlayImage(imageList1.Handle, 8, 2);
        }

        #region　メニュー・コンテキストメニューイベント時の動作
        //メニュー動作
        /////////////////////////////////////////////////////////////////////////////////////
        private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xmlfile xf = new Xmlfile();
            xf.SerializeTreeView(ConfigManagerView, configmanagerxmlpath);
            xf.SerializeTreeView(RemoteFilemanagerView, remotehostxmlpath);
            xf.SerializeTreeView(TemplateView, templatexmlpath);
        }

        //名前をつけて保存
        private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "*.xml";       //はじめに「ファイル名」で表示される文字列を指定する
            sfd.InitialDirectory = appDirPath; //ディレクトリ初期位置の指定
            sfd.Filter = "xmlファイル(*.xml)|すべてのファイル(*.*)";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 2;                        //2番目の「すべてのファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";            //タイトル
            sfd.RestoreDirectory = true;            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;            //既に存在するファイル名を指定したとき警告する
            sfd.CheckPathExists = true;            //存在しないパスが指定されたとき警告を表示する

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Xmlfile xf = new Xmlfile();
                xf.SerializeTreeView(ConfigManagerView, sfd.FileName);
                xf.SerializeTreeView(RemoteFilemanagerView, sfd.FileName);
                xf.SerializeTreeView(TemplateView, sfd.FileName);
            }
        }

        private void 削除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode();
            GetSelectedNode(ref tn);
            tn.Remove();      //選択したノードを削除
        }

        //変数の編集メニュー
        private void 変数編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariableSetting f = new VariableSetting();
            TreeNode selectnode = ConfigManagerView.SelectedNode;
            LinNodeTag LinNT = (LinNodeTag)selectnode.Tag;
            LinNodeTag linnodetag = new LinNodeTag();//tagの割り当て
            linnodetag.NodeProfile = new Node_Profile();
            linnodetag.NodeProfile.EnvVariableTable = new Hashtable();

            if (ConfigManagerView.SelectedNode.IsSelected)  //ConfigManagerTreeのノードが選択されていたら
            {
                if (LinNT != null)
                {
                    foreach (DictionaryEntry varrec in LinNT.NodeProfile.EnvVariableTable)
                    {
                        f.dataGridView1.Rows.Add(varrec.Value, varrec.Value);
                    }
                }
                //フォームの表示
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    try //null例外許す
                    {
                        foreach (DataGridViewRow row in f.dataGridView1.Rows)
                        {
                            linnodetag.NodeProfile.EnvVariableTable.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                        }
                    }
                    catch (Exception msg)
                    {
                        switch (msg.HResult)
                        {
                            case -2147467261: //tagがnullのときは無視
                                break;
                            default:
                                ConsoleText.Text = msg.Message;
                                break;
                        }
                    }
                    finally
                    {
                        selectnode.Tag = linnodetag;
                    }
                }
                else if (f.DialogResult == DialogResult.Cancel)
                {
                }
                f.Dispose();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ConnectHost f = new ConnectHost();
            TreeView FocusedControl = new TreeView();

            //どのコントロールがアクティブか調べる
            if (ConfigManagerView.Focused)
            {
                FocusedControl = ConfigManagerView;
                add_hostgroup_ToolStripMenuItem.Enabled = true;
                add_host_ToolStripMenuItem.Enabled = true;
            }
            else if (TemplateView.Focused)
            {
                FocusedControl = TemplateView;
                add_hostgroup_ToolStripMenuItem.Enabled = false;
                add_host_ToolStripMenuItem.Enabled = false;
            }

        }

        //ホストの追加
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ConnectHostクラスのインスタンスを作成する
            ConnectHost f = new ConnectHost();
            TreeView FocusedControl = new TreeView();

            //どのコントロールがアクティブか調べる
            if (ConfigManagerView.Focused)
            {
                FocusedControl = ConfigManagerView;
            }
            else if (RemoteFilemanagerView.Focused)
            {
                FocusedControl = RemoteFilemanagerView;
            }

            //ConnectHostを表示する
            //ダイアログを表示する
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                TreeNode tn = new TreeNode(), tn2;  //tn;新たなノードを追加
                if (FocusedControl.SelectedNode != null)
                {
                    tn = FocusedControl.SelectedNode;
                    tn = tn.Nodes.Add(f.HostName.Text.ToString());
                    //                    tn = FocusedControl.SelectedNode;
                }
                else
                {
                    tn = FocusedControl.Nodes.Add(f.HostName.Text.ToString());
                }
                //親ノードにドライブを設定
                SessionOptions current_sessionOptions = new SessionOptions();
                LinNodeTag linnodetag = new LinNodeTag();
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    linnodetag.HostName = f.HostName.Text;
                    linnodetag.UserName = f.UserName.Text;
                    linnodetag.PassWord = f.Password.Text;
                    linnodetag.PortNo = int.Parse(f.PortNo.Text);
                    linnodetag.FtpMode = f.passivemode;
                    linnodetag.InputSessionOptions(current_sessionOptions);
                    tn.Tag = linnodetag;

                    // sessionの作成
                    sessionid = RemoteFilemanagerView.Nodes.Count - 1;
                    current_session[sessionid] = new Session();
                    current_session[sessionid].Open(current_sessionOptions);

                    if (FocusedControl.Name == "RemoteFilemanagerView")
                    {
                        RemoteDirectoryInfo directory = current_session[sessionid].ListDirectory("/");
                        foreach (RemoteFileInfo fileInfo in directory.Files)
                        {
                            if (fileInfo.IsDirectory && !fileInfo.IsParentDirectory && !fileInfo.IsThisDirectory)
                            {
                                tn2 = new TreeNode(fileInfo.Name, 3, 3);
                                tn.Nodes.Add(tn2);
                                tn2.Nodes.Add("..");
                            }
                        }
                    }
                }
                //                return 0;
                catch (Exception msg)
                {
                    ConsoleText.Text = msg.Message;
                }
                finally
                {
                    Cursor.Current = Cursors.Arrow;
                }
                sessionid++;
            }
        }

        //ホストグループの追加
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfigManagerView.SelectedNode.IsSelected)  //ConfigManagerTreeのノードが選択されていたら
                {
                    TreeNode newnode = ConfigManagerView.SelectedNode.Nodes.Add("新しいホストグループ", "新しいホストグループ", 3);
                    newnode.Tag = new HostGroupNodeTag(); //tagの割り当て
                }
            }
            catch { }
        }

        //コンテキストメニュー２(Remotefilemanager用)
        private void ホスト追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ConnectHostクラスのインスタンスを作成する
            ConnectHost f = new ConnectHost();

            //ConnectHostを表示する
            //ダイアログを表示する
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                TreeNode tn = RemoteFilemanagerView.Nodes.Add(f.HostName.Text), tn2;                            //tn;新たなノードを追加
                Cursor.Current = Cursors.WaitCursor;

                if (f.Platform_Linux.Checked)
                {
                    SessionOptions current_sessionOptions = new SessionOptions(); //親ノードにドライブを設定
                    LinNodeTag linnodetag = new LinNodeTag();

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        linnodetag.HostName = f.HostName.Text;
                        linnodetag.UserName = f.UserName.Text;
                        linnodetag.PassWord = f.Password.Text;
                        linnodetag.PortNo = int.Parse(f.PortNo.Text);
                        linnodetag.FtpMode = f.passivemode;
                        linnodetag.InputSessionOptions(current_sessionOptions);
                        tn.Tag = linnodetag;

                        // sessionの作成
                        sessionid = RemoteFilemanagerView.Nodes.Count - 1;
                        current_session[sessionid] = new Session();
                        current_session[sessionid].Open(current_sessionOptions);

                        RemoteDirectoryInfo directory = current_session[sessionid].ListDirectory("/");
                        foreach (RemoteFileInfo fileInfo in directory.Files)
                        {
                            if (fileInfo.IsDirectory && !fileInfo.IsParentDirectory && !fileInfo.IsThisDirectory)
                            {
                                tn2 = new TreeNode(fileInfo.Name, 3, 3);
                                tn.Nodes.Add(tn2);
                                tn2.Nodes.Add("..");
                            }
                        }
                    }
                    //                return 0;
                    catch (Exception msg)
                    {
                        ConsoleText.Text = msg.Message;
                    }
                    sessionid++;
                }
                //Windowsの場合
                else if (f.Platform_Windows.Checked)
                {
                    WinNodeTag winnodetag = new WinNodeTag();

                    winnodetag.HostName = f.HostName.Text;
                    winnodetag.UserName = f.UserName.Text;
                    winnodetag.PassWord = f.Password.Text;
                    tn.Tag = winnodetag;
                    /*
                                        ConnectionOptions option = new ConnectionOptions();
                                        option.Username = "DomainName\\UserName";
                                        option.Password = "パスワードを入れる";
                                        ManagementScope scope = new ManagementScope("\\\\ServerName\\root\\cimv2", option);
                                        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");
                                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                                        ManagementObjectCollection moCollection = searcher.Get();

                                        foreach (ManagementObject mo in moCollection)
                                        {
                                            Console.WriteLine("Name:\t{0}", mo["Name"]);
                                        }
                                        try
                                        {
                                            //とりあえずコピーできるかやってみる
                                            File.Delete(destFilePath);
                                            File.Copy(sourceFilePath, destFilePath);
                                        }

                                        //認証に失敗すると UnauthorizedAccessException が発生する(Exceptionでキャッチしてもいいかも)
                                        catch (UnauthorizedAccessException)
                                        {
                                            // 接続情報を設定  
                                            NETRESOURCE netResource = new NETRESOURCE();
                                            netResource.dwScope = 0;
                                            netResource.dwType = 1;
                                            netResource.dwDisplayType = 0;
                                            netResource.dwUsage = 0;
                                            netResource.lpLocalName = ""; // ネットワークドライブにする場合は"z:"などドライブレター設定  
                                            netResource.lpRemoteName = shareName;
                                            netResource.lpProvider = "";
                                            string password = "ness7591";
                                            string userId = "takamure";
                    //                        string password = winnodetag.PassWord;
                    //                        string userId = @winnodetag.UserName;
                                            int ret = 0;

                                            try
                                            {
                                                //既に接続してる場合があるので一旦切断する
                                                ret = WNetCancelConnection2(shareName, 0, true);
                                                //共有フォルダに認証情報を使って接続
                                                ret = WNetAddConnection2(ref netResource, "ness7591", "takamure", 0);
                                            }
                                            catch (Exception)
                                            {
                                                //エラー処理
                                            }

                                            string[] dri = Environment.GetLogicalDrives();//ドライブ名を取得
                                            foreach (string d in dri)
                                            {
                                                TreeNode childnode = new TreeNode(d, 1, 1);
                                                childnode.Nodes.Add("..");//架空の枝を追加
                                                tn.Nodes.Add(childnode);//ノードライブアイコンを設定
                                            }
                                            LocalFileView.Nodes.Add(tn);//親ノードにドライブを設定

                                            Console.WriteLine(ret);

                                            //ファイルコピー
                                            File.Delete(destFilePath);
                                            File.Copy(sourceFilePath, destFilePath);
                                        }
                                        Console.WriteLine("終了");
                                        Console.ReadLine();
                                    }*/
                }

                Cursor.Current = Cursors.Arrow;
            }
        }
        //コンテキストメニューファイルグループの追加
        private void add_filegroup_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode sn = new TreeNode();

            try
            {
                if (GetSelectedNode(ref sn))  //ノードが選択されていたら
                {
                    TreeNode newnode = sn.Nodes.Add("NewFolder", "NewFolder", 3, 3);
                }
            }
            catch { }
        }

        //コンテキストメニューファイル追加
        private void add_configfile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode sn = new TreeNode();

            try
            {
                if (GetSelectedNode(ref sn))  //ノードが選択されていたら
                {
                    TreeNode newnode = sn.Nodes.Add("newfile", "newfile", 5, 5);
                }
            }
            catch { }
        }

        private void sJISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*            TabPage tabpage = tabControl2.SelectedTab;
                        string filename = tabpage.Text ;                    //ファイル名の取得
                        string localpath = appDirPath + "\\" + filename;

                        try
                        {
                                Cursor.Current = Cursors.WaitCursor;

                            //テキストファイル読み込み
                                if (IsTextFile(localpath))
                                {
                                    StreamReader sr = new StreamReader(localpath, Encoding.GetEncoding("Shift_JIS"));
                                    string text = sr.ReadToEnd();
                                    sr.Close();

                                    tabpage.Text = filename;
                                    tabpage.Text = text;
                                }
                                else
                                {
                                    CustomLogWrite(ConsoleText, " テキストファイル形式で読み込めません。");
                                }
                        }
                        catch (Exception msg)
                        {
                            CustomLogWrite(ConsoleText, msg.Message);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Arrow;
                        }*/
        }

        private void add_template_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode sn = new TreeNode();

            try
            {
                if (GetSelectedNode(ref sn))  //ノードが選択されていたら
                {
                    TreeNode newnode = sn.Nodes.Add("NewTemplate", "NewTemplate", 5, 5);
                    //                    newnode.Tag = 
                }
            }
            catch { }
        }

        private void テンプレートグループToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode sn = new TreeNode();
            int i = 1;
            try
            {
                if (GetSelectedNode(ref sn))  //ノードが選択されていたら
                {
                    //作成するノードグループの名前作成
                    string BaseName = "NewTplGrp", CreNodeName = BaseName;
                    foreach (TreeNode tn in sn.Nodes) //TODO このロジックだとCreNodeNameがかぶる場合がある
                    {
                        if (tn.Text == CreNodeName)
                        {
                            CreNodeName = BaseName + i.ToString();
                            i++;
                        }
                    }

                    //作成するディレクトリ
                    string CreDir = templatedir + sn.FullPath.Replace(GetRootNode(sn).Text, "") + "\\" + CreNodeName;

                    //TreeNodeの作成
                    TreeNode newnode = sn.Nodes.Add(CreNodeName, CreNodeName, 3, 3);
                    SafeCreateDirectory(CreDir);
                }
            }
            catch { }
        }
        #endregion

        #region ConfigManagementイベント時の動作
        //TODO NODEの親子関係を入れる。
        //ConfigManagementのノードを展開しようとしているときの動作
        private void ConfigManageTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode tn = e.Node, tn2;          //展開対象のノード
            string d = tn.FullPath;           　//展開するノードのフルパスを取得
            tn.Nodes.Clear();
            try
            {
                foreach (DirectoryInfo childdir in tn.Nodes)
                {
                    tn2 = new TreeNode(childdir.Name, 3, 3);
                    tn.Nodes.Add(tn2);
                    tn2.Nodes.Add("..");
                }
            }
            catch (Exception msg)
            {
                ConsoleText.Text = msg.Message;
            }
        }

        //ドロップされたときの動作
        private void ConfigManageTree_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたデータがTreeNodeか調べる
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeView tv = (TreeView)sender;                                             //ドロップされたデータ(TreeNode)を取得
                TreeNode source = (TreeNode)e.Data.GetData(typeof(TreeNode));             　//ドロップ元のTreeNode
                TreeNode target = tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y)));      //ドロップ先のTreeNode

                //マウス下のNodeがドロップ先として適切か調べる
                if (target != null && target != source /*&& !IsChildNode(SrcTreeNode, TgtTreeNode)*/)
                {
                    //ドロップされたNodeのコピーを作成
                    TreeNode cln = (TreeNode)source.Clone();
                    target.Nodes.Add(cln);                       //Nodeを追加
                    target.Expand();                             //ドロップ先のNodeを展開
                    tv.SelectedNode = cln;                       //追加されたNodeを選択
                }
                else
                    e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        //ドラッグしているときの動作
        private void ConfigManageTree_DragOver(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがTreeNodeか調べる
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                if ((e.KeyState & 8) == 8 &&
                    (e.AllowedEffect & DragDropEffects.Copy) ==
                    DragDropEffects.Copy)
                    //Ctrlキーが押されていればCopy
                    //"8"はCtrlキーを表す
                    e.Effect = DragDropEffects.Copy;
                else if ((e.AllowedEffect & DragDropEffects.Move) ==
                    DragDropEffects.Move)
                    //何も押されていなければMove
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            else
                //TreeNodeでなければ受け入れない
                e.Effect = DragDropEffects.None;

            //マウス下のNodeを選択する
            if (e.Effect != DragDropEffects.None)
            {
                TreeView tv = (TreeView)sender;
                //マウスのあるNodeを取得する
                TreeNode target =
                    tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y)));
                //ドラッグされているNodeを取得する
                TreeNode source =
                    (TreeNode)e.Data.GetData(typeof(TreeNode));
                //マウス下のNodeがドロップ先として適切か調べる
                if (target != null && target != source /*&&
                        !IsChildNode(SrcTreeNode, TgtTreeNode)*/)
                {
                    //Nodeを選択する
                    if (target.IsSelected == false)
                        tv.SelectedNode = target;
                }
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        //ドラックしはじめの動作
        private void ConfigManageTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            tv.SelectedNode = (TreeNode)e.Item;
            tv.Focus();
            //ノードのドラッグを開始する
            DragDropEffects dde =
                tv.DoDragDrop(e.Item, DragDropEffects.All);
            //移動した時は、ドラッグしたノードを削除する
            if ((dde & DragDropEffects.Move) == DragDropEffects.Move)
                tv.Nodes.Remove((TreeNode)e.Item);
        }

        //ツリーノードのラベルの編集が開始された時
        private void ConfigManageTree_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //ルートのコードは編集できないようにする
            if (e.Node.Parent == null)
            {
                e.CancelEdit = true;
            }
        }

        //ツリーノードのラベルの編集された時
        private void ConfigManageTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //ラベルが変更されたか調べる
            //e.Labelがnullならば、変更されていない
            if (e.Label != null)
            {
                //同名のノードが同じ親ノード内にあるか調べる
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode n in e.Node.Parent.Nodes)
                    {
                        //同名のノードがあるときは編集をキャンセルする
                        if (n != e.Node && n.Text == e.Label)
                        {
                            MessageBox.Show("同名のノードがすでにあります。");
                            //編集をキャンセルして元に戻す
                            e.CancelEdit = true;
                            return;
                        }
                    }
                }
            }

        }

        //ツリーノードのキーが押された時
        private void ConfigManageTree_KeyUp(object sender, KeyEventArgs e)
        {
        TreeView tv = (TreeView)sender;

            //F2キーが離されたときは、フォーカスのあるアイテムの編集を開始
            if (e.KeyCode == Keys.F2 && tv.SelectedNode != null && tv.LabelEdit)
            {
                tv.SelectedNode.BeginEdit();
            }
        }

        //ノードがダブルクリックされたとき
        private void ConfigManagerView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (((TreeView)sender).SelectedNode.Tag.GetType() == typeof(TemplateTag))
                {
                    TreeNode tn = ((TreeView)sender).SelectedNode;
                    TemplateTag TpltTag = (TemplateTag)tn.Tag;

                    string LeftFilePath = appDirPath + "\\" + tn.FullPath;  //ダウンロード先パス
                                                                            //TODO TemplateView側のノード配置に変更があったときに反映されるようロジック変更が必要
                    string RightFilePath = TpltTag.localfile_fullpath;

                    AddTabControlWithDiff(tabControl2, LeftFilePath, RightFilePath);
                }
            }
            catch
            {

            }
        }

        #endregion

        #region LocalFileViewのイベント時の動作
        private void LocalFileView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            DirectoryInfo di;

            if (e.Node.Parent != null)
            {
                TreeNode tn = e.Node, tn2;
                string d = tn.FullPath;//展開するノードのフルパスを取得
                d = d.Replace(System.Net.Dns.GetHostName() + "\\", ""); //ホスト名削除
                tn.Nodes.Clear();
                di = new DirectoryInfo(d);//ディレクトリ一覧を取得
                try
                {
                    foreach (DirectoryInfo d2 in di.GetDirectories())
                    {
                        tn2 = new TreeNode(d2.Name, 3, 4);
                        tn.Nodes.Add(tn2);
                        tn2.Nodes.Add("..");
                    }
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        tn2 = new TreeNode(fi.Name, 5, 5);
                        tn.Nodes.Add(tn2);
                    }
                }
                catch (Exception msg)
                {
                    ConsoleText.Text = msg.Message;
                }
            }
        }

        private void LocalFileView_DoubleClick(object sender, EventArgs e)
        {
        }

        private void LocalFileView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = LocalFileView.SelectedNode;   //選択されたノードを取得
            if (tn.Parent != null)
            {
                string filepath = tn.FullPath;
                filepath = filepath.Replace(System.Net.Dns.GetHostName() + "\\", ""); //ホスト名削除

                if (IsTextFile(filepath))
                {
                    AddTabControlWithText(tabControl2, filepath);
                }
                else
                {
                    DateTime tm = DateTime.Now;
                    ConsoleText.AppendText(tm + " テキストファイル形式で読み込めません。");
                }
            }

        }
        #endregion

        #region RemoteFileViewのイベント時の動作
        private void RemoteFilemanagerView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolStrip_address.Text = e.Node.FullPath;
        }

        //ノードを展開したときの動作
        private void RemoteFilemanagerView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode tn = e.Node, tn2;
            TreeNode rootnode = GetRootNode(tn);
            if (tn.Parent != null)
            {
                string d = tn.FullPath;                                     //展開するノードのフルパスを取得
                d = d.Replace("\\", "/");
                //            tn.Nodes.Clear();
                d = d.Replace(rootnode.Text, "");//ホスト名の削除
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    tn.Nodes.Clear();
                    RemoteDirectoryInfo directory = current_session[rootnode.Index].ListDirectory(d);

                    foreach (RemoteFileInfo fileInfo in directory.Files)
                    {
                        if (fileInfo.IsDirectory && !fileInfo.IsParentDirectory && !fileInfo.IsThisDirectory)
                        {
                            tn2 = new TreeNode(fileInfo.Name, 3, 3);
                            tn.Nodes.Add(tn2);
                            tn2.Nodes.Add("..");
                        }
                    }
                    foreach (RemoteFileInfo fileInfo in directory.Files)
                    {
                        if (!fileInfo.IsDirectory && !fileInfo.IsParentDirectory && !fileInfo.IsThisDirectory)
                        {
                            tn2 = new TreeNode(fileInfo.Name, 5, 5);
                            tn.Nodes.Add(tn2);
                        }
                    }
                }
                catch (Exception msg)
                {
                    ConsoleText.Text = msg.Message;
                }
                finally
                {
                    Cursor.Current = Cursors.Arrow;
                }
            }
            //                return 0;
        }

        //マウスを動かしたとき
        private void RemoteFilemanagerView_MouseMove(object sender, MouseEventArgs e)
        { 
            /*
            TreeView tv;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (sender.GetType().Name == "TreeView")
            {
                tv = (TreeView)sender;
                Cursor.Current = Cursors.Hand;
                _isDraging = true;
                _diffPoint = e.Location;
                if (!_isDraging)
                {
                    return;
                }

                label1.Visible = true;
                label1.Location = e.Location;

                            int x = label1.Location.X + e.X - _diffPoint.Value.X;
                            int y = label1.Location.Y + e.Y - _diffPoint.Value.Y;

                            if (x <= 0) x = 0;
                            if (y <= 0) y = 0;
                            
            }*/
        }

        //マウスボタンを放したとき
        private void RemoteFilemanagerView_MouseUp(object sender, MouseEventArgs e)
        {
            /*            Cursor.Current = Cursors.Default;
                        _isDraging = false;

                        if (e.Button != MouseButtons.Left)
                        {
                            return;
                        }
            */
        }

        //RemoteFilemanagerのダブルクリックされたとき
        private void RemoteFilemanagerView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        //RemoteFilemanagerのノードがダブルクリックされたとき
        private void RemoteFilemanagerView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode slct_tn = RemoteFilemanagerView.SelectedNode;   //選択されたノードを取得
            TreeNode hostnode = GetRootNode(slct_tn);                //対象ホスト名を取得
            string rmt_filepath = slct_tn.FullPath;               //リモートファイルのフルパス
            rmt_filepath = rmt_filepath.Replace(hostnode.Text, ""); //ホスト名削除
            rmt_filepath = rmt_filepath.Replace("\\", "/"); //パスのセパレータ文字変更

            string filename = slct_tn.Text;                          //ファイル名の取得
            sessionid = hostnode.Index;                         //Session番号

            TransferOperationResult TrnOpRst;                   //FTP結果収納変数

            try
            {
                if (slct_tn.Parent != null)
                {
                    string localdir = downloaddir;
                    string localpath = downloaddir + "\\" + filename;
                    Directory.CreateDirectory(localdir);
                    if (Directory.Exists(localpath) == false)
                    {
                    }

                    Cursor.Current = Cursors.WaitCursor;

                    //TODO sessionidの値が正しく動かないときがあるはず。
                    //ダウンロード実行
                    TrnOpRst = current_session[sessionid].GetFiles(rmt_filepath, localpath);

                    // Throw on any error
                    TrnOpRst.Check();

                    //テキストファイル読み込み
                    if (IsTextFile(localpath))
                    {
                        AddTabControlWithText(tabControl2, localpath); //TabにTextBoxタブを追加する。
                    }
                    else
                    {
                        CustomLogWrite(ConsoleText, " テキストファイル形式で読み込めません。");
                    }
                }
            }
            catch (Exception msg)
            {
                CustomLogWrite(ConsoleText, msg.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }

        }

        //ドラッグを始め時
        private void RemoteFilemanagerView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            tv.SelectedNode = (TreeNode)e.Item;
            tv.Focus();
            //ノードのドラッグを開始する
            DragDropEffects dde = tv.DoDragDrop(e.Item, DragDropEffects.All);
            /*            //移動した時は、ドラッグしたノードを削除する
                        if ((dde & DragDropEffects.Move) == DragDropEffects.Move)
                            tv.Nodes.Remove((TreeNode)e.Item);
                            */
        }

        //オブジェクトが境界内にドラッグされたとき
        private void RemoteFilemanagerView_DragOver(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがTreeNodeか調べる
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                if ((e.KeyState & 8) == 8 &&
                    (e.AllowedEffect & DragDropEffects.Copy) ==
                    DragDropEffects.Copy)
                    //Ctrlキーが押されていればCopy
                    //"8"はCtrlキーを表す
                    e.Effect = DragDropEffects.Copy;
                else if ((e.AllowedEffect & DragDropEffects.Move) ==
                    DragDropEffects.Move)
                    //何も押されていなければMove
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            else
                //TreeNodeでなければ受け入れない
                e.Effect = DragDropEffects.None;

            //マウス下のNodeを選択する
            if (e.Effect != DragDropEffects.None)
            {
                TreeView tv = (TreeView)sender;
                //マウスのあるNodeを取得する
                TreeNode target =
                    tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y)));
                //ドラッグされているNodeを取得する
                TreeNode source =
                    (TreeNode)e.Data.GetData(typeof(TreeNode));
                //マウス下のNodeがドロップ先として適切か調べる
                if (target != null && target != source /*&&
                        !IsChildNode(SrcTreeNode, TgtTreeNode)*/)
                {
                    //Nodeを選択する
                    if (target.IsSelected == false)
                        tv.SelectedNode = target;
                }
                else
                    e.Effect = DragDropEffects.None;
            }

        }

        /*        private void RemoteFilemanagerView_MouseDown(object sender, MouseEventArgs e)
                {
                    TreeView tv;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    if (sender.GetType().Name == "TreeView")
                    {
                        tv = (TreeView)sender;
                        Cursor.Current = Cursors.Hand;
                        _isDraging = true;
                        _diffPoint = e.Location;

                        if (tv.SelectedNode != null)
                        {
                            label1.Text = tv.SelectedNode.FullPath;
                            label1.Location = tv.Location;

                            label1.Location.Offset(_diffPoint);
                        }
                    }
                }
        */

        private void 接続ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //現在アクティブなコントロールを取得する
            TreeView ActvTreeView = GetActiveTreeView();

            //選択されたNodeで接続
            ConnectHostFromTreeNode(ActvTreeView.SelectedNode);
        }
        #endregion

        #region TemplateViewのイベント時の動作
        //TemplateViewの動作
        /////////////////////////////////////////////////////////////////////////////////////
        //DRAGで領域に入ったとき
        private void TemplateView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;//ドラッグ＆ドロップの効果を、コピーに設定
        }

        private void TemplateView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            tv.SelectedNode = (TreeNode)e.Item;
            tv.Focus();
            //ノードのドラッグを開始する
            DragDropEffects dde =
                tv.DoDragDrop(e.Item, DragDropEffects.All);
            //移動した時は、ドラッグしたノードを削除する
            /*
             * if ((dde & DragDropEffects.Move) == DragDropEffects.Move)
             * tv.Nodes.Remove((TreeNode)e.Item);
             */
        }

        //DRAGでドロップしたとき
        //TODO 実体のファイルを見てLoadする。
        //TODO コピー先ノードの同一名称のノードがないかチェックが必要。
        private void TemplateView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                //ドロップされたデータがTreeNodeか？
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeView tv = (TreeView)sender;                                     //イベント発生元のTreeView＝TemplateView
                    TreeNode SrcTreeNode = (TreeNode)e.Data.GetData(typeof(TreeNode));  //送り元のTreeNode
                    TreeNode TgtTreeNode = tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y)));//ドロップ先のTreeNode

                    //マウス下のNodeがドロップ先として適切か？
                    if (TgtTreeNode != null && TgtTreeNode != SrcTreeNode)
                    {
                        //ドロップされたNodeのコピーを作成
                        TreeNode SrcTreeNodeClone = (TreeNode)SrcTreeNode.Clone();

                        //if (IsPossibleParent(TgtTreeNode, SrcTreeNodeClone))
                        {
                            TgtTreeNode.Nodes.Add(SrcTreeNodeClone);
                            TgtTreeNode.Expand();                                           //ドロップ先のNodeを展開
                            tv.SelectedNode = SrcTreeNodeClone;                             //追加されたNodeを選択

                            //テンプレートファイルの配置処理
                            string TplPath = templatedir + ConvertFilePath(SrcTreeNodeClone);//テンプレートの絶対パス
                            string TgtTplDir = Path.GetDirectoryName(TplPath);              //対象テンプレートのディレクトリパス

                            //ディレクトリがない場合作成する
                            SafeCreateDirectory(TgtTplDir);

                            //TemplateViewからD&Dされたときの処理
                            if (SrcTreeNode.TreeView.Name == "TemplateView")
                            {
                                //ローカルファイルの移動処理
                                string SrcFilePath = templatedir + 
                                    SrcTreeNode.FullPath.Replace(GetRootNode(SrcTreeNode).Text, "");            //移動元ファイルパス

                                if (SrcTreeNode.SelectedImageIndex == 3) Directory.Move(SrcFilePath, TplPath);   //ディレクトリの移動
                                else if (SrcTreeNode.SelectedImageIndex == 5) File.Move(SrcFilePath, TplPath);   //ファイルの移動

                                //移動元ノードの削除
                                SrcTreeNode.Remove();
                            }
                            //RemoteTreeViewからD&Dされたときの処理
                            else if (SrcTreeNode.TreeView.Name == "RemoteFilemanagerView")
                            {
                                TreeNode hostnode = GetRootNode(SrcTreeNode);                   //対象ホスト名を取得
                                string RmtFilePath = SrcTreeNode.FullPath.                      //リモートファイルのフルパス
                                    Replace(hostnode.Text, "").                                 //ホスト名削除
                                    Replace("\\", "/");                                         //パスのセパレータ文字変更

                                //TODO sessionidの値が不正でホストが複数あるとき正しく動かないかも。
                                //ダウンロード実行
                                TransferOperationResult TrnOperRslt;                            //FTP結果収納変数
                                TrnOperRslt = current_session[hostnode.Index].GetFiles(RmtFilePath, TplPath);

                                //タグにファイルパスを追加
                                TemplateTag TgtFileNodeTag = new TemplateTag();
                                TgtFileNodeTag.remotefile_fullpath = RmtFilePath;
                                TgtFileNodeTag.localfile_fullpath = TplPath;
                                TgtFileNodeTag.filename = SrcTreeNodeClone.Text;

                                SrcTreeNodeClone.Tag = TgtFileNodeTag;
                            }
                        }
                        //Nodeを追加処理
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception msg)
            {
                CustomLogWrite(ConsoleText, msg.Message);
            }
        }

        //DRAG中
        private void TemplateView_DragOver(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがTreeNodeか調べる
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                //TreeNodeでなければ受け入れない
                e.Effect = DragDropEffects.None;

            //マウス下のNodeを選択する
            if (e.Effect != DragDropEffects.None)
            {
                TreeView tv = (TreeView)sender;
                //マウスのあるNodeを取得する
                TreeNode target =
                    tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y)));
                //ドラッグされているNodeを取得する
                TreeNode source =
                    (TreeNode)e.Data.GetData(typeof(TreeNode));
                //マウス下のNodeがドロップ先として適切か調べる
                if (target != null && target != source /*&&
                        !IsChildNode(SrcTreeNode, TgtTreeNode)*/)
                {
                    //Nodeを選択する
                    if (target.IsSelected == false)
                        tv.SelectedNode = target;
                }
                else
                    e.Effect = DragDropEffects.None;
            }

        }

        //領域内で再描画されたとき
        private void TemplateView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }

        //ノードが選択されたとき
        private void TemplateView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode carrent_node = e.Node;  //選択されたノード宣言
            dataGridView1.Rows.Clear();
            try
            {
                if (carrent_node.ImageIndex == 3) //フォルダの時は配下のテンプレートを表示
                {
                    foreach (TreeNode child_node in carrent_node.Nodes)
                    {
                        if (child_node.ImageIndex == 5)
                        {
                            TemplateTag fnt = (TemplateTag)child_node.Tag; //TODO　変換できなかった場合の処理を後で追加（T.B.D）
                            dataGridView1.Rows.Add(child_node.Text, child_node.Text, fnt.remotefile_fullpath);
                        }
                    }
                }
                else if (carrent_node.ImageIndex == 5) //ファイルの時はテンプレートを表示
                {
                    TemplateTag fnt = (TemplateTag)carrent_node.Tag;
                    dataGridView1.Rows.Add(carrent_node.Text, carrent_node.Text, fnt.remotefile_fullpath);
                }
            }
            catch (Exception msg)
            {
                CustomLogWrite(ConsoleText, msg.Message);
            }
        }
        #endregion

        //TreeViewのサイズを固定化する。
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer3.SplitterDistance = 300;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsoleText_TextChanged(object sender, EventArgs e)
        {
            //            tabControl3.SelectedTab = Output;
        }

        private void ファイルを比較するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csdiff.openFileDlg dlg = new csdiff.openFileDlg();
            DialogResult result = dlg.ShowDialog(this);
            if (result != DialogResult.OK) return;

            OpenFileBoth(dlg.edFilePath1.Text, dlg.edFilePath2.Text);
        }

        protected void OpenFileBoth(string leftname, string rightname)
        {
            AddTabControlWithDiff(tabControl2, leftname, rightname);

            /*            Document document = new Document();
                        Option option = new Option();
                        csdiff.View view1 = new  csdiff.View(document, option);

                        view1.Parent = this;
                        view1.Dock = DockStyle.Fill;
                        view1.Show();

                        // tabの追加
                        TabPage myTabPage = new TabPage("aaa");
                        myTabPage.Controls.Add(view1);
                        tabControl2.TabPages.Add(myTabPage);
                        tabControl2.SelectedTab = myTabPage;

                        FnameBar fnameBar = new FnameBar(document, option);
                        //            fnameBar.Parent = myTabPage;
                        fnameBar.Dock = DockStyle.Top;
                        fnameBar.Show();

                        if (leftname != null)
                        {
                            document.Load(DocOf.LEFT, leftname);
                        }
                        if (rightname != null)
                        {
                            document.Load(DocOf.RIGHT, rightname);
                        }
                        fnameBar.Invalidate();

                        if (document.IsLoadedAll())
                        {
            //                mru.Add(document.fnames[(int)DocOf.LEFT] + "/" + document.fnames[(int)DocOf.RIGHT]);
                            document.UpdateCompositSection(option.bIgnoreBlank);
                            view1.InitialUpdate(true);
                        }
                        */
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 再読込ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO Linux専用になっている
            //FocusedControlを取得する（SplitControlを取り除く）

            TreeView FcsdTreeView = GetActiveTreeView(); //選択されたTreeViewを取得する
            TreeNode SlctNode = FcsdTreeView.SelectedNode;//選択されたノード
            TreeNode HostNode = SlctNode; //選択されたノードの親ホストノード
            string a = "temp";

            //親ホストノードを取得す
            //TODO ホストグループノードの時の条件も後で追加する
            HostNode.Tag = HostNode.Tag ?? a;
            try
            {
                while ((HostNode.Tag.GetType() != typeof(LinNodeTag) && HostNode.Tag.GetType() != typeof(WinNodeTag)) || HostNode.Parent == null)
                {
                    HostNode = HostNode.Parent;
                }
            }
            catch
            {
                throw;
            }


            //選択したノードが
            //ホストの場合の動作
            if (SlctNode.Tag.GetType() == typeof(LinNodeTag) || SlctNode.Tag.GetType() == typeof(WinNodeTag))
            {
                int sessionid = ConnectHostFromTreeNode(HostNode);
                GetFileFromNode(SlctNode, current_session[sessionid]);
                ConfigManagerView.Update();
            }
            //テンプレートグループ場合の動作
            //TODO テンプレートグループにTagがわり当たっていないのでこの処理を通らない。
            else if (SlctNode.Tag.GetType() == typeof(TemplateGroupTag))
            {
                int sessionid = ConnectHostFromTreeNode(HostNode);
                GetFileFromNode(SlctNode, current_session[sessionid]);
            }
            //テンプレートの場合の動作
            else if (SlctNode.Tag.GetType() == typeof(TemplateTag))
            {
                int sessionid = ConnectHostFromTreeNode(HostNode);
                GetFileFromNode(SlctNode, current_session[sessionid]);
            }
        }

        private void バージョン情報AToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            Graphics grap = ((TabControl)sender).CreateGraphics();
            Rectangle rect = Rectangle.Empty;
            //TODO 閉じるボタン描画()
            rect = GetTabCloseButtonRect(e.TabPageIndex);
            ControlPaint.DrawCaptionButton(grap, rect, CaptionButton.Close, ButtonState.Flat);
            grap = null;
        }
    }
}

//TODO 文字コード変換の未実装
//TODO TabControlに閉じるボタン追加

