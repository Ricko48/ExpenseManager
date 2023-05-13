using BL.Exceptions;
using BL.Services.Interfaces;
using Autofac;

namespace UI.User
{
    public partial class SignIn : Form
    {
        private readonly IUserService _userService;
        private readonly IContainer _container;

        public SignIn(IContainer container)
        {
            _userService = container.Resolve<IUserService>();
            _container = container;
            InitializeComponent();
        }

        private async void SignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Text fields 'Username' and 'Password' cannot be empty.");
                return;
            }

            try
            {
                await _userService.SignInAsync(UsernameBox.Text, PasswordBox.Text);
            }
            catch (Exception ex) when (ex is UserWithGivenUserNameDoesNotExist or InvalidPasswordException)
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

        private void SignUp_Click(object sender, EventArgs e)
        {
            Hide();
            var signUpForm = new SignUp(_container);
            signUpForm.ShowDialog();
            ClearFields();
            Show();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            PasswordBox.UseSystemPasswordChar = true;
            CenterToScreen();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_userService.IsUserSignedIn())
            {
                var result = MessageBox.Show("Are you sure you want to close the application?", "Confirm Close", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                Application.Exit();
            }
            base.OnFormClosing(e);
        }

        private void ClearFields()
        {
            UsernameBox.Text = string.Empty;
            PasswordBox.Text = string.Empty;
        }
    }
}