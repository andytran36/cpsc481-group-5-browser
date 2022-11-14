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
    public partial class UnlockScreen : UserControl {
        public event EventHandler Handler_UnlockScreenClicked;

        public UnlockScreen()
        {
            InitializeComponent();
        }

        // Routing
        void LoadPage(string Url)
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

        }
        // End Routing

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordAccepted = false;
            if(PasswordInput.Password.Length == 6)
            {
                args.PasswordAccepted = true;
            }
            PasswordInput.Clear();
            Handler_UnlockScreenClicked?.Invoke(this, args);
        }

        private void Lock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {

        }

        public class PasswordArgs: EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }

    }
}
