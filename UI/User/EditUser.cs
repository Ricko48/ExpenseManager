using Autofac;
using BL.Exceptions;
using BL.Services.Interfaces;

namespace UI.User
{
    public partial class EditUser : Form
    {
        private readonly IUserService _userService;

        public EditUser(IContainer container)
        {
            _userService = container.Resolve<IUserService>();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                await _userService.UpdateSignedInUserAsync(new DAL.Entities.User
                {
                    UserName = UsernameBox.Text,
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text
                });
            }
            catch (UsernameAlreadyUsedException ex)
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

        private async void EditUser_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            var user = await _userService.GetSignedInUserAsync();
            UsernameBox.Text = user.UserName;
            FirstNameBox.Text = user.FirstName;
            LastNameBox.Text = user.LastName;
            CenterToScreen();
        }
    }
}
