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
            decimal decimalAmount;
            var result = decimal.TryParse(AddAmountBox.Text.Replace('.', ','), out decimalAmount);

            if (!result)
            {
                MessageBox.Show("Only valid numbers are allowed in 'Amount' field.", "Alert");
                return;
            }

            if (decimalAmount <= 0)
            {
                MessageBox.Show("Only numbers bigger than zero are allowed in 'Amount' field.", "Alert");
                return;
            }

            try
            {
                _transactionService.AddTransactionForSignedInUserAsync(new DAL.Entities.Transaction
                {
                    Amount = decimalAmount,
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

        private void AddTransaction_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            AddTransactionType.SelectedIndex = 0;
            AddDatePicker.Value = DateTime.Now;
            AddDescriptionBox.Text = string.Empty;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
        }
    }
}
