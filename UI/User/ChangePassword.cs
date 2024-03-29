﻿using Autofac;
using BL.Exceptions;
using BL.Services.Interfaces;

namespace UI.User
{
    public partial class ChangePassword : Form
    {
        private readonly IUserService _userService;

        public ChangePassword(IContainer container)
        {
            _userService = container.Resolve<IUserService>();
            InitializeComponent();
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewPasswordBox.Text) || string.IsNullOrEmpty(ConfirmNewPasswordBox.Text) ||
                string.IsNullOrEmpty(CurrentPasswordBox.Text))
            {
                MessageBox.Show("All the fields are required.", "Error");
                return;
            }

            if (NewPasswordBox.Text != ConfirmNewPasswordBox.Text)
            {
                MessageBox.Show("Field 'New password' dos not match field 'Confirm new password'.", "Error");
                return;
            }

            try
            {
                await _userService.UpdatePasswordForSignedInUser(NewPasswordBox.Text, CurrentPasswordBox.Text);
            }
            catch (Exception ex) when (ex is InvalidPasswordException or PasswordNotComplexEnoughException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                return;
            }

            Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CurrentPasswordBox.UseSystemPasswordChar = true;
            NewPasswordBox.UseSystemPasswordChar = true;
            ConfirmNewPasswordBox.UseSystemPasswordChar = true;
            CenterToScreen();
        }
    }
}
