using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using NodeTag;
using WinSCP;

namespace ConfigManage
{
    class Xmlfile
    {
        /// <summary>
        /// 
        /// </summary>
        private const string XmlNodeTag = "node";
        private const string XmlNodeTextAtt = "text";
        private const string XmlNodeTagAtt = "tag";
        private const string XmlNodeImageIndexAtt = "imageindex";
        private const string XmlNodeSelectImageIndexAtt = "selectimageindex";

        /// <summary>
        /// XMLファイルをロードして指定したTreeViewに読み込む
        /// </summary>
        /// <param name="treeView">読み込み先のTreeViewオブジェクト</param>
        /// <param name="fileName">保存したXMLファイル名</param>
               
        public void DeserializeTreeView(TreeView treeView, string fileName)
        {
            treeView.Nodes.Clear();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            ConvertXmlNodeToTreeNode(doc, treeView.Nodes);
            //            treeView.Nodes[0].ExpandAll();
        }

        public void SerializeTreeView(TreeView treeView, string fileName)
        {
            XmlWriterSettings xmlsettings = new XmlWriterSettings();
            xmlsettings.Encoding = Encoding.Unicode;                       //エンコーディング
            xmlsettings.Indent = true;                                      //インデントを入れる
            xmlsettings.IndentChars = "\t";                 //インデントの文字

            // Create the XmlWriter object and write some content.
            XmlWriter textWriter = XmlWriter.Create(fileName, xmlsettings);
            textWriter.WriteStartDocument();                    // writing the xml declaration tag
            textWriter.WriteRaw("\r\n");
            textWriter.WriteStartElement(treeView.Name);            // writing the main tag that encloses all node tags
                                                                    //XmlSerializerオブジェクトを作成
            SaveNodes(treeView.Nodes, textWriter);               // save the nodes, recursive method
            textWriter.WriteEndElement();
            textWriter.Close();
        }

        /*        public void SerializeTreeView2(object obj, string fileName,bool append) //テストしたいクラス(できなそう)
                {
                    try
                    {
                        //XmlSerializerオブジェクトを作成
                        //オブジェクトの型を指定する
                        XmlSerializer serializer = new XmlSerializer(typeof(object));
                        //書き込むファイルを開く（UTF-8 BOM無し）
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
                            fileName, append, new System.Text.UTF8Encoding(false));
                        //シリアル化し、XMLファイルに保存する
                        serializer.Serialize(sw, obj);                //ファイルを閉じる
                        sw.Close();
                    }
                    catch(Exception msg)
                    {
                        MessageBox.Show(msg.Message);
                    }
                }
                */

        private void SaveNodes(TreeNodeCollection nodesCollection, XmlWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                textWriter.WriteStartElement(XmlNodeTag);
                textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
                textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());
                textWriter.WriteAttributeString(XmlNodeSelectImageIndexAtt, node.SelectedImageIndex.ToString());

                //TagにWinSCP.SessionOptionsが割り当てられているときの動作
                if (node.Tag != null && node.Tag.GetType().Name == "LinNodeTag")
                {
                    LinNodeTag nodetag = (LinNodeTag)node.Tag;
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());
                    textWriter.WriteElementString("HostName", nodetag.HostName);
                    textWriter.WriteElementString("UserName", nodetag.UserName);
                    textWriter.WriteElementString("PortNo", nodetag.PortNo.ToString());
                    textWriter.WriteElementString("PassWord", nodetag.PassWord);
                    textWriter.WriteElementString("FtpMode", nodetag.FtpMode.ToString());
                    textWriter.WriteElementString("Protocol", "FTP");
                }
                else if (node.Tag != null && node.Tag.GetType().Name == "WinNodeTag")
                {

                }
                else if (node.Tag != null && node.Tag.GetType().Name == "TemplateGroupTag")
                {
                    TemplateGroupTag nodetag = (TemplateGroupTag)node.Tag;
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());
                }
                else if (node.Tag != null && node.Tag.GetType().Name == "TemplateTag")
                {
                    TemplateTag nodetag = (TemplateTag)node.Tag;
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());
                    textWriter.WriteElementString("filename", nodetag.filename);
                    textWriter.WriteElementString("remotefile_fullpath", nodetag.remotefile_fullpath);
                    textWriter.WriteElementString("localfile_fullpath", nodetag.localfile_fullpath);
                }

                if (node.Nodes.Count > 0)
                {
                    SaveNodes(node.Nodes, textWriter);
                }
                textWriter.WriteEndElement();
            }
        }

        //xmlNode; XMLファイル(xmlNode型)。XMLファイルをxmlNode型にしてから渡す。
        //treeNodes ;XMLファイルを展開するtreeNode
        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {
            //TreeNodeCollection treeroot = treeNodes
            foreach (XmlNode xmlchildNode in xmlNode.ChildNodes) //xmlchildNodeは１つのタグに相当
            {
                switch (xmlchildNode.NodeType)                               //タグがnodeのとき
                {
                    case XmlNodeType.Element:
                        if (xmlchildNode.Name == "node") //nodeタグだったら新しいノードを作成
                        {
                            TreeNode newTreeNode = XmlTagToNode(treeNodes, xmlchildNode);
                            //                            SetTagParm(xmlchildNode, newTreeNode);
                            ConvertXmlNodeToTreeNode(xmlchildNode, newTreeNode.Nodes); //xmlchildNodeを再帰的に呼び出し
                        }
                        else
                        {
                            //xmlchildNodeを再帰的に呼び出し !nodeの時も実行されちゃう
                            ConvertXmlNodeToTreeNode(xmlchildNode, treeNodes);
                        }
                        break;

                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        //xmlchildNodeを再帰的に呼び出し !nodeの時も実行されちゃう
                        ConvertXmlNodeToTreeNode(xmlchildNode, treeNodes);
                        break;
                }
            }
        }

        /// <summary>
        /// Xmlを読み込み指定したTreeNodeに追加する。
        /// </summary>
        /// <param name="tnc">TargetになるTreeNode</param>
        /// <param name="xac">Xml</param>
        /// <returns></returns>
        private TreeNode XmlTagToNode(TreeNodeCollection tnc, XmlNode xac)
        {
            var nodename = "default";
            int imageindex = 0, selectimageindex = 0;
            object tagobj = null;
            foreach (XmlAttribute xmlattr in xac.Attributes)
            {
                switch (xmlattr.Name)
                {
                    case "text":
                        nodename = xmlattr.Value;
                        break;
                    case "imageindex":
                        imageindex = int.Parse(xmlattr.Value);
                        break;
                    case "selectimageindex":
                        selectimageindex = int.Parse(xmlattr.Value);
                        break;
                    case "tag":
                        tagobj = SetTagParm(xac);
                        break;
                }
            }
            TreeNode tn = tnc.Add(nodename);
            tn.ImageIndex = imageindex;
            tn.SelectedImageIndex = selectimageindex;
            tn.Tag = tagobj;
            return tn;
        }

        /// <summary>
        /// xmlからTagClassに読み込み
        /// </summary>
        /// <param name="xmlchildNode"></param>
        /// <param name="tn"></param>
        private object SetTagParm(XmlNode xmlchildNode)
        {
            string tagname = null;
            foreach (XmlAttribute xmlattr in xmlchildNode.Attributes)
            {
                if (xmlattr.Name == "tag") tagname = xmlattr.Value;
            }
            //TODO すべてのNODEでLinNodeTagが設定されてしまう。
            if (tagname == "NodeTag.LinNodeTag")
            {
                LinNodeTag linnodetag = new LinNodeTag();
                foreach (XmlElement XmlElm in xmlchildNode.ChildNodes)
                {
                    switch (XmlElm.Name)
                    {
                        case "HostName": linnodetag.HostName = XmlElm.InnerText; break;
                        case "UserName": linnodetag.UserName = XmlElm.InnerText; break;
                        case "PortNo": linnodetag.PortNo = int.Parse(XmlElm.InnerText); break;
                        case "PassWord": linnodetag.PassWord = XmlElm.InnerText; break;
                        //string型からenum型に変換
                        case "FtpMode": linnodetag.FtpMode = (FtpMode)Enum.Parse(typeof(FtpMode), XmlElm.InnerText); break;
                        case "Host": linnodetag.UserName = XmlElm.InnerText; break;
                            //                  case "Protocol": linnodetag. = XmlElm.InnerText; break;
                    }
                }
                return linnodetag;
            }
            else if (tagname == "NodeTag.TemplateGroupTag")
            {
                TemplateGroupTag tmplgrptag = new TemplateGroupTag();
                foreach (XmlElement XmlElm in xmlchildNode.ChildNodes)
                {
                    switch (XmlElm.Name)
                    {
                    }
                }
                return tmplgrptag;
            }

            else if (tagname == "NodeTag.TemplateTag")
            {
                TemplateTag tmpltag = new TemplateTag();
                foreach (XmlElement XmlElm in xmlchildNode.ChildNodes)
                {
                    switch (XmlElm.Name)
                    {
                        case "filename": tmpltag.filename = XmlElm.InnerText; break;
                        case "remotefile_fullpath": tmpltag.remotefile_fullpath = XmlElm.InnerText; break;
                        case "localfile_fullpath": tmpltag.localfile_fullpath = XmlElm.InnerText; break;
                    }
                }
                return tmpltag;
            }
            return null;
        }
    }
}
