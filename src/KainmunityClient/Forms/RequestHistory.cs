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
            dateSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            dateSection.BorderStyle = BorderStyle.None;
            dateSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dateSection.Name = $"date_{requestId}";
            dateSection.Size = new Size(126, 21);
            dateSection.ReadOnly = true;
            dateSection.Text = date;
            dateSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TextBox nameSection = new TextBox();
            nameSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            nameSection.BorderStyle = BorderStyle.None;
            nameSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameSection.Name = $"name_{requestId}";
            nameSection.Size = new Size(169, 21);
            nameSection.ReadOnly = true;
            nameSection.Text = itemName;
            nameSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TextBox quantitySection = new TextBox();
            quantitySection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            quantitySection.BorderStyle = BorderStyle.None;
            quantitySection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            quantitySection.Name = $"quantity_{requestId}";
            quantitySection.Size = new Size(128, 21);
            quantitySection.ReadOnly = true;
            quantitySection.Text = Convert.ToString(quantity);
            quantitySection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TextBox statusSection = new TextBox();
            statusSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            statusSection.BorderStyle = BorderStyle.None;
            statusSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            statusSection.Name = $"status_{requestId}";
            statusSection.Size = new Size(130, 21);
            statusSection.ReadOnly = true;
            statusSection.Text = status;
            statusSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            TableLayoutPanel requestEntryPlaceholder = new TableLayoutPanel();
            requestEntryPlaceholder.ColumnCount = 4;
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.30303F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.23232F));
            requestEntryPlaceholder.Controls.Add(statusSection, 3, 0);
            requestEntryPlaceholder.Controls.Add(quantitySection, 2, 0);
            requestEntryPlaceholder.Controls.Add(nameSection, 1, 0);
            requestEntryPlaceholder.Controls.Add(dateSection, 0, 0);
            requestEntryPlaceholder.Name = $"requestEntryPlaceholder_{requestId}";
            requestEntryPlaceholder.RowCount = 1;
            requestEntryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            requestEntryPlaceholder.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            requestEntryPlaceholder.Size = new Size(579, 27);


            requestsListContainer.SetFlowBreak(requestEntryPlaceholder, true);
            requestsListContainer.Controls.Add(requestEntryPlaceholder);
        }

        private void ReturnToProfile(object sender, EventArgs e)
        {
            this.Hide();
            new UserProfileForm(APIConnector.UserId).Show();
        }
    }

}
