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
    /// Interaction logic for PinPrompt.xaml
    /// </summary>
    public partial class PinPrompt : UserControl {
        public event EventHandler<PinArgs> Handler_PinContinueClicked;

        public PinPrompt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PinArgs args = new PinArgs();
            args.PinAccepted = false;
            if(PinInput.Password.Length == 6)
            {
                args.PinAccepted = true;
            }
            Handler_PinContinueClicked?.Invoke(this, args);
        }

        public class PinArgs: EventArgs
        {
            public bool PinAccepted { get; set; }
        }

    }
}
