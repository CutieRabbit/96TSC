using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool verificater(string str)
        {
            string[] split = str.Split(' ');
            try
            {
                if (split.Length != 6) throw new Exception();
            
                for (int i = 0; i < split.Length; i++)
                {
                    int a = Convert.ToInt16(split[i]);
                    if (a > 100) throw new Exception();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10 30 50 60 80 100";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(verificater(textBox1.Text) == false)
            {
                MessageBox.Show("輸入錯誤，請重新輸入");
                return;
            }
            string[] split = textBox1.Text.Split(' ');
            int[] number = new int[6];
            for(int i = 0; i < number.Length; i++)
            {
                number[i] = Convert.ToInt16(split[i]);
            }
            int aver = 0;
            for(int i = 0; i < number.Length; i++)
            {
                aver += number[i];
            }
            aver /= 6;
            int max = number.Max();
            int min = number.Min();
            double cnt = 0;
            for(int i = 0; i < number.Length; i++)
            {
                cnt += Math.Pow(number[i] - aver, 2);
            }
            cnt /= 6;
            cnt = Math.Sqrt(cnt);
            label2.Text += "平均值 = " + aver + Environment.NewLine;
            label2.Text += "最大值 = " + max + Environment.NewLine;
            label2.Text += "最小值 = " + min + Environment.NewLine;
            label2.Text += "標準差 = " + cnt + Environment.NewLine;
        }
    }
}
