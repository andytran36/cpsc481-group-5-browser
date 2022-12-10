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
    /// Interaction logic for PasswordPrompt.xaml
    /// </summary>
    public partial class PasswordPrompt : UserControl {
        public EventHandler Handler_CancelClicked;
        public event EventHandler<PasswordArgs> Handler_ContinueClicked;

        public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PopupTitle.Content.ToString() == "Settings")
            {
                PasswordArgs args = new PasswordArgs();
                args.PasswordAccepted = false;
                if (PasswordInput.Password.Length >= 6)
                {
                    args.PasswordAccepted = true;
                }
                PasswordInput.Clear();
                Handler_ContinueClicked?.Invoke(this, args);
            }
            else
            {
                //sends pass to recovery
                Reset();
                //Handler_CancelClicked?.Invoke(this, e);
            }
        }

        public void HideErrorMessage()
        {
            ErrorMsg.Visibility = Visibility.Hidden;
        }

        public void SetErrorMessage()
        {
            ErrorMsg.Visibility = Visibility.Visible;
        }

        private void Forgot_Clicked(object sender, RoutedEventArgs e)
        {
            PopupTitle.Content = "Forgot Admin Password";
            Instruction.Visibility = Visibility.Collapsed;
            PasswordInput.Visibility = Visibility.Collapsed;
            HideErrorMessage();
            ContinueBtn.Content = "Confirm";
            ForgotBtn.Visibility = Visibility.Collapsed;
            ForgotPswdDesc.Visibility = Visibility.Visible;
        }

        private void Reset()
        {
            PopupTitle.Content = "Settings";
            Instruction.Visibility = Visibility.Visible;
            PasswordInput.Visibility = Visibility.Visible;
            HideErrorMessage();
            ContinueBtn.Content = "Continue";
            ForgotBtn.Visibility = Visibility.Visible;
            ForgotPswdDesc.Visibility = Visibility.Collapsed;
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }
    }
}
