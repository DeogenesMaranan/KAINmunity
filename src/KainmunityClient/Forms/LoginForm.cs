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
            return ErrorHandling.IsContactNumber(text);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (IsContactNumber(inputContactNumber.Text))
            {
                invalidContact.Text = "";
                bool isSuccess = await AccountManager.VerifyLogin(inputContactNumber.Text, inputPassword.Text);

                if (isSuccess)
                {
                    if (APIConnector.AccountType == "Logistics")
                    {
                        invalidPass.Text = "";
                        this.Hide();
                        LogisticDashboardForm dashboard = new LogisticDashboardForm();
                        dashboard.Show();
                    }
                    else
                    {
                        invalidPass.Text = "";
                        this.Hide();
                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();
                    }
                }
                else
                {
                    invalidPass.ForeColor = Color.Red;
                    invalidPass.Text = "Wrong password";
                }
            }
            else
            {
                invalidContact.ForeColor = Color.Red;
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
