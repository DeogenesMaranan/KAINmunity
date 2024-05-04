namespace KainmunityClient.Forms
{
    partial class DonationForm
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
            this.donorId = new System.Windows.Forms.TextBox();
            this.donationName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.donationQuanity = new System.Windows.Forms.TextBox();
            this.donationExpiry = new System.Windows.Forms.Label();
            this.donateButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // donorId
            // 
            this.donorId.Location = new System.Drawing.Point(226, 83);
            this.donorId.Name = "donorId";
            this.donorId.Size = new System.Drawing.Size(167, 20);
            this.donorId.TabIndex = 0;
            // 
            // donationName
            // 
            this.donationName.Location = new System.Drawing.Point(226, 134);
            this.donationName.Name = "donationName";
            this.donationName.Size = new System.Drawing.Size(167, 20);
            this.donationName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Donor ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Donation Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Donation Quantity";
            // 
            // donationQuanity
            // 
            this.donationQuanity.Location = new System.Drawing.Point(226, 187);
            this.donationQuanity.Name = "donationQuanity";
            this.donationQuanity.Size = new System.Drawing.Size(167, 20);
            this.donationQuanity.TabIndex = 4;
            // 
            // donationExpiry
            // 
            this.donationExpiry.AutoSize = true;
            this.donationExpiry.Location = new System.Drawing.Point(223, 230);
            this.donationExpiry.Name = "donationExpiry";
            this.donationExpiry.Size = new System.Drawing.Size(81, 13);
            this.donationExpiry.TabIndex = 7;
            this.donationExpiry.Text = "Donation Expiry";
            // 
            // donateButton
            // 
            this.donateButton.Location = new System.Drawing.Point(226, 289);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(75, 23);
            this.donateButton.TabIndex = 8;
            this.donateButton.Text = "Donate";
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(226, 246);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // DonationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.donationExpiry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.donationQuanity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.donationName);
            this.Controls.Add(this.donorId);
            this.Name = "DonationForm";
            this.Text = "DonationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox donorId;
        private System.Windows.Forms.TextBox donationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox donationQuanity;
        private System.Windows.Forms.Label donationExpiry;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}