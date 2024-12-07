using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Project_Yoonsik
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Item> Items { get; set; }
        public int Total => Items.Sum(item => item.Price * item.Quantity);

        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Waiting,    // 접수 대기 중
        InProgress, // 진행 중
        Completed  // 완료
    }
}
