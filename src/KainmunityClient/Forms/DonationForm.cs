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

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private async void donateButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
            bool isSuccess = await AccountManager.AddDonation(Convert.ToInt32(donorId.Text), donationName.Text, Convert.ToInt32(donationQuanity.Text), formattedDateTime);

            if (isSuccess)
            {
                this.Hide();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
