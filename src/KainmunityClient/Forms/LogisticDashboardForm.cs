using KainmunityClient.ServerAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            firstName.Text = res["UserFirstName"] as string;
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
                showRequest(requestId, requesterName, itemName, requestQuantity);
            }

            foreach (var donation in donated)
            {
                int donationId = Convert.ToInt32(donation["DonationId"]);
                string donorName = Convert.ToString(donation["DonorName"]);
                string donationItemName = Convert.ToString(donation["DonationName"]);
                int donationQuantity = Convert.ToInt32(donation["DonationOriginalQuantity"]);
                showDonation(donationId, donorName, donationItemName, donationQuantity);
            }
        }
        private void showDonation(int donationId, string donorName, string donationItemName, int donationQuantity)
        {
            TextBox nameTb = new TextBox();
            nameTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameTb.Location = new Point(3, 6);
            nameTb.Name = $"name_{donationId}";
            nameTb.ReadOnly = true;
            nameTb.Size = new Size(223, 18);
            nameTb.TabIndex = 0;
            nameTb.TextAlign = HorizontalAlignment.Center;
            nameTb.Text = donorName;

            TextBox itemtb = new TextBox();
            itemtb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemtb.BorderStyle = BorderStyle.None;
            itemtb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemtb.Location = new Point(2, 4);
            itemtb.Name = $"item_{donationId}";
            itemtb.ReadOnly = true;
            itemtb.Size = new Size(136, 18);
            itemtb.TabIndex = 0;
            itemtb.TextAlign = HorizontalAlignment.Center;
            itemtb.Text = donationItemName;

            TextBox quantityTb = new TextBox();
            quantityTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityTb.BorderStyle = BorderStyle.None;
            quantityTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            quantityTb.Location = new Point(3, 6);
            quantityTb.Name = $"quantity_{donationId}";
            quantityTb.ReadOnly = true;
            quantityTb.Size = new Size(77, 18);
            quantityTb.TabIndex = 0;
            quantityTb.TextAlign = HorizontalAlignment.Center;
            quantityTb.Text = Convert.ToString(donationQuantity);

            Button resolveBtn = new Button();
            resolveBtn.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            resolveBtn.FlatAppearance.BorderSize = 0;
            resolveBtn.FlatStyle = FlatStyle.Flat;
            resolveBtn.ForeColor = SystemColors.Window;
            resolveBtn.Name = $"resolveBtn_{donationId}";
            resolveBtn.Size = new Size(109, 39);
            resolveBtn.Text = "ACCEPT";
            resolveBtn.UseVisualStyleBackColor = false;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{donationId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{donationId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = $"quantityPanel_{donationId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            TableLayoutPanel donationContainer = new TableLayoutPanel();
            donationContainer.ColumnCount = 4;
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            donationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            donationContainer.Controls.Add(quantityPanel, 0, 0);
            donationContainer.Controls.Add(itemPanel, 0, 0);
            donationContainer.Controls.Add(namePanel, 0, 0);
            donationContainer.Controls.Add(resolveBtn, 1, 0);
            donationContainer.Location = new Point(0, 0);
            donationContainer.Margin = new Padding(0);
            donationContainer.Name = $"requestEntryContainer_{donationId}";
            donationContainer.RowCount = 1;
            donationContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            donationContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            donationContainer.Size = new Size(582, 35);
            donationContainer.TabIndex = 3;

            donatedContainer.Controls.Add(donationContainer);

            resolveBtn.Click += async delegate (object sender, EventArgs e)
            {
                var res = await LogisticManager.UpdateDonationStatus(donationId);

                if (res)
                {
                    MessageBox.Show("Success");
                    new LogisticDashboardForm().Show();
                    this.Close();
                    // Not restarting
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };
        }

        private void showRequest(int requestId, string requesterName, string itemName, int requestQuantity)
        {
            // Request Panel
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
            itemtb.Location = new Point(2, 4);
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
            quantityTb.Text = Convert.ToString(requestQuantity);

            Button resolveBtn = new Button();
            resolveBtn.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            resolveBtn.FlatAppearance.BorderSize = 0;
            resolveBtn.FlatStyle = FlatStyle.Flat;
            resolveBtn.ForeColor = SystemColors.Window;
            resolveBtn.Name = $"resolveBtn_{requestId}";
            resolveBtn.Size = new Size(109, 39);
            resolveBtn.Text = "ACCEPT";
            resolveBtn.UseVisualStyleBackColor = false;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{requestId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{requestId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = $"quantityPanel_{requestId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            TableLayoutPanel requestContainer = new TableLayoutPanel();
            requestContainer.ColumnCount = 4;
            requestContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            requestContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            requestContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            requestContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            requestContainer.Controls.Add(quantityPanel, 0, 0);
            requestContainer.Controls.Add(itemPanel, 0, 0);
            requestContainer.Controls.Add(namePanel, 0, 0);
            requestContainer.Controls.Add(resolveBtn, 1, 0);
            requestContainer.Location = new Point(0, 0);
            requestContainer.Margin = new Padding(0);
            requestContainer.Name = $"requestEntryContainer_{requestId}";
            requestContainer.RowCount = 1;
            requestContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            requestContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            requestContainer.Size = new Size(582, 35);
            requestContainer.TabIndex = 3;

            requestedContainer.Controls.Add(requestContainer);

            resolveBtn.Click += async delegate (object sender, EventArgs e)
            {
                var res = await LogisticManager.UpdateRequestStatus(requestId);

                if (res)
                {
                    MessageBox.Show("Success");
                    new LogisticDashboardForm().Show();
                    this.Close();
                    // Not restarting
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };
        }
    }
}