using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.ServerAPI;

namespace KainmunityClient.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            bool isSuccess = await AccountManager.VerifyLogin(inputContactNumber.Text, inputPassword.Text);

            if (isSuccess)
            {
                MessageBox.Show("Success");
                this.Hide();
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signup = new SignupForm();
            signup.Show();
        }

        private void showPasswordState(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                inputPassword.UseSystemPasswordChar = false;
            }
            else
            {
                inputPassword.UseSystemPasswordChar = true;
            }
        }

        private void showCheckBox(object sender, EventArgs e)
        {
            showPassword.Visible = true;
        }
    }
}
