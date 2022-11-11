﻿using System;
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
using System.Diagnostics;

namespace cpsc481_group5_browser
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : UserControl
    {
        List<string> History;


        // Event Listeners
        public event EventHandler Handler_BrowserSettingsClicked;


        public Browser()
        {
            InitializeComponent();
            History = new List<string>();
            LoadPage("https://www.google.ca");
        }

        // Routing
        void LoadPage(string Url)
        {
            SearchBox.Text = Url;
            History.Add(Url);
            WebBrowser.Navigate(Url);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.WebBrowser.CanGoBack)
            {
                this.WebBrowser.GoBack();
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (this.WebBrowser.CanGoForward)
            {
                this.WebBrowser.GoForward();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "https://www.google.com".Trim();
            History.Add("https://www.google.com".Trim());
            WebBrowser.Navigate(SearchBox.Text);
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.IsDown)
            {
                string Page = SearchBox.Text.Trim();
                LoadPage(Page);
            }
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
            Handler_BrowserSettingsClicked?.Invoke(this, new EventArgs());
        }
    }
}
