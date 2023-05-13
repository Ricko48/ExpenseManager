namespace UI.MainBoard
{
    partial class MainBoard
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
            accountToolStripMenuItem = new ToolStripMenuItem();
            viewDetailsToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            deleteAccountToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            TransactionsTable = new DataGridView();
            label1 = new Label();
            BalanceLabel = new Label();
            AddTransactionButton = new Button();
            FromAmountBox = new TextBox();
            ToAmountBox = new TextBox();
            ToDateTimePicker = new DateTimePicker();
            FromDateTimePicker = new DateTimePicker();
            ApplyFilterButton = new Button();
            ResetFilterButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ExpenseCheckBox = new CheckBox();
            IncomeCheckBox = new CheckBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionsTable).BeginInit();
            SuspendLayout();
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewDetailsToolStripMenuItem, editAccountToolStripMenuItem, changePasswordToolStripMenuItem, logOutToolStripMenuItem, deleteAccountToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(77, 24);
            accountToolStripMenuItem.Text = "Account";
            // 
            // viewDetailsToolStripMenuItem
            // 
            viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            viewDetailsToolStripMenuItem.Size = new Size(228, 26);
            viewDetailsToolStripMenuItem.Text = "View account details";
            viewDetailsToolStripMenuItem.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(228, 26);
            editAccountToolStripMenuItem.Text = "Edit account details";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(228, 26);
            changePasswordToolStripMenuItem.Text = "Change password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(228, 26);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // deleteAccountToolStripMenuItem
            // 
            deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            deleteAccountToolStripMenuItem.Size = new Size(228, 26);
            deleteAccountToolStripMenuItem.Text = "Delete account";
            deleteAccountToolStripMenuItem.Click += deleteAccountToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(830, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // TransactionsTable
            // 
            TransactionsTable.AllowUserToOrderColumns = true;
            TransactionsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransactionsTable.Location = new Point(0, 287);
            TransactionsTable.Name = "TransactionsTable";
            TransactionsTable.RowHeadersWidth = 51;
            TransactionsTable.RowTemplate.Height = 29;
            TransactionsTable.Size = new Size(830, 507);
            TransactionsTable.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(67, 67);
            label1.Name = "label1";
            label1.Size = new Size(105, 35);
            label1.TabIndex = 3;
            label1.Text = "Balance:";
            // 
            // BalanceLabel
            // 
            BalanceLabel.AutoSize = true;
            BalanceLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            BalanceLabel.Location = new Point(178, 67);
            BalanceLabel.Name = "BalanceLabel";
            BalanceLabel.Size = new Size(81, 35);
            BalanceLabel.TabIndex = 4;
            BalanceLabel.Text = "label2";
            // 
            // AddTransactionButton
            // 
            AddTransactionButton.Location = new Point(12, 235);
            AddTransactionButton.Name = "AddTransactionButton";
            AddTransactionButton.Size = new Size(804, 34);
            AddTransactionButton.TabIndex = 5;
            AddTransactionButton.Text = "Add transaction";
            AddTransactionButton.UseVisualStyleBackColor = true;
            AddTransactionButton.Click += AddTransactionButton_Click;
            // 
            // FromAmountBox
            // 
            FromAmountBox.Location = new Point(107, 143);
            FromAmountBox.Name = "FromAmountBox";
            FromAmountBox.Size = new Size(125, 27);
            FromAmountBox.TabIndex = 6;
            // 
            // ToAmountBox
            // 
            ToAmountBox.Location = new Point(107, 185);
            ToAmountBox.Name = "ToAmountBox";
            ToAmountBox.Size = new Size(125, 27);
            ToAmountBox.TabIndex = 7;
            // 
            // ToDateTimePicker
            // 
            ToDateTimePicker.Location = new Point(337, 183);
            ToDateTimePicker.Name = "ToDateTimePicker";
            ToDateTimePicker.Size = new Size(250, 27);
            ToDateTimePicker.TabIndex = 8;
            // 
            // FromDateTimePicker
            // 
            FromDateTimePicker.Location = new Point(337, 143);
            FromDateTimePicker.Name = "FromDateTimePicker";
            FromDateTimePicker.Size = new Size(250, 27);
            FromDateTimePicker.TabIndex = 9;
            // 
            // ApplyFilterButton
            // 
            ApplyFilterButton.Location = new Point(722, 144);
            ApplyFilterButton.Name = "ApplyFilterButton";
            ApplyFilterButton.Size = new Size(94, 29);
            ApplyFilterButton.TabIndex = 10;
            ApplyFilterButton.Text = "Apply";
            ApplyFilterButton.UseVisualStyleBackColor = true;
            ApplyFilterButton.Click += ApplyFilterButton_Click;
            // 
            // ResetFilterButton
            // 
            ResetFilterButton.Location = new Point(722, 183);
            ResetFilterButton.Name = "ResetFilterButton";
            ResetFilterButton.Size = new Size(94, 29);
            ResetFilterButton.TabIndex = 12;
            ResetFilterButton.Text = "Reset";
            ResetFilterButton.UseVisualStyleBackColor = true;
            ResetFilterButton.Click += ResetFilterButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 146);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 13;
            label2.Text = "Amout from:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 188);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 14;
            label3.Text = "Amount to:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 146);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 15;
            label4.Text = "Date from:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(269, 188);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 16;
            label5.Text = "Date to:";
            // 
            // ExpenseCheckBox
            // 
            ExpenseCheckBox.AutoSize = true;
            ExpenseCheckBox.Location = new Point(619, 146);
            ExpenseCheckBox.Name = "ExpenseCheckBox";
            ExpenseCheckBox.Size = new Size(85, 24);
            ExpenseCheckBox.TabIndex = 17;
            ExpenseCheckBox.Text = "Expense";
            ExpenseCheckBox.UseVisualStyleBackColor = true;
            // 
            // IncomeCheckBox
            // 
            IncomeCheckBox.AutoSize = true;
            IncomeCheckBox.Location = new Point(619, 185);
            IncomeCheckBox.Name = "IncomeCheckBox";
            IncomeCheckBox.Size = new Size(80, 24);
            IncomeCheckBox.TabIndex = 18;
            IncomeCheckBox.Text = "Income";
            IncomeCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 794);
            Controls.Add(IncomeCheckBox);
            Controls.Add(ExpenseCheckBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ResetFilterButton);
            Controls.Add(ApplyFilterButton);
            Controls.Add(FromDateTimePicker);
            Controls.Add(ToDateTimePicker);
            Controls.Add(ToAmountBox);
            Controls.Add(FromAmountBox);
            Controls.Add(AddTransactionButton);
            Controls.Add(BalanceLabel);
            Controls.Add(label1);
            Controls.Add(TransactionsTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainBoard";
            Text = "Expense Manager";
            Load += MainBoard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem viewDetailsToolStripMenuItem;
        private ToolStripMenuItem editAccountToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem deleteAccountToolStripMenuItem;
        private MenuStrip menuStrip1;
        private DataGridView TransactionsTable;
        private Label label1;
        private Label BalanceLabel;
        private Button AddTransactionButton;
        private TextBox FromAmountBox;
        private TextBox ToAmountBox;
        private DateTimePicker ToDateTimePicker;
        private DateTimePicker FromDateTimePicker;
        private Button ApplyFilterButton;
        private Button ResetFilterButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox ExpenseCheckBox;
        private CheckBox IncomeCheckBox;
    }
}