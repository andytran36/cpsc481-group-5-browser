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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public event EventHandler Handler_ToSettings;
        public event EventHandler Handler_ToBrowser;
        public event EventHandler Handler_ToHome;
        public event EventHandler Handler_ToUserSelect;
        PasswordPrompt PasswordPopup;

        public HomePage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Handler_ToHome?.Invoke(this, new EventArgs());
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        
        }

        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string Url = e.Uri.ToString();
            SearchBox.Text = Url;
        }
        // End Routing

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

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
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

        private void Browse(object sender, MouseButtonEventArgs e)
        {
            Handler_ToBrowser?.Invoke(this, new EventArgs());
            Handler_ToUserSelect?.Invoke(this, new EventArgs());
        }
    }
}
