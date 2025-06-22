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
    public partial class NewAccount : Form
    {
        const string constr = @"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();

        public NewAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void insertUser()
        {
            if (textBox2.Text != textBox3.Text)
                MessageBox.Show("Passwords don't match, Retype");

            else
            {
                if (checkBox1.Checked == false)
                {
                    con.Open();
                    string sql = "insert into Users(Users_Tags, wallet_amount, email, password) values (@userid, 0," + textBox1.Text + "@game.pk, @pass)";
                    cm = new SqlCommand(sql, con);
                    cm.Parameters.AddWithValue("@userid", Convert.ToInt32(textBox1.Text));
                    cm.Parameters.AddWithValue("@pass", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    //cm.ExecuteNonQuery();


                    MessageBox.Show("Account created!");

                    this.Hide();
                    Form1 ss = new Form1();
                    ss.Show();

                }

                else
                {
                    string sql = "insert into Users(Users_Tags, wallet_amount, email, password, develop_id) values (@userid, 0," + textBox1.Text + "@game.pk, @pass, (select max(develepor_ID) from Published_By) +1))";
                    cm = new SqlCommand(sql, con);
                    con.Open();
                    cm.Parameters.AddWithValue("@userid", Convert.ToInt32(textBox1.Text));
                    cm.Parameters.AddWithValue("@pass", textBox2.Text);

                    MessageBox.Show("Account created!");

                    this.Hide();
                    Form1 ss = new Form1();
                    ss.Show();
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertUser();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
