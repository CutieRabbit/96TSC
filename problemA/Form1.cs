using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public string converter(string str)
        {
            string result = "";
            for(int i = 0; i < 20; i++)
            {
                result += Convert.ToString(Convert.ToInt16(str.Substring(4 * i, 4),2),16);
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string result1 = "";
            string result2 = "";
            string result3 = "";
            string result4 = "";
            string data1 = textBox1.Text;
            string data2 = textBox2.Text;
            string data3 = comboBox1.Text;
            string data4 = comboBox2.Text;
            string data5 = textBox3.Text;
            result1 = Convert.ToString(Convert.ToInt64(data1.Substring(2)),2).PadLeft(27,'0');
            result1 = (data1[1].Equals('1') ? '0' : '1') + result1;
            result1 = Convert.ToString(0 + (data1[0] - 'A'), 2).PadLeft(5,'0')+ result1;
            result1.PadLeft(32, '0');

            string year = Convert.ToString(Convert.ToInt16(data2.Substring(0, 4)) - 1900, 2).PadLeft(7,'0');
            string month = Convert.ToString(Convert.ToInt16(data2.Substring(4, 2)),2).PadLeft(4,'0');
            string day = Convert.ToString(Convert.ToInt16(data2.Substring(6, 2)), 2).PadLeft(5, '0');
            result2 = year + month + day;
            result2 = comboBox1.Items.IndexOf(data3) + result2;

            result3 = Convert.ToString(comboBox2.Items.IndexOf(data4),2).PadLeft(3,'0');
            result4 = Convert.ToString(Convert.ToInt32(data5.Substring(2)),2).PadLeft(27,'0');

            string result = result4 + " " + result3 + " " + result2 + " " + result1;

            Console.WriteLine(result);

            textBox4.Text = converter(result.Replace(" ","")).ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = textBox4.Text;
            string str = "";
            for(int i = 0; i < data.Length; i++)
            {
                str += Convert.ToString(Convert.ToInt16(data[i].ToString(),16),2).PadLeft(4,'0');
            }
            Console.WriteLine(str);
            string phoneNumber = "09" + Convert.ToInt32(str.Substring(0, 27),2);
            string study = comboBox2.Items[Convert.ToInt32(str.Substring(27, 3), 2)].ToString();
            string married = comboBox1.Items[Convert.ToInt32(str[30].ToString(), 2)].ToString();
            string year = (Convert.ToInt32(str.Substring(31, 7), 2) + 1900).ToString();
            string month = Convert.ToInt32(str.Substring(38, 4), 2).ToString().PadLeft(2,'0');
            string day = Convert.ToInt32(str.Substring(42, 5), 2).ToString().PadLeft(2, '0');
            string word = "" + ((char)(Convert.ToInt32(str.Substring(47, 5), 2) + 'A')).ToString();
            string number1 = (Convert.ToInt32(str.Substring(52, 1), 2)+1).ToString();
            string number2 = (Convert.ToInt32(str.Substring(53),2)).ToString();
            textBox1.Text = word + number1 + number2;
            textBox2.Text = year + month + day;
            comboBox2.Text = study;
            textBox3.Text = phoneNumber;
            comboBox1.Text = married;
        }
    }
}
