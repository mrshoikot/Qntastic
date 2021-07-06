using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Qntastic.Pages;
using Qntastic.Helpers;
using System.Diagnostics;

namespace Qntastic
{
    /// <summary>
    /// Interaction logic for Queues.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            showQeueus();
            Socket.init();
            Debug.WriteLine("connetion requested");
        }

        public void showDesks()
        {
            Main.Content = new Desks();
        }

        public void showQeueus()
        {
            Main.Content = new Queues();
        }

        public void showEntries()
        {
            Main.Content = new Entries();
        }

        private void SettingPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings swin = new Settings();
            swin.Owner = this;
            swin.Show();
        }

        private void DesksPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showDesks();
        }

        private void QueuePanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showQeueus();
        }
    }
}
