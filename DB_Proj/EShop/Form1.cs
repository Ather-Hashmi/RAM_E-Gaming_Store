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
using System.Windows.Forms.VisualStyles;
using System.Data.SqlTypes;


namespace EShop
{
   
    public partial class Form1 : Form
    {

        public static string userID = "";
        public static string pass = "";

        const string constr =@"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void checkUserLogin()
        {
            string sql = "select Users_Tag from Users where Users_Tag= @userID and Password= @pass";

            cm = new SqlCommand(sql, con);
            con.Open();

            cm.Parameters.AddWithValue("@userID", Convert.ToInt32(textBox1.Text));
            cm.Parameters.AddWithValue("@pass", textBox2.Text);

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                userID = textBox1.Text;
                pass = textBox2.Text;
                this.Hide();
                Home ss = new Home();
                ss.Show();
            }
            else
                MessageBox.Show("Invalid username or password");

            con.Close();
        }

        private void checkDevLogin()
        {
            string sql = "select Users_Tag from Users where develop_id= @userID and Password= @pass";

            cm = new SqlCommand(sql, con);
            con.Open();

            cm.Parameters.AddWithValue("@userID", Convert.ToInt32(textBox1.Text));
            cm.Parameters.AddWithValue("@pass", textBox2.Text);

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                this.Hide();
                Developer_Page ss = new Developer_Page();
                ss.Show();
            }
            else
                MessageBox.Show("Invalid username or password");



            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewAccount ss = new NewAccount();
            ss.Show();
    
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkDevLogin();
            }
            else
            {
                checkUserLogin();
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
