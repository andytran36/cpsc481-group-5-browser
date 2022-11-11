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
    public partial class CreateNewUser : UserControl
    {

        // Event Handlers
        public event EventHandler Handler_CreateNewUserHomeClicked;
        public event EventHandler Handler_CreateNewUserSettingsClicked;
        public event EventHandler<CreateNewUserArgs> Handler_CreateNewUserCreateClicked;

        public CreateNewUser()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserHomeClicked?.Invoke(this, new EventArgs());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserSettingsClicked?.Invoke(this, new EventArgs());
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserArgs args = new CreateNewUserArgs();
            args.Name = CreateUserName.Text.Trim();
            args.Age = CreateUserAge.Text.Trim();


            Handler_CreateNewUserCreateClicked?.Invoke(this, args);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserHomeClicked?.Invoke(this, new EventArgs());
        }

        public class CreateNewUserArgs : EventArgs
        {
            public string Name { get; set; }
            public string Age { get; set; }
        }
    }
}