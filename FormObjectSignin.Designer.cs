
namespace MES_project
{
    partial class FormObjectSignin
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
            this.tb_rfid = new MetroFramework.Controls.MetroTextBox();
            this.tb_category = new MetroFramework.Controls.MetroTextBox();
            this.tb_name = new MetroFramework.Controls.MetroTextBox();
            this.tb_id = new MetroFramework.Controls.MetroTextBox();
            this.btn_rfidtag = new MetroFramework.Controls.MetroButton();
            this.btn_cancel = new MetroFramework.Controls.MetroButton();
            this.btn_sign = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
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
            this.tb_rfid.Location = new System.Drawing.Point(140, 320);
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
            this.tb_rfid.TabIndex = 33;
            this.tb_rfid.UseSelectable = true;
            this.tb_rfid.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_rfid.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tb_rfid.TextChanged += new System.EventHandler(this.tb_rfid_TextChanged);
            // 
            // tb_category
            // 
            // 
            // 
            // 
            this.tb_category.CustomButton.Image = null;
            this.tb_category.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_category.CustomButton.Name = "";
            this.tb_category.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.tb_category.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_category.CustomButton.TabIndex = 1;
            this.tb_category.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_category.CustomButton.UseSelectable = true;
            this.tb_category.CustomButton.Visible = false;
            this.tb_category.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_category.Lines = new string[0];
            this.tb_category.Location = new System.Drawing.Point(140, 261);
            this.tb_category.MaxLength = 32767;
            this.tb_category.Multiline = true;
            this.tb_category.Name = "tb_category";
            this.tb_category.PasswordChar = '\0';
            this.tb_category.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_category.SelectedText = "";
            this.tb_category.SelectionLength = 0;
            this.tb_category.SelectionStart = 0;
            this.tb_category.ShortcutsEnabled = true;
            this.tb_category.Size = new System.Drawing.Size(159, 33);
            this.tb_category.TabIndex = 32;
            this.tb_category.UseSelectable = true;
            this.tb_category.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_category.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.tb_name.Location = new System.Drawing.Point(140, 204);
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
            this.tb_name.TabIndex = 31;
            this.tb_name.UseSelectable = true;
            this.tb_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.tb_id.Location = new System.Drawing.Point(140, 152);
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
            this.tb_id.TabIndex = 30;
            this.tb_id.UseSelectable = true;
            this.tb_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_rfidtag
            // 
            this.btn_rfidtag.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_rfidtag.Location = new System.Drawing.Point(311, 320);
            this.btn_rfidtag.Name = "btn_rfidtag";
            this.btn_rfidtag.Size = new System.Drawing.Size(95, 33);
            this.btn_rfidtag.TabIndex = 29;
            this.btn_rfidtag.Text = "중복확인";
            this.btn_rfidtag.UseSelectable = true;
            this.btn_rfidtag.Click += new System.EventHandler(this.btn_rfidtag_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_cancel.Location = new System.Drawing.Point(245, 405);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 31);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseSelectable = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_sign
            // 
            this.btn_sign.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_sign.Location = new System.Drawing.Point(109, 405);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(75, 31);
            this.btn_sign.TabIndex = 27;
            this.btn_sign.Text = "등록";
            this.btn_sign.UseSelectable = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(43, 318);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(91, 25);
            this.metroLabel4.TabIndex = 26;
            this.metroLabel4.Text = "RFID id : ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(31, 261);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(103, 25);
            this.metroLabel3.TabIndex = 25;
            this.metroLabel3.Text = "카테고리 : ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(69, 204);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 25);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "이름 : ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(87, 152);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 25);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "ID : ";
            // 
            // FormObjectSignin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 501);
            this.Controls.Add(this.tb_rfid);
            this.Controls.Add(this.tb_category);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.btn_rfidtag);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sign);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FormObjectSignin";
            this.Text = "물품 등록";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormObjectSignin_FormClosed);
            this.Load += new System.EventHandler(this.FormObjectSignin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tb_rfid;
        private MetroFramework.Controls.MetroTextBox tb_category;
        private MetroFramework.Controls.MetroTextBox tb_name;
        private MetroFramework.Controls.MetroTextBox tb_id;
        private MetroFramework.Controls.MetroButton btn_rfidtag;
        private MetroFramework.Controls.MetroButton btn_cancel;
        private MetroFramework.Controls.MetroButton btn_sign;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}