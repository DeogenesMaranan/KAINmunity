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

        private void showLeaderboardEntry(int donorId, string donorName, int donations)
        {
            TextBox name = new TextBox();
            name.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            name.BorderStyle = BorderStyle.None;
            name.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            name.Name = $"name_{donorId}";
            name.Size = new Size(300, 21);
            name.Text = donorName;
            name.TextAlign = HorizontalAlignment.Center;

            TextBox donationCount = new TextBox();
            donationCount.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            donationCount.BorderStyle = BorderStyle.None;
            donationCount.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            donationCount.Name = $"donations_{donorId}";
            donationCount.Size = new Size(96, 21);
            donationCount.TabIndex = 1;
            donationCount.Text = "1000";
            donationCount.TextAlign = HorizontalAlignment.Center;

            TableLayoutPanel entryContainer = new TableLayoutPanel();
            entryContainer.ColumnCount = 2;
            entryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            entryContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            entryContainer.Controls.Add(name, 0, 0);
            entryContainer.Controls.Add(donationCount, 1, 0);
            entryContainer.Name = $"entryContainer_{donorId}";
            entryContainer.RowCount = 1;
            entryContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            entryContainer.Size = new Size(408, 32);

            leaderboardContainer.SetFlowBreak(entryContainer, true);
            leaderboardContainer.Controls.Add(entryContainer);
        }
    }
}
