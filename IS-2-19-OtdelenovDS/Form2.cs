﻿using System;
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
        static class DBUtils
        {
            public static string GetDBConnection()
            {
                string host = "caseum.ru";
                string port = "33333";
                string database = "db_test";
                string username = "test_user";
                string password = "test_pass";
                string connString = $"server={host};port={port};user={username};database={database};password={password};";
                return connString;
            }
        }
        MySqlConnection conn = new MySqlConnection(DBUtils.GetDBConnection());
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Удача");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не повезло: " + ex);
            }
            finally
            {

            }
        }
    }
}
