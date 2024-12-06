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
        public string Name { get => GetName();}
        public int Price { get => GetPrice(); }
        
        public string PriceDetail { get => $"가격 {Price} 만원"; }
        public int Quantity { get; set; }

        #region ID 통한 가격 및, 이름 설정 함수
        private int GetPrice()
        {
            int i = 0;
            switch (ProductId)
            {
                case 0:
                    i = 1;
                    break;
                case 1:
                    i = 1;
                    break;
                case 2:
                    i = 2;
                    break;
                case 3:
                    i = 2;
                    break;
                case 4:
                    i = 3;
                    break;
                case 5:
                    i = 4;
                    break;
                default:
                    i = 0;
                    break;
            }
            return i;
        }

        private string GetName()
        {
            string s = "";
            switch(ProductId)
            {
                case 0:
                    s = "아메리카노";
                    break;
                case 1:
                    s = "피자빵";
                    break;
                case 2:
                    s = "소금빵";
                    break;
                case 3:
                    s = "카페라떼";
                    break;
                case 4:
                    s = "프레첼";
                    break;
                case 5:
                    s = "브런치 세트";
                    break;
                default:
                    break;
            }
            return s;

        }
        #endregion
    }

    public class Order
    {
        public string OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Item> Items { get; set; }
        public int Total { get; set; }
    }
}
