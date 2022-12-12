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
    /// Interaction logic for ParentalSettingsUser.xaml
    /// </summary>
    public partial class ParentalSettingsUser : UserControl
    {
        public int Index;

        public event EventHandler<UserProfileArgs> Handler_UserSettingsClicked;

        public ParentalSettingsUser(int index, string name)
        {
            InitializeComponent();

            Index = index;
            Name.Content = name;
        }

        private void UserProfileClicked(object sender, RoutedEventArgs e) { 
            UserProfileArgs args = new UserProfileArgs();
            args.Index = Index;

            Handler_UserSettingsClicked?.Invoke(this, args);
        }

        public class UserProfileArgs : EventArgs
        {
            public int Index { get; set; }
        }
    }
}
