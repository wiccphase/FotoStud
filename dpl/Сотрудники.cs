using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dpl
{
    //enum RowState
    //{
    //    Exised,
    //    New,
    //    Modifier,
    //    ModifierNew,
    //    Deleted
    //}
    public partial class Сотрудники : Form
    {
        DataSet ds;
        SqlCommandBuilder commandBuilder;
        private SqlConnection sqlConnection = null;
        int selectedRow;
        public Сотрудники()
        {
            InitializeComponent();


        }

        //private void DeleteRow()
        //{
        //    int index = dataGridView1.CurrentCell.RowIndex;
        //    //dataGridView1.Rows[index].Visible = false;


        //    if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
        //    {
        //        dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        //    }
          
        //}

        //private void Update()
        //{
        //    for(int index = 0; index < dataGridView1.Rows.Count; index++)
        //    {
        //        var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

        //        if (rowState == RowState.Exised)
        //            continue;
        //        if (rowState == RowState.Deleted)
        //        {
        //            var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
        //            var deleteQuere = $"delete from Sotrudnik where id = {id} ";
        //            var command = new SqlCommand(deleteQuere, sqlConnection);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}


        private void button6_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }

        private void Сотрудники_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДСотрудникиDataSet.Sotrudnik". При необходимости она может быть перемещена или удалена.
            this.sotrudnikTableAdapter.Fill(this.бДСотрудникиDataSet.Sotrudnik);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet2.Sotrudnik". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet1.Sotrudnik". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet.Orders". При необходимости она может быть перемещена или удалена.


            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Покдлючение к Базе данных выполнено");
            }
            //SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Sotrudnik", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            redsotrudnik redsot = new redsotrudnik();
            redsot.Show();
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

                    if (
                        row.Cells["dataGridViewTextBoxColumn1"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn2"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn3"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn4"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn5"].Value.ToString().Contains(value) ||
                        row.Cells["dataGridViewTextBoxColumn6"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    dataGridView1.Rows.Remove(row);
            //}
            SqlCommand com = new SqlCommand("DELETE FROM Sotrudnik WHERE id=@id", sqlConnection);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Основная_панель fop = new Основная_панель();
            fop.Show();
            this.Hide();
        }
    }
    }




