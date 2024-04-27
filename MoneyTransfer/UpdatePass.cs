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
    public partial class UpdatePass : Form
    {
        public UpdatePass()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Agents Obj = new Agents();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=YOOMMM\SQLEXPRESS;Initial Catalog=MoneyTransDb;Integrated Security=True;");
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(PasswordTb.Text == "")
            {
                MBox.Alert("Enter New Password");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update AdminTbl set Adpass=@Ap where AdId=@AdmKey", Con);
                    cmd.Parameters.AddWithValue("@Ap", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@AdmKey", 1);
                    cmd.ExecuteNonQuery();
                    MBox.Alert("Updated Successfully!");
                    Con.Close();
                    AdminLogin Obj = new AdminLogin();
                    Obj.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
