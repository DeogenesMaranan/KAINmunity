using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.ServerAPI;

namespace KainmunityClient.Forms
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private async void FillUpInformation(object sender, EventArgs e)
        {
            var info = await AccountManager.GetAccountInfo();

            firstName.Text = Convert.ToString(info["UserFirstName"]);
            lastName.Text = Convert.ToString(info["UserLastName"]);
            emailAddress.Text = Convert.ToString(info["UserEmailAddress"]);
            contactNumber.Text = Convert.ToString(info["UserContactNumber"]);
            homeAddress.Text = Convert.ToString(info["UserHomeAddress"]);
            yearlyIncome.Text = Convert.ToString(info["UserYearlyIncome"]);
            householdSize.Text = Convert.ToString(info["UserHouseholdSize"]);
            password.Text = Convert.ToString(info["UserPassword"]);

            emailAddress.Enabled = true;
            homeAddress.Enabled = true;
            yearlyIncome.Enabled = true;
            householdSize.Enabled = true;
            password.Enabled = true;
        }

        private async void UploadInformation(object sender, EventArgs e)
        {
            var isSuccess = await AccountManager.EditAccount(
                firstName.Text,
                lastName.Text,
                password.Text,
                emailAddress.Text,
                contactNumber.Text,
                homeAddress.Text,
                Convert.ToDouble(yearlyIncome.Text),
                Convert.ToInt32(householdSize.Text)
                );

            if (isSuccess)
            {
                MessageBox.Show("Account edited successfully.");
            }
            else
            {
                MessageBox.Show("Account failed to edit.");
            }
        }

        private void ReturnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void showPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void showCheckBox(object sender, EventArgs e)
        {
            showPassword.Visible = true;
        }
    }
}
