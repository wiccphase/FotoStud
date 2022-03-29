using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dpl
{
    public partial class Таблица : Form
    {
        private SqlConnection sqlConnection = null;
        public Таблица()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Таблица_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ordersDataset.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.ordersDataset.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet3.Orders". При необходимости она может быть перемещена или удалена.

            {


                db db = new db();
                db.GetConnection();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Покдлючение к Базе данных выполнено");
                }
                //SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Orders", sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            redorders redord1 = new redorders();
            redord1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            var values = textBox1.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView1.Rows[i];

                    if (row.Cells["dataGridViewTextBoxColumn3"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn2"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("DELETE FROM Orders WHERE id=@id", sqlConnection);
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            com.Parameters.AddWithValue("@id", id);

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Запись удалена");
                
            }
            catch
            {
                MessageBox.Show("Удалить не удалось!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }
    }


        
    
}