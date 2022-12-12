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
    /// Interaction logic for ChangeUserSetting.xaml
    /// </summary>
    public partial class ChangeUserSetting : UserControl
    {
        private int _numValue = 0;
        private int _numValue2 = 0;
        public ChangeUserSetting()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
            txtNum2.Text = _numValue2.ToString();
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

        }


        //Stack overflow numeric up down

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        public int NumValue2
        {
            get { return _numValue2; }
            set
            {
                _numValue2 = value;
                txtNum2.Text = value.ToString();
            }
        }

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

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
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

            if (!int.TryParse(txtNum2.Text, out _numValue2))
                txtNum2.Text = _numValue2.ToString();
        }
    }
}
