﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
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




            Form2 app = new Form2();
            app.Show();
            Hide();
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
