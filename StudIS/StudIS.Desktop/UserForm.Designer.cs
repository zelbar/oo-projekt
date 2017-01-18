namespace StudIS.Desktop
{
    partial class UserForm
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
            this.userInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.coursesGroupBox = new System.Windows.Forms.GroupBox();
            this.nationalIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.nationalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.studentIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.studentIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.accountGroupBox = new System.Windows.Forms.GroupBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordButton = new System.Windows.Forms.Button();
            this.coursesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.userInfoGroupBox.SuspendLayout();
            this.coursesGroupBox.SuspendLayout();
            this.accountGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInfoGroupBox
            // 
            this.userInfoGroupBox.Controls.Add(this.studentIdentificationNumberTextBox);
            this.userInfoGroupBox.Controls.Add(this.studentIdentificationNumberLabel);
            this.userInfoGroupBox.Controls.Add(this.nationalIdentificationNumberTextBox);
            this.userInfoGroupBox.Controls.Add(this.nationalIdentificationNumberLabel);
            this.userInfoGroupBox.Controls.Add(this.surnameTextBox);
            this.userInfoGroupBox.Controls.Add(this.surnameLabel);
            this.userInfoGroupBox.Controls.Add(this.nameTextBox);
            this.userInfoGroupBox.Controls.Add(this.nameLabel);
            this.userInfoGroupBox.Location = new System.Drawing.Point(13, 13);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Size = new System.Drawing.Size(315, 138);
            this.userInfoGroupBox.TabIndex = 0;
            this.userInfoGroupBox.TabStop = false;
            this.userInfoGroupBox.Text = "Podaci o korisniku";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(24, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Ime";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(197, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(9, 50);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(44, 13);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Prezime";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(112, 47);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(197, 20);
            this.surnameTextBox.TabIndex = 3;
            // 
            // coursesGroupBox
            // 
            this.coursesGroupBox.Controls.Add(this.coursesCheckedListBox);
            this.coursesGroupBox.Location = new System.Drawing.Point(335, 13);
            this.coursesGroupBox.Name = "coursesGroupBox";
            this.coursesGroupBox.Size = new System.Drawing.Size(253, 286);
            this.coursesGroupBox.TabIndex = 12;
            this.coursesGroupBox.TabStop = false;
            this.coursesGroupBox.Text = "Predmeti";
            // 
            // nationalIdentificationNumberLabel
            // 
            this.nationalIdentificationNumberLabel.AutoSize = true;
            this.nationalIdentificationNumberLabel.Location = new System.Drawing.Point(9, 77);
            this.nationalIdentificationNumberLabel.Name = "nationalIdentificationNumberLabel";
            this.nationalIdentificationNumberLabel.Size = new System.Drawing.Size(25, 13);
            this.nationalIdentificationNumberLabel.TabIndex = 4;
            this.nationalIdentificationNumberLabel.Text = "OIB";
            // 
            // nationalIdentificationNumberTextBox
            // 
            this.nationalIdentificationNumberTextBox.Location = new System.Drawing.Point(112, 74);
            this.nationalIdentificationNumberTextBox.Name = "nationalIdentificationNumberTextBox";
            this.nationalIdentificationNumberTextBox.Size = new System.Drawing.Size(197, 20);
            this.nationalIdentificationNumberTextBox.TabIndex = 5;
            // 
            // studentIdentificationNumberLabel
            // 
            this.studentIdentificationNumberLabel.AutoSize = true;
            this.studentIdentificationNumberLabel.Location = new System.Drawing.Point(9, 107);
            this.studentIdentificationNumberLabel.Name = "studentIdentificationNumberLabel";
            this.studentIdentificationNumberLabel.Size = new System.Drawing.Size(43, 13);
            this.studentIdentificationNumberLabel.TabIndex = 6;
            this.studentIdentificationNumberLabel.Text = "JMBAG";
            // 
            // studentIdentificationNumberTextBox
            // 
            this.studentIdentificationNumberTextBox.Location = new System.Drawing.Point(112, 104);
            this.studentIdentificationNumberTextBox.Name = "studentIdentificationNumberTextBox";
            this.studentIdentificationNumberTextBox.Size = new System.Drawing.Size(197, 20);
            this.studentIdentificationNumberTextBox.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 261);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Pohrani";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // accountGroupBox
            // 
            this.accountGroupBox.Controls.Add(this.passwordButton);
            this.accountGroupBox.Controls.Add(this.passwordLabel);
            this.accountGroupBox.Controls.Add(this.emailTextBox);
            this.accountGroupBox.Controls.Add(this.emailLabel);
            this.accountGroupBox.Location = new System.Drawing.Point(13, 158);
            this.accountGroupBox.Name = "accountGroupBox";
            this.accountGroupBox.Size = new System.Drawing.Size(315, 97);
            this.accountGroupBox.TabIndex = 9;
            this.accountGroupBox.TabStop = false;
            this.accountGroupBox.Text = "Podaci o računu";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(7, 20);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-mail";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(112, 17);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(197, 20);
            this.emailTextBox.TabIndex = 10;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(9, 49);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(44, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Lozinka";
            // 
            // passwordButton
            // 
            this.passwordButton.Location = new System.Drawing.Point(112, 44);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(197, 23);
            this.passwordButton.TabIndex = 11;
            this.passwordButton.Text = "Generiraj novu";
            this.passwordButton.UseVisualStyleBackColor = true;
            // 
            // coursesCheckedListBox
            // 
            this.coursesCheckedListBox.FormattingEnabled = true;
            this.coursesCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.coursesCheckedListBox.Name = "coursesCheckedListBox";
            this.coursesCheckedListBox.Size = new System.Drawing.Size(241, 259);
            this.coursesCheckedListBox.TabIndex = 13;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 306);
            this.Controls.Add(this.accountGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.coursesGroupBox);
            this.Controls.Add(this.userInfoGroupBox);
            this.Name = "UserForm";
            this.Text = "Korisnik";
            this.userInfoGroupBox.ResumeLayout(false);
            this.userInfoGroupBox.PerformLayout();
            this.coursesGroupBox.ResumeLayout(false);
            this.accountGroupBox.ResumeLayout(false);
            this.accountGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userInfoGroupBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.GroupBox coursesGroupBox;
        private System.Windows.Forms.TextBox nationalIdentificationNumberTextBox;
        private System.Windows.Forms.Label nationalIdentificationNumberLabel;
        private System.Windows.Forms.TextBox studentIdentificationNumberTextBox;
        private System.Windows.Forms.Label studentIdentificationNumberLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox accountGroupBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button passwordButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckedListBox coursesCheckedListBox;
    }
}