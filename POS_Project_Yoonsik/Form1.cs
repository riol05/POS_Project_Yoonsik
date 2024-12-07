using POS_Project_Yoonsik.Scripts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Button = System.Windows.Forms.Button;

namespace POS_Project_Yoonsik
{
    public partial class POSProgram : Form
    {
        #region 싱글톤 패턴
        private static POSProgram _instance;
        public static POSProgram Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new POSProgram();
                }
                return _instance;
            }
        }
        #endregion

        private System.Random random;
        private Timer orderTimer;
        private Dictionary<int, Button> tableDic = new Dictionary<int, Button>();
        private List<Table> tables = new List<Table>();
        private List<ListBox> listBoxes;
        private Dictionary<string, string> listBoxData = new Dictionary<string, string>();
        private int _highlightIndex = -1;
        private Dictionary<int, int> listBoxItemStatus = new Dictionary<int, int>();
        private static readonly Dictionary<OrderStatus, Brush> StatusBrushes = new Dictionary<OrderStatus, Brush>
        {
            { OrderStatus.Waiting, Brushes.White },
            { OrderStatus.InProgress, Brushes.Yellow },
            { OrderStatus.Completed, Brushes.Green }
        };

        public POSProgram()
        {
            InitializeComponent();
            orderBox.DrawMode = DrawMode.OwnerDrawFixed;
            orderBox.DrawItem += OrderBox_DrawItem;

            #region 타이머 설정
            random = new Random();
            orderTimer = new Timer();
            orderTimer.Interval = 60000; // 1분 (60000 밀리초)
            orderTimer.Tick += OrderTimer_Tick;
            orderTimer.Start();
            #endregion

            #region UI 리스트 초기화 및 이벤트 설정
            List<ListBox> listBoxes = new List<ListBox>
            {
                orderBox,
                totalOrderBox
            };
            for (int j = 0; j < listBoxes.Count; j++)
            {
                listBoxes[j].Click += OrderBoxClick;
            }
            this.listBoxes = listBoxes;

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
            for (int i = 0; i < buttonList.Count; i++)
            {
                tables.Add(new Table
                {
                    TableId = i + 1,
                    TableButton = buttonList[i]
                });

                buttonList[i].Click += SharedButtonClickHandler;
                buttonList[i].Enabled = false;
            }
            #endregion
        }

        // POS TableButton 이벤트 메서드
        private void SharedButtonClickHandler(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                var table = tables.FirstOrDefault(t => t.TableButton == clickedButton);
                if (table != null)
                {
                    var tableDetailsForm = new TableDetail(table);
                    tableDetailsForm.Show(); // 새 폼 열기
                }
            }
        }

        // 1분 주기로 들어오는 주문 메서드
        private void OrderTimer_Tick(object sender, EventArgs e)
        {
            int orderCount = random.Next(1, 4);
            for (int i = 0; i < orderCount; i++)
            {
                var order = OrderGenerator.GenerateRandomOrder();
                string jsonOrder = JsonConvert.SerializeObject(order,
                    Newtonsoft.Json.Formatting.Indented);

                var table = tables.FirstOrDefault(t => t.Status == TableStatus.Empty);
                if (table != null)
                {
                    table.TableButton.Enabled = true;
                    table.Status = TableStatus.Used;
                    table.CurrentOrder = order;
                    AddOrderToListBox(table.TableId, order, jsonOrder);
                }
            }
        }

        // POS 종료 버튼 이벤트 메서드
        private void EndButton_Click(object sender, EventArgs e) => Application.Exit();

        // listBox 이벤트 메서드
        private void OrderBoxClick(object sender, EventArgs e)
        {
            ListBox clickedObject = sender as ListBox;
            if (clickedObject.SelectedItem != null)
            {
                string selectedOrder = clickedObject.SelectedItem.ToString();

                if (listBoxData.TryGetValue(selectedOrder, out string jsonOrder))
                    MessageBox.Show($"선택된 주문 :\n{jsonOrder}");
            }
        }

        // ListBox Item 추가 메서드
        private void AddOrderToListBox(int tableId, Order order, string jsonOrder)
        {
            string displayText = $"{tableId} 번 테이블, {order.Total} 원";

            orderBox.Items.Add(displayText);
            int index = orderBox.Items.Count - 1;
            totalOrderBox.Items.Add($"{order.Timestamp}, {order.Total} 원");

            listBoxItemStatus[tableId] = index;
            listBoxData[displayText] = jsonOrder;
        }



        private void OrderBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = orderBox.Items[e.Index].ToString();
            int tableId = int.Parse(itemText.Split(' ')[0]);

            OrderStatus status = listBoxItemStatus.ContainsKey(tableId)
                ? tables[tableId - 1].CurrentOrder?.Status ?? OrderStatus.Waiting
                : OrderStatus.Waiting;

            Brush backgroundBrush = StatusBrushes.ContainsKey(status)
                ? StatusBrushes[status] : Brushes.Gray;

            if(status == OrderStatus.Completed)
            {
                orderBox.Items.RemoveAt(e.Index);
            }

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds);

            e.DrawFocusRectangle();
        }

        public void UpdateOrderStatus(Table _table, OrderStatus newStatus)
        {
            if (!listBoxItemStatus.ContainsKey(_table.TableId)) return;

            if (newStatus == OrderStatus.Completed)
            {
                var table = tables.FirstOrDefault(t => t.TableId == _table.TableId);
                if (table != null)
                {
                    table.Status = TableStatus.Empty;
                    table.CurrentOrder = null;
                }

                listBoxItemStatus.Remove(_table.TableId);

                _table.Status = TableStatus.Empty;
                _table.CurrentOrder = null;
            }

            orderBox.Refresh();
        }
    }
}
