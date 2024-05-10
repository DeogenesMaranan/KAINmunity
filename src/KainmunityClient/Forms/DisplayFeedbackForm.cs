using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KainmunityClient.Models;
using KainmunityClient.ServerAPI;

namespace KainmunityClient.Forms
{
    public partial class DisplayFeedbackForm : Form
    {
        public DisplayFeedbackForm()
        {
            InitializeComponent();
        }

        private async void GetFeedbacks(object sender, EventArgs e)
        {
            var feedbacks = await FeedbackManager.FetchFeedbacks();

            foreach (var feedback in feedbacks)
            {
                int feedbackId = Convert.ToInt32(feedback["FeedbackId"]);
                string content = Convert.ToString(feedback["FeedbackContent"]);

                showFeedbackEntry(feedbackId, content);
            }
        }

        private void showFeedbackEntry(int feedbackId, string feedbackContent)
        {
            TextBox contentTextBox = new TextBox();
            contentTextBox.BackColor = Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            contentTextBox.BorderStyle = BorderStyle.None;
            contentTextBox.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            contentTextBox.Margin = new Padding(5);
            contentTextBox.Name = $"contentTextBox_{feedbackId}";
            contentTextBox.Size = new Size(437, 24);
            contentTextBox.Text = feedbackContent;
            contentTextBox.Location = new Point(3, 3);

            Panel textBoxBG = new Panel();
            textBoxBG.Location = new Point(3, 3);
            textBoxBG.BackColor = Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            textBoxBG.Controls.Add(contentTextBox);
            textBoxBG.Name = $"contentBackground_{feedbackId}";
            textBoxBG.Size = new Size(452, 39);
            textBoxBG.TabIndex = 1;
            textBoxBG.Location = new Point(3, 3);

            Button resolveBtn = new Button();
            resolveBtn.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            resolveBtn.FlatAppearance.BorderSize = 0;
            resolveBtn.FlatStyle = FlatStyle.Flat;
            resolveBtn.ForeColor = SystemColors.Window;
            resolveBtn.Name = $"resolveBtn_{feedbackId}";
            resolveBtn.Size = new Size(109, 39);
            resolveBtn.Text = "RESOLVE";
            resolveBtn.UseVisualStyleBackColor = false;

            TableLayoutPanel tableContainer = new TableLayoutPanel();
            tableContainer.ColumnCount = 2;
            tableContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableContainer.Location = new Point(3, 3);
            tableContainer.Controls.Add(textBoxBG, 0, 0);
            tableContainer.Controls.Add(resolveBtn, 1, 0);
            tableContainer.Name = $"feedbackTable_{feedbackId}";
            tableContainer.RowCount = 1;
            tableContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableContainer.Size = new Size(573, 46);
            tableContainer.TabIndex = 2;
            tableContainer.Location = new Point(3, 3);

            feedbackContainer.Controls.Add(tableContainer);

            resolveBtn.Click += async delegate (object sender, EventArgs e)
            {
                var res = await FeedbackManager.ResolveFeedback(feedbackId);

                if (res)
                {
                    new DisplayFeedbackForm().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
                
            };
        }

            

        private void returnToDashboard(object sender, EventArgs e)
        {
            this.Hide();
            new DashboardForm().Show();
        }
    }


}
