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
    /// Interaction logic for ForgotPasswordUC.xaml
    /// </summary>
    public partial class ForgotPasswordUC : UserControl
    {
        public ForgotPasswordUC()
        {
            InitializeComponent();
        }

        private void Reset_password_Click(object sender, RoutedEventArgs e)
        {
            //Implement password reset function that sends an e-mail to the user with a link to reset/specify new password
            //If the e-mail is not found as a registered user, notice the user and give option to register if they are not a user yet
            MessageBox.Show("Not implemented yet!");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //If the user cancels, return back to the login screen
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadWelcomePanel();
        }
    }
}
