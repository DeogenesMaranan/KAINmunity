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
        private readonly string _userId;
        private readonly bool _isViewer;
        public UserProfileForm(string userId, bool isViewer = false)
        {
            _userId = userId;
            _isViewer = isViewer;
            InitializeComponent();
        }

        private async void FillUpInformation(object sender, EventArgs e)
        {
            var info = await AccountManager.GetAccountInfo(_userId);

            firstName.Text = Convert.ToString(info["UserFirstName"]);
            lastName.Text = Convert.ToString(info["UserLastName"]);
            emailAddress.Text = Convert.ToString(info["UserEmailAddress"]);
            contactNumber.Text = Convert.ToString(info["UserContactNumber"]);
            homeAddress.Text = Convert.ToString(info["UserHomeAddress"]);
            yearlyIncome.Text = Convert.ToString(info["UserYearlyIncome"]);
            householdSize.Text = Convert.ToString(info["UserHouseholdSize"]);
            password.Text = Convert.ToString(info["UserPassword"]);

            if (!_isViewer)
            {
                emailAddress.ReadOnly = false;
                homeAddress.ReadOnly = false;
                yearlyIncome.ReadOnly = false;
                householdSize.ReadOnly = false;
                password.ReadOnly = false;
            }
            else
            {
                this.Controls.Remove(password);
                this.Controls.Remove(labelPassword);
                this.Controls.Remove(showPassword);
                this.Controls.Remove(save);
                password.Dispose();
                labelPassword.Dispose();
                showPassword.Dispose();
                save.Dispose();
            }

            this.Text = $"{firstName.Text} {lastName.Text}'s Profile";
            this.ActiveControl = null;
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
            if (_isViewer)
            {
                this.Close();
                return;
            }

            this.Hide();
            new DashboardForm().Show();
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

        private void showIcon(object sender, EventArgs e)
        {
            showPassword.Visible = true;
        }
    }
}
