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
    public partial class Add_tovar : Form
    {
        MySqlConnection conndb = ConnDB.connection;

        public void add_Tovar()
        {

            //Проверка на пустоту
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string id = textBox1.Text;
                        string name = textBox2.Text;
                        string vid = textBox3.Text;
                        string cena = textBox4.Text;
                        string update = $"INSERT INTO Tovars (ID, Name, Vid, Cena)" +
                        $" VALUES ('{id}','{name}', '{vid}', '{cena}')";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Данные о товаре добавлены");
                        conndb.Close();
                    }
                }
            }
        }
        public Add_tovar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_Tovar();
        }
    }
}
