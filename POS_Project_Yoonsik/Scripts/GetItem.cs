using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Project_Yoonsik
{
    public class GetItemDes
    {
        public string GetNameById(int productId)
        {
            switch (productId)
            {
                case 0: return "아메리카노";
                case 1: return "피자빵";
                case 2: return "소금빵";
                case 3: return "카페라떼";
                case 4: return "프레첼";
                case 5: return "브런치 세트";
                default: return "알 수 없음";
            }
        }

        public int GetPriceById(int productId)
        {
            switch (productId)
            {
                case 0:
                case 1:
                    return 1;

                case 2:
                case 3:
                    return 2;

                case 4:
                    return 3;

                case 5:
                    return 4;

                default:
                    return 0;
            }
        }
    }
}
