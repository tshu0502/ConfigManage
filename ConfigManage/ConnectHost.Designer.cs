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
            this.button1 = new System.Windows.Forms.Button();
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
            this.OK.Location = new System.Drawing.Point(139, 290);
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
            this.Cancel.Location = new System.Drawing.Point(268, 290);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "接続テスト";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConnectHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 339);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}