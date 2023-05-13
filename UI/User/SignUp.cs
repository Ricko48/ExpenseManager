using Autofac;
using BL.Exceptions;
using BL.Services.Interfaces;

namespace UI.User
{
    public partial class SignUp : Form
    {
        private readonly IUserService _userService;
        private readonly IContainer _container;

        public SignUp(IContainer container)
        {
            _userService = container.Resolve<IUserService>();
            _container = container;
            InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordBox.Text) || string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (PasswordBox.Text != ConfirmPasswordBox.Text)
            {
                MessageBox.Show("Text fields 'Password' and 'Confirm password' do not match.");
                return;
            }

            try
            {
                await _userService.CreateUserAsync(new DAL.Entities.User()
                {
                    UserName = UsernameBox.Text,
                    Password = PasswordBox.Text,
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                });
            }
            catch (Exception ex) when (ex is UserNameEndsOrStartsWithWhitespaceException
                                           or UsernameAlreadyUsedException
                                           or PasswordNotComplexEnoughException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }

            Close();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            PasswordBox.UseSystemPasswordChar = true;
            ConfirmPasswordBox.UseSystemPasswordChar = true;
            CenterToScreen();
        }
    }
}
