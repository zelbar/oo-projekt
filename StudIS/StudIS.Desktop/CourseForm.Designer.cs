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
            this.naturalIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.naturalIdentifierLabel = new System.Windows.Forms.Label();
            this.EctsPointsLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.courseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ectsCreditsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LecturerscheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.studentsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.lecturersLabel = new System.Windows.Forms.Label();
            this.studentsGroupBox.SuspendLayout();
            this.courseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ectsCreditsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 252);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Pohrani";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // studentsGroupBox
            // 
            this.studentsGroupBox.Controls.Add(this.studentsCheckedListBox);
            this.studentsGroupBox.Location = new System.Drawing.Point(334, 12);
            this.studentsGroupBox.Name = "studentsGroupBox";
            this.studentsGroupBox.Size = new System.Drawing.Size(238, 271);
            this.studentsGroupBox.TabIndex = 17;
            this.studentsGroupBox.TabStop = false;
            this.studentsGroupBox.Text = "Upisani studenti";
            // 
            // naturalIdentifierTextBox
            // 
            this.naturalIdentifierTextBox.Location = new System.Drawing.Point(112, 47);
            this.naturalIdentifierTextBox.Name = "naturalIdentifierTextBox";
            this.naturalIdentifierTextBox.Size = new System.Drawing.Size(197, 20);
            this.naturalIdentifierTextBox.TabIndex = 2;
            // 
            // naturalIdentifierLabel
            // 
            this.naturalIdentifierLabel.AutoSize = true;
            this.naturalIdentifierLabel.Location = new System.Drawing.Point(9, 50);
            this.naturalIdentifierLabel.Name = "naturalIdentifierLabel";
            this.naturalIdentifierLabel.Size = new System.Drawing.Size(28, 13);
            this.naturalIdentifierLabel.TabIndex = 2;
            this.naturalIdentifierLabel.Text = "Šifra";
            // 
            // EctsPointsLabel
            // 
            this.EctsPointsLabel.AutoSize = true;
            this.EctsPointsLabel.Location = new System.Drawing.Point(9, 77);
            this.EctsPointsLabel.Name = "EctsPointsLabel";
            this.EctsPointsLabel.Size = new System.Drawing.Size(70, 13);
            this.EctsPointsLabel.TabIndex = 4;
            this.EctsPointsLabel.Text = "ECTS bodovi";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(197, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 13);
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
            this.courseInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.courseInfoGroupBox.Name = "courseInfoGroupBox";
            this.courseInfoGroupBox.Size = new System.Drawing.Size(315, 111);
            this.courseInfoGroupBox.TabIndex = 0;
            this.courseInfoGroupBox.TabStop = false;
            this.courseInfoGroupBox.Text = "Podaci o predmetu";
            // 
            // ectsCreditsNumericUpDown
            // 
            this.ectsCreditsNumericUpDown.Location = new System.Drawing.Point(112, 77);
            this.ectsCreditsNumericUpDown.Name = "ectsCreditsNumericUpDown";
            this.ectsCreditsNumericUpDown.Size = new System.Drawing.Size(197, 20);
            this.ectsCreditsNumericUpDown.TabIndex = 3;
            // 
            // LecturerscheckedListBox
            // 
            this.LecturerscheckedListBox.FormattingEnabled = true;
            this.LecturerscheckedListBox.Location = new System.Drawing.Point(124, 136);
            this.LecturerscheckedListBox.Name = "LecturerscheckedListBox";
            this.LecturerscheckedListBox.Size = new System.Drawing.Size(197, 139);
            this.LecturerscheckedListBox.TabIndex = 5;
            // 
            // studentsCheckedListBox
            // 
            this.studentsCheckedListBox.FormattingEnabled = true;
            this.studentsCheckedListBox.Location = new System.Drawing.Point(7, 19);
            this.studentsCheckedListBox.Name = "studentsCheckedListBox";
            this.studentsCheckedListBox.Size = new System.Drawing.Size(225, 244);
            this.studentsCheckedListBox.TabIndex = 0;
            // 
            // lecturersLabel
            // 
            this.lecturersLabel.AutoSize = true;
            this.lecturersLabel.Location = new System.Drawing.Point(14, 136);
            this.lecturersLabel.Name = "lecturersLabel";
            this.lecturersLabel.Size = new System.Drawing.Size(55, 13);
            this.lecturersLabel.TabIndex = 19;
            this.lecturersLabel.Text = "Predavači";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 296);
            this.Controls.Add(this.LecturerscheckedListBox);
            this.Controls.Add(this.lecturersLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.studentsGroupBox);
            this.Controls.Add(this.courseInfoGroupBox);
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
        private System.Windows.Forms.CheckedListBox LecturerscheckedListBox;
        private System.Windows.Forms.CheckedListBox studentsCheckedListBox;
        private System.Windows.Forms.Label lecturersLabel;
    }
}