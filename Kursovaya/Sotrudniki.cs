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
    public partial class Sotrudniki : Form
    {
        public Sotrudniki()
        {
            InitializeComponent();
        }

        public void Change_data()
        {
            Sotr_data data = new Sotr_data();
            data.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change_data();
        }
       
    }
}
