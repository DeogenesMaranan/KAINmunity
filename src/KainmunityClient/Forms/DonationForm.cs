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
        private async void donateButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
            bool isSuccess = await DonationManager.AddDonation(donationName.Text, Convert.ToInt32(donationQuanity.Text), formattedDateTime);

            if (isSuccess)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
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
    }
}
