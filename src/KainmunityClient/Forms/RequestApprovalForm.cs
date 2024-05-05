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
    public partial class RequestApprovalForm : Form
    {
        public RequestApprovalForm()
        {
            InitializeComponent();
        }

        private async void FetchRequests(object sender, EventArgs e)
        {
            var requests = await DonationManager.GetRequests();

            foreach (var request in requests)
            {
                int requestId = Convert.ToInt32(request["RequestId"]);
                string requesterName = Convert.ToString(request["RequesterName"]);
                string itemName = Convert.ToString(request["DonationName"]);
                int requestQuantity = Convert.ToInt32(request["RequestQuantity"]);
                string requestStatus = Convert.ToString(request["RequestStatus"]);

                AddRequestEntry(requestId, requesterName, itemName, Convert.ToString(requestQuantity), requestStatus);
            }
        }

        private void AddRequestEntry(int requestId, string requesterName, string itemName, string itemQuantity, string requestStatus)
        {
            TextBox nameTextBox = new TextBox();
            nameTextBox.Text = requesterName;
            nameTextBox.Size = new Size(224, 20);
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            nameTextBox.ReadOnly = true;
            nameTextBox.Name = $"name_{requestId}";

            TextBox itemTextBox = new TextBox();
            itemTextBox.Text = itemName;
            itemTextBox.Size = new Size(137, 20);
            itemTextBox.TextAlign = HorizontalAlignment.Center;
            nameTextBox.ReadOnly = true;
            itemTextBox.Name = $"item_{requestId}";

            TextBox quantityTextBox = new TextBox();
            quantityTextBox.Text = itemQuantity;
            quantityTextBox.Size = new Size(80, 20);
            quantityTextBox.TextAlign = HorizontalAlignment.Center;
            nameTextBox.ReadOnly = true;
            quantityTextBox.Name = $"quantity_{requestId}";

            ComboBox statusComboBox = new ComboBox();
            statusComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            statusComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            statusComboBox.Items.AddRange(new object[] { "Pending", "Accepted", "Declined" });
            statusComboBox.Text = requestStatus;
            statusComboBox.Size = new Size(110, 20);
            statusComboBox.Name = $"status_{requestId}";

            TableLayoutPanel requestEntryLayout = new TableLayoutPanel();
            requestEntryLayout.Size = new Size(575, 27);
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            requestEntryLayout.Controls.Add(nameTextBox, 0, 0);
            requestEntryLayout.Controls.Add(itemTextBox, 1, 0);
            requestEntryLayout.Controls.Add(quantityTextBox, 2, 0);
            requestEntryLayout.Controls.Add(statusComboBox, 3, 0);

            flowLayoutPanel1.Controls.Add(requestEntryLayout);
        }





        private void ReturnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            new DashboardForm().Show();
        }
    }
}
