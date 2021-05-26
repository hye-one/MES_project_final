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
    public partial class FormMainMenu : MetroFramework.Forms.MetroForm
    {
        FormLogin formLogin;

        //-----------변수 선언부---------------
        Size desktopPanelSize = new Size(978, 560);

        // 시간 변수
        string nowTime;

        // DB연동 변수
        //static String connStr = "Server=127.0.0.1; Uid=root; Pwd=1234; Database=MESdb; Charset=UTF8";
        static String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=MESdb;Charset=UTF8";
        static MySqlConnection conn; // 교량
        static MySqlCommand cmd; // 트럭
        static String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈

        // DB 속성 변수
        string u_inTime;
        string u_outTime;
        string staff_rfid_tag;    //출퇴근 태그할 때 태그된 RFIDid
        string object_rfid_tag;
        string u_RFIDid;    //결근 처리할 때 DB에서 불러오는 RFIDid
        string w_time, r_time;  //입고, 출고시각

        // STM32 UART 통신 변수
        string dataIn; //UART로부터 들어온 data를 읽어 들이는 변수
        string[] inputSensorData;
        string ct1, dt1, ct2, dt2, ct3, dt3;
        string e_num1 = "1 ", e_num2 = "2", e_num3 = "3";
        public static string[] e_status1 = new string[2];    // 0번째 : 변경 후, 1번째 : 변경 전 
        public static string[] e_status2 = new string[2];
        public static string[] e_status3 = new string[2];

        // RFID 변수
        bool rfid_chulFlag; //RFID 출근/퇴근 선택 상태 플래그
        bool rfid_wareFlag; //RFID 입고/출고 선택 상태 플래그
        public static bool rfid_objSignin; //품목 등록창 활성화 상태 플래그
        public static bool rfid_userSignin;
        
        // 근태관리변수
        string nowTimeHHmmss;
        string todayString;
        bool checkinToday, checkoutToday;
        string[] absentAry = { };   //결근자
        bool absentUpdateFlag;
        DateTime today;
        //Fields
        private Button currentButton;
        private Form activeForm = null;     // Form을 저장할 Form 변수

        public static string status_time;
        public static string status;

        // Constructor
        public FormMainMenu()
        { 
            InitializeComponent();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);

            rfid_objSignin = false;
            rfid_userSignin = false;

            FormObjectSignin formObjectSignin = new FormObjectSignin(serialPort1);
            if(formObjectSignin != null)
            {
                rfid_objSignin = true;
            }
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 174, 219);
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in PanelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.FromArgb(58, 58, 58);
                    
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnsender)
        {
            ActivateButton(btnsender);
            if (activeForm != null && activeForm.Text != "FormEquipStatus" && activeForm.Text != "FormOperationStatus")
            {
                activeForm.Close();
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == childForm.GetType())
                {
                    activeForm = childForm;
                    form.Show();
                    form.Activate();
                    form.BringToFront();
                    return;
                }
            }
            activeForm = childForm;
            childForm.TopLevel = false; //childForm -> control
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelDesktopPanel.Controls.Add(childForm);
            this.PanelDesktopPanel.Tag = childForm;
            childForm.Size = new Size(999, 600);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_myPage_Click(object sender, EventArgs e)
        {
            // MainMenu로 돌아감
            //activeForm.Close();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text != this.Text)
                {
                    //form.WindowState = FormWindowState.Minimized;
                    form.Hide();
                }
            }
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            // Logo
            
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Image = Image.FromFile("D:\\project\\MES_project\\MESlogo.png");

            // -------------------LogIn Form begin---------------
            formLogin = new FormLogin();   //로그인폼 생성
            formLogin.loginEventHandler += new LoginEventHandler(LoginSuccess);
            switch (formLogin.ShowDialog())
            {
                case DialogResult.OK:       //로그인 성공->로그인 창 닫고 메인메뉴 실행
                    formLogin.Close();
                    break;
                case DialogResult.Cancel:   //로그인 취소-> 전체 창 닫기
                    Dispose();
                    break;
            }
            // -------------------LogIn Form end---------------

            //--------------UART Transport begin---------------
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 115200;
            //serialPort1.BaudRate = 57600;

            serialPort1.Open();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //--------------UART Transport end-----------------


            timer1.Start();

            
            rfid_chulFlag = true;
            rfid_wareFlag = true;
            //rfid_userSignin = false;
        }
        private void LoginSuccess(string id, string pw)
        {
            
        }
        
        private void toggle_warehouse_CheckedChanged(object sender, EventArgs e)
        {
            // 입출고 토글
            if (toggle_warehouse.Checked == true)
            {
                label_objectInOut.Text = "출고";
                rfid_wareFlag = false;
            }

            else
            {
                label_objectInOut.Text = "입고";
                rfid_wareFlag = true;
            }
        }

        private void timerStaffAttand_Tick(object sender, EventArgs e)
        {
            nowTimeHHmmss = DateTime.Now.ToString("HH:mm:ss");
            bool weekend = false;
            if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
                weekend = true;            
            else
                weekend = false;
            //토요일, 일요일엔 결근 상태 갱신하지 않음
            //결근상태 갱신 시간
            if (!weekend && (nowTimeHHmmss == "09:38:00"))    
            {
                today = DateTime.Now;
                todayString = DateTime.Now.ToString("yyyy-MM-dd");
                sql = "SELECT u_RFIDid, u_inTime, u_outTime FROM UserTbl;";
                cmd.CommandText = sql;  
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["u_inTime"].ToString()))
                    {
                        u_inTime = " ";
                    }
                    else if (string.IsNullOrEmpty(reader["u_outTime"].ToString()))
                    {
                        u_outTime = " ";
                    }
                    else
                    {
                        u_RFIDid = reader["u_RFIDid"].ToString();
                        u_inTime = reader["u_inTime"].ToString();
                        u_outTime = reader["u_outTime"].ToString();
                    }

                    if (u_inTime == null)
                    {
                        checkinToday = false;
                    }
                    else if (u_outTime == null)
                    {
                        checkoutToday = false;
                    }
                    else 
                    {
                    checkinToday = u_inTime.Contains(todayString);    //출근 날짜 오늘?
                    checkoutToday = u_outTime.Contains(todayString);  //퇴근 날짜 오늘?
                    }
                    

                    if (!checkinToday || !checkoutToday)
                    {
                        Array.Resize(ref absentAry, absentAry.Length + 1);
                        absentAry[absentAry.Length - 1] = u_RFIDid;
                    }

                }
                reader.Close();

                if (absentAry.Length != 0)
                {
                    for (int i = 0; i < absentAry.Length - 1; i++)
                    {
                        sql = "UPDATE userTbl SET u_absent = u_absent + 1 WHERE u_RFIDid = '";
                        sql += absentAry[i] + "';";
                        cmd.CommandText = sql;  // 짐을 트럭에 싣기
                        cmd.ExecuteNonQuery();
                    }

                }
                
                //absentUpdateFlag = true;
                
            }
        }
        
        private void btn_mainMenu1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormOperationStatus(this.timer1), sender);
        }

        private void btn_mainMenu2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormEquipStatus(this.serialPort1, this.timer1), sender);
        }

        private void btn_mainMenu3_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_mainMenu4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormEntireObject(this.serialPort1), sender);
        }

        private void btn_mainMenu5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormWarehouseObj(), sender);
        }

        private void btn_mainMenu6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReleaseObj(), sender);
        }

        private void btn_mainMenu7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormStaff(), sender);
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            FormSignin formSignin = new FormSignin(serialPort1);
            formSignin.ShowDialog();
        }

        private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            serialPort1.Close();
            conn.Close();
        }

        private void toggle_chul_CheckedChanged(object sender, EventArgs e)
        {

            // 출퇴근 토글
            if (toggle_chul.Checked == true) 
            {
                label_StaffinOut.Text = "퇴근";
                rfid_chulFlag = false;
            }

            else 
            { 
                label_StaffinOut.Text = "출근";
                rfid_chulFlag = true;
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIn = serialPort1.ReadLine();        // \n를 만날때까지 읽어 들인다.

            this.Invoke(new EventHandler(showdata));
        }

        private bool staffRFIDcheck()
        {
            sql = "SELECT EXISTS (SELECT u_RFIDid FROM UserTbl where u_RFIDid = '";
            sql += staff_rfid_tag + "') as success;"; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader();
            long success = 0;
            while (reader.Read())
            {
                success = (long)reader["success"];
            }
            reader.Close();
            if (success == 1)
                return true;
            else
                return false;
        }
        private bool objectRFIDcheck()
        {
            sql = "SELECT EXISTS (SELECT o_RFIDid FROM ObjectTbl where o_RFIDid = '";
            sql += object_rfid_tag + "') as success;"; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader();
            long success = 0;
            while (reader.Read())
            {
                success = (long)reader["success"];
            }
            reader.Close();
            if (success == 1)
                return true;
            else
                return false;
        }
        private void RFIDTimeInsert()
        {
            todayString = DateTime.Now.ToString("yyyy-MM-dd");
            string todayDate = todayString.ToString();
            
            nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            string dInTimeHHmmss = "10:30:00";
            string dOutTimeHHmmss = "18:00:00";
            DateTime dInTime = DateTime.Parse(todayDate +" "+ dInTimeHHmmss);      //designated 출근시각
            DateTime dOutTime = DateTime.Parse(todayDate +" "+ dOutTimeHHmmss);    //designated 퇴근시각

            sql = "SELECT u_inTime, u_outTime FROM UserTbl WHERE u_RFIDid = '";
            sql+= staff_rfid_tag+"';";
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // 출근
                if (string.IsNullOrEmpty(reader["u_inTime"].ToString()))
                {
                    u_inTime = " ";
                }
                else
                {
                    u_inTime = reader["u_inTime"].ToString();
                }

                // 퇴근
                if (string.IsNullOrEmpty(reader["u_outTime"].ToString()))
                {
                    u_outTime = " ";
                }
                else
                {
                    u_outTime = reader["u_outTime"].ToString();
                }
            }
            reader.Close();
            
            checkinToday = u_inTime.Contains(todayString);    //출근 날짜 오늘?
            checkoutToday = u_outTime.Contains(todayString);  //퇴근 날짜 오늘?

            if (rfid_chulFlag == true)
            {   //출근 찍을 수 있는 상태
                if (u_inTime == "" || !checkinToday)
                {
                    if (DateTime.Compare(DateTime.Parse(nowTime), dInTime) <= 0) //DB에 기록되는 시간과 동일한 시간과 비교. 여기서 Now쓰면 XXX
                    {
                        // 출근시각 09:00 보다 빠르거나 같으면
                        sql = "UPDATE userTbl SET u_inTime = '";
                        sql += nowTime + "' WHERE u_RFIDid = '" + staff_rfid_tag + "';";
                        cmd.CommandText = sql;  
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("출근 처리 되었습니다");
                    }
                    else
                    {
                        // 출근시각 09:00 보다 늦으면
                        sql = "UPDATE userTbl SET u_inTime = '";
                        sql += nowTime + "', u_jigak = u_jigak + 1 WHERE u_RFIDid = '" + staff_rfid_tag + "';";
                        cmd.CommandText = sql;  
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("출근 처리 되었습니다\n(지각처리)");
                    }

                }
                //이미 출근: 출근 날짜가 오늘일 때
                else
                {
                    MessageBox.Show("이미 출근 처리 되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else   
            {   //퇴근 찍을 수 있는 상태
                if(checkinToday&&(u_outTime == "" || !checkoutToday))
                {
                    if(DateTime.Compare(DateTime.Parse(nowTime),dOutTime) < 0)
                    {
                        // 퇴근시각 18:00 보다 빠르거나 같으면
                        sql = "UPDATE userTbl SET u_outTime = '";
                        sql += nowTime + "', u_jogi = u_jogi + 1 WHERE u_RFIDid = '" + staff_rfid_tag + "';";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("퇴근 처리 되었습니다\n(조퇴 처리)");
                    }
                    else
                    {
                        // 퇴근시각 18:00 보다 늦으면
                        sql = "UPDATE userTbl SET u_outTime = '";
                        sql += nowTime + "' WHERE u_RFIDid = '" + staff_rfid_tag + "';";
                        cmd.CommandText = sql;  // 짐을 트럭에 싣기
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("퇴근 처리 되었습니다");
                    }
                }
                else if (!checkinToday)
                {
                    MessageBox.Show("금일 출근 처리 되지 않았습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("이미 퇴근 처리 되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void RFIDObjectInsert()
        {
            todayString = DateTime.Now.ToString("yyyy-MM-dd");
            string todayDate = todayString.ToString();

            nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            sql = "SELECT w_time, r_time FROM ObjectTbl WHERE o_RFIDid = '";
            sql += object_rfid_tag + "';";
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // 입고
                if (string.IsNullOrEmpty(reader["w_time"].ToString()))
                {
                    w_time = "";
                }
                else
                {
                    w_time = reader["w_time"].ToString();
                }

                // 출고
                if (string.IsNullOrEmpty(reader["r_time"].ToString()))
                {
                    r_time = "";
                }
                else
                {
                    r_time = reader["r_time"].ToString();
                }
            }
            reader.Close();

            if(!rfid_objSignin)
            {
                if (rfid_wareFlag == true)
                {   //입고 찍을 수 있는 상태
                    if (w_time == "")   //입고 기록 없을 때
                    {
                        sql = "UPDATE ObjectTbl SET w_time = '";
                        sql += nowTime + "' WHERE o_RFIDid = '" + object_rfid_tag + "';";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("입고 처리 되었습니다");

                    }
                    //이미 입고 기록 있을 때
                    else
                    {
                        MessageBox.Show("이미 입고 처리 되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {   //출고 찍을 수 있는 상태
                    if (r_time == "" && w_time != "")
                    {
                        sql = "UPDATE ObjectTbl SET r_time = '";
                        sql += nowTime + "' WHERE o_RFIDid = '" + object_rfid_tag + "';";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("출고 처리 되었습니다");

                    }
                    else if (r_time == "" && w_time == "")
                    {
                        MessageBox.Show("입고 처리되지 않은 항목입니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("이미 출고 처리 되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void showdata(object s, EventArgs e)
        {
            //----------------근태관리...RFID 1 begin-------------------//
            // 1)uart데이터 받아옴...rfid1b0 fb 27 32 5e 
            // 2)데이터의 rfid만 따로 떼기
            string[] tmp1= { }; string[] tmp2 = { };
            if (dataIn.Contains("rfid1") == true)
            {
                //MessageBox.Show("rfid1 확인");
                tmp1 = dataIn.Split('/');
                tmp2 = tmp1[1].Split(' ');
                staff_rfid_tag = tmp2[0]+" " + tmp2[1] + " " + tmp2[2] + " " + tmp2[3] + " " + tmp2[4];
                //MessageBox.Show("rfid_tag : "+staff_rfid_tag +"!!!");
                // 3)rfid db에 있는지 확인 -> 출근시각 오늘인지 확인
                // 4)보드에 'valid'/'invalid'전송
                // 5)rfid db로 보내서 현재시각 저장하기
                bool rfidCheck = staffRFIDcheck();       //RFID가 DB에 있는지 확인
                
                if (!rfid_userSignin)
                {
                    if (!rfidCheck)
                    {
                        serialPort1.WriteLine("invalid1" + Environment.NewLine);
                        MessageBox.Show("유효하지 않은 카드입니다");
                    }
                    else
                    {
                        serialPort1.WriteLine("valid1" + Environment.NewLine);
                        RFIDTimeInsert();
                    }
                }
                
            }
            if (dataIn.Contains("user") == true && rfid_chulFlag == false)
            {
                rfid_chulFlag = true;
                toggle_chul.CheckState = CheckState.Unchecked;

            }
            else if(dataIn.Contains("user") == true && rfid_chulFlag == true)
            {
                rfid_chulFlag = false;
                toggle_chul.CheckState = CheckState.Checked;
            }

            //-----------------근태관리...RFID 1 end -----------------//

            //------------품목입출고관리...RFID 2 begin---------------//
            string[] tmp3 = { }; string[] tmp4 = { };
            if (!rfid_objSignin)
            {
                if (dataIn.Contains("rfid2") == true)
                {
                    //MessageBox.Show("rfid2 확인");
                    tmp3 = dataIn.Split('/');
                    tmp4 = tmp3[1].Split(' ');
                    object_rfid_tag = tmp4[0] + " " + tmp4[1] + " " + tmp4[2] + " " + tmp4[3] + " " + tmp4[4];
                    
                    // 3)rfid db에 있는지 확인 -> 출근시각 오늘인지 확인
                    // 4)보드에 'valid'/'invalid'전송
                    // 5)rfid db로 보내서 현재시각 저장하기
                    bool rfidCheck = objectRFIDcheck();       //RFID가 DB에 있는지 확인
                    if (!rfidCheck)
                    {
                        serialPort1.WriteLine("invalid2" + Environment.NewLine);
                        MessageBox.Show("유효하지 않은 품목입니다");
                    }
                    else
                    {
                        serialPort1.WriteLine("valid2" + Environment.NewLine);
                        RFIDObjectInsert();
                    }

                }
            }
               
            if (dataIn.Contains("object") == true && rfid_wareFlag == false)
            {
                rfid_wareFlag = true;
                toggle_warehouse.CheckState = CheckState.Unchecked;

            }
            else if (dataIn.Contains("object") == true && rfid_wareFlag == true)
            {
                rfid_wareFlag = false;
                toggle_warehouse.CheckState = CheckState.Checked;
            }
            //------------품목입출고관리...RFID 2 begin---------------//

            // ------------ 현재 온도 저장 ------------ //
            if (dataIn.Contains("cur_room1") == true)   // Room1 현재 온도
            {
                inputSensorData = dataIn.Split(' ');
                ct1 = inputSensorData[1].ToString();
            }
            if (dataIn.Contains("cur_room2") == true)   // Room2 현재 온도
            {
                inputSensorData = dataIn.Split(' ');
                ct2 = inputSensorData[1].ToString();
            }
            if (dataIn.Contains("cur_room3") == true)   // Room3 현재 온도
            {
                inputSensorData = dataIn.Split(' ');
                ct3 = inputSensorData[1].ToString();
            }
            // ------------ 희망 온도 저장 ------------ //
            if (dataIn.Contains("dsr_room1") == true)   // Room1 희망 온도
            {
                inputSensorData = dataIn.Split(' ');
                dt1 = inputSensorData[1].ToString();
            }
            if (dataIn.Contains("dsr_room2") == true)   // Room2 희망 온도
            {
                inputSensorData = dataIn.Split(' ');
                dt2 = inputSensorData[1].ToString();
            }
            if (dataIn.Contains("dsr_room3") == true)   // Room3 희망 온도
            {
                inputSensorData = dataIn.Split(' ');
                dt3 = inputSensorData[1].ToString();
            }
            // ------------ 기기 상태 저장 ------------ //
            if (dataIn.Contains("equip_room1") == true)   // Room1 기기 상태
            {
                e_num1 = "1";
                inputSensorData = dataIn.Split(' ');
                if (e_status1[0] == null)
                {
                    e_status1[0] = inputSensorData[1].ToString();
                }
                else
                {
                    e_status1[1] = e_status1[0];
                    e_status1[0] = inputSensorData[1].ToString();
                }
            }
            if (dataIn.Contains("equip_room2") == true)   // Room2 기기 상태
            {
                e_num2 = "2";
                inputSensorData = dataIn.Split(' ');
                if (e_status2[0] == null)
                {
                    e_status2[0] = inputSensorData[1].ToString();
                }
                else
                {
                    e_status2[1] = e_status2[0];
                    e_status2[0] = inputSensorData[1].ToString();
                }
            }
            if (dataIn.Contains("equip_room3") == true)   // Room3 기기 상태
            {
                e_num3 = "3";
                inputSensorData = dataIn.Split(' ');
                if (e_status3[0] == null)
                {
                    e_status3[0] = inputSensorData[1].ToString();
                }
                else
                {
                    e_status3[1] = e_status3[0];
                    e_status3[0] = inputSensorData[1].ToString();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //-------------- DB EquipTempTbl save -----------------
            int chkint = 0;
            if (ct1 != null && ct2 != null && ct3 != null && dt1 != null && dt2 != null && dt3 != null && int.TryParse(ct1, out chkint) && int.TryParse(ct2, out chkint) && int.TryParse(ct3, out chkint))
            {
                // INSERT INTO EquipTempTbl (et_time, ct1, dt1, ct2, dt2, ct3, dt3) VALUES ('YYMMDDHHMMSS', 1, 1, 2, 2, 3, 3);
                nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "INSERT INTO EquipTempTbl (et_time, ct1, dt1, ct2, dt2, ct3, dt3) VALUES ('";
                sql += nowTime + "', " + ct1 + ", " + dt1 + ", " + ct2 + ", " + dt2 + ", " + ct3 + ", " + dt3 + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            //-------------- DB EquipmentTbl save -----------------
            // equipment 상태가 변하면 DB에 저장
            if ((e_status1[0] != e_status1[1] || (e_status1[1] == null && e_status1[0] != null)) && int.TryParse(e_status1[0], out chkint))     // 1호기
            {
                // INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (1, 'YYMMDDHHMMSS', 0);
                string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (";
                sql += e_num1 + ", '" + nowTime + "', " + e_status1[0] + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                status_time = nowTime;
                status = e_status1[0];
            }
            if ((e_status2[0] != e_status2[1] || (e_status2[1] == null && e_status2[0] != null)) && int.TryParse(e_status2[0], out chkint))   // 2호기
            {
                
                // INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (1, 'YYMMDDHHMMSS', 0);
                string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (";
                sql += e_num2 + ", '" + nowTime + "', " + e_status2[0] + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                status_time = nowTime;
                status = e_status2[0];
            }
            if ((e_status3[0] != e_status3[1] || (e_status3[1] == null && e_status3[0] != null)) && int.TryParse(e_status3[0], out chkint))   // 3호기
            {
                
                // INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (1, 'YYMMDDHHMMSS', 0);
                string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "INSERT INTO EquipmentTbl (e_num, e_time, e_status) VALUES (";
                sql += e_num3 + ", '" + nowTime + "', " + e_status3[0] + ");";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                status_time = nowTime;
                status = e_status3[0];
            }

            // UartCheck
            if (serialPort1.IsOpen)
            {
                pictureBox1.Image = Image.FromFile("D:\\project\\MES_project\\uartOn.png");

            }
            else
                pictureBox1.Image = Image.FromFile("D:\\project\\MES_project\\uartOff.png");
        }

        
        
    }
}