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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connect.GetDBConnection());//создаётся экземпляр класса MySqlConnection
            string sqlZapros = $"SELECT id, fio, theme_kurs FROM t_stud";//В переменную sqlZapros идёт присвоение ячеек таблицы
            try
            {
                conn.Open();//Открывается соединение с бд
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sqlZapros, conn);//создаётся экземпляр класса MySqlConnection, принимаются значения переменной и экземпляра класса
                DataSet dataset = new DataSet();//создаётся экземпляр класса DataSet
                IDataAdapter.Fill(dataset);//Заполнение
                dataGridView1.DataSource = dataset.Tables[0];//И это тоже
                conn.Close();//Закрывается соединение с бд
            }
            catch (Exception ex)
            {
                MessageBox.Show("Подключение разорвано: " + ex);
                conn.Close();//Закрывается соединение с бд
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                string index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                string id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString();
                MessageBox.Show(id_rows);
            }
        }
    }
}
