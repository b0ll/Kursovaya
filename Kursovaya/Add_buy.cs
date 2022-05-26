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
    public partial class Add_buy : Form
    {
        public Add_buy()
        {
            InitializeComponent();
        }

        MySqlConnection conndb = ConnDB.connection;

        public void add_Buy()
        {

            //Проверка на пустоту
            if ( textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "")
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
                        string sotr = textBox2.Text;
                        string tovar = textBox3.Text;
                        string client = textBox4.Text;
                        string cost = textBox5.Text;
                        string time = dateTimePicker1.Value.ToString(string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value));
                        string update = $"INSERT INTO Uslugi (ID, Sotrudnik, Tovar, Client, Cost, Time)" +
                        $" VALUES ('{id}','{sotr}', '{tovar}', '{client}', '{cost}', '{time}')";
                        MySqlCommand command = new MySqlCommand(update, conndb); 
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Данные о продаже добавлены");
                        conndb.Close();
                    }
                }
            }
        }

        private void Add_buy_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_Buy();
        }

        private void Add_buy_FormClosing(object sender, FormClosingEventArgs e)
        {
            SotrMenu sm = new SotrMenu();
            this.Hide();
        }
    }
}
