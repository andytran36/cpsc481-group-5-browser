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
    /// Interaction logic for ParentalSettings.xaml
    /// </summary>
    public partial class ParentalSettings : UserControl
    {
        public event EventHandler Handler_BackClicked;
        public event EventHandler Handler_BobChangeClicked;
        public event EventHandler Handler_ToHome;
        ContactSettings ContactPopup;
        PasswordInSettings PwSettingsContent;

        public ParentalSettings()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ParentalSettingsLoaded);
        }

        private void Back_Clicked(object sender, MouseButtonEventArgs e)
        {
            Handler_BackClicked?.Invoke(this, new EventArgs());
        }

        private void changebob(object sender, MouseButtonEventArgs e)
        {
            Handler_BobChangeClicked.Invoke(this, new EventArgs());
        }
        
        private void ParentalSettingsLoaded(object sender, RoutedEventArgs e)
        {
            
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

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PasswordSettings_Clicked(object sender, MouseButtonEventArgs e)
        {
            PwSettingsPopup.IsOpen = true;
            PwSettingsContent = PwSettingsPopupContent;
            PwSettingsContent.Handler_CancelClicked += new EventHandler(PwSettingsCancel_Clicked);
            PwSettingsContent.Handler_ConfirmClicked += new EventHandler<PasswordInSettings.PasswordArgs>(PwSettingsConfirm_Clicked);
        }

        private void PwSettingsCancel_Clicked(object sender, EventArgs e)
        {
            PwSettingsPopup.IsOpen = false;
            PwSettingsPopup.Visibility = Visibility.Collapsed;
        }

        private void PwSettingsConfirm_Clicked(object sender, PasswordInSettings.PasswordArgs e)
        {
            if (e.PasswordMatch && e.GoodPassword)
            {
                PwSettingsPopup.Visibility = Visibility.Collapsed;
                PwSettingsPopup.IsOpen = false;
            }
            else
            {
                if (!e.PasswordMatch)
                {
                    PwSettingsContent.SetNoMatchMsg();
                }

                if (!e.GoodPassword)
                {
                    PwSettingsContent.SetBadPswdMsg();
                }
                
                Debug.WriteLine("Settings password error");
            }
        }

        private void ContactSettings_Clicked(object sender, MouseButtonEventArgs e)
        {
            ContactSettingsPopup.IsOpen = true;
            ContactPopup = ContactSettingsPopupContent;
            ContactPopup.SetOpen();
            ContactPopup.Handler_CancelClicked += new EventHandler(ContactCancel_Clicked);
            ContactPopup.Handler_SaveClicked += new EventHandler<ContactSettings.ContactInformation>(ContactSave_Clicked);
        }

        private void ContactCancel_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Contact cancel clicked");
            ContactSettingsPopup.Visibility = Visibility.Collapsed;
            ContactSettingsPopup.IsOpen = false;
        }

        private void ContactSave_Clicked(object sender, ContactSettings.ContactInformation e)
        {
            if (ContactSettingsPopupContent.EmailValid() == false)
            {
                ContactSettingsPopupContent.HideGeneralMessage();
                ContactSettingsPopupContent.HidePhoneMessage();
                ContactSettingsPopupContent.SetEmailMessage();
            }

            if (ContactSettingsPopupContent.PhoneValid() == false)
            {
                ContactSettingsPopupContent.HideGeneralMessage();
                ContactSettingsPopupContent.HideEmailMessage();
                ContactSettingsPopupContent.SetPhoneMessage();
            }

            if (ContactSettingsPopupContent.NothingToSave() == true)
            {
                ContactSettingsPopupContent.SetGeneralMessage();
            }

            if ((ContactSettingsPopupContent.EmailValid() == true  && ContactSettingsPopupContent.PhoneValid() == true) && ContactSettingsPopupContent.NothingToSave() == false)
            {
                ContactSettingsPopupContent.HideGeneralMessage();
                ContactSettingsPopupContent.HidePhoneMessage();
                ContactSettingsPopupContent.HideEmailMessage();
                ContactSettingsPopup.Visibility = Visibility.Collapsed;
                ContactSettingsPopup.IsOpen = false;
            }
            //do something with contact info
        }
    }
}
