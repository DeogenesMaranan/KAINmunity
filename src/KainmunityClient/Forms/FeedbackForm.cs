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
    public partial class FeedbackForm : Form
    {
        public FeedbackForm()
        {
            InitializeComponent();
        }

        private async void fetchFeedbacks(object sender, EventArgs e)
        {
            /*var feedbacks = await DonationManager.GetFeedbacks(); // Not yet implemented

            foreach (var feedback in feedbacks)
            {
                int feedbackId = Convert.ToInt32(feedback["FeedbackId"]);
                int respondentId = Convert.ToInt32(feedback["RespondentId"]);
                string content = feedback["FeedbackContent"];

                string respondentName = // tk

                showFeedbackEntry(feedbackId, respondentName, content);
            }*/

            throw new NotImplementedException(); // tk
        }

        private async void submitFeedback(object sender, EventArgs e)
        {
            throw new NotImplementedException(); // tk
        }

        private void showFeedbackEntry(int feedbackId, string respondentName, string feedbackContent)
        {
            TextBox content = new TextBox();
            content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            content.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            content.Multiline = true;
            content.Name = $"content_{feedbackId}";
            content.Size = new System.Drawing.Size(161, 65);
            content.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            content.TextAlign = HorizontalAlignment.Center;

            TextBox author = new TextBox();
            author.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            author.BorderStyle = System.Windows.Forms.BorderStyle.None;
            author.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            author.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            author.Name = $"author_{feedbackId}";
            author.ReadOnly = true;
            author.Size = new System.Drawing.Size(161, 21);
            author.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            author.TextAlign = HorizontalAlignment.Center;

            Panel feedbackPlaceholder = new Panel();
            feedbackPlaceholder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            feedbackPlaceholder.Controls.Add(content);
            feedbackPlaceholder.Controls.Add(author);
            feedbackPlaceholder.Name = $"feedbackPlaceholder_{feedbackId}";
            feedbackPlaceholder.Size = new System.Drawing.Size(186, 118);

            feedbackContainer.Controls.Add(feedbackPlaceholder);
        }


    }


}
