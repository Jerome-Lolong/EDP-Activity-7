using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTransfer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moneyTransDbDataSet1.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.moneyTransDbDataSet1.Table);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].XValueMember = "Money Sent";
            chart1.Series[0].YValueMembers = "Money Sent";

            chart1.Series[1].XValueMember= "Total Amnt";
            chart1.Series[1].YValueMembers= "Total Amnt";

            chart1.DataSource = tableBindingSource;
            chart1.DataBind();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agents Obj = new Agents();
            Obj.Show();
            this.Hide();
        }
    }
}
