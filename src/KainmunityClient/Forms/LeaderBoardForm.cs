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
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void showLeaderboardEntry(int donorId, string donorName, int donations)
        {
            TextBox name = new TextBox();
            name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            name.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            name.Name = $"name_{donorId}";
            name.Size = new System.Drawing.Size(300, 21);
            name.Text = donorName;
            name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TextBox donationCount = new TextBox();
            donationCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            donationCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            donationCount.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            donationCount.Name = $"donations_{donorId}";
            donationCount.Size = new System.Drawing.Size(96, 21);
            donationCount.TabIndex = 1;
            donationCount.Text = "1000";
            donationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TableLayoutPanel entryContainer = new TableLayoutPanel();
            entryContainer.ColumnCount = 2;
            entryContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            entryContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            entryContainer.Controls.Add(name, 0, 0);
            entryContainer.Controls.Add(donationCount, 1, 0);
            entryContainer.Name = $"entryContainer_{donorId}";
            entryContainer.RowCount = 1;
            entryContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            entryContainer.Size = new System.Drawing.Size(408, 32);

            leaderboardContainer.Controls.Add(entryContainer);
        }
    }
}
