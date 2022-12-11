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

public struct Settings
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    // TODO: Preferred method of contact here
}

public struct User
{
    public string Name { get; set; }
    public string Password { get; set; }
    // TODO: User settings here 

    public User(string Name, string Password)
    {
        this.Name = Name;
        this.Password = Password;
    }
}


namespace cpsc481_group_5_browser
{
    public partial class MainWindow : Window
    {

        Browser BrowserScreen;
        UserSelect UserSelectScreen;
        TimeLimit TimeLimitPopup;
        HomePage HomeScreen;
        LockScreen LockScreenPopup;
        PasswordPrompt SettingsPasswordPrompt;
        ParentalSettings ParentalSettingsScreen;
        ChangeUserSetting ChangeUserSettingsScreen;
        UserProfilePassword UserProfilePasswordPopup;

        // Hardcoded Values
        List<User> Users = new List<User>
            {
                new User("John", "1234"),
                new User("Bob", "12345"),
            };

        public MainWindow()
        {
            InitializeComponent();

            // Initialize all the screens
            BrowserScreen = new Browser();
            UserSelectScreen = new UserSelect(Users);
            TimeLimitPopup = new TimeLimit();
            HomeScreen = new HomePage();
            LockScreenPopup = new LockScreen();
            SettingsPasswordPrompt = new PasswordPrompt();
            ParentalSettingsScreen = new ParentalSettings();
            ChangeUserSettingsScreen = new ChangeUserSetting();
            UserProfilePasswordPopup = new UserProfilePassword();

            // Browser Handlers
            //BrowserScreen.Handler_LockedScreenClicked += new EventHandler(Handle_LockScreenClicked);
            BrowserScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            BrowserScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            BrowserScreen.Handler_ToHome += new EventHandler(Handle_ToHome);
            BrowserScreen.Handler_ToUserSelect += new EventHandler(Handle_ToUserSelect);

            // User Select Handlers
            UserSelectScreen.Handler_UserProfileClicked += new EventHandler(Handle_UserProfileClicked);
            UserSelectScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            UserSelectScreen.Handler_ToHome += new EventHandler(Handle_ToHome);
            UserSelectScreen.Handler_NewUserProfile += new EventHandler<CreateNewUser.CreateNewUserArgs>(Handle_CreateNewUserProfile);

            // Parental Settings Screen Handlers
            ParentalSettingsScreen.Handler_BobChangeClicked += new EventHandler(Handle_BobChangeSettingsClicked);
            ParentalSettingsScreen.Handler_ToHome += new EventHandler(Handle_ToHome);

            // Home Screen Handlers
            HomeScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            HomeScreen.Handler_ToHome += new EventHandler(Handle_ToHome);
            HomeScreen.Handler_ToUserSelect += new EventHandler(Handle_ToUserSelect);

            //Home Screen Handlers
            HomeScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            HomeScreen.Handler_ToBrowser += new EventHandler(Handle_ToBrowser);

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

        private void Handle_CreateNewUserProfile(object sender, CreateNewUser.CreateNewUserArgs e)
        {
            Debug.WriteLine("Create New User Create Button clicked");
            Users.Add(new User("Test", "12345"));
            UserSelectScreen.UpdateUserNames(Users);
            this.contentControl.Content = UserSelectScreen;
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

        private void Handle_ToBrowser(object sender, EventArgs e)
        {
            this.contentControl.Content = BrowserScreen;
        }
        
        void Handle_ToUserSelect(object sender, EventArgs e)
        {
            this.contentControl.Content = UserSelectScreen;
        }
    }
}