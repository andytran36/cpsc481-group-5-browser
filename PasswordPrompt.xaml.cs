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
using static cpsc481_group5_browser.LockScreen;

namespace cpsc481_group5_browser
{
    /// <summary>
    /// Interaction logic for PasswordPrompt.xaml
    /// </summary>
    public partial class PasswordPrompt : UserControl {
        public event EventHandler<PasswordArgs> Handler_PasswordContinueClicked;

        public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordAccepted = false;
            if(PasswordInput.Password.Length == 6)
            {
                args.PasswordAccepted = true;
            }
            PasswordInput.Clear();
            Handler_PasswordContinueClicked?.Invoke(this, args);
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }

    }
}
