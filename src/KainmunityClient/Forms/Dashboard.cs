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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private async void firstName_Click(object sender, EventArgs e)
        {
        }

        private void donationBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            DonationForm donation = new DonationForm();
            donation.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var res = await AccountManager.GetAccountInfo();

            if (res.ContainsKey("UserFirstName"))
            {
                string userFirstName = res["UserFirstName"] as string;
                if (userFirstName != null)
                {
                    MessageBox.Show($"User First Name: {userFirstName}");
                }
                else
                {
                    MessageBox.Show("UserFirstName is null");
                }
            }
            else
            {
                MessageBox.Show("UserFirstName not found in response");
            }
        }


    }
}
