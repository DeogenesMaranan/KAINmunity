﻿using System;
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
    }
}
