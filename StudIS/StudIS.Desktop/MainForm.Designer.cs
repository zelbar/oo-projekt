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
            this.userTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.studentRadioButton = new System.Windows.Forms.RadioButton();
            this.lecturerRadioButton = new System.Windows.Forms.RadioButton();
            this.adminRadioButton = new System.Windows.Forms.RadioButton();
            this.emailLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.userTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userTypeGroupBox
            // 
            this.userTypeGroupBox.Controls.Add(this.adminRadioButton);
            this.userTypeGroupBox.Controls.Add(this.lecturerRadioButton);
            this.userTypeGroupBox.Controls.Add(this.studentRadioButton);
            this.userTypeGroupBox.Location = new System.Drawing.Point(13, 13);
            this.userTypeGroupBox.Name = "userTypeGroupBox";
            this.userTypeGroupBox.Size = new System.Drawing.Size(259, 99);
            this.userTypeGroupBox.TabIndex = 0;
            this.userTypeGroupBox.TabStop = false;
            this.userTypeGroupBox.Text = "Vrsta korisnika";
            // 
            // studentRadioButton
            // 
            this.studentRadioButton.AutoSize = true;
            this.studentRadioButton.Location = new System.Drawing.Point(7, 20);
            this.studentRadioButton.Name = "studentRadioButton";
            this.studentRadioButton.Size = new System.Drawing.Size(62, 17);
            this.studentRadioButton.TabIndex = 0;
            this.studentRadioButton.TabStop = true;
            this.studentRadioButton.Text = "Student";
            this.studentRadioButton.UseVisualStyleBackColor = true;
            // 
            // lecturerRadioButton
            // 
            this.lecturerRadioButton.AutoSize = true;
            this.lecturerRadioButton.Location = new System.Drawing.Point(7, 43);
            this.lecturerRadioButton.Name = "lecturerRadioButton";
            this.lecturerRadioButton.Size = new System.Drawing.Size(64, 17);
            this.lecturerRadioButton.TabIndex = 1;
            this.lecturerRadioButton.TabStop = true;
            this.lecturerRadioButton.Text = "Profesor";
            this.lecturerRadioButton.UseVisualStyleBackColor = true;
            // 
            // adminRadioButton
            // 
            this.adminRadioButton.AutoSize = true;
            this.adminRadioButton.Location = new System.Drawing.Point(7, 66);
            this.adminRadioButton.Name = "adminRadioButton";
            this.adminRadioButton.Size = new System.Drawing.Size(85, 17);
            this.adminRadioButton.TabIndex = 2;
            this.adminRadioButton.TabStop = true;
            this.adminRadioButton.Text = "Administrator";
            this.adminRadioButton.UseVisualStyleBackColor = true;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(20, 119);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(163, 13);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "E-mail adresa korisničkog računa";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 2;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(13, 163);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(259, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "Unesi novog";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(13, 192);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(259, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Uredi";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 221);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(259, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Izbriši";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.userTypeGroupBox);
            this.Name = "MainForm";
            this.Text = "StudIS";
            this.userTypeGroupBox.ResumeLayout(false);
            this.userTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox userTypeGroupBox;
        private System.Windows.Forms.RadioButton adminRadioButton;
        private System.Windows.Forms.RadioButton lecturerRadioButton;
        private System.Windows.Forms.RadioButton studentRadioButton;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}