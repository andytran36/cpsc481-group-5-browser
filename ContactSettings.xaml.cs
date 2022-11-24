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
            Emailinput.Text = "user@email.com";
            Phoneinput.Text = "(123)-456-7890";
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            Emailinput.Clear();
            Phoneinput.Clear();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            ContactInformation contactinfo = new ContactInformation();
            contactinfo.Email = Emailinput.Text.Trim();
            contactinfo.Phonenumber = Phoneinput.Text.Trim();
            Emailinput.Clear();
            Phoneinput.Clear();
            Handler_SaveClicked?.Invoke(this, contactinfo);
        }

        public class ContactInformation: EventArgs
        {
            public string Email { get; set; }
            public string Phonenumber { get; set; }
        }

        private void PhoneNum_Pressed(object sender, KeyEventArgs e)
        {
            
        }
    }
}
