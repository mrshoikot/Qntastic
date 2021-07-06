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
using System.Collections.ObjectModel;
using Qntastic.Models;
using Qntastic.Helpers;

namespace Qntastic
{
    /// <summary>
    /// Interaction logic for CreateQueue.xaml
    /// </summary>
    public partial class CreateQueue : Window
    {

        public ObservableCollection<CustomComboItem> Desks { get; set; }
        public CustomComboItem selectedDesk { get; set; }

        public CreateQueue()
        {
            InitializeComponent();
            DataContext = this;

            Desks = new ObservableCollection<CustomComboItem>();
            bool selected = false;



            foreach (Desk desk in State.AllDesks())
            {
            System.Diagnostics.Debug.WriteLine("fuck");

                CustomComboItem item = new CustomComboItem { id = desk.id, content = desk.name };
                Desks.Add(item);


                if (!selected)
                {
                    selectedDesk = item;
                    selected = true;
                }
            }
        }

        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EnterButton.Foreground = Brushes.Black;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            CustomComboItem selection = (CustomComboItem)deskinput.SelectedItem;
            new Queue { name=nameinput.Text, desk=new Desk(selection.id) }.save();
            ((Dashboard)Owner).showQeueus();
            this.Close();
        }
    }
}
