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
    /// Interaction logic for TopBarUC.xaml
    /// </summary>
    public partial class TopBarUC : UserControl
    {
        public TopBarUC()
        {
            InitializeComponent();
            setLabelUsernameWindows();


        }

        private void setLabelUsernameWindows()
        {
            lblTop.Content = "Name: " + Environment.UserName;
        }

        private void _btnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new SettingsUC());
        }
    }
}
