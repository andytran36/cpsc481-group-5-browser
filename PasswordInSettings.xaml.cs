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
    /// Interaction logic for PasswordSettingsPopup.xaml
    /// </summary>
    public partial class PasswordInSettings : UserControl
    {
        public EventHandler Handler_CancelClicked;
        public event EventHandler<PasswordArgs> Handler_ConfirmClicked;

        public PasswordInSettings()
        {
            InitializeComponent();
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void Confirmbtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordMatch = false;
            bool ValidLength = Passwordinput.Password.Length >= 6 && Passwordinputconfirm.Password.Length >= 6;
            bool Matches = Passwordinput.Password.Equals(Passwordinputconfirm.Password);
            if (ValidLength && Matches) 
            {
                args.PasswordMatch = true;
            }
            Passwordinput.Clear();
            Handler_ConfirmClicked?.Invoke(this, args);
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordMatch { get; set; }
        }
    }
}
