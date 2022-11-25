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

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordInput.Clear();
            PasswordInputConfirm.Clear();
            HideBadPswdMsg();
            HideNoMatchMsg();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordMatch = false;
            bool ValidLength = PasswordInput.Password.Length >= 6 && PasswordInputConfirm.Password.Length >= 6;
            bool Matches = PasswordInput.Password.Equals(PasswordInputConfirm.Password);
            if (ValidLength && Matches) 
            {
                args.PasswordMatch = true;
                args.GoodPassword = true;
            }else if (!ValidLength && Matches)
            {
                args.PasswordMatch = true;
                args.GoodPassword = false;
            }else if (ValidLength && !Matches)
            {
                args.PasswordMatch = false;
                args.GoodPassword = true;
            }
            else
            {
                args.PasswordMatch = false;
                args.GoodPassword = false;
            }
            PasswordInput.Clear();
            PasswordInputConfirm.Clear();
            HideNoMatchMsg();
            HideBadPswdMsg();
            Handler_ConfirmClicked?.Invoke(this, args);
        }

        public void HideNoMatchMsg()
        {
            NoMatchMsg.Visibility = Visibility.Hidden;
        }

        public void HideBadPswdMsg()
        {
            BadPwMsg.Visibility = Visibility.Hidden;
        }

        public void SetNoMatchMsg()
        {
            NoMatchMsg.Visibility = Visibility.Visible;
        }

        public void SetBadPswdMsg()
        {
            if (NoMatchMsg.Visibility == Visibility.Visible)
            {
                Thickness mymargin = BadPwMsg.Margin;
                mymargin.Top = 21;
                BadPwMsg.Margin = mymargin;
                BadPwMsg.Visibility = Visibility.Visible;
            }
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordMatch { get; set; }
            public bool GoodPassword { get; set; }
        }
    }
}
