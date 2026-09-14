using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechFixFrontend
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if ("techfixadmin".Equals(username, StringComparison.OrdinalIgnoreCase) && "techfix@09".Equals(password))
            { 
                Form1 home = new Form1();
                home.Show();
                this.Hide();
            }
        }
    }
}
