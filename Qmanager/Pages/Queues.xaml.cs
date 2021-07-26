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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Qntastic.Models;
using Qntastic.Helpers;
using System.Diagnostics;

namespace Qntastic.Pages
{
    /// <summary>
    /// Interaction logic for Queues.xaml
    /// </summary>
    public partial class Queues : Page
    {
        public Queues()
        {
            InitializeComponent();
            loadQueues();
        }

        private void loadQueues()
        {
            var queues = State.AllQueues();
            if (queues.Count % 2 == 0)
            {
                QueueContainer.ItemsSource = queues.GetRange(0, queues.Count / 2);
            }
            else
            {
                QueueContainer.ItemsSource = queues.GetRange(0, queues.Count / 2+1);
            }

            QueueContainer2.ItemsSource = queues.GetRange(queues.Count / 2, queues.Count/2);
        }

        private void plusButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateQueue cqwin = new CreateQueue();
            cqwin.Owner = Window.GetWindow(this);
            cqwin.Show();
        }

        private void NewEntryButton_Click(object sender, RoutedEventArgs e)
        {
            Queue queue = new Queue((int)((Button)sender).Tag);
            State.SelectedQueue = queue;

            CreateEntry cewin = new CreateEntry();
            cewin.Owner = Window.GetWindow(this);
            cewin.Show();
        }

        private void qitem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Queue queue = new Queue((int)((Border)sender).Tag);  
            State.SelectedQueue = queue;

            ((Dashboard)Window.GetWindow(this)).Main.Content = new Entries();
        }

        private void PlusIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateQueue cqwin = new CreateQueue();
            cqwin.Owner = Window.GetWindow(this);
            cqwin.Show();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Queue queue = new Queue((int)((Button)sender).Tag);
            queue.Move();
            loadQueues();
        }
    }
}
