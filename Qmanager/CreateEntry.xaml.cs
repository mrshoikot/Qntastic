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
    /// Interaction logic for CreateEntry.xaml
    /// </summary>
    public partial class CreateEntry : Window
    {
        public CreateEntry()
        {
            InitializeComponent();
        }

        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EnterButton.Foreground = Brushes.Black;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Entry en = new Entry { name = nameinput.Text, phone = phoneinput.Text, queue = State.SelectedQueue };
            en.save();
            en.sms();
            try
            {
                ((Dashboard)Owner).showEntries();
            }
            catch { }
            this.Close();
        }
    }
}
