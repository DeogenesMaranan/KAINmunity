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
    public partial class LogisticDashboardForm : Form
    {
        public LogisticDashboardForm()
        {
            InitializeComponent();
        }

        private async void GetAccepted(object sender, EventArgs e)
        {
            var accepted = await LogisticManager.FetchAccepted();

            foreach (var acc in accepted)
            {
                int requestId = Convert.ToInt32(acc["RequestId"]);
                string requesterName = Convert.ToString(acc["RequesterName"]);
                string itemName = Convert.ToString(acc["DonationName"]);
                int requestQuantity = Convert.ToInt32(acc["RequestQuantity"]);

                showAccepted(requestId, requesterName, itemName, requestQuantity);
            }
        }

        private void showAccepted(int requestId, string requesterName, string itemName, int requestQuantity)
        {
            TextBox nameTb = new TextBox();
            nameTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            nameTb.BorderStyle = BorderStyle.None;
            nameTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            nameTb.Location = new Point(3, 6);
            nameTb.Name = $"name_{requestId}";
            nameTb.ReadOnly = true;
            nameTb.Size = new Size(223, 18);
            nameTb.TabIndex = 0;
            nameTb.TextAlign = HorizontalAlignment.Center;
            nameTb.Text = requesterName;

            TextBox itemtb = new TextBox();
            itemtb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemtb.BorderStyle = BorderStyle.None;
            itemtb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemtb.Location = new Point(2, 4);
            itemtb.Name = $"item_{requestId}";
            itemtb.ReadOnly = true;
            itemtb.Size = new Size(136, 18);
            itemtb.TabIndex = 0;
            itemtb.TextAlign = HorizontalAlignment.Center;
            itemtb.Text = itemName;

            TextBox quantityTb = new TextBox();
            quantityTb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityTb.BorderStyle = BorderStyle.None;
            quantityTb.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            quantityTb.Location = new Point(3, 6);
            quantityTb.Name = $"quantity_{requestId}";
            quantityTb.ReadOnly = true;
            quantityTb.Size = new Size(77, 18);
            quantityTb.TabIndex = 0;
            quantityTb.TextAlign = HorizontalAlignment.Center;
            quantityTb.Text = Convert.ToString(requestQuantity);

            Button resolveBtn = new Button();
            resolveBtn.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            resolveBtn.FlatAppearance.BorderSize = 0;
            resolveBtn.FlatStyle = FlatStyle.Flat;
            resolveBtn.ForeColor = SystemColors.Window;
            resolveBtn.Name = $"resolveBtn_{requestId}";
            resolveBtn.Size = new Size(109, 39);
            resolveBtn.Text = "ACCEPT";
            resolveBtn.UseVisualStyleBackColor = false;

            Panel namePanel = new Panel();
            namePanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            namePanel.Controls.Add(nameTb);
            namePanel.Dock = DockStyle.Fill;
            namePanel.Location = new Point(3, 3);
            namePanel.Name = $"namePanel_{requestId}";
            namePanel.Size = new Size(226, 29);
            namePanel.TabIndex = 1;

            Panel itemPanel = new Panel();
            itemPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            itemPanel.Controls.Add(itemtb);
            itemPanel.Dock = DockStyle.Fill;
            itemPanel.Location = new Point(235, 3);
            itemPanel.Name = $"itemPanel_{requestId}";
            itemPanel.Size = new Size(139, 29);
            itemPanel.TabIndex = 0;

            Panel quantityPanel = new Panel();
            quantityPanel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            quantityPanel.Controls.Add(quantityTb);
            quantityPanel.Dock = DockStyle.Fill;
            quantityPanel.Location = new Point(380, 3);
            quantityPanel.Name = "quantityPanel_{requestId}";
            quantityPanel.Size = new Size(81, 29);
            quantityPanel.TabIndex = 3;

            TableLayoutPanel logisticsAcceptedContainer = new TableLayoutPanel();
            logisticsAcceptedContainer.ColumnCount = 4;
            logisticsAcceptedContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            logisticsAcceptedContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            logisticsAcceptedContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            logisticsAcceptedContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            logisticsAcceptedContainer.Controls.Add(quantityPanel, 0, 0);
            logisticsAcceptedContainer.Controls.Add(itemPanel, 0, 0);
            logisticsAcceptedContainer.Controls.Add(namePanel, 0, 0);
            logisticsAcceptedContainer.Controls.Add(resolveBtn, 1, 0);
            logisticsAcceptedContainer.Location = new Point(0, 0);
            logisticsAcceptedContainer.Margin = new Padding(0);
            logisticsAcceptedContainer.Name = $"requestEntryContainer_{requestId}";
            logisticsAcceptedContainer.RowCount = 1;
            logisticsAcceptedContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            logisticsAcceptedContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            logisticsAcceptedContainer.Size = new Size(582, 35);
            logisticsAcceptedContainer.TabIndex = 3;

            logisticContainer.Controls.Add(logisticsAcceptedContainer);

            resolveBtn.Click += async delegate (object sender, EventArgs e)
            {
                var res = await LogisticManager.UpdateDeliveryStatus(requestId);

                if (res)
                {
                    new LogisticDashboardForm().Show();
                    this.Close();
                    // Not restarting
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            };
        }
    }
}