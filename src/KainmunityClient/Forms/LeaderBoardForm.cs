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
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private async void FetchLeaderboard(object sender, EventArgs e)
        {
            var donors = await DonationManager.GetLeaderboard();

            foreach (var donor in donors)
            {
                int donorId = Convert.ToInt32(donor["DonorId"]);
                string donorName= Convert.ToString(donor["DonorName"]);
                int donations = Convert.ToInt32(donor["TotalDonations"]);

                showLeaderboardEntry(donorId, donorName, donations);
            }
        }

        private void showLeaderboardEntry(int donorId, string donorName, int donations)
        {
            TextBox name = new TextBox();
            name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            name.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            name.Name = $"name_{donorId}";
            name.Size = new Size(206, 21);
            name.Text = donorName;
            name.TextAlign = HorizontalAlignment.Center;
            name.ReadOnly = true;
            name.Location = new Point(0, 3);

            TextBox donationCount = new TextBox();
            donationCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            donationCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            donationCount.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            donationCount.Name = $"donations_{donorId}";
            donationCount.Size = new Size(206, 21);
            donationCount.TabIndex = 1;
            donationCount.Text = Convert.ToString(donations);
            donationCount.TextAlign = HorizontalAlignment.Center;
            donationCount.ReadOnly = true;
            donationCount.Location = new Point(0, 3);


            Panel namePanel = new Panel();
            namePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(name);
            namePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            namePanel.Name = $"namePanel_{donorId}";

            Panel donationPanel = new Panel();
            donationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            donationPanel.Controls.Add(donationCount);
            donationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            donationPanel.Name = $"donationPanel_{donorId}";

            TableLayoutPanel entryContainer = new TableLayoutPanel();
            entryContainer.ColumnCount = 2;
            entryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            entryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            entryContainer.Controls.Add(namePanel, 0, 0);
            entryContainer.Controls.Add(donationPanel, 1, 0);
            entryContainer.Name = $"entryContainer_{donorId}";
            entryContainer.RowCount = 1;
            entryContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            entryContainer.Size = new Size(408, 32);


            leaderboardContainer.SetFlowBreak(entryContainer, true);
            leaderboardContainer.Controls.Add(entryContainer);
        }

        private void returnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dash = new DashboardForm();
            dash.Show();
        }
    }
}
