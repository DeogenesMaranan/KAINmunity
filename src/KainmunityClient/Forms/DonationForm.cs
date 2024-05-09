using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.ServerAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace KainmunityClient.Forms
{
    public partial class DonationForm : Form
    {
        public DonationForm()
        {
            InitializeComponent();
        }

        private static bool IsNotBlank(string text)
        {
            return ErrorHandling.IsNotBlank(text);
        }
        private static bool IsNumber(string text)
        {
            return ErrorHandling.IsNumber(text);
        }

        private async void donateButton_Click(object sender, EventArgs e)
        {
            if (IsNotBlank(donationName.Text) && IsNotBlank(donationQuanity.Text) && IsNumber(donationQuanity.Text))
            {
                DateTime selectedDateTime = dateTimePicker1.Value;
                string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
                bool isSuccess = await DonationManager.AddDonation(donationName.Text, Convert.ToInt32(donationQuanity.Text), formattedDateTime);

                if (isSuccess)
                {
                    statusText.ForeColor = Color.Green;
                    statusText.Text = "Thank you for donating!";
                }
                else
                {
                    statusText.ForeColor = Color.Red;
                    statusText.Text = "Failed to process your donation.";
                }
            } else
            {
                statusText.ForeColor = Color.Red;
                statusText.Text = "Please follow a proper format or don't leave blank spaces.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
        }

        private void DonationForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
