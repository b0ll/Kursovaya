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
        //��������� ����, ������� ������ �������� ������� �����������
        public static bool auth = false;
        //��������� ����, ������� ������ �������� ID ������������
        public static string auth_id = null;
        //��������� ����, ������� ������ �������� ��� ������������
        public static string auth_login = null;
        //������ ���� ��� ������ ����������
        public static string auth_sotr = null;
        //��������� ����, ������� ������ ���������� ���������� ������������
        public static int auth_role = 0;
    }
}

