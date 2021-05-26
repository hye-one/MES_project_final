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
    public partial class FormObjectSignin : MetroFramework.Forms.MetroForm
    {
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        string dataIn;
        string rfid_tag;

        string[] tmp1 = { }; string[] tmp2 = { };
        // 중복확인 flag
        int rfidcheckflag = 0;

        SerialPort objectPort;

        public FormObjectSignin(SerialPort port)
        {
            InitializeComponent();
            objectPort = port;
        }

        private void FormObjectSignin_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            FormMainMenu.rfid_objSignin = true;
            MessageBox.Show(FormMainMenu.rfid_objSignin.ToString());
            objectPort.DataReceived += ObjectPort_DataReceived;

        }

        private void ObjectPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //MessageBox.Show("데이터 받아오기");
            // rfid 읽기
            dataIn = objectPort.ReadLine();        // \n를 만날때까지 읽어 들인다.                 
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(showdata));
            }
        }

        private void showdata(object s, EventArgs e)
        {
            if (dataIn.Contains("rfid2") == true)
            {
                //MessageBox.Show("rfid태그됨");
                tmp1 = dataIn.Split('/');
                tmp2 = tmp1[1].Split(' ');
                rfid_tag = tmp2[0] + " " + tmp2[1] + " " + tmp2[2] + " " + tmp2[3] + " " + tmp2[4];
                tb_rfid.Text = rfid_tag;
            }
            
        }

        private void btn_rfidtag_Click(object sender, EventArgs e)
        {
            // 입력된 rfid가 db에 저장되어 있는지 확인
            // SELECT COUNT(o_RFIDid) as count FROM ObjectTbl WHERE o_RFIDid = 'd1 f6 bf 49 d1';
            sql = "SELECT COUNT(o_RFIDid) as count FROM ObjectTbl WHERE o_RFIDid = '" + tb_rfid.Text + "';";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();
            int rfidcheck = int.Parse(reader["count"].ToString());

            if (tb_rfid.Text != "" && tb_rfid.Text.Length == 14)
            {
                if (rfidcheck != 0)
                {
                    objectPort.WriteLine("invalid2" + Environment.NewLine);
                    MessageBox.Show("사용중인 rfid입니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    objectPort.WriteLine("valid2" + Environment.NewLine);
                    MessageBox.Show("rfid를 사용할 수 있습니다", "알림", MessageBoxButtons.OK);
                    rfidcheckflag = 1;
                }
            }
            else
            {
                objectPort.WriteLine("invalid2" + Environment.NewLine);
                MessageBox.Show("rfid를 다시 한번 확인해주세요");
            }
            reader.Close();
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == "")
            {
                MessageBox.Show("id를 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_category.Text == "")
            {
                MessageBox.Show("카테고리를 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_name.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_rfid.Text == "")
            {
                MessageBox.Show("rfid를 tag해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rfidcheckflag != 1)
            {
                MessageBox.Show("rfid 중복확인 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // DB에 저장 -> 처리완료 메시지 박스 -> CLOSE --------------------------- //
                // INSERT INTO ObjectTbl (o_RFIDid, o_category, o_name, o_id) VALUES ('TT f6 bf 49 d1', '볼베어링', '볼베어링d10D26', '1234');
                sql = "INSERT INTO ObjectTbl (o_RFIDid, o_category, o_name, o_id) VALUES ('";
                sql += tb_rfid.Text + "', '" + tb_category.Text + "', '" + tb_name.Text + "', '" + tb_id.Text + "');";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("등록완료!");
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMainMenu.rfid_userSignin = false;
        }

        private void FormObjectSignin_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectPort.DataReceived -= ObjectPort_DataReceived;
            FormMainMenu.rfid_objSignin = false;
            conn.Close();
        }

        private void tb_rfid_TextChanged(object sender, EventArgs e)
        {
            rfidcheckflag = 0;
        }
    }
}
