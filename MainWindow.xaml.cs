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
    public bool EmailPreferred { get; set; }
    public bool PhonePreferred { get; set; }
}

public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public bool Notif_1 { get; set; }
    public bool Notif_2 { get; set; }
    public bool Notif_3 { get; set; }
    public bool Notif_4 { get; set; }

    public int Hours { get; set; }
    public int Minutes { get; set; }

    public bool Notif_5 { get; set; }
    public bool Notif_6 { get; set; }
    public bool Notif_7 { get; set; }
    // TODO: User settings here 

    public User(string Name, string Password)
    {
        this.Name = Name;
        this.Password = Password;
        Notif_1 = false;
        Notif_2 = false;
        Notif_3 = false;
        Notif_4 = false;

        Hours = 0;
        Minutes = 0;

        Notif_5 = false;
        Notif_6 = false;
        Notif_7 = false;
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

        int CurrentUser;

        // Hardcoded Values
        List<User> Users = new List<User>
            {
                new User("John", "1234"),
                new User("Bob", "12345"),
            };

        Settings GeneralSettings; 

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
            
            ParentalSettingsScreen = new ParentalSettings(ref GeneralSettings, Users);
            UserProfilePasswordPopup = new UserProfilePassword();

            // Browser Handlers
            //BrowserScreen.Handler_LockedScreenClicked += new EventHandler(Handle_LockScreenClicked);
            BrowserScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            BrowserScreen.Handler_ToHome += new EventHandler(Handle_ToHome);
            BrowserScreen.Handler_ToUserSelect += new EventHandler(Handle_ToUserSelect);

            // User Select Handlers
            UserSelectScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            UserSelectScreen.Handler_ToHome += new EventHandler(Handle_ToHome);
            UserSelectScreen.Handler_NewUserProfile += new EventHandler<CreateNewUser.CreateNewUserArgs>(Handle_CreateNewUserProfile);

            // Parental Settings Screen Handlers
            ParentalSettingsScreen.Handler_UserSettingsClicked += new EventHandler<ParentalSettingsUser.UserProfileArgs>(Handle_UserSettingsClicked);
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

        private void Handle_UserSettingsClicked(object sender, ParentalSettingsUser.UserProfileArgs e)
        {
            CurrentUser = e.Index;
            ChangeUserSettingsScreen = new ChangeUserSetting(Users[CurrentUser]);
            ChangeUserSettingsScreen.Handler_ToSettings += new EventHandler(Handle_ToSettings);
            ChangeUserSettingsScreen.Handler_ChangeUserSettings += new EventHandler<ChangeUserSetting.UserSettingsArgs>(Handle_ChangeUserSettings);
            this.contentControl.Content = ChangeUserSettingsScreen;
        }

        private void Handle_ChangeUserSettings(object sender, ChangeUserSetting.UserSettingsArgs e)
        {
            Users[CurrentUser].Notif_1 = e.Notif_1;
            Users[CurrentUser].Notif_2 = e.Notif_2;
            Users[CurrentUser].Notif_3 = e.Notif_3;
            Users[CurrentUser].Notif_4 = e.Notif_4;
            Users[CurrentUser].Notif_5 = e.Notif_5;
            Users[CurrentUser].Notif_6 = e.Notif_6;
            Users[CurrentUser].Notif_7 = e.Notif_7;
            Users[CurrentUser].Hours = e.Hours;
            Users[CurrentUser].Minutes = e.Minutes;
        }

        private void Handle_SettingsClicked(object sender, EventArgs e)
        {
            this.contentControl.Content = SettingsPasswordPrompt;
        }

        private void Handle_CreateNewUserProfile(object sender, CreateNewUser.CreateNewUserArgs e)
        {
            Users.Add(new User(e.Name, e.Password));
            UserSelectScreen.UpdateUserNames(Users);
            ParentalSettingsScreen.UpdateUsers(Users);
            this.contentControl.Content = UserSelectScreen;
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