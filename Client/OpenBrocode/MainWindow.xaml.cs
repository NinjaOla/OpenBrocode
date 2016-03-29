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

namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow windowController
        {
            get
            {
                return ((MainWindow)System.Windows.Application.Current.MainWindow);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            windowController.aTest.Content = "this is a test";
            windowController.aTest.Background = Brushes.Black; 
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button butt = (Button)sender;
 
            
        }


        private void _btnSetting_Click(object sender, RoutedEventArgs e)
        {
            settingsToggle();
        }

        private void settingsToggle()
        {
            
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            background_colorbox.Visibility = Visibility.Hidden;
            topBar_colorbox.Visibility = Visibility.Hidden;
            sideBar_colorbox.Visibility = Visibility.Hidden;
        }
    }
}
