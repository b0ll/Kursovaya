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
    public partial class Sotr_addDel : Form
    {
        public Sotr_addDel()
        {
            InitializeComponent();
        }
        MySqlConnection conndb = ConnDB.connection;

        public void add_sotrudnik()
        {

            //Проверка на пустоту
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
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
                        string post = textBox3.Text;
                        string login = textBox4.Text;
                        string password = textBox5.Text;
                        string status = textBox7.Text;
                        string update = $"INSERT INTO Sotrudniki (ID, s_fio, s_post, s_status, login, password)" +
                        $" VALUES ('{id}','{sotr}', '{post}','{status}', '{login}', '{password}')";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сотрудник успешно добавлен");
                        conndb.Close();
                    }
                }
            }
        }

        public void del_Sotrudnik()
        {
            //Проверка на пустоту
            if (textBox6.Text == "")
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                conndb.Open();
                {
                    try
                    {
                        string id = textBox6.Text;
                        string update = $"DELETE FROM Sotrudniki WHERE ID = '{id}'";
                        MySqlCommand command = new MySqlCommand(update, conndb);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                    finally
                    {
                        MessageBox.Show("Сотрудник успешно удалён");
                        conndb.Close();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            add_sotrudnik();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            del_Sotrudnik();
        }
    }
}
