using KainmunityClient.ServerAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.Models;

namespace KainmunityClient.Forms
{
    public partial class RequestApprovalForm : Form
    {
        class RequestEntry
        {
            public bool StatusChanged { get; set; }
            public int RequestId { get; set; }
            public int RequesterId { get; set; }
            public int DonationId { get; set; }
            public int RequestQuantity { get; set; }
            public TextBox NameTextBox { get; set; }
            public TextBox DonationTextBox { get; set; }
            public ComboBox StatusComboBox { get; set; }
        }

        private List<RequestEntry> _requestEntries = new List<RequestEntry>();

        public RequestApprovalForm()
        {
            InitializeComponent();
        }

        private async void FetchRequests(object sender, EventArgs e)
        {
            var requests = await DonationManager.GetRequests();

            foreach (var request in requests)
            {
                int requestId = Convert.ToInt32(request["RequestId"]);
                int requesterId = Convert.ToInt32(request["RequesterId"]);
                string requesterName = Convert.ToString(request["RequesterName"]);
                int donationId = Convert.ToInt32(request["DonationId"]);
                string itemName = Convert.ToString(request["DonationName"]);
                int requestQuantity = Convert.ToInt32(request["RequestQuantity"]);
                string requestStatus = Convert.ToString(request["RequestStatus"]);

                AddRequestEntry(requestId, requesterId, requesterName, donationId, itemName, requestQuantity, requestStatus);
            }
        }

        private void AddRequestEntry(int requestId, int requesterId, string requesterName, int donationId, string itemName, int itemQuantity, string requestStatus)
        {
            TextBox nameTextBox = new TextBox();
            nameTextBox.Text = requesterName;
            nameTextBox.Size = new Size(224, 20);
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            nameTextBox.ReadOnly = true;
            nameTextBox.Name = $"name_{requestId}";

            TextBox itemTextBox = new TextBox();
            itemTextBox.Text = itemName;
            itemTextBox.Size = new Size(137, 20);
            itemTextBox.TextAlign = HorizontalAlignment.Center;
            itemTextBox.ReadOnly = true;
            itemTextBox.Name = $"item_{requestId}";

            TextBox quantityTextBox = new TextBox();
            quantityTextBox.Text = Convert.ToString(itemQuantity);
            quantityTextBox.Size = new Size(80, 20);
            quantityTextBox.TextAlign = HorizontalAlignment.Center;
            quantityTextBox.ReadOnly = true;
            quantityTextBox.Name = $"quantity_{requestId}";

            ComboBox statusComboBox = new ComboBox();
            statusComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            statusComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            statusComboBox.Items.AddRange(new object[] { "Pending", "Accepted", "Declined" });
            statusComboBox.Text = requestStatus;
            statusComboBox.Size = new Size(110, 20);
            statusComboBox.Name = $"status_{requestId}";

            if (requestStatus != "Pending")
            {
                statusComboBox.Enabled = false;
            }

            TableLayoutPanel requestEntryLayout = new TableLayoutPanel();
            requestEntryLayout.Size = new Size(575, 27);
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            requestEntryLayout.Controls.Add(nameTextBox, 0, 0);
            requestEntryLayout.Controls.Add(itemTextBox, 1, 0);
            requestEntryLayout.Controls.Add(quantityTextBox, 2, 0);
            requestEntryLayout.Controls.Add(statusComboBox, 3, 0);

            flowLayoutPanel1.Controls.Add(requestEntryLayout);

            var requestEntry = new RequestEntry
            {
                StatusChanged = false,
                RequestId = requestId,
                RequesterId = requesterId,
                DonationId = donationId,
                RequestQuantity = itemQuantity,
                NameTextBox = nameTextBox,
                DonationTextBox = itemTextBox,
                StatusComboBox = statusComboBox
            };

            int requestIndex = _requestEntries.Count;
            _requestEntries.Add(requestEntry);

            statusComboBox.SelectedIndexChanged += delegate (object sender, EventArgs e)
            {
                _requestEntries[requestIndex].StatusChanged = true;
            };

            nameTextBox.Click += delegate (object sender, EventArgs e)
            {
                new UserProfileForm(Convert.ToString(requesterId), true).Show();
            };
        }

        private async void UploadStatusChanges(object sender, EventArgs e)
        {
            var updatedEntries = new List<DonationRequest>();

            foreach (var requestEntry in _requestEntries)
            {
                if (requestEntry.StatusChanged)
                {
                    var request = new DonationRequest
                    {
                        RequestId = requestEntry.RequestId,
                        RequesterId = requestEntry.RequesterId,
                        DonationId = requestEntry.DonationId,
                        Quantity = requestEntry.RequestQuantity,
                        Status = requestEntry.StatusComboBox.Text,
                    };

                    updatedEntries.Add(request);
                }
            }

            var res = await DonationManager.UpdateRequests(updatedEntries);

            MessageBox.Show(res ? "Success" : "Failed");

            this.Hide();
            new RequestApprovalForm().Show();
        }

        private void ReturnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            new DashboardForm().Show();
        }
    }
}
