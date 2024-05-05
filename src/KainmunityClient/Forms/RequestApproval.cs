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
    public partial class RequestApproval : Form
    {
        public RequestApproval()
        {
            InitializeComponent();
        }


        private void AddRequestEntry(int requestId, string requesterName, string itemName, string itemQuantity, string requestStatus)
        {
            // Create controls for the new request entry
            Label nameLabel = new Label();
            nameLabel.Text = requesterName;
            nameLabel.Name = $"name_{requestId}";

            Label itemLabel = new Label();
            itemLabel.Text = itemName;
            itemLabel.Name = $"item_{requestId}";

            Label quantityLabel = new Label();
            quantityLabel.Text = itemQuantity;
            quantityLabel.Name = $"quantity_{requestId}";

            ComboBox statusComboBox = new ComboBox();
            statusComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            statusComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            statusComboBox.Items.AddRange(new object[] { "Pending", "Accepted", "Declined" });
            statusComboBox.Text = requestStatus;
            statusComboBox.Name = $"status_{requestId}";

            // Create a new TableLayoutPanel for the request entry
            TableLayoutPanel requestEntryLayout = new TableLayoutPanel();
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            requestEntryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            // Add controls to the TableLayoutPanel
            requestEntryLayout.Controls.Add(nameLabel, 0, 0);
            requestEntryLayout.Controls.Add(itemLabel, 1, 0);
            requestEntryLayout.Controls.Add(quantityLabel, 2, 0);
            requestEntryLayout.Controls.Add(statusComboBox, 3, 0);

            // Add the TableLayoutPanel to the FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(requestEntryLayout);
        }


    }
}
