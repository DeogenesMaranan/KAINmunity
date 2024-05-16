using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KainmunityClient.ServerAPI;

namespace KainmunityClient.Forms
{
    public partial class AcceptedDeliveryForm : Form
    {
        public AcceptedDeliveryForm()
        {
            InitializeComponent();
        }

        private async void GetDelivery(object sender, EventArgs e)
        {
            int courierId = Convert.ToInt32(APIConnector.UserId);
            var requested = await LogisticManager.FetchRequestDelivery(courierId);
            var donated = await LogisticManager.FetchDonationDelivery(courierId);

            foreach (var request in requested)
            {
                int requestId = Convert.ToInt32(request["RequestId"]);
                string requesterName = Convert.ToString(request["RequesterName"]);
                string itemName = Convert.ToString(request["DonationName"]);
                int requestQuantity = Convert.ToInt32(request["RequestQuantity"]);
                string requestStatus = Convert.ToString(request["RequestStatus"]);
                int userId = Convert.ToInt32(request["RequesterId"]);
                int donationId = Convert.ToInt32(request["DonationId"]);
                if (requestStatus != "Delivery") continue;
                ShowRequest(requestId, requesterName, itemName, requestQuantity, userId, donationId);
            }

            foreach (var donate in donated)
            {
                int donationId = Convert.ToInt32(donate["DonationId"]);
                int userId = Convert.ToInt32(donate["DonorId"]);
                string donorName = Convert.ToString(donate["DonorName"]);
                string itemName = Convert.ToString(donate["DonationName"]);
                int donationQuantity = Convert.ToInt32(donate["DonationOriginalQuantity"]);
                string donationStatus = Convert.ToString(donate["DonationStatus"]);
                if (donationStatus != "Delivery") continue;
                ShowDonation(donationId, donorName, itemName, donationQuantity, userId);
            }
        }

        private TableLayoutPanel CreateEntry(int rowId, string name, string itemName, int quantity, int transactiontType)
        {
            TextBox nameTb = new TextBox();
            nameTb.BackColor = Color.FromArgb(255, 246, 207);
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTb.Location = new Point(3, 6);
            nameTb.Name = $"name_{rowId}";
            nameTb.ReadOnly = true;
            nameTb.Size = new Size(199, 18);
            nameTb.TabIndex = 0;
            nameTb.TextAlign = HorizontalAlignment.Center;
            nameTb.Text = name;

            TextBox itemtb = new TextBox();
            itemtb.BackColor = Color.FromArgb(255, 246, 207);
            itemtb.BorderStyle = BorderStyle.None;
            itemtb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemtb.Location = new Point(2, 4);
            itemtb.Name = $"item_{rowId}";
            itemtb.ReadOnly = true;
            itemtb.Size = new Size(147, 18);
            itemtb.TabIndex = 0;
            itemtb.TextAlign = HorizontalAlignment.Center;
            itemtb.Text = itemName;

            TextBox quantityTb = new TextBox();
            quantityTb.BackColor = Color.FromArgb(255, 246, 207);
            quantityTb.BorderStyle = BorderStyle.None;
            quantityTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityTb.Location = new Point(3, 6);
            quantityTb.Name = $"quantity_{rowId}";
            quantityTb.ReadOnly = true;
            quantityTb.Size = new Size(93, 18);
            quantityTb.TabIndex = 0;
            quantityTb.TextAlign = HorizontalAlignment.Center;
            quantityTb.Text = quantity.ToString();

            Button acceptBtn = new Button();
            acceptBtn.BackColor = Color.FromArgb(0, 60, 67);
            acceptBtn.FlatAppearance.BorderSize = 0;
            acceptBtn.FlatStyle = FlatStyle.Flat;
            acceptBtn.ForeColor = SystemColors.Window;
            acceptBtn.Name = $"resolveBtn_{rowId}";
            acceptBtn.Size = new Size(109, 39);
            acceptBtn.Text = (transactiontType == 2) ? "RECEIVED" : "DELIVERED";
            acceptBtn.UseVisualStyleBackColor = false;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(255, 246, 207);
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{rowId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(255, 246, 207);
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{rowId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(255, 246, 207);
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = $"quantityPanel_{rowId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            TableLayoutPanel container = new TableLayoutPanel();
            container.ColumnCount = 4;
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            container.Controls.Add(acceptBtn, 3, 0);
            container.Controls.Add(quantityPanel, 2, 0);
            container.Controls.Add(itemPanel, 1, 0);
            container.Controls.Add(namePanel, 0, 0);
            container.Location = new Point(0, 0);
            container.Margin = new Padding(0);
            container.Name = $"requestEntryContainer_{rowId}";
            container.RowCount = 1;
            container.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            container.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            container.Size = new Size(582, 35);
            container.TabIndex = 3;

            return container;
        }
        private void ShowRequest(int requestId, string requesterName, string itemName, int requestQuantity, int userId, int donationId)
        {
            TableLayoutPanel entry = CreateEntry(requestId, requesterName, itemName, requestQuantity, 1);
            requestsContainer.Controls.Add(entry);
            Button acceptBtn = entry.GetControlFromPosition(3, 0) as Button;
            Panel namePanel = entry.GetControlFromPosition(0, 0) as Panel;
            TextBox ntb = namePanel.Controls[0] as TextBox;
            Panel itemPanel = entry.GetControlFromPosition(1, 0) as Panel;
            TextBox itb = itemPanel.Controls[0] as TextBox;

            acceptBtn.Click += async (sender, e) =>
            {
                var updateRequest = await LogisticManager.FinishRequestStatus(requestId);
                if (updateRequest)
                {
                    this.Hide();
                    AcceptedDeliveryForm form = new AcceptedDeliveryForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };

            ntb.Click += delegate (object sender, EventArgs e)
            {
                ShowDetails(userId);
            };

            itb.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                new DonationDetails(this, donationId).Show();
            };
        }
        private void ShowDonation(int donationId, string donorName, string itemName, int donationQuantity, int userId)
        {
            TableLayoutPanel entry = CreateEntry(donationId, donorName, itemName, donationQuantity, 2);
            donationsContainer.Controls.Add(entry);
            Button acceptBtn = entry.GetControlFromPosition(3, 0) as Button;
            Panel namePanel = entry.GetControlFromPosition(0, 0) as Panel;
            TextBox ntb = namePanel.Controls[0] as TextBox;
            Panel itemPanel = entry.GetControlFromPosition(1, 0) as Panel;
            TextBox itb = itemPanel.Controls[0] as TextBox;

            acceptBtn.Click += async (sender, e) =>
            {
                var updateDonate = await LogisticManager.FinishDonationStatus(donationId);
                if (updateDonate)
                {
                    this.Hide();
                    AcceptedDeliveryForm form = new AcceptedDeliveryForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };

            ntb.Click += delegate (object sender, EventArgs e)
            {
                ShowDetails(userId);
            };

            itb.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                new DonationDetails(this, donationId).Show();
            };
        }

        private async void ShowDetails(int userId)
        {
            mainPanel.Location = new System.Drawing.Point(196, 83);
            detailsPanel.Visible = true;

            var info = await AccountManager.GetAccountInfo(userId.ToString());

            fname.Text = Convert.ToString(info["UserFirstName"]);
            lname.Text = Convert.ToString(info["UserLastName"]);
            eadd.Text = Convert.ToString(info["UserEmailAddress"]);
            cnum.Text = Convert.ToString(info["UserContactNumber"]);
            hadd.Text = Convert.ToString(info["UserHomeAddress"]);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogisticDashboardForm form = new LogisticDashboardForm();
            form.Show();
        }

        private void hideDescription(object sender, EventArgs e)
        {
            mainPanel.Location = new System.Drawing.Point(111, 83);
            detailsPanel.Visible = false;
        }
    }
}
