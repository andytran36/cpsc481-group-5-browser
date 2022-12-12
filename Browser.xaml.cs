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
using System.Diagnostics;

namespace cpsc481_group5_browser
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : UserControl
    {
        List<string> History;


        // Event Listeners
        public event EventHandler Handler_LockedScreenClicked;
        public event EventHandler Handler_ToSettings;
        PasswordPrompt PasswordPopup;
        public event EventHandler Handler_Lock;
        LockScreen LockPopup;
        public event EventHandler Handler_Unlock;
        UnlockScreen UnlockPopup;
        public event EventHandler Handler_ToHome;
        public event EventHandler Handler_ToUserSelect;

        public Browser()
        {
            InitializeComponent();
            History = new List<string>();
            LoadPage("https://www.google.ca");
        }

        // Routing
        void LoadPage(string Url)
        {
            SearchBox.Text = Url;
            History.Add(Url);
            WebBrowser.Navigate(Url);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.WebBrowser.CanGoBack)
            {
                this.WebBrowser.GoBack();
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (this.WebBrowser.CanGoForward)
            {
                this.WebBrowser.GoForward();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //SearchBox.Text = "https://www.google.com".Trim();
            //History.Add("https://www.google.com".Trim());
            //WebBrowser.Navigate(SearchBox.Text);
            Handler_ToHome?.Invoke(this, new EventArgs());
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.IsDown)
            {
                string Page = SearchBox.Text.Trim();
                LoadPage(Page);
            }
        }

        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string Url = e.Uri.ToString();
            SearchBox.Text = Url;
        }
        // End Routing

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            Lockpopup.IsOpen = true;
            LockPopup = Lockpopupcontent;
            LockPopup.Handler_CancelClicked += new EventHandler(LockCancel_Clicked);
            LockPopup.Handler_LockClicked += new EventHandler<LockScreen.PasswordArgs>(LockContinue_Clicked);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            PasswordPrompt.IsOpen = true;
            PasswordPopup = PasswordPromptContent;
            PasswordPopup.Handler_ContinueClicked += new EventHandler<PasswordPrompt.PasswordArgs>(PasswordPromptContinue_Clicked);
            PasswordPopup.Handler_CancelClicked += new EventHandler(PasswordPromptCancel_Clicked);
        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            Unlockpopup.IsOpen = true;
            UnlockPopup = Unlockpopupcontent;
            UnlockPopup.Handler_CancelClicked += new EventHandler(UnlockCancel_Clicked);
            UnlockPopup.Handler_UnlockClicked += new EventHandler<UnlockScreen.PasswordArgs>(UnlockContinue_Clicked);
        }

        private void PasswordPromptCancel_Clicked(object sender, EventArgs e)
        {
            PasswordPrompt.Visibility = Visibility.Collapsed;
            PasswordPrompt.IsOpen = false;
        }

        private void PasswordPromptContinue_Clicked(object sender, PasswordPrompt.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                PasswordPrompt.Visibility = Visibility.Collapsed;
                PasswordPrompt.IsOpen = false;
                PasswordPopup.HideErrorMessage();
                Handler_ToSettings?.Invoke(this, new EventArgs());
            }
            else
            {
                PasswordPopup.SetErrorMessage();
            }
        }

        private void LockCancel_Clicked(object sender, EventArgs e)
        {
            Lockpopup.Visibility = Visibility.Collapsed;
            Lockpopup.IsOpen = false;
        }

        private void LockContinue_Clicked(object sender, LockScreen.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                Lockpopup.Visibility = Visibility.Collapsed;
                Lockpopup.IsOpen = false;
                NormalBar.Visibility = Visibility.Collapsed;
                LockedBar.Visibility = Visibility.Visible;
                LockPopup.HideErrorMsg();
            }
            else
            {
                LockPopup.SetErrorMsg();
            }

        }

        private void UnlockCancel_Clicked(object sender, EventArgs e)
        {
            Unlockpopup.Visibility = Visibility.Collapsed;
            Unlockpopup.IsOpen = false;
        }

        private void UnlockContinue_Clicked(object sender, UnlockScreen.PasswordArgs e)
        {
            if (e.PasswordAccepted)
            {
                Unlockpopup.Visibility = Visibility.Collapsed;
                Unlockpopup.IsOpen = false;
                NormalBar.Visibility = Visibility.Visible;
                LockedBar.Visibility = Visibility.Collapsed;
                UnlockPopup.HideErrorMsg();
            }
            else
            {
                UnlockPopup.SetErrorMsg();
            }
        }

        void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            Handler_ToUserSelect?.Invoke(this, new EventArgs());
        }
    }
}