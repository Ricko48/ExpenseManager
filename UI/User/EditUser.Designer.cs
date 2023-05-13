namespace UI.User
{
    partial class EditUser
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
            label2 = new Label();
            FirstNameBox = new TextBox();
            LastNameBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
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
            label1.Location = new Point(177, 45);
            label1.Name = "label1";
            label1.Size = new Size(214, 41);
            label1.TabIndex = 1;
            label1.Text = "Change details";
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
            // FirstNameBox
            // 
            FirstNameBox.Location = new Point(155, 156);
            FirstNameBox.Name = "FirstNameBox";
            FirstNameBox.Size = new Size(267, 27);
            FirstNameBox.TabIndex = 7;
            // 
            // LastNameBox
            // 
            LastNameBox.Location = new Point(155, 204);
            LastNameBox.Name = "LastNameBox";
            LastNameBox.Size = new Size(267, 27);
            LastNameBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 159);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 10;
            label5.Text = "First name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 207);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 12;
            label6.Text = "Last name:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(155, 258);
            button1.Name = "button1";
            button1.Size = new Size(267, 29);
            button1.TabIndex = 13;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 357);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(LastNameBox);
            Controls.Add(FirstNameBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(UsernameBox);
            Name = "EditUser";
            Text = "Change details";
            Load += EditUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameBox;
        private Label label1;
        private Label label2;
        private TextBox FirstNameBox;
        private TextBox LastNameBox;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}