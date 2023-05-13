namespace UI.User
{
    partial class ChangePassword
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CurrentPasswordBox = new TextBox();
            label1 = new Label();
            NewPasswordBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SaveButton = new Button();
            label4 = new Label();
            ConfirmNewPasswordBox = new TextBox();
            SuspendLayout();
            // 
            // CurrentPasswordBox
            // 
            CurrentPasswordBox.Location = new Point(207, 109);
            CurrentPasswordBox.Name = "CurrentPasswordBox";
            CurrentPasswordBox.Size = new Size(267, 27);
            CurrentPasswordBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(207, 43);
            label1.Name = "label1";
            label1.Size = new Size(255, 41);
            label1.TabIndex = 1;
            label1.Text = "Change password";
            // 
            // NewPasswordBox
            // 
            NewPasswordBox.Location = new Point(207, 162);
            NewPasswordBox.Name = "NewPasswordBox";
            NewPasswordBox.Size = new Size(267, 27);
            NewPasswordBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 112);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 3;
            label2.Text = "Current password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 165);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 4;
            label3.Text = "New password:";
            // 
            // SaveButton
            // 
            SaveButton.BackColor = SystemColors.ActiveCaption;
            SaveButton.Location = new Point(207, 273);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(267, 29);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 223);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 7;
            label4.Text = "Confirm new password:";
            // 
            // ConfirmNewPasswordBox
            // 
            ConfirmNewPasswordBox.Location = new Point(207, 220);
            ConfirmNewPasswordBox.Name = "ConfirmNewPasswordBox";
            ConfirmNewPasswordBox.Size = new Size(267, 27);
            ConfirmNewPasswordBox.TabIndex = 8;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 363);
            Controls.Add(ConfirmNewPasswordBox);
            Controls.Add(label4);
            Controls.Add(SaveButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NewPasswordBox);
            Controls.Add(label1);
            Controls.Add(CurrentPasswordBox);
            Name = "ChangePassword";
            Text = "Change password";
            Load += ChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CurrentPasswordBox;
        private Label label1;
        private TextBox NewPasswordBox;
        private Label label2;
        private Label label3;
        private Button SaveButton;
        private Label label4;
        private TextBox ConfirmNewPasswordBox;
    }
}