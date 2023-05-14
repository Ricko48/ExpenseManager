namespace UI.Transaction
{
    partial class AddTransaction
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
            label1 = new Label();
            AmountBox = new Label();
            DateTimeBox = new Label();
            TransactionTypeBox = new Label();
            DescriptionBox = new Label();
            AddAmountBox = new TextBox();
            AddDescriptionBox = new TextBox();
            AddTransactionType = new ComboBox();
            AddDatePicker = new DateTimePicker();
            AddTransactionButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(166, 38);
            label1.Name = "label1";
            label1.Size = new Size(191, 35);
            label1.TabIndex = 0;
            label1.Text = "Add transaction";
            // 
            // AmountBox
            // 
            AmountBox.AutoSize = true;
            AmountBox.Location = new Point(67, 100);
            AmountBox.Name = "AmountBox";
            AmountBox.Size = new Size(65, 20);
            AmountBox.TabIndex = 1;
            AmountBox.Text = "Amount:";
            // 
            // DateTimeBox
            // 
            DateTimeBox.AutoSize = true;
            DateTimeBox.Location = new Point(88, 206);
            DateTimeBox.Name = "DateTimeBox";
            DateTimeBox.Size = new Size(44, 20);
            DateTimeBox.TabIndex = 2;
            DateTimeBox.Text = "Date:";
            // 
            // TransactionTypeBox
            // 
            TransactionTypeBox.AutoSize = true;
            TransactionTypeBox.Location = new Point(12, 152);
            TransactionTypeBox.Name = "TransactionTypeBox";
            TransactionTypeBox.Size = new Size(120, 20);
            TransactionTypeBox.TabIndex = 3;
            TransactionTypeBox.Text = "Transaction type:";
            // 
            // DescriptionBox
            // 
            DescriptionBox.AutoSize = true;
            DescriptionBox.Location = new Point(44, 272);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(88, 20);
            DescriptionBox.TabIndex = 4;
            DescriptionBox.Text = "Description:";
            // 
            // AddAmountBox
            // 
            AddAmountBox.Location = new Point(140, 97);
            AddAmountBox.Name = "AddAmountBox";
            AddAmountBox.Size = new Size(250, 27);
            AddAmountBox.TabIndex = 5;
            AddAmountBox.Text = "0";
            AddAmountBox.TextAlign = HorizontalAlignment.Right;
            // 
            // AddDescriptionBox
            // 
            AddDescriptionBox.Location = new Point(140, 248);
            AddDescriptionBox.Multiline = true;
            AddDescriptionBox.Name = "AddDescriptionBox";
            AddDescriptionBox.Size = new Size(250, 114);
            AddDescriptionBox.TabIndex = 6;
            // 
            // AddTransactionType
            // 
            AddTransactionType.FormattingEnabled = true;
            AddTransactionType.Items.AddRange(new object[] { "Income", "Expense" });
            AddTransactionType.Location = new Point(140, 149);
            AddTransactionType.Name = "AddTransactionType";
            AddTransactionType.Size = new Size(250, 28);
            AddTransactionType.TabIndex = 7;
            // 
            // AddDatePicker
            // 
            AddDatePicker.Location = new Point(140, 201);
            AddDatePicker.Name = "AddDatePicker";
            AddDatePicker.Size = new Size(250, 27);
            AddDatePicker.TabIndex = 8;
            // 
            // AddTransactionButton
            // 
            AddTransactionButton.Location = new Point(140, 391);
            AddTransactionButton.Name = "AddTransactionButton";
            AddTransactionButton.Size = new Size(250, 39);
            AddTransactionButton.TabIndex = 9;
            AddTransactionButton.Text = "Add transaction";
            AddTransactionButton.UseVisualStyleBackColor = true;
            AddTransactionButton.Click += AddTransactionButton_Click;
            // 
            // AddTransaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 473);
            Controls.Add(AddTransactionButton);
            Controls.Add(AddDatePicker);
            Controls.Add(AddTransactionType);
            Controls.Add(AddDescriptionBox);
            Controls.Add(AddAmountBox);
            Controls.Add(DescriptionBox);
            Controls.Add(TransactionTypeBox);
            Controls.Add(DateTimeBox);
            Controls.Add(AmountBox);
            Controls.Add(label1);
            Name = "AddTransaction";
            Text = "Add transaction";
            Load += AddTransaction_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label AmountBox;
        private Label DateTimeBox;
        private Label TransactionTypeBox;
        private Label DescriptionBox;
        private TextBox AddAmountBox;
        private TextBox AddDescriptionBox;
        private ComboBox AddTransactionType;
        private DateTimePicker AddDatePicker;
        private Button AddTransactionButton;
    }
}