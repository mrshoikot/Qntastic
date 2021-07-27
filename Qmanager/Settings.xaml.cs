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

namespace Qntastic
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EnterButton.Foreground = Brushes.Black;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            State.setInst(instInput.Text);
            this.Hide();
        }
    }
}
