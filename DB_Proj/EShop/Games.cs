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
    public partial class Games : Form
    {
        const string constr = @"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public int number;


        public Games()
        {
            InitializeComponent();
        }


        public Games(int num)
        {
            Console.WriteLine(num);
            this.number = num;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ss = new Home();
            ss.Show();
        }

        private void getGames(int num)
        {

            string sql = "select GameName from Games where Category= @num";

            cm = new SqlCommand(sql, con);
            con.Open();

            cm.Parameters.AddWithValue("@num", num);
      

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Console.WriteLine(da);
          
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[1][0].ToString();
            textBox3.Text = dt.Rows[2][0].ToString();

            con.Close();
        }

        private void addFeatured()
        {

            string sql = "select top 2 GameName from Games, Featured where Games.GameID= Featured.GameID order by Featured.FeatureFrom_Date desc";

            cm = new SqlCommand(sql, con);
            con.Open();


            SqlDataAdapter ds = new SqlDataAdapter(cm);
            DataTable dt1 = new DataTable();
            ds.Fill(dt1);

            //Console.WriteLine(da);

            textBox1.Text = dt1.Rows[0][0].ToString();
            textBox2.Text = dt1.Rows[1][0].ToString();

            con.Close();
        
    }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cricket22 ss = new Cricket22();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StreetFighter ss = new StreetFighter();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            
            this.Hide();
            Solitaire ss = new Solitaire();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MineCraft ss = new MineCraft();
            ss.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Games_Load(object sender, EventArgs e)
        {
            if (number == 0)
            {
                addFeatured();
            }
            else
            {
                getGames(number);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Solitaire ss = new Solitaire();
            ss.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Solitaire ss = new Solitaire();
            ss.Show();
        }
    }
}
