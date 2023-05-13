using BL.Services.Interfaces;
using Autofac;
using DAL.Enums;

namespace UI.Transaction
{
    public partial class AddTransaction : Form
    {
        private readonly ITransactionService _transactionService;

        public AddTransaction(IContainer container)
        {
            _transactionService = container.Resolve<ITransactionService>();
            InitializeComponent();
        }

        private void AddTransactionButton_Click(object sender, EventArgs e)
        {
            if (AddAmountBox.Text.Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("Only digits are allowed in 'Amount' field.", "Alert");
                return;
            }

            if (string.IsNullOrWhiteSpace(AddAmountBox.Text))
            {
                MessageBox.Show("Amount field is required.", "Alert");
                return;
            }

            try
            {
                _transactionService.AddTransactionForSignedInUserAsync(new DAL.Entities.Transaction
                {
                    Amount = decimal.Parse(AddAmountBox.Text),
                    TransactionType = (TransactionType)AddTransactionType.SelectedIndex,
                    Date = AddDatePicker.Value,
                    Description = AddDescriptionBox.Text
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                return;
            }

            Close();
        }

        private void AddAmountBox_KeyPress(object sender, EventArgs e)
        {
            if (AddAmountBox.Text.Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("Only numbers are allowed.", "Alert");
            }
        }

        private void AddTransaction_Load(object sender, EventArgs e)
        {
            AddTransactionType.SelectedText = "Expense";
            AddDatePicker.Value = DateTime.Now;
            AddDescriptionBox.Text = string.Empty;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
        }
    }
}
