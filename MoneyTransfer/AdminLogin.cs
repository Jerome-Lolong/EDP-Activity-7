using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace MoneyTransfer
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=YOOMMM\SQLEXPRESS;Initial Catalog=MoneyTransDb;Integrated Security=True;");
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTb.Text == "")
            {
                MBox.Alert("Please enter credentials.");
            } else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(@"select count(*) from AdminTbl where Adpass='" + PasswordTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Agents Obj = new Agents();
                        Obj.Show();
                        this.Hide();
                        Con.Close();
                    }
                    else
                    {
                        MBox.Alert("Wrong Credentials!");
                    }
                    Con.Close();
                } catch (Exception Ex)
                {
                    MBox.Alert(Ex.Message);
                }

            }

        }
    }
}

