using System;
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

namespace ColorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {            
            viewModel.AddColor();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveSelectedColor();
            addButton.IsEnabled = true;
        }

        private void colorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorListBox.SelectedItem != null)
                addButton.IsEnabled = false;
            else
                addButton.IsEnabled = true;
        }

    }
}
