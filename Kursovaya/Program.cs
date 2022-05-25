using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }
    }
    static class Auth
    {
        //—татичное поле, которое хранит значение статуса авторизации
        public static bool auth = false;
        //—татичное поле, которое хранит значени€ ID пользовател€
        public static string auth_id = null;
        //—татичное поле, которое хранит значени€ ‘»ќ пользовател€
        public static string auth_login = null;
        //статик поле дл€ данных сотрудника
        public static string auth_sotr = null;
        //—татичное поле, которое хранит количество привелегий пользовател€
        public static int auth_role = 0;
    }
}

