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
    public partial class DonationDetails : Form
    {
        public DonationDetails()
        {
            InitializeComponent();
        }

        public void FillDetails(string donationDate, string donorName, string itemName, int availableQuantity, string expirationDate)
        {
            ddatetb.Text = donationDate;
            dnametb.Text = donorName;
            inametb.Text = itemName;
            stocktb.Text = availableQuantity.ToString();
            edatetb.Text = expirationDate;
        }
        
        public void AddAssociatedRequestEntry(int requestId, string requestedDate, string requesterName, string requestQuantity, string requestStatus)
        {
            TextBox statusTb = new TextBox();
            statusTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            statusTb.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusTb.Location = new System.Drawing.Point(3, 5);
            statusTb.Name = $"statusTb_{requestId}";
            statusTb.ReadOnly = true;
            statusTb.Size = new System.Drawing.Size(164, 18);
            statusTb.TabIndex = 2;
            statusTb.Text = requestStatus;
            statusTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TextBox reqQuanTb = new TextBox();
            reqQuanTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqQuanTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reqQuanTb.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reqQuanTb.Location = new System.Drawing.Point(3, 5);
            reqQuanTb.Name = $"reqQuanTb_{requestId}";
            reqQuanTb.ReadOnly = true;
            reqQuanTb.Size = new System.Drawing.Size(163, 18);
            reqQuanTb.TabIndex = 1;
            reqQuanTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            reqQuanTb.Text = requestQuantity;

            TextBox reqNameTb = new TextBox();
            reqNameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqNameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reqNameTb.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reqNameTb.Location = new System.Drawing.Point(5, 5);
            reqNameTb.Name = $"reqNameTb_{requestId}";
            reqNameTb.ReadOnly = true;
            reqNameTb.Size = new System.Drawing.Size(220, 18);
            reqNameTb.TabIndex = 0;
            reqNameTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            reqNameTb.Text = requesterName;

            TextBox reqDateTb = new TextBox();
            reqDateTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqDateTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reqDateTb.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reqDateTb.Location = new System.Drawing.Point(0, 5);
            reqDateTb.Name = $"reqDateTb_{requestId}";
            reqDateTb.ReadOnly = true;
            reqDateTb.Size = new System.Drawing.Size(108, 18);
            reqDateTb.TabIndex = 0;
            reqDateTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            reqDateTb.Text = requestedDate;


            Panel statusPanel = new Panel();
            statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusPanel.Controls.Add(statusTb);
            statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            statusPanel.Location = new System.Drawing.Point(404, 3);
            statusPanel.Name = $"statusPanel_{requestId}";
            statusPanel.TabIndex = 2;

            Panel reqQuanPanel = new Panel();
            reqQuanPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqQuanPanel.Controls.Add(reqQuanTb);
            reqQuanPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            reqQuanPanel.Location = new System.Drawing.Point(232, 3);
            reqQuanPanel.Name = $"reqQuanPanel_{requestId}";
            reqQuanPanel.TabIndex = 1;

            Panel reqNamePanel = new Panel();
            reqNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqNamePanel.Controls.Add(reqNameTb);
            reqNamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            reqNamePanel.Location = new System.Drawing.Point(3, 3);
            reqNamePanel.Name = $"reNamePanel_{requestId}";
            reqNamePanel.Size = new System.Drawing.Size(223, 28);
            reqNamePanel.TabIndex = 0;

            Panel reqDatePanel = new Panel();
            reqDatePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            reqDatePanel.Controls.Add(reqDateTb);
            reqDatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            reqDatePanel.Location = new System.Drawing.Point(3, 3);
            reqDatePanel.Name = $"reqDatePanel_{requestId}";
            reqDatePanel.TabIndex = 3;

            TableLayoutPanel entryPlaceholder = new TableLayoutPanel();
            entryPlaceholder.ColumnCount = 4;
            entryPlaceholder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            entryPlaceholder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            entryPlaceholder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            entryPlaceholder.Controls.Add(statusPanel, 3, 0);
            entryPlaceholder.Controls.Add(reqQuanPanel, 2, 0);
            entryPlaceholder.Controls.Add(reqNamePanel, 1, 0);
            entryPlaceholder.Controls.Add(reqDatePanel, 0, 0);
            entryPlaceholder.Name = "entryPlaceholder";
            entryPlaceholder.RowCount = 1;
            entryPlaceholder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            entryPlaceholder.Size = new System.Drawing.Size(574, 34);

            assReqContainer.Controls.Add(entryPlaceHolder);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
