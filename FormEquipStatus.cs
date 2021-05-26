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
    public partial class FormEquipStatus : Form
    {
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        //static String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        int valDtflag = 0;
        int dtDefalut1, dtDefalut2, dtDefalut3;
        string [] et_timeAry = new string[30];
        int[] room1ct = new int[30];
        int[] room2ct = new int[30];
        int[] room3ct = new int[30];
        int[] room1dt = new int[30];
        int[] room2dt = new int[30];
        int[] room3dt = new int[30];
        // 시간 변수
        string nowTime;
        DateTime et_time;
        string et_timeString;
        int ct1, ct2, ct3, dt1, dt2, dt3;

        SerialPort equipPort;
        Timer timer;

        // AirCompressor 변수
        bool AirFlag_1ho, AirFlag_2ho, AirFlag_3ho;
        bool good1ho, good2ho, good3ho;
        //byte a_num;
        const byte a_num1 = 1, a_num2 = 2, a_num3 = 3;
        string a_time;
        byte[] a_status1, a_status2, a_status3;
        
        
        public FormEquipStatus(SerialPort port, Timer timer)
        {
            InitializeComponent();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            equipPort = port;
            this.timer = timer;
        }
        private void airComp()
        {
            goodTemp();
            nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!good1ho && !AirFlag_1ho)   //켜야 하고 꺼져 있을 때
            {
                AirFlag_1ho = true;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num1 + ", '" + nowTime + "', " + 1 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if(good1ho && AirFlag_1ho)     //꺼야 하고 켜져 있을 때
            {
                AirFlag_1ho = false;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num1 + ", '" + nowTime + "', " + 0 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if(!good1ho && AirFlag_1ho) //켜야 하고 켜져 있을 때
            {
                AirFlag_1ho = true;
            }
            else //꺼야 하고 꺼져 있을 때
            {
                AirFlag_1ho = false;
            }
            //2호기
            if (!good2ho && !AirFlag_2ho)   //켜야 하고 꺼져 있을 때
            {
                AirFlag_2ho = true;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num2 + ", '" + nowTime + "', " + 1 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if (good2ho && AirFlag_2ho)     //꺼야 하고 켜져 있을 때
            {
                AirFlag_2ho = false;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num2 + ", '" + nowTime + "', " + 0 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if (!good2ho && AirFlag_2ho) //켜야 하고 켜져 있을 때
            {
                AirFlag_2ho = true;
            }
            else //꺼야 하고 꺼져 있을 때
            {
                AirFlag_2ho = false;
            }
            // 3호기
            if (!good3ho && !AirFlag_3ho)   //켜야 하고 꺼져 있을 때
            {
                AirFlag_3ho = true;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num3 + ", '" + nowTime + "', " + 1 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if (good3ho && AirFlag_3ho)     //꺼야 하고 켜져 있을 때
            {
                AirFlag_3ho = false;
                sql = "INSERT INTO AirCompTbl (a_num, a_time, a_status) VALUES (";
                sql += a_num3 + ", '" + nowTime + "', " + 0 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            else if (!good3ho && AirFlag_3ho) //켜야 하고 켜져 있을 때
            {
                AirFlag_3ho = true;
            }
            else //꺼야 하고 꺼져 있을 때
            {
                AirFlag_3ho = false;
            }


        }
        private void goodTemp() //온도 상태 확인
        {
            if (ct1 > dt1)
            {
                good1ho = false;
                label_airCompStatus1.Text = "ON";
            }
            else
            {
                good1ho = true;
                label_airCompStatus1.Text = "OFF";
            }
            if (ct2 > dt2)
            {
                good2ho = false;
                label_airCompStatus_2.Text = "ON";

            }
            else
            {
                good2ho = true;
                label_airCompStatus_2.Text = "OFF";

            }
            if (ct3 > dt3)
            {
                good3ho = false;
                label_airCompStatus3.Text = "ON";

            }
            else
            {
                good3ho = true;
                label_airCompStatus3.Text = "OFF";

            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 텍스트에 출력하기
            // SELECT ct1, dt1, ct2, dt2, ct3, dt3 FROM EquipTempTbl;
            sql = "SELECT et_time, ct1, dt1, ct2, dt2, ct3, dt3 FROM EquipTempTbl;";
            cmd.CommandText = sql;

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                et_time = (DateTime)reader["et_time"];
                et_timeString = et_time.ToString("HH:mm:ss");
                ct1 = int.Parse(reader["ct1"].ToString());
                ct2 = int.Parse(reader["ct2"].ToString());
                ct3 = int.Parse(reader["ct3"].ToString());
                dt1 = int.Parse(reader["dt1"].ToString());
                dt2 = int.Parse(reader["dt2"].ToString());
                dt3 = int.Parse(reader["dt3"].ToString());

                //if (valDtflag == 0)
                //{
                //    trackBar1.Value = int.Parse(tb_dt1.Text);
                //    trackBar2.Value = int.Parse(tb_dt2.Text);
                //    trackBar3.Value = int.Parse(tb_dt3.Text);

                //    tb_dtValue1.Text = trackBar1.Value.ToString();
                //    tb_dtValue2.Text = trackBar2.Value.ToString();
                //    tb_dtValue3.Text = trackBar3.Value.ToString();

                //    dtDefalut1 = trackBar1.Value;
                //    dtDefalut2 = trackBar2.Value;
                //    dtDefalut3 = trackBar3.Value;
                //    valDtflag = 1;
                //}

            }
            reader.Close();

            // 공조기 제어
            airComp();

            tb_ct1.Text = ct1.ToString();
            tb_ct2.Text = ct2.ToString();
            tb_ct3.Text = ct3.ToString();
            tb_dt1.Text = dt1.ToString();
            tb_dt2.Text = dt2.ToString();
            tb_dt3.Text = dt3.ToString();
            // 그래프로 출력하기
            // 한칸씩 당기기

            for (int i = 0; i < room1ct.Length - 1; i++)
            {
                et_timeAry[i] = et_timeAry[i + 1];
                room1ct[i] = room1ct[i + 1];
                room1dt[i] = room1dt[i + 1];
                room2ct[i] = room2ct[i + 1];
                room2dt[i] = room2dt[i + 1];
                room3ct[i] = room3ct[i + 1];
                room3dt[i] = room3dt[i + 1];
            }
            // 마지막칸에 값 넣기
            for (int i = 0; i < et_timeAry.Length; i++)
            {
                et_timeAry[et_timeAry.Length - 1 - i] = et_time.AddSeconds(-i).ToString("HH:mm:ss");
            }

            et_timeAry[et_timeAry.Length - 1] = et_timeString;
            room1ct[room1ct.Length - 1] = ct1;
            room1dt[room1dt.Length - 1] = dt1;
            room2ct[room2ct.Length - 1] = ct2;
            room2dt[room2dt.Length - 1] = dt2;
            room3ct[room3ct.Length - 1] = ct3;
            room3dt[room3dt.Length - 1] = dt3;


            chart_1ho.Series[0].Points.Clear();
            chart_1ho.Series[1].Points.Clear();
            chart_2ho.Series[0].Points.Clear();
            chart_2ho.Series[1].Points.Clear();
            chart_3ho.Series[0].Points.Clear();
            chart_3ho.Series[1].Points.Clear();

            for (int i = 0; i < room1ct.Length; i++)
            {
                chart_1ho.Series[0].Points.AddXY(et_timeAry[i], room1ct[i]);
                chart_1ho.Series[1].Points.AddXY(et_timeAry[i], room1dt[i]);
                chart_2ho.Series[0].Points.AddXY(et_timeAry[i], room2ct[i]);
                chart_2ho.Series[1].Points.AddXY(et_timeAry[i], room2dt[i]);
                chart_3ho.Series[0].Points.AddXY(et_timeAry[i], room3ct[i]);
                chart_3ho.Series[1].Points.AddXY(et_timeAry[i], room3dt[i]);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e) // 삭제하기
        {

        }

        private void FormEquipStatus_Load(object sender, EventArgs e)
        {
            timer.Tick += Timer_Tick;

            // 그래프 그리기
            chart_1ho.Series[0].ChartType =  // room1 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart_1ho.Series[1].ChartType =  // room1 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart_2ho.Series[0].ChartType =  // room2 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart_2ho.Series[1].ChartType =  // room2 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart_3ho.Series[0].ChartType =  // room3 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart_3ho.Series[1].ChartType =  // room3 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            //chart_Room2Temp.Series[0].Color = Color.DodgerBlue;
            //chart_Room2Temp.Series[1].Color = Color.DeepSkyBlue;
            chart_1ho.Series[0].BorderWidth = 2;
            chart_1ho.Series[1].BorderWidth = 2;
            chart_2ho.Series[0].BorderWidth = 2;
            chart_2ho.Series[1].BorderWidth = 2;
            chart_3ho.Series[0].BorderWidth = 2;
            chart_3ho.Series[1].BorderWidth = 2;
            // Legend Setting
            chart_1ho.Series[0].LegendText = "현재온도";
            chart_1ho.Series[1].LegendText = "설정온도";
            chart_2ho.Series[0].LegendText = "현재온도";
            chart_2ho.Series[1].LegendText = "설정온도";
            chart_3ho.Series[0].LegendText = "현재온도";
            chart_3ho.Series[1].LegendText = "설정온도";
            
            chart_1ho.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart_2ho.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart_3ho.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;

            
            
        }

        private void FormEquipStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tb_dtValue1.Text = trackBar1.Value.ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tb_dtValue2.Text = trackBar2.Value.ToString();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            tb_dtValue3.Text = trackBar3.Value.ToString();
        }

        // 희망온도를 Default 값으로 초기화
        private void btn_dtReset1_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room1 " + dtDefalut1 + Environment.NewLine);
            trackBar1.Value = dtDefalut1;
            tb_dtValue1.Text = dtDefalut1.ToString();
        }
        private void btn_dtReset2_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room2 " + dtDefalut2 + Environment.NewLine);
            trackBar2.Value = dtDefalut2;
            tb_dtValue2.Text = dtDefalut2.ToString();
        }
        private void btn_dtReset3_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room3 " + dtDefalut3 + Environment.NewLine);
            trackBar3.Value = dtDefalut3;
            tb_dtValue3.Text = dtDefalut3.ToString();
        }

        // 희망온도를 원하는 값으로 설정
        private void btn_dtSet1_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room1 " + tb_dtValue1.Text + Environment.NewLine);
        }
        private void btn_dtSet2_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room2 " + tb_dtValue2.Text + Environment.NewLine);
        }
        private void btn_dtSet3_Click(object sender, EventArgs e)
        {
            equipPort.WriteLine("room3 " + tb_dtValue3.Text + Environment.NewLine);
        }
    }
}
