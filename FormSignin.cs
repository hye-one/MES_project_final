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
using System.Timers;
namespace MES_project
{
    public partial class FormSignin : MetroFramework.Forms.MetroForm
    {
        // DB연동 변수
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        string dataIn;
        string rfid_tag;

        // 중복확인 flag
        int idcheckflag = 0;
        int rfidcheckflag = 0;
        SerialPort userPort;
        public FormSignin(SerialPort port)
        {
            InitializeComponent();
            userPort = port;
        }

        private void FormSignin_Load(object sender, EventArgs e)
        {
            
            // DB 연결
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            FormMainMenu.rfid_userSignin = true;
            //MessageBox.Show(FormMainMenu.rfid_userSignin.ToString());

            userPort.DataReceived += UserPort_DataReceived;
            // PORT 연결
            //serialPort1.PortName = "COM8";
            //serialPort1.BaudRate = 115200;
            //serialPort1.Open();
        }

        private void UserPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //MessageBox.Show("데이터 받아오기");
            // rfid 읽기
            dataIn = userPort.ReadLine();        // \n를 만날때까지 읽어 들인다.                 
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(showdata));
            }
        }
        

        private void showdata(object s, EventArgs e)
        {
            string[] tmp1 = { }; string[] tmp2 = { };
            if (dataIn.Contains("rfid1") == true)
            {
                tmp1 = dataIn.Split('/');
                tmp2 = tmp1[1].Split(' ');
                rfid_tag = tmp2[0] + " " + tmp2[1] + " " + tmp2[2] + " " + tmp2[3] + " " + tmp2[4];
                tb_rfid.Text = rfid_tag;
            }
        }

        private void btn_idcheck_Click(object sender, EventArgs e)
        {
            // 입력된 id가 db에 저장되어 있는지 확인
            // SELECT COUNT(u_id) FROM UserTbl WHERE u_id = 'heehee';
            sql = "SELECT COUNT(u_id) as count FROM UserTbl WHERE u_id = '" + tb_id.Text + "';";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();
            int idcheck = int.Parse(reader["count"].ToString());
            
            if(idcheck != 0)
            {
                MessageBox.Show("사용중인 id입니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("id를 사용할 수 있습니다", "알림", MessageBoxButtons.OK);
                idcheckflag = 1;
            }
            reader.Close();
        }

        private void btn_rfid_Click(object sender, EventArgs e)
        {
            // 입력된 rfid가 db에 저장되어 있는지 확인
            // SELECT COUNT(u_RFIDid) as count FROM UserTbl WHERE u_RFIDid = 'b0 fb 27 32 5e';
            sql = "SELECT COUNT(u_RFIDid) as count FROM UserTbl WHERE u_RFIDid = '" + tb_rfid.Text + "';";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();
            int rfidcheck = int.Parse(reader["count"].ToString());

            if(tb_rfid.Text != "" && tb_rfid.Text.Length == 14)
            {
                if (rfidcheck != 0)
                {
                    userPort.WriteLine("invalid1" + Environment.NewLine);
                    MessageBox.Show("사용중인 rfid입니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_rfid.Clear();
                }
                else
                {
                    userPort.WriteLine("valid1" + Environment.NewLine);
                    MessageBox.Show("rfid를 사용할 수 있습니다", "알림", MessageBoxButtons.OK);
                    rfidcheckflag = 1;
                }
            }
            else
            {
                userPort.WriteLine("invalid1" + Environment.NewLine);
                MessageBox.Show("rfid를 다시 한번 확인해주세요");
            }
            reader.Close();
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            if(idcheckflag != 1)
            {
                MessageBox.Show("id 중복확인 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(tb_pw.Text == "")
            {
                MessageBox.Show("pw를 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(tb_name.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_rfid.Text == "")
            {
                MessageBox.Show("rfid를 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(rfidcheckflag != 1) 
            {
                MessageBox.Show("rfid 중복확인 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // DB에 저장 -> 처리완료 메시지 박스 -> CLOSE --------------------------- //
                // INSERT INTO UserTbl (u_RFIDid, u_id, u_pw, u_name) VALUES ('b0 11 27 32 5e', 'miji', '1lswl11', '강민지');
                sql = "INSERT INTO UserTbl (u_RFIDid, u_id, u_pw, u_name, u_jigak, u_jogi, u_absent) VALUES ('";
                sql += tb_rfid.Text + "', '" + tb_id.Text + "', '" + tb_pw.Text + "', '" + tb_name.Text + "', 0, 0, 0);";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("등록완료!");
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSignin_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            userPort.DataReceived -= UserPort_DataReceived;
            FormMainMenu.rfid_userSignin = false;
        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {
            idcheckflag = 0;
        }

        private void tb_rfid_TextChanged(object sender, EventArgs e)
        {
            rfidcheckflag = 0;
        }
    }
}
