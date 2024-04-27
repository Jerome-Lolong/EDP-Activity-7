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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moneyTransDbDataSet.Report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.moneyTransDbDataSet.Report);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear existing series
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Add new series
            chart1.Series.Add("Sender");
            chart1.Series.Add("Receiver");
            chart1.Series.Add("Metro Manila");
            chart1.Series.Add("Quezon");
            chart1.Series.Add("Legazpi");
            chart1.Series.Add("Biringan");

            chart2.Series.Add("Sender");
            chart2.Series.Add("Receiver");
            chart2.Series.Add("Metro Manila");
            chart2.Series.Add("Quezon");
            chart2.Series.Add("Legazpi");
            chart2.Series.Add("Biringan");

            // Set data source
            chart1.DataSource = reportBindingSource;
            chart2.DataSource = reportBindingSource;

            // Set X and Y value members for each series
            chart1.Series["Sender"].XValueMember = "Sender"; // Use appropriate column name
            chart1.Series["Sender"].YValueMembers = "Sender";
            chart1.Series["Receiver"].XValueMember = "Receiver"; // Use appropriate column name
            chart1.Series["Receiver"].YValueMembers = "Receiver";
            chart1.Series["Metro Manila"].XValueMember = "Metro Manila"; // Use appropriate column name
            chart1.Series["Metro Manila"].YValueMembers = "Metro Manila";
            chart1.Series["Quezon"].XValueMember = "Quezon"; // Use appropriate column name
            chart1.Series["Quezon"].YValueMembers = "Quezon";
            chart1.Series["Legazpi"].XValueMember = "Legazpi"; // Use appropriate column name
            chart1.Series["Legazpi"].YValueMembers = "Legazpi";
            chart1.Series["Biringan"].XValueMember = "Biringan"; // Use appropriate column name
            chart1.Series["Biringan"].YValueMembers = "Biringan";

            chart2.Series["Sender"].XValueMember = "Sender"; // Use appropriate column name
            chart2.Series["Sender"].YValueMembers = "Sender";
            chart2.Series["Receiver"].XValueMember = "Receiver"; // Use appropriate column name
            chart2.Series["Receiver"].YValueMembers = "Receiver";
            chart2.Series["Metro Manila"].XValueMember = "Metro Manila"; // Use appropriate column name
            chart2.Series["Metro Manila"].YValueMembers = "Metro Manila";
            chart2.Series["Quezon"].XValueMember = "Quezon"; // Use appropriate column name
            chart2.Series["Quezon"].YValueMembers = "Quezon";
            chart2.Series["Legazpi"].XValueMember = "Legazpi"; // Use appropriate column name
            chart2.Series["Legazpi"].YValueMembers = "Legazpi";
            chart2.Series["Biringan"].XValueMember = "Biringan"; // Use appropriate column name
            chart2.Series["Biringan"].YValueMembers = "Biringan";

            // Set chart type to spline
            foreach (var series in chart2.Series)
            {
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }

            // Data bind
            chart1.DataBind();
            chart2.DataBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transactions Obj = new Transactions();
            Obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
