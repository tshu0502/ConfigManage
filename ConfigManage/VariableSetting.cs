using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigManage;

namespace ConfigManage
{
    public partial class VariableSetting : Form
    {
        public VariableSetting()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void VariableSetting_Load(object sender, EventArgs e)　//dataGridViewに値を読み込む(子供側では実装していない)
        {
            /*            TreeNode tn = ;//選択されたノードの情報を取得する。

                        TreeView FocusedControl = new TreeView();
                        if (ConfigManagerView.Focused)
                        {
                            FocusedControl = ConfigManagerView;
                        }
                        else if (RemoteFilemanagerView.Focused)
                        {
                            FocusedControl = RemoteFilemanagerView;
                        }
                        
                        if (tn.IsSelected)  //ConfigManagerTreeのノードが選択されていたら
                        {
                            VariableSetting f = new VariableSetting();
                            //フォームの表示
                            try //null例外許す
                            {
                                foreach (DataGridViewRow row in f.dataGridView1.Rows)
                                {
                                    dataGridView1.Rows.Add();
                                    TreeNode selectnode = tn;
                                    FtpNodeTag ftpnodetag = new FtpNodeTag();//tagの割り当て
                                    ftpnodetag.NodeProfile.EnvVariableTable.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                                }
                            }
                            catch
                            {
                            }

                        }
                    }*/
        }
    }
}
