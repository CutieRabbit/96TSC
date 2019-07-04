using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int verification(string str)
        {
            bool[] vec = new bool[6];
            vec[0] = str.Length >= 3;
            vec[1] = !str[0].Equals('K');
            vec[2] = true;
            vec[4] = true;
            vec[5] = true;
            int cnt = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'L') vec[2] = false;
                if (str[i] == 'K') vec[4] = false;
            }
            for(int i = 0; i < str.Length && vec[2] == false; i++)
            {
                if (str[i] == 'L') cnt++;
            }
            for (int i = 0; i < str.Length && vec[4] == false; i++)
            {
                if (str[i] == 'K') vec[4] = true;
            }
            vec[2] = vec[2] == true ? true : cnt >= 2;
            vec[3] = str[str.Length - 1] != 'M' && str[str.Length - 2] != 'M';
            if(cnt == 0)
            {
                vec[5] = !(str[str.Length - 1] == 'O');
            }
            for(int i = 0; i < 6; i++)
            {
                if (vec[i] == false) return i + 1;
            }
            return -1;
        }

        private string fix(string str)
        {
            char[] array = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (i != str.Length - 1)
                {
                    array[i] = 'O';
                }
                else
                {
                    array[i] = 'N';
                }
            }
            string result = "";
            for(int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if(verification(str) == -1)
            {
                textBox2.Text = str + "是正確密碼文字";
            }
            else
            {
                textBox2.Text = str + "不是正確密碼文字";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            textBox4.Text = "本輸入密碼無法滿足第" + verification(str) + "條件";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str1 = textBox5.Text;
            string str2 = textBox7.Text;
            textBox6.Text = fix(str1);
            textBox8.Text = fix(str2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] str = new string[4] { "LLL", "MMM", "NNN", "OOO" };
            int a = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (verification(str[i]) == -1) a++;
            }
            textBox9.Text = "4";
            textBox10.Text = a.ToString();
        }
    }
}
