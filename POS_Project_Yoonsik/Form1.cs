using POS_Project_Yoonsik.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace POS_Project_Yoonsik
{
    public partial class POSProgram : Form
    {
        private System.Random random;
        private Timer orderTimer;
        public POSProgram()
        {
            InitializeComponent();
            // listbox를 정리
            listBoxOrders.Items.Clear();

            #region 1분 주기 주문
            random = new Random();
            orderTimer = new Timer();
            orderTimer.Interval = 60000; // 1분 (60000 밀리초)
            orderTimer.Tick += OrderTimer_Tick;
            #endregion

            #region 버튼 이벤트 메서드 설정 및, buttonList를 통한 모듈화?<- 무슨 뜻이었더라
            List<Button> buttonList = new List<Button> {
                table_Button1,
                table_Button2,
                table_Button3,
                table_Button4,
                table_Button5,
                table_Button6,
                table_Button7,
                table_Button8,
                table_Button9
                };

            foreach(var button in buttonList)
            {
                button.Click += SharedButtonClickHandler;
                button.Enabled = false;
            }
            #endregion
        }

        // POS TableButton 이벤트 메서드
        private void SharedButtonClickHandler(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Enabled)
            {
                MessageBox.Show($"{clickedButton.Text} 버튼이 클릭되었습니다!");
            }
        }

        
        // 1분 주기로 들어오는 주문 메서드
        private void OrderTimer_Tick(object sender, EventArgs e)
        {
            int orderCount = random.Next(1, 4); // 1~3개의 주문 생성
            for (int i = 0; i < orderCount; i++)
            {
                var order = OrderGenerator.GenerateRandomOrder();
                string jsonOrder = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented);

                // ListBox에 주문 추가
                listBoxOrders.Items.Add(jsonOrder);
                listBoxOrders.Items.Add("--------------------");
            }
        }

        // POS 종료 버튼 이벤트 메서드
        private void EndButton_Click(object sender, EventArgs e) => Application.Exit();

        // listBox 정렬 메서드
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
