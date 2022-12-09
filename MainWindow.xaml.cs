using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using cpsc481_group5_browser;
using static cpsc481_group5_browser.CreateNewUser;

namespace cpsc481_group_5_browser
{
    public partial class MainWindow : Window
    {

        Browser BrowserScreen;
        UserSelect UserSelectScreen;
        CreateNewUser CreateNewUserScreen;
        TimeLimit TimeLimitPopup;
        HomePage HomeScreen;
        LockScreen LockScreenPopup;
        PasswordPrompt SettingsPasswordPrompt;
        ParentalSettings ParentalSettingsScreen;
        ChangeUserSetting ChangeUserSettingsScreen;
        UserProfilePassword UserProfilePasswordPopup;

        // Hardcoded Values
        List<string> UserNames = new List<string>
            {
                "John",
                "Bob",
            };

        public MainWindow()
        {
            InitializeComponent();

            // Initialize all the screens
            BrowserScreen = new Browser();
            UserSelectScreen = new UserSelect(UserNames);
            CreateNewUserScreen = new CreateNewUser();
            TimeLimitPopup = new TimeLimit();
            HomeScreen = new HomePage();
            LockScreenPopup = new LockScreen();
            SettingsPasswordPrompt = new PasswordPrompt();
            ParentalSettingsScreen = new ParentalSettings();
            ChangeUserSettingsScreen = new ChangeUserSetting();
            UserProfilePasswordPopup = new UserProfilePassword();

            // Browser Handlers
            BrowserScreen.Handler_LockedScreenClicked += new EventHandler(Handle_LockScreenClicked);
            BrowserScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            BrowserScreen.Handler_ToUserSelect += new EventHandler(Handle_ToUserSelect);

            // LockScreen Handlers
            LockScreenPopup.Handler_LockClicked += new EventHandler(Handle_LockScreenClicked);

            // User Select Handlers
            UserSelectScreen.Handler_UserProfileClicked += new EventHandler(Handle_UserProfileClicked);
            UserSelectScreen.Handler_CreateNewUserClicked += new EventHandler(Handle_CreateNewUserClicked);
            UserSelectScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            UserSelectScreen.Handler_ToHome += new EventHandler(Handle_ToHome);

            // Create New User Handlers
            CreateNewUserScreen.Handler_CreateNewUserHomeClicked += new EventHandler(Handle_HomeClicked);
            CreateNewUserScreen.Handler_CreateNewUserSettingsClicked += new EventHandler(Handle_SettingsClicked);
            CreateNewUserScreen.Handler_CreateNewUserCreateClicked += new EventHandler<CreateNewUserArgs>(Handle_CreateNewUserCreateClicked);

            // Password Screen Handlers
            

            // Parental Settings Screen Handlers
            ParentalSettingsScreen.Handler_BobChangeClicked += new EventHandler(Handle_BobChangeSettingsClicked);

            //Home Screen Handlers
            HomeScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            HomeScreen.Handler_ToUserSelect += new EventHandler(Handle_ToUserSelect);

            // Set Screen to User Select on System Startup
            this.contentControl.Content = UserSelectScreen;

        }

        private void Handle_HomeClicked(object sender, EventArgs e)
        {
            this.contentControl.Content = UserSelectScreen;
        }

        private void Handle_SettingsClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("settings clicked");
            //TODO: deal with popup
            this.contentControl.Content = SettingsPasswordPrompt;
        }

        private void Handle_UserProfileClicked(object sender, EventArgs e)
        {
            //TODO: deal with popup
            Debug.WriteLine("User Profile clicked");
        }

        private void Handle_CreateNewUserClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Create New User Screen clicked");

            // Check for password first and then navigate here
            this.contentControl.Content = CreateNewUserScreen;
        }

        private void Handle_CreateNewUserCreateClicked(object sender, CreateNewUserArgs e)
        {
            Debug.WriteLine("Create New User Create Button clicked");
            UserNames.Add(e.Name);
            UserSelectScreen.UpdateUserNames(UserNames);
            this.contentControl.Content = UserSelectScreen;
        }

        private void Handle_LockScreenClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Lock Screen clicked");
            //TODO: deal with popup
            this.contentControl.Content = LockScreenPopup;
        }
        
        private void Handle_BobChangeSettingsClicked(object sender, EventArgs e)
        {
            this.contentControl.Content = ChangeUserSettingsScreen;
        }

        private void Handle_ToSettings(object sender, EventArgs e)
        {
            //Goes to settings after password confirmed
            this.contentControl.Content = ParentalSettingsScreen;
        }

        private void Handle_ToHome(object sender, EventArgs e)
        {
            this.contentControl.Content = HomeScreen;
        }

        private void Handle_ToUserSelect(object sender, EventArgs e)
        {
            this.contentControl.Content = UserSelectScreen;
        }
    }
}