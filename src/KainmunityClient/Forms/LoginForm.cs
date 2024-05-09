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
using static System.Net.Mime.MediaTypeNames;

namespace KainmunityClient.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private static bool IsContactNumber(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                count++;
                if (!char.IsDigit(c))
                {
                    return false;
                }

                if (count == 1 && c != '0' || count == 2 && c != '9')
                {
                    return false;
                }
            }

            if (count == 11)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (IsContactNumber(inputContactNumber.Text))
            {
                invalidContact.Text = "";
                bool isSuccess = await AccountManager.VerifyLogin(inputContactNumber.Text, inputPassword.Text);

                if (isSuccess)
                {
                    invalidPass.Text = "";
                    this.Hide();
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                }
                else
                {
                    invalidPass.Text = "Wrong password";
                }
            }
            else
            {
                invalidContact.Text = "Invalid Format";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signup = new SignupForm();
            signup.Show();
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            if (inputPassword.UseSystemPasswordChar == true)
            {
                showPassword.BackgroundImage = Properties.Resources.eye;
                inputPassword.UseSystemPasswordChar = false;
            }
            else
            {
                showPassword.BackgroundImage = Properties.Resources.show;
                inputPassword.UseSystemPasswordChar = true;
            }
        }

        private void showIcons(object sender, EventArgs e)
        {
            showPassword.Visible = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
