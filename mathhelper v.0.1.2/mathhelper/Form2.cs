using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathhelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private double FirstFrm(int n, double res) //вычисления по первой формуле
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    res -= Math.Sqrt(i);
                }
                else if (i == n)
                {
                    res += Math.Sqrt(i);
                }
                else res += i;
            }
            return res;
        }

        private double SecondFrm(int n, double res) //вычисления по вторрой формуле
        {
            for (int i = 1; i <= n; i++)
            {
                res += Math.Pow(i, i);
            }
            return res;
        }

        private double ThirdFrm(int n, double res) //вычисления по третьей формуле
        {
            for (int i = 1; i <= n; i++)
            {
                res += 1 / i;
            }
            return res;
        }

        private void button1_Click(object sender, EventArgs e) //кнопка "вычислить"
        {
            richTextBox1.Clear();
            double res = 0;
            int n;
            int rnd;
            
            n = Convert.ToInt32(textBox1.Text);
            rnd = Convert.ToInt32(textBox2.Text);
            if (comboBox1.SelectedIndex == 1) res = FirstFrm(n, res);
            else if (comboBox1.SelectedIndex == 2) res = SecondFrm(n, res);
            else if (comboBox1.SelectedIndex == 3) res = ThirdFrm(n, res);
            else
            {
                //round округляет только для 15 знаков!
                res = Math.Round(FirstFrm(n, res), rnd);
                richTextBox1.AppendText(Convert.ToString(res) + Environment.NewLine);
                res = Math.Round(SecondFrm(n, res), rnd);
                richTextBox1.AppendText(Convert.ToString(res) + Environment.NewLine);
                res = Math.Round(ThirdFrm(n, res), rnd);
                richTextBox1.AppendText(Convert.ToString(res) + Environment.NewLine);
            }
        }

       

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e) //вызов справки по проекту
        {
            Help help = new Help();
            help.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //контроль ввода данных для n
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) //контроль ввода данных для числа округления
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
