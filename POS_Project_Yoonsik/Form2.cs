using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project_Yoonsik
{
    public partial class TableDetail : Form
    {
        private Table table;
        public TableDetail(Table table)
        {
            InitializeComponent();
            this.table = table; // 전달받은 테이블 정보 저장
            LoadTableDetails();

            if(table.CurrentOrder.Status == OrderStatus.Waiting)
                Completed.Enabled = false;
            else
                 makingCoffee.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedOrder = listBox1.SelectedItem.ToString();
                MessageBox.Show($"선택된 주문 : {selectedOrder}");
            }
        }

        private void LoadTableDetails()
        {
            if (table != null)
            {
                // 테이블 정보를 화면에 표시
                label1.Text = $"테이블 번호: {table.TableId} 번 테이블";
                label2.Text = $"테이블 상태: {table.CurrentOrder.Status} 입니다.";
                label3.Text = $"총 주문 금액: {table.CurrentOrder?.Total ?? 0}원";

                // 주문 항목 목록 표시 (예: ListBox에 추가)
                if (table.CurrentOrder?.Items != null)
                {
                    foreach (var item in table.CurrentOrder.Items)
                    {
                        listBox1.Items.Add($"상품 : {item.Name}, 수량: {item.Quantity}, 가격: {item.Price}");
                    }
                }
                makingCoffee.Enabled = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }

        private void makingCoffee_Click(object sender, EventArgs e)
        {
            table.CurrentOrder.Status = OrderStatus.InProgress;
            POSProgram.Instance.UpdateOrderStatus(table, OrderStatus.InProgress);
            MessageBox.Show("제조가 완료되었습니다.");
            this.Close();
        }

        private void Completed_Click(object sender, EventArgs e)
        {
            table.CurrentOrder.Status = OrderStatus.Completed;
            table.TableButton.Enabled = false;
            POSProgram.Instance.UpdateOrderStatus(table, OrderStatus.Completed);
            MessageBox.Show("주문이 완료되었습니다.");
            this.Close();
        }
    }
}
