using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project_Yoonsik
{
    public enum TableStatus
    {
        Empty,
        Used
    }

    public class Table
    {
        public int TableId { get; set; }
        public Button TableButton { get; set; }
        public Order CurrentOrder { get; set; }
        public TableStatus Status { get; set; }
    }
}
