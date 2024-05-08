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
            TextBox feedId = new TextBox();
            feedId.Text = Convert.ToString(feedbackId);
            feedId.Size = new Size(250, 20);
            feedId.TextAlign = HorizontalAlignment.Center;
            feedId.ReadOnly = true;
            feedId.Name = $"id_{feedbackId}";

            TextBox feedContent = new TextBox();
            feedContent.Text = feedbackContent;
            feedContent.Size = new Size(250, 20);
            feedContent.TextAlign = HorizontalAlignment.Center;
            feedContent.ReadOnly = true;
            feedContent.Name = $"content_{feedbackId}";

            TableLayoutPanel feedbackPlaceholder = new TableLayoutPanel();
            feedbackPlaceholder.Size = new Size(575, 27);
            feedbackPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            feedbackPlaceholder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            feedbackPlaceholder.Controls.Add(feedId, 0, 0);
            feedbackPlaceholder.Controls.Add(feedContent, 1, 0);

            feedbackContainer.Controls.Add(feedbackPlaceholder);
        }
    }


}
