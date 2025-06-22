using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShop
{
    public partial class Developer_Page : Form
    {
        const string constr = @"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Developer_Page()
        {
            InitializeComponent();
        }

        private void getStats()
        {
            string sql = "select top 2 GameName,TotalDownload, AvgDailyPlayers, ActivePlayer from Games order by TotalDownload desc";
            cm = new SqlCommand(sql, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            textBox1.Text = dt.Rows[0][0].ToString();
            textBox3.Text = dt.Rows[0][1].ToString();
            textBox4.Text= dt.Rows[0][2].ToString();
            textBox5.Text= dt.Rows[0][3].ToString();

            textBox2.Text = dt.Rows[1][0].ToString();
            textBox6.Text = dt.Rows[1][1].ToString();
            textBox7.Text = dt.Rows[1][2].ToString();
            textBox8.Text = dt.Rows[1][3].ToString();

            con.Close();

        }

        private void insertGame()
        {
            string sql1 = "select GameName from Games where GameName= @name";
            cm = new SqlCommand(sql1, con);
            cm.Parameters.AddWithValue("@name", textBox9.Text);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            

            if (dt1.Rows.Count == 0)
            {
                string sql = "insert into Games(GameId,GameName, DevelopedBy_Id, ESBR_Rating, Category, Price,discount) values( max(GameID)+1, @gamName, (select develop_id from Users where Users_Tag=Form1.userid), @ESBR, @Category , @Price, @Discount)";
                cm = new SqlCommand(sql, con);
                //con.Open();
                cm.Parameters.AddWithValue("@gamName", textBox9.Text);

                cm.Parameters.AddWithValue("@ESBR", comboBox2.Text);
           
                cm.Parameters.AddWithValue("@Price", Convert.ToInt32(textBox10.Text));
                cm.Parameters.AddWithValue("@Discount", Convert.ToInt32(textBox11.Text));

                if (comboBox1.Text == "Horror")
                {
                    cm.Parameters.AddWithValue("@Category", 2);
                    cm.ExecuteNonQuery();
                }

                else if (comboBox1.Text == "Adenture")
                {
                    cm.Parameters.AddWithValue("@Category", 1);
                    cm.ExecuteNonQuery();
                }

                else if (comboBox1.Text == "Fighting")
                {
                    cm.Parameters.AddWithValue("@Category", 3);
                    cm.ExecuteNonQuery();
                }

                if (comboBox1.Text == "FPS")
                {
                    cm.Parameters.AddWithValue("@Category", 4);
                    cm.ExecuteNonQuery();
                }

                textBox9.Clear();
                textBox12.Clear();
                textBox10.Clear();
                textBox11.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();

                
                MessageBox.Show("Game added sucessfully!");
            }

            else
            {
                MessageBox.Show("Game already present! Add a new one");
            }
           
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Developer_Page_Load(object sender, EventArgs e)
        {
            getStats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertGame();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
