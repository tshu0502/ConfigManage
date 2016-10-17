using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace csdiff
{
	/// <summary>
	/// openFileDlg �̊T�v�̐����ł��B
	/// </summary>
	public class openFileDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox edFilePath1;
		public System.Windows.Forms.TextBox edFilePath2;
		private System.Windows.Forms.Button browse2;
		private System.Windows.Forms.OpenFileDialog ofd;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public openFileDlg()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edFilePath1 = new System.Windows.Forms.TextBox();
            this.edFilePath2 = new System.Windows.Forms.TextBox();
            this.browse2 = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(344, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 34);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(491, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "�L�����Z��";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "�t�@�C��&1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "�t�@�C��&2";
            // 
            // edFilePath1
            // 
            this.edFilePath1.Location = new System.Drawing.Point(118, 21);
            this.edFilePath1.Name = "edFilePath1";
            this.edFilePath1.Size = new System.Drawing.Size(407, 25);
            this.edFilePath1.TabIndex = 1;
            // 
            // edFilePath2
            // 
            this.edFilePath2.Location = new System.Drawing.Point(118, 74);
            this.edFilePath2.Name = "edFilePath2";
            this.edFilePath2.Size = new System.Drawing.Size(407, 25);
            this.edFilePath2.TabIndex = 4;
            // 
            // browse2
            // 
            this.browse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browse2.Location = new System.Drawing.Point(534, 70);
            this.browse2.Name = "browse2";
            this.browse2.Size = new System.Drawing.Size(47, 35);
            this.browse2.TabIndex = 5;
            this.browse2.Text = "...";
            this.browse2.Click += new System.EventHandler(this.browse2_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "���ׂẴt�@�C��|*.*";
            // 
            // openFileDlg
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(392, 126);
            this.Controls.Add(this.edFilePath1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edFilePath2);
            this.Controls.Add(this.browse2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "openFileDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "��r����t�@�C���̑I��";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void browse1_Click(object sender, System.EventArgs e)
		{
			browseFile( edFilePath1 );
		}

		private void browse2_Click(object sender, System.EventArgs e)
		{
			browseFile( edFilePath2 );
		}

		private void browseFile( TextBox textbox )
		{
			DialogResult result = ofd.ShowDialog(this);
			if( result != DialogResult.OK ) return;
			textbox.Text = ofd.FileName;

		}

	}
}
