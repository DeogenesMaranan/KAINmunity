using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.Models;
using KainmunityClient.ServerAPI;

namespace KainmunityClient.Forms
{
    public partial class RequestForm : Form
    {
        private class DonationEntry
        {
            public int DonationId { get; set; }
            public TextBox RequestQuantityTextBox { get; set; }
        }

        private List<DonationEntry> _donationEntries = new List<DonationEntry>();

        public RequestForm()
        {
            InitializeComponent();
        }

        private async void FetchDonations(object sender, EventArgs e)
        {
            var donations = await DonationManager.GetDonations();

            if (donations == null)
            {
                MessageBox.Show("Failed to fetch donations.");
                return;
            }

            foreach (DonationItem donation in donations)
            {
                AddListItem(donation.DonationId, donation.ExpiryDate, donation.Name, donation.Quantity);
            }
        }

        private void AddListItem(int itemId, string expiration, string itemName, int availableQuantity)
        {
            TextBox requestQuantityPlace = new TextBox();
            requestQuantityPlace.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            requestQuantityPlace.Name = $"requestQuantity_{itemId}";
            requestQuantityPlace.Size = new Size(137, 21);
            requestQuantityPlace.TextAlign = HorizontalAlignment.Center;

            TextBox availableQuantityPlace = new TextBox();
            availableQuantityPlace.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            availableQuantityPlace.BorderStyle = BorderStyle.None;
            availableQuantityPlace.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            availableQuantityPlace.Name = $"quantitySection_{itemId}";
            availableQuantityPlace.Size = new Size(137, 21);
            availableQuantityPlace.ReadOnly = true;
            availableQuantityPlace.Text = availableQuantity.ToString();
            availableQuantityPlace.TextAlign = HorizontalAlignment.Center;

            TextBox expiryPlace = new TextBox();
            expiryPlace.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            expiryPlace.BorderStyle = BorderStyle.None;
            expiryPlace.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            expiryPlace.Name = $"expirySection_{itemId}";
            expiryPlace.Size = new Size(137, 21);
            expiryPlace.ReadOnly = true;
            expiryPlace.Text = expiration.Split(' ')[0]; ;
            expiryPlace.TextAlign = HorizontalAlignment.Center;

            TextBox namePlace = new TextBox();
            namePlace.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            namePlace.BorderStyle = BorderStyle.None;
            namePlace.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            namePlace.Name = $"nameSection_{itemId}";
            namePlace.Size = new Size(137, 21);
            namePlace.ReadOnly = true;
            namePlace.Text = itemName;

            TableLayoutPanel entriesPlace = new TableLayoutPanel();
            entriesPlace.ColumnCount = 4;
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.Controls.Add(requestQuantityPlace, 3, 0);
            entriesPlace.Controls.Add(availableQuantityPlace, 2, 0);
            entriesPlace.Controls.Add(expiryPlace, 1, 0);
            entriesPlace.Controls.Add(namePlace, 0, 0);
            entriesPlace.Name = $"requestPlaceholder_{itemId}";
            entriesPlace.RowCount = 1;
            entriesPlace.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            entriesPlace.Size = new Size(574, 27);
            entriesPlace.TabIndex = 10;

            flowLayoutPanel.Controls.Add(entriesPlace);

            _donationEntries.Add(new DonationEntry()
            {
                DonationId = itemId,
                RequestQuantityTextBox = requestQuantityPlace,
            });
        }

        private async void UploadRequests(object sender, EventArgs e)
        {
            var donationRequests = new List<DonationRequest>();
            foreach (var entry in _donationEntries)
            {
                if (entry.RequestQuantityTextBox.Text.Length == 0) continue;

                donationRequests.Add(new DonationRequest()
                {
                    DonationId = entry.DonationId,
                    Quantity = Convert.ToInt32(entry.RequestQuantityTextBox.Text),
                });
            }

            var isSuccess = await DonationManager.UploadRequests(donationRequests);
            
            if (isSuccess)
            {
                MessageBox.Show("Requests uploaded successfully.");
                ReturnToDashboard();
            }
            else
            {
                MessageBox.Show("Requests failed to upload.");
            }
        }

        private void ReturnToDashboard(object sender = null, EventArgs e = null)
        {
            new DashboardForm().Show();
            Close();
        }
    }
}
