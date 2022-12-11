using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ContactSettingsPopup.xaml
    /// </summary>
    public partial class ContactSettings : UserControl
    {
        public event EventHandler Handler_CancelClicked;
        public event EventHandler<ContactInformation> Handler_SaveClicked;

        public ContactSettings()
        {
            InitializeComponent();
            EmailInput.Text = "user@email.com";
            PhoneInput.Text = "(123)-456-7890";
        }

        public bool IsDefaultEmail()
        {
            if (EmailInput.Text == "user@email.com")
            {
                return true;
            }
            return false;
        }

        public bool IsDefaultPhone()
        {
            if (PhoneInput.Text == "(123)-456-7890")
            {
                return true;
            }
            return false;
        }

        public void SetOpen()
        {
            EmailInput.Text = "user@email.com";
            PhoneInput.Text = "(123)-456-7890";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            EmailPreferredBox.IsChecked = false;
            PhonePreferredBox.IsChecked = false;
            EmailInput.Clear();
            PhoneInput.Clear();
            FixEmail();
            FixPhone();
            HideEmailMessage();
            HidePhoneMessage();
            HideGeneralMessage();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactInformation contactinfo = new ContactInformation();
            contactinfo.Email = EmailInput.Text.Trim();
            contactinfo.PhoneNumber = PhoneInput.Text.Trim();
            contactinfo.EmailPreferred = (bool)EmailPreferredBox.IsChecked ? true : false;
            contactinfo.PhonePreferred = (bool)PhonePreferredBox.IsChecked ? true : false;
            Handler_SaveClicked?.Invoke(this, contactinfo);
            //EmailInput.Clear();
            //PhoneInput.Clear();
            //EmailPreferredBox.IsChecked = false;
            //PhonePreferredBox.IsChecked = false;
            FixEmail();
            FixPhone();
        }

        private void EmailInput_Clicked(object sender, RoutedEventArgs e)
        {
            EmailInput.Clear();
            EmailInput.GotFocus -= EmailInput_Clicked;
        }

        private void FixEmail()
        {
            EmailInput.GotFocus += EmailInput_Clicked;
        }

        private void PhoneInput_Clicked(object sender, RoutedEventArgs e)
        {
            PhoneInput.Clear();
            PhoneInput.GotFocus -= PhoneInput_Clicked;
        }

        private void FixPhone()
        {
            PhoneInput.GotFocus += PhoneInput_Clicked;
        }

        private void ValidatePhoneInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9\\-\\(\\)]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EmailChecked(object sender, RoutedEventArgs e)
        {
            if ((bool)PhonePreferredBox.IsChecked)
            {
                PhonePreferredBox.IsChecked = false;
            }
        }

        private void PhoneChecked(object sender, RoutedEventArgs e)
        {
            if ((bool)EmailPreferredBox.IsChecked)
            {
                EmailPreferredBox.IsChecked = false;
            }
        }

        public bool EmailValid()
        {
            if (EmailPreferredBox.IsChecked == true && (EmailInput.Text.Trim().Length == 0 || IsDefaultEmail()))
            {
                return false;
            }
            return true;
        }

        public bool PhoneValid()
        {
            if (PhonePreferredBox.IsChecked == true && (PhoneInput.Text.Trim().Length == 0 || IsDefaultPhone()))
            {
                return false;
            }
            return true;
        }

        public bool NothingToSave()
        {
            if (EmailPreferredBox.IsChecked == false && PhonePreferredBox.IsChecked == false)
            {
                return true;
            }
            return false;
        }

        public void HideEmailMessage()
        {
            EmailMsg.Visibility = Visibility.Hidden;
        }

        public void SetEmailMessage()
        {
            EmailMsg.Visibility = Visibility.Visible;
        }

        public void HidePhoneMessage()
        {
            PhoneMsg.Visibility = Visibility.Hidden;
        }

        public void SetPhoneMessage()
        {
            PhoneMsg.Visibility = Visibility.Visible;
        }

        public void HideGeneralMessage()
        {
            GeneralMsg.Visibility = Visibility.Hidden;
        }

        public void SetGeneralMessage()
        {
            GeneralMsg.Visibility = Visibility.Visible;
        }

        public class ContactInformation: EventArgs
        {
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public bool EmailPreferred { get; set; }

            public bool PhonePreferred { get; set; }
        }
    }
}
