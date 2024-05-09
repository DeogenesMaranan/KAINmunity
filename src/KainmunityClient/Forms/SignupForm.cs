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
            }
            else
            {
                return false;
            }
        }

        private static bool IsNumber(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsNotBlank(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8)
        {
            if (string.IsNullOrWhiteSpace(text1) ||
                string.IsNullOrWhiteSpace(text2) ||
                string.IsNullOrWhiteSpace(text3) ||
                string.IsNullOrWhiteSpace(text4) ||
                string.IsNullOrWhiteSpace(text5) ||
                string.IsNullOrWhiteSpace(text6) ||
                string.IsNullOrWhiteSpace(text7) ||
                string.IsNullOrWhiteSpace(text8))
            {
                return false;
            }

            return true;
        }


        private async void regButton_Click(object sender, EventArgs e)
        {
            if (IsNotBlank(firstName.Text, lastName.Text, password.Text, email.Text, contactNumber.Text, address.Text, income.Text, size.Text))
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
                        statusText.Text = "Failed to register your account. Please Try again.";
                    }
                }
                else
                {
                    statusText.Text = "Please follow a proper format for each input box.";
                }
            }
            else
            {
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
