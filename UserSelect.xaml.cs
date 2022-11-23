using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public UserSelect(List<string> UserNames)
        {
            InitializeComponent();

            int index = 0;
            foreach (string User in UserNames)
            {
                Button btn = new Button();
                btn.Content = User;
                btn.SetValue(Grid.ColumnProperty, index);
                btn.Click += new RoutedEventHandler(Profile_Click);
                UsersGrid.Children.Add(btn);
                index += 2;
            }

            Button createNew = new Button();
            createNew.Content = "Create New User";
            createNew.SetValue(Grid.ColumnProperty, 8);
            createNew.Click += new RoutedEventHandler(CreateNewUser_Click);
            UsersGrid.Children.Add(createNew);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profilepasswordpopup.IsOpen = true;
            ProfilePassword = Profilepasswordcontent;
            ProfilePassword.Handler_ContinueClicked += new EventHandler<UserProfilePassword.PasswordArgs>(ProfileContinue_Clicked);
            ProfilePassword.Handler_CancelClicked += new EventHandler(ProfileCancel_Clicked);
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserClicked?.Invoke(this, new EventArgs());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Passwordprompt.IsOpen = true;
            PasswordPopup = Passwordpromptcontent;
            PasswordPopup.Handler_ContinueClicked += new EventHandler<PasswordPrompt.PasswordArgs>(PasswordPromptContinue_Clicked);
            PasswordPopup.Handler_CancelClicked += new EventHandler(PasswordPromptCancel_Clicked);
        }

        public void UpdateUserNames(List<string> UpdatedUserNames)
        {
            int index = 0;
            foreach (string User in UpdatedUserNames)
            {
                Button btn = new Button();
                btn.Content = User;
                btn.SetValue(Grid.ColumnProperty, index);
                btn.Click += new RoutedEventHandler(Profile_Click);
                UsersGrid.Children.Add(btn);
                index += 2;
            }
        }

        private void ProfileCancel_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("User select cancel clicked");
            Profilepasswordpopup.Visibility = Visibility.Collapsed;
            Profilepasswordpopup.IsOpen = false;
        }

        private void ProfileContinue_Clicked(object sender, UserProfilePassword.PasswordArgs e)
        {
            Debug.WriteLine("User select continue clicked");
            if (e.PasswordAccepted)
            {
                Profilepasswordpopup.Visibility = Visibility.Collapsed;
                Profilepasswordpopup.IsOpen = false;
                Handler_ToHome?.Invoke(this, new EventArgs());
            }
            else
            {
                Debug.WriteLine("Profile password error");
            }

        }

        private void PasswordPromptCancel_Clicked(object sender, EventArgs e)
        {
            Passwordprompt.Visibility= Visibility.Collapsed;
            Passwordprompt.IsOpen = false;
        }

        private void PasswordPromptContinue_Clicked(object sender, PasswordPrompt.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                Passwordprompt.Visibility = Visibility.Collapsed;
                Passwordprompt.IsOpen = false;
                Handler_ToSettings?.Invoke(this, new EventArgs());
            }
            else
            {
                Debug.WriteLine("Profile password error");
            }
        }
    }
}