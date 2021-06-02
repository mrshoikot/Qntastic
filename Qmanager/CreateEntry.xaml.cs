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

namespace Qmanager
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
    }
}
