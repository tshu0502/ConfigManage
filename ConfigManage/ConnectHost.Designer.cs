namespace ConfigManage
{
    partial class ConnectHost
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
            this.HostName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Chk_Passive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PortNo = new System.Windows.Forms.TextBox();
            this.ConnectTest = new System.Windows.Forms.Button();
            this.Platform_Linux = new System.Windows.Forms.RadioButton();
            this.Platform_Windows = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostName
            // 
            this.HostName.Location = new System.Drawing.Point(19, 37);
            this.HostName.Margin = new System.Windows.Forms.Padding(4);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(371, 29);
            this.HostName.TabIndex = 0;
            this.HostName.Text = "ec2-52-192-249-109.ap-northeast-1.compute.amazonaws.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "ホスト名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "ユーザ名";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(19, 96);
            this.UserName.Margin = new System.Windows.Forms.Padding(4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(371, 29);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "webadmin";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(19, 155);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(371, 29);
            this.Password.TabIndex = 5;
            this.Password.Text = "webadmin";
            this.Password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "パスワード";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(138, 389);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(123, 37);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(267, 389);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(123, 37);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Chk_Passive
            // 
            this.Chk_Passive.AutoSize = true;
            this.Chk_Passive.Location = new System.Drawing.Point(19, 191);
            this.Chk_Passive.Name = "Chk_Passive";
            this.Chk_Passive.Size = new System.Drawing.Size(156, 26);
            this.Chk_Passive.TabIndex = 9;
            this.Chk_Passive.Text = "PASV MODE";
            this.Chk_Passive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "ポート番号";
            // 
            // PortNo
            // 
            this.PortNo.Location = new System.Drawing.Point(17, 246);
            this.PortNo.Margin = new System.Windows.Forms.Padding(4);
            this.PortNo.Name = "PortNo";
            this.PortNo.Size = new System.Drawing.Size(104, 29);
            this.PortNo.TabIndex = 11;
            this.PortNo.Text = "21";
            // 
            // ConnectTest
            // 
            this.ConnectTest.Location = new System.Drawing.Point(16, 389);
            this.ConnectTest.Name = "ConnectTest";
            this.ConnectTest.Size = new System.Drawing.Size(116, 37);
            this.ConnectTest.TabIndex = 12;
            this.ConnectTest.Text = "接続テスト";
            this.ConnectTest.UseVisualStyleBackColor = true;
            // 
            // Platform_Linux
            // 
            this.Platform_Linux.AutoSize = true;
            this.Platform_Linux.Checked = true;
            this.Platform_Linux.Location = new System.Drawing.Point(6, 28);
            this.Platform_Linux.Name = "Platform_Linux";
            this.Platform_Linux.Size = new System.Drawing.Size(84, 26);
            this.Platform_Linux.TabIndex = 14;
            this.Platform_Linux.TabStop = true;
            this.Platform_Linux.Text = "Linux";
            this.Platform_Linux.UseVisualStyleBackColor = true;
            // 
            // Platform_Windows
            // 
            this.Platform_Windows.AutoSize = true;
            this.Platform_Windows.Location = new System.Drawing.Point(6, 60);
            this.Platform_Windows.Name = "Platform_Windows";
            this.Platform_Windows.Size = new System.Drawing.Size(113, 26);
            this.Platform_Windows.TabIndex = 16;
            this.Platform_Windows.Text = "Windows";
            this.Platform_Windows.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Platform_Linux);
            this.groupBox1.Controls.Add(this.Platform_Windows);
            this.groupBox1.Location = new System.Drawing.Point(16, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 101);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "プラットフォーム";
            // 
            // ConnectHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConnectTest);
            this.Controls.Add(this.PortNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Chk_Passive);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HostName);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConnectHost";
            this.Text = "接続先";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox HostName;
        public System.Windows.Forms.TextBox UserName;
        public System.Windows.Forms.TextBox Password;
        public System.Windows.Forms.CheckBox Chk_Passive;
        public System.Windows.Forms.TextBox PortNo;
        private System.Windows.Forms.Button ConnectTest;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton Platform_Linux;
        public System.Windows.Forms.RadioButton Platform_Windows;
    }
}