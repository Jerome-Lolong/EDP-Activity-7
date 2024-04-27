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

namespace MoneyTransfer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=YOOMMM\SQLEXPRESS;Initial Catalog=MoneyTransDb;Integrated Security=True;");
        
        public static string Username = "", UserCity="";
        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "" || CityCb.SelectedIndex == -1)
            {
                MBox.Alert("Login your Credentials");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(@"select count(*) from AgentTbl where AName='" + UnameTb.Text + "' and APass='" + PasswordTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Username = UnameTb.Text;
                    UserCity = CityCb.SelectedItem.ToString();
                    Transactions Obj = new Transactions();
                    Obj.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MBox.Alert("Wrong Credentials!");
                }
                Con.Close();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
