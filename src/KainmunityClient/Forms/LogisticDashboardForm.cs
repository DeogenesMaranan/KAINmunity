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
    public partial class LogisticDashboardForm : Form
    {
        public LogisticDashboardForm()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            var res = await AccountManager.GetAccountInfo();
            string name = res["UserFirstName"] as string;
            firstName.Text = $"WELCOME, {name}";
        }

        private async void GetAccepted(object sender, EventArgs e)
        {
            var requested = await LogisticManager.FetchAcceptedRequest();
            var donated = await LogisticManager.FetchAcceptedDonation();

            foreach (var request in requested)
            {
                int requestId = Convert.ToInt32(request["RequestId"]);
                string requesterName = Convert.ToString(request["RequesterName"]);
                string itemName = Convert.ToString(request["DonationName"]);
                int requestQuantity = Convert.ToInt32(request["RequestQuantity"]);
                int userId = Convert.ToInt32(request["RequesterId"]);
                ShowRequest(requestId, requesterName, itemName, requestQuantity, userId);
            }

            foreach (var donation in donated)
            {
                int donationId = Convert.ToInt32(donation["DonationId"]);
                string donorName = Convert.ToString(donation["DonorName"]);
                string donationItemName = Convert.ToString(donation["DonationName"]);
                int donationQuantity = Convert.ToInt32(donation["DonationOriginalQuantity"]);
                int userId = Convert.ToInt32(donation["DonorId"]);
                ShowDonation(donationId, donorName, donationItemName, donationQuantity, userId);
            }
        }

        private TableLayoutPanel CreateEntry(int donationId, string donorName, string donationItemName, int donationQuantity)
        {
            TextBox nameTb = new TextBox();
            nameTb.BackColor = Color.FromArgb(255, 246, 207);
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTb.Location = new Point(3, 6);
            nameTb.Name = $"name_{donationId}";
            nameTb.ReadOnly = true;
            nameTb.Size = new Size(199, 18);
            nameTb.TabIndex = 0;
            nameTb.TextAlign = HorizontalAlignment.Center;
            nameTb.Text = donorName;

            TextBox itemtb = new TextBox();
            itemtb.BackColor = Color.FromArgb(255, 246, 207);
            itemtb.BorderStyle = BorderStyle.None;
            itemtb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemtb.Location = new Point(2, 4);
            itemtb.Name = $"item_{donationId}";
            itemtb.ReadOnly = true;
            itemtb.Size = new Size(147, 18);
            itemtb.TabIndex = 0;
            itemtb.TextAlign = HorizontalAlignment.Center;
            itemtb.Text = donationItemName;

            TextBox quantityTb = new TextBox();
            quantityTb.BackColor = Color.FromArgb(255, 246, 207);
            quantityTb.BorderStyle = BorderStyle.None;
            quantityTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityTb.Location = new Point(3, 6);
            quantityTb.Name = $"quantity_{donationId}";
            quantityTb.ReadOnly = true;
            quantityTb.Size = new Size(93, 18);
            quantityTb.TabIndex = 0;
            quantityTb.TextAlign = HorizontalAlignment.Center;
            quantityTb.Text = donationQuantity.ToString();

            Button acceptBtn = new Button();
            acceptBtn.BackColor = Color.FromArgb(0, 60, 67);
            acceptBtn.FlatAppearance.BorderSize = 0;
            acceptBtn.FlatStyle = FlatStyle.Flat;
            acceptBtn.ForeColor = SystemColors.Window;
            acceptBtn.Name = $"resolveBtn_{donationId}";
            acceptBtn.Size = new Size(109, 39);
            acceptBtn.Text = "ACCEPT";
            acceptBtn.UseVisualStyleBackColor = false;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(255, 246, 207);
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{donationId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(255, 246, 207);
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{donationId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(255, 246, 207);
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = $"quantityPanel_{donationId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            TableLayoutPanel donationContainer = new TableLayoutPanel();
            donationContainer.ColumnCount = 4;
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            donationContainer.Controls.Add(quantityPanel, 2, 0);
            donationContainer.Controls.Add(itemPanel, 1, 0);
            donationContainer.Controls.Add(namePanel, 0, 0);
            donationContainer.Controls.Add(acceptBtn, 3, 0);
            donationContainer.Location = new Point(0, 0);
            donationContainer.Margin = new Padding(0);
            donationContainer.Name = $"requestEntryContainer_{donationId}";
            donationContainer.RowCount = 1;
            donationContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            donationContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            donationContainer.Size = new Size(582, 35);
            donationContainer.TabIndex = 3;

            return donationContainer;
        }

        private void ShowDonation(int donationId, string donorName, string donationItemName, int donationQuantity, int userId)
        {
            TableLayoutPanel entry = CreateEntry(donationId, donorName, donationItemName, donationQuantity);
            donationsContainer.Controls.Add(entry);
            Button acceptBtn = entry.GetControlFromPosition(3, 0) as Button;
            Panel namePanel = entry.GetControlFromPosition(0, 0) as Panel;
            TextBox nametb = namePanel.Controls[0] as TextBox;
            Panel itemPanel = entry.GetControlFromPosition(1, 0) as Panel;
            TextBox itemtb = itemPanel.Controls[0] as TextBox;

            acceptBtn.Click += async (sender, e) =>
            {
                var updateDonate = await LogisticManager.UpdateDonationStatus(donationId);
                bool isSuccess = await LogisticManager.AddDeliveryDonation(donationId);
                if (isSuccess && updateDonate)
                {
                    this.Hide();
                    LogisticDashboardForm form = new LogisticDashboardForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };

            nametb.Click += delegate (object sender, EventArgs e)
            {
                ShowDetails(userId);
            };

            itemtb.Click += delegate (object sender, EventArgs e)
            {
                this.Hide();
                new DonationDetails(this, donationId).Show();
            };
        }

        private void ShowRequest(int requestId, string requesterName, string itemName, int requestQuantity, int userId)
        {
            TableLayoutPanel entry = CreateEntry(requestId, requesterName, itemName, requestQuantity);
            requestsContainer.Controls.Add(entry);
            Button acceptBtn = entry.GetControlFromPosition(3, 0) as Button;
            Panel namePanel = entry.GetControlFromPosition(0, 0) as Panel;
            TextBox nametb = namePanel.Controls[0] as TextBox;

            acceptBtn.Click += async (sender, e) =>
            {
                var updateRequest = await LogisticManager.UpdateRequestStatus(requestId);
                bool isSuccess = await LogisticManager.AddDeliveryRequest(requestId);
                if (isSuccess && updateRequest)
                {
                    this.Hide();
                    LogisticDashboardForm form = new LogisticDashboardForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };

            nametb.Click += delegate (object sender, EventArgs e)
            {
                ShowDetails(userId);
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

        private void hideDetails_Click(object sender, EventArgs e)
        {
            mainPanel.Location = new System.Drawing.Point(111, 83);
            detailsPanel.Visible = false;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void openDelivery_Click(object sender, EventArgs e)
        {
            this.Hide();
            AcceptedDeliveryForm acceptedForm = new AcceptedDeliveryForm();
            acceptedForm.Show();
        }
    }
}