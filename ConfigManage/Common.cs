using NodeTag;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinSCP;
using csdiff;
using System.Drawing;
using System.Runtime.InteropServices;
using Acha_ya.SampleApplication;

namespace ConfigManage
{
    partial class MainForm : Form
    {
        //アプリ実行ファイル
        string appFilePath = System.Windows.Forms.Application.ExecutablePath;
        //アプリのディレクトリ
        string appDirPath = Application.StartupPath;

        //configmanagerのPATH
        string configmanagerxmlpath = Application.StartupPath + "\\Configmanager.xml";
        string remotehostxmlpath = Application.StartupPath + "\\Remotehost.xml";
        string templatexmlpath = Application.StartupPath + "\\Template.xml";

        string templatedir = Application.StartupPath + "\\template";
        string downloaddir = Application.StartupPath + "\\download";
        string tempdir = Application.StartupPath + "\\temp";

        bool _isDraging = false;
        System.Drawing.Point _diffPoint = new System.Drawing.Point(0, 0);

        Session[] current_session = new Session[10]; //FTPのセッション
        int sessionid = 0;                           //FTPのセッションID

        #region TreeView関係
        //最上位のノード情報を取得する。
        public TreeNode GetRootNode(TreeNode node)
        {
            TreeNode topnode = new TreeNode();
            return (node.Parent == null) ? node : node = GetRootNode(node.Parent);
            /*            while (node.Parent != null )
                        {
                            return getRootNode(node.Parent);
                        }
                        return null;*/
        }

        //ノードのファイルパスを取得する。
        public string ConvertFilePath(TreeNode node)
        {
            string filepath = node.FullPath;
            string hostname = GetRootNode(node).Text;
            return filepath = filepath.Replace(hostname, "");
        }

        /// <summary>
        /// chiledNodeがparentNodeの子ノードか確認
        /// </summary>
        /// <param name="parentNode">親ノード</param>
        /// <param name="childNode">子ノード</param>
        /// <returns></returns>
        private static bool IsChildNode(TreeNode parentNode, TreeNode childNode)
        {
            if (childNode.Parent == parentNode)
                return true;
            else if (childNode.Parent != null)
                return IsChildNode(parentNode, childNode.Parent);
            else
                return false;
        }

        /// <summary>
        /// ActiveなTreeViewを調べる
        /// </summary>
        /// <returns></returns>
        public TreeView GetActiveTreeView()
        {
            Control FocusedControl = this.ActiveControl;
            while (FocusedControl.GetType() == typeof(SplitContainer))
            {
                ContainerControl CldFcsdCtrl = (ContainerControl)FocusedControl;
                FocusedControl = CldFcsdCtrl.ActiveControl;
            }

            return (TreeView)FocusedControl;
        }

        /// <summary>
        /// 選択されているTreeViewとそのノードを返す
        /// </summary>
        /// <param name="selectednode">与えられた引数に選択されているTreeViewとそのノードを代入する。</param>
        /// <returns>
        /// true 成功
        /// false　失敗
        /// </returns>
        private bool GetSelectedNode(ref TreeNode selectednode)
        {
            TreeView activetree;
            try
            {
                if (ConfigManagerView.Focused)
                {
                    activetree = ConfigManagerView;
                    selectednode = activetree.SelectedNode;
                    return true;

                }
                else if (RemoteFilemanagerView.Focused)
                {
                    activetree = RemoteFilemanagerView;
                    selectednode = activetree.SelectedNode;
                    return true;
                }
                else if (TemplateView.Focused)
                {
                    activetree = TemplateView;
                    selectednode = activetree.SelectedNode;
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 指定したパスにディレクトリが存在しない場合
        /// すべてのディレクトリとサブディレクトリを作成します
        /// </summary>
        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }

        /// <summary>
        /// （実装未完了）TreeNode pnode配下にmynodeを配置できるか確認
        /// </summary>
        /// <param name="pnode">チェックする親ノード</param>
        /// <param name="mynode">配置したいノード</param>
        /// <returns></returns>
        public bool IsPossibleParent(TreeNode pnode, TreeNode mynode)
        {
            try
            {
                //TODO Tagオブジェクトの基底クラス内容同士を比較したい。
                HostGroupNodeTag pnodetag = (HostGroupNodeTag)pnode.Tag;
                HostGroupNodeTag mynodetag = (HostGroupNodeTag)mynode.Tag;

                if ((pnodetag.hierarchy >= mynodetag.hierarchy) && (mynodetag.selfchild == true)) return true;
                return false;
            }
            catch (Exception msg)
            {
                ConsoleText.Text = msg.Message;
                return false;
            }
        }

        /// <summary>
        /// TreeNodeからtreenodeホストに接続する。
        /// </summary>
        /// <param name="treenode">接続したいホストノード</param>
        public int ConnectHostFromTreeNode(TreeNode treenode)
        {
            object obj = treenode.Tag;

            if (obj.GetType() == typeof(LinNodeTag))
            {
                //親ノードにドライブを設定
                SessionOptions current_sessionOptions = new SessionOptions();
                LinNodeTag linnodetag = (LinNodeTag)obj;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    linnodetag.InputSessionOptions(current_sessionOptions);
                    // sessionの作成
                    while (current_session[sessionid] != null)
                    {
                        ++sessionid;
                    }
                    current_session[sessionid] = new Session();
                    current_session[sessionid].Open(current_sessionOptions);
                    TreeViewOverlayImage(treenode, 1);

                    linnodetag.sessionid = sessionid;
                }
                catch (Exception msg)
                {
                    ConsoleText.Text = msg.Message;
                }
                finally
                {
                    Cursor.Current = Cursors.Arrow;
                }

                return sessionid;
            }

            else if (obj.GetType() == typeof(WinNodeTag))
            {
            }
            return -1;
        }

        private void GetFileFromNode(TreeNode treeNode, Session session)
        {
            try
            {
                if (treeNode.Tag.GetType() == typeof(TemplateTag))
                {
                    string LclFilePath = appDirPath + "\\" + treeNode.FullPath;            //ダウンロード先パス
                    string FileName = treeNode.Text;                                      //ファイル名
                    string RmtFilePath = ((TemplateTag)treeNode.Tag).remotefile_fullpath; //ダウンロード元ファイル

                    SafeCreateDirectory(Path.GetDirectoryName(LclFilePath));                                      //ダウンロードするディレクトリがなければ作る。
                    //ダウンロード開始
                    session.GetFiles(RmtFilePath, LclFilePath);
                    TreeViewOverlayImage(treeNode, 2); //ダウンロードOKのアイコン表示

                    //比較する。
                    string RightFilePath = ((TemplateTag)treeNode.Tag).localfile_fullpath;

                    Document document = new Document();
                    Option option = new Option();

                    document.Load(DocOf.LEFT, LclFilePath);
                    document.Load(DocOf.RIGHT, RightFilePath);
                    
                    if (document.IsLoadedAll())
                    {
                        document.UpdateCompositSection(option.bIgnoreBlank);
                        for (Section section =(Section)document.secComposit.m_head;section != null; section = (Section)section.GetNext())
                        {
                            if(section.state != STATE.SAME)
                            {
                                TreeViewOverlayImage(treeNode, 3);
                            }
                        }
                    }
                }
            }
            catch (Exception msg)
            {
                ConsoleText.Text = msg.Message;
            }

            foreach (TreeNode tn in treeNode.Nodes)
            {
                GetFileFromNode(tn, session);
            }
        }

        #endregion

        //テキストファイル判定
        public bool IsTextFile(string filePath)
        {
            try
            {
                FileStream file = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] byteData = new byte[1];
                /*                while (file.Read(byteData, 0, byteData.Length) > 0)
                                {
                                    if (byteData[0] == 0)
                                        return false;
                                }*/
                return true;
            }
            catch (Exception msg)
            {
                CustomLogWrite(ConsoleText, msg.Message);
                return false;
            }
        }

        public void CustomLogWrite(TextBox tb, string str)
        {
            DateTime tm = DateTime.Now;
            tb.AppendText(tm + " " + str + "\r\n");
            ConsoleText.AppendText(tm + " " + str + "\r\n");
        }

        /// <summary>
        /// 指定されたTEXTファイルを開き、TabControlにタブを追加する。
        /// </summary>
        /// <param name="TabControl">追加するTabControl</param>
        /// <param name="filepath">TEXTファイルのパス</param>
        /// <returns>
        /// true 成功
        /// false　失敗
        /// </returns>
        private bool AddTabControlWithText(TabControl TabControl, string filepath)
        {
            //TODO エラー処理入れる。

            string filename = Path.GetFileName(filepath);

            //エンコードの確認
            byte[] bs = FileReadByByte(filepath);
            Encoding encode = GetCode(bs);

            //ファイルの読み込み
            StreamReader sr = new StreamReader(filepath, encode);
            string text = sr.ReadToEnd();
            sr.Close();

            //文字コード変換
            text = text.Replace("\n", "\r\n").Replace("\r\r", "\r");

            // textBox1への読み込み
            TextBox txtbox = new TextBox();
            txtbox.Text = text;

            // textBox1の設定
            txtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            txtbox.Location = new System.Drawing.Point(3, 3);
            txtbox.Margin = new System.Windows.Forms.Padding(0);
            txtbox.Font = new System.Drawing.Font("ＭＳ ゴシック", 11, System.Drawing.FontStyle.Regular);
            txtbox.Multiline = true;
            txtbox.Name = filename;
            txtbox.Size = new System.Drawing.Size(833, 353);

            // tabの追加
            string title = filename + "- Remote";
            TabPage myTabPage = new TabPage(title);
            myTabPage.Controls.Add(txtbox);
            TabControl.TabPages.Add(myTabPage);
            TabControl.SelectedTab = myTabPage;

            switch (encode.ToString())
            {
                case "SJIS": //tagがnullのときは無視
                    eUCToolStripMenuItem.Checked = true;
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 指定されたTEXTファイルを開き、比較しTabControlにタブを追加する。
        /// </summary>
        /// <param name="TabControl">追加先のTabControl</param>
        /// <param name="leftname">比較元のファイルパス</param>
        /// <param name="rightname">比較先のファイルパス</param>
        private void AddTabControlWithDiff(TabControl TabControl, string leftname, string rightname)
        {
            Document document = new Document();
            Option option = new Option();
            csdiff.View view = new csdiff.View(document, option);
            TabPage myTabPage = new TabPage(Path.GetFileName(leftname));
            FnameBar fnameBar = new FnameBar(document, option);

            //            view.Parenft = this;
            view.Dock = DockStyle.Fill;
            view.Show();

            // tabの追加
            myTabPage.Controls.Add(view);
            TabControl.TabPages.Add(myTabPage);
            TabControl.SelectedTab = myTabPage;

            Graphics grap = TabControl.CreateGraphics();
            Rectangle rect = Rectangle.Empty;
            //TODO 閉じるボタン描画()
            rect = GetTabCloseButtonRect(myTabPage.TabIndex);
            ControlPaint.DrawCaptionButton(grap, rect, CaptionButton.Close, ButtonState.Flat);
            grap = null;


            fnameBar.Parent = myTabPage;
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
            //            fnameBar.Invalidate();

            if (document.IsLoadedAll())
            {
                document.UpdateCompositSection(option.bIgnoreBlank);
                view.InitialUpdate(true);
            }
        }

        /// <summary>
        /// タブの閉じるボタン場所を取得
        /// </summary>
        /// <param name="index">タブのインデックス</param>
        /// <returns></returns>
        private Rectangle GetTabCloseButtonRect(int tabindex)
        {
            Rectangle rect = tabControl2.GetTabRect(tabindex);
            rect.X = rect.Right - 20;
            rect.Y = rect.Top + 2;
            rect.Width = 16;
            rect.Height = 16;

            return rect;
        }

        /// <summary>
        /// 文字コードを判別する。
        /// </summary>
        /// <remarks>
        /// Jcode.pmのgetcodeメソッドを移植したものです。
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// Jcode.pmの著作権情報
        /// Copyright 1999-2005 Dan Kogai <dankogai@dan.co.jp>
        /// This library is free software; you can redistribute it and/or modify it
        ///  under the same terms as Perl itself.
        /// </remarks>
        /// <param name="bytes">文字コードを調べるデータ</param>
        /// <returns>適当と思われるEncodingオブジェクト。
        /// 判断できなかった時はnull。</returns>
        public static Encoding GetCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }

        /// <summary>
        /// ファイルをByte[]に読み込む。
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        //TODO 戻り値の見直しが必要
        public byte[] FileReadByByte(string filepath)
        {
            //ファイルを開く
            FileStream fs = new FileStream(
                filepath,
                FileMode.Open,
                FileAccess.Read);
            //ファイルを読み込むバイト型配列を作成する
            byte[] bs = new byte[fs.Length];
            //ファイルの内容をすべて読み込む
            fs.Read(bs, 0, bs.Length);
            //閉じる
            fs.Close();
            return bs;
        }

        /*		public string GetPathWithoutRoot(string fullpath)
				{
					string[] str=null;
					str = fullpath;
					return str;
				}
		*/
        /// <summary>
        /// 指定した TreeNode にオーバーレイアイコンを表示する様に指示する。
        /// </summary>
        /// <param name="node">対象となる TreeNode オブジェクト</param>
        /// <param name="overlayIndex">オーバーレイインデックス</param>
        public static void TreeViewOverlayImage(TreeNode node, uint overlayIndex)
        {
            // TreeView_SetItemState(node.TreeView.Handle, node.Handle,
            //     overlayIndex << 8, TVIS_OVERLAYMASK); 相当の処理
            TVITEM tvi = new TVITEM();
            tvi.mask = NativeMethods.TVIF_STATE;
            tvi.hItem = node.Handle;
            tvi.stateMask = NativeMethods.TVIS_OVERLAYMASK;
            tvi.state = (overlayIndex << 8);
            NativeMethods.SendMessage(node.TreeView.Handle, NativeMethods.TVM_SETITEMW, 0, ref tvi);
        }

        //接続切断するWin32 API を宣言
        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);

        //認証情報を使って接続するWin32 API宣言
        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);
        //WNetAddConnection2に渡す接続の詳細情報の構造体
        [StructLayout(LayoutKind.Sequential)]
        internal struct NETRESOURCE
        {
            public int dwScope;//列挙の範囲
            public int dwType;//リソースタイプ
            public int dwDisplayType;//表示オブジェクト
            public int dwUsage;//リソースの使用方法
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpLocalName;//ローカルデバイス名。使わないならNULL。
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpRemoteName;//リモートネットワーク名。使わないならNULL
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpComment;//ネットワーク内の提供者に提供された文字列
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpProvider;//リソースを所有しているプロバイダ名
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
    public class TabControlEx : TabControl
    {

        // タブの閉じるボタンクリックイベント
        public event EventHandler TabCloseButtonClick;

        // コンストラクタ
        public TabControlEx()
        {
        }

        // タブの閉じるボタンクリックイベント
        protected void OnCloseButtonClick(EventArgs e)
        {
            MessageBox.Show("タブの閉じるボタンが押されたよ！");
            if (this.TabCloseButtonClick != null)
            {
                this.TabCloseButtonClick(this, e);
            }
        }

        // OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point pt = new Point(e.X, e.Y);
            Rectangle rect = this.GetTabCloseButtonRect(pt);
            if (rect.Contains(pt))
            {
                this.OnCloseButtonClick(new EventArgs());
                this.Invalidate(rect);
            }
        }

        // タブの閉じるボタン場所を取得
        private Rectangle GetTabCloseButtonRect(Point pt)
        {
            Rectangle rect;
            for (int i = 0; i < base.TabCount; i++)
            {
                rect = this.GetTabCloseButtonRect(i);
                if (rect.Contains(pt))
                {
                    return rect;
                }
            }
            return Rectangle.Empty;
        }


        // タブの閉じるボタン場所を取得
        private Rectangle GetTabCloseButtonRect(int index)
        {
            Rectangle rect = this.GetTabRect(index);
            rect.X = rect.Right - 20;
            rect.Y = rect.Top + 2;
            rect.Width = 16;
            rect.Height = 16;

            return rect;
        }

        // タブに閉じるボタンを描画
        private void DrawTabCloseButton()
        {
            Graphics g = this.CreateGraphics();
            Rectangle rect = Rectangle.Empty;
            Point pt = this.PointToClient(Cursor.Position);
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                rect = this.GetTabCloseButtonRect(i);
                // 閉じるボタン描画
                ControlPaint.DrawCaptionButton(g, rect, CaptionButton.Close, ButtonState.Flat);
            }
            g = null;
        }

        // WndProc
 /*       protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 15:
                    this.DrawTabCloseButton();
                    break;
                default:
                    break;
            }
        }
        */
    }
}

//閉じるアイコンの
namespace Acha_ya.SampleApplication
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public uint lParam;
            public int iIndent;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TVITEM
        {
            public uint mask;
            public IntPtr hItem;
            public uint state;
            public uint stateMask;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public uint lParam;
            public int iIntegral;
        }
        /// <summary>
        /// Win32API及びその定数の定義クラス
        /// </summary>
        public class NativeMethods
        {
            public const int TVIF_STATE = 0x0008;
            public const int TVIS_OVERLAYMASK = 0x0F00;
            public const int TVM_SETITEMW = 0x113F;
            public const int LVSIL_SMALL = 1;
            public const int LVIS_OVERLAYMASK = 0x0F00;
            public const int LVM_SETIMAGELIST = 0x1003;
            public const int LVM_SETITEMSTATE = 0x102B;
            [DllImport("comctl32.dll")]
            public static extern int ImageList_SetOverlayImage(IntPtr himl, int iImage, int iOverlay);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, ref TVITEM lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, ref LVITEM lParam);
            public NativeMethods()
            {
            }
        }
    }

