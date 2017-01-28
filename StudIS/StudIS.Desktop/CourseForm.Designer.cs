namespace StudIS.Desktop
{
    partial class CourseForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.studentsGroupBox = new System.Windows.Forms.GroupBox();
            this.studentsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.naturalIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.naturalIdentifierLabel = new System.Windows.Forms.Label();
            this.EctsPointsLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.courseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ectsCreditsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lecturersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.lecturersLabel = new System.Windows.Forms.Label();
            this.studentsGroupBox.SuspendLayout();
            this.courseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ectsCreditsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(16, 310);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Pohrani";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // studentsGroupBox
            // 
            this.studentsGroupBox.Controls.Add(this.studentsCheckedListBox);
            this.studentsGroupBox.Location = new System.Drawing.Point(445, 15);
            this.studentsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.studentsGroupBox.Name = "studentsGroupBox";
            this.studentsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.studentsGroupBox.Size = new System.Drawing.Size(317, 334);
            this.studentsGroupBox.TabIndex = 17;
            this.studentsGroupBox.TabStop = false;
            this.studentsGroupBox.Text = "Upisani studenti";
            // 
            // studentsCheckedListBox
            // 
            this.studentsCheckedListBox.FormattingEnabled = true;
            this.studentsCheckedListBox.Location = new System.Drawing.Point(9, 23);
            this.studentsCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.studentsCheckedListBox.Name = "studentsCheckedListBox";
            this.studentsCheckedListBox.Size = new System.Drawing.Size(299, 293);
            this.studentsCheckedListBox.TabIndex = 0;
            // 
            // naturalIdentifierTextBox
            // 
            this.naturalIdentifierTextBox.Location = new System.Drawing.Point(149, 58);
            this.naturalIdentifierTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.naturalIdentifierTextBox.Name = "naturalIdentifierTextBox";
            this.naturalIdentifierTextBox.Size = new System.Drawing.Size(261, 22);
            this.naturalIdentifierTextBox.TabIndex = 2;
            // 
            // naturalIdentifierLabel
            // 
            this.naturalIdentifierLabel.AutoSize = true;
            this.naturalIdentifierLabel.Location = new System.Drawing.Point(12, 62);
            this.naturalIdentifierLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.naturalIdentifierLabel.Name = "naturalIdentifierLabel";
            this.naturalIdentifierLabel.Size = new System.Drawing.Size(37, 17);
            this.naturalIdentifierLabel.TabIndex = 2;
            this.naturalIdentifierLabel.Text = "Šifra";
            // 
            // EctsPointsLabel
            // 
            this.EctsPointsLabel.AutoSize = true;
            this.EctsPointsLabel.Location = new System.Drawing.Point(12, 95);
            this.EctsPointsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EctsPointsLabel.Name = "EctsPointsLabel";
            this.EctsPointsLabel.Size = new System.Drawing.Size(90, 17);
            this.EctsPointsLabel.TabIndex = 4;
            this.EctsPointsLabel.Text = "ECTS bodovi";
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
            this.nameLabel.Size = new System.Drawing.Size(43, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Naziv";
            // 
            // courseInfoGroupBox
            // 
            this.courseInfoGroupBox.Controls.Add(this.ectsCreditsNumericUpDown);
            this.courseInfoGroupBox.Controls.Add(this.EctsPointsLabel);
            this.courseInfoGroupBox.Controls.Add(this.naturalIdentifierTextBox);
            this.courseInfoGroupBox.Controls.Add(this.naturalIdentifierLabel);
            this.courseInfoGroupBox.Controls.Add(this.nameTextBox);
            this.courseInfoGroupBox.Controls.Add(this.nameLabel);
            this.courseInfoGroupBox.Location = new System.Drawing.Point(16, 15);
            this.courseInfoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseInfoGroupBox.Name = "courseInfoGroupBox";
            this.courseInfoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.courseInfoGroupBox.Size = new System.Drawing.Size(420, 137);
            this.courseInfoGroupBox.TabIndex = 0;
            this.courseInfoGroupBox.TabStop = false;
            this.courseInfoGroupBox.Text = "Podaci o predmetu";
            // 
            // ectsCreditsNumericUpDown
            // 
            this.ectsCreditsNumericUpDown.Location = new System.Drawing.Point(149, 95);
            this.ectsCreditsNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.ectsCreditsNumericUpDown.Name = "ectsCreditsNumericUpDown";
            this.ectsCreditsNumericUpDown.Size = new System.Drawing.Size(263, 22);
            this.ectsCreditsNumericUpDown.TabIndex = 3;
            // 
            // lecturersCheckedListBox
            // 
            this.lecturersCheckedListBox.FormattingEnabled = true;
            this.lecturersCheckedListBox.Location = new System.Drawing.Point(165, 167);
            this.lecturersCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.lecturersCheckedListBox.Name = "lecturersCheckedListBox";
            this.lecturersCheckedListBox.Size = new System.Drawing.Size(261, 157);
            this.lecturersCheckedListBox.TabIndex = 5;
            // 
            // lecturersLabel
            // 
            this.lecturersLabel.AutoSize = true;
            this.lecturersLabel.Location = new System.Drawing.Point(19, 167);
            this.lecturersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lecturersLabel.Name = "lecturersLabel";
            this.lecturersLabel.Size = new System.Drawing.Size(71, 17);
            this.lecturersLabel.TabIndex = 19;
            this.lecturersLabel.Text = "Predavači";
            // 
            // CourseForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 364);
            this.Controls.Add(this.lecturersCheckedListBox);
            this.Controls.Add(this.lecturersLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.studentsGroupBox);
            this.Controls.Add(this.courseInfoGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CourseForm";
            this.Text = "Predmet";
            this.studentsGroupBox.ResumeLayout(false);
            this.courseInfoGroupBox.ResumeLayout(false);
            this.courseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ectsCreditsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox studentsGroupBox;
        private System.Windows.Forms.TextBox naturalIdentifierTextBox;
        private System.Windows.Forms.Label naturalIdentifierLabel;
        private System.Windows.Forms.Label EctsPointsLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.GroupBox courseInfoGroupBox;
        private System.Windows.Forms.NumericUpDown ectsCreditsNumericUpDown;
        private System.Windows.Forms.CheckedListBox lecturersCheckedListBox;
        private System.Windows.Forms.CheckedListBox studentsCheckedListBox;
        private System.Windows.Forms.Label lecturersLabel;
    }
}