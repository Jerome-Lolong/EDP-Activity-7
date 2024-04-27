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
using DocumentFormat.OpenXml.Bibliography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MoneyTransfer
{
    public partial class Receives : Form
    {
        public Receives()
        {
            InitializeComponent();
            DisplayRec();
            CityLbl.Text = Transactions.UserCity;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=YOOMMM\SQLEXPRESS;Initial Catalog=MoneyTransDb;Integrated Security=True;");
        int Amt;
        private void CheckCode()
        {
            if (SCodeTb.Text == "")
            {
                MBox.Alert("Please Input a Code.");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(@"select count(*) from SendTbl where SCode='" + SCodeTb.Text + "' and Collected='"+"No"+"' and RCity='"+CityLbl.Text+"'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    try
                    {
                        //Con.Open();
                        string query = "select * from SendTbl where SCode='" + SCodeTb.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                        sda1.Fill(dt1);
                        foreach (DataRow dr in dt1.Rows)
                        {
                            SNameLbl.Text = dr["SenderName"].ToString();
                            RNameLbl.Text = dr["ReceiverName"].ToString();
                            Amt = Convert.ToInt32(dr["SAmt"].ToString());
                            AmtLbl.Text = "RS:" + dr["SAmt"].ToString();
                            SentDateLbl.Text = dr["SDate"].ToString();
                            CityLbl.Text = dr["RCity"].ToString();
                            SCityLbl.Text = dr["SCity"].ToString();
                        }
                        Con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MBox.Alert("Code doesn't Exist!");
                    Con.Close();
                }
            }  
                }

        private void DisplayRec()
        {
            Con.Open();
            string Query = "select * from ReceiveTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ReceiveDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckCode();
        }
        private void Reset()
        {
            SNameLbl.Text = "";
            RNameLbl.Text = "";
            AmtLbl.Text = "";
            SentDateLbl.Text = "";
            SCodeTb.Text = "";
            SCityLbl.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Receives_Load(object sender, EventArgs e)
        {
            Todaylbl.Text = TodayDate.Value.Date.ToString();
        }

        private void SentDateLbl_Click(object sender, EventArgs e)
        {

        }
        private void UpdateSend()
        {
            
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update SendTbl set Collected=@Ac where SCode=@SKey", Con);
                    cmd.Parameters.AddWithValue("@Ac", "Yes");
                    cmd.Parameters.AddWithValue("@SKey", SCodeTb.Text);
                    cmd.ExecuteNonQuery();
                    //MBox.Alert("Edit Successfully!");
                    Con.Close();
                    //DisplayAgents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (SCodeTb.Text == "" || RNameLbl.Text == "")
            {
                MBox.Alert("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into ReceiveTbl(SCode,SName,RName,STotal,SDate,RDate,RCity,SCity) values (@SC,@SN,@RN,@ST,@SD,@RD,@RC,@SCi)", Con);
                    cmd.Parameters.AddWithValue("@SC", SCodeTb.Text);
                    cmd.Parameters.AddWithValue("@SN", SNameLbl.Text);
                    cmd.Parameters.AddWithValue("@RN", RNameLbl.Text);
                    cmd.Parameters.AddWithValue("@ST", Amt);
                    cmd.Parameters.AddWithValue("@SD", DateTime.Parse(SentDateLbl.Text).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@RD", DateTime.Parse(Todaylbl.Text).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@RC", CityLbl.Text);
                    cmd.Parameters.AddWithValue("@SCi", SCityLbl.Text);
                    cmd.ExecuteNonQuery();
                    MBox.Alert("Money Received!");
                    Con.Close();
                    DisplayRec();
                    UpdateSend();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Todaylbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Transactions Obj = new Transactions();
            Obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transactions Obj = new Transactions();
            Obj.Show();
            this.Hide();
            //Goes Back to Transactions Page
        }
    }
}
