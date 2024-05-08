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
    public partial class RequestHistory : Form
    {
        public RequestHistory()
        {
            InitializeComponent();
        }

        private void showRequestListEntry(int requestId, string date, string itemName, int quantity, string status)
        {
            TextBox dateSection = new TextBox();
            dateSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            dateSection.BorderStyle = BorderStyle.None;
            dateSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dateSection.Name = $"date_{requestId}";
            dateSection.Size = new Size(126, 21);

            TextBox nameSection = new TextBox();
            nameSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            nameSection.BorderStyle = BorderStyle.None;
            nameSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameSection.Name = $"name_{requestId}";
            nameSection.Size = new Size(169, 21);

            TextBox quantitySection = new TextBox();
           quantitySection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
           quantitySection.BorderStyle = BorderStyle.None;
           quantitySection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
           quantitySection.Name = $"quantity_{requestId}";
           quantitySection.Size = new Size(128, 21);

            TextBox statusSection = new TextBox();
            statusSection.BackColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            statusSection.BorderStyle = BorderStyle.None;
            statusSection.Font = new Font("Tw Cen MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            statusSection.Name = $"status_{requestId}";
            statusSection.Size = new Size(130, 21);

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

    }

}
