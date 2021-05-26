using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports; //Add for UART
using System.Data.SqlClient; //Add for MySQL
using MySql.Data.MySqlClient;
namespace MES_project
{
    class LoginHandler
    {
        // DB연동 변수
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈

        private bool UserTblChek(string id, string pw)
        {
            //<1> 데이터베이스 연결 (교량 건설) + <2> 트럭 준비
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            sql = "SELECT EXISTS (SELECT u_id FROM UserTbl where u_id = '";
            sql += id + "') as success";
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader();
            long correctId = 0;
            while (reader.Read())
            {
                correctId = (long)reader["success"];
            }

            reader.Close();
            if (correctId == 1)
            {
                sql = "SELECT EXISTS (SELECT u_pw FROM UserTbl where u_pw = '";
                sql += pw + "') as success;";
                cmd.CommandText = sql;  // 짐을 트럭에 싣기
                reader = cmd.ExecuteReader();
                long correctPw = 0;
                while (reader.Read())
                {
                    correctPw = (long)reader["success"];

                }
                reader.Close();
                if (correctPw == 1 && correctId == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;


            //<4> 데이터베이스 해제 (교량 철거)
            conn.Close();
        }

        public bool LoginCheck(string id, string pw) 
        {
            bool check;

           check = UserTblChek(id, pw);
            //임시 관리자 아이디랑 비번 만들고 싶으면 다음 줄을 if (check|| id.Equals("11")) 와 같이 변경
            if (check)
                return true;
            else
                return false;
        }
            
    }
}
