using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dpl
{
    public partial class Статистика : Form
    {
        private SqlConnection sqlConnection = null;
        public Статистика()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }

        private void Статистика_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "datastatistikasotrudnik.Sotrudnik". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "datagridstatistikaprodazhi.Orders". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet10.Sotrudnik". При необходимости она может быть перемещена или удалена.

            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Покдлючение к Базе данных выполнено");
            }
            
          
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlCommand mySqlCommand = new SqlCommand("SELECT Name,Surname,Phone FROM Sotrudnik", sqlConnection))
            using (SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
            using (StreamWriter streamWriter = new StreamWriter("textFile"))
            {
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; streamWriter.Write("\t" + mySqlDataReader[i++].ToString())) ;
                    streamWriter.WriteLine(string.Empty);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }
    }
}
