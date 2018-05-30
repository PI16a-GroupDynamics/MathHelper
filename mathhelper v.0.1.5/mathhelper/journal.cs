using System;
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
    public partial class journal : Form
    {
        public journal()
        {
            InitializeComponent();
        }

        private void journal_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Доступно только для пользователей с правами администратора");
            t.SetToolTip(button2, "Доступно только для пользователей с правами администратора");

        }
    }
}
