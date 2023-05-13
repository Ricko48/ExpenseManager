namespace UI.User
{
    partial class UserDetail
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
            UserNameLabel = new Label();
            FirstNameLabel = new Label();
            LastNameLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameLabel.Location = new Point(205, 28);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(109, 46);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "label1";
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            FirstNameLabel.Location = new Point(205, 91);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(81, 35);
            FirstNameLabel.TabIndex = 1;
            FirstNameLabel.Text = "label2";
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LastNameLabel.Location = new Point(205, 151);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(81, 35);
            LastNameLabel.TabIndex = 2;
            LastNameLabel.Text = "label3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 48);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 103);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 4;
            label2.Text = "First name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 163);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 5;
            label3.Text = "Last name:";
            // 
            // UserDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 253);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LastNameLabel);
            Controls.Add(FirstNameLabel);
            Controls.Add(UserNameLabel);
            Name = "UserDetail";
            Text = "User info";
            Load += UserDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLabel;
        private Label FirstNameLabel;
        private Label LastNameLabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}