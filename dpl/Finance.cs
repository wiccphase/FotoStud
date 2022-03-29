using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace dpl
{
    public partial class Finance : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;
        public Finance()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            table.Clear();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            {
                dbb db = new dbb();
                db.GetConnection();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("EST");
                }

                adapter = new SqlDataAdapter("Select * From Finance", sqlConnection);
                table = new DataTable();

                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://online.sberbank.ru/CSAFront/index.do#/");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Основная_панель fop = new Основная_панель();
            fop.Show();
            this.Hide();
        }
    }
}
