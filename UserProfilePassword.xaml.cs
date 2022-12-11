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
    /// Interaction logic for UserProfilePassword.xaml
    /// </summary>
    public partial class UserProfilePassword : UserControl
    {
        public event EventHandler Handler_CancelClicked;
        public event EventHandler<PasswordArgs> Handler_ContinueClicked;

        public UserProfilePassword()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HideErrorMessage();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordAccepted = false;
            if (Passwordinput.Password.Length >= 6)
            {
                args.PasswordAccepted = true;
            }
            Passwordinput.Clear();
            HideErrorMessage();
            Handler_ContinueClicked?.Invoke(this, args);
        }

        public void HideErrorMessage()
        {
            ErrorMsg.Visibility = Visibility.Hidden;
        }

        public void SetErrorMessage()
        {
            ErrorMsg.Visibility = Visibility.Visible;
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }
    }
}
