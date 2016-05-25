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
using System.Windows.Media.Animation;

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
            //windowController.aTest.Content = "this is a test";
            //windowController.aTest.Background = Brushes.Black; 
            //this.initialLoadPanel();
            this.loadWelcomePanel();
        }

        public void loadWelcomePanel()
        {
            stackMid.Children.Clear();
            WelcomeUC welUcObject = new WelcomeUC();
            stackMid.Children.Add(welUcObject);
        }

        public void initialLoadPanel()
        {
            stackMid.Children.Clear();
            LeftSideBarUC leftUcObject = new LeftSideBarUC();
            stackLeft.Children.Add(leftUcObject);

            HomeViewUC midUcObject = new HomeViewUC();
            stackMid.Children.Add(midUcObject);

            TopBarUC topUcObject = new TopBarUC();
            stackTop.Children.Add(topUcObject);
        }

        public void loadPanel(UserControl view)
        {
            stackMid.Children.Clear();
            stackMid.Children.Add(view);
        }
    }
}
