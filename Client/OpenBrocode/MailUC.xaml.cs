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


namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for MailUC.xaml
    /// </summary>
    public partial class MailUC : UserControl
    {
        private mailSender mailObj;
        public MailUC()
        {
            InitializeComponent();
            mailObj = new mailSender("openbrocode@gmail.com", "brocode1337");

        }

        private void _sendBtn_Click(object sender, RoutedEventArgs e)
        {
            mailObj.newMailMessage(mailObj.getMailAddress(), mailTo.Text, subject.Text, body.Text);
            subject.Text = "Mail sent";
        }

        private void _cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new HomeViewUC());
        }
    }
}
