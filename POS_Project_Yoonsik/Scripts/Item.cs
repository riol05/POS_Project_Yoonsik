using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Project_Yoonsik
{
    public class Item
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        
        public string OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Item> Items { get; set; }
        public double Total { get; set; }
    }
}
