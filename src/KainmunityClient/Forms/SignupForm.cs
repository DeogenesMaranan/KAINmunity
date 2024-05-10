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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private static bool IsContactNumber(string text)
        {
            return ErrorHandling.IsContactNumber(text);
        }

        private static bool IsNumber(string text)
        {
            return ErrorHandling.IsNumber(text);
        }

        private static bool IsNotBlank(string text)
        {
            return ErrorHandling.IsNotBlank(text);
        }

        private async void regButton_Click(object sender, EventArgs e)
        {
            if (IsNotBlank(firstName.Text) ||
                IsNotBlank(lastName.Text) ||
                IsNotBlank(password.Text) ||
                IsNotBlank(email.Text) ||
                IsNotBlank(contactNumber.Text) ||
                IsNotBlank(address.Text) ||
                IsNotBlank(income.Text) ||
                IsNotBlank(size.Text))
            {
                if (IsContactNumber(contactNumber.Text) && IsNumber(income.Text) && IsNumber(size.Text))
                {
                    bool isSuccess = await AccountManager.CreateAccount(firstName.Text, lastName.Text, password.Text, email.Text, contactNumber.Text, address.Text, Convert.ToDouble(income.Text), Convert.ToInt32(size.Text));

                    if (isSuccess)
                    {
                        statusText.ForeColor = Color.Green;
                        statusText.Text = "You've registered!";
                    }
                    else
                    {
                        statusText.ForeColor = Color.Red;
                        statusText.Text = "Failed to register your account. Please Try again.";
                    }
                }
                else
                {
                    statusText.ForeColor = Color.Red;
                    statusText.Text = "Please follow a proper format for each input box.";
                }
            }
            else
            {
                statusText.ForeColor = Color.Red;
                statusText.Text = "Please complete all fields.";
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
