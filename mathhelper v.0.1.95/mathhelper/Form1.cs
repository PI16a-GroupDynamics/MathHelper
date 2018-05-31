using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mathhelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            const string db = @"mathhelper.db";
            SQLiteConnection con = new SQLiteConnection (String.Format("Data Source = {0};", db));
            con.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM auth WHERE login='';", con);

            */

            string str = Convert.ToString(textBox1.Text) + " " + Convert.ToString(textBox2.Text);
            StreamReader file = new StreamReader("auth.txt");
            string[] auth = File.ReadAllLines("auth.txt");
            bool auth_check = false;

            foreach (string line in File.ReadLines("auth.txt"))
            {
                if (line.Contains(str))
                {
                    auth_check = true;
                    MessageBox.Show("Авторизация успешна!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Form2 app = new Form2();
                    app.Show();
                    Hide();
                    break;
                }
            }
            if (!auth_check) MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock)) label4.Visible = true;
            else label4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock)) label4.Visible = true;
            else label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
