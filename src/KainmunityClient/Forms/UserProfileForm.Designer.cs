using System;

namespace KainmunityClient.Forms
{
    partial class UserProfileForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.error = new System.Windows.Forms.TextBox();
            this.donationHistory = new System.Windows.Forms.Button();
            this.viewRequestsButton = new System.Windows.Forms.Button();
            this.showPassword = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.householdSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.yearlyIncome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.homeAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contactNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.error);
            this.panel1.Controls.Add(this.donationHistory);
            this.panel1.Controls.Add(this.viewRequestsButton);
            this.panel1.Controls.Add(this.showPassword);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.householdSize);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.yearlyIncome);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.homeAddress);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.contactNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.emailAddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lastName);
            this.panel1.Controls.Add(this.firstName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(152, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 449);
            this.panel1.TabIndex = 0;
            // 
            // error
            // 
            this.error.BackColor = System.Drawing.Color.White;
            this.error.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.error.Enabled = false;
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(180, 368);
            this.error.Name = "error";
            this.error.ReadOnly = true;
            this.error.Size = new System.Drawing.Size(145, 13);
            this.error.TabIndex = 33;
            this.error.TabStop = false;
            this.error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // donationHistory
            // 
            this.donationHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.donationHistory.FlatAppearance.BorderSize = 0;
            this.donationHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationHistory.ForeColor = System.Drawing.Color.White;
            this.donationHistory.Location = new System.Drawing.Point(37, 383);
            this.donationHistory.Margin = new System.Windows.Forms.Padding(2);
            this.donationHistory.Name = "donationHistory";
            this.donationHistory.Size = new System.Drawing.Size(120, 40);
            this.donationHistory.TabIndex = 21;
            this.donationHistory.Text = "DONATIONS";
            this.donationHistory.UseVisualStyleBackColor = false;
            this.donationHistory.Click += new System.EventHandler(this.ShowDonationHistory);
            // 
            // viewRequestsButton
            // 
            this.viewRequestsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.viewRequestsButton.FlatAppearance.BorderSize = 0;
            this.viewRequestsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewRequestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRequestsButton.ForeColor = System.Drawing.Color.White;
            this.viewRequestsButton.Location = new System.Drawing.Point(357, 383);
            this.viewRequestsButton.Margin = new System.Windows.Forms.Padding(2);
            this.viewRequestsButton.Name = "viewRequestsButton";
            this.viewRequestsButton.Size = new System.Drawing.Size(120, 40);
            this.viewRequestsButton.TabIndex = 20;
            this.viewRequestsButton.Text = "REQUESTS";
            this.viewRequestsButton.UseVisualStyleBackColor = false;
            this.viewRequestsButton.Click += new System.EventHandler(this.ShowRequestHistory);
            // 
            // showPassword
            // 
            this.showPassword.BackColor = System.Drawing.SystemColors.Window;
            this.showPassword.BackgroundImage = global::KainmunityClient.Properties.Resources.show;
            this.showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showPassword.FlatAppearance.BorderSize = 0;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword.Font = new System.Drawing.Font("Tw Cen MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword.Location = new System.Drawing.Point(366, 338);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(26, 17);
            this.showPassword.TabIndex = 19;
            this.showPassword.UseVisualStyleBackColor = false;
            this.showPassword.Visible = false;
            this.showPassword.Click += new System.EventHandler(this.showPassword_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(120, 317);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 17);
            this.labelPassword.TabIndex = 18;
            this.labelPassword.Text = "Password";
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.Window;
            this.password.Location = new System.Drawing.Point(123, 336);
            this.password.Name = "password";
            this.password.ReadOnly = true;
            this.password.Size = new System.Drawing.Size(270, 20);
            this.password.TabIndex = 17;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.showIcon);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.back.Location = new System.Drawing.Point(14, 14);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(52, 23);
            this.back.TabIndex = 16;
            this.back.Text = "BACK";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.ReturnToDashboard);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(93)))), ((int)(((byte)(102)))));
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(197, 383);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(120, 40);
            this.save.TabIndex = 15;
            this.save.Text = "SAVE";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.UploadInformation);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(284, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Household Size";
            // 
            // householdSize
            // 
            this.householdSize.BackColor = System.Drawing.SystemColors.Window;
            this.householdSize.Location = new System.Drawing.Point(278, 289);
            this.householdSize.Name = "householdSize";
            this.householdSize.ReadOnly = true;
            this.householdSize.Size = new System.Drawing.Size(115, 20);
            this.householdSize.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(120, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Annual Income";
            // 
            // yearlyIncome
            // 
            this.yearlyIncome.BackColor = System.Drawing.SystemColors.Window;
            this.yearlyIncome.Location = new System.Drawing.Point(123, 289);
            this.yearlyIncome.Name = "yearlyIncome";
            this.yearlyIncome.ReadOnly = true;
            this.yearlyIncome.Size = new System.Drawing.Size(149, 20);
            this.yearlyIncome.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(120, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Home Address";
            // 
            // homeAddress
            // 
            this.homeAddress.BackColor = System.Drawing.SystemColors.Window;
            this.homeAddress.Location = new System.Drawing.Point(123, 242);
            this.homeAddress.Name = "homeAddress";
            this.homeAddress.ReadOnly = true;
            this.homeAddress.Size = new System.Drawing.Size(270, 20);
            this.homeAddress.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contact Number";
            // 
            // contactNumber
            // 
            this.contactNumber.BackColor = System.Drawing.SystemColors.Window;
            this.contactNumber.Location = new System.Drawing.Point(123, 195);
            this.contactNumber.Name = "contactNumber";
            this.contactNumber.ReadOnly = true;
            this.contactNumber.Size = new System.Drawing.Size(270, 20);
            this.contactNumber.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email Address";
            // 
            // emailAddress
            // 
            this.emailAddress.BackColor = System.Drawing.SystemColors.Window;
            this.emailAddress.Location = new System.Drawing.Point(123, 148);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.ReadOnly = true;
            this.emailAddress.Size = new System.Drawing.Size(270, 20);
            this.emailAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(275, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // lastName
            // 
            this.lastName.BackColor = System.Drawing.SystemColors.Window;
            this.lastName.Location = new System.Drawing.Point(278, 101);
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            this.lastName.Size = new System.Drawing.Size(115, 20);
            this.lastName.TabIndex = 2;
            // 
            // firstName
            // 
            this.firstName.BackColor = System.Drawing.SystemColors.Window;
            this.firstName.Location = new System.Drawing.Point(123, 101);
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Size = new System.Drawing.Size(149, 20);
            this.firstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(170, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROFILE";
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(802, 502);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserProfileForm";
            this.Load += new System.EventHandler(this.FillUpInformation);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TextBox contactNumber;
        private System.Windows.Forms.TextBox homeAddress;
        private System.Windows.Forms.TextBox yearlyIncome;
        private System.Windows.Forms.TextBox householdSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6; // Changed label6 to a unique name
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox emailAddress;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.Button viewRequestsButton;
        private System.Windows.Forms.Button donationHistory;
        private System.Windows.Forms.TextBox error;
    }
}
