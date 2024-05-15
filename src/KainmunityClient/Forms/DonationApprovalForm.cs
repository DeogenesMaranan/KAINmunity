using KainmunityClient.ServerAPI;
using Newtonsoft.Json;
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

namespace KainmunityClient.Forms
{
    public partial class DonationApprovalForm : Form
    {
        public DonationApprovalForm()
        {
            InitializeComponent();
        }

        private async void FetchPendingDonations(object sender, EventArgs e)
        {
            var donations = await DonationManager.GetPendingDonations();

            if (donations == null)
            {
                MessageBox.Show("Failed to fetch donations.");
                return;
            }

            foreach (var donation in donations)
            {
                int donationId = Convert.ToInt32(donation["DonationId"]);
                string donationDate = Convert.ToString(donation["DonationDate"]).Remove(10);
                string donorName = Convert.ToString(donation["DonorName"]);
                string itemName = Convert.ToString(donation["DonationName"]);
                int quantity = Convert.ToInt32(donation["DonationQuantity"]);
                string expiryDate = Convert.ToString(donation["DonationExpiry"]).Remove(10);

                ListAllPendingDonations(donationId, donationDate, donorName, itemName, quantity, expiryDate);
            }


        }

        public void ListAllPendingDonations(int donationId, string donationDate, string donorName, string itemName, int availableQuantity, string expirationDate)
        {
            var entryPlaceholder = new TableLayoutPanel();
            var aQuan = new Panel();
            var aQuantb = new TextBox();
            var inamepanel = new Panel();
            var inametb = new TextBox();
            var ddatepanel = new Panel();
            var ddatetb = new TextBox();
            var exdatepanel = new Panel();
            var exdatetb = new TextBox();
            var dnamePanel = new Panel();
            var dnametb = new TextBox();
            var accptbtn = new Button();

            accptbtn.BackColor =Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            accptbtn.FlatAppearance.BorderSize = 0;
            accptbtn.FlatStyle = FlatStyle.Flat;
            accptbtn.ForeColor =Color.White;
            accptbtn.Name = $"accptbtn_{donationId}";
            accptbtn.Size = new Size(58, 28);
            accptbtn.Text = "✔";
            accptbtn.UseVisualStyleBackColor = false;

            entryPlaceholder.ColumnCount = 6;
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            entryPlaceholder.Controls.Add(dnamePanel, 0, 0);
            entryPlaceholder.Controls.Add(aQuan, 2, 0);
            entryPlaceholder.Controls.Add(inamepanel, 1, 0);
            entryPlaceholder.Controls.Add(ddatepanel, 0, 0);
            entryPlaceholder.Controls.Add(exdatepanel, 3, 0);
            entryPlaceholder.Controls.Add(accptbtn, 5, 0);
            entryPlaceholder.Location = new Point(3, 3);
            entryPlaceholder.Name = $"entryPlaceholder_{donationId}";
            entryPlaceholder.RowCount = 1;
            entryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            entryPlaceholder.Size = new Size(753, 34);

            aQuan.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            aQuan.Controls.Add(aQuantb);
            aQuan.Dock = DockStyle.Fill;
            aQuan.Name = $"aQuan_{donationId}";
            aQuan.TabIndex = 2;

            aQuantb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            aQuantb.BorderStyle = BorderStyle.None;
            aQuantb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            aQuantb.Location = new Point(3, 5);
            aQuantb.Name = $"aQuantb_{donationId}";
            aQuantb.ReadOnly = true;
            aQuantb.Size = new Size(66, 18);
            aQuantb.TabIndex = 2;
            aQuantb.TextAlign = HorizontalAlignment.Center;
            aQuantb.Text = availableQuantity.ToString();

            inamepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inamepanel.Controls.Add(inametb);
            inamepanel.Dock = DockStyle.Fill;
            inamepanel.Name = $"inamepanel_{donationId}";
            inamepanel.TabIndex = 1;

            inametb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inametb.BorderStyle = BorderStyle.None;
            inametb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            inametb.Location = new Point(3, 5);
            inametb.Name = $"inametb_{donationId}";
            inametb.ReadOnly = true;
            inametb.Size = new Size(186, 18);
            inametb.TabIndex = 1;
            inametb.TextAlign = HorizontalAlignment.Center;
            inametb.Text = itemName;

            ddatepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatepanel.Controls.Add(ddatetb);
            ddatepanel.Dock = DockStyle.Fill;
            ddatepanel.Name = $"ddatepanel_{donationId}";
            ddatepanel.TabIndex = 0;

            ddatetb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatetb.BorderStyle = BorderStyle.None;
            ddatetb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ddatetb.Location = new Point(0, 5);
            ddatetb.Name = $"ddatetb_{donationId}";
            ddatetb.ReadOnly = true;
            ddatetb.Size = new Size(103, 18);
            ddatetb.TabIndex = 0;
            ddatetb.TextAlign = HorizontalAlignment.Center;
            ddatetb.Text = donationDate;

            exdatepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            exdatepanel.Controls.Add(exdatetb);
            exdatepanel.Dock = DockStyle.Fill;
            exdatepanel.Name = $"exdatepanel_{donationId}";
            exdatepanel.TabIndex = 7;

            exdatetb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            exdatetb.BorderStyle = BorderStyle.None;
            exdatetb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            exdatetb.Location = new Point(3, 5);
            exdatetb.Name = $"exdatetb_{donationId}";
            exdatetb.ReadOnly = true;
            exdatetb.Size = new Size(103, 18);
            exdatetb.TabIndex = 2;
            exdatetb.TextAlign = HorizontalAlignment.Center;
            exdatetb.Text = expirationDate;

            dnamePanel.BackColor =Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            dnamePanel.Controls.Add(dnametb);
            dnamePanel.Dock = DockStyle.Fill;
            dnamePanel.Name = $"eedt_{donationId}";
            dnamePanel.TabIndex = 8;

            dnametb.BackColor =Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            dnametb.BorderStyle = BorderStyle.None;
            dnametb.Font = new Font("Tw Cen MT", 12F,FontStyle.Regular,GraphicsUnit.Point, ((byte)(0)));
            dnametb.Location = new Point(3, 5);
            dnametb.Name = $"edname_{donationId}";
            dnametb.ReadOnly = true;
            dnametb.Size = new Size(186, 18);
            dnametb.TabIndex = 2;
            dnametb.TextAlign = HorizontalAlignment.Center;
            dnametb.Text = donorName;

            donationsPlaceholder.Controls.Add(entryPlaceholder);
        }

        private void returnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
        }
    }
}
