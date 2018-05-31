using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GemBox.Document;
using System.Windows.Forms;

namespace mathhelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            comboBox1.SelectedIndex = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            // Если программу свернули, то убрать ее из панели задач и показать в трее иконку
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
            base.OnResize(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Форму закрывает пользователь по клику на крестик, комбинацией Alt+F4 или по клику "закрыть" контекстного меню.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Отменить закрытие формы
                e.Cancel = true;

                // Вместо закрытия — свернуть
                WindowState = FormWindowState.Minimized;
            }
            base.OnFormClosing(e);
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
            res = 1 / i;
            return res;
        }

        private void button1_Click(object sender, EventArgs e) //кнопка "вычислить"
        {
            richTextBox1.Clear();
            double res = 0;
            double S = 0;
            string str = "";
            int n;
            int rnd; //round округляет только для 15 знаков!

            n = Convert.ToInt32(textBox1.Text);
            rnd = Convert.ToInt32(textBox2.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(FirstFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = S = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(SecondFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = S = 0;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(ThirdFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = 0; S = 0;

               
            }

            var document = new DocumentModel();

            if (MessageBox.Show("Сохранить результаты вычислений?", "MathHelper",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        == DialogResult.Yes)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"", false, System.Text.Encoding.Default);
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
                        switch (savedialog.FilterIndex)
                        {
                            case 1:
                                richTextBox1.SaveFile(savedialog.FileName, RichTextBoxStreamType.PlainText); break;
                            case 2:
                                {
                                    // Add document content.
                                    document.Sections.Add(new Section(document, new Paragraph(document, richTextBox1.Text)));
                                    // Save the generated document as PDF file.
                                    str = savedialog.FileName;                    
                                    document.Save(savedialog.FileName);
                                }; break;
                                                          

                                //pict.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить результаты вычислений", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            /*             
             else
            {                
                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(FirstFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = S = 0;

                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(SecondFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = S = 0;

                for (int i = 1; i <= n; i++)
                {
                    res = Math.Round(ThirdFrm(n, i, res), rnd);
                    S += res;
                    if (i == n) richTextBox1.AppendText(" = " + Convert.ToString(S));
                    else
                    {
                        richTextBox1.AppendText(Convert.ToString(S));
                        if (i != n - 1) richTextBox1.AppendText(" + ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
                res = S = 0;
            }

             */

        }



        private void справкаToolStripMenuItem_Click(object sender, EventArgs e) //вызов справки по проекту
        {
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
                        
        }

        private void журналПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journal jrnl = new journal();
            jrnl.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox2, "Возможно округление до 15 знаков");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void выходИзПриложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из приложения?", "MathHelper",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void историяИзмененийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changelog chnglg = new changelog();
            chnglg.Show();
        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}
