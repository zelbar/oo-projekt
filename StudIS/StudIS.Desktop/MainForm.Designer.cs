namespace StudIS.Desktop
{
    partial class MainForm
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
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.newUserButton = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.studentRadioButton = new System.Windows.Forms.RadioButton();
            this.lecturerRadioButton = new System.Windows.Forms.RadioButton();
            this.adminRadioButton = new System.Windows.Forms.RadioButton();
            this.userTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.usersGroupBox = new System.Windows.Forms.GroupBox();
            this.coursesGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteCourseButton = new System.Windows.Forms.Button();
            this.editCourseButton = new System.Windows.Forms.Button();
            this.newCourseButton = new System.Windows.Forms.Button();
            this.coursesListBox = new System.Windows.Forms.ListBox();
            this.userTypeGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.usersGroupBox.SuspendLayout();
            this.coursesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(13, 148);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(218, 17);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "E-mail adresa korisničkog računa";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(7, 169);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(275, 22);
            this.emailTextBox.TabIndex = 2;
            // 
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(7, 199);
            this.newUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(275, 28);
            this.newUserButton.TabIndex = 3;
            this.newUserButton.Text = "Unesi novog";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // editUserButton
            // 
            this.editUserButton.Location = new System.Drawing.Point(7, 235);
            this.editUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(275, 28);
            this.editUserButton.TabIndex = 4;
            this.editUserButton.Text = "Uredi";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(7, 271);
            this.deleteUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(275, 28);
            this.deleteUserButton.TabIndex = 5;
            this.deleteUserButton.Text = "Izbriši";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // studentRadioButton
            // 
            this.studentRadioButton.AutoSize = true;
            this.studentRadioButton.Location = new System.Drawing.Point(9, 25);
            this.studentRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.studentRadioButton.Name = "studentRadioButton";
            this.studentRadioButton.Size = new System.Drawing.Size(78, 21);
            this.studentRadioButton.TabIndex = 0;
            this.studentRadioButton.TabStop = true;
            this.studentRadioButton.Text = "Student";
            this.studentRadioButton.UseVisualStyleBackColor = true;
            // 
            // lecturerRadioButton
            // 
            this.lecturerRadioButton.AutoSize = true;
            this.lecturerRadioButton.Location = new System.Drawing.Point(9, 53);
            this.lecturerRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.lecturerRadioButton.Name = "lecturerRadioButton";
            this.lecturerRadioButton.Size = new System.Drawing.Size(83, 21);
            this.lecturerRadioButton.TabIndex = 1;
            this.lecturerRadioButton.TabStop = true;
            this.lecturerRadioButton.Text = "Profesor";
            this.lecturerRadioButton.UseVisualStyleBackColor = true;
            // 
            // adminRadioButton
            // 
            this.adminRadioButton.AutoSize = true;
            this.adminRadioButton.Location = new System.Drawing.Point(9, 81);
            this.adminRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.adminRadioButton.Name = "adminRadioButton";
            this.adminRadioButton.Size = new System.Drawing.Size(112, 21);
            this.adminRadioButton.TabIndex = 2;
            this.adminRadioButton.TabStop = true;
            this.adminRadioButton.Text = "Administrator";
            this.adminRadioButton.UseVisualStyleBackColor = true;
            // 
            // userTypeGroupBox
            // 
            this.userTypeGroupBox.Controls.Add(this.adminRadioButton);
            this.userTypeGroupBox.Controls.Add(this.lecturerRadioButton);
            this.userTypeGroupBox.Controls.Add(this.studentRadioButton);
            this.userTypeGroupBox.Location = new System.Drawing.Point(7, 22);
            this.userTypeGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.userTypeGroupBox.Name = "userTypeGroupBox";
            this.userTypeGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.userTypeGroupBox.Size = new System.Drawing.Size(275, 122);
            this.userTypeGroupBox.TabIndex = 0;
            this.userTypeGroupBox.TabStop = false;
            this.userTypeGroupBox.Text = "Vrsta korisnika";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.usersGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.coursesGroupBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 313);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // usersGroupBox
            // 
            this.usersGroupBox.Controls.Add(this.userTypeGroupBox);
            this.usersGroupBox.Controls.Add(this.deleteUserButton);
            this.usersGroupBox.Controls.Add(this.emailLabel);
            this.usersGroupBox.Controls.Add(this.editUserButton);
            this.usersGroupBox.Controls.Add(this.emailTextBox);
            this.usersGroupBox.Controls.Add(this.newUserButton);
            this.usersGroupBox.Location = new System.Drawing.Point(3, 3);
            this.usersGroupBox.Name = "usersGroupBox";
            this.usersGroupBox.Size = new System.Drawing.Size(293, 307);
            this.usersGroupBox.TabIndex = 0;
            this.usersGroupBox.TabStop = false;
            this.usersGroupBox.Text = "Korisnici";
            // 
            // coursesGroupBox
            // 
            this.coursesGroupBox.Controls.Add(this.deleteCourseButton);
            this.coursesGroupBox.Controls.Add(this.editCourseButton);
            this.coursesGroupBox.Controls.Add(this.newCourseButton);
            this.coursesGroupBox.Controls.Add(this.coursesListBox);
            this.coursesGroupBox.Location = new System.Drawing.Point(302, 3);
            this.coursesGroupBox.Name = "coursesGroupBox";
            this.coursesGroupBox.Size = new System.Drawing.Size(293, 299);
            this.coursesGroupBox.TabIndex = 1;
            this.coursesGroupBox.TabStop = false;
            this.coursesGroupBox.Text = "Predmeti";
            // 
            // deleteCourseButton
            // 
            this.deleteCourseButton.Location = new System.Drawing.Point(7, 271);
            this.deleteCourseButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteCourseButton.Name = "deleteCourseButton";
            this.deleteCourseButton.Size = new System.Drawing.Size(279, 28);
            this.deleteCourseButton.TabIndex = 8;
            this.deleteCourseButton.Text = "Izbriši";
            this.deleteCourseButton.UseVisualStyleBackColor = true;
            this.deleteCourseButton.Click += new System.EventHandler(this.deleteCourseButton_Click);
            // 
            // editCourseButton
            // 
            this.editCourseButton.Location = new System.Drawing.Point(7, 235);
            this.editCourseButton.Margin = new System.Windows.Forms.Padding(4);
            this.editCourseButton.Name = "editCourseButton";
            this.editCourseButton.Size = new System.Drawing.Size(279, 28);
            this.editCourseButton.TabIndex = 7;
            this.editCourseButton.Text = "Uredi";
            this.editCourseButton.UseVisualStyleBackColor = true;
            this.editCourseButton.Click += new System.EventHandler(this.editCourseButton_Click);
            // 
            // newCourseButton
            // 
            this.newCourseButton.Location = new System.Drawing.Point(7, 199);
            this.newCourseButton.Margin = new System.Windows.Forms.Padding(4);
            this.newCourseButton.Name = "newCourseButton";
            this.newCourseButton.Size = new System.Drawing.Size(279, 28);
            this.newCourseButton.TabIndex = 6;
            this.newCourseButton.Text = "Unesi novi";
            this.newCourseButton.UseVisualStyleBackColor = true;
            this.newCourseButton.Click += new System.EventHandler(this.newCourseButton_Click);
            // 
            // coursesListBox
            // 
            this.coursesListBox.FormattingEnabled = true;
            this.coursesListBox.ItemHeight = 16;
            this.coursesListBox.Location = new System.Drawing.Point(7, 22);
            this.coursesListBox.Name = "coursesListBox";
            this.coursesListBox.ScrollAlwaysVisible = true;
            this.coursesListBox.Size = new System.Drawing.Size(279, 164);
            this.coursesListBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 353);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "StudIS";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.userTypeGroupBox.ResumeLayout(false);
            this.userTypeGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.usersGroupBox.ResumeLayout(false);
            this.usersGroupBox.PerformLayout();
            this.coursesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.RadioButton studentRadioButton;
        private System.Windows.Forms.RadioButton lecturerRadioButton;
        private System.Windows.Forms.RadioButton adminRadioButton;
        private System.Windows.Forms.GroupBox userTypeGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox usersGroupBox;
        private System.Windows.Forms.GroupBox coursesGroupBox;
        private System.Windows.Forms.Button newCourseButton;
        private System.Windows.Forms.ListBox coursesListBox;
        private System.Windows.Forms.Button deleteCourseButton;
        private System.Windows.Forms.Button editCourseButton;
    }
}