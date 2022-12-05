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

        public void SetOpen()
        {
            EmailInput.Text = "user@email.com";
            PhoneInput.Text = "(123)-456-7890";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            EmailInput.Clear();
            PhoneInput.Clear();
            FixEmail();
            FixPhone();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactInformation contactinfo = new ContactInformation();
            contactinfo.Email = EmailInput.Text.Trim();
            contactinfo.PhoneNumber = PhoneInput.Text.Trim();
            contactinfo.EmailPreferred = (bool)EmailPreferredBox.IsChecked ? true : false;
            contactinfo.PhonePreferred = (bool)PhonePreferredBox.IsChecked ? true : false;
            EmailInput.Clear();
            PhoneInput.Clear();
            FixEmail();
            FixPhone();
            Handler_SaveClicked?.Invoke(this, contactinfo);
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

        public class ContactInformation: EventArgs
        {
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public bool EmailPreferred { get; set; }

            public bool PhonePreferred { get; set; }
        }

        private void Typing(object sender, KeyEventArgs e)
        {
            /*
            if (PhoneInput.Text.Length == 1)
            {
                // put space after
                string newstr = PhoneInput.Text + " ";
                PhoneInput.Text = newstr;
                PhoneInput.CaretIndex = 2;
                //phone length 2 now
            }
            */
            if (PhoneInput.Text.Length == 1)
            {
                string newstr = "(" + PhoneInput.Text;
                PhoneInput.Text = newstr;
                //length is 2 now
                PhoneInput.CaretIndex = 2;
            }
           
            if (PhoneInput.Text.Length == 4)
            {
                string newstr = PhoneInput.Text + ") ";
                PhoneInput.Text = newstr;
                //length is 6 now
                PhoneInput.CaretIndex = 6;
            }

            if (PhoneInput.Text.Length == 9)
            {
                string newstr = PhoneInput.Text + "-";
                PhoneInput.Text = newstr;
                //length is 10 now
                PhoneInput.CaretIndex = 11;
            }
        }
    }
}
