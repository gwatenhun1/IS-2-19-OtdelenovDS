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

namespace IS_2_19_OtdelenovDS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static class DBUtils
        {
           
            public static string GetDBConnection()
            {
                string connString = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass";
                return connString;
            }
        }
        MySqlConnection conn = new MySqlConnection(DBUtils.GetDBConnection());
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Идёт подключение");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex);
            }
            conn.Close();
        }
    }
}
