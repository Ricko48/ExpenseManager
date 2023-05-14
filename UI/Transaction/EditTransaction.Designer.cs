namespace UI.Transaction
{
    partial class EditTransaction
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
            EditAmountBox = new TextBox();
            EditDescriptionBox = new TextBox();
            EditTransactionType = new ComboBox();
            EditDatePicker = new DateTimePicker();
            EditTransactionButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(166, 38);
            label1.Name = "label1";
            label1.Size = new Size(187, 35);
            label1.TabIndex = 0;
            label1.Text = "Edit transaction";
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
            // EditAmountBox
            // 
            EditAmountBox.Location = new Point(140, 97);
            EditAmountBox.Name = "EditAmountBox";
            EditAmountBox.Size = new Size(250, 27);
            EditAmountBox.TabIndex = 5;
            EditAmountBox.Text = "0";
            EditAmountBox.TextAlign = HorizontalAlignment.Right;
            // 
            // EditDescriptionBox
            // 
            EditDescriptionBox.Location = new Point(140, 248);
            EditDescriptionBox.Multiline = true;
            EditDescriptionBox.Name = "EditDescriptionBox";
            EditDescriptionBox.Size = new Size(250, 114);
            EditDescriptionBox.TabIndex = 6;
            // 
            // EditTransactionType
            // 
            EditTransactionType.FormattingEnabled = true;
            EditTransactionType.Items.AddRange(new object[] { "Income", "Expense" });
            EditTransactionType.Location = new Point(140, 149);
            EditTransactionType.Name = "EditTransactionType";
            EditTransactionType.Size = new Size(250, 28);
            EditTransactionType.TabIndex = 7;
            // 
            // EditDatePicker
            // 
            EditDatePicker.Location = new Point(140, 201);
            EditDatePicker.Name = "EditDatePicker";
            EditDatePicker.Size = new Size(250, 27);
            EditDatePicker.TabIndex = 8;
            // 
            // EditTransactionButton
            // 
            EditTransactionButton.Location = new Point(140, 391);
            EditTransactionButton.Name = "EditTransactionButton";
            EditTransactionButton.Size = new Size(250, 39);
            EditTransactionButton.TabIndex = 9;
            EditTransactionButton.Text = "Save transaction";
            EditTransactionButton.UseVisualStyleBackColor = true;
            EditTransactionButton.Click += EditTransactionButton_Click;
            // 
            // EditTransaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 473);
            Controls.Add(EditTransactionButton);
            Controls.Add(EditDatePicker);
            Controls.Add(EditTransactionType);
            Controls.Add(EditDescriptionBox);
            Controls.Add(EditAmountBox);
            Controls.Add(DescriptionBox);
            Controls.Add(TransactionTypeBox);
            Controls.Add(DateTimeBox);
            Controls.Add(AmountBox);
            Controls.Add(label1);
            Name = "EditTransaction";
            Text = "Edit transaction";
            Load += EditTransaction_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label AmountBox;
        private Label DateTimeBox;
        private Label TransactionTypeBox;
        private Label DescriptionBox;
        private TextBox EditAmountBox;
        private TextBox EditDescriptionBox;
        private ComboBox EditTransactionType;
        private DateTimePicker EditDatePicker;
        private Button EditTransactionButton;
    }
}