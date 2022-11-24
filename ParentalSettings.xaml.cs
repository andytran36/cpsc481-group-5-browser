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
        ContactSettings Contactpopup;

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

        private void ContactSettings_Clicked(object sender, MouseButtonEventArgs e)
        {
            Contactsettingspopup.IsOpen = true;
            Contactpopup = Contactsettingspoupcontent;
            Contactpopup.Handler_CancelClicked += new EventHandler(ContactCancel_Clicked);
            Contactpopup.Handler_SaveClicked += new EventHandler<ContactSettings.ContactInformation>(ContactSave_Clicked);
        }

        private void ContactCancel_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Contact cancel clicked");
            Contactsettingspopup.Visibility = Visibility.Collapsed;
            Contactsettingspopup.IsOpen = false;
        }

        private void ContactSave_Clicked(object sender, ContactSettings.ContactInformation e)
        {
            Contactsettingspopup.Visibility = Visibility.Collapsed;
            Contactsettingspopup.IsOpen = false;
            //do something with contact info
        }
    }
}
