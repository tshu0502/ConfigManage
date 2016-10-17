using System;
using System.Windows.Forms;
using WinSCP;


namespace ConfigManage
{
    public partial class ConnectHost : Form
    {
        public FtpMode passivemode;

        public ConnectHost()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (Chk_Passive.Checked == true)    passivemode = FtpMode.Passive;            
            else                                passivemode = FtpMode.Active;
            Close();
        }
    }
}
