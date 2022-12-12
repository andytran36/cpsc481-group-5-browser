using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ChangeUserSetting.xaml
    /// </summary>
    public partial class ChangeUserSetting : UserControl
    {
        User CurrentUser = new User("", "");

        public event EventHandler Handler_ToSettings;
        public event EventHandler<UserSettingsArgs> Handler_ChangeUserSettings;

        public ChangeUserSetting(User user)
        {
            InitializeComponent();
            CurrentUser = user;

            txtNum.Text = CurrentUser.Hours.ToString();
            txtNum2.Text = CurrentUser.Minutes.ToString();

            Heading.Content = CurrentUser.Name.ToUpper() + "'S SETTINGS";

            Notif_1.IsChecked = CurrentUser.Notif_1;
            Notif_2.IsChecked = CurrentUser.Notif_2;
            Notif_3.IsChecked = CurrentUser.Notif_3;
            Notif_4.IsChecked = CurrentUser.Notif_4;
            Notif_5.IsChecked = CurrentUser.Notif_5;
            Notif_6.IsChecked = CurrentUser.Notif_6;
            Notif_7.IsChecked = CurrentUser.Notif_7;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Handler_ToSettings?.Invoke(this, EventArgs.Empty);
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string Url = e.Uri.ToString();
            SearchBox.Text = Url;
        }
        // End Routing

        private void Lock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UserSettingsArgs args = new UserSettingsArgs();
            args.Notif_1 = Notif_1.IsChecked == true;
            args.Notif_2 = Notif_2.IsChecked == true;
            args.Notif_3 = Notif_3.IsChecked == true;
            args.Notif_4 = Notif_4.IsChecked == true;
            args.Notif_5 = Notif_5.IsChecked == true;
            args.Notif_6 = Notif_6.IsChecked == true;
            args.Notif_7 = Notif_7.IsChecked == true;
            Handler_ChangeUserSettings?.Invoke(this, args);
        }

        //Stack overflow numeric up down

        public int NumValue
        {
            get { return CurrentUser.Hours; }
            set
            {
                CurrentUser.Hours = value;
                txtNum.Text = value.ToString();
            }
        }

        public int NumValue2
        {
            get { return CurrentUser.Minutes; }
            set
            {
                CurrentUser.Minutes = value;
                txtNum2.Text = value.ToString();
            }
        }

        //1 is hours
        //2 is minutes

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdUp_Click2(object sender, RoutedEventArgs e)
        {
            NumValue2+=5;

        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;

        }

        private void cmdDown_Click2(object sender, RoutedEventArgs e)
        {
            NumValue2-=5;

        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (NumValue < 0)
            {
                NumValue = 0;
            }

            if (NumValue > 24)
            {
                NumValue = 24;
            }

            txtNum.Text = CurrentUser.Hours.ToString();
        }

        private void txtNum_TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (txtNum2 == null)
            {
                return;
            }

            if (NumValue2 < 0)
            {
                NumValue2 = 0;
            }

            if (NumValue2 > 59)
            {
                NumValue2 = 59;
            }

            txtNum2.Text =CurrentUser.Minutes.ToString();

        }

        public class UserSettingsArgs : EventArgs
        {
            public bool Notif_1 { get; set; }
            public bool Notif_2 { get; set; }
            public bool Notif_3 { get; set; }
            public bool Notif_4 { get; set; }
            public bool Notif_5 { get; set; }
            public bool Notif_6 { get; set; }
            public bool Notif_7 { get; set; }
            public int Hours { get; set; }
            public int Minutes { get; set; }
        }
    }
}
