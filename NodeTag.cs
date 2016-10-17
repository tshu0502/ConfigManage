using System.Collections;
using WinSCP;

namespace NodeTag
{

    interface NodeTagCommon
    {
    }

    //ホストグループのノードtag　基底クラス
    public class HostGroupNodeTag
    {
        public  int hierarchy = 2;
        public  bool selfchild = true;

        public Node_Profile NodeProfile;
        public HostGroupNodeTag()
        {

        }
    }

    //各ノードのプロファイル(環境変数)
    public class Node_Profile
    {
        public Hashtable EnvVariableTable;
    }

    //ホストノードtag
    public class HostNodeTag : HostGroupNodeTag
    {
        public const int hierarchy = 3;
        public const bool selfchild = false;

        public string HostName;        /* ホスト名 */
        public string UserName;        /* ユーザ名 */
        public string PassWord;        /* パスワード */
        public string env_hostname;
        public string env_installpath;
        public string custom_hostname;
        public string custom_installpath;
        /* ToBe 独自の環境変数を設定する 配列化 */

        public HostNodeTag()
        {
        }
    }
    
    //Linuxノードの設定tag
    public class LinNodeTag : HostNodeTag
    {
        public const int hierarchy = 3;
        public const bool selfchild = false;

        public int PortNo;                          /* ポート番号 */
        public bool Anonymous;                      /* Anonymousフラグ */
        public FtpMode FtpMode;                     /* PASVモード (YES/NO) */
        public bool FireWall;                       /* FireWallを使う (YES/NO) */
        protected bool ftp = true;
        public string SshHostKeyFingerprint;
        public int sessionid;

        public void InputSessionOptions(SessionOptions sessionopt)
        {
            sessionopt.Protocol = Protocol.Ftp;
            sessionopt.HostName = HostName;
            sessionopt.UserName = UserName;
            sessionopt.Password = PassWord;
            sessionopt.PortNumber = PortNo;
            sessionopt.FtpMode = FtpMode;
            /* sessionopt.SshHostKeyFingerprint; = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx"; */
        }
    }

    //Windowsノード用tag
    public class WinNodeTag : HostNodeTag
    {
        public const int hierarchy = 3;
        public const bool selfchild = false;
    }

    public class TemplateGroupTag
    {
        public const int hierarchy = 4;
        public const bool selfchild = true;
    }

    //テンプレートノードtag
    public class TemplateTag
    {
        public const int hierarchy = 5;
        public const bool selfchild = false;

        public string filename = null;
        public string remotefile_fullpath = null;
        public string localfile_fullpath = null;
    }

    public class DiffenitionNodeTag
    {
        public const int hierarchy = 5;
        public const bool selfchild = false;

        //        string env_hostname;
        //        string env_installpath;
        public string filename = null;
        public string remotefile_fullpath = null;
        public string localfile_fullpath = null;
    }

}