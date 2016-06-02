using OpenBrocode.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for mailInboxUC.xaml
    /// </summary>
    public partial class mailInboxUC : UserControl
    {
        public mailInboxUC()
        {
            InitializeComponent();
            
        }



        public void getMails()
        {
            UserHandler.Mail.retrieveUnseenMessages();
            List<MailMessage> messages = UserHandler.Mail.messages.ToList();
            //So we get newest mails first.
            messages.Reverse();

            listbox1.ItemsSource = messages;

            //Bindings in .xaml changed from "Sender" to "From" sender didnt leave a mail adress or anything.

        }

        private void _btnWriteMail_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new MailUC());
        }

        private void _btnLoadMail_Click(object sender, RoutedEventArgs e)
        {
            //Added this button because it was quite slow. So optional to load emails.
            getMails();
        }
    }
}
