using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library1
{
    public class ConnDB
    {
        public static MySqlConnection connection = new MySqlConnection("server=chuc.caseum.ru;port=33333;user=st_3_19_8;database=is_3_19_st8_KURS;password=59878228");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
