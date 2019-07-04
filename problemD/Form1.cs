using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double formula(int n,double second)
        {
            double val = 0;
            for(double k = 1; k <= n; k+=2)
            {
                val += 2 / (k * Math.PI) * Math.Cos(k * Math.PI * second + ((Math.Pow(-1, (k - 1) / 2)) - 1) * (Math.PI / 2));
            }
            return val + 1 / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            int n = Convert.ToInt16(textBox1.Text);
            double m = Convert.ToDouble(textBox2.Text);
            chart1.ChartAreas[0].AxisX.Maximum = 3.0;
            chart1.ChartAreas[0].AxisX.Minimum = -3.0;
            chart1.ChartAreas[0].AxisY.Minimum = -1.5;
            chart1.ChartAreas[0].AxisY.Maximum = 1.5;
            for (double i = -3; i <= 3; i+=1*m)
            {
                chart1.Series[0].Points.AddXY(i,formula(n, i));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].Points.Clear();
        }
    }
}
