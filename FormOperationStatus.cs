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
    public partial class FormOperationStatus : Form
    {
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        string e_status1, e_status2, e_status3;
        string e_time;
        string e_status;
        string loadTime;
        string lastUpdate;
        string nowdate = null;
        const byte e_num1 = 1, e_num2 = 2, e_num3 = 3;
        Timer timer;
        public FormOperationStatus(Timer timer)
        {
            InitializeComponent();
            // ListView 설정
            ListView_1ho.View = View.Details; //화면 설정(타입:Details)
            ListView_1ho.GridLines = true;    //구분선
            ListView_2ho.View = View.Details; //화면 설정(타입:Details)
            ListView_2ho.GridLines = true;    //구분선
            ListView_3ho.View = View.Details; //화면 설정(타입:Details)
            ListView_3ho.GridLines = true;    //구분선

            // ListView Col. 추가
            ListView_1ho.Columns.Add("상태저장시각", 150);
            ListView_1ho.Columns.Add("상태", 100);
            ListView_2ho.Columns.Add("상태저장시각", 150);
            ListView_2ho.Columns.Add("상태", 100);
            ListView_3ho.Columns.Add("상태저장시각", 150);
            ListView_3ho.Columns.Add("상태", 100);
            this.timer = timer;
            timer.Tick += Timer_Tick;
        }

        private void ListViewShow_Status_change(byte ho)
        {
            nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT e_num, e_time, e_status FROM equipmenttbl WHERE e_num = "+ ho +" AND e_time LIKE '" + nowdate + "%' order by e_num, e_time ASC;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                e_time = ((DateTime)reader["e_time"]).ToString("HH:mm:ss");
                //e_status = reader["e_status"].ToString();
                string tmp_daytime = e_time.ToString();
                string[] tmp = tmp_daytime.Split(' ');
                if(reader["e_status"].ToString() == "1")
                {
                    e_status = "가동";
                }
                else
                {
                    e_status = "정지";
                }
                // table 출력
                ListViewItem item = new ListViewItem(e_time);
                item.SubItems.Add(e_status.ToString());
                if(ho == 1) 
                {
                    ListView_1ho.Items.Add(item);
                }
                else if(ho == 2)
                {
                    ListView_2ho.Items.Add(item);
                }
                else
                {
                    ListView_3ho.Items.Add(item);
                }
                
            }
            reader.Close();
            loadTime = e_time;
            conn.Close();
            
        }

        private void Update_Status_change(string nowdate, byte ho, string lastUpdate)
        {
            //nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            //SELECT e_num, e_time, e_status FROM equipmenttbl WHERE e_num = 1 AND e_time > '2021-05-17 14:38:34' order by e_num, e_time;
            sql = "SELECT e_num, e_time, e_status FROM equipmenttbl WHERE e_num = " + ho;
            sql += " AND e_time >= '" + nowdate + " " + lastUpdate + "' order by e_num, e_time;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                e_time = ((DateTime)reader["e_time"]).ToString("HH:mm:ss");
                string tmp_daytime = e_time.ToString();
                string[] tmp = tmp_daytime.Split(' ');
                if (reader["e_status"].ToString() == "1")
                {
                    e_status = "가동";
                }
                else
                {
                    e_status = "정지";
                }
                // table 출력
                ListViewItem item = new ListViewItem(e_time);
                item.SubItems.Add(e_status.ToString());
                if (ho == 1)
                {
                    ListView_1ho.Items.Add(item);
                }
                else if (ho == 2)
                {
                    ListView_2ho.Items.Add(item);
                }
                else
                {
                    ListView_3ho.Items.Add(item);
                }

            }
            reader.Close();

            conn.Close();
        }
        private void FormOperationStatus_Load(object sender, EventArgs e)
        {
            // 오늘 상태변화 listVeiw에 출력
            //string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            
            // 1호기 상태변화 출력
            ListViewShow_Status_change(e_num1);
            // 2호기 상태변화 출력
            ListViewShow_Status_change(e_num2);
            // 3호기 상태변화 출력
            ListViewShow_Status_change(e_num3);

            lastUpdate = loadTime;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lastUpdate = loadTime;
            string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            // 현상황 상태 버튼색으로 나타내기
            e_status1 = FormMainMenu.e_status1[0];
            e_status2 = FormMainMenu.e_status2[0];
            e_status3 = FormMainMenu.e_status3[0];
            btn_1ho.UseCustomBackColor = true;
            btn_2ho.UseCustomBackColor = true;
            btn_3ho.UseCustomBackColor = true;
            if (e_status1 == "1")
            {
                btn_1ho.BackColor = Color.LawnGreen;
                btn_1ho.Text = "가동중";
            }
            else
            {
                btn_1ho.BackColor = Color.Red;
                btn_1ho.Text = "정지";
            }
            if (e_status2 == "1")
            {
                btn_2ho.BackColor = Color.LawnGreen;
                btn_2ho.Text = "가동중";
            }
            else
            {
                btn_2ho.BackColor = Color.Red;
                btn_2ho.Text = "정지";
            }
            if (e_status3 == "1")
            {
                btn_3ho.BackColor = Color.LawnGreen;
                btn_3ho.Text = "가동중";
            }
            else
            {
                btn_3ho.BackColor = Color.Red;
                btn_3ho.Text = "정지";
            }

            if (FormMainMenu.e_status1[0] != FormMainMenu.e_status1[1])
            {
                Update_Status_change(nowdate, 1, lastUpdate);
            }
            if (FormMainMenu.e_status2[0] != FormMainMenu.e_status2[1])
            {
                Update_Status_change(nowdate, 2, lastUpdate);
            }
            if (FormMainMenu.e_status3[0] != FormMainMenu.e_status3[1])
            {
                Update_Status_change(nowdate, 3, lastUpdate);
            }
        }
    }
}
