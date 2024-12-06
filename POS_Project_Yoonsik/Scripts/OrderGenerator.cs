using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace POS_Project_Yoonsik.Scripts
{
    public static class OrderGenerator
    {
        private static Random _random = new Random();

        public static Order GenerateRandomOrder()
        {
            var orderId = Guid.NewGuid().ToString(); // 고유 주문 ID
            var timestamp = DateTime.Now;

            int itemCount = _random.Next(1, 4); // 1~3개의 상품 생성
            var items = new List<Item>();
            int total = 0;

            for (int i = 0; i < itemCount; i++)
            {
                var item = new Item
                {
                    ProductId = _random.Next(1, 6),
                    Quantity = _random.Next(1, 5) // 1~4개
                };
                total += item.Price * item.Quantity;
                items.Add(item);
            }

            return new Order
            {
                OrderId = orderId,
                Timestamp = timestamp,
                Items = items,
                Total = total
            };
        }
    }
}
