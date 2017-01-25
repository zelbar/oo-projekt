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
            this.studentIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.studentIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.nationalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.nationalIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.coursesGroupBox = new System.Windows.Forms.GroupBox();
            this.coursesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.accountGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
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
            this.userInfoGroupBox.Location = new System.Drawing.Point(17, 16);
            this.userInfoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.userInfoGroupBox.Size = new System.Drawing.Size(420, 170);
            this.userInfoGroupBox.TabIndex = 0;
            this.userInfoGroupBox.TabStop = false;
            this.userInfoGroupBox.Text = "Podaci o korisniku";
            // 
            // studentIdentificationNumberTextBox
            // 
            this.studentIdentificationNumberTextBox.Location = new System.Drawing.Point(149, 128);
            this.studentIdentificationNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.studentIdentificationNumberTextBox.Name = "studentIdentificationNumberTextBox";
            this.studentIdentificationNumberTextBox.Size = new System.Drawing.Size(261, 22);
            this.studentIdentificationNumberTextBox.TabIndex = 7;
            // 
            // studentIdentificationNumberLabel
            // 
            this.studentIdentificationNumberLabel.AutoSize = true;
            this.studentIdentificationNumberLabel.Location = new System.Drawing.Point(12, 132);
            this.studentIdentificationNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.studentIdentificationNumberLabel.Name = "studentIdentificationNumberLabel";
            this.studentIdentificationNumberLabel.Size = new System.Drawing.Size(55, 17);
            this.studentIdentificationNumberLabel.TabIndex = 6;
            this.studentIdentificationNumberLabel.Text = "JMBAG";
            // 
            // nationalIdentificationNumberTextBox
            // 
            this.nationalIdentificationNumberTextBox.Location = new System.Drawing.Point(149, 91);
            this.nationalIdentificationNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nationalIdentificationNumberTextBox.Name = "nationalIdentificationNumberTextBox";
            this.nationalIdentificationNumberTextBox.Size = new System.Drawing.Size(261, 22);
            this.nationalIdentificationNumberTextBox.TabIndex = 5;
            // 
            // nationalIdentificationNumberLabel
            // 
            this.nationalIdentificationNumberLabel.AutoSize = true;
            this.nationalIdentificationNumberLabel.Location = new System.Drawing.Point(12, 95);
            this.nationalIdentificationNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nationalIdentificationNumberLabel.Name = "nationalIdentificationNumberLabel";
            this.nationalIdentificationNumberLabel.Size = new System.Drawing.Size(31, 17);
            this.nationalIdentificationNumberLabel.TabIndex = 4;
            this.nationalIdentificationNumberLabel.Text = "OIB";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(149, 58);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(261, 22);
            this.surnameTextBox.TabIndex = 3;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(12, 62);
            this.surnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(59, 17);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Prezime";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(149, 23);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(261, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 28);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(30, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Ime";
            // 
            // coursesGroupBox
            // 
            this.coursesGroupBox.Controls.Add(this.coursesCheckedListBox);
            this.coursesGroupBox.Location = new System.Drawing.Point(447, 16);
            this.coursesGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.coursesGroupBox.Name = "coursesGroupBox";
            this.coursesGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.coursesGroupBox.Size = new System.Drawing.Size(337, 352);
            this.coursesGroupBox.TabIndex = 12;
            this.coursesGroupBox.TabStop = false;
            this.coursesGroupBox.Text = "Predmeti";
            // 
            // coursesCheckedListBox
            // 
            this.coursesCheckedListBox.FormattingEnabled = true;
            this.coursesCheckedListBox.Location = new System.Drawing.Point(8, 23);
            this.coursesCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.coursesCheckedListBox.Name = "coursesCheckedListBox";
            this.coursesCheckedListBox.Size = new System.Drawing.Size(320, 310);
            this.coursesCheckedListBox.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(17, 321);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Pohrani";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // accountGroupBox
            // 
            this.accountGroupBox.Controls.Add(this.passwordTextBox);
            this.accountGroupBox.Controls.Add(this.passwordLabel);
            this.accountGroupBox.Controls.Add(this.emailTextBox);
            this.accountGroupBox.Controls.Add(this.emailLabel);
            this.accountGroupBox.Location = new System.Drawing.Point(17, 194);
            this.accountGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.accountGroupBox.Name = "accountGroupBox";
            this.accountGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.accountGroupBox.Size = new System.Drawing.Size(420, 119);
            this.accountGroupBox.TabIndex = 9;
            this.accountGroupBox.TabStop = false;
            this.accountGroupBox.Text = "Podaci o računu";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(9, 60);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 17);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Lozinka";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(149, 21);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(261, 22);
            this.emailTextBox.TabIndex = 10;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(9, 25);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(47, 17);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-mail";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(149, 60);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(261, 22);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // UserForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 377);
            this.Controls.Add(this.accountGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.coursesGroupBox);
            this.Controls.Add(this.userInfoGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckedListBox coursesCheckedListBox;
        private System.Windows.Forms.TextBox passwordTextBox;
    }
}