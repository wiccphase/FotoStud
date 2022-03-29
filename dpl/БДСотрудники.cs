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

            {


                db db = new db();
                db.GetConnection();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("1");
                }
                //SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Orders", sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

     
    }


        
    
}