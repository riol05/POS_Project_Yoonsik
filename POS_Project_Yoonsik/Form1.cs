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
        System.Random random = new Random();
        public POSProgram()
        {
            InitializeComponent();
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
                button.Enabled = false;
                button.Click += SharedButtonClickHandler;
            }
        }

        // POS TableButton 이벤트 메서드
        private void SharedButtonClickHandler(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MessageBox.Show($"{clickedButton.Text} 버튼이 클릭되었습니다!");
            }
        }

        
        private void OrderTimer_Tick(object sender, EventArgs e)
        {
            int orderCount = random.Next(1, 4); // 1~3개의 주문 생성
            for (int i = 0; i < orderCount; i++)
            {
                var order = OrderGenerator.GenerateRandomOrder();
                string jsonOrder = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented);

                // ListBox에 주문 추가
                //listBoxOrders.Items.Add(jsonOrder);
                //listBoxOrders.Items.Add("--------------------");
            }
        }

        // POS 종료 버튼 이벤트 메서드
        private void EndButton_Click(object sender, EventArgs e) => Application.Exit();
    }
}
