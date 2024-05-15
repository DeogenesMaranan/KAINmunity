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
            var donations = await DonationManager.GetDonations();

            if (donations == null)
            {
                MessageBox.Show("Failed to fetch donations.");
                return;
            }

            foreach (DonationItem donation in donations)
            {
                if (donation.Status != "Pending")
                {
                    continue;
                }
                ListAllPendingDonations(donation.DonationId, donation.DonationDate, "TK donorName", donation.Name, donation.Quantity, donation.ExpiryDate);
            }


        }

        public void ListAllPendingDonations(int donationId, string donationDate, string donorName, string itemName, int availableQuantity, string expirationDate)
        {
            var entryPlaceholder = new TableLayoutPanel();
            var inamepanel = new Panel();
            var inametb = new TextBox();
            var dnamepanel = new Panel();
            var dnametb = new TextBox();
            var ddatepanel = new Panel();
            var ddatetb = new TextBox();
            var stockpanel = new Panel();
            var stocktb = new TextBox();
            var edatePanel = new Panel();
            var edatetb = new TextBox();
            var accptbtn = new Button();

            accptbtn.BackColor =Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            accptbtn.FlatAppearance.BorderSize = 0;
            accptbtn.FlatStyle = FlatStyle.Flat;
            accptbtn.ForeColor =Color.White;
            accptbtn.Location = new Point(615, 3);
            accptbtn.Name = "accptbtn";
            accptbtn.Size = new Size(65, 28);
            accptbtn.TabIndex = 9;
            accptbtn.Text = "✔";
            accptbtn.UseVisualStyleBackColor = false;

            entryPlaceholder.ColumnCount = 6;
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            entryPlaceholder.Controls.Add(edatePanel, 0, 0);
            entryPlaceholder.Controls.Add(inamepanel, 2, 0);
            entryPlaceholder.Controls.Add(dnamepanel, 1, 0);
            entryPlaceholder.Controls.Add(ddatepanel, 0, 0);
            entryPlaceholder.Controls.Add(stockpanel, 3, 0);
            entryPlaceholder.Controls.Add(accptbtn, 5, 0);
            entryPlaceholder.Location = new Point(3, 3);
            entryPlaceholder.Name = $"entryPlaceholder_{donationId}";
            entryPlaceholder.RowCount = 1;
            entryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            entryPlaceholder.Size = new Size(683, 34);
            entryPlaceholder.TabIndex = 26;

            inamepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inamepanel.Controls.Add(inametb);
            inamepanel.Dock = DockStyle.Fill;
            inamepanel.Name = $"inamepanel_{donationId}";
            inamepanel.TabIndex = 2;

            inametb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inametb.BorderStyle = BorderStyle.None;
            inametb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            inametb.Location = new Point(3, 5);
            inametb.Name = $"inametb_{donationId}";
            inametb.ReadOnly = true;
            inametb.Size = new Size(127, 18);
            inametb.TabIndex = 2;
            inametb.TextAlign = HorizontalAlignment.Center;
            inametb.Text = availableQuantity.ToString();

            dnamepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            dnamepanel.Controls.Add(dnametb);
            dnamepanel.Dock = DockStyle.Fill;
            dnamepanel.Name = $"dnamepanel_{donationId}";
            dnamepanel.TabIndex = 1;

            dnametb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            dnametb.BorderStyle = BorderStyle.None;
            dnametb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dnametb.Location = new Point(3, 5);
            dnametb.Name = $"dnametb_{donationId}";
            dnametb.ReadOnly = true;
            dnametb.Size = new Size(127, 18);
            dnametb.TabIndex = 1;
            dnametb.TextAlign = HorizontalAlignment.Center;
            dnametb.Text = itemName;

            ddatepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatepanel.Controls.Add(ddatetb);
            ddatepanel.Dock = DockStyle.Fill;
            ddatepanel.Name = $"ddatepanel_{donationId}";
            ddatepanel.TabIndex = 0;

            ddatetb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatetb.BorderStyle = BorderStyle.None;
            ddatetb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ddatetb.Location = new Point(5, 5);
            ddatetb.Name = $"ddatetb_{donationId}";
            ddatetb.ReadOnly = true;
            ddatetb.Size = new Size(122, 18);
            ddatetb.TabIndex = 0;
            ddatetb.TextAlign = HorizontalAlignment.Center;
            ddatetb.Text = donationDate;

            stockpanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            stockpanel.Controls.Add(stocktb);
            stockpanel.Dock = DockStyle.Fill;
            stockpanel.Name = $"stockpanel_{donationId}";
            stockpanel.TabIndex = 7;

            stocktb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            stocktb.BorderStyle = BorderStyle.None;
            stocktb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            stocktb.Location = new Point(3, 5);
            stocktb.Name = $"stocktb_{donationId}";
            stocktb.ReadOnly = true;
            stocktb.Size = new Size(56, 18);
            stocktb.TabIndex = 2;
            stocktb.TextAlign = HorizontalAlignment.Center;
            stocktb.Text = expirationDate;

            edatePanel.BackColor =Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            edatePanel.Controls.Add(edatetb);
            edatePanel.Dock = DockStyle.Fill;
            edatePanel.Name = $"eedt_{donationId}";
            edatePanel.TabIndex = 8;
            edatetb.BackColor =Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            edatetb.BorderStyle = BorderStyle.None;
            edatetb.Font = new Font("Tw Cen MT", 12F,FontStyle.Regular,GraphicsUnit.Point, ((byte)(0)));
            edatetb.Location = new Point(3, 5);
            edatetb.Name = $"eedate_{donationId}";
            edatetb.ReadOnly = true;
            edatetb.Size = new Size(127, 18);
            edatetb.TabIndex = 2;
            edatetb.TextAlign = HorizontalAlignment.Center;
            edatetb.Text = donorName;

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
