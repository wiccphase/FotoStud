using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dpl
{
    public partial class Дедлайн : Form
    {
        public Дедлайн()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }

        private void Дедлайн_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "deadlinedataset.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.deadlinedataset.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "база_данных_директора_фотостудииDataSet4.Orders". При необходимости она может быть перемещена или удалена.

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Основная_панель fr2 = new Основная_панель();
            fr2.Show();
            this.Hide();
        }
    }
}
