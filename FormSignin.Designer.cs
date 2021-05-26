
namespace MES_project
{
    partial class FormSignin
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btn_sign = new MetroFramework.Controls.MetroButton();
            this.btn_cancel = new MetroFramework.Controls.MetroButton();
            this.btn_rfidtag = new MetroFramework.Controls.MetroButton();
            this.tb_id = new MetroFramework.Controls.MetroTextBox();
            this.tb_pw = new MetroFramework.Controls.MetroTextBox();
            this.tb_name = new MetroFramework.Controls.MetroTextBox();
            this.tb_rfid = new MetroFramework.Controls.MetroTextBox();
            this.btn_idcheck = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(78, 173);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "ID : ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(67, 225);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "PW : ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(60, 282);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "이름 : ";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(34, 339);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(91, 25);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "RFID id : ";
            // 
            // btn_sign
            // 
            this.btn_sign.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_sign.Location = new System.Drawing.Point(100, 426);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(75, 31);
            this.btn_sign.TabIndex = 4;
            this.btn_sign.Text = "등록";
            this.btn_sign.UseSelectable = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_cancel.Location = new System.Drawing.Point(236, 426);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 31);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseSelectable = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_rfidtag
            // 
            this.btn_rfidtag.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_rfidtag.Location = new System.Drawing.Point(302, 341);
            this.btn_rfidtag.Name = "btn_rfidtag";
            this.btn_rfidtag.Size = new System.Drawing.Size(95, 33);
            this.btn_rfidtag.TabIndex = 6;
            this.btn_rfidtag.Text = "중복확인";
            this.btn_rfidtag.UseSelectable = true;
            this.btn_rfidtag.Click += new System.EventHandler(this.btn_rfid_Click);
            // 
            // tb_id
            // 
            // 
            // 
            // 
            this.tb_id.CustomButton.Image = null;
            this.tb_id.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_id.CustomButton.Name = "";
            this.tb_id.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.tb_id.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_id.CustomButton.TabIndex = 1;
            this.tb_id.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_id.CustomButton.UseSelectable = true;
            this.tb_id.CustomButton.Visible = false;
            this.tb_id.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_id.Lines = new string[0];
            this.tb_id.Location = new System.Drawing.Point(131, 173);
            this.tb_id.MaxLength = 32767;
            this.tb_id.Multiline = true;
            this.tb_id.Name = "tb_id";
            this.tb_id.PasswordChar = '\0';
            this.tb_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_id.SelectedText = "";
            this.tb_id.SelectionLength = 0;
            this.tb_id.SelectionStart = 0;
            this.tb_id.ShortcutsEnabled = true;
            this.tb_id.Size = new System.Drawing.Size(159, 33);
            this.tb_id.TabIndex = 7;
            this.tb_id.UseSelectable = true;
            this.tb_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tb_id.TextChanged += new System.EventHandler(this.tb_id_TextChanged);
            // 
            // tb_pw
            // 
            // 
            // 
            // 
            this.tb_pw.CustomButton.Image = null;
            this.tb_pw.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_pw.CustomButton.Name = "";
            this.tb_pw.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.tb_pw.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_pw.CustomButton.TabIndex = 1;
            this.tb_pw.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_pw.CustomButton.UseSelectable = true;
            this.tb_pw.CustomButton.Visible = false;
            this.tb_pw.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_pw.Lines = new string[0];
            this.tb_pw.Location = new System.Drawing.Point(131, 225);
            this.tb_pw.MaxLength = 32767;
            this.tb_pw.Multiline = true;
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '*';
            this.tb_pw.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_pw.SelectedText = "";
            this.tb_pw.SelectionLength = 0;
            this.tb_pw.SelectionStart = 0;
            this.tb_pw.ShortcutsEnabled = true;
            this.tb_pw.Size = new System.Drawing.Size(159, 33);
            this.tb_pw.TabIndex = 8;
            this.tb_pw.UseSelectable = true;
            this.tb_pw.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_pw.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tb_name
            // 
            // 
            // 
            // 
            this.tb_name.CustomButton.Image = null;
            this.tb_name.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_name.CustomButton.Name = "";
            this.tb_name.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.tb_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_name.CustomButton.TabIndex = 1;
            this.tb_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_name.CustomButton.UseSelectable = true;
            this.tb_name.CustomButton.Visible = false;
            this.tb_name.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_name.Lines = new string[0];
            this.tb_name.Location = new System.Drawing.Point(131, 282);
            this.tb_name.MaxLength = 32767;
            this.tb_name.Multiline = true;
            this.tb_name.Name = "tb_name";
            this.tb_name.PasswordChar = '\0';
            this.tb_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_name.SelectedText = "";
            this.tb_name.SelectionLength = 0;
            this.tb_name.SelectionStart = 0;
            this.tb_name.ShortcutsEnabled = true;
            this.tb_name.Size = new System.Drawing.Size(159, 33);
            this.tb_name.TabIndex = 9;
            this.tb_name.UseSelectable = true;
            this.tb_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tb_rfid
            // 
            // 
            // 
            // 
            this.tb_rfid.CustomButton.Image = null;
            this.tb_rfid.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_rfid.CustomButton.Name = "";
            this.tb_rfid.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.tb_rfid.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_rfid.CustomButton.TabIndex = 1;
            this.tb_rfid.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_rfid.CustomButton.UseSelectable = true;
            this.tb_rfid.CustomButton.Visible = false;
            this.tb_rfid.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_rfid.Lines = new string[0];
            this.tb_rfid.Location = new System.Drawing.Point(131, 341);
            this.tb_rfid.MaxLength = 32767;
            this.tb_rfid.Multiline = true;
            this.tb_rfid.Name = "tb_rfid";
            this.tb_rfid.PasswordChar = '\0';
            this.tb_rfid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_rfid.SelectedText = "";
            this.tb_rfid.SelectionLength = 0;
            this.tb_rfid.SelectionStart = 0;
            this.tb_rfid.ShortcutsEnabled = true;
            this.tb_rfid.Size = new System.Drawing.Size(159, 33);
            this.tb_rfid.TabIndex = 10;
            this.tb_rfid.UseSelectable = true;
            this.tb_rfid.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_rfid.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tb_rfid.TextChanged += new System.EventHandler(this.tb_rfid_TextChanged);
            // 
            // btn_idcheck
            // 
            this.btn_idcheck.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_idcheck.Location = new System.Drawing.Point(302, 173);
            this.btn_idcheck.Name = "btn_idcheck";
            this.btn_idcheck.Size = new System.Drawing.Size(95, 33);
            this.btn_idcheck.TabIndex = 11;
            this.btn_idcheck.Text = "중복확인";
            this.btn_idcheck.UseSelectable = true;
            this.btn_idcheck.Click += new System.EventHandler(this.btn_idcheck_Click);
            // 
            // FormSignin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 540);
            this.Controls.Add(this.btn_idcheck);
            this.Controls.Add(this.tb_rfid);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_pw);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.btn_rfidtag);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sign);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FormSignin";
            this.Text = "회원가입";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSignin_FormClosed);
            this.Load += new System.EventHandler(this.FormSignin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton btn_sign;
        private MetroFramework.Controls.MetroButton btn_cancel;
        private MetroFramework.Controls.MetroButton btn_rfidtag;
        private MetroFramework.Controls.MetroTextBox tb_id;
        private MetroFramework.Controls.MetroTextBox tb_pw;
        private MetroFramework.Controls.MetroTextBox tb_name;
        private MetroFramework.Controls.MetroTextBox tb_rfid;
        private MetroFramework.Controls.MetroButton btn_idcheck;
    }
}