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
    public partial class FormWarehouseObj : Form
    {
        // DB연동 변수
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈

        // DB 속성 변수

        string o_category;
        string o_name;
        string w_time, r_time;
        string o_id;

        private void btn_warehouseSelect_Click(object sender, EventArgs e)
        {
           
        
        }

        private void FormWarehouseObj_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            
            sql = "SELECT o_category, o_name, o_id, w_time FROM ObjectTbl WHERE w_time is not NULL AND r_time is NULL;"; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader(); // 짐을 서버에 부어넣고, 끈으로 묶어서 끈만 가져옴.

            while (reader.Read())
            {
                // DB에서 read
                o_category = (string)reader["o_category"];
                o_name = (string)reader["o_name"];
                o_id = (string)reader["o_id"];

                if (string.IsNullOrEmpty(reader["w_time"].ToString()))
                {
                    w_time = "";
                }
                else
                {
                    w_time = reader["w_time"].ToString();
                }


                // table 출력
                ListView_WarehouseObj.Location = new Point(30, 60);

                ListViewItem item = new ListViewItem(o_category.ToString());
                item.SubItems.Add(o_name.ToString());
                item.SubItems.Add(o_id.ToString());
                item.SubItems.Add(w_time.ToString());
                ListView_WarehouseObj.Items.Add(item);
            }
            reader.Close();
            
        }

        private void FormWarehouseObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        public FormWarehouseObj()
        {
            InitializeComponent();

            // ListView 설정
            ListView_WarehouseObj.View = View.Details; //화면 설정(타입:Details)
            ListView_WarehouseObj.GridLines = true;    //구분선

            // ListView Col. 추가
            ListView_WarehouseObj.Columns.Add("카테고리", 100);
            ListView_WarehouseObj.Columns.Add("제품명", 200);
            ListView_WarehouseObj.Columns.Add("제품번호", 100);
            ListView_WarehouseObj.Columns.Add("입고", 200);
            
        }
    }
}
