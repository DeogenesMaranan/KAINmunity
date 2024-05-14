using System.Drawing;
using System.Windows.Forms;

namespace KainmunityClient.Forms
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.label1 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.feedbackPanel = new System.Windows.Forms.Panel();
            this.submitFeedback = new System.Windows.Forms.Button();
            this.feedbackTextBox = new System.Windows.Forms.TextBox();
            this.profileButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.donationBox = new System.Windows.Forms.Button();
            this.requestButton = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.feedbackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 21F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(56, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "WELCOME,";
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Font = new System.Drawing.Font("Impact", 21F);
            this.firstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.firstName.Location = new System.Drawing.Point(177, 66);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(0, 35);
            this.firstName.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.feedbackPanel);
            this.panel3.Controls.Add(this.profileButton);
            this.panel3.Controls.Add(this.logoutButton);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.donationBox);
            this.panel3.Controls.Add(this.firstName);
            this.panel3.Controls.Add(this.requestButton);
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 504);
            this.panel3.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(207)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.button1.Location = new System.Drawing.Point(602, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "LEADERBOARD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.toLeaderboard);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(710, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "FEEDBACK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.showFeedbackButton_Click);
            // 
            // feedbackPanel
            // 
            this.feedbackPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            this.feedbackPanel.Controls.Add(this.error);
            this.feedbackPanel.Controls.Add(this.submitFeedback);
            this.feedbackPanel.Controls.Add(this.feedbackTextBox);
            this.feedbackPanel.Location = new System.Drawing.Point(536, 254);
            this.feedbackPanel.Name = "feedbackPanel";
            this.feedbackPanel.Size = new System.Drawing.Size(249, 214);
            this.feedbackPanel.TabIndex = 8;
            this.feedbackPanel.Visible = false;
            // 
            // submitFeedback
            // 
            this.submitFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.submitFeedback.FlatAppearance.BorderSize = 0;
            this.submitFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitFeedback.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitFeedback.ForeColor = System.Drawing.Color.White;
            this.submitFeedback.Location = new System.Drawing.Point(12, 179);
            this.submitFeedback.Name = "submitFeedback";
            this.submitFeedback.Size = new System.Drawing.Size(75, 23);
            this.submitFeedback.TabIndex = 1;
            this.submitFeedback.Text = "SUBMIT";
            this.submitFeedback.UseVisualStyleBackColor = false;
            this.submitFeedback.Click += new System.EventHandler(this.sendFeedback);
            // 
            // feedbackTextBox
            // 
            this.feedbackTextBox.Location = new System.Drawing.Point(12, 16);
            this.feedbackTextBox.Multiline = true;
            this.feedbackTextBox.Name = "feedbackTextBox";
            this.feedbackTextBox.Size = new System.Drawing.Size(221, 153);
            this.feedbackTextBox.TabIndex = 0;
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.ForeColor = System.Drawing.Color.White;
            this.profileButton.Location = new System.Drawing.Point(385, 20);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(97, 40);
            this.profileButton.TabIndex = 6;
            this.profileButton.Text = "PROFILE";
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(694, 20);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(97, 40);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "LOGOUT";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // donationBox
            // 
            this.donationBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.donationBox.FlatAppearance.BorderSize = 0;
            this.donationBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationBox.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationBox.ForeColor = System.Drawing.Color.White;
            this.donationBox.Location = new System.Drawing.Point(488, 20);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(97, 40);
            this.donationBox.TabIndex = 2;
            this.donationBox.Text = "DONATE";
            this.donationBox.UseVisualStyleBackColor = false;
            this.donationBox.Click += new System.EventHandler(this.donationBox_Click);
            // 
            // requestButton
            // 
            this.requestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.requestButton.FlatAppearance.BorderSize = 0;
            this.requestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.requestButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestButton.ForeColor = System.Drawing.Color.White;
            this.requestButton.Location = new System.Drawing.Point(591, 20);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(97, 40);
            this.requestButton.TabIndex = 3;
            this.requestButton.Text = "REQUEST";
            this.requestButton.UseVisualStyleBackColor = false;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // error
            // 
            this.error.BackColor = System.Drawing.Color.White;
            this.error.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.error.Enabled = false;
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(55, 146);
            this.error.Name = "error";
            this.error.ReadOnly = true;
            this.error.Size = new System.Drawing.Size(145, 13);
            this.error.TabIndex = 34;
            this.error.TabStop = false;
            this.error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(254)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(802, 502);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.feedbackPanel.ResumeLayout(false);
            this.feedbackPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button donationBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Button profileButton;
        private Panel feedbackPanel;
        private Button submitFeedback;
        private TextBox feedbackTextBox;
        private Button button2;
        private Button button1;
        private TextBox error;
    }
}