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
    /// Interaction logic for ParentalSettings.xaml
    /// </summary>
    public partial class ParentalSettings : UserControl
    {
        public event EventHandler Handler_BackClicked;
        public ParentalSettings()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, MouseButtonEventArgs e)
        {
            Handler_BackClicked?.Invoke(this, new EventArgs());
        }
    }
}
