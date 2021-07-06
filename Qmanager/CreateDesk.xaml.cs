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
using Qntastic.Models;
using Qntastic.Pages;

namespace Qntastic
{
    /// <summary>
    /// Interaction logic for CreateDesk.xaml
    /// </summary>
    public partial class CreateDesk : Window
    {
        public CreateDesk()
        {
            InitializeComponent();
        }

        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EnterButton.Foreground = Brushes.Black;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Desk desk = new Desk();
            desk.name = nameinput.Text;
            desk.personal = personalinput.Text;
            desk.save();
            ((Dashboard)Owner).showDesks();
            nameinput.Clear();
            personalinput.Clear();
        }
    }
}
