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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private async void regButton_Click(object sender, EventArgs e)
        {
            bool isSuccess = await AccountManager.CreateAccount(firstName.Text, lastName.Text, password.Text, email.Text, contactNumber.Text, address.Text, Convert.ToDouble(income.Text), Convert.ToInt32(size.Text));

            if (isSuccess)
            {
                this.Hide();
                MessageBox.Show("You can now login haha");
                LoginForm login = new LoginForm();
                login.Show();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }


        private void showPassword_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar == true)
            {
                showPassword.BackgroundImage = Properties.Resources.eye;
                password.UseSystemPasswordChar = false;
            }
            else
            {
                showPassword.BackgroundImage = Properties.Resources.show;
                password.UseSystemPasswordChar = true;
            }
        }

        private void showIcons(object sender, EventArgs e)
        {
            showPassword.Visible = true;
        }
    }
}
