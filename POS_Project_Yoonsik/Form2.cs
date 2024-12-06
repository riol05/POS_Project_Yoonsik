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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "주문 내역입니다.";
            label2.Text = "접수중 주문";
            label3.Text = "처리중 주문";
            label4.Text = "완료된 주문";
            listBox1.Text = " ";
            listBox2.Text = " ";
            listBox3.Text = " ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
