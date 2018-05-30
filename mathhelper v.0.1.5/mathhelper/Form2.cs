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

        private double FirstFrm(int n, int i, double res) //вычисления по первой формуле
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

            return res;
        }

        private double SecondFrm(int n, int i, double res) //вычисления по вторрой формуле
        {
            res += Math.Pow(i, i);
            return res;
        }

        private double ThirdFrm(int n, int i, double res) //вычисления по третьей формуле
        {
            res += 1 / i;
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
            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(FirstFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(SecondFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(ThirdFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;
            }
            else
            {
                //round округляет только для 15 знаков!
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(FirstFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;

                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(SecondFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;

                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(ThirdFrm(n, i, res), rnd);
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(res));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(res));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0;
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

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить результаты...";
            //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.OverwritePrompt = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            savedialog.CheckPathExists = true;
            //список форматов файла, отображаемый в поле "Тип файла"
            savedialog.Filter = "Text Files(*.txt)|*.txt|Adobe Acrobat Files(*.pdf)|*.pdf|All files (*.*)|*.*";
            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    //pict.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить результаты вычислений", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void журналПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journal jrnl = new journal();
            jrnl.Show();
        }
    }
}
