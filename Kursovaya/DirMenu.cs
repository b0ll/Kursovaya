using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class DirMenu : Form
    {
        public DirMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sotrudniki me = new Sotrudniki();
            me.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellList sl = new SellList();
            sl.ShowDialog();
        }
    }
}
