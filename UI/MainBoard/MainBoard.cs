using Autofac;
using BL.Services.Interfaces;
using DAL.Enums;
using System.Globalization;
using UI.Transaction;
using UI.User;

namespace UI.MainBoard
{
    public partial class MainBoard : Form
    {
        private readonly IContainer _container;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private IEnumerable<DAL.Entities.Transaction> _transactions;

        private UserDetail? _userDetailForm;
        private EditUser? _editUserForm;
        private ChangePassword? _changePasswordForm;
        private AddTransaction? _addTransactionForm;
        private EditTransaction? _editTransactionForm;

        public MainBoard(IContainer container)                               // signin close ToDo
        {
            _container = container;
            _userService = _container.Resolve<IUserService>();
            _transactionService = _container.Resolve<ITransactionService>();
            InitializeComponent();
        }

        private async void MainBoard_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            if (!_userService.IsUserSignedIn())
            {
                Hide();
                var signInForm = new SignIn(_container);
                signInForm.ShowDialog(this);
                Show();
            }

            await Refresh();
            SetUpTransactionTable();
        }

        private void SetUpTransactionTable()
        {
            TransactionsTable.ReadOnly = true;
            TransactionsTable.RowHeadersVisible = false;
            TransactionsTable.Columns["Id"].Visible = false;
            TransactionsTable.Columns["UserId"].Visible = false;
            TransactionsTable.Columns["TransactionType"].HeaderText = "Type";
            TransactionsTable.CellFormatting += AmountCell_CellFormatting;

            var editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            TransactionsTable.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            TransactionsTable.Columns.Add(deleteButtonColumn);

            TransactionsTable.CellContentClick += ActionButton_CellContentClick;

            foreach (DataGridViewColumn column in TransactionsTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void AmountCell_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != TransactionsTable.Columns["Amount"].Index)
            {
                return;
            }

            var row = TransactionsTable.Rows[e.RowIndex];
            var transactionType = row.Cells[TransactionsTable.Columns["TransactionType"].Index];
            if (transactionType.Value.ToString() == TransactionType.Expense.ToString())
            {
                e.Value = "-" + e.Value;
            }
        }

        private async void ActionButton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == TransactionsTable.Columns["Delete"].Index)
            {
                await DeleteTransactionButtonClickedAsync(e);
            }
            else if (e.ColumnIndex == TransactionsTable.Columns["Edit"].Index)
            {
                await EditTransactionButtonClickedAsync(e);
            }
        }

        private async Task EditTransactionButtonClickedAsync(DataGridViewCellEventArgs e)
        {
            try
            {
                var transactionId = int.Parse(TransactionsTable.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                _editTransactionForm = new EditTransaction(_container, transactionId);
                _editTransactionForm.FormClosed += EditTransactionFormFormFormClosed;
                _editTransactionForm.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error");
            }

            await Refresh();
        }

        private async void EditTransactionFormFormFormClosed(object sender, EventArgs e)
        {
            _editTransactionForm = null;
            await Refresh();
        }

        private async Task DeleteTransactionButtonClickedAsync(DataGridViewCellEventArgs e)
        {
            var transactionId = int.Parse(TransactionsTable.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            var decision = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm delete transaction", MessageBoxButtons.YesNo);
            if (decision == DialogResult.No)
            {
                return;
            }

            try
            {
                await _transactionService.DeleteTransactionAsync(transactionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error");
            }

            await Refresh();
        }

        private void ResetFilters()
        {
            var orderedByDate = _transactions.OrderBy(x => x.Date);
            var orderedByAmount = _transactions.OrderBy(x => x.TransactionType == TransactionType.Income ? x.Amount : -x.Amount);
            FromAmountBox.Text = '-' + orderedByAmount.First().Amount.ToString();
            ToAmountBox.Text = orderedByAmount.Last().Amount.ToString();
            FromDateTimePicker.Value = orderedByDate.First().Date;
            ToDateTimePicker.Value = orderedByDate.Last().Date;
            ExpenseCheckBox.Checked = true;
            IncomeCheckBox.Checked = true;
        }

        private async Task ReloadTransactions()
        {
            BalanceLabel.Text = (await _transactionService.GetBalanceForSignedInUserAsync()).ToString("0.00", CultureInfo.InvariantCulture);
            _transactions = await _transactionService.GetAllTransactionsForSignedInUserAsync();
            TransactionsTable.DataSource = _transactions;
        }

        private async Task Refresh()
        {
            await ReloadTransactions();
            ResetFilters();
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var decision = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);

            if (decision == DialogResult.No)
            {
                return;
            }

            _userService.SignOut();
            var signInForm = new SignIn(_container);
            Hide();
            signInForm.ShowDialog(this);
            Show();
        }

        private async void DeleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var decision = MessageBox.Show("Are you sure you want to delete your account?", "Confirm delete account", MessageBoxButtons.YesNo);

            if (decision == DialogResult.No)
            {
                return;
            }

            await _userService.DeleteSignedInUserAsync();
            var signInForm = new SignIn(_container);
            Hide();
            signInForm.ShowDialog(this);
            Show();
        }

        private void ViewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_userDetailForm != null)
            {
                _userDetailForm.BringToFront();
                return;
            }

            _userDetailForm = new UserDetail(_container);
            _userDetailForm.FormClosed += ViewDetailsToolStripMenuItem_FormClosed;
            _userDetailForm.Show(this);
        }

        private void ViewDetailsToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _userDetailForm = null;
        }

        private void EditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_editUserForm != null)
            {
                _editUserForm.BringToFront();
                return;
            }

            _editUserForm = new EditUser(_container);
            _editUserForm.FormClosed += EditAccountToolStripMenuItem_FormClosed;
            _editUserForm.Show(this);
        }

        private void EditAccountToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _editUserForm = null;
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_changePasswordForm != null)
            {
                _changePasswordForm.BringToFront();
                return;
            }

            _changePasswordForm = new ChangePassword(_container);
            _changePasswordForm.FormClosed += ChangePasswordToolStripMenuItem_FormClosed;
            _changePasswordForm.Show(this);
        }

        private void ChangePasswordToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _changePasswordForm = null;
        }

        private async void ResetFilterButton_Click(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            // ToDo
        }

        private void AddTransactionButton_Click(object sender, EventArgs e)
        {
            if (_addTransactionForm != null)
            {
                _addTransactionForm.BringToFront();
                return;
            }

            _addTransactionForm = new AddTransaction(_container);
            _addTransactionForm.FormClosed += AddTransactionFormButtonFormClosed;
            _addTransactionForm.Show(this);
        }

        private async void AddTransactionFormButtonFormClosed(object sender, EventArgs e)
        {
            _addTransactionForm = null;
            await Refresh();
        }
    }
}
