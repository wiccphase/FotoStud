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
    public partial class redsotrudnik : Form
    {


        private SqlConnection sqlConnection = null;

        public redsotrudnik()
        {
            InitializeComponent();
        }

        private void redsotrudnik_Load(object sender, EventArgs e)
        {

            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("ЕСТЬ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле  пустое");
                return;
            }


            SqlCommand command = new SqlCommand($"INSERT INTO [Sotrudnik] (Name, Surname, Phone, Birthday, Zarplata, Dolzhnost) VALUES (@Name ,@Surname, @Phone, @Birthday, @Zarplata, @Dolzhnost)", sqlConnection);
        
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Surname", SqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@Birthday", SqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@Zarplata", SqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@Dolzhnost", SqlDbType.VarChar).Value = textBox6.Text;

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были успешно добавлены");
          

            else
                MessageBox.Show("Произошла ошибка");

   
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Сотрудники табличка = new Сотрудники();
            табличка.Show();
            this.Hide();
        }
    }
}
