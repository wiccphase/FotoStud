using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class imgexplorer : Form
    {

        private SqlConnection sqlConnection = null;
        public imgexplorer()
        {
            InitializeComponent();
        }
      
       


        private void imgexplorer_Load(object sender, EventArgs e)
        {

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



            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                this.Text = openFileDialog1.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                

                SqlCommand comm = new SqlCommand($"INSERT INTO [Photo] (ImageByte,OrderId) VALUES (@ImageByte,@OrderId)", sqlConnection);
                int lubluy = Convert.ToInt32(textBox1.Text);
            comm.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy;
            comm.Parameters.Add("@ImageByte", SqlDbType.Image).Value = ms.ToArray();
                comm.ExecuteNonQuery();
            
          
            
            //var govno = Image.Empty;
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";

            //openFileDialog.Filter = "Images Files(*.JPG;*.PNG)|*.JPG;*.PNG|ALL files (*.*)|*.*";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{


            //    filePath = openFileDialog.FileName;


            //    SqlCommand cmd = new SqlCommand(
            //   "INSERT INTO Orders (ImageByte, AltText)" +
            //   "VALUES (@ImageByte, @AltText)", sqlConnection);


            //    FileStream fStream = new FileStream(
            //        "D:\\GraphFile.png", FileMode.Open, FileAccess.Read);



            //    Byte[] imageBytes = new byte[fStream.Length];
            //    fStream.Read(imageBytes, 0, imageBytes.Length);

            //    SqlParameter par = new SqlParameter(
            //        "@IdPhoto", SqlDbType.UniqueIdentifier);
            //    par.Value = Guid.NewGuid();
            //    par.Direction = ParameterDirection.Input;
            //    cmd.Parameters.Add(par);

            //    par = new SqlParameter("@ImageByte", SqlDbType.Image);
            //    par.Value = imageBytes;
            //    cmd.Parameters.Add(par);

            //    par = new SqlParameter("@AltText", SqlDbType.NVarChar);
            //    par.Value = "Просто картинка";
            //    cmd.Parameters.Add(par);


            //    cmd.ExecuteNonQuery();

        }
        


        public void button2_Click(object sender, EventArgs e)
        {


            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Покдлючение к Базе данных выполнено");
            }


            int lubluy2 = Convert.ToInt32(textBox2.Text);
            

        SqlCommand command = new SqlCommand(
                "SELECT ImageByte FROM Photo WHERE OrderId=@OrderId", sqlConnection);
            command.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy2;


            //SqlCommand comm = new SqlCommand("Select IdPhoto from Photo WHERE  WHERE OrderId=@OrderId", sqlConnection);
            //command.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy2;
            //negr2002 = Convert.ToInt32(comm);


            //SqlCommand commm = new SqlCommand(
            //    "SELECT ImageByte FROM Photo WHERE OrderId=@OrderID and PhotoId>@PhotoId", sqlConnection);
            //command.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy2;
            //command.Parameters.Add("@PhotoId", SqlDbType.Int).Value = negr2002;







            //SqlDataReader datareader = command.ExecuteReader();
            //datareader.Read();

            //int bLength = (int)datareader.GetBytes(6, 0, null, 0, int.MaxValue);

            //byte[] bBuffer = new byte[bLength];

            //datareader.GetBytes(1, 0, bBuffer, 0, bLength);


            //MemoryStream mStream = new MemoryStream(bBuffer);

            //pictureBox1.Image = Image.FromStream(mStream);



            try
            {

                MemoryStream stream = new MemoryStream((byte[])command.ExecuteScalar());
                this.pictureBox1.Image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            sqlConnection.Close();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;

            //sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            //sqlConnection.Open();

            //int lubluy5 = Convert.ToInt32(textBox2.Text);
            

     


            //SqlCommand comm = new SqlCommand("Select IdPhoto FROM Photo WHERE OrderId=@OrderId", sqlConnection);
            //comm.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy5;
            ////negr2002 = Convert.ToInt32(comm);
            //int result = ((int)comm.ExecuteScalar());
            ////negr2002 = Convert.ToInt32(comm);

            //SqlCommand commm = new SqlCommand(
            // "SELECT ImageByte FROM Photo WHERE OrderId=@OrderId and IdPhoto>@IdPhoto", sqlConnection);
            //commm.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy5;
            //commm.Parameters.Add("@IdPhoto", SqlDbType.Int).Value = result;
           
            //try
            //{

            //    MemoryStream stream = new MemoryStream((byte[])commm.ExecuteScalar());
            //    this.pictureBox1.Image = Image.FromStream(stream);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка");
            //}
            //sqlConnection.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();

            int lubluy5 = Convert.ToInt32(textBox2.Text);





            SqlCommand comm = new SqlCommand("Select IdPhoto FROM Photo WHERE OrderId=@OrderId", sqlConnection);
            comm.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy5;
            //negr2002 = Convert.ToInt32(comm);
            int result = ((int)comm.ExecuteScalar());
            //negr2002 = Convert.ToInt32(comm);

            SqlCommand commm = new SqlCommand(
             "SELECT ImageByte FROM Photo WHERE OrderId=@OrderId and IdPhoto>@IdPhoto", sqlConnection);
            commm.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy5;
            commm.Parameters.Add("@IdPhoto", SqlDbType.Int).Value = result;

            try
            {

                MemoryStream stream = new MemoryStream((byte[])commm.ExecuteScalar());
                this.pictureBox1.Image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            sqlConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            db db = new db();
            db.GetConnection();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Покдлючение к Базе данных выполнено");
            }


            int lubluy2 = Convert.ToInt32(textBox2.Text);


            SqlCommand command = new SqlCommand(
                    "SELECT ImageByte FROM Photo WHERE OrderId=@OrderId", sqlConnection);
            command.Parameters.Add("@OrderId", SqlDbType.Int).Value = lubluy2;



            try
            {

                MemoryStream stream = new MemoryStream((byte[])command.ExecuteScalar());
                this.pictureBox1.Image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            sqlConnection.Close();
        }
    } 
}

