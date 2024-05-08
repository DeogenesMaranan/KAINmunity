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
using System.Text.Json;

namespace KainmunityClient.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            var res = await AccountManager.GetAccountInfo();
            firstName.Text = res["UserFirstName"] as string;
        }
        private void donationBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            DonationForm donation = new DonationForm();
            donation.Show();
        }
        private void requestButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (APIConnector.AccountType == "Admin")
            {
                new RequestApprovalForm().Show();
            }
            else
            {
                new RequestForm().Show();
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
        private void Dashboard_Load_1(object sender, EventArgs e)
        {

        }
        private void firstName_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserProfileForm(APIConnector.UserId).Show();
        }

        private void showFeedbackButton_Click(object sender, EventArgs e)
        {
            if (APIConnector.AccountType == "Admin")
            {
                this.Hide();
                new DisplayFeedbackForm().Show();
            }
            else
            {
                if (feedbackPanel.Visible)
                {
                    feedbackPanel.Visible = false;
                }
                else
                {
                    feedbackPanel.Visible = true;
                }
            }
        }

        private async void sendFeedback(object sender, EventArgs e)
        {
            bool isSuccess = await FeedbackManager.AddFeedback(feedbackTextBox.Text);
            if (isSuccess)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
