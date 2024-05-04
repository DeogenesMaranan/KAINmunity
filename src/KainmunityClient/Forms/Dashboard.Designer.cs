namespace KainmunityClient.Forms
{
    partial class Dashboard
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
            this.firstName = new System.Windows.Forms.Label();
            this.donationBox = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Location = new System.Drawing.Point(203, 79);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(51, 13);
            this.firstName.TabIndex = 1;
            this.firstName.Text = "<default>";
            this.firstName.Click += new System.EventHandler(this.firstName_Click);
            // 
            // donationBox
            // 
            this.donationBox.Location = new System.Drawing.Point(193, 114);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(75, 23);
            this.donationBox.TabIndex = 2;
            this.donationBox.Text = "Donation";
            this.donationBox.UseVisualStyleBackColor = true;
            this.donationBox.Click += new System.EventHandler(this.donationBox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.donationBox);
            this.Controls.Add(this.firstName);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Button donationBox;
        private System.Windows.Forms.Button button1;
    }
}