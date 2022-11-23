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
    /// Interaction logic for ContactSettingsPopup.xaml
    /// </summary>
    public partial class ContactSettings : UserControl
    {
        //public EventHandler Handler_CancelClicked;
        //public event EventHandler Handler_ContinueClicked;

        public ContactSettings()
        {
            InitializeComponent();
            Emailinput.Text = "user@email.com";
            Phoneinput.Text = "(123)-456-7890";
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Continuebtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
