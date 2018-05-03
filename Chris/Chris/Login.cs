using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chris
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = "chris";
            String password = "1234";


            if (textBox1.Text.Equals(username))
            {
                if (textBox2.Text.Equals(password))
                {
                    // MessageBox.Show("Accessed");

                    this.Close();


                }
                else
                {
                    MessageBox.Show("Password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Username incorrect");
            }
        }

        private new void Enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(e, e);
            }
        }

        private void Enter_Username(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(e, e);
            }
        }

        private void Enter_PW(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(e, e);
            }
        }
    }
}
