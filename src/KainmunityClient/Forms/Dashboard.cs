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

namespace KainmunityClient.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // await AccountManager.GetAccountInfo();
        }

        private void firstName_Click(object sender, EventArgs e)
        {
        }

        private void donationBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            DonationForm donation = new DonationForm();
            donation.Show();
        }
    }
}
