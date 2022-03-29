using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace dpl
{

   
    public partial class Авторизация : Form
    {

        private SqlConnection sqlConnection = null;
        public Авторизация()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            {
                dbb db = new dbb();
                db.GetConnection();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString);

                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("EST");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void button_login_Click(object sender, EventArgs e)
        {
            String loginuser = loginField.Text;
            String passUser = passField.Text;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM users where login = @log AND password = @pas", sqlConnection);
            command.Parameters.Add("@log", SqlDbType.VarChar).Value = loginuser;
            command.Parameters.Add("@pas", SqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Основная_панель frm4 = new Основная_панель();
                frm4.Show();
                this.Hide();


            }
            else
                MessageBox.Show("nEusPEH");

        }
  

    }
}
