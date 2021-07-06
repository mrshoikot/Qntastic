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
using Qntastic;
using System.Diagnostics;


namespace Qntastic.Pages
{
    /// <summary>
    /// Interaction logic for Desks.xaml
    /// </summary>
    public partial class Entries : Page
    {
        public Entries()
        {
            InitializeComponent();
            loadEntries();
        }

        private void loadEntries()
        {
            EntryContainer.ItemsSource = State.SelectedQueue.Entries();
        }

        private void PlusIcon_Mousedown(object sender, MouseButtonEventArgs e)
        {
            CreateEntry cdWin = new CreateEntry();
            cdWin.Owner = Window.GetWindow(this);
            cdWin.Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Entry entry = new Entry((int)((Button)sender).Tag);
            entry.delete(entry.id);
            loadEntries();
        }
    }
}
