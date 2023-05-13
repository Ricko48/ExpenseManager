using System.Globalization;
using Autofac;
using BL.Services.Interfaces;
using DAL.Enums;
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
        private AddTransaction? _addTransaction;

        public MainBoard(IContainer container)
        {
            _container = container;
            _userService = _container.Resolve<IUserService>();
            _transactionService = _container.Resolve<ITransactionService>();
            InitializeComponent();
        }

        private async void MainBoard_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            //if (!_userService.IsUserSignedIn())
            //{
            //    var signInForm = new SignIn(_container);
            //    signInForm.ShowDialog(this);
            //}

            FormBorderStyle = FormBorderStyle.FixedSingle;
            await Refresh();
            SetUpTransactionTable();
        }

        private void SetUpTransactionTable()
        {
            TransactionsTable.DataSource = _transactions;
            TransactionsTable.Columns["Id"].Visible = false;
            TransactionsTable.Columns["UserId"].Visible = false;
            TransactionsTable.Columns["TransactionType"].HeaderText = "Type";
        }

        private void ResetFilters()
        {
            ToAmountBox.Text = 0.ToString();
            FromAmountBox.Text = 0.ToString();
            FromDateTimePicker = new DateTimePicker();
            ToDateTimePicker = new DateTimePicker();
            ExpenseCheckBox.Checked = false;
            IncomeCheckBox.Checked = false;
        }

        private async void ReloadTransactions()
        {
            BalanceLabel.Text = (await _transactionService.GetBalanceForSignedInUserAsync()).ToString(CultureInfo.CurrentCulture);
            //_transactions = await _transactionService.GetAllTransactionsForSignedInUserAsync();
        }

        private async Task Refresh()
        {
            ReloadTransactions();
            ResetFilters();

            _transactions = new List<DAL.Entities.Transaction>
            {
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                },
                new()
                {
                    Amount = (decimal)500.50,
                    Date = DateTime.Now,
                    Description = "Test transaction1",
                    TransactionType = TransactionType.Income,
                    UserId = 1,
                    Id = 1
                },
                new()
                {
                    Amount = (decimal)5200.33,
                    Date = DateTime.Now,
                    Description = "Test transaction2",
                    TransactionType = TransactionType.Expense,
                    UserId = 1,
                    Id = 2
                }
            };
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private async void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_userDetailForm != null)
            {
                _userDetailForm.BringToFront();
                return;
            }

            _userDetailForm = new UserDetail(_container);
            _userDetailForm.FormClosed += viewDetailsToolStripMenuItem_FormClosed;
            _userDetailForm.Show(this);
        }

        private void viewDetailsToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _userDetailForm = null;
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_editUserForm != null)
            {
                _editUserForm.BringToFront();
                return;
            }

            _editUserForm = new EditUser(_container);
            _editUserForm.FormClosed += editAccountToolStripMenuItem_FormClosed;
            _editUserForm.Show(this);
        }

        private void editAccountToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _editUserForm = null;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_changePasswordForm != null)
            {
                _changePasswordForm.BringToFront();
                return;
            }

            _changePasswordForm = new ChangePassword(_container);
            _changePasswordForm.FormClosed += changePasswordToolStripMenuItem_FormClosed;
            _changePasswordForm.Show(this);
        }

        private void changePasswordToolStripMenuItem_FormClosed(object sender, EventArgs e)
        {
            _changePasswordForm = null;
        }

        private async void ResetFilterButton_Click(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {

        }

        private void AddTransactionButton_Click(object sender, EventArgs e)
        {
            if (_addTransaction != null)
            {
                _addTransaction.BringToFront();
                return;
            }

            _addTransaction = new AddTransaction(_container);
            _addTransaction.FormClosed += AddTransactionButton_FormClosed;
            _addTransaction.Show(this);
        }

        private void AddTransactionButton_FormClosed(object sender, EventArgs e)
        {
            _addTransaction = null;
        }
    }
}
