using Autofac;
using BL.Services.Interfaces;
using System.Globalization;
using BL.Models;
using DataExport;
using DataImport;
using UI.Transaction;
using UI.User;

namespace UI.MainBoard
{
    public partial class MainBoard : Form
    {
        private readonly IContainer _container;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionsDataExporter _transactionsDataExporter;
        private readonly ITransactionsDataImporter _transactionsDataImporter;
        private TransactionFilterModel _transactionsFilter;

        #region Forms

        private UserDetail? _userDetailForm;
        private EditUser? _editUserForm;
        private ChangePassword? _changePasswordForm;
        private AddTransaction? _addTransactionForm;
        private EditTransaction? _editTransactionForm;

        #endregion

        public MainBoard(IContainer container)
        {
            _container = container;
            _userService = _container.Resolve<IUserService>();
            _transactionService = _container.Resolve<ITransactionService>();
            _transactionsDataExporter = _container.Resolve<ITransactionsDataExporter>();
            _transactionsDataImporter = _container.Resolve<ITransactionsDataImporter>();
            InitializeComponent();
        }

        #region Setup
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

            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
            SetUpTransactionTable();
        }

        private void SetUpTransactionTable()
        {
            TransactionsTable.ReadOnly = true;
            TransactionsTable.RowHeadersVisible = false;
            TransactionsTable.Columns["Id"].Visible = false;
            TransactionsTable.Columns["UserId"].Visible = false;
            TransactionsTable.CellFormatting += DateCell_CellFormatting;

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

            TransactionsTable.CellContentClick += TransactionRowActionButton_CellContentClick;

            foreach (DataGridViewColumn column in TransactionsTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void DateCell_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == TransactionsTable.Columns["Date"].Index)
            {
                e.Value = DateTime.Parse(e.Value.ToString()).ToString("dd/MM/yyyy");
            }

            if (e.ColumnIndex == TransactionsTable.Columns["Amount"].Index)
            {
                e.Value = decimal.Parse(e.Value.ToString()).ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #region Data loading

        private async Task ReloadDataAsync()
        {
            await ReloadBalanceAsync();
            await ReloadTransactionsAsync();
        }

        private async Task ReloadBalanceAsync()
        {
            var balance = await _transactionService.GetBalanceForSignedInUserWithFilter(_transactionsFilter);
            BalanceLabel.Text = balance.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private async Task ReloadTransactionsAsync()
        {
            TransactionsTable.DataSource =
                await _transactionService.GetTransactionsByFilterForSignedInUserAsync(_transactionsFilter);
        }

        #endregion

        #region Transaction table - Actions

        #region Edit transaction

        private void EditTransactionButton_Click(DataGridViewCellEventArgs e)
        {
            try
            {
                var transactionId = int.Parse(TransactionsTable.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                _editTransactionForm = new EditTransaction(_container, transactionId);
                _editTransactionForm.FormClosed += EditTransactionFormForm_FormClosed;
                _editTransactionForm.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error");
            }
        }

        private async void EditTransactionFormForm_FormClosed(object sender, EventArgs e)
        {
            _editTransactionForm = null;
            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        #endregion

        #region Delete transaction

        private async Task DeleteTransactionButton_ClickedAsync(DataGridViewCellEventArgs e)
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

            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        #endregion

        #region Add transaction

        private void AddTransactionButton_Click(object sender, EventArgs e)
        {
            if (_addTransactionForm != null)
            {
                _addTransactionForm.BringToFront();
                return;
            }

            _addTransactionForm = new AddTransaction(_container);
            _addTransactionForm.FormClosed += AddTransactionFormButton_FormClosed;
            _addTransactionForm.Show(this);
        }

        private async void AddTransactionFormButton_FormClosed(object sender, EventArgs e)
        {
            _addTransactionForm = null;
            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        #endregion

        #region Transactions filter

        private async void ResetFilterButton_Click(object sender, EventArgs e)
        {
            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        private async void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            UpdateTransactionsFilterFromUi();
            await ReloadDataAsync();
        }

        private async Task UpdateTransactionsFilterFromDbAsync()
        {
            _transactionsFilter = await _transactionService.GetTransactionsFilterModelForSignedInUserAsync();
            FromAmountBox.Text = _transactionsFilter.AmountFrom.ToString();
            ToAmountBox.Text = _transactionsFilter.AmountTo.ToString();
            FromDateTimePicker.Value = _transactionsFilter.FromDateTime;
            ToDateTimePicker.Value = _transactionsFilter.ToDateTime;
        }

        private void UpdateTransactionsFilterFromUi()
        {
            decimal amountFrom;
            decimal amountTo;
            if (!decimal.TryParse(ToAmountBox.Text.Replace('.', ','), out amountTo) ||
                !decimal.TryParse(FromAmountBox.Text.Replace('.', ','), out amountFrom))
            {
                MessageBox.Show("Only valid numbers are allowed in 'amount' fields.", "Error");
                return;
            }

            if (amountFrom > amountTo)
            {
                MessageBox.Show("'Min amount' cannot be greater than 'Max amount'.", "Error");
                return;
            }

            if (ToDateTimePicker.Value < FromDateTimePicker.Value)
            {
                MessageBox.Show("'From' date cannot be greater than 'To' date.", "Error");
                return;
            }

            _transactionsFilter = new TransactionFilterModel
            {
                AmountTo = amountTo,
                AmountFrom = amountFrom,
                FromDateTime = FromDateTimePicker.Value,
                ToDateTime = ToDateTimePicker.Value
            };
        }

        #endregion

        #region Actions Setup

        private async void TransactionRowActionButton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == TransactionsTable.Columns["Delete"].Index)
            {
                await DeleteTransactionButton_ClickedAsync(e);
            }
            else if (e.ColumnIndex == TransactionsTable.Columns["Edit"].Index)
            {
                EditTransactionButton_Click(e);
            }
        }

        #endregion

        #endregion

        #region Account menu items

        #region Log out

        private void LogOutButton_Click(object sender, EventArgs e)
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

        #endregion

        #region Delete account

        private async void DeleteAccountButton_Click(object sender, EventArgs e)
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

        #endregion

        #region View account

        private void ViewAccountDetailsButton_Click(object sender, EventArgs e)
        {
            if (_userDetailForm != null)
            {
                _userDetailForm.BringToFront();
                return;
            }

            _userDetailForm = new UserDetail(_container);
            _userDetailForm.FormClosed += ViewAccountDetails_FormClosed;
            _userDetailForm.Show(this);
        }

        private void ViewAccountDetails_FormClosed(object sender, EventArgs e)
        {
            _userDetailForm = null;
        }

        #endregion

        #region Edit account

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            if (_editUserForm != null)
            {
                _editUserForm.BringToFront();
                return;
            }

            _editUserForm = new EditUser(_container);
            _editUserForm.FormClosed += EditAccount_FormClosed;
            _editUserForm.Show(this);
        }

        private void EditAccount_FormClosed(object sender, EventArgs e)
        {
            _editUserForm = null;
        }

        #endregion

        #region Change password

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (_changePasswordForm != null)
            {
                _changePasswordForm.BringToFront();
                return;
            }

            _changePasswordForm = new ChangePassword(_container);
            _changePasswordForm.FormClosed += ChangePassword_FormClosed;
            _changePasswordForm.Show(this);
        }

        private void ChangePassword_FormClosed(object sender, EventArgs e)
        {
            _changePasswordForm = null;
        }

        #endregion

        #endregion

        #region Data menu items

        private async void DataImportButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var filePath = openFileDialog.FileName;

            try
            {
                await _transactionsDataImporter.ImportAllAsync(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error");
                return;
            }
            
            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        private async void DataExportButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            folderBrowserDialog.Description = "Select a folder to save the file.";
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var path = folderBrowserDialog.SelectedPath;
            try
            {
                await _transactionsDataExporter.ExportByFilterAsync(path, _transactionsFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error");
                return;
            }
            
            await UpdateTransactionsFilterFromDbAsync();
            await ReloadDataAsync();
        }

        #endregion
    }
}
