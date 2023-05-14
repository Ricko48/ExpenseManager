using Autofac;
using BL.Services.Interfaces;

namespace UI.User
{
    public partial class UserDetail : Form
    {
        private readonly IUserService _userService;

        public UserDetail(IContainer container)
        {
            _userService = container.Resolve<IUserService>();
            InitializeComponent();
        }

        private async void UserDetail_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
            var user = await _userService.GetSignedInUserAsync();
            UserNameLabel.Text = user.UserName;
            FirstNameLabel.Text = user.FirstName;
            LastNameLabel.Text = user.LastName;
        }
    }
}
