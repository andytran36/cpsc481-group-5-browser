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
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : UserControl
    {
        public EventHandler Handler_CancelClicked;
        public event EventHandler<CreateNewUserArgs> Handler_CreateNewUserCreateClicked;

        public CreateNewUser()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            UserPasswordInput.Password = "";
            PasswordInput.Password = "";

            Handler_CancelClicked?.Invoke(this, e);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserArgs args = new CreateNewUserArgs();
            args.Name = NameTextBox.Text.Trim();
            args.Password = UserPasswordInput.Password.Trim();

            NameTextBox.Text = "";
            UserPasswordInput.Password = "";
            PasswordInput.Password = "";

            Handler_CreateNewUserCreateClicked?.Invoke(this, args);
        }

        public class PasswordArgs : EventArgs
        {
            public bool PasswordAccepted { get; set; }
        }

        public class CreateNewUserArgs : EventArgs
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
    }
}
