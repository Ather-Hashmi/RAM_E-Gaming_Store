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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EShop.Resources
{
    public partial class Wallet : Form
    {
        const string constr = @"Data Source=HU-DOPX-ML17; Initial Catalog=GamingRam ;User ID= sa; Password=Fall2022.dbms";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Wallet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User ss = new User();
            ss.Show();
        }

        private void updateWallet()
        {
            string sql = "update Users set wallet_amount=wallet_amount+ @wallet where Users_Tag= @user";
            cm = new SqlCommand(sql, con);
            con.Open();

            cm.Parameters.AddWithValue("@user", Convert.ToInt32(Form1.userID));
            cm.Parameters.AddWithValue("@wallet", Convert.ToDecimal(textBox1.Text));
            cm.ExecuteNonQuery();

            con.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            updateWallet();
            this.Hide();
            User ss = new User();
            ss.Show();
        }
    }
}
