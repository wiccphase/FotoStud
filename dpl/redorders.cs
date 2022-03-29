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


    public partial class redorders : Form
    {

        private SqlConnection sqlConnection = null;
        public redorders()
        {
            InitializeComponent();
        }

        private void redorders_Load(object sender, EventArgs e)
        {

            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("1");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле  пустое");
                return;
            }
           

            SqlCommand command = new SqlCommand($"INSERT INTO [Orders] (NameOfPhoto) VALUES (@NameOfPhoto ,@price)", sqlConnection);

            command.Parameters.Add("@NameOfPhoto", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@price", SqlDbType.VarChar).Value = textBox2.Text;
           
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Да");
            else
                MessageBox.Show("nea");

           

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Таблица таблича = new Таблица();
            таблича.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
