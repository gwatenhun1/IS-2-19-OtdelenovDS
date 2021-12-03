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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Connect2.GetDBConnection());
            string sqlZapros = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sqlZapros, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                string index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                DateTime x = DateTime.Today;
                DateTime y = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[2].Value.ToString());
                string resultDays = (x - y).ToString();
                MessageBox.Show("Со дня рождения прошло " + resultDays.Substring(0, resultDays.Length - 9) + " дней");
            }
        }
    }
}
