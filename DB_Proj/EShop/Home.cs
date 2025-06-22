using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShop
{
    public partial class Home : Form
    {
        public int pg = 0;
        public Home()
        {
        
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            pg = 1;
            Games ss = new Games(pg);
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pg = 2;
            this.Hide();
            Games ss = new Games(pg);
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pg = 3;
            this.Hide();
            Games ss = new Games(pg);
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Games ss = new Games(pg);
            ss.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            User ss = new User();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShoppingCart ss = new ShoppingCart();
            ss.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form1.userID;
        }
    }
}
