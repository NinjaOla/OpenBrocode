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
using Mail;
using OpenBrocode.User;


namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for MailUC.xaml
    /// </summary>
    public partial class MailUC : UserControl
    {
        
        


        public MailUC()
        {
            InitializeComponent();
            
            if(UserHandler.Mail == null)
            {

                UserHandler.mailHandler(UserHandler.getUser().settings.settings.MailUN, UserHandler.getUser().settings.settings.MailPW);

            }
            
            
            

        }

        private void _sendBtn_Click(object sender, RoutedEventArgs e)
        {
            UserHandler.Mail.newMailMessage(UserHandler.Mail.getMailAddress(), mailTo.Text, subject.Text, body.Text);

            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new mailInboxUC());
        }

        private void _cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new mailInboxUC());
        }
    }
}
