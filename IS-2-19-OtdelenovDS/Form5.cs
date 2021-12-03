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
using ConnectDB;

namespace IS_2_19_OtdelenovDS
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Connect2.GetDBConnection());
            string sqlZapros = $"SELECT idStud, fioStud, datetimeStud FROM t_PraktStud";
            try
            {
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sqlZapros, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 2];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Connect2.GetDBConnection());
            conn.Open();
            string fioSTUD = textBox2.Text;
            string datetimeSTUD = textBox3.Text;
            string zapros = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioSTUD}','{datetimeSTUD}');";
            int perem = 0;
            try
            {
                MySqlCommand command1 = new MySqlCommand(zapros, conn);
                perem = command1.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
            finally
            {
                conn.Close();
                if (perem != 0)
                {
                    MessageBox.Show("Данные были внесены в таблицу");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Connect2.GetDBConnection());
            string sqlZapros = $"SELECT idStud, fioStud, datetimeStud FROM t_PraktStud";
            try
            {
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sqlZapros, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 2];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
