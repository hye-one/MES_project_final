using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //Add for UART
using System.Data.SqlClient; //Add for MySQL
using MySql.Data.MySqlClient;

namespace MES_project
{
    public delegate void LoginEventHandler(string id, string pw);
    public partial class FormLogin : MetroFramework.Forms.MetroForm
    {
        public event LoginEventHandler loginEventHandler;

        string id;
        string pw;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            tb_id.Focus();
        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
            LoginHandler loginHandler = new LoginHandler();
            if (ControlCheck())
            {
                id = tb_id.Text;
                pw = tb_pw.Text;
                if (loginHandler.LoginCheck(id, pw))    //Loginhandler 클래스를 호출해 id, pw가 일치하는지 확인한다.
                {
                    loginEventHandler(id, pw);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //tb_id.Clear();
                    //tb_pw.Clear();
                }
            }
        }

        private bool ControlCheck()
        {
            if (String.IsNullOrEmpty(tb_id.Text) || String.IsNullOrEmpty(tb_pw.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요");
                return false;
            }
            else
            return true;
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            
        }
    }
}
