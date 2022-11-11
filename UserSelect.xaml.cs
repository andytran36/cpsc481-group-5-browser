using Microsoft.VisualBasic.ApplicationServices;
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
    /// Interaction logic for UserSelect.xaml
    /// </summary>
    public partial class UserSelect : UserControl
    {

        public event EventHandler Handler_UserProfileClicked;
        public event EventHandler Handler_CreateNewUserClicked;
        public event EventHandler Handler_UserSelectSettingsClicked;

        public UserSelect(List<string> UserNames)
        {
            InitializeComponent();

            int index = 0;
            foreach (string User in UserNames)
            {
                Button btn = new Button();
                btn.Content = User;
                btn.SetValue(Grid.ColumnProperty, index);
                btn.Click += new RoutedEventHandler(Profile_Click);
                UsersGrid.Children.Add(btn);
                index += 2;
            }

            Button createNew = new Button();
            createNew.Content = "Create New User";
            createNew.SetValue(Grid.ColumnProperty, 8);
            createNew.Click += new RoutedEventHandler(CreateNewUser_Click);
            UsersGrid.Children.Add(createNew);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Handler_UserProfileClicked?.Invoke(this, new EventArgs());
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            Handler_CreateNewUserClicked?.Invoke(this, new EventArgs());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Handler_UserSelectSettingsClicked?.Invoke(this, new EventArgs());
        }

        public void UpdateUserNames(List<string> UpdatedUserNames)
        {
            int index = 0;
            foreach (string User in UpdatedUserNames)
            {
                Button btn = new Button();
                btn.Content = User;
                btn.SetValue(Grid.ColumnProperty, index);
                btn.Click += new RoutedEventHandler(Profile_Click);
                UsersGrid.Children.Add(btn);
                index += 2;
            }
        }
    }
}