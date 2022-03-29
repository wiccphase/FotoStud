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
    public partial class Основная_панель : Form
    {
        public Основная_панель()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Таблица таблица = new Таблица();
            таблица.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Профиль fr2 = new Профиль();
            fr2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Сотрудники fr2 = new Сотрудники();
            fr2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Дедлайн fr2 = new Дедлайн();
            fr2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Отчеты fr2 = new Отчеты();
            fr2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Статистика fr2 = new Статистика();
            fr2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Авторизация fr2 = new Авторизация();
            fr2.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Finance fn2 = new Finance();
            fn2.Show();
            this.Hide();
        }

        private void Основная_панель_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                imgexplorer imx = new imgexplorer();
            imx.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
