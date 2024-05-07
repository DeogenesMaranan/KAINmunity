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
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
        }


        private void AddListItem(int itemId, string itemName, int availableQuantity)
        {
            Label nameLabel = new Label();
            nameLabel.Text = itemName;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Name = $"name_{itemId}";

            Label quantityLabel = new Label();
            quantityLabel.Text = availableQuantity.ToString();
            quantityLabel.Dock = DockStyle.Fill;
            quantityLabel.TextAlign = ContentAlignment.MiddleCenter;
            quantityLabel.Name = $"quantity_{itemId}";

            TextBox requestQuantityTextBox = new TextBox();
            requestQuantityTextBox.Dock = DockStyle.Fill;
            requestQuantityTextBox.Name = $"requestQuantity_{itemId}";

            TableLayoutPanel listItems = new TableLayoutPanel();
            listItems.Size = new Size(575, 27);

            listItems.Controls.Add(nameLabel, 0, 0);
            listItems.Controls.Add(quantityLabel, 1, 0);
            listItems.Controls.Add(requestQuantityTextBox, 2, 0);

            listItems.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 33F);
            listItems.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 33F);
            listItems.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 33F);
            listItems.Name = $"list_{itemId}";

            flowLayoutPanel.Controls.Add(listItems);
        }
    }
}
