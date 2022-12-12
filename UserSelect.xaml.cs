using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static cpsc481_group5_browser.CreateNewUser;

namespace cpsc481_group5_browser
{
    /// <summary>
    /// Interaction logic for UserSelect.xaml
    /// </summary>
    public partial class UserSelect : UserControl
    {
        public event EventHandler Handler_ToSettings;
        public event EventHandler Handler_ToHome;
        public event EventHandler<CreateNewUserArgs> Handler_NewUserProfile;
        UserProfilePassword ProfilePassword;
        PasswordPrompt PasswordPopup;
        List<UserProfile> StoredUsers = new List<UserProfile>();
        UserProfile CreateNewUserProfile;
        CreateNewUser CreateNewUserPrompt;

        public UserSelect(List<User> users)
        {
            InitializeComponent();

            int Index = 0;
            foreach (User User in users)
            {
                ColumnDefinition ColDef = new ColumnDefinition();
                UsersGrid.ColumnDefinitions.Add(ColDef);

                UserProfile TempUser = new UserProfile(User.Name);
                TempUser.SetValue(Grid.ColumnProperty, Index);
                TempUser.ProfileButton.Click += new RoutedEventHandler(Profile_Click);
                UsersGrid.Children.Add(TempUser);
                StoredUsers.Add(TempUser);

                Index += 1;
            }

            ColumnDefinition CreateNewCol = new ColumnDefinition();
            UsersGrid.ColumnDefinitions.Add(CreateNewCol);

            CreateNewUserProfile = new UserProfile("New User");
            CreateNewUserProfile.SetValue(Grid.ColumnProperty, Index);
            CreateNewUserProfile.ProfileButton.Click += new RoutedEventHandler(CreateNewUser_Click);
            UsersGrid.Children.Add(CreateNewUserProfile);

            // Create New User
            CreateNewUserPrompt = CreateNewUserContent;
            CreateNewUserPrompt.Handler_CreateNewUserCreateClicked += new EventHandler<CreateNewUser.CreateNewUserArgs>(CreateNewUserContinue_Click);
            CreateNewUserPrompt.Handler_CancelClicked += new EventHandler(CreateNewUserCancel_Click);

            // Profile Password
            ProfilePassword = ProfilePasswordContent;
            ProfilePassword.Handler_ContinueClicked += new EventHandler<UserProfilePassword.PasswordArgs>(ProfileContinue_Clicked);
            ProfilePassword.Handler_CancelClicked += new EventHandler(ProfileCancel_Clicked);

            // Settings Password
            PasswordPopup = PasswordPromptContent;
            PasswordPopup.Handler_ContinueClicked += new EventHandler<PasswordPrompt.PasswordArgs>(PasswordPromptContinue_Clicked);
            PasswordPopup.Handler_CancelClicked += new EventHandler(PasswordPromptCancel_Clicked);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ProfilePasswordPopup.IsOpen = true;
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (StoredUsers.Count < 5)
            {
                CreateNewUserPopup.IsOpen = true;
            }
            else
            {
                // too many users
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            PasswordPrompt.IsOpen = true;
        }

        public void UpdateUserNames(List<User> updatedUserNames)
        {
            int Index = 0;
            foreach (User User in updatedUserNames)
            {
                UserProfile TempUser = new UserProfile(User.Name);
                TempUser.SetValue(Grid.ColumnProperty, Index);
                TempUser.ProfileButton.Click += new RoutedEventHandler(Profile_Click);

                if (Index >= StoredUsers.Count)
                {
                    UsersGrid.Children.Add(TempUser);
                    StoredUsers.Add(TempUser);
                }
                else StoredUsers[Index] = TempUser;

                Index += 1;
            }

            ColumnDefinition CreateNewCol = new ColumnDefinition();
            UsersGrid.ColumnDefinitions.Add(CreateNewCol);
            
            CreateNewUserProfile.SetValue(Grid.ColumnProperty, Index);
        }

        private void ProfileCancel_Clicked(object sender, EventArgs e)
        {
            ProfilePasswordPopup.Visibility = Visibility.Collapsed;
            ProfilePasswordPopup.IsOpen = false;
        }

        private void ProfileContinue_Clicked(object sender, UserProfilePassword.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                ProfilePasswordPopup.Visibility = Visibility.Collapsed;
                ProfilePasswordPopup.IsOpen = false;
                ProfilePasswordContent.HideErrorMessage();
                Handler_ToHome?.Invoke(this, new EventArgs());
            }
            else
            {
                ProfilePasswordContent.SetErrorMessage();
            }

        }

        private void PasswordPromptCancel_Clicked(object sender, EventArgs e)
        {
            PasswordPrompt.Visibility= Visibility.Collapsed;
            PasswordPrompt.IsOpen = false;
        }

        private void PasswordPromptContinue_Clicked(object sender, PasswordPrompt.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                PasswordPrompt.Visibility = Visibility.Collapsed;
                PasswordPrompt.IsOpen = false;
                ProfilePasswordPopup.Visibility = Visibility.Collapsed;
                ProfilePasswordPopup.IsOpen = false;
                PasswordPromptContent.HideErrorMessage();
                Handler_ToSettings?.Invoke(this, new EventArgs());
            }
            else
            {
                PasswordPopup.SetErrorMessage();
            }
        }

        private void CreateNewUserContinue_Click(object sender, CreateNewUserArgs e)
        {
            Handler_NewUserProfile?.Invoke(this, e);
            CreateNewUserPopup.Visibility = Visibility.Collapsed;
            CreateNewUserPopup.IsOpen = false;
        }

        private void CreateNewUserCancel_Click(object sender, EventArgs e)
        {
            CreateNewUserPopup.Visibility = Visibility.Collapsed;
            CreateNewUserPopup.IsOpen = false;
        }
    }
}