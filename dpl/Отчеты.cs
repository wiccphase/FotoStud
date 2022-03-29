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
    public partial class Отчеты : Form
    {
        private SqlConnection sqlConnection = null;
        public Отчеты()
        {   
            InitializeComponent();
        }







        private void button6_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }

        private void Отчеты_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet.Orders". При необходимости она может быть перемещена или удалена.

            db DB = new db();
            DB.GetConnection();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("БД активирована");
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
