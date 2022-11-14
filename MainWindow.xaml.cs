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
        PinPrompt EnterPinScreen;
        ParentalSettings ParentalSettingsScreen;
        ChangeUserSetting ChangeUserSettingsScreen;

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
            EnterPinScreen = new PinPrompt();
            ParentalSettingsScreen = new ParentalSettings();
            ChangeUserSettingsScreen = new ChangeUserSetting();

            // Browser Handlers
            BrowserScreen.Handler_BrowserSettingsClicked += new EventHandler(Handle_SettingsClicked);

            // User Select Handlers
            UserSelectScreen.Handler_UserProfileClicked += new EventHandler(Handle_UserProfileClicked);
            UserSelectScreen.Handler_UserSelectSettingsClicked += new EventHandler(Handle_SettingsClicked);
            UserSelectScreen.Handler_CreateNewUserClicked += new EventHandler(Handle_CreateNewUserClicked);

            // Create New User Handlers
            CreateNewUserScreen.Handler_CreateNewUserHomeClicked += new EventHandler(Handle_HomeClicked);
            CreateNewUserScreen.Handler_CreateNewUserSettingsClicked += new EventHandler(Handle_SettingsClicked);
            CreateNewUserScreen.Handler_CreateNewUserCreateClicked += new EventHandler<CreateNewUserArgs>(Handle_CreateNewUserCreateClicked);

            //Pin Screen Handlers
            EnterPinScreen.Handler_PinContinueClicked += new EventHandler<PinPrompt.PinArgs>(Handle_PinContinueClicked);

            //Parental Settings Screen Handlers
            ParentalSettingsScreen.Handler_BobChangeClicked += new EventHandler(Handle_BobChangeSettingsClicked);

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
            // Navigate to Parental Settings
            this.contentControl.Content = EnterPinScreen;
        }

        private void Handle_UserProfileClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("User Profile clicked");
            this.contentControl.Content = BrowserScreen;
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

        private void Handle_PinContinueClicked(object sender, PinPrompt.PinArgs e)
        {
            if (e.PinAccepted)
            {
                Debug.WriteLine("To settings");
                this.contentControl.Content = ParentalSettingsScreen;
            }
            else
            {
                Debug.WriteLine("Error");
            }
        }
        
        private void Handle_BobChangeSettingsClicked(object sender, EventArgs e)
        {
            this.contentControl.Content = ChangeUserSettingsScreen;
        }
    }
}