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
using Newtonsoft.Json;
using System.IO;

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
            windowController.label1.Visibility = Visibility.Hidden;
            windowController.label2.Visibility = Visibility.Hidden;
            windowController.label3.Visibility = Visibility.Hidden;
            windowController.background_colorbox.Visibility = Visibility.Hidden;
            windowController.topBar_colorbox.Visibility = Visibility.Hidden;
            windowController.sideBar_colorbox.Visibility = Visibility.Hidden;
            windowController._btnRetrieveJSON.Visibility = Visibility.Hidden;
            windowController._btnSetJSON.Visibility = Visibility.Hidden;
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
            
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            background_colorbox.Visibility = Visibility.Visible;
            topBar_colorbox.Visibility = Visibility.Visible;
            sideBar_colorbox.Visibility = Visibility.Visible;
            _btnRetrieveJSON.Visibility = Visibility.Visible;
            _btnSetJSON.Visibility = Visibility.Visible;
        }

        private void _btnRetrieveJSON_Click(object sender, RoutedEventArgs e)
        {
            //deserializing the object(class) from the file
            String jsonString = File.ReadAllText("json.json");
            LayoutClass l1 = JsonConvert.DeserializeObject<LayoutClass>(jsonString);
            background_colorbox.Text = l1.backgroundColor;
            topBar_colorbox.Text = l1.topBoxColor;
            sideBar_colorbox.Text = l1.sideBoxColor;
        }

        private void _btnSetJSON_Click(object sender, RoutedEventArgs e)
        {
            //Serializes the object(class) to the file
            LayoutClass l2 = new LayoutClass { backgroundColor = background_colorbox.Text, sideBoxColor = sideBar_colorbox.Text, topBoxColor = topBar_colorbox.Text };
            String jsonOutput = JsonConvert.SerializeObject(l2);
            File.WriteAllText("json.json", jsonOutput);
        }
    }
}
