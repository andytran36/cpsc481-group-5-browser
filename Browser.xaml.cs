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
        public event EventHandler Handler_ToHome;
        PasswordPrompt PasswordPopup;

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
            Handler_LockedScreenClicked?.Invoke(this, new EventArgs());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            PasswordPrompt.IsOpen = true;
            PasswordPopup = PasswordPromptContent;
            PasswordPopup.Handler_ContinueClicked += new EventHandler<PasswordPrompt.PasswordArgs>(PasswordPromptContinue_Clicked);
            PasswordPopup.Handler_CancelClicked += new EventHandler(PasswordPromptCancel_Clicked);
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