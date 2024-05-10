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
    public partial class RequestHistory : Form
    {
        public RequestHistory()
        {
            InitializeComponent();
        }

        private async void FetchRequestHistory(object sender, EventArgs e)
        {
            var requests = await AccountManager.GetRequestHistory();
            
            foreach (var request in requests)
            {
                int requestId = Convert.ToInt32(request["RequestId"]);
                string date = Convert.ToString(request["RequestDate"]).Remove(10);
                string itemName = Convert.ToString(request["DonationName"]);
                int quantity = Convert.ToInt32(request["RequestQuantity"]);
                string status = Convert.ToString(request["RequestStatus"]);

                ShowRequestListEntry(requestId, date, itemName, quantity, status);
            }
        }

        private void ShowRequestListEntry(int requestId, string date, string itemName, int quantity, string status)
        {
            TextBox dateSection = new TextBox();
            dateSection.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            dateSection.BorderStyle = BorderStyle.None;
            dateSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dateSection.Name = $"date_{requestId}";
            dateSection.Size = new Size(126, 21);
            dateSection.ReadOnly = true;
            dateSection.Text = date;
            dateSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dateSection.Location = new Point(0, 3);

            TextBox nameSection = new TextBox();
            nameSection.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            nameSection.BorderStyle = BorderStyle.None;
            nameSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameSection.Name = $"name_{requestId}";
            nameSection.Size = new Size(169, 21);
            nameSection.ReadOnly = true;
            nameSection.Text = itemName;
            nameSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nameSection.Location = new Point(0, 3);

            TextBox quantitySection = new TextBox();
            quantitySection.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantitySection.BorderStyle = BorderStyle.None;
            quantitySection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            quantitySection.Name = $"quantity_{requestId}";
            quantitySection.Size = new Size(128, 21);
            quantitySection.ReadOnly = true;
            quantitySection.Text = Convert.ToString(quantity);
            quantitySection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            quantitySection.Location = new Point(0, 3);

            TextBox statusSection = new TextBox();
            statusSection.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusSection.BorderStyle = BorderStyle.None;
            statusSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            statusSection.Name = $"status_{requestId}";
            statusSection.Size = new Size(130, 21);
            statusSection.ReadOnly = true;
            statusSection.Text = status;
            statusSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            statusSection.Location = new Point(0, 3);

            Panel datePanel = new Panel();
            datePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            datePanel.Controls.Add(dateSection);
            datePanel.Dock = DockStyle.Fill;
            datePanel.Name = $"datepanel_{requestId}";

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(nameSection);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Name = $"namepanel_{requestId}";

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityPanel.Controls.Add(quantitySection);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Name = $"quantitypanel_{requestId}";

            Panel statusPanel = new Panel();
            statusPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            statusPanel.Controls.Add(statusSection);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Name = $"statuspanel_{requestId}";

            TableLayoutPanel requestEntryPlaceholder = new TableLayoutPanel();
            requestEntryPlaceholder.ColumnCount = 4;
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.30303F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.Controls.Add(statusPanel, 3, 0);
            requestEntryPlaceholder.Controls.Add(quantityPanel, 2, 0);
            requestEntryPlaceholder.Controls.Add(namePanel, 1, 0);
            requestEntryPlaceholder.Controls.Add(datePanel, 0, 0);
            requestEntryPlaceholder.Name = $"requestEntryPlaceholder_{requestId}";
            requestEntryPlaceholder.RowCount = 1;
            requestEntryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            requestEntryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            requestEntryPlaceholder.Size = new Size(579, 36);

            requestsListContainer.Controls.Add(requestEntryPlaceholder);
        }

        private void ReturnToProfile(object sender, EventArgs e)
        {
            this.Hide();
            new UserProfileForm(APIConnector.UserId).Show();
        }
    }

}
