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


namespace Qntastic.Pages
{
    /// <summary>
    /// Interaction logic for Desks.xaml
    /// </summary>
    public partial class Desks : Page
    {
        public Desks()
        {
            InitializeComponent();
            loadDesks();
        }

        private void loadDesks()
        {
            DeskContainer.ItemsSource = State.AllDesks();
        }

        private void PlusIcon_Mousedown(object sender, MouseButtonEventArgs e)
        {
            CreateDesk cdWin = new CreateDesk();
            cdWin.Owner = Window.GetWindow(this);
            cdWin.Show();
            System.Diagnostics.Debug.WriteLine("");
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Desk desk = new Desk((int)((Button)sender).Tag);
            desk.delete(desk.id);
            loadDesks();
        }

    }
}
