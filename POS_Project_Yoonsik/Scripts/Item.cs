using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Project_Yoonsik
{
    public class Item
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PriceDetail { get => $"가격 {Price} 만원"; }
        public int Quantity { get; set; }
    }
}
