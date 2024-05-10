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
            TextBox nameTb = new TextBox();
            nameTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameTb.Location = new Point(3, 6);
            nameTb.Name = $"name_{requestId}";
            nameTb.ReadOnly = true;
            nameTb.Size = new Size(223, 18);
            nameTb.TabIndex = 0;
            nameTb.TextAlign = HorizontalAlignment.Center;
            nameTb.Text = requesterName;

            TextBox itemtb = new TextBox();
            itemtb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemtb.BorderStyle = BorderStyle.None;
            itemtb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemtb.Location = new Point(3, 6);
            itemtb.Name = $"item_{requestId}";
            itemtb.ReadOnly = true;
            itemtb.Size = new Size(136, 18);
            itemtb.TabIndex = 0;
            itemtb.TextAlign = HorizontalAlignment.Center;
            itemtb.Text = itemName;

            TextBox quantityTb = new TextBox();
            quantityTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityTb.BorderStyle = BorderStyle.None;
            quantityTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            quantityTb.Location = new Point(3, 6);
            quantityTb.Name = $"quantity_{requestId}";
            quantityTb.ReadOnly = true;
            quantityTb.Size = new Size(77, 18);
            quantityTb.TabIndex = 0;
            quantityTb.TextAlign = HorizontalAlignment.Center;
            quantityTb.Text = Convert.ToString(itemQuantity);

            ComboBox statusOption = new ComboBox();
            statusOption.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusOption.FlatStyle = FlatStyle.Flat;
            statusOption.FormattingEnabled = true;
            statusOption.Location = new Point(3, 5);
            statusOption.Name = "statusOption";
            statusOption.RightToLeft = RightToLeft.No;
            statusOption.Size = new Size(106, 21);
            statusOption.Name = $"status_{requestId}";
            statusOption.Text = requestStatus;
            statusOption.AutoCompleteMode = AutoCompleteMode.Suggest;
            statusOption.AutoCompleteSource = AutoCompleteSource.ListItems;
            statusOption.Items.AddRange(new object[] { "Pending", "Accepted", "Declined" });

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{requestId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{requestId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel statusPanel = new Panel();
            statusPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusPanel.Controls.Add(statusOption);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Location = new Point(467, 3);
            statusPanel.Name = $"statusPanel_{requestId}";
            statusPanel.Size = new Size(112, 29);
            statusPanel.TabIndex = 2;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = "quantityPanel_{requestId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            if (requestStatus != $"Pending")
            {
                statusOption.Enabled = false;
            }

            TableLayoutPanel requestEntryContainer = new TableLayoutPanel();
            requestEntryContainer.ColumnCount = 4;
            requestEntryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            requestEntryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            requestEntryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            requestEntryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            requestEntryContainer.Controls.Add(quantityPanel, 0, 0);
            requestEntryContainer.Controls.Add(statusPanel, 0, 0);
            requestEntryContainer.Controls.Add(namePanel, 0, 0);
            requestEntryContainer.Controls.Add(itemPanel, 0, 0);
            requestEntryContainer.Location = new Point(0, 0);
            requestEntryContainer.Margin = new Padding(0);
            requestEntryContainer.Name = $"requestEntryContainer_{requestId}";
            requestEntryContainer.RowCount = 1;
            requestEntryContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            requestEntryContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            requestEntryContainer.Size = new Size(582, 35);
            requestEntryContainer.TabIndex = 3;

            flowLayoutPanel1.Controls.Add(requestEntryContainer);

            var requestEntry = new RequestEntry
            {
                StatusChanged = false,
                RequestId = requestId,
                RequesterId = requesterId,
                DonationId = donationId,
                RequestQuantity = itemQuantity,
                NameTextBox = nameTb,
                DonationTextBox = itemtb,
                StatusComboBox = statusOption
            };

            int requestIndex = _requestEntries.Count;
            _requestEntries.Add(requestEntry);

            statusOption.SelectedIndexChanged += delegate (object sender, EventArgs e)
            {
                _requestEntries[requestIndex].StatusChanged = true;
            };

            nameTb.Click += delegate (object sender, EventArgs e)
            {
                new UserProfileForm(Convert.ToString(requesterId), true).Show();
            };

            itemtb.Click += delegate (object sender, EventArgs e)
            {
                Hide();
                new DonationDetails(this, donationId).Show();
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

            Hide();
            new RequestApprovalForm().Show();
        }

        private void ReturnToDashboard(object sender, EventArgs e)
        {
            Hide();
            new DashboardForm().Show();
        }
    }
}
