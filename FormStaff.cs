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
    public partial class FormStaff : Form
    {
        // DB연동 변수
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈

        // DB 속성 변수
        string u_name;
        byte u_jigak;
        byte u_absent;
        byte u_jogi;
        string u_inTime;
        string u_outTime;

        public FormStaff()
        {
            InitializeComponent();
            // ListView 설정
            ListView_Staff.Location = new Point(30, 60);
            ListView_Staff.View = View.Details; //화면 설정(타입:Details)
            ListView_Staff.GridLines = true;    //구분선

            // ListView Col. 추가
            ListView_Staff.Columns.Add("이름", 80);
            ListView_Staff.Columns.Add("지각", 40);
            ListView_Staff.Columns.Add("조퇴", 40);
            ListView_Staff.Columns.Add("결근", 40);
            ListView_Staff.Columns.Add("출근시각", 200);
            ListView_Staff.Columns.Add("퇴근시각", 200);
            
        }

       private void changeHeaderColor(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Aqua, e.Bounds);
            e.DrawText();
        }
        private void DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                //switch (e.Header.TextAlign)
                //{
                //    case HorizontalAlignment.Center:
                //        sf.Alignment = StringAlignment.Center;
                //        break;
                //    case HorizontalAlignment.Right:
                //        sf.Alignment = StringAlignment.Far;
                //        break;
                //}

                // Draw the standard header background.
                e.DrawBackground();

                e.Graphics.FillRectangle(Brushes.Aqua, e.Bounds);
                e.DrawText();
            }
            return;
        }
        private void FormStaff_Load(object sender, EventArgs e)
        {
            ListView_Staff.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(DrawColumnHeader);

            //<1> 데이터베이스 연결 (교량 건설) + <2> 트럭 준비
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            // <3> 물건을 준비해서, 트럭에 실어서 다리 건너 부어넣기.
            sql = "SELECT u_name, u_jigak, u_absent, u_jogi, u_inTime, u_outTime FROM UserTbl"; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader(); // 짐을 서버에 부어넣고, 끈으로 묶어서 끈만 가져옴.

            while (reader.Read())
            {
                // DB에서 read
                u_name = (string)reader["u_name"];
                if (string.IsNullOrEmpty(reader["u_jigak"].ToString()))
                    u_jigak = 0;
                else
                    u_jigak = (byte)reader["u_jigak"];

                if (string.IsNullOrEmpty(reader["u_jogi"].ToString()))
                    u_jogi = 0;
                else
                    u_jogi = (byte)reader["u_jogi"];

                if (string.IsNullOrEmpty(reader["u_absent"].ToString()))
                    u_absent = 0;
                else
                    u_absent = (byte)reader["u_absent"];

                if (string.IsNullOrEmpty(reader["u_inTime"].ToString()))
                    u_inTime = " ";
                else
                    u_inTime = reader["u_inTime"].ToString();

                if (string.IsNullOrEmpty(reader["u_outTime"].ToString()))
                    u_outTime = " ";
                else
                    u_outTime = reader["u_outTime"].ToString();

                // table 출력
                ListViewItem item = new ListViewItem(u_name.ToString());
                item.SubItems.Add(u_jigak.ToString());
                item.SubItems.Add(u_absent.ToString());
                item.SubItems.Add(u_jogi.ToString());
                item.SubItems.Add(u_inTime.ToString());
                item.SubItems.Add(u_outTime.ToString());
                ListView_Staff.Items.Add(item);
                //item.UseItemStyleForSubItems = false;   
                //item.SubItems[1].BackColor = Color.Salmon;
            }
            reader.Close();
            conn.Close();
        }
    }
}
