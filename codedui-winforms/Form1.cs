using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codedui_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var n = int.Parse(textBox1.Text);
            if (n >= 0)
            {
                label1.Text = Fib(n).ToString();
            }
            else
            {
                label1.Text = "Invalid input.";
            }
        }

        private int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
