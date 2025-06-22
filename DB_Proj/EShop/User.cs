using EShop.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShop
{
    public partial class User : Form
    {
        const string constr = @"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();

        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ss = new Home();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory ss = new Inventory();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Wallet ss = new Wallet();
            ss.Show();
        }

 

        private void displayWallet()
        {
            string sql = "select wallet_amount from Users where Users_Tag = @user";
            cm = new SqlCommand(sql, con);
            con.Open();
            cm.Parameters.AddWithValue("@user", Convert.ToInt32(textBox1.Text));

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            textBox3.Text = dt.Rows[0][0].ToString();

            con.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.userID;
            textBox2.Text = Form1.pass;
            displayWallet();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
