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
using System.Drawing;


namespace cpsc481_group_5_browser
{
    public partial class MainWindow : Window
    {
        List<string> History; // list of webpages visited since the browser was opened
        public MainWindow()
        {
            InitializeComponent();
            History = new List<string>();
            LoadPage("https://www.google.ca");
        }

        // Routing
        void LoadPage(string Url)
        {
            searchBox.Text = Url;
            History.Add(Url);
            webBrowser.Navigate(Url);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (this.webBrowser.CanGoBack)
            {
                this.webBrowser.GoBack();
            }
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (this.webBrowser.CanGoForward)
            {
                this.webBrowser.GoForward();
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "https://www.google.com".Trim();
            History.Add("https://www.google.com".Trim());
            webBrowser.Navigate(searchBox.Text);
        }

        private void area_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.IsDown)
            {
                string Page = searchBox.Text.Trim();
                LoadPage(Page);
            }
        }

        private void webBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string Url = e.Uri.ToString();
            searchBox.Text = Url;
        }
        // End Routing

        private void lock_Click(object sender, RoutedEventArgs e)
        {
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
