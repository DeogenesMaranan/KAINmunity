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
using static System.Windows.Forms.AxHost;

namespace KainmunityClient.Forms
{
    public partial class DonationHistoryForm : Form
    {
        public DonationHistoryForm()
        {
            InitializeComponent();
        }

        private async void FetchDonationHistory(object sender, EventArgs e)
        {
            var donations = await AccountManager.GetDonationHistory();

            foreach (var donation in donations)
            {
                int donationId = Convert.ToInt32(donation["DonationId"]);
                string donationDate = Convert.ToString(donation["DonationDate"]).Remove(10);
                string itemName = Convert.ToString(donation["DonationName"]);
                int itemStock = Convert.ToInt32(donation["DonationQuantity"]);
                string itemExpiration = Convert.ToString(donation["DonationExpiry"]).Remove(10);

                AddHistoryEntry(donationId, donationDate, itemName, itemStock, itemExpiration);
            }
        }

        public void AddHistoryEntry(int donationId, string donationDate, string itemName, int itemStock, string itemExpiration)
        {   
            TextBox edatetb = new TextBox();
            edatetb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            edatetb.BorderStyle = BorderStyle.None;
            edatetb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            edatetb.Name = $"edatetb_{donationId}";
            edatetb.ReadOnly = true;
            edatetb.Size = new Size(147, 18);
            edatetb.TextAlign = HorizontalAlignment.Center;
            edatetb.Text = itemExpiration;
            edatetb.Location = new Point(0, 5);

            TextBox inametb = new TextBox();
            inametb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inametb.BorderStyle = BorderStyle.None;
            inametb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            inametb.Name = $"inametb_{donationId}";
            inametb.ReadOnly = true;
            inametb.Size = new Size(188, 18);
            inametb.TextAlign = HorizontalAlignment.Center;
            inametb.Text = itemName;
            inametb.Location = new Point(0, 5);

            TextBox ddatetb = new TextBox();
            ddatetb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatetb.BorderStyle = BorderStyle.None;
            ddatetb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ddatetb.Name = $"ddatetb_{donationId}";
            ddatetb.ReadOnly = true;
            ddatetb.Size = new Size(146, 18);
            ddatetb.TextAlign = HorizontalAlignment.Center;
            ddatetb.Text = donationDate;
            ddatetb.Location = new Point(0, 5);

            TextBox stocktb = new TextBox();
            stocktb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            stocktb.BorderStyle = BorderStyle.None;
            stocktb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            stocktb.Name = $"stocktb_{donationId}";
            stocktb.ReadOnly = true;
            stocktb.Size = new Size(68, 18);
            stocktb.TextAlign = HorizontalAlignment.Center;
            stocktb.Text = itemStock.ToString();
            stocktb.Location = new Point(0, 5);

            Panel edatepanel = new Panel();
            edatepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            edatepanel.Controls.Add(edatetb);
            edatepanel.Dock = DockStyle.Fill;
            edatepanel.Name = $"edatepanel_{donationId}";
            edatepanel.Size = new Size(150, 28);

            Panel inamepanel = new Panel();
            inamepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            inamepanel.Controls.Add(inametb);
            inamepanel.Dock = DockStyle.Fill;
            inamepanel.Name = $"inamepanel_{donationId}";
            inamepanel.Size = new Size(188, 28);

            Panel ddatepanel = new Panel();
            ddatepanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            ddatepanel.Controls.Add(ddatetb);
            ddatepanel.Dock = DockStyle.Fill;
            ddatepanel.Name = $"ddatepanel_{donationId}";
            ddatepanel.Size = new Size(149, 28);
          
            Panel stockpanel = new Panel();
            stockpanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            stockpanel.Controls.Add(stocktb);
            stockpanel.Dock = DockStyle.Fill;
            stockpanel.Name = $"stockpanel_{donationId}";
            stockpanel.Size = new Size(71, 28);
        
            TableLayoutPanel historyPlaceholder = new TableLayoutPanel();
            historyPlaceholder.ColumnCount = 4;
            historyPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.66667F));
            historyPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            historyPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.33333F));
            historyPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.66667F));
            historyPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            historyPlaceholder.Controls.Add(edatepanel, 3, 0);
            historyPlaceholder.Controls.Add(inamepanel, 1, 0);
            historyPlaceholder.Controls.Add(ddatepanel, 0, 0);
            historyPlaceholder.Controls.Add(stockpanel, 2, 0);
            historyPlaceholder.Location = new Point(0, 0);
            historyPlaceholder.Margin = new Padding(0);
            historyPlaceholder.Name = $"historyPlaceholder_{donationId}";
            historyPlaceholder.RowCount = 1;
            historyPlaceholder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            historyPlaceholder.Size = new Size(582, 34);
            historyPlaceholder.TabIndex = 22;

            historyContainer.Controls.Add(historyPlaceholder);
        }

        private void ReturnToProfile(object sender, EventArgs e)
        {
            new UserProfileForm(APIConnector.UserId).Show();
            this.Close();
        }
    }
}
