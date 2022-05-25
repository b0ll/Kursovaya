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
    public partial class Sotr_data : Form
    {
        public Sotr_data()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection conndb = ConnDB.connection;

        private void button1_Click(object sender, EventArgs e)
        {
            {

                string a = textBox3.Text;
                string k = textBox1.Text;
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введите данные");
                }
                else
                {
                    try
                    {
                        conndb.Open();
                        string commandStr = $"UPDATE Sotrudniki SET login = '{k}' WHERE ID = '{a}'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(commandStr, conndb);
                        DataTable dTable = new DataTable();
                        adapter.Fill(dTable);
                    }
                    catch
                    {

                    }
                    conndb.Close();
                }

            }
        }
    }
}
