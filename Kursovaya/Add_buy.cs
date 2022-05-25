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

        public void add_data()
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
                    //Вставляем значения в таблицу Service_Rendering
                    string commandStr = $"INSERT INTO Uslugi (Sotrudnik,Time,Tovar,Client,Cost) VALUES (@Sotrudnik,@Time,@Tovar,@Client,@Cost)";
                    MySqlCommand command = new MySqlCommand(commandStr, conndb);
                    try
                    {
                        //берём значение из текстбоксов,дататаймпикера и кидаем в базу данных
                        command.Parameters.Add("@Sotrudnik", MySqlDbType.Text).Value = textBox2.Text;
                        command.Parameters.Add("@Time", MySqlDbType.DateTime).Value = dateTimePicker1.Text;
                        command.Parameters.Add("@Tovar", MySqlDbType.Text).Value = textBox3.Text;
                        command.Parameters.Add("@Client", MySqlDbType.Text).Value = textBox4.Text;
                        command.Parameters.Add("@Cost", MySqlDbType.Int32).Value = textBox5.Text;
                        //Изменения данных в БД
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
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
            add_data();
        }
    }
}
