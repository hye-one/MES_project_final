
namespace MES_project
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.tb_pw = new MetroFramework.Controls.MetroTextBox();
            this.tb_id = new MetroFramework.Controls.MetroTextBox();
            this.btn_logIn = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_pw
            // 
            // 
            // 
            // 
            this.tb_pw.CustomButton.Image = null;
            this.tb_pw.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.tb_pw.CustomButton.Name = "";
            this.tb_pw.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_pw.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_pw.CustomButton.TabIndex = 1;
            this.tb_pw.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_pw.CustomButton.UseSelectable = true;
            this.tb_pw.CustomButton.Visible = false;
            this.tb_pw.Lines = new string[0];
            this.tb_pw.Location = new System.Drawing.Point(81, 426);
            this.tb_pw.MaxLength = 32767;
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '●';
            this.tb_pw.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_pw.SelectedText = "";
            this.tb_pw.SelectionLength = 0;
            this.tb_pw.SelectionStart = 0;
            this.tb_pw.ShortcutsEnabled = true;
            this.tb_pw.Size = new System.Drawing.Size(256, 23);
            this.tb_pw.TabIndex = 0;
            this.tb_pw.UseSelectable = true;
            this.tb_pw.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_pw.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tb_id
            // 
            // 
            // 
            // 
            this.tb_id.CustomButton.Image = null;
            this.tb_id.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.tb_id.CustomButton.Name = "";
            this.tb_id.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_id.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_id.CustomButton.TabIndex = 1;
            this.tb_id.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_id.CustomButton.UseSelectable = true;
            this.tb_id.CustomButton.Visible = false;
            this.tb_id.ForeColor = System.Drawing.Color.DarkGray;
            this.tb_id.Lines = new string[0];
            this.tb_id.Location = new System.Drawing.Point(81, 355);
            this.tb_id.MaxLength = 32767;
            this.tb_id.Name = "tb_id";
            this.tb_id.PasswordChar = '\0';
            this.tb_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_id.SelectedText = "";
            this.tb_id.SelectionLength = 0;
            this.tb_id.SelectionStart = 0;
            this.tb_id.ShortcutsEnabled = true;
            this.tb_id.Size = new System.Drawing.Size(256, 23);
            this.tb_id.TabIndex = 0;
            this.tb_id.UseSelectable = true;
            this.tb_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_logIn
            // 
            this.btn_logIn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btn_logIn.Location = new System.Drawing.Point(157, 470);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(102, 32);
            this.btn_logIn.TabIndex = 1;
            this.btn_logIn.Text = "로그인";
            this.btn_logIn.UseSelectable = true;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(118, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(81, 332);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(22, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "ID";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.White;
            this.metroLabel2.Location = new System.Drawing.Point(81, 403);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(30, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "PW";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 540);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_logIn);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_pw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Resizable = false;
            this.Text = "MES Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tb_pw;
        private MetroFramework.Controls.MetroTextBox tb_id;
        private MetroFramework.Controls.MetroButton btn_logIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}