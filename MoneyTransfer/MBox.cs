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
    public partial class MBox : Form
    {
        public MBox()
        {
            InitializeComponent();
            MsgLbl.Text = AMessage;
        }
        static string AMessage;
        public static void Alert(string Msg)
        {
            AMessage = Msg;
            MBox Obj = new MBox();
            Obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
