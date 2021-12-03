using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_2_19_OtdelenovDS
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
    public class connect
    {
        public static string GetDBConnection()
        {
            string connString = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass";
            return connString;
        }
    }
}
