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
            emailAddress.Focus();
            emailAddress.Enabled = false;
        }

        private async void FillUpInformation(object sender, EventArgs e)
        {
            APIConnector.UserId = Convert.ToString(2); // TK: Delete line after finishing the form
            var info = await AccountManager.GetAccountInfo();

            firstName.Text = Convert.ToString(info["UserFirstName"]);
            lastName.Text = Convert.ToString(info["UserLastName"]);
            emailAddress.Text = Convert.ToString(info["UserEmailAddress"]);
            contactNumber.Text = Convert.ToString(info["UserContactNumber"]);
            homeAddress.Text = Convert.ToString(info["UserHomeAddress"]);
            yearlyIncome.Text = Convert.ToString(info["UserYearlyIncome"]);
            householdSize.Text = Convert.ToString(info["UserHouseholdSize"]);

            emailAddress.Enabled = true;
            homeAddress.Enabled = true;
            yearlyIncome.Enabled = true;
            householdSize.Enabled = true;
        }

        private async void UploadInformation(object sender, EventArgs e)
        {
            var isSuccess = await AccountManager.EditAccount(
                firstName.Text,
                lastName.Text,
                "123123123", // TK: Change to password.Text after creating field for changing password
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
    }
}
