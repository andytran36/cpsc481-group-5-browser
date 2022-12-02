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
    public partial class LockScreen : UserControl {
        public event EventHandler Handler_CancelClicked;
        public event EventHandler<PasswordArgs> Handler_LockClicked;
        

        public LockScreen()
        {
            InitializeComponent();
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            HideErrorMsg();
            Handler_CancelClicked?.Invoke(this, e);
        }

        private void Lockbtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordAccepted = false;

            if(Passwordinput.Password.Length >= 6)
            {
                args.PasswordAccepted = true;
            }
            HideErrorMsg();
            Passwordinput.Clear();
            Handler_LockClicked?.Invoke(this, args);
        }

        public void SetErrorMsg()
        {
            ErrorMsg.Visibility = Visibility.Visible;
        }

        public void HideErrorMsg()
        {
            ErrorMsg.Visibility = Visibility.Hidden;
        }

        public class PasswordArgs: EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }
    }
}
