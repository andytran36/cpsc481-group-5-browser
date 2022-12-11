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
    /// Interaction logic for TimeLimit.xaml
    /// </summary>
    public partial class TimeLimit : UserControl
    {
        List<string> History;


        // Event Listeners
        public event EventHandler Handler_ContinueClicked;

        public TimeLimit()
        {
            InitializeComponent();
        }

        private void Continuebtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordArgs args = new PasswordArgs();
            args.PasswordAccepted = false;
            if (Passwordinput.Password.Length >= 6)
            {
                args.PasswordAccepted = true;
            }
            Passwordinput.Clear();
            HideErrorMsg();
            Handler_ContinueClicked?.Invoke(this, args);
        }

        public void SetErrorMsg()
        {
            ErrorMsg.Visibility = Visibility.Visible;
        }

        public void HideErrorMsg()
        {
            ErrorMsg.Visibility = Visibility.Hidden;
        }
        
        public class PasswordArgs : EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }
    }
}
