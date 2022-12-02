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

namespace cpsc481_group5_browser
{
    /// <summary>
    /// Interaction logic for UserSelect.xaml
    /// </summary>
    public partial class UserSelect : UserControl
    {

        public event EventHandler Handler_UserProfileClicked;
        public event EventHandler Handler_CreateNewUserClicked;
        public event EventHandler Handler_ToSettings;
        public event EventHandler Handler_ToHome;
        UserProfilePassword ProfilePassword;
        PasswordPrompt PasswordPopup;
        List<UserProfile> StoredUsers = new List<UserProfile>();
        UserProfile CreateNewUserProfile;

        public UserSelect(List<string> userNames)
        {
            InitializeComponent();

            int Index = 0;
            foreach (string User in userNames)
            {
                ColumnDefinition ColDef = new ColumnDefinition();
                UsersGrid.ColumnDefinitions.Add(ColDef);

                UserProfile TempUser = new UserProfile(User);
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
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ProfilePasswordPopup.IsOpen = true;
            ProfilePassword = ProfilePasswordContent;
            ProfilePassword.Handler_ContinueClicked += new EventHandler<UserProfilePassword.PasswordArgs>(ProfileContinue_Clicked);
            ProfilePassword.Handler_CancelClicked += new EventHandler(ProfileCancel_Clicked);
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserClicked?.Invoke(this, new EventArgs());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            PasswordPrompt.IsOpen = true;
            PasswordPopup = PasswordPromptContent;
            PasswordPopup.Handler_ContinueClicked += new EventHandler<PasswordPrompt.PasswordArgs>(PasswordPromptContinue_Clicked);
            PasswordPopup.Handler_CancelClicked += new EventHandler(PasswordPromptCancel_Clicked);
        }

        public void UpdateUserNames(List<string> updatedUserNames)
        {
            int Index = 0;
            foreach (string User in updatedUserNames)
            {
                UserProfile TempUser = new UserProfile(User);
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
            Debug.WriteLine("User select cancel clicked");
            ProfilePasswordPopup.Visibility = Visibility.Collapsed;
            ProfilePasswordPopup.IsOpen = false;
        }

        private void ProfileContinue_Clicked(object sender, UserProfilePassword.PasswordArgs e)
        {
            Debug.WriteLine("User select continue clicked");
            if (e.PasswordAccepted)
            {
                ProfilePasswordPopup.Visibility = Visibility.Collapsed;
                ProfilePasswordPopup.IsOpen = false;
                Handler_ToHome?.Invoke(this, new EventArgs());
            }
            else
            {
                Debug.WriteLine("Profile password error");
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
                Handler_ToSettings?.Invoke(this, new EventArgs());
            }
            else
            {
                PasswordPopup.SetErrorMessage();
                Debug.WriteLine("Profile password error");
            }
        }
    }
}