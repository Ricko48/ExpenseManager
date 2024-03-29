﻿namespace UI.User
{
    partial class SignIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            label1.Size = new Size(108, 41);
            label1.TabIndex = 1;
            label1.Text = "Sign in";
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
            SignInButton.Location = new Point(155, 216);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(267, 29);
            SignInButton.TabIndex = 5;
            SignInButton.Text = "Sign in";
            SignInButton.UseVisualStyleBackColor = false;
            SignInButton.Click += SignIn_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(242, 271);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Sign up";
            button2.UseVisualStyleBackColor = false;
            button2.Click += SignUp_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 363);
            Controls.Add(button2);
            Controls.Add(SignInButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PasswordBox);
            Controls.Add(label1);
            Controls.Add(UsernameBox);
            Name = "SignIn";
            Text = "Sign in";
            Load += SignIn_Load;
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
    }
}