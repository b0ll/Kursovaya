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
       
     public partial class Authorization : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_3_19_8;database=is_3_19_st8_KURS;password=59878228";
        MySqlConnection conndb;
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public Authorization()
        {
            InitializeComponent();
        }
        public int Connection(string login, string password)
        {
            int a = 0;
            try
            {
                conndb.Open();
                //Выбор всех данных из таблицы Sotrudniki и их фильтрование по подходящим логину и паролю
                string commandStr = $"SELECT count(*) FROM Sotrudniki WHERE login = '{login}' AND password = '{password}'";
                MySqlCommand comm1 = new MySqlCommand(commandStr, conndb);
                int k = Convert.ToInt32(comm1.ExecuteScalar());
                if (k != 0)
                {
                    //Выбор столбца s_status в зависимости от логина и пароля
                    string commandStr2 = $"SELECT s_status FROM Sotrudniki WHERE login = '{login}' AND password = '{password}'";
                    MySqlCommand comm2 = new MySqlCommand(commandStr2, conndb);
                    a = Convert.ToInt32(comm2.ExecuteScalar());
                }
            }
            //Обработка исключений
            catch
            {

            }
            //Закрытие соединения
            conndb.Close();
            return a;
        }
        
        private void Authorization_Load(object sender, EventArgs e)
        {
            conndb = new MySqlConnection(connStr);
        }
        public void Uroven()
        {
            //Если возвращаемое значение a равняется 1(уровень доступа, то есть столбец s_status в БД), открывается форма меню сотрудника,
            //если 2, то форма меню директора
            if (Connection(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("Вы авторизированы как сотрудник");
                //Скрытие данной формы и запуск следующей в зависимости от введёных данных
                SotrMenu sm = new SotrMenu();
                this.Hide();
                sm.ShowDialog();
            }
            else if (Connection(textBox1.Text, textBox2.Text) == 2)
            {
                MessageBox.Show("Вы авторизированы как директор");
                DirMenu dm = new DirMenu();
                this.Hide();
                dm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }


            private void button1_Click(object sender, EventArgs e)
        {
            Uroven();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = sha256(textBox2.Text);
        }
              
        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
