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
using System.Windows.Media.Imaging;
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
            this.loadPanel();
        }

        private void loadPanel()
        {
            LeftSideBarUC leftUcObject = new LeftSideBarUC();
            stackLeft.Children.Add(leftUcObject);

            HomeViewUC midUcObject = new HomeViewUC();
            stackMid.Children.Add(midUcObject);

            TopBarUC topUcObject = new TopBarUC();
            stackTop.Children.Add(topUcObject);
        }

        public void loadHomePanel()
        {
            stackMid.Children.Clear();
            HomeViewUC midHomeObject = new HomeViewUC();
            stackMid.Children.Add(midHomeObject);
        }

        public void loadMailPanel()
        {
            stackMid.Children.Clear();
            MailUC midMailObject = new MailUC();
            stackMid.Children.Add(midMailObject);
        }


        public void loadFacePanel()
        {
            stackMid.Children.Clear();
            FacebookUC midFaceUC = new FacebookUC();
            stackMid.Children.Add(midFaceUC);
        }

        public void loadTwitterPanel()
        {
            stackMid.Children.Clear();
            TwitterUC midTwitUC = new TwitterUC();
            stackMid.Children.Add(midTwitUC);
        }

        public void loadSettingsPanel()

        {
            stackMid.Children.Clear();
            SettingsUC midSetUC = new SettingsUC();
            stackMid.Children.Add(midSetUC);
        }

    }
}
