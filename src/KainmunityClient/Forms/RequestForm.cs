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
            public int AvailableQuantity { get; set; }
        }

        private List<DonationEntry> _donationEntries = new List<DonationEntry>();

        public RequestForm()
        {
            InitializeComponent();
        }

        private async void FetchDonations(object sender, EventArgs e)
        {
            var donations = await DonationManager.GetDonations();
            var account = await AccountManager.GetAccountInfo();
            int currentUser = Convert.ToInt32(account["UserId"]);

            if (donations == null)
            {
                MessageBox.Show("Failed to fetch donations.");
                return;
            }

            foreach (DonationItem donation in donations)
            {
                if(donation.Status != "Received" || donation.DonorId == currentUser)
                {
                    continue;
                }
                AddListItem(donation.DonationId, donation.ExpiryDate, donation.Name, donation.Quantity);
            }
        }

        private void AddListItem(int itemId, string expiration, string itemName, int availableQuantity)
        {
            TextBox requestQuantityPlace = new TextBox();
            requestQuantityPlace.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            requestQuantityPlace.BorderStyle = BorderStyle.None;
            requestQuantityPlace.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            requestQuantityPlace.Name = $"requestQuantity_{itemId}";
            requestQuantityPlace.Size = new Size(137, 21);
            requestQuantityPlace.TextAlign = HorizontalAlignment.Center;
            requestQuantityPlace.Location = new Point(3, 5);
            requestQuantityPlace.TabIndex = 0;

            TextBox availableQuantityPlace = new TextBox();
            availableQuantityPlace.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            availableQuantityPlace.BorderStyle = BorderStyle.None;
            availableQuantityPlace.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            availableQuantityPlace.Name = $"quantitySection_{itemId}";
            availableQuantityPlace.Size = new Size(137, 21);
            availableQuantityPlace.ReadOnly = true;
            availableQuantityPlace.Text = availableQuantity.ToString();
            availableQuantityPlace.TextAlign = HorizontalAlignment.Center;
            availableQuantityPlace.Location = new Point(3, 5);

            TextBox expiryPlace = new TextBox();
            expiryPlace.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            expiryPlace.BorderStyle = BorderStyle.None;
            expiryPlace.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            expiryPlace.Name = $"expirySection_{itemId}";
            expiryPlace.Size = new Size(137, 21);
            expiryPlace.ReadOnly = true;
            expiryPlace.Text = expiration.Split(' ')[0]; ;
            expiryPlace.TextAlign = HorizontalAlignment.Center;
            expiryPlace.Location = new Point(3, 5);

            TextBox namePlace = new TextBox();
            namePlace.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePlace.BorderStyle = BorderStyle.None;
            namePlace.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            namePlace.Name = $"nameSection_{itemId}";
            namePlace.Size = new Size(137, 21);
            namePlace.ReadOnly = true;
            namePlace.Text = itemName;
            namePlace.Location = new Point(3, 5);
            namePlace.TextAlign = HorizontalAlignment.Center;

            Panel requestQuantityPanel = new Panel();
            requestQuantityPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            requestQuantityPanel.Controls.Add(requestQuantityPlace);
            requestQuantityPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            Panel availableQuantityPanel = new Panel();
            availableQuantityPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            availableQuantityPanel.Controls.Add(availableQuantityPlace);
            availableQuantityPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            Panel expiryPanel = new Panel();
            expiryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            expiryPanel.Controls.Add(expiryPlace);
            expiryPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            Panel namePanel = new Panel();
            namePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(namePlace);
            namePanel.Dock = System.Windows.Forms.DockStyle.Fill;

            TableLayoutPanel entriesPlace = new TableLayoutPanel();
            entriesPlace.ColumnCount = 4;
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entriesPlace.Controls.Add(requestQuantityPanel, 3, 0);
            entriesPlace.Controls.Add(availableQuantityPanel, 2, 0);
            entriesPlace.Controls.Add(expiryPanel, 1, 0);
            entriesPlace.Controls.Add(namePanel, 0, 0);
            entriesPlace.Name = $"requestPlaceholder_{itemId}";
            entriesPlace.RowCount = 1;
            entriesPlace.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            entriesPlace.Size = new Size(574, 37);
            entriesPlace.TabIndex = 10;

            flowLayoutPanel.Controls.Add(entriesPlace);

            _donationEntries.Add(new DonationEntry()
            {
                DonationId = itemId,
                RequestQuantityTextBox = requestQuantityPlace,
                AvailableQuantity = availableQuantity
            });

            namePlace.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                new DonationDetails(this, itemId).Show();
            };
        }
        private bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
        }

        private async void UploadRequests(object sender, EventArgs e)
        {
            var donationRequests = new List<DonationRequest>();
            bool isFormatted = true;
            foreach (var entry in _donationEntries)
            {
                if (entry.RequestQuantityTextBox.Text.Length == 0) continue;
                if (!IsNumber(entry.RequestQuantityTextBox.Text))
                {
                    isFormatted = false;
                    break;
                }

                int requestedQuantity = Convert.ToInt32(entry.RequestQuantityTextBox.Text);
                if (requestedQuantity > entry.AvailableQuantity)
                {
                    entry.RequestQuantityTextBox.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    isFormatted = false;
                    break;
                }

                donationRequests.Add(new DonationRequest()
                {
                    DonationId = entry.DonationId,
                    Quantity = requestedQuantity,
                });
            }

            if (!isFormatted)
            {
                MessageBox.Show("Please enter a valid number for each input box.");
            }
            else
            {
                var isSuccess = await DonationManager.UploadRequests(donationRequests);

                if (isSuccess)
                {
                    MessageBox.Show("You may now wait for the approval.");
                }
                else
                {
                    MessageBox.Show("Failed to process your request.");
                }
            }
        }

        private void ReturnToDashboard(object sender = null, EventArgs e = null)
        {
            new DashboardForm().Show();
            Close();
        }
    }
}
