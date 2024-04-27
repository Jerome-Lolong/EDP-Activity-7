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
namespace MoneyTransfer
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            DisplayAgents();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=YOOMMM\SQLEXPRESS;Initial Catalog=MoneyTransDb;Integrated Security=True;");
        private void Reset()
        {
            ANameTb.Text = "";
            APhoneTb.Text = "";
            APasswordTb.Text = "";
            ACityCb.SelectedItem=-1;
            Key = 1;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (ANameTb.Text == "" || ACityCb.SelectedIndex == -1 || APhoneTb.Text == "" || APasswordTb.Text == ""    ) 
            { 
                MBox.Alert("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into AgentTbl(AName,APhone,ACity,APass) values (@An,@Ap,@Ac,@Apass)", Con);
                    cmd.Parameters.AddWithValue("@An", ANameTb.Text);
                    cmd.Parameters.AddWithValue("@Ap", APhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ac", ACityCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Apass", APasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MBox.Alert("Saved Successfully!");
                    Con.Close();
                    DisplayAgents();
                    Reset();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void DisplayAgents()
        {
            Con.Open();
            string Query = "select * from AgentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int Key = 0;
        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AgentsDGV.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                ANameTb.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
                APhoneTb.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
                ACityCb.SelectedItem = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
                APasswordTb.Text = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();
                if (ANameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MBox.Alert("Select an Agent to Delete.");
            }else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from AgentTbl where AId=@AgKey", Con);
                cmd.Parameters.AddWithValue("@AgKey", Key);
                cmd.ExecuteNonQuery();
                MBox.Alert("Agent Deleted!");

                Con.Close();
                DisplayAgents();
                Reset();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ANameTb.Text == "" || ACityCb.SelectedIndex == -1 || APhoneTb.Text == "" || APasswordTb.Text == "")
            {
                MBox.Alert("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update AgentTbl set AName=@An,APhone=@Ap,ACity=@Ac,APass=@Apass where AId=@AgKey", Con); 
                    cmd.Parameters.AddWithValue("@An", ANameTb.Text);
                    cmd.Parameters.AddWithValue("@Ap", APhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ac", ACityCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Apass", APasswordTb.Text);
                    cmd.Parameters.AddWithValue("@AgKey", Key);
                    cmd.ExecuteNonQuery();
                    MBox.Alert("Edit Successfully!");
                    Con.Close();
                    DisplayAgents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            UpdatePass Obj = new UpdatePass();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }
    }
}
