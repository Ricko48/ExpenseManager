using System.Globalization;
using Autofac;
using BL.Services.Interfaces;

namespace UI.Transaction
{
    public partial class EditTransaction : Form
    {
        private readonly ITransactionService _transactionService;
        private readonly int _transactionId;

        public EditTransaction(IContainer container, int transactionId)
        {
            _transactionService = container.Resolve<ITransactionService>();
            _transactionId = transactionId;
            InitializeComponent();
        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
            LoadEntryFields();
        }

        private async void LoadEntryFields()
        {
            DAL.Entities.Transaction transaction;
            try
            {
                transaction = await _transactionService.GetTransactionByIdAsync(_transactionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error ocured while loading original transaction data.\nMessage: {ex.Message}", "Error");
                return;
            }

            EditAmountBox.Text = transaction.Amount.ToString(CultureInfo.CurrentCulture);
            EditDatePicker.Value = transaction.Date;
            EditDescriptionBox.Text = transaction.Description;
        }

        private void EditTransactionButton_Click(object sender, EventArgs e)
        {
            decimal decimalAmount;
            var result = decimal.TryParse(EditAmountBox.Text.Replace('.', ','), out decimalAmount);
            if (!result)
            {
                MessageBox.Show("Only valid numbers are allowed in 'Amount' field.", "Alert");
                return;
            }
            if (decimalAmount == 0)
            {
                MessageBox.Show("Value zero is not allowed in 'Amount' field.", "Alert");
                return;
            }

            try
            {
                _transactionService.UpdateTransactionAsync(new DAL.Entities.Transaction
                {
                    Id = _transactionId,
                    Amount = decimalAmount,
                    Date = EditDatePicker.Value,
                    Description = EditDescriptionBox.Text
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                return;
            }

            Close();
        }
    }
}
