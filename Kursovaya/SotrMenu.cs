using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Library1;

namespace Kursovaya
{
    public partial class SotrMenu : Form
    {
        public SotrMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_buy ab = new Add_buy();
            ab.ShowDialog();
       
        }
        private void SotrMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization au = new Authorization();
            au.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TovarList tl = new TovarList();
            tl.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_tovar at = new Add_tovar();
            at.ShowDialog();
        }
    }
}
