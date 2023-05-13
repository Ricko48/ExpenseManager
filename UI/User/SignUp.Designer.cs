namespace UI.User
{
    partial class SignUp
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
            UsernameBox = new TextBox();
            label1 = new Label();
            PasswordBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SignInButton = new Button();
            button2 = new Button();
            FirstNameBox = new TextBox();
            LastNameBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            ConfirmPasswordBox = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(155, 106);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(267, 27);
            UsernameBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(230, 51);
            label1.Name = "label1";
            label1.Size = new Size(119, 41);
            label1.TabIndex = 1;
            label1.Text = "Sign up";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(155, 159);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(267, 27);
            PasswordBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 109);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 162);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // SignInButton
            // 
            SignInButton.BackColor = SystemColors.ActiveCaption;
            SignInButton.Location = new Point(243, 413);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(94, 29);
            SignInButton.TabIndex = 5;
            SignInButton.Text = "Sign in";
            SignInButton.UseVisualStyleBackColor = false;
            SignInButton.Click += SignInButton_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(155, 363);
            button2.Name = "button2";
            button2.Size = new Size(267, 29);
            button2.TabIndex = 6;
            button2.Text = "Sign up";
            button2.UseVisualStyleBackColor = false;
            button2.Click += SignUpButton_Click;
            // 
            // FirstNameBox
            // 
            FirstNameBox.Location = new Point(155, 262);
            FirstNameBox.Name = "FirstNameBox";
            FirstNameBox.Size = new Size(267, 27);
            FirstNameBox.TabIndex = 7;
            // 
            // LastNameBox
            // 
            LastNameBox.Location = new Point(155, 310);
            LastNameBox.Name = "LastNameBox";
            LastNameBox.Size = new Size(267, 27);
            LastNameBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 216);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 9;
            label4.Text = "Confirm password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 265);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 10;
            label5.Text = "First name:";
            // 
            // ConfirmPasswordBox
            // 
            ConfirmPasswordBox.Location = new Point(155, 213);
            ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            ConfirmPasswordBox.Size = new Size(267, 27);
            ConfirmPasswordBox.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 313);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 12;
            label6.Text = "Last name:";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 498);
            Controls.Add(label6);
            Controls.Add(ConfirmPasswordBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(LastNameBox);
            Controls.Add(FirstNameBox);
            Controls.Add(button2);
            Controls.Add(SignInButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PasswordBox);
            Controls.Add(label1);
            Controls.Add(UsernameBox);
            Name = "SignUp";
            Text = "Sign up";
            Load += SignUp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameBox;
        private Label label1;
        private TextBox PasswordBox;
        private Label label2;
        private Label label3;
        private Button SignInButton;
        private Button button2;
        private TextBox FirstNameBox;
        private TextBox LastNameBox;
        private Label label4;
        private Label label5;
        private TextBox ConfirmPasswordBox;
        private Label label6;
    }
}