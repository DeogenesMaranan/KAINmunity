using System.Windows.Forms;

namespace KainmunityClient.Forms
{
    partial class DisplayFeedbackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.feedbackContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.head = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.head.SuspendLayout();
            this.SuspendLayout();
            // 
            // feedbackContainer
            // 
            this.feedbackContainer.AutoScroll = true;
            this.feedbackContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.feedbackContainer.Location = new System.Drawing.Point(115, 96);
            this.feedbackContainer.Name = "feedbackContainer";
            this.feedbackContainer.Size = new System.Drawing.Size(597, 394);
            this.feedbackContainer.TabIndex = 6;
            this.feedbackContainer.WrapContents = false;
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.White;
            this.head.Controls.Add(this.back);
            this.head.Controls.Add(this.title);
            this.head.Location = new System.Drawing.Point(115, 12);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(576, 78);
            this.head.TabIndex = 5;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.back.Location = new System.Drawing.Point(10, 9);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(52, 23);
            this.back.TabIndex = 17;
            this.back.Text = "BACK";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.returnToDashboard);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.title.Location = new System.Drawing.Point(188, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(215, 60);
            this.title.TabIndex = 2;
            this.title.Text = "FEEDBACK";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(802, 502);
            this.Controls.Add(this.feedbackContainer);
            this.Controls.Add(this.head);
            this.Name = "DisplayFeedbackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.Load += new System.EventHandler(this.GetFeedbacks);
            this.head.ResumeLayout(false);
            this.head.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel feedbackContainer;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label title;
    }
}