
namespace MES_project
{
    partial class FormMainMenu
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.PanelMenu = new MetroFramework.Controls.MetroPanel();
            this.btn_mainMenu7 = new System.Windows.Forms.Button();
            this.btn_mainMenu6 = new System.Windows.Forms.Button();
            this.btn_mainMenu5 = new System.Windows.Forms.Button();
            this.btn_mainMenu4 = new System.Windows.Forms.Button();
            this.btn_mainMenu2 = new System.Windows.Forms.Button();
            this.btn_mainMenu1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlUser = new MetroFramework.Controls.MetroPanel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.PanelDesktopPanel = new MetroFramework.Controls.MetroPanel();
            this.label_objectInOut = new System.Windows.Forms.Label();
            this.toggle_warehouse = new MetroFramework.Controls.MetroToggle();
            this.label_StaffinOut = new System.Windows.Forms.Label();
            this.toggle_chul = new MetroFramework.Controls.MetroToggle();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.btn_Home = new MetroFramework.Controls.MetroButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerStaffAttand = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_signIn = new System.Windows.Forms.Button();
            this.PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.PanelDesktopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.Controls.Add(this.btn_mainMenu7);
            this.PanelMenu.Controls.Add(this.btn_mainMenu6);
            this.PanelMenu.Controls.Add(this.btn_mainMenu5);
            this.PanelMenu.Controls.Add(this.btn_mainMenu4);
            this.PanelMenu.Controls.Add(this.btn_mainMenu2);
            this.PanelMenu.Controls.Add(this.btn_mainMenu1);
            this.PanelMenu.Controls.Add(this.pictureBox1);
            this.PanelMenu.Controls.Add(this.pnlUser);
            this.PanelMenu.HorizontalScrollbarBarColor = true;
            this.PanelMenu.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelMenu.HorizontalScrollbarSize = 10;
            this.PanelMenu.Location = new System.Drawing.Point(20, 60);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(182, 600);
            this.PanelMenu.TabIndex = 0;
            this.PanelMenu.VerticalScrollbarBarColor = true;
            this.PanelMenu.VerticalScrollbarHighlightOnWheel = false;
            this.PanelMenu.VerticalScrollbarSize = 10;
            // 
            // btn_mainMenu7
            // 
            this.btn_mainMenu7.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu7.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu7.Location = new System.Drawing.Point(0, 429);
            this.btn_mainMenu7.Name = "btn_mainMenu7";
            this.btn_mainMenu7.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu7.TabIndex = 8;
            this.btn_mainMenu7.Text = "사원근태관리";
            this.btn_mainMenu7.UseVisualStyleBackColor = true;
            this.btn_mainMenu7.Click += new System.EventHandler(this.btn_mainMenu7_Click);
            // 
            // btn_mainMenu6
            // 
            this.btn_mainMenu6.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu6.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu6.Location = new System.Drawing.Point(0, 371);
            this.btn_mainMenu6.Name = "btn_mainMenu6";
            this.btn_mainMenu6.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu6.TabIndex = 8;
            this.btn_mainMenu6.Text = "출고품목관리";
            this.btn_mainMenu6.UseVisualStyleBackColor = true;
            this.btn_mainMenu6.Click += new System.EventHandler(this.btn_mainMenu6_Click);
            // 
            // btn_mainMenu5
            // 
            this.btn_mainMenu5.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu5.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu5.Location = new System.Drawing.Point(0, 316);
            this.btn_mainMenu5.Name = "btn_mainMenu5";
            this.btn_mainMenu5.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu5.TabIndex = 8;
            this.btn_mainMenu5.Text = "창고품목관리";
            this.btn_mainMenu5.UseVisualStyleBackColor = true;
            this.btn_mainMenu5.Click += new System.EventHandler(this.btn_mainMenu5_Click);
            // 
            // btn_mainMenu4
            // 
            this.btn_mainMenu4.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu4.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu4.Location = new System.Drawing.Point(0, 257);
            this.btn_mainMenu4.Name = "btn_mainMenu4";
            this.btn_mainMenu4.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu4.TabIndex = 8;
            this.btn_mainMenu4.Text = "전체품목관리";
            this.btn_mainMenu4.UseVisualStyleBackColor = true;
            this.btn_mainMenu4.Click += new System.EventHandler(this.btn_mainMenu4_Click);
            // 
            // btn_mainMenu2
            // 
            this.btn_mainMenu2.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu2.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu2.Location = new System.Drawing.Point(0, 199);
            this.btn_mainMenu2.Name = "btn_mainMenu2";
            this.btn_mainMenu2.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu2.TabIndex = 8;
            this.btn_mainMenu2.Text = "설비모니터링";
            this.btn_mainMenu2.UseVisualStyleBackColor = true;
            this.btn_mainMenu2.Click += new System.EventHandler(this.btn_mainMenu2_Click);
            // 
            // btn_mainMenu1
            // 
            this.btn_mainMenu1.FlatAppearance.BorderSize = 0;
            this.btn_mainMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu1.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_mainMenu1.Location = new System.Drawing.Point(0, 141);
            this.btn_mainMenu1.Name = "btn_mainMenu1";
            this.btn_mainMenu1.Size = new System.Drawing.Size(182, 60);
            this.btn_mainMenu1.TabIndex = 8;
            this.btn_mainMenu1.Text = "설비가동현황";
            this.btn_mainMenu1.UseVisualStyleBackColor = true;
            this.btn_mainMenu1.Click += new System.EventHandler(this.btn_mainMenu1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 578);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 19);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pnlUser
            // 
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUser.HorizontalScrollbarBarColor = true;
            this.pnlUser.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlUser.HorizontalScrollbarSize = 10;
            this.pnlUser.Location = new System.Drawing.Point(0, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(182, 86);
            this.pnlUser.TabIndex = 6;
            this.pnlUser.VerticalScrollbarBarColor = true;
            this.pnlUser.VerticalScrollbarHighlightOnWheel = false;
            this.pnlUser.VerticalScrollbarSize = 10;
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(20, 18);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(84, 80);
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // PanelDesktopPanel
            // 
            this.PanelDesktopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDesktopPanel.Controls.Add(this.btn_signIn);
            this.PanelDesktopPanel.Controls.Add(this.label_objectInOut);
            this.PanelDesktopPanel.Controls.Add(this.toggle_warehouse);
            this.PanelDesktopPanel.Controls.Add(this.label_StaffinOut);
            this.PanelDesktopPanel.Controls.Add(this.toggle_chul);
            this.PanelDesktopPanel.Controls.Add(this.monthCalendar1);
            this.PanelDesktopPanel.Controls.Add(this.pictureBox2);
            this.PanelDesktopPanel.HorizontalScrollbarBarColor = true;
            this.PanelDesktopPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelDesktopPanel.HorizontalScrollbarSize = 10;
            this.PanelDesktopPanel.Location = new System.Drawing.Point(202, 101);
            this.PanelDesktopPanel.Name = "PanelDesktopPanel";
            this.PanelDesktopPanel.Size = new System.Drawing.Size(978, 560);
            this.PanelDesktopPanel.TabIndex = 1;
            this.PanelDesktopPanel.VerticalScrollbarBarColor = true;
            this.PanelDesktopPanel.VerticalScrollbarHighlightOnWheel = false;
            this.PanelDesktopPanel.VerticalScrollbarSize = 10;
            // 
            // label_objectInOut
            // 
            this.label_objectInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_objectInOut.AutoSize = true;
            this.label_objectInOut.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_objectInOut.Location = new System.Drawing.Point(647, 381);
            this.label_objectInOut.Name = "label_objectInOut";
            this.label_objectInOut.Size = new System.Drawing.Size(44, 23);
            this.label_objectInOut.TabIndex = 9;
            this.label_objectInOut.Text = "입고";
            // 
            // toggle_warehouse
            // 
            this.toggle_warehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggle_warehouse.AutoSize = true;
            this.toggle_warehouse.DisplayStatus = false;
            this.toggle_warehouse.Location = new System.Drawing.Point(716, 383);
            this.toggle_warehouse.Name = "toggle_warehouse";
            this.toggle_warehouse.Size = new System.Drawing.Size(50, 19);
            this.toggle_warehouse.TabIndex = 8;
            this.toggle_warehouse.Text = "Off";
            this.toggle_warehouse.UseSelectable = true;
            this.toggle_warehouse.CheckedChanged += new System.EventHandler(this.toggle_warehouse_CheckedChanged);
            // 
            // label_StaffinOut
            // 
            this.label_StaffinOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_StaffinOut.AutoSize = true;
            this.label_StaffinOut.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StaffinOut.Location = new System.Drawing.Point(647, 336);
            this.label_StaffinOut.Name = "label_StaffinOut";
            this.label_StaffinOut.Size = new System.Drawing.Size(44, 23);
            this.label_StaffinOut.TabIndex = 9;
            this.label_StaffinOut.Text = "출근";
            // 
            // toggle_chul
            // 
            this.toggle_chul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggle_chul.AutoSize = true;
            this.toggle_chul.DisplayStatus = false;
            this.toggle_chul.Location = new System.Drawing.Point(716, 338);
            this.toggle_chul.Name = "toggle_chul";
            this.toggle_chul.Size = new System.Drawing.Size(50, 19);
            this.toggle_chul.TabIndex = 8;
            this.toggle_chul.Text = "Off";
            this.toggle_chul.UseSelectable = true;
            this.toggle_chul.CheckedChanged += new System.EventHandler(this.toggle_chul_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar1.Location = new System.Drawing.Point(567, 81);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(49, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(178, 186);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.btn_Home);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 60);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1160, 43);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // btn_Home
            // 
            this.btn_Home.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Home.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btn_Home.Location = new System.Drawing.Point(1098, 0);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(62, 43);
            this.btn_Home.TabIndex = 2;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseSelectable = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_myPage_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerStaffAttand
            // 
            this.timerStaffAttand.Enabled = true;
            this.timerStaffAttand.Interval = 1000;
            this.timerStaffAttand.Tick += new System.EventHandler(this.timerStaffAttand_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(110, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ver1.0";
            // 
            // btn_signIn
            // 
            this.btn_signIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_signIn.BackColor = System.Drawing.Color.LightGray;
            this.btn_signIn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_signIn.FlatAppearance.BorderSize = 0;
            this.btn_signIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signIn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signIn.Location = new System.Drawing.Point(49, 368);
            this.btn_signIn.Name = "btn_signIn";
            this.btn_signIn.Size = new System.Drawing.Size(178, 48);
            this.btn_signIn.TabIndex = 10;
            this.btn_signIn.Text = "신규 사용자 등록";
            this.btn_signIn.UseVisualStyleBackColor = false;
            this.btn_signIn.Click += new System.EventHandler(this.btn_signIn_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.PanelDesktopPanel);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.PanelDesktopPanel.ResumeLayout(false);
            this.PanelDesktopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel PanelMenu;
        private MetroFramework.Controls.MetroPanel PanelDesktopPanel;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton btn_Home;
        private MetroFramework.Controls.MetroPanel pnlUser;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_StaffinOut;
        private MetroFramework.Controls.MetroToggle toggle_chul;
        private System.Windows.Forms.Timer timerStaffAttand;
        private System.Windows.Forms.Label label_objectInOut;
        private MetroFramework.Controls.MetroToggle toggle_warehouse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_mainMenu2;
        private System.Windows.Forms.Button btn_mainMenu1;
        private System.Windows.Forms.Button btn_mainMenu7;
        private System.Windows.Forms.Button btn_mainMenu6;
        private System.Windows.Forms.Button btn_mainMenu5;
        private System.Windows.Forms.Button btn_mainMenu4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_signIn;
    }
}

